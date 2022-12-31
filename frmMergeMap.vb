Imports System.IO
Public Class frmMergeMap
    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Dim blnError As Boolean = False

    Dim strImgPath As String = ""
    Dim strMapImgPath As String = ""
    Dim diMap As New Dictionary(Of String, String)

    Private Sub frmMergeMap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtExportImagesPath.Text = ExportImgPAth
    End Sub
    Private Sub btnBrowseImagesFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseImagesFolder.Click
        txtExportImagesPath.Text = ""
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strPath As String = FolderBrowserDialog1.SelectedPath
            txtExportImagesPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub btnBrowsePDFFolder_Click(sender As Object, e As EventArgs) Handles btnBrowsePDFFolder.Click
        txtMapImagePath.Text = ""
        If FolderBrowserDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strPath As String = FolderBrowserDialog2.SelectedPath
            txtMapImagePath.Text = FolderBrowserDialog2.SelectedPath
        End If
    End Sub

    Private Sub txtExportImagesPath_TextChanged(sender As Object, e As EventArgs) Handles txtExportImagesPath.TextChanged
        EnableDisable()
    End Sub

    Private Sub txtExportPDFPath_TextChanged(sender As Object, e As EventArgs) Handles txtMapImagePath.TextChanged
        EnableDisable()
    End Sub

    Private Sub EnableDisable()
        If txtExportImagesPath.Text.Trim = "" OrElse txtMapImagePath.Text.Trim = "" Then
            btnMergeMap.Enabled = False
        Else
            btnMergeMap.Enabled = True
        End If
    End Sub

    Private Sub btnMergeMap_Click(sender As Object, e As EventArgs) Handles btnMergeMap.Click
        GrpMain.Enabled = False
        Dim TargetLogFileNm As String = ""

        Try
            blnError = False
            blnQuit = False
            blnExit = False

            strImgPath = txtExportImagesPath.Text
            strMapImgPath = txtMapImagePath.Text

            ProcessDirectory(strMapImgPath, 2)

            ProcessDirectory(strImgPath, 1)

        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo OUT
        Finally
            lblMsg.Text = ""
        End Try

        Dim strMsg As String = ""
        MsgBox(IIf(blnExit, "QUIT FROM PROCESS " & strMsg, " OVER " & strMsg))
OUT:
        GrpMain.Enabled = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub RecursionMapFolder(ByVal targetDir As String)
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessDirectory(ByVal targetDirectory As String, ByVal formatType As Integer)
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

            Me.Text = "Current Directory:" & targetDirectory
            Application.DoEvents()

            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)

            'Dim fileEntries1 As String() = Directory.GetFiles(targetDirectory, "*." & ImgExtension)

            If formatType = 1 Then
                Dim totEntries As Integer = Directory.GetFiles(targetDirectory, "*.jpg").Count + Directory.GetFiles(targetDirectory, "*.tif").Count

                'Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*.*").Where()

                'var filteredFiles = Directory.GetFiles(Path, "*.*").Where(File >= File.ToLower().EndsWith("aspx") || file.ToLower().EndsWith("ascx")).ToList();

                'Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories.Where(s >= s.EndsWith(".JPG") Or s.EndsWith(".TIF"))

                If (totEntries > 0) Then
                    Me.Text = "Current Directory:" & targetDirectory & "  TOTAL IMAGES: " & totEntries
                    Application.DoEvents()
                    Try
                        di = New DirectoryInfo(targetDirectory)
                        Dim DIRNM As String = di.Name
                        If DIRNM.EndsWith("_1") OrElse DIRNM.EndsWith("_2") Then 'NIS 202211  LastFolderNm = "CDAPDF"
                            DIRNM = Mid(di.Name, 1, 5)
                            If di.Name.Contains("_") = False Then
                                DIRNM = "XXX"
                            End If
                        End If

                        If IsNumeric(DIRNM) AndAlso IsNumeric(di.Parent.Name) Then
                            Dim IndexVal As String = Mid(targetDirectory, InStrRev(targetDirectory, "\") + 1).Split("_")(0)
                            If diMap.ContainsKey(IndexVal) Then
                                processfile(targetDirectory, diMap(IndexVal))
                            End If
                        End If

                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
            Else
                Dim totEntries As Integer = Directory.GetFiles(targetDirectory, "*.jpg").Count
                If totEntries > 0 Then
                    Dim mapImgPath As String = targetDirectory
                    Dim FldNm As String = Mid(targetDirectory, InStrRev(targetDirectory, "\") + 1) '.Split("_")(0)
                    Dim IndexVal As String = ""
                    Dim blnFnd As Boolean = False
                    For Each c In FldNm
                        If IsNumeric(c) Then
                            IndexVal &= c
                            blnFnd = True
                        Else
                            If blnFnd Then
                                Exit For
                            End If
                        End If
                    Next
                    IndexVal = Format(CInt(IndexVal), "00000")
                    If IsNumeric(IndexVal) AndAlso diMap.ContainsKey(IndexVal) = False Then
                        diMap.Add(IndexVal, targetDirectory)
                    ElseIf IsNumeric(IndexVal) Then
                        diMap(IndexVal) = diMap(IndexVal) & "|" & targetDirectory
                    End If
                End If
            End If

            If blnExit OrElse blnQuit OrElse blnError Then
                Exit Sub
            End If
            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory) '.OrderBy(Function(fn) fn)
            Array.Sort(subdirectoryEntries)

            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries
                If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                    If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        blnExit = True
                        Exit For
                    End If
                End If
                Try
                    ProcessDirectory(subdirectory, formatType)
                Catch ex As Exception
                    Throw ex
                End Try
                If blnExit OrElse blnQuit OrElse blnError Then
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
    Private Sub processfile(ByVal targetdir As String, ByVal MapImgPath As String)
        Try
            For Each strpath In MapImgPath.Split("|")
                If Not Directory.Exists(strpath) Then
                    Continue For
                End If
                Dim di As DirectoryInfo = New DirectoryInfo(strpath)
                    For Each fi In di.GetFiles("*." & ImgExtension)
                    Dim fileNm As String = "Z_" & fi.Name
                    If File.Exists(targetdir & "\" & fileNm) = False Then
                        File.Copy(fi.FullName, targetdir & "\" & fileNm)
                    End If
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
End Class