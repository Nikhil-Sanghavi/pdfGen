
Imports iText.Kernel.Pdf
Imports iText.Kernel.Utils
Imports iText.Pdfocr
Imports iText.Pdfocr.Tesseract4
Imports iText.IO.Image.ImageDataFactory
Imports iText.IO.Image
Imports System.IO
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.ImageProcessing.Document
Imports Atalasoft.Imaging.Codec.Pdf

'Imports Tesseract
Imports System.Threading
Public Class frmCDOPDFGeneration
    Dim CON As SqlClient.SqlConnection
    Dim strImgPath As String = ""
    Dim strPDFPath As String = ""
    Dim tesseract4OcrEngineProperties As Tesseract4OcrEngineProperties = New Tesseract4OcrEngineProperties()

    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Dim blnError As Boolean = False

    Dim fsLogFileStream As FileStream
    Dim fsLogStreamWriter As StreamWriter
    Dim TotPDFGen As Integer = 0
    Dim testDAtaPath As String = Application.StartupPath & "\tessdata\"
    Dim TotMAxIndex As Integer = 4
    Dim imgEdit As New Atalasoft.Imaging.WinControls.WorkspaceViewer
    Dim tiffEn As New Atalasoft.Imaging.Codec.TiffEncoder
    Dim defaultMBSize As Integer = 22 '7
    Dim CatalogFileNm As String = Application.StartupPath & "\" & LastFolderNm & ".DAT"
    Dim NpoPageToDisplayFileNm As String
    Dim SrCatalog As StreamReader
    Dim SwCatalog As StreamWriter
    Dim swNoPageToDisplay As StreamWriter
    Dim FolderStructASperIndex As Boolean = False

    Delegate Sub doOcrPdfCreation(ByRef SubOutputFile As String, ByRef LIST_IMAGES_OCR1 As IList(Of FileInfo), ByRef OcrPdfCreator As OcrPdfCreator) 'dis 31/01/2021
    Private Sub btnSearchablePDF_Click(sender As Object, e As EventArgs) Handles btnSearchablePDF.Click
        Try
            'Dim testDAtaPath As String = Application.StartupPath & "\tessdata\"
            Dim inputDir As String = "D:\Digitize\SCC_SCAN\Scan_CDO_Export\COLOR_IMG\GANDHINAGAR_GANDHINAGAR\001-GENERAL\00\00\00001"
            Dim OUTPUT_PDF As String = inputDir & "\hello.pdf"
            Dim di As DirectoryInfo = New DirectoryInfo(inputDir)
            Dim TotFiles As Integer = di.GetFiles("*.JPG").Length '+ di.GetFiles("*.TIF").Length
            Dim StInd As Integer = 0

            'For Each fi In di.GetFiles("*.JPG")
            '    If Not fi.Name.Contains("_COLOR") Then
            '        ColorLevelsExtraction(fi.FullName)
            '    End If
            'Next

            Dim LIST_IMAGES_OCR As IList(Of FileInfo) = di.GetFiles("*.JPG")
            ' StInd = LIST_IMAGES_OCR.Count
            'Dim LIST_IMAGES_OCR As IList(Of FileInfo) = di.GetFiles("*.TIF")
            'Array.Resize(LIST_IMAGES_OCR, di.GetFiles("*.TIF").Length)
            ' Array.Resize(Of FileInfo)(LIST_IMAGES_OCR, TotFiles)

            'For Each fi As FileInfo In di.GetFiles("*.TIF")
            '    LIST_IMAGES_OCR(StInd) = fi
            '    StInd += 1
            'Next
            Dim tesseractReader As Tesseract4LibOcrEngine = New Tesseract4LibOcrEngine(tesseract4OcrEngineProperties)
            'Dim t As OcrPdfCreatorProperties
            tesseract4OcrEngineProperties.SetPathToTessData(New FileInfo(testDAtaPath))

            'tesseract4OcrEngineProperties.SetLanguages() 
            'Dim op As OcrPdfCreatorProperties
            'Dim PW As WriterProperties
            'op.SetPdfLang("en")
            'MsgBox(op.GetScaleMode().ToString)
            Dim pdfDoc As PdfDocument = New PdfDocument(New PdfWriter(OUTPUT_PDF))

            'Dim img As Image = iText.Kernel.Image.getInstance(img)
            'Dim Document As Document = New Document(img)
            'Dim writer As PdfWriter = PdfWriter.getInstance(Document, New FileOutputStream(dest))
            'Document.open()
            'img.setAbsolutePosition(0, 0)
            'Document.add(img)
            'Document.close()

            Dim OcrPdfCreator As OcrPdfCreator = New OcrPdfCreator(tesseractReader)
            Using writer = New PdfWriter(OUTPUT_PDF)
                OcrPdfCreator.CreatePdf(LIST_IMAGES_OCR, writer).Close()
            End Using
            MsgBox("Over")
            ' GrpMain.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmCDOPDFGeneration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '   CON = New SqlClient.SqlConnection(strSQLConString)
            txtExportImagesPath.Text = ExportImgPAth
            txtExportPDFPath.Text = ExportPDFPath

            If Directory.Exists(testDAtaPath) = False Then
                MsgBox("PDF CONVERSION REQUIRED FOLDER DOES NOT EXISTS " & testDAtaPath)
                GoTo Out
            End If
            For IND As Integer = 2 To 25
                cmbMB.Items.Add(IND)
            Next

            ReadCatalog()

            cmbMB.Text = defaultMBSize '7
            If defaultMBSize <> defaultPDFMBFile Then
                cmbMB.Text = defaultPDFMBFile
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo Out
        End Try
        Exit Sub
Out:
        GrpMain.Enabled = False
    End Sub
    Private Sub btnBrowseImagesFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseImagesFolder.Click
        txtExportImagesPath.Text = ""
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strPath As String = FolderBrowserDialog1.SelectedPath
            txtExportImagesPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub btnBrowsePDFFolder_Click(sender As Object, e As EventArgs) Handles btnBrowsePDFFolder.Click
        txtExportPDFPath.Text = ""
        If FolderBrowserDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strPath As String = FolderBrowserDialog2.SelectedPath
            txtExportPDFPath.Text = FolderBrowserDialog2.SelectedPath
        End If
    End Sub

    Private Sub txtExportImagesPath_TextChanged(sender As Object, e As EventArgs) Handles txtExportImagesPath.TextChanged
        EnableDisable()
    End Sub

    Private Sub txtExportPDFPath_TextChanged(sender As Object, e As EventArgs) Handles txtExportPDFPath.TextChanged
        EnableDisable()
    End Sub

    Private Sub EnableDisable()
        If txtExportImagesPath.Text.Trim = "" OrElse txtExportPDFPath.Text.Trim = "" Then
            btnGeneratePDF.Enabled = False
        Else
            btnGeneratePDF.Enabled = True
        End If
    End Sub

    Private Sub btnGeneratePDF_Click(sender As Object, e As EventArgs) Handles btnGeneratePDF.Click
        GrpMain.Enabled = False
        Dim TargetLogFileNm As String = ""
        Dim NoPageToDisplayFileNm As String = ""

        Try
            WriteCatalog()
            blnError = False
            blnQuit = False
            blnExit = False

            If CInt(cmbMB.Text) <> defaultMBSize Then
                If MsgBox("Mb Selection is not " & defaultMBSize & ". Do You wish to Continue", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirmation") = MsgBoxResult.No Then
                    GrpMain.Enabled = True
                    Exit Sub
                End If
            End If

            strImgPath = txtExportImagesPath.Text
            strPDFPath = txtExportPDFPath.Text '& "\COLOR_PDF"
            TargetLogFileNm = strImgPath + "\PDFConversionLog.txt"
            NoPageToDisplayFileNm = strImgPath & "\NoPageToDisplay.txt"

            fsLogFileStream = New FileStream(TargetLogFileNm, FileMode.Append, FileAccess.Write)
            fsLogStreamWriter = New StreamWriter(fsLogFileStream)
            If chkSkipNoPageToDisplay.Checked Then
                swNoPageToDisplay = New StreamWriter(NoPageToDisplayFileNm, True)
            End If
            TotPDFGen = 0
            tiffEn.Compression = Atalasoft.Imaging.Codec.TiffCompression.Group4FaxEncoding

            ProcessDirectory(strImgPath)

            fsLogStreamWriter.Close()
            fsLogFileStream.Close()

            If New FileInfo(TargetLogFileNm).Length = 0 Then
                Try
                    File.Delete(TargetLogFileNm)
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo Out
        Finally
            If Not IsNothing(fsLogStreamWriter) Then
                fsLogStreamWriter.Dispose()
            End If
            If Not IsNothing(fsLogFileStream) Then
                fsLogFileStream.Close()
            End If

            If Not IsNothing(swNoPageToDisplay) Then
                swNoPageToDisplay.Close()
                swNoPageToDisplay.Dispose()
            End If
            lblMsg.Text = ""
        End Try
        Dim strMsg As String = " CONVERTED PDF TOTAL : " & TotPDFGen
        If File.Exists(TargetLogFileNm) AndAlso New FileInfo(TargetLogFileNm).Length = 0 Then
            Try
                File.Delete(TargetLogFileNm)
            Catch ex As Exception
            End Try

            MsgBox(IIf(blnExit, "QUIT FROM PROCESS " & strMsg, " OVER " & strMsg))
        Else
            Clipboard.Clear()
            Clipboard.SetText(TargetLogFileNm)
            MsgBox(strMsg & " ERROR LOG GENERATED , PLEASE CHECK LOG" & STR_CLIPBOARD_COPY_MSG)
            GoTo Out
        End If
Out:
        GrpMain.Enabled = True
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
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

            'Dim fileEntries1 As String() = Directory.GetFiles(targetDirectory, "*." & ImgExtension)
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
                    If LastFolderNm = "CDAPDF" Then 'NIS 202211
                        DIRNM = Mid(di.Name, 1, 5)
                        If di.Name.Contains("_") = False Then
                            DIRNM = "XXX"
                        End If
                    End If
                    'If IsNumeric(DIRNM) AndAlso IsNumeric(di.Parent.Name) Then
                    If chkMapPDF.Checked Then
                            If ChkPerPagePDF.Checked Then
                                processSingalFileForExtraPage(targetDirectory)
                            Else
                                processFileAndMerge2(targetDirectory)
                            End If
                        Else
                            If chkSplitGenerateAndMergePDf.Checked Then
                                If totEntries > 101 Then
                                    processFileAndMerge(targetDirectory)
                                Else
                                    processFile(targetDirectory)
                                End If
                            Else
                                processFile(targetDirectory)
                            End If
                        End If
                    'End If
                Catch ex As Exception
                    Throw ex
                End Try
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
                    ProcessDirectory(subdirectory)
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
    Private Sub processFile(ByVal targetDirectory As String)
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
            Dim MetaDataValues() As String = di.FullName.Split("\")
            Dim tmpMaxIndex As Integer = TotMAxIndex
            Dim strWhereQry As String = ""
            Dim OUTPUT_PDF As String = strPDFPath
            Dim IndexVal As String = ""
            Dim Index1 As String = ""
            Dim Index2 As String = ""
            Dim Index3 As String = ""
            Dim Index4 As String = ""


            For indSub As Integer = 1 To TotMAxIndex
                If tmpMaxIndex = TotMAxIndex Then
                    strWhereQry = strWhereQry & " WHERE "
                Else
                    strWhereQry = strWhereQry & " AND "
                End If

                If indSub = 1 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 1)
                    Index1 = Mid(IndexVal, 1, InStrRev(IndexVal, "_") - 1)
                    Index2 = Mid(IndexVal, InStrRev(IndexVal, "_") + 1)
                    strWhereQry = strWhereQry & "INDEX1='" & Index1 & "'"
                    strWhereQry = strWhereQry & " AND INDEX2='" & Index2 & "'"
                    indSub += 1
                    tmpMaxIndex -= 1
                ElseIf indSub = 3 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 2)
                    Index3 = IndexVal

                    strWhereQry = strWhereQry & "INDEX3='" & Index3 & "'"

                ElseIf indSub = 4 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex)
                    strWhereQry = strWhereQry & "INDEX4='" & Index4 & "'"
                    Index4 = IndexVal
                End If

                tmpMaxIndex -= 1
            Next

            OUTPUT_PDF &= "\" & Index1 & "_" & Index2 & "\" & Index3 & "\" & Mid(Index4, 1, 2) & "\" & Mid(Index4, 3, 2) & "\"

            If Directory.Exists(OUTPUT_PDF) = False Then
                Directory.CreateDirectory(OUTPUT_PDF)
            End If

            OUTPUT_PDF &= Index4 & ".PDF"

            If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                GoTo Skip
            End If
            If File.Exists(OUTPUT_PDF) Then
                File.Delete(OUTPUT_PDF)
            End If

            ChangePixelFormat(targetDirectory)
            RenameTifFiles(targetDirectory)

            ' TesseractEnviornment.CustomSearchPath = Application.StartupPath & "\x86\"
            Dim fi As FileInfo() = di.GetFiles("*.JPG") '.OrderBy(Function(fn) fn.Name)
            Dim LIST_IMAGES_OCR As IList(Of FileInfo) = di.GetFiles("*.JPG").OrderBy(Function(fn) fn.Name).ToArray  '.OfType(Of FileInfo)
            'TesseractEnvironment.CustomSearchPath

            'tesseract4OcrEngineProperties.
            Dim tesseractReader As Tesseract4LibOcrEngine = New Tesseract4LibOcrEngine(tesseract4OcrEngineProperties)
            tesseract4OcrEngineProperties.SetPathToTessData(New FileInfo(testDAtaPath))
            Dim properties As OcrPdfCreatorProperties = New OcrPdfCreatorProperties
            Dim OcrPdfCreator As OcrPdfCreator = New OcrPdfCreator(tesseractReader, properties)



            Application.DoEvents()
            Application.DoEvents()
            If chkUseFormatII.Checked Then
                Me.Invoke(New doOcrPdfCreation(AddressOf OCRPDFCreation), New Object() {OUTPUT_PDF, LIST_IMAGES_OCR, OcrPdfCreator})
            Else
                Using writer = New PdfWriter(OUTPUT_PDF)
                    If chkSetPDFCompression.Checked Then
                        writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                    End If
                    OcrPdfCreator.CreatePdf(LIST_IMAGES_OCR, writer).Close()
                    Application.DoEvents()
                    Application.DoEvents()
                End Using
            End If

            If File.Exists(OUTPUT_PDF) Then
                TotPDFGen += 1
            End If
Skip:

            Application.DoEvents()
            Application.DoEvents()
            OcrPdfCreator = Nothing
            tesseractReader = Nothing

            ' LIST_IMAGES_OCR.Clear()
            'Catch ex1 As Tesseract4OcrException
            '    MsgBox(ex1.Message & vbNewLine & vbNewLine & vbNewLine & ex1.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex1.StackTrace)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            blnError = True
        Finally

        End Try
    End Sub

    Private Sub processFileAndMerge(ByVal targetDirectory As String)
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
            Dim MetaDataValues() As String = di.FullName.Split("\")
            Dim tmpMaxIndex As Integer = TotMAxIndex
            Dim strWhereQry As String = ""
            Dim OUTPUT_PDF As String = strPDFPath
            Dim IndexVal As String = ""
            Dim Index1 As String = ""
            Dim Index2 As String = ""
            Dim Index3 As String = ""
            Dim Index4 As String = ""

            For indSub As Integer = 1 To TotMAxIndex
                If tmpMaxIndex = TotMAxIndex Then
                    strWhereQry = strWhereQry & " WHERE "
                Else
                    strWhereQry = strWhereQry & " AND "
                End If

                If indSub = 1 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 1)
                    Index1 = Mid(IndexVal, 1, InStrRev(IndexVal, "_") - 1)
                    Index2 = Mid(IndexVal, InStrRev(IndexVal, "_") + 1)
                    strWhereQry = strWhereQry & "INDEX1='" & Index1 & "'"
                    strWhereQry = strWhereQry & " AND INDEX2='" & Index2 & "'"
                    indSub += 1
                    tmpMaxIndex -= 1
                ElseIf indSub = 3 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 2)
                    Index3 = IndexVal

                    strWhereQry = strWhereQry & "INDEX3='" & Index3 & "'"

                ElseIf indSub = 4 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex)
                    strWhereQry = strWhereQry & "INDEX4='" & Index4 & "'"
                    Index4 = IndexVal
                End If

                tmpMaxIndex -= 1
            Next

            OUTPUT_PDF &= "\" & Index1 & "_" & Index2 & "\" & Index3 & "\" & Mid(Index4, 1, 2) & "\" & Mid(Index4, 3, 2) & "\"

            If Directory.Exists(OUTPUT_PDF) = False Then
                Directory.CreateDirectory(OUTPUT_PDF)
            End If

            Dim SubOutPutFilePath As String = OUTPUT_PDF
            Dim SubOutputFile As String = ""

            OUTPUT_PDF &= Index4 & ".PDF"


            If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                GoTo Skip
            End If
            If File.Exists(OUTPUT_PDF) Then
                File.Delete(OUTPUT_PDF)
            End If

            If File.Exists(SubOutPutFilePath & Index4 & "_01.PDF") = False Then
                ChangePixelFormat(targetDirectory)
                RenameTifFiles(targetDirectory)
            End If

            If blnExit Then
                GoTo Skip
            End If
            ' TesseractEnviornment.CustomSearchPath = Application.StartupPath & "\x86\"
            'Dim fi As FileInfo() = di.GetFiles("*.JPG") '.OrderBy(Function(fn) fn.Name)
            Dim TotFiles As Integer = di.GetFiles("*.JPG").Length

            'Dim stIndex As Integer = 0
            Dim TakeImgLen As Integer = 100 '30 '100 '30
            If txtNoOfImagesPerBatch.Text <> "" AndAlso txtNoOfImagesPerBatch.Text > 0 Then
                TakeImgLen = txtNoOfImagesPerBatch.Text
            End If
            Dim LIST_IMAGES_OCR As IList(Of FileInfo) = di.GetFiles("*.JPG").OrderBy(Function(fn) fn.Name).ToArray  '.OfType(Of FileInfo)
            'Dim Job1 As Thread
            Dim FileId As Integer = 1
            For stIndex As Integer = 0 To TotFiles - 1
                Dim LIST_IMAGES_OCR1 As IList(Of FileInfo) = LIST_IMAGES_OCR.Skip(stIndex).Take(TakeImgLen).ToArray
                SubOutputFile = SubOutPutFilePath & Index4 & "_" & Format(FileId, "00") & ".PDF"

                lblMsg.Text = SubOutputFile
                Application.DoEvents()

                If File.Exists(SubOutputFile) AndAlso New FileInfo(SubOutputFile).Length > 0 Then
                    GoTo NXTSUB
                End If

                Dim tesseractReader As Tesseract4LibOcrEngine = New Tesseract4LibOcrEngine(tesseract4OcrEngineProperties)
                tesseract4OcrEngineProperties.SetPathToTessData(New FileInfo(testDAtaPath))
                Dim OcrPdfCreator As OcrPdfCreator = New OcrPdfCreator(tesseractReader)
                Application.DoEvents()

                'frmCDOPDFGeneration fcp = New frmCDOPDFGeneration 

                'Dim p As ParameterizedThreadStart = New ParameterizedThreadStart(AddressOf OCRPDFCreation)
                'Job1 = New Thread(New ParameterizedThreadStart(AddressOf OCRPDFCreation))
                'Dim Parameters = New Object() {SubOutputFile, LIST_IMAGES_OCR1, OcrPdfCreator}
                'Job1.Start(Parameters)
                'Job1.Join()
                Try
                    If chkUseFormatII.Checked Then
                        Me.Invoke(New doOcrPdfCreation(AddressOf OCRPDFCreation), New Object() {SubOutputFile, LIST_IMAGES_OCR1, OcrPdfCreator})
                    Else
                        Using writer = New PdfWriter(SubOutputFile)
                            If chkSetPDFCompression.Checked Then
                                'writer.IsFullCompression = True
                                writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                            End If
                            Application.DoEvents()
                            OcrPdfCreator.CreatePdf(LIST_IMAGES_OCR1, writer).Close()
                            Application.DoEvents()
                        End Using
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    OcrPdfCreator = Nothing
                    tesseractReader = Nothing
                End Try
                'LIST_IMAGES_OCR1.Clear()

NXTSUB:
                stIndex += TakeImgLen - 1
                FileId += 1
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                OcrPdfCreator = Nothing
                tesseractReader = Nothing

                If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                    If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        blnExit = True
                        Exit For
                    End If
                End If

            Next

            If blnExit Then
                GoTo Skip
            End If
            Application.DoEvents()
            MergeFile(SubOutPutFilePath, Index4, OUTPUT_PDF)
            Application.DoEvents()
            Application.DoEvents()

            If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                For Each fi In Directory.GetFiles(SubOutPutFilePath, Index4 & "_*.PDF")
                    File.Delete(fi)
                Next
            End If
            'TesseractEnvironment.CustomSearchPath

            'tesseract4OcrEngineProperties.

            lblMsg.Text = ""

            If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                TotPDFGen += 1
            End If
Skip:
            ' LIST_IMAGES_OCR.Clear()
            'Catch ex1 As Tesseract4OcrException
            '    MsgBox(ex1.Message & vbNewLine & vbNewLine & vbNewLine & ex1.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex1.StackTrace)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            blnError = True
        Finally

        End Try
    End Sub
    Private Sub OCRPDFCreation(ByRef SubOutputFile As String, ByRef LIST_IMAGES_OCR1 As IList(Of FileInfo), ByRef OcrPdfCreator As OcrPdfCreator)
        Try
            Using writer = New PdfWriter(SubOutputFile)
                If chkSetPDFCompression.Checked Then
                    'writer.IsFullCompression = True
                    writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                End If

                Application.DoEvents()
                OcrPdfCreator.CreatePdf(LIST_IMAGES_OCR1, writer).Close()
                Application.DoEvents()
            End Using

            Do While True
                If File.Exists(SubOutputFile) Then
                    If New FileInfo(SubOutputFile).Length > 0 Then
                        Exit Do
                    End If
                End If
                Threading.Thread.Sleep(1000)
            Loop

            'Catch ex1 As Tesseract4OcrException
            '    MsgBox(ex1.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("PDF CREATION " & vbNewLine & ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            Throw ex
        End Try
    End Sub
    Private Sub btnMergePDF_Click(sender As Object, e As EventArgs) Handles btnMergePDF.Click
        Try
            Dim inputFld As String = "D:\Digitize\SCC_SCAN\Scan_CDO\GANDHINAGAR\GANDHINAGAR\001-GENERAL\00012"
            strPDFPath = txtExportPDFPath.Text '& "\COLOR_PDF"
            processFileAndMerge(inputFld)
            Exit Sub

            Dim file1 As String = "D:\Digitize\CDO_EXPORT\COLOR_PDF\GANDHINAGAR_GANDHINAGAR\001-GENERAL\00\00\00008.PDF"
            Dim file2 As String = "D:\Digitize\CDO_EXPORT\COLOR_PDF\GANDHINAGAR_GANDHINAGAR\001-GENERAL\00\00\00009.PDF"
            Dim OutputFld As String = "D:\Digitize\CDO_EXPORT\COLOR_PDF\GANDHINAGAR_GANDHINAGAR\001-GENERAL\00\00"
            'MergeFile(file1, file2, OutputFld)
            MsgBox("Over")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MergeFile(ByRef Output_Folder As String, ByRef Ptrn As String, ByRef OutPutFile As String)
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(Output_Folder)
            Dim pdfDoc1 As PdfDocument = Nothing
            Dim pdfDoc2 As PdfDocument = Nothing
            Dim merger As PdfMerger = Nothing
            For Each fi In di.GetFiles(Ptrn & "_*.PDF")
                If IsNothing(pdfDoc1) Then
                    pdfDoc1 = New PdfDocument(New PdfReader(fi), New PdfWriter(OutPutFile))
                    merger = New PdfMerger(pdfDoc1)
                    Continue For
                End If
                pdfDoc2 = New PdfDocument(New PdfReader(fi))
                merger.Merge(pdfDoc2, 1, pdfDoc2.GetNumberOfPages())
                pdfDoc2.Close()
            Next

            If Not IsNothing(pdfDoc2) Then
                pdfDoc2.Close()
            End If

            If Not IsNothing(pdfDoc1) Then
                pdfDoc1.Close()
            End If

            ' Dim pdfDoc1 As PdfDocument = New PdfDocument(New PdfReader(File1), New PdfWriter(Output_Folder + "merged.pdf"))
            'Dim pdfDoc2 As PdfDocument = New PdfDocument(New PdfReader(File2))
            'Dim merger As PdfMerger = New PdfMerger(pdfDoc1)
            ''merger.Merge(pdfDoc2, 1, pdfDoc2.GetNumberOfPages())
            ''pdfDoc2.Close()
            'pdfDoc1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub processFileAndMerge2(ByVal targetDirectory As String)
        Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
        Dim MetaDataValues() As String = di.FullName.Split("\")
        Dim tmpMaxIndex As Integer = TotMAxIndex
        Dim strWhereQry As String = ""
        Dim OUTPUT_PDF As String = strPDFPath
        Dim IndexVal As String = ""
        Dim Index1 As String = ""
        Dim Index2 As String = ""
        Dim Index3 As String = ""
        Dim Index4 As String = ""
        Dim pct As New PictureBox
        Dim fs As FileStream = Nothing
        Dim pdfGen As Integer = 0
        Dim incCnt As Integer = 0
        Try
            If FolderStructASperIndex Then
                For indSub As Integer = 1 To TotMAxIndex
                    If tmpMaxIndex = TotMAxIndex Then
                        strWhereQry = strWhereQry & " WHERE "
                    Else
                        strWhereQry = strWhereQry & " AND "
                    End If

                    If indSub = 1 Then
                        IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 1)
                        Index1 = Mid(IndexVal, 1, InStrRev(IndexVal, "_") - 1)
                        Index2 = Mid(IndexVal, InStrRev(IndexVal, "_") + 1)
                        strWhereQry = strWhereQry & "INDEX1='" & Index1 & "'"
                        strWhereQry = strWhereQry & " AND INDEX2='" & Index2 & "'"
                        indSub += 1
                        tmpMaxIndex -= 1
                    ElseIf indSub = 3 Then
                        IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 2)
                        Index3 = IndexVal

                        strWhereQry = strWhereQry & "INDEX3='" & Index3 & "'"

                    ElseIf indSub = 4 Then
                        IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex)
                        strWhereQry = strWhereQry & "INDEX4='" & Index4 & "'"
                        Index4 = IndexVal
                    End If

                    tmpMaxIndex -= 1
                Next

                OUTPUT_PDF &= "\" & Index1 & "_" & Index2 & "\" & Index3 & "\" & Mid(Index4, 1, 2) & "\" & Mid(Index4, 3, 2) & "\"
            Else
                Index4 = di.Name
                OUTPUT_PDF &= di.FullName.Replace(txtExportImagesPath.Text, "") & "\"
            End If

            If Directory.Exists(OUTPUT_PDF) = False Then
                Directory.CreateDirectory(OUTPUT_PDF)
            End If

            Dim SubOutPutFilePath As String = OUTPUT_PDF
            Dim SubOutputFile As String = ""

            OUTPUT_PDF &= Index4 & ".PDF"

            If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                If chkSingalPDF.Checked Then GoTo Skip
                If New FileInfo(OUTPUT_PDF).Length > ((Int(cmbMB.Text) + 2) * 1024 * 1024) Then
                    'If chkASKForDelete.Checked Then
                    Dim filelen As Double = Math.Round(((New FileInfo(OUTPUT_PDF).Length) / 1024) / 1024, 2)
                    If MsgBox(OUTPUT_PDF & vbNewLine & "FILE SIZE IS " & filelen & " WHICH IS GREATER THAN " & Int(cmbMB.Text) & vbNewLine & "Are You Sure to delete it?", vbYesNo + MsgBoxStyle.DefaultButton2, "Confirmation") = MsgBoxResult.No Then
                        GoTo Skip
                    End If
                    'End If
                    For Each fi In Directory.GetFiles(SubOutPutFilePath, Index4 & "_*.PDF")
                        File.Delete(fi)
                    Next
                    File.Delete(OUTPUT_PDF)
                Else
                    GoTo Skip
                End If
            End If

            If File.Exists(OUTPUT_PDF) Then
                File.Delete(OUTPUT_PDF)
            End If

            If File.Exists(SubOutPutFilePath & Index4 & "_01.PDF") = False Then
                ChangePixelFormat(targetDirectory)
                RenameTifFiles(targetDirectory)
            End If

            If blnExit Then
                GoTo Skip
            End If
            'Dim TotFiles As Integer = di.GetFiles("*.JPG | *.TIF").Length
            Dim TotFiles As Integer = di.GetFiles("*.JPG").Count '+ di.GetFiles("*.TIF").Count

            Dim TakeImgLen As Integer = 100 '30
            If txtNoOfImagesPerBatch.Text <> "" AndAlso txtNoOfImagesPerBatch.Text > 0 Then
                TakeImgLen = txtNoOfImagesPerBatch.Text
            End If
            'LIST_IMAGES_OCR = di.GetFiles("*.*").
            'OrderBy(Function(fn) fn.Name).ToArray

            Dim LIST_IMAGES_OCR As IList(Of FileInfo) = Nothing
            If chkSkipNoPageToDisplay.Checked = False Then
                LIST_IMAGES_OCR = di.GetFiles("*.JPG").
                            OrderBy(Function(fn) fn.Name).ToArray
            Else
                LIST_IMAGES_OCR = di.GetFiles("*.JPG").Where(Function(fn) fn.Name.ToUpper.EndsWith("_L.JPG") = False).
                            OrderBy(Function(fn) fn.Name).ToArray

                For Each fi In di.GetFiles("*_L.JPG")
                    swNoPageToDisplay.WriteLine(fi)
                Next
            End If
            TotFiles = LIST_IMAGES_OCR.Count

            'Where(Function(fn) fn.Extension.ToLower = "jpg" Or fn.Extension.ToLower = "tif").

            'If chkSkipNoPageToDisplay.Checked Then
            '    For Each fiTemp In LIST_IMAGES_OCR
            '        If fiTemp.Name.EndsWith("_L.JPG") OrElse fiTemp.Name.EndsWith("_L.TIF") Then
            '            LIST_IMAGES_OCR.Remove(fiTemp)
            '            TotFiles -= 1
            '        End If
            '    Next
            'End If

            Dim FileId As Integer = 1
            Dim MB As Integer = cmbMB.Text * 1024 * 1024

            Dim logicOneFileAtATime As Boolean = True
            If logicOneFileAtATime Then
                Dim tesseractReader1 As Tesseract4LibOcrEngine = New Tesseract4LibOcrEngine(tesseract4OcrEngineProperties)
                tesseract4OcrEngineProperties.SetPathToTessData(New FileInfo(testDAtaPath))
                Dim properties1 As OcrPdfCreatorProperties = New OcrPdfCreatorProperties
                properties1.SetPdfLang("en")
                Dim OcrPdfCreator1 As OcrPdfCreator = New OcrPdfCreator(tesseractReader1, properties1)
                FileId = 0
                Dim stFileIndex As Integer = 0
Upnxt:
                Dim SubOutputFile1 As String = SubOutPutFilePath & Index4 & IIf(FileId = 0, "", "_" & Format(FileId, "00")) & ".PDF"

                Using writer = New PdfWriter(SubOutputFile1)
                    If chkSetPDFCompression.Checked Then
                        writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                    End If
                    Dim pDoc As New PdfDocument(writer)
                    Dim doc1 As iText.Layout.Document = New iText.Layout.Document(pDoc)
                    doc1.SetMargins(0, 0, 0, 0)
                    Dim imagesize As Long = 0
                    Dim totpgcnttobeadded As Integer = 0
                    For stIndex As Integer = stFileIndex To TotFiles - 1
                        Dim fi As FileInfo = LIST_IMAGES_OCR(stIndex)
                        Try
                            imagesize += fi.Length
                            If chkSingalPDF.Checked Then
                                stFileIndex = stIndex
                                totpgcnttobeadded += 1
                            Else
                                If imagesize > MB AndAlso stIndex <= (TotFiles - 1) AndAlso stFileIndex <> stIndex Then 'AndAlso (TotFiles - stIndex) <> 1 AndAlso totpgcnttobeadded <> 0
                                    FileId += 1
                                    stFileIndex = stIndex
                                    totpgcnttobeadded += 1
                                    Exit For
                                    'MsgBox("Size Exists at point " & imagesize & " image no:" & stIndex + 1)
                                Else
                                    stFileIndex = stIndex
                                    totpgcnttobeadded += 1
                                End If
                            End If
                            Dim fullFileName = LIST_IMAGES_OCR(stIndex).FullName
                            Dim pct1 As New PictureBox
                            Dim fs1 As FileStream = File.OpenRead(fullFileName)
                            pct1.Image = Image.FromStream(fs1, True, False)

                            Dim Width As Double = pct1.Image.Width / pct1.Image.HorizontalResolution
                            Dim Height As Double = pct1.Image.Height / pct1.Image.VerticalResolution

                            If Not IsNothing(pct1.Image) Then
                                pct1.Image.Dispose()
                            End If
                            If Not IsNothing(fs1) Then
                                fs1.Close()
                            End If

                            Application.DoEvents()
                            Dim data As ImageData = ImageDataFactory.Create(fullFileName)
                            Dim img As iText.Layout.Element.Image = New iText.Layout.Element.Image(data)
                            Dim rect As iText.Kernel.Geom.Rectangle = New iText.Kernel.Geom.Rectangle(CInt(Width * 72), CInt(Height * 72))
                            Dim pageSize As iText.Kernel.Geom.PageSize = New iText.Kernel.Geom.PageSize(rect)
                            'Find_PDF_Size = doc1.getCurrentDocumentSize()
                            pDoc.AddNewPage(pageSize)
                            doc1.Add(img)
                            doc1.Flush()

                            'Dim pfi As New FileInfo(SubOutputFile1)
                            'If pfi.Length > MB Then
                            '    MsgBox("pdf size is increasing")
                            'End If
                            If stIndex = TotFiles - 1 Then
                                stFileIndex = TotFiles
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            MsgBox("PDF CREATION " & vbNewLine & ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
                            Throw ex
                        End Try
                    Next

                    doc1.Close()

                End Using 'end NEWLOGIC
                If FileId > 0 AndAlso stFileIndex < TotFiles Then
                    GoTo Upnxt
                End If
            Else
                For stIndex As Integer = 0 To TotFiles - 1
                    Dim fi As FileInfo = LIST_IMAGES_OCR(stIndex)
                    If fi.Name.Length <= 9 Then
                        fsLogStreamWriter.WriteLine(targetDirectory & vbTab & "PLEASE CHECK SIZE FIRST")
                        GoTo Skip
                    End If
                Next
                incCnt = 0
up1:
                FileId = 1 'dis 04/05/2022
                For stIndex As Integer = 0 To TotFiles - 1
Up:
                    TakeImgLen = 100
                    If txtNoOfImagesPerBatch.Text <> "" AndAlso txtNoOfImagesPerBatch.Text > 0 Then
                        TakeImgLen = txtNoOfImagesPerBatch.Text
                    End If
                    Dim LastTakenImg As Integer = 0
                    For indsub As Integer = stIndex To stIndex + TakeImgLen
                        If indsub >= LIST_IMAGES_OCR.Count Then
                            Exit For
                        End If
                        Dim fi As FileInfo = LIST_IMAGES_OCR(indsub)
                        Dim blnMap As Boolean = False
                        If fi.Name.Contains("SIZE") Then
                            Dim SIZE As String = Mid(fi.Name, InStr(fi.Name, "SIZE_") + 5)
                            SIZE = Mid(SIZE, 1, InStr(SIZE, "_") - 1)

                            If IsNumeric(SIZE) AndAlso Val(SIZE) > 1400 Then
                                blnMap = True
                            End If
                        End If

                        If ((fi.Name.Contains("001-GENERAL") = False AndAlso fi.Name.Contains("SIZE")) OrElse fi.Length > MB OrElse blnMap) Then 'fi.Length > MB AndAlso fi.Name.Contains("SIZE")
                            If indsub <> stIndex Then
                                TakeImgLen = indsub '- 1
                                GoTo LBLpdf
                            Else
                                SubOutputFile = SubOutPutFilePath & Index4 & "_" & Format(FileId, "00") & ".PDF"

                                lblMsg.Text = SubOutputFile
                                Application.DoEvents()
                                LastTakenImg = TakeImgLen
                                If File.Exists(SubOutputFile) AndAlso New FileInfo(SubOutputFile).Length > 100 Then
                                    TakeImgLen = 1
                                    GoTo NXTSUB 'NXT
                                End If

                                TakeImgLen = 1
                                Dim LIST_IMAGES_OCR2 As IList(Of FileInfo) = LIST_IMAGES_OCR.Skip(indsub).Take(TakeImgLen).ToArray
                                MapPDFCreationUsingiText(LIST_IMAGES_OCR2, SubOutputFile)
                                GoTo NXTSUB 'Up
                            End If

                        End If
                        LastTakenImg += 1
NXT:
                    Next
LBLpdf:
                    If LastTakenImg <> 0 Then
                        If TakeImgLen <> stIndex Then
                            TakeImgLen = IIf(TakeImgLen - stIndex > 0, TakeImgLen - stIndex, stIndex - TakeImgLen)
                        End If
                        If TakeImgLen + stIndex > TotFiles Then
                            TakeImgLen = TotFiles - stIndex
                        End If
                    End If

                    SubOutputFile = SubOutPutFilePath & Index4 & "_" & Format(FileId, "00") & ".PDF"

                    lblMsg.Text = SubOutputFile
                    Application.DoEvents()

                    If File.Exists(SubOutputFile) AndAlso New FileInfo(SubOutputFile).Length > 0 Then
                        GoTo NXTSUB
                    End If

                    If File.Exists(SubOutputFile) Then
                        File.Delete(SubOutputFile)
                    End If

                    Dim LIST_IMAGES_OCR1 As IList(Of FileInfo) = LIST_IMAGES_OCR.Skip(stIndex).Take(TakeImgLen).ToArray
                    Dim tesseractReader As Tesseract4LibOcrEngine = New Tesseract4LibOcrEngine(tesseract4OcrEngineProperties)
                    tesseract4OcrEngineProperties.SetPathToTessData(New FileInfo(testDAtaPath))

                    Dim properties As OcrPdfCreatorProperties = New OcrPdfCreatorProperties

                    properties.SetPdfLang("en")
                    Dim rectangle As iText.Kernel.Geom.Rectangle = New iText.Kernel.Geom.Rectangle(612, 1008)
                    rectangle.SetX(0)
                    rectangle.SetY(0)
                    properties.SetPageSize(rectangle)
                    'properties.SetScaleMode(ScaleMode.SCALE_TO_FIT)

                    Dim OcrPdfCreator As OcrPdfCreator = New OcrPdfCreator(tesseractReader, properties)
                    'Dim OcrPdfCreator As OcrPdfCreator = New OcrPdfCreator(tesseractReader)
                    Application.DoEvents()
                    pdfGen += 1
                    Try
                        If chkUseFormatII.Checked Then
                            Me.Invoke(New doOcrPdfCreation(AddressOf OCRPDFCreation), New Object() {SubOutputFile, LIST_IMAGES_OCR1, OcrPdfCreator})
                            pdfGen += 1
                        Else
                            Using writer = New PdfWriter(SubOutputFile)
                                If chkSetPDFCompression.Checked Then
                                    writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                                End If
                                Application.DoEvents()


                                OcrPdfCreator.CreatePdf(LIST_IMAGES_OCR1, writer).
                                Close()
                                Application.DoEvents()
                                pdfGen += 1
                            End Using
                        End If
                    Catch ex As Exception
                        blnExit = True
                        Throw ex
                    Finally
                        OcrPdfCreator = Nothing
                        tesseractReader = Nothing
                    End Try
NXTSUB:
                    stIndex += TakeImgLen - 1
                    FileId += 1
                    Application.DoEvents()
                    Application.DoEvents()
                    Application.DoEvents()
                    Application.DoEvents()
                    OcrPdfCreator = Nothing
                    tesseractReader = Nothing

                    If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                        If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            blnExit = True
                            Exit For
                        End If
                    End If
                    Threading.Thread.Sleep(5000)
                    If pdfGen > 5 Then
                        GC.Collect()
                        pdfGen = 0
                    End If
                Next
                If Not blnExit Then
                    Application.DoEvents()
                    MergeFile(SubOutPutFilePath, Index4, OUTPUT_PDF)
                    Application.DoEvents()
                    Application.DoEvents()

                    If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                        For Each fi In Directory.GetFiles(SubOutPutFilePath, Index4 & "_*.PDF")
                            File.Delete(fi)
                        Next
                    End If
                    lblMsg.Text = ""

                    If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                        TotPDFGen += 1
                    End If
                End If
            End If
Skip:
        Catch ex As Exception
            If (ex.Message.Contains("Tesseract failed")) Then
                Threading.Thread.Sleep(5000)
                incCnt += 1
                GC.Collect()
                pdfGen = 0
                If incCnt <= 3 Then '3
                    GoTo up1
                Else
                    fsLogStreamWriter.WriteLine(targetDirectory & vbTab & "Tesseract failed Check Map Size")
                    GoTo OUT2
                End If
            End If
            MsgBox(ex.Message)
            blnError = True
        Finally

        End Try
OUT2:
    End Sub
    Private Sub CreateMapPDFUsingAtala(ByRef LIST_IMAGES_OCR1 As IList(Of FileInfo), ByRef OutputPDFNm As String)
        Dim col As New PdfImageCollection
        Dim fs As FileStream = Nothing
        Dim pdfEn As New PdfEncoder

        Try
            For Each fi As FileInfo In LIST_IMAGES_OCR1
                col.Add(New PdfImage(fi.FullName, -1, PdfCompressionType.Jpeg))
            Next

            If (col.Count > 0) Then
                fs = New FileStream(OutputPDFNm, FileMode.Create, FileAccess.Write)
                pdfEn.SizeMode = PdfPageSizeMode.FitToImage
                pdfEn.Save(fs, col, Nothing)
                Application.DoEvents()
            Else
                blnError = True
                GoTo Out
            End If
Out:
        Catch ex As Exception
            Throw ex
        Finally
            If (Not IsNothing(col)) Then
                col.Clear()
                col = Nothing
            End If
            If (Not IsNothing(fs)) Then
                fs.Close()
                fs = Nothing
            End If
            pdfEn = Nothing
        End Try
    End Sub
    Private Sub MapPDFCreationUsingiText(ByRef LIST_IMAGES_OCR1 As IList(Of FileInfo), ByRef SubOutputFile As String)
        Try
            Dim pct As New PictureBox
            Dim fs As FileStream = File.OpenRead(LIST_IMAGES_OCR1(0).FullName)
            pct.Image = Image.FromStream(fs, True, False)

            Dim Width As Double = pct.Image.Width / pct.Image.HorizontalResolution
            Dim Height As Double = pct.Image.Height / pct.Image.VerticalResolution

            If Not IsNothing(pct.Image) Then
                pct.Image.Dispose()
            End If
            If Not IsNothing(fs) Then
                fs.Close()
            End If

            Using writer = New PdfWriter(SubOutputFile)
                Dim pDoc As New PdfDocument(writer)

                Application.DoEvents()
                Dim data As ImageData = ImageDataFactory.Create(LIST_IMAGES_OCR1(0).FullName)
                Dim img As iText.Layout.Element.Image = New iText.Layout.Element.Image(data)
                Dim rect As iText.Kernel.Geom.Rectangle = New iText.Kernel.Geom.Rectangle(CInt(Width * 72), CInt(Height * 72))
                Dim pageSize As iText.Kernel.Geom.PageSize = New iText.Kernel.Geom.PageSize(rect)
                Dim doc1 As iText.Layout.Document = New iText.Layout.Document(pDoc, pageSize) 'iText.Kernel.Geom.PageSize.A3
                doc1.SetLeftMargin(0)
                doc1.SetRightMargin(0)
                doc1.SetTopMargin(0)
                doc1.SetBottomMargin(0)
                doc1.Add(img)
                doc1.Close()
            End Using
            fs.Close()
            Do While True
                If File.Exists(SubOutputFile) Then
                    If New FileInfo(SubOutputFile).Length > 0 Then
                        Exit Do
                    End If
                End If
                Threading.Thread.Sleep(1000)
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("PDF CREATION " & vbNewLine & ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            Throw ex
        End Try
    End Sub
    Private Sub CreateMapPDFUsingitext7(ByRef LIST_IMAGES_OCR1 As IList(Of FileInfo), ByRef SubOutputFile As String)
        Try
            Dim writer = New PdfWriter(SubOutputFile)
            Dim pDoc As New PdfDocument(writer)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtNoOfImagesPerBatch_TextChanged(sender As Object, e As EventArgs) Handles txtNoOfImagesPerBatch.TextChanged

    End Sub

    Private Sub txtNoOfImagesPerBatch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoOfImagesPerBatch.KeyPress
        process_KeyPress(e, True)
    End Sub

    Private Sub txtNoOfImagesPerBatch_Enter(sender As Object, e As EventArgs) Handles txtNoOfImagesPerBatch.Enter
        txtNoOfImagesPerBatch.SelectAll()
    End Sub

    Private Sub processSingalFileForExtraPage(ByVal targetDirectory As String)
        Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
        Dim MetaDataValues() As String = di.FullName.Split("\")
        Dim tmpMaxIndex As Integer = TotMAxIndex
        Dim strWhereQry As String = ""
        Dim OUTPUT_PDF As String = targetDirectory  'strPDFPath
        Dim IndexVal As String = ""
        Dim Index1 As String = ""
        Dim Index2 As String = ""
        Dim Index3 As String = ""
        Dim Index4 As String = ""
        Dim pct As New PictureBox
        Dim fs As FileStream = Nothing
        Dim pdfGen As Integer = 0
        Dim incCnt As Integer = 0

        Try
            For indSub As Integer = 1 To TotMAxIndex
                If tmpMaxIndex = TotMAxIndex Then
                    strWhereQry = strWhereQry & " WHERE "
                Else
                    strWhereQry = strWhereQry & " AND "
                End If

                If indSub = 1 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 1)
                    Index1 = Mid(IndexVal, 1, InStrRev(IndexVal, "_") - 1)
                    Index2 = Mid(IndexVal, InStrRev(IndexVal, "_") + 1)
                    strWhereQry = strWhereQry & "INDEX1='" & Index1 & "'"
                    strWhereQry = strWhereQry & " AND INDEX2='" & Index2 & "'"
                    indSub += 1
                    tmpMaxIndex -= 1
                ElseIf indSub = 3 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 2)
                    Index3 = IndexVal

                    strWhereQry = strWhereQry & "INDEX3='" & Index3 & "'"

                ElseIf indSub = 4 Then
                    IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex)
                    strWhereQry = strWhereQry & "INDEX4='" & Index4 & "'"
                    Index4 = IndexVal
                End If

                tmpMaxIndex -= 1
            Next
            Dim SubOutPutFilePath As String = OUTPUT_PDF
            Dim SubOutputFile As String = ""
            If di.GetFiles("*.PDF").Length = 0 Then
                ChangePixelFormat(targetDirectory)
                RenameTifFiles(targetDirectory)
            End If

            If blnExit Then
                GoTo Skip
            End If
            Dim TotFiles As Integer = di.GetFiles("*.JPG").Length

            If di.GetFiles("*.JPG").Length = di.GetFiles("*.PDF").Length Then
                GoTo Skip
            End If

            Dim TakeImgLen As Integer = 1 '100 '30
            If txtNoOfImagesPerBatch.Text <> "" AndAlso txtNoOfImagesPerBatch.Text > 0 Then
                TakeImgLen = 1 'txtNoOfImagesPerBatch.Text
            End If
            Dim LIST_IMAGES_OCR As IList(Of FileInfo) = di.GetFiles("*.JPG").OrderBy(Function(fn) fn.Name).ToArray  '.OfType(Of FileInfo)
            'Dim Job1 As Thread
            Dim FileId As Integer = 1
            Dim MB As Integer = cmbMB.Text * 1024 * 1024 '7340032 '8388608 '8MB '10485760 '10MB '1048576 1mb
            Dim blnPDFGen As Boolean = False

            For stIndex As Integer = 0 To TotFiles - 1
                Dim fi As FileInfo = LIST_IMAGES_OCR(stIndex)
                If fi.Name.Length <= 9 Then
                    fsLogStreamWriter.WriteLine(targetDirectory & vbTab & "PLEASE CHECK SIZE FIRST")
                    GoTo Skip
                End If
            Next

            incCnt = 0
up1:
            FileId = 1 'dis 04/05/2022
            For stIndex As Integer = 0 To TotFiles - 1
Up:
                TakeImgLen = 1
                If txtNoOfImagesPerBatch.Text <> "" AndAlso txtNoOfImagesPerBatch.Text > 0 Then
                    TakeImgLen = 1 'txtNoOfImagesPerBatch.Text
                End If
                'If stIndex + TakeImgLen > TotFiles Then 
                '    TakeImgLen = TotFiles - 1
                '    TakeImgLen -= stIndex
                'End If
                Dim LastTakenImg As Integer = 0
                blnPDFGen = False

                For indsub As Integer = stIndex To (stIndex + TakeImgLen - 1)
                    If indsub >= LIST_IMAGES_OCR.Count Then
                        Exit For
                    End If
                    Dim fi As FileInfo = LIST_IMAGES_OCR(indsub)

                    Dim blnMap As Boolean = False
                    If fi.Name.Contains("SIZE") Then
                        Dim SIZE As String = Mid(fi.Name, InStr(fi.Name, "SIZE_") + 5)
                        SIZE = Mid(SIZE, 1, InStr(SIZE, "_") - 1)

                        If IsNumeric(SIZE) AndAlso Val(SIZE) > 1400 Then
                            blnMap = True
                        End If
                    End If
                    'SubOutputFile = SubOutPutFilePath & Index4 & "_" & Mid(fi.Name, 1, InStr(fi.Name, ".") - 1) & ".PDF"
                    SubOutputFile = SubOutPutFilePath & "\" & Mid(fi.Name, 1, InStr(fi.Name, ".") - 1) & ".PDF"
                    If File.Exists(SubOutputFile) Then
                        GoTo NXTSUB
                    End If
                    If ((fi.Name.Contains("001-GENERAL") = False AndAlso fi.Name.Contains("SIZE")) OrElse fi.Length > MB OrElse blnMap) Then 'fi.Length > MB AndAlso fi.Name.Contains("SIZE")
                        If indsub <> stIndex Then
                            'SubOutputFile = SubOutPutFilePath & Index4 & "_" & Format(FileId, "00") & ".PDF"

                            'lblMsg.Text = SubOutputFile
                            'Application.DoEvents()

                            'If File.Exists(SubOutputFile) AndAlso New FileInfo(SubOutputFile).Length > 0 Then
                            '    GoTo NXT
                            'End If

                            'Dim LIST_IMAGES_OCR2 As IList(Of FileInfo) = LIST_IMAGES_OCR.Skip(stIndex).Take(TakeImgLen).ToArray
                            TakeImgLen = indsub '- 1
                            GoTo LBLpdf
                        Else
                            'SubOutputFile = SubOutPutFilePath & Index4 & "_" & Format(FileId, "00") & ".PDF"

                            lblMsg.Text = SubOutputFile
                            Application.DoEvents()
                            LastTakenImg = TakeImgLen
                            If File.Exists(SubOutputFile) AndAlso New FileInfo(SubOutputFile).Length > 100 Then
                                TakeImgLen = 1
                                'stIndex += TakeImgLen
                                'FileId += 1
                                'TakeImgLen = LastTakenImg
                                'LastTakenImg -= stIndex
                                GoTo NXTSUB 'NXT
                            End If

                            TakeImgLen = 1
                            Dim LIST_IMAGES_OCR2 As IList(Of FileInfo) = LIST_IMAGES_OCR.Skip(indsub).Take(TakeImgLen).ToArray
                            MapPDFCreationUsingiText(LIST_IMAGES_OCR2, SubOutputFile)

                            'stIndex += TakeImgLen
                            'FileId += 1
                            'TakeImgLen = LastTakenImg
                            'LastTakenImg -= stIndex
                            GoTo NXTSUB 'Up
                        End If
                        blnPDFGen = True
                    End If
                    LastTakenImg += 1
NXT:
                    'If stIndex = 0 And TakeImgLen = 1 Then
                    '    Exit For
                    'End If
                Next
LBLpdf:
                If LastTakenImg <> 0 Then
                    'If TakeImgLen - stIndex < 0 Then
                    '    MsgBox("")
                    'End If
                    'If TakeImgLen <> stIndex Then
                    '    TakeImgLen = IIf(TakeImgLen - stIndex > 0, TakeImgLen - stIndex, stIndex - TakeImgLen)
                    'End If
                    If TakeImgLen + stIndex > TotFiles Then
                        TakeImgLen = TotFiles - stIndex
                    End If
                End If

                ' SubOutputFile = SubOutPutFilePath & Index4 & "_" & Format(FileId, "00") & ".PDF"

                lblMsg.Text = SubOutputFile
                Application.DoEvents()

                If File.Exists(SubOutputFile) AndAlso New FileInfo(SubOutputFile).Length > 0 Then
                    GoTo NXTSUB
                End If

                If File.Exists(SubOutputFile) Then
                    File.Delete(SubOutputFile)
                End If

                Dim LIST_IMAGES_OCR1 As IList(Of FileInfo) = LIST_IMAGES_OCR.Skip(stIndex).Take(TakeImgLen).ToArray
                Dim tesseractReader As Tesseract4LibOcrEngine = New Tesseract4LibOcrEngine(tesseract4OcrEngineProperties)
                tesseract4OcrEngineProperties.SetPathToTessData(New FileInfo(testDAtaPath))
                Dim OcrPdfCreator As OcrPdfCreator = New OcrPdfCreator(tesseractReader)
                Application.DoEvents()
                pdfGen += 1

                Try
                    If chkUseFormatII.Checked Then
                        Me.Invoke(New doOcrPdfCreation(AddressOf OCRPDFCreation), New Object() {SubOutputFile, LIST_IMAGES_OCR1, OcrPdfCreator})
                        pdfGen += 1
                    Else
                        Using writer = New PdfWriter(SubOutputFile)
                            If chkSetPDFCompression.Checked Then
                                'writer.IsFullCompression = True
                                writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                            End If
                            Application.DoEvents()
                            OcrPdfCreator.CreatePdf(LIST_IMAGES_OCR1, writer).Close()
                            Application.DoEvents()
                            pdfGen += 1
                        End Using
                    End If
                Catch ex As Exception
                    blnExit = True
                    Throw ex
                Finally
                    'If Not IsNothing(OcrPdfCreator) Then
                    '    System.Runtime.InteropServices.Marshal.ReleaseComObject(OcrPdfCreator)
                    'End If
                    'If Not IsNothing(tesseractReader) Then
                    '    System.Runtime.InteropServices.Marshal.ReleaseComObject(tesseractReader)
                    'End If
                    OcrPdfCreator = Nothing
                    tesseractReader = Nothing
                End Try


NXTSUB:
                stIndex += TakeImgLen - 1
                FileId += 1
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                'If Not IsNothing(OcrPdfCreator) Then
                '    System.Runtime.InteropServices.Marshal.ReleaseComObject(OcrPdfCreator)
                'End If
                'If Not IsNothing(tesseractReader) Then
                '    System.Runtime.InteropServices.Marshal.ReleaseComObject(tesseractReader)
                'End If
                OcrPdfCreator = Nothing
                tesseractReader = Nothing

                If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                    If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        blnExit = True
                        Exit For
                    End If
                End If
                If blnPDFGen Then
                    Threading.Thread.Sleep(2000)
                End If
                If pdfGen > 5 Then
                    GC.Collect()
                    pdfGen = 0
                End If
            Next

            If blnExit Then
                GoTo Skip
            End If

            Application.DoEvents()
            ' MergeFile(SubOutPutFilePath, Index4, OUTPUT_PDF)
            Application.DoEvents()
            Application.DoEvents()

            'If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
            '    For Each fi In Directory.GetFiles(SubOutPutFilePath, Index4 & "_*.PDF")
            '        File.Delete(fi)
            '    Next
            'End If
            'TesseractEnvironment.CustomSearchPath

            'tesseract4OcrEngineProperties.

            lblMsg.Text = ""

            'If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
            '    TotPDFGen += 1
            'End If
Skip:
            ' LIST_IMAGES_OCR.Clear()
            'Catch ex1 As Tesseract4OcrException
            '    MsgBox(ex1.Message & vbNewLine & vbNewLine & vbNewLine & ex1.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex1.StackTrace)
        Catch ex As Exception
            If (ex.Message.Contains("Tesseract failed")) Then
                Threading.Thread.Sleep(5000)
                incCnt += 1
                'If pdfGen > 5 Then
                GC.Collect()
                pdfGen = 0
                'End If

                If incCnt <= 3 Then '3
                    GoTo up1
                Else
                    fsLogStreamWriter.WriteLine(targetDirectory & vbTab & "Tesseract failed Check Map Size")
                    GoTo OUT2
                End If
            End If
            'MsgBox(ex.Message & vbNewLine & vbNewLine & vbNewLine & ex.InnerException.ToString & vbNewLine & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message)
            blnError = True
        Finally

        End Try
OUT2:
    End Sub
    Private Sub frmCDOPDFGeneration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(SrCatalog) Then
            SrCatalog.Close()
            SrCatalog = Nothing
        End If
        If Not IsNothing(SwCatalog) Then
            SwCatalog.Close()
            SwCatalog = Nothing
        End If
    End Sub
    Private Sub ReadCatalog()
        Try
            Dim LINE1 As String = ""
            Dim LineIndex As String = ""
            Dim LineValue As String = ""

            If File.Exists(CatalogFileNm) Then
                Try
                    SrCatalog = New StreamReader(CatalogFileNm)
                Catch ex As Exception
                    SrCatalog = Nothing
                    File.Delete(CatalogFileNm)
                End Try
            End If
            If IsNothing(SrCatalog) = False Then
                Do While IsNothing(SrCatalog.EndOfStream) = False
                    LINE1 = SrCatalog.ReadLine()
                    If (LINE1 = Nothing AndAlso SrCatalog.EndOfStream) Then
                        Exit Do
                    End If
                    If Trim(LINE1) = "" Then
                        Continue Do
                    End If
                    LineIndex = Mid(LINE1, 4, 1)
                    LineValue = Mid(LINE1, InStr(LINE1, "=") + 1)
                    If LINE1.Contains("KEY0") Then
                        defaultPDFMBFile = LineValue
                    ElseIf LINE1.Contains("KEY1") Then
                        txtExportImagesPath.Text = LineValue
                    ElseIf LINE1.Contains("KEY2") Then
                        txtExportPDFPath.Text = LineValue
                    ElseIf LINE1.Contains("KEY3") Then
                        chkSkipNoPageToDisplay.Checked = LineValue
                    ElseIf LINE1.Contains("KEY4") Then
                        chkSingalPDF.Checked = LineValue
                    End If
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(SrCatalog) Then
                SrCatalog.Close()
                SrCatalog = Nothing
            End If
        End Try
    End Sub
    Private Sub WriteCatalog()
        Try
            SwCatalog = New StreamWriter(CatalogFileNm, False)
            SwCatalog.WriteLine("KEY0=" & cmbMB.Text)
            SwCatalog.WriteLine("KEY1=" & txtExportImagesPath.Text)
            SwCatalog.WriteLine("KEY2=" & txtExportPDFPath.Text)
            SwCatalog.WriteLine("KEY3=" & chkSkipNoPageToDisplay.Checked)
            SwCatalog.WriteLine("KEY4=" & chkSingalPDF.Checked)
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(SwCatalog) Then
                SwCatalog.Close()
                SwCatalog = Nothing
            End If
        End Try
    End Sub
End Class
