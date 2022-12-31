Imports iText.Kernel.Pdf
Imports iText.Kernel.Utils
Imports iText.Pdfocr
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmGenerateExcelFromPDFPaperSize 'frmSetSize
    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Dim fsLogFileStream As FileStream
    Dim fsLogStreamWriter As StreamWriter
    Dim imgEdit As New Atalasoft.Imaging.WinControls.WorkspaceViewer
    Private Sub frmGenerateExcelFromPDFPaperSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub txtExportPDFPath_TextChanged(sender As Object, e As EventArgs) Handles txtPDFImagePath.TextChanged
        If txtPDFImagePath.Text.Trim <> "" Then
            btnRetriveDocPDFSize.Enabled = True
        Else
            btnRetriveDocPDFSize.Enabled = False
        End If
    End Sub
    Private Sub btnBrowsePDFFolder_Click(sender As Object, e As EventArgs) Handles btnBrowsePDFImageFolder.Click
        txtPDFImagePath.Text = ""
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPDFImagePath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub btnRetriveDocPDFSize_Click(sender As Object, e As EventArgs) Handles btnRetriveDocPDFSize.Click
        GrpMain.Enabled = False
        Try
            Dim PDFPAth As String = txtPDFImagePath.Text
            If Not Directory.Exists(PDFPAth) Then
                MessageBox.Show("Original PDF Path not Exists" & PDFPAth)
                txtPDFImagePath.Focus()
                GoTo OUT
            End If

            Dim strTarget As String = ""
            blnExit = False
            blnQuit = False

            fsLogFileStream = New FileStream(PDFPAth + "\CDOPDFPageSize.txt", FileMode.Append, FileAccess.Write)
            fsLogStreamWriter = New StreamWriter(fsLogFileStream)
            ProcessDirectory(PDFPAth)
            fsLogStreamWriter.Flush()
            fsLogStreamWriter.Close()
            fsLogFileStream.Close()

            'Dim di As DirectoryInfo = New DirectoryInfo(PDFPAth)
            'Dim pdfDoc2 As PdfDocument = Nothing
            'For Each fi In di.GetFiles("*.PDF")
            '    pdfDoc2 = New PdfDocument(New PdfReader(fi))
            '    Dim PsIZE As iText.Kernel.Geom.Rectangle = pdfDoc2.GetPage(1).GetPageSize
            '    ' Dim P As PdfDocumentInfo = pdfDoc2.GetDocumentInfo
            '    'rectangle width and height are measured in points 72 points to an inch
            '    Dim Width As Double = Math.Round(PsIZE.GetWidth / 72, 2) 'rectangle width and height are measured in points 72 points to an inch
            '    Dim Height As Double = Math.Round(PsIZE.GetHeight / 72, 2) 'rectangle width and height are measured in points 72 points to an inch
            '    pdfDoc2.Close()
            'Next

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
            Me.Text = "Current Directory:" & targetDirectory
            Application.DoEvents()

            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)

            If chkRenameMapFolderName.Checked Then 'Dis 20/12/2022
                If di.Name.Contains("-") OrElse di.Name.Contains("_") Then
                    Dim c As Char = Mid(di.Name, 1, 1)
                    Dim c1 As Char = Mid(di.Name, 2, 1)
                    Dim c3 As String = Mid(di.Name, 3)
                    If di.Name.Contains("-") Then 'dis 26/12/2022
                        c3 = Mid(di.Name, InStr(di.Name, "-") + 1)
                    Else
                        c3 = Mid(di.Name, InStr(di.Name, "_") + 1)
                    End If

                    'If (c1 = "-" OrElse c1 = "_") AndAlso IsNumeric(c) = False Then
                    If IsNumeric(c) = False Then
                        If IsNumeric(c3) Then
                            Rename(di.FullName, di.Parent.FullName & "\" & Format(CInt(c3), "00000"))
                            di = New DirectoryInfo(di.Parent.FullName & "\" & Format(CInt(c3), "00000"))
                            targetDirectory = di.Parent.FullName & "\" & Format(CInt(c3), "00000")
                        End If
                    End If
                End If
            End If

            Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*.PDF")

            If (fileEntries.Length > 0) Then
                Me.Text = "Current Directory:" & targetDirectory & "  TOTAL PDF: " & fileEntries.Length
                Application.DoEvents()
                Try
                    'fsLogStreamWriter.WriteLine(targetDirectory & vbTab & "  TOTAL PDF: " & fileEntries.Length & vbTab & "PDF FOUND-CONVERT IT TO IMAGE FIRST")
                    'di = New DirectoryInfo(targetDirectory)
                    CheckPDFPaperSize(targetDirectory)
                Catch ex As Exception
                    Throw ex
                End Try
            End If

            If blnExit OrElse blnQuit Then
                Exit Sub
            End If

            Dim fileEntries1 As String() = Directory.GetFiles(targetDirectory, "*.JPG")

            If (fileEntries1.Length > 0) Then
                Me.Text = "Current Directory:" & targetDirectory & "  TOTAL JPG: " & fileEntries1.Length
                Application.DoEvents()
                Try
                    'di = New DirectoryInfo(targetDirectory)
                    CheckJPEGPaperSize(targetDirectory)
                Catch ex As Exception
                    Throw ex
                End Try
            End If


            If blnExit OrElse blnQuit Then
                Exit Sub
            End If

            Dim fileEntries2 As String() = Directory.GetFiles(targetDirectory, "*.TIF*")

            If (fileEntries2.Length > 0) Then
                Me.Text = "Current Directory:" & targetDirectory & "  TOTAL TIFF: " & fileEntries2.Length
                Application.DoEvents()
                Try
                    'di = New DirectoryInfo(targetDirectory)
                    CheckTIFFPaperSize(targetDirectory)
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
    Private Sub CheckPDFPaperSize(ByRef PDFPath As String)
        Dim di As DirectoryInfo = New DirectoryInfo(PDFPath)
        Dim pdfDoc2 As PdfDocument = Nothing
        Try
            For Each fi In di.GetFiles("*.PDF")
                pdfDoc2 = New PdfDocument(New PdfReader(fi))
                Dim TotPages As Integer = pdfDoc2.GetNumberOfPages
                For ind As Integer = 1 To TotPages
                    Dim PSize As iText.Kernel.Geom.Rectangle = pdfDoc2.GetPage(1).GetPageSize
                    ' Dim P As PdfDocumentInfo = pdfDoc2.GetDocumentInfo
                    'rectangle width and height are measured in points 72 points to an inch
                    'Dim Width As Double = Math.Round(PSize.GetWidth / 72, 2) 'Rectangle width and height are measured in points 72 points to an inch
                    'Dim Height As Double = Math.Round(PSize.GetHeight / 72, 2) 'Rectangle width and height are measured in points 72 points to an inch
                    Dim Width As Integer = Math.Round(PSize.GetWidth * 100 / 72, 0) 'Rectangle width and height are measured in points 72 points to an inch
                    Dim Height As Integer = Math.Round(PSize.GetHeight * 100 / 72, 0) 'Rectangle width and height are measured in points 72 points to an inch
                    pdfDoc2.Close()

                    fn_RenameFile(fi, Width, Height)

                    fsLogStreamWriter.WriteLine(fi.FullName & vbTab & Width & vbTab & Height & vbTab)
                    fsLogStreamWriter.Flush()
                Next

            Next

            'For Each fi In di.GetFiles("*.JPG")
            '    imgEdit.Open(fi.FullName)
            '    Dim Width As Integer = imgEdit.Image.Width / imgEdit.Image.Resolution.X
            '    Dim height As Integer = imgEdit.Image.Height / imgEdit.Image.Resolution.Y
            '    fsLogStreamWriter.WriteLine(fi.FullName & vbTab & Width & vbTab & height & vbTab & blnRepair)
            '    fsLogStreamWriter.Flush()
            '    If Not IsNothing(imgEdit.Image) Then
            '        imgEdit.Image.Dispose()
            '    End If
            'Next

            'For Each fi In di.GetFiles("*.TIF")
            '    imgEdit.Open(fi.FullName)
            '    Dim Width As Integer = imgEdit.Image.Width / imgEdit.Image.Resolution.X
            '    Dim height As Integer = imgEdit.Image.Height / imgEdit.Image.Resolution.Y
            '    fsLogStreamWriter.WriteLine(fi.FullName & vbTab & Width & vbTab & height & vbTab & blnRepair)
            '    fsLogStreamWriter.Flush()
            '    If Not IsNothing(imgEdit.Image) Then
            '        imgEdit.Image.Dispose()
            '    End If
            'Next

        Catch ex As Exception
            fsLogStreamWriter.WriteLine(PDFPath & vbTab & ex.Message)
            fsLogStreamWriter.Flush()
            'Throw ex
        Finally
            If Not IsNothing(pdfDoc2) Then
                pdfDoc2.Close()
                pdfDoc2 = Nothing
            End If
        End Try
    End Sub
    Private Sub CheckJPEGPaperSize(ByRef PDFPath As String)
        Dim di As DirectoryInfo = New DirectoryInfo(PDFPath)
        Dim pct As New PictureBox
        Dim fs As FileStream = Nothing

        Try
            For Each fi In di.GetFiles("*.JPG")
                fs = File.OpenRead(fi.FullName)
                'imgEdit.Open(fi.FullName)
                'Dim Width As Integer = imgEdit.Image.Width / imgEdit.Image.Resolution.X
                'Dim height As Integer = imgEdit.Image.Height / imgEdit.Image.Resolution.Y
                pct.Image = Image.FromStream(fs, True, False) ' New Bitmap(fi.FullName) 'Image.FromFile(fi.FullName)
                Dim Width As Integer = pct.Image.Width * 100 / pct.Image.HorizontalResolution
                Dim Height As Integer = pct.Image.Height * 100 / pct.Image.VerticalResolution
                If Not IsNothing(pct.Image) Then
                    pct.Image.Dispose()
                End If
                If Not IsNothing(fs) Then
                    fs.Close()
                End If
                fn_RenameFile(fi, Width, Height)

                'ImgFile = fi.Name.ToUpper
                'Dim sIZE As String = ""
                'If Width < Height Then
                '    sIZE = Format(Width, "000") & "_" & Format(Height, "000")
                'Else
                '    sIZE = Format(Height, "000") & "_" & Format(Width, "000")
                'End If
                'If PDFFileNM.EndsWith("R") Then
                '    blnRepair = True
                '    If PDFFileNM.Contains("_SIZE") = False Then
                '        ImgFile = ImgFile.Replace(".JPG", "_SIZE_" & sIZE & "_R.JPG")
                '    End If
                'Else
                '    blnRepair = False
                '    If PDFFileNM.Contains("_SIZE") = False Then
                '        ImgFile = ImgFile.Replace(".JPG", "_SIZE_" & sIZE & ".JPG")
                '    End If
                'End If
                'If PDFFileNM.Contains("_SIZE") = False Then
                '    If File.Exists(fi.DirectoryName & "\" & ImgFile) = False Then
                '        Rename(fi.FullName, fi.DirectoryName & "\" & ImgFile)
                '    Else
                '        fsLogStreamWriter.WriteLine(fi.FullName & vbTab & "NEW FILE NAME: " & PDFFileNM & " FILE RENAMING PROBLEM. FILE ALREAY EXISTS")
                '        fsLogStreamWriter.Flush()
                '    End If
                'End If

                fsLogStreamWriter.WriteLine(fi.FullName & vbTab & Width & vbTab & Height & vbTab)
                fsLogStreamWriter.Flush()
            Next
        Catch ex As Exception
            fsLogStreamWriter.WriteLine(PDFPath & vbTab & ex.Message)
            fsLogStreamWriter.Flush()
        Finally
            If Not IsNothing(pct.Image) Then
                pct.Image.Dispose()
            End If
            If Not IsNothing(fs) Then
                fs.Close()
            End If
            If Not IsNothing(imgEdit.Image) Then
                imgEdit.Image.Dispose()
            End If
        End Try
    End Sub
    Private Sub CheckTIFFPaperSize(ByRef PDFPath As String)
        Dim di As DirectoryInfo = New DirectoryInfo(PDFPath)
        Try
            For Each fi In di.GetFiles("*.TIF*")
                'If PDFFileNM.EndsWith("R") Then
                '    blnRepair = True
                'Else
                '    blnRepair = False
                'End If
                imgEdit.Open(fi.FullName)
                Dim Width As Integer = imgEdit.Image.Width * 100 / imgEdit.Image.Resolution.X
                Dim height As Integer = imgEdit.Image.Height * 100 / imgEdit.Image.Resolution.Y
                If Not IsNothing(imgEdit.Image) Then
                    imgEdit.Image.Dispose()
                End If
                If Not IsNothing(imgEdit.Image) Then
                    imgEdit.Image.Dispose()
                End If

                fn_RenameFile(fi, Width, height)
                fsLogStreamWriter.WriteLine(fi.FullName & vbTab & Width & vbTab & height & vbTab)
                fsLogStreamWriter.Flush()

            Next
        Catch ex As Exception
            fsLogStreamWriter.WriteLine(PDFPath & vbTab & ex.Message)
            fsLogFileStream.Flush()
        End Try
    End Sub
    Private Sub fn_RenameFile(fi As FileInfo, Width As Integer, Height As Integer)
        Dim blnRepair As Boolean
        Dim ImgFile As String
        Dim ImgFileExtension As String = fi.Extension.ToUpper
        ImgFile = fi.Name.ToUpper

        Dim ImgFileName As String = Mid(ImgFile, 1, InStrRev(ImgFile, ".") - 1)
        Dim blnchng As Boolean = False

        Dim sIZE As String = ""
        If Width < Height Then
            sIZE = Format(Width, "00000") & "_" & Format(Height, "00000")
        Else
            sIZE = Format(Height, "00000") & "_" & Format(Width, "00000")
        End If
        If chkRenameImagesForAdditionalImages.Checked Then ' Dis 20/12/2022
            ImgFile = ImgFile.Replace(ImgFileExtension, "_001-GENERAL" & ImgFileExtension)
        End If
        If ImgFileName.EndsWith("R") Then
            blnRepair = True
            If ImgFileName.Contains("_SIZE") = False Then
                ImgFile = ImgFile.Replace(ImgFileExtension, "_SIZE_" & sIZE & "_R" & ImgFileExtension)
            Else
                ImgFile = Mid(ImgFile, 1, InStr(ImgFile, "_SIZE") - 1) & "_SIZE_" & sIZE & "_R" & ImgFileExtension
            End If
        Else
            blnRepair = False
            If ImgFileName.Contains("_SIZE") = False Then
                ImgFile = ImgFile.Replace(ImgFileExtension, "_SIZE_" & sIZE & ImgFileExtension)
            Else
                ImgFile = Mid(ImgFile, 1, InStr(ImgFile, "_SIZE") - 1) & "_SIZE_" & sIZE & ImgFileExtension
            End If
        End If

        Dim index As Integer = -1
        For i As Integer = 0 To ImgFile.Length - 1
            If Char.IsDigit(ImgFile(i)) Then
                index = i
            Else
                Exit For
            End If
        Next
        Dim strDigit As String = ""
        Dim blnZeroPadding As Boolean = False
        If index >= 0 And index <= 3 Then
            strDigit = ImgFile.Substring(0, index + 1)
            strDigit = New String("0", 5 - (index + 1)) + strDigit
            ImgFile = strDigit + ImgFile.Substring(index + 1)
            blnZeroPadding = True
        End If


        If ImgFileName.Contains("_SIZE") = False OrElse blnZeroPadding OrElse True Then
            If File.Exists(fi.DirectoryName & "\" & ImgFile) = False Then
                Rename(fi.FullName, fi.DirectoryName & "\" & ImgFile)
            Else
                fsLogStreamWriter.WriteLine(fi.FullName & vbTab & "NEW FILE NAME: " & ImgFileName & " FILE RENAMING PROBLEM. FILE ALREAY EXISTS")
                fsLogStreamWriter.Flush()
            End If
            'Else
            '    fsLogStreamWriter.WriteLine(fi.DirectoryName & "\" & ImgFile & vbTab & Width & vbTab & Height & vbTab & blnRepair)
            '    fsLogStreamWriter.Flush()
        End If
    End Sub
End Class