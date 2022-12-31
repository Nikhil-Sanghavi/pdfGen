Imports System.IO

Imports iText.Kernel.Pdf
Imports iText.Kernel.Utils
Imports iText.Pdfocr
Imports iText.Pdfocr.Tesseract4
Imports iText.IO.Image.ImageDataFactory
Imports iText.IO.Image
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.ImageProcessing.Document
Imports Atalasoft.Imaging.Codec.Pdf

Public Class frmRegerate_Replace_Repair_SingalPDF
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
    Dim CatalogFileNm As String = Application.StartupPath & "\Replace" & LastFolderNm & ".DAT"
    Dim NpoPageToDisplayFileNm As String
    Dim SrCatalog As StreamReader
    Dim SwCatalog As StreamWriter
    Dim swNoPageToDisplay As StreamWriter
    Dim FolderStructASperIndex As Boolean = False
    Dim srBranch As StreamReader
    Dim diBranchDir As New Dictionary(Of String, String)
    Dim diImageDir As New Dictionary(Of String, String)
    Dim TargetLogFileNm As String = ""
    Dim NoPageToDisplayFileNm As String = ""

    Private Sub frmRegerate_Replace_Repair_SingalPDF_Load(sender As Object, e As EventArgs) Handles Me.Load
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

            Dim Line As String = ""
            Dim BranchFileNm As String = Application.StartupPath & "\Branch.txt"
            If File.Exists(BranchFileNm) Then
                srBranch = New StreamReader(BranchFileNm)
                Do While IsNothing(srBranch.EndOfStream) = False
                    Line = srBranch.ReadLine
                    If (Line = Nothing AndAlso srBranch.EndOfStream AndAlso Trim(Line) = "") Then
                        Exit Do
                    End If
                    cmbBranch.Items.Add(Line)
                Loop
                srBranch.Close()
                If Not IsNothing(srBranch) Then
                    srBranch.Dispose()
                End If
            End If
            If cmbBranch.Items.Count = 0 Then
                MsgBox("Please Load Branch First")
                GoTo Out
            Else
                cmbBranch.Sorted = True
                cmbBranch.SelectedIndex = 0
            End If
            GrpSub.Enabled = False

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
                    If (LINE1 = Nothing And SrCatalog.EndOfStream) Then
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
                    ElseIf LINE1.Contains("KEY5") Then
                        cmbBranch.Text = LineValue
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
            SwCatalog.WriteLine("KEY5=" & cmbBranch.Text)
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(SwCatalog) Then
                SwCatalog.Close()
                SwCatalog = Nothing
            End If
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        btnDisconnect_Click(Nothing, Nothing)
        Me.Close()
    End Sub
    Private Sub txtExportImagesPath_TextChanged(sender As Object, e As EventArgs) Handles txtExportImagesPath.TextChanged
        enabledisablebtn()
    End Sub
    Private Sub txtExportPDFPath_TextChanged(sender As Object, e As EventArgs) Handles txtExportPDFPath.TextChanged
        enabledisablebtn()
    End Sub
    Private Sub enabledisablebtn()
        If txtExportImagesPath.Text.Trim = "" OrElse txtExportPDFPath.Text.Trim = "" Then
            btnConnect.Enabled = False
            btnDisconnect.Enabled = False
        Else
            btnConnect.Enabled = True
            btnDisconnect.Enabled = False
        End If
    End Sub
    Private Sub txtFileNo_TextChanged(sender As Object, e As EventArgs) Handles txtFileNo.TextChanged
        If txtFileNo.Text = "" Then
            btnGeneratePDF.Enabled = False
        Else
            btnGeneratePDF.Enabled = True
        End If
    End Sub
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        GrpMain.Enabled = False
        Try
            blnError = False
            blnQuit = False
            blnExit = False
            TotPDFGen = 0

            strImgPath = txtExportImagesPath.Text
            strPDFPath = txtExportPDFPath.Text '& "\COLOR_PDF"
            TargetLogFileNm = strImgPath + "\ReplacePDFConversionLog.txt"
            NoPageToDisplayFileNm = strImgPath & "\ReplaceNoPageToDisplay.txt"
            fsLogFileStream = New FileStream(TargetLogFileNm, FileMode.Append, FileAccess.Write)
            fsLogStreamWriter = New StreamWriter(fsLogFileStream)
            If chkSkipNoPageToDisplay.Checked Then
                swNoPageToDisplay = New StreamWriter(NoPageToDisplayFileNm, True)
            End If
            tiffEn.Compression = Atalasoft.Imaging.Codec.TiffCompression.Group4FaxEncoding
            GrpSub.Enabled = True
            btnDisconnect.Enabled = True
            cmbBranch.Focus()
            Exit Sub
            'ProcessDirectory(strImgPath, 1)
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo Out
        Finally
            'If Not IsNothing(fsLogStreamWriter) Then
            '    fsLogStreamWriter.Dispose()
            'End If
            'If Not IsNothing(fsLogFileStream) Then
            '    fsLogFileStream.Close()
            'End If

            'If Not IsNothing(swNoPageToDisplay) Then
            '    swNoPageToDisplay.Close()
            '    swNoPageToDisplay.Dispose()
            'End If
            'lblMsg.Text = ""
        End Try
Out:
        GrpMain.Enabled = True
    End Sub
    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        blnError = False
        blnQuit = False
        blnExit = False
        WriteCatalog()
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
        If File.Exists(TargetLogFileNm) Then
            If New FileInfo(TargetLogFileNm).Length = 0 Then
                Try
                    File.Delete(TargetLogFileNm)
                Catch ex As Exception
                End Try
            Else
                Clipboard.Clear()
                Clipboard.SetText(TargetLogFileNm)
            End If
        End If
        GrpSub.Enabled = False
        GrpMain.Enabled = True
        btnConnect.Enabled = True
    End Sub
    'Private Sub ProcessDirectory(ByVal targetDirectory As String, ByVal formatType As Integer)
    '    Try
    '        If blnExit Or blnQuit Then
    '            Exit Sub
    '        End If
    '        If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
    '            If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                blnExit = True
    '                Exit Sub
    '            End If
    '        End If
    '        Me.Text = "Current Directory:" & targetDirectory
    '        Application.DoEvents()

    '        Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)

    '        Dim totEntries As Integer = Directory.GetFiles(targetDirectory, "*.jpg").Count + Directory.GetFiles(targetDirectory, "*.tif").Count
    '        If (totEntries > 0) Then
    '            Me.Text = "Current Directory:" & targetDirectory & "  TOTAL IMAGES: " & totEntries
    '            Application.DoEvents()
    '            Try
    '                di = New DirectoryInfo(targetDirectory)
    '                Dim DIRNM As String = di.Name
    '                If LastFolderNm = "CDAPDF" Then 'NIS 202211
    '                    DIRNM = Mid(di.Name, 1, 5)
    '                    If di.Name.Contains("_") = False Then
    '                        DIRNM = "XXX"
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                Throw ex
    '            End Try
    '        End If

    '        If blnExit OrElse blnQuit OrElse blnError Then
    '            Exit Sub
    '        End If
    '        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory) '.OrderBy(Function(fn) fn)
    '        Array.Sort(subdirectoryEntries)

    '        Dim subdirectory As String
    '        For Each subdirectory In subdirectoryEntries
    '            If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
    '                If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                    blnExit = True
    '                    Exit For
    '                End If
    '            End If
    '            Try
    '                If formatType = 1 Then
    '                    Dim DocId As String = Mid(subdirectory, InStrRev(subdirectory, "\") + 1)
    '                    If IsNumeric(subdirectory) OrElse (subdirectory.Contains("_") AndAlso IsNumeric(Mid(subdirectory, 1, 5))) Then
    '                        If Directory.GetFiles(subdirectory, "*." & ImgExtension).Length > 0 Then
    '                            diBranchDir.Add(targetDirectory, targetDirectory)
    '                            Exit For
    '                        End If
    '                        ProcessDirectory(subdirectory, formatType)
    '                        Exit For
    '                    Else
    '                        ProcessDirectory(subdirectory, formatType)
    '                    End If
    '                Else
    '                    ProcessDirectory(subdirectory, formatType)
    '                End If

    '            Catch ex As Exception
    '                Throw ex
    '            End Try
    '            If blnExit OrElse blnQuit OrElse blnError Then
    '                Exit For
    '            End If
    '        Next subdirectory
    '        If blnExit Then
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Sub btnGeneratePDF_Click(sender As Object, e As EventArgs) Handles btnGeneratePDF.Click
        Try
            GrpSub.Enabled = False
            blnError = False
            Dim DocNo As String = Format(CInt(txtFileNo.Text), "00000")
            Dim ImagePath As String = strImgPath & "\" & cmbBranch.Text & "\" & DocNo
            Dim pdfPath As String = strPDFPath & "\" & cmbBranch.Text & "\" & DocNo
            Dim FinalPath As String = ""
            If Directory.Exists(ImagePath) Then
                If Directory.Exists(ImagePath) = False Then
                    MsgBox("Image Path not Found" & vbNewLine & ImagePath)
                    GoTo Out
                End If
                'If File.Exists(pdfPath) = False Then
                '    MsgBox("PDF Path not Found" & vbNewLine & pdfPath)
                '    GoTo Out
                'End If
                Dim fldPtrn As String = DocNo & ".PDF"
                If File.Exists(pdfPath & "\" & DocNo) Then
                    File.Delete(pdfPath & "\" & DocNo)
                End If

                GenerateSpecifiedPDF(ImagePath, pdfPath, DocNo)
                FinalPath = pdfPath
            Else
                Dim structFld As String = ""
                Dim fldPtrn As String = DocNo & "_?"
                If Directory.Exists(Mid(ImagePath, 1, InStrRev(ImagePath, "\"))) = False OrElse Directory.GetDirectories(Mid(ImagePath, 1, InStrRev(ImagePath, "\")), fldPtrn).Length = 0 Then
                    MsgBox("Image Path Not Found" & vbNewLine & ImagePath & structFld)
                    GoTo Out
                End If
                For Each di In Directory.GetDirectories(Mid(pdfPath, 1, InStrRev(pdfPath, "\")), fldPtrn)
                    For Each fi In Directory.GetFiles(di, DocNo & "*.PDF")
                        File.Delete(fi)
                    Next
                Next
                For ind As Integer = 1 To 9
                    structFld = "_" & ind
                    If Directory.Exists(ImagePath & structFld) = False OrElse Directory.GetFiles(ImagePath & structFld, "*.JPG").Length = 0 Then
                        Continue For
                    End If
                    'If Directory.Exists(pdfPath & structFld) = False Then
                    '    If ind = 1 Then
                    '        MsgBox("PDF Path Not Found" & vbNewLine & pdfPath & structFld)
                    '        GoTo Out
                    '    Else
                    '        Continue For
                    '    End If
                    'End If
                    GenerateSpecifiedPDF(ImagePath & structFld, pdfPath & structFld, DocNo & structFld)
                Next
            End If

            If blnError Then
                MsgBox("Over Generated With Errors" & vbNewLine & " Disconnect and Check Log File")
            Else
                MsgBox("Over Generated")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
Out:
        GrpSub.Enabled = True
        txtFileNo.Focus()
    End Sub
    Private Sub GenerateSpecifiedPDF(ByVal ImgDir As String, ByVal strPDFPAth As String, ByVal PDFNm As String)
        Dim di As DirectoryInfo = New DirectoryInfo(ImgDir)
        Dim MetaDataValues() As String = di.FullName.Split("\")
        Dim tmpMaxIndex As Integer = TotMAxIndex
        Dim strWhereQry As String = ""
        Dim OUTPUT_PDF As String = strPDFPAth & "\"
        'Dim IndexVal As String = ""
        'Dim Index1 As String = ""
        'Dim Index2 As String = ""
        'Dim Index3 As String = ""
        'Dim Index4 As String = ""
        Dim pct As New PictureBox
        Dim fs As FileStream = Nothing
        Dim pdfGen As Integer = 0
        Dim incCnt As Integer = 0

        Try
            'If FolderStructASperIndex Then
            '    For indSub As Integer = 1 To TotMAxIndex
            '        If tmpMaxIndex = TotMAxIndex Then
            '            strWhereQry = strWhereQry & " WHERE "
            '        Else
            '            strWhereQry = strWhereQry & " And "
            '        End If

            '        If indSub = 1 Then
            '            IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 1)
            '            Index1 = Mid(IndexVal, 1, InStrRev(IndexVal, "_") - 1)
            '            Index2 = Mid(IndexVal, InStrRev(IndexVal, "_") + 1)
            '            strWhereQry = strWhereQry & "INDEX1='" & Index1 & "'"
            '            strWhereQry = strWhereQry & " AND INDEX2='" & Index2 & "'"
            '            indSub += 1
            '            tmpMaxIndex -= 1
            '        ElseIf indSub = 3 Then
            '            IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex - 2)
            '            Index3 = IndexVal

            '            strWhereQry = strWhereQry & "INDEX3='" & Index3 & "'"

            '        ElseIf indSub = 4 Then
            '            IndexVal = MetaDataValues(MetaDataValues.Length - tmpMaxIndex)
            '            strWhereQry = strWhereQry & "INDEX4='" & Index4 & "'"
            '            Index4 = IndexVal
            '        End If

            '        tmpMaxIndex -= 1
            '    Next

            '    OUTPUT_PDF &= "\" & Index1 & "_" & Index2 & "\" & Index3 & "\" & Mid(Index4, 1, 2) & "\" & Mid(Index4, 3, 2) & "\"
            'Else
            '    Index4 = di.Name
            '    OUTPUT_PDF &= di.FullName.Replace(txtExportImagesPath.Text, "") & "\"
            'End If

            If Directory.Exists(OUTPUT_PDF) = False Then
                Directory.CreateDirectory(OUTPUT_PDF)
            End If

            Dim SubOutPutFilePath As String = OUTPUT_PDF
            Dim SubOutputFile As String = ""

            OUTPUT_PDF &= PDFNm & ".PDF"

            If File.Exists(OUTPUT_PDF) AndAlso New FileInfo(OUTPUT_PDF).Length > 0 Then
                'If chkSingalPDF.Checked Then GoTo Skip
                'If New FileInfo(OUTPUT_PDF).Length > ((Int(cmbMB.Text) + 2) * 1024 * 1024) Then
                '    'If chkASKForDelete.Checked Then
                '    Dim filelen As Double = Math.Round(((New FileInfo(OUTPUT_PDF).Length) / 1024) / 1024, 2)
                '    If MsgBox(OUTPUT_PDF & vbNewLine & "FILE SIZE IS " & filelen & " WHICH IS GREATER THAN " & Int(cmbMB.Text) & vbNewLine & "Are You Sure to delete it?", vbYesNo + MsgBoxStyle.DefaultButton2, "Confirmation") = MsgBoxResult.No Then
                '        GoTo Skip
                '    End If
                '    'End If
                '    For Each fi In Directory.GetFiles(SubOutPutFilePath, PDFNm & "_*.PDF")
                '        File.Delete(fi)
                '    Next
                '    File.Delete(OUTPUT_PDF)
                'Else
                '    GoTo Skip
                'End If
                For Each fi In Directory.GetFiles(SubOutPutFilePath, PDFNm & "_*.PDF")
                    File.Delete(fi)
                Next

                File.Delete(OUTPUT_PDF)
            End If

            If File.Exists(OUTPUT_PDF) Then
                File.Delete(OUTPUT_PDF)
            End If

            If File.Exists(SubOutPutFilePath & PDFNm & "_01.PDF") = False Then
                'ChangePixelFormat(targetDirectory)
                RenameTifFiles(ImgDir)
            End If

            If blnExit Then
                GoTo Skip
            End If
            'Dim TotFiles As Integer = di.GetFiles("*.JPG | *.TIF").Length
            Dim TotFiles As Integer = di.GetFiles("*.JPG").Count '+ di.GetFiles("*.TIF").Count

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
                Dim SubOutputFile1 As String = SubOutPutFilePath & PDFNm & IIf(FileId = 0, "", "_" & Format(FileId, "00")) & ".PDF"

                Using writer = New PdfWriter(SubOutputFile1)
                    'If chkSetPDFCompression.Checked Then
                    '    writer.SetCompressionLevel(0) '(0 = best speed, 9 = best compression, -1 is default  PdfStream.NO_COMPRESSION PdfStream.BEST_COMPRESSION PdfStream.DEFAULT_COMPRESSION
                    'End If
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
            End If
Skip:
        Catch ex As Exception
            If (ex.Message.Contains("Tesseract failed")) Then
                Threading.Thread.Sleep(5000)
                incCnt += 1
                GC.Collect()
                pdfGen = 0
                If incCnt <= 3 Then '3
                    'GoTo up1
                Else
                    fsLogStreamWriter.WriteLine(ImgDir & vbTab & "Tesseract failed Check Map Size")
                    GoTo OUT2
                End If
            End If
            fsLogStreamWriter.WriteLine(ImgDir)
            MsgBox(ex.Message)
            blnError = True
        End Try
OUT2:
    End Sub
    Private Sub txtFileNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFileNo.KeyPress
        process_KeyPress(e, True)
    End Sub
    Private Sub frmRegerate_Replace_Repair_SingalPDF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        btnDisconnect_Click(Nothing, Nothing)
    End Sub
    Private Sub cmbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBranch.SelectedIndexChanged

    End Sub
    Private Sub cmbBranch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBranch.KeyPress
        process_KeyPress(e, False)
    End Sub

    Private Sub txtFileNo_Enter(sender As Object, e As EventArgs) Handles txtFileNo.Enter
        txtFileNo.SelectAll()
    End Sub

    Private Sub txtExportImagesPath_Enter(sender As Object, e As EventArgs) Handles txtExportImagesPath.Enter
        txtExportImagesPath.SelectAll()
    End Sub
    Private Sub txtExportPDFPath_Enter(sender As Object, e As EventArgs) Handles txtExportPDFPath.Enter
        txtExportPDFPath.SelectAll()
    End Sub

    Private Sub txtExportImagesPath_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExportImagesPath.KeyPress
        process_KeyPress(e, False)
    End Sub

    Private Sub txtExportPDFPath_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExportPDFPath.KeyPress
        process_KeyPress(e, False)
    End Sub

    Private Sub cmbMB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMB.KeyPress
        process_KeyPress(e, False)
    End Sub


End Class