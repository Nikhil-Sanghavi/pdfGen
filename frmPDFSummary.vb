Imports System.IO
Public Class frmPDFSummary
    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Dim fsLogFileStream As FileStream
    Dim fsLogStreamWriter As StreamWriter
    Private Sub frmPDFSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatus.ForeColor = Color.Red
    End Sub
    Private Sub txtExportPDFPath_TextChanged(sender As Object, e As EventArgs) Handles txtImagePath.TextChanged
        If txtImagePath.Text.Trim <> "" Then
            btnRetriveDocPDFSize.Enabled = True
        Else
            btnRetriveDocPDFSize.Enabled = False
        End If
    End Sub
    Private Sub btnBrowsePDFFolder_Click(sender As Object, e As EventArgs)
        txtImagePath.Text = ""
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtImagePath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub btnRetriveDocPDFSize_Click(sender As Object, e As EventArgs) Handles btnRetriveDocPDFSize.Click
        GrpMain.Enabled = False
        Try
            Dim ImgPAth As String = txtImagePath.Text
            If Not Directory.Exists(ImgPAth) Then
                MessageBox.Show("Original Image Path not Exists" & ImgPAth)
                txtImagePath.Focus()
                GoTo OUT
            End If

            Dim strTarget As String = ""
            blnExit = False
            blnQuit = False

            fsLogFileStream = New FileStream(ImgPAth + "\CDOPDFSize.txt", FileMode.Append, FileAccess.Write)
            fsLogStreamWriter = New StreamWriter(fsLogFileStream)

            fsLogStreamWriter.WriteLine("*" & vbTab & "Folder" & vbTab & "PDFId" & vbTab & "A4" & vbTab & "A4_R" & vbTab & "Legal" & vbTab & "Legal_R" & vbTab & "A3" & vbTab & "A3_R" & vbTab & "A2" & vbTab & "A2_R" & vbTab & "A1" & vbTab & "A1_R" & vbTab & "A0" & vbTab & "A0_R" & vbTab & "MAP" & vbTab & "MAP_R" & vbTab & "BigArea" & vbTab & "BigArea_R")
            fsLogStreamWriter.Flush()

            ProcessDirectory(ImgPAth)
            fsLogStreamWriter.Flush()
            fsLogStreamWriter.Close()
            fsLogFileStream.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(fsLogStreamWriter) Then
                fsLogStreamWriter.Close()
            End If
            If Not IsNothing(fsLogFileStream) Then
                fsLogFileStream.Close()
            End If
        End Try
        If blnExit Or blnQuit Then
            MsgBox("Quit From Process")
        Else
            MsgBox("Over")
        End If
        GrpMain.Enabled = True
        Exit Sub
OUT:
        GrpMain.Enabled = True
    End Sub
    Private Sub ProcessDirectory(ByVal targetDirectory As String)
        Try
            If blnExit Or blnQuit Then
                Exit Sub
            End If
            If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    blnExit = True
                    Exit Sub
                End If
            End If
            lblStatus.Text = "Current Directory:" & targetDirectory
            Application.DoEvents()

            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)

            Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*.PDF")
            Dim A4Img As Integer = 0
            Dim LegalImg As Integer = 0
            Dim A3Img As Integer = 0
            Dim A2Img As Integer = 0
            Dim A1Img As Integer = 0
            Dim A0Img As Integer = 0
            Dim MAPImg As Integer = 0
            Dim bigAreaImg As Integer = 0

            Dim A4Img_R As Integer = 0
            Dim LegalImg_R As Integer = 0
            Dim A3Img_R As Integer = 0
            Dim A2Img_R As Integer = 0
            Dim A1Img_R As Integer = 0
            Dim A0Img_R As Integer = 0
            Dim MAPImg_R As Integer = 0
            Dim bigAreaImg_R As Integer = 0

            Dim blnRepair As Boolean = False

            If (fileEntries.Length > 0) Then
                lblStatus.Text = "Current Directory:" & targetDirectory & "  TOTAL PDF: " & fileEntries.Length
                Application.DoEvents()
                Try
                    ' Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
                    For Each fi As FileInfo In di.GetFiles("*.PDF")

                        A4Img = 0
                        LegalImg = 0
                        A3Img = 0
                        A2Img = 0
                        A1Img = 0
                        A0Img = 0
                        MAPImg = 0
                        bigAreaImg = 0

                        A4Img_R = 0
                        LegalImg_R = 0
                        A3Img_R = 0
                        A2Img_R = 0
                        A1Img_R = 0
                        A0Img_R = 0
                        MAPImg_R = 0
                        bigAreaImg_R = 0

                        blnRepair = False

                        'Dim fi As New FileInfo(Img)
                        Dim ImgNm As String = fi.Name
                        Dim WIDTH As Integer
                        Dim Height As Integer
                        Dim PDFFileNM As String = Mid(fi.Name, 1, InStrRev(fi.Name, ".") - 1).ToUpper
                        If PDFFileNM.EndsWith("R") Then
                            blnRepair = True
                        Else
                            blnRepair = False
                        End If
                        If ImgNm.Contains("_SIZE") Then
                            WIDTH = Mid(ImgNm, InStr(ImgNm, "_SIZE_") + 6, 5)
                            Height = Mid(ImgNm, InStr(ImgNm, "_SIZE_") + 12, 5)
                        Else
                            WIDTH = 0
                            Height = 0
                        End If
                        Dim bigArea As Integer = 0
                        Dim PaperSize As Char = CalculatePaperSize(WIDTH, Height, bigArea)
                        'If blnRepair Then
                        '    bigAreaImg_R += bigArea
                        'Else
                        'bigAreaImg += bigArea
                        'End If
                        If PaperSize = "4" Then
                            A4Img += 1
                            If blnRepair Then
                                A4Img_R += 1
                            End If
                        ElseIf PaperSize = "L" Then
                            LegalImg += 1
                            If blnRepair Then
                                LegalImg_R += 1
                            End If
                        ElseIf PaperSize = "3" Then
                            A3Img += 1
                            If blnRepair Then
                                A3Img_R += 1
                            End If
                        ElseIf PaperSize = "2" Then
                            A2Img += 1
                            If blnRepair Then
                                A2Img_R += 1
                            End If
                        ElseIf PaperSize = "1" Then
                            A1Img += 1
                            If blnRepair Then
                                A1Img_R += 1
                            End If
                        ElseIf PaperSize = "0" Then
                            A0Img += 1
                            If blnRepair Then
                                A0Img_R += 1
                            End If
                        ElseIf PaperSize = "M" Then
                            MAPImg += 1
                            bigAreaImg += bigArea
                            If blnRepair Then
                                MAPImg_R += 1
                                bigAreaImg_R += bigArea
                            End If
                        End If
                        fsLogStreamWriter.WriteLine(PaperSize & vbTab & fi.DirectoryName & vbTab & fi.Name & vbTab & A4Img & vbTab & A4Img_R & vbTab & LegalImg & vbTab & LegalImg_R & vbTab & A3Img & vbTab & A3Img_R & vbTab & A2Img & vbTab & A2Img_R & vbTab & A1Img & vbTab & A1Img_R & vbTab & A0Img & vbTab & A0Img_R & vbTab & MAPImg & vbTab & MAPImg_R & vbTab & bigAreaImg & vbTab & bigAreaImg_R)
                        fsLogStreamWriter.Flush()

                    Next
                    ' fsLogStreamWriter.WriteLine(targetDirectory & vbTab & "  TOTAL PDF: " & fileEntries.Length & vbTab & "PDF FOUND-CONVERT IT TO IMAGE FIRST")
                    'di = New DirectoryInfo(targetDirectory)
                    ' CheckPDFPaperSize(targetDirectory)
                Catch ex As Exception
                    Throw ex
                End Try
            End If

            If blnExit OrElse blnQuit Then
                Exit Sub
            End If

            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory) '.OrderBy(Function(fn) fn)
            Array.Sort(subdirectoryEntries)

            Dim subdirectory As String = ""
            For Each subdirectory In subdirectoryEntries
                If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                    If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        blnExit = True
                        Exit For
                    End If
                End If
                Try
                    ProcessDirectory(subdirectory)
                Catch ex As Exception
                    Throw ex
                End Try
                If blnExit OrElse blnQuit Then
                    Exit For
                End If
            Next subdirectory

            If blnExit Then
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class