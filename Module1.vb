Imports System.IO
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.ImageProcessing.Document

Module Module1
    Public DBServer As String = ""
    Public DBCatalog As String = ""
    Public intTimeout As Integer = 0
    Public MinlngFileSeries As Integer = 0
    Public MaxlngFileSeries As Integer = 0
    Public blnWindowsAuthentication As Boolean = False
    Public ExportImgPAth As String = ""
    Public ExportPDFPath As String = ""
    Public strMachineName As String = ""
    Public targetDir As String = ""
    Public strSQLConString As String = ""
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal key As Keys) As Integer
    Public STR_PDFEXPORT_MSG As String = "PDF Generated, Path: "
    Public STR_XLSEXPORT_MSG As String = "Excel Generated, Path: "
    Public STR_CLIPBOARD_COPY_MSG As String = vbNewLine & vbNewLine + "Path has been copied to Clipboard, you can use copied path to open this file."
    Public ImgExtension As String = "JPG"
    Public LastFolderNm As String = "CDOPDF" 'UID
    Public LicExpiryDt As Date
    Public defaultPDFMBFile As Integer = 22

    Public Function CalculatePaperSize(ByVal intWidth As Integer, ByVal intHeight As Integer, ByRef bigArea As Integer) As Char
        Dim MinVal As Double = Math.Min(intWidth, intHeight)
        Dim MaxVal As Double = Math.Max(intWidth, intHeight)
        'MinVal = Math.Round(MinVal, 2)
        'MaxVal = Math.Round(MaxVal, 2)
        bigArea = 0
        Dim PaperSize As Char = "0"
        If MinVal = 0 And MaxVal = 0 Then 'undefined size
            PaperSize = "*"
        ElseIf MinVal <= 856 And MaxVal <= 1169 Then 'A4 If Math.Round(MinVal, 2) <= 8.56 And Math.Round(MaxVal, 2) <= 11.69 Then 'A4
            PaperSize = "4"
        ElseIf MinVal <= 856 And MaxVal <= 1400 Then 'LEGAL 8.56
            PaperSize = "L"
        ElseIf MinVal <= 1169 And MaxVal <= 1654 Then 'A3 ElseIf Math.Round(MinVal, 2) <= 11.69 And Math.Round(MaxVal, 2) <= 16.54 Then 'A3
            PaperSize = "3"
        ElseIf MinVal <= 1654 And MaxVal <= 2340 Then 'A2 ElseIf Math.Round(MinVal, 1) <= 16.5 And Math.Round(MaxVal, 1) <= 23.4 Then 'A2
            PaperSize = "2"
        ElseIf MinVal <= 2340 And MaxVal <= 3310 Then 'A1 ElseIf Math.Round(MinVal, 1) <= 23.4 And Math.Round(MaxVal, 1) <= 33.1 Then 'A1
            PaperSize = "1"
        ElseIf MinVal <= 3310 And MaxVal <= 4680 Then 'A0 ElseIf Math.Round(MinVal, 1) <= 33.1 And Math.Round(MaxVal, 1) <= 46.8 Then 'A0
            PaperSize = "0"
        Else
            PaperSize = "M"
            bigArea += Math.Round((MinVal * MaxVal) / 1440000, 0)
        End If
        Return PaperSize
    End Function
    Public Sub ChangePixelFormat(ByRef targetDirectory As String)
        Try
            Exit Sub
            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
            Dim GryDir As DirectoryInfo = New DirectoryInfo(targetDirectory & "\GRAY")
            Dim imgEdit As New Atalasoft.Imaging.WinControls.WorkspaceViewer
            Dim blnExit As Boolean = False
            Dim tiffEn As New Atalasoft.Imaging.Codec.TiffEncoder

            If Directory.Exists(GryDir.FullName) AndAlso GryDir.GetFiles("*.JPG").Length > 0 Then
                For Each fi As FileInfo In GryDir.GetFiles("*.JPG")
                    File.Move(fi.FullName, fi.Directory.Parent.FullName & "\" & fi.Name.ToUpper.Replace(".JPG", "_GRAY.JPG"))
                    'Rename(fi.FullName, fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG"))
                Next

                If GryDir.GetFiles("*.JPG").Length = 0 Then
                    GryDir.Delete()
                End If
            End If

            For Each fi As FileInfo In di.GetFiles("*.TIF")
                If File.Exists(fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG")) Then
                    File.Delete(fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG"))
                End If
                Rename(fi.FullName, fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG"))
            Next

            For Each fiTEMP As FileInfo In di.GetFiles("*.JPG")
                imgEdit.Open(fiTEMP.FullName)
                If imgEdit.Image.ColorDepth = 24 Then Continue For
                If fiTEMP.FullName.ToUpper.Contains("_GRAY") Then
                    Continue For
                End If
                Application.DoEvents()
                If imgEdit.Image.PixelFormat <> PixelFormat.Pixel1bppIndexed Then
                    imgEdit.Image = imgEdit.Image.GetChangedPixelFormat(PixelFormat.Pixel1bppIndexed)
                    Application.DoEvents()
                    imgEdit.Save(fiTEMP.FullName, tiffEn)
                End If
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                If Not IsNothing(imgEdit.Image) Then
                    imgEdit.Image.Dispose()
                    imgEdit.Refresh()
                End If

                If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                    If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        blnExit = True
                        Exit For
                    End If
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            Throw ex
        End Try
    End Sub
    Public Sub RenameTifFiles(ByRef targetDirectory As String)
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
            For Each fi As FileInfo In di.GetFiles("*.TIF")
                If File.Exists(fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG")) Then
                    File.Delete(fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG"))
                End If
                Rename(fi.FullName, fi.DirectoryName & "\" & fi.Name.ToUpper.Replace(".TIF", ".JPG"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            Throw ex
        End Try
    End Sub

End Module

