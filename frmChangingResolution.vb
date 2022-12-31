Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Imaging.ImageProcessing
Imports System.IO
Public Class frmChangingResolution
    Dim strImgPath As String = ""
    Dim blnError As Boolean = False
    Dim blnQuit As Boolean = False
    Dim blnExit As Boolean = False
    Dim imgEdit As New Atalasoft.Imaging.WinControls.WorkspaceViewer
    Dim TotImgChanged As Integer = 0
    Dim enTiff As New Atalasoft.Imaging.Codec.TiffEncoder
    Public en As New JpegEncoder
    Private Sub frmChangingResolution_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub btnBrowseImagesFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseImagesFolder.Click
        txtExportImagesPath.Text = ""
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strPath As String = FolderBrowserDialog1.SelectedPath
            txtExportImagesPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub btnChangingResolution_Click(sender As Object, e As EventArgs) Handles btnChangingResolution.Click
        GrpMain.Enabled = False
        Dim TargetLogFileNm As String = ""

        Try
            blnError = False
            blnQuit = False
            blnExit = False

            strImgPath = txtExportImagesPath.Text

            TotImgChanged = 0
            enTiff.Compression = Atalasoft.Imaging.Codec.TiffCompression.Group4FaxEncoding

            ProcessDirectory(strImgPath)

            'fsLogStreamWriter.Close()
            'fsLogFileStream.Close()

            'If New FileInfo(TargetLogFileNm).Length = 0 Then
            '    Try
            '        File.Delete(TargetLogFileNm)
            '    Catch ex As Exception
            '    End Try
            'End If

            Dim strMsg As String = " CONVERTED PDF TOTAL : " & TotImgChanged
            MsgBox(IIf(blnExit, "QUIT FROM PROCESS " & strMsg, " OVER " & strMsg))

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
            lblMsg.Text = ""
        End Try
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

            Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*." & ImgExtension)

            If (fileEntries.Length > 0) Then
                Me.Text = "Current Directory:" & targetDirectory & "  TOTAL IMAGES: " & fileEntries.Length
                Application.DoEvents()
                Try
                    di = New DirectoryInfo(targetDirectory)
                    'If IsNumeric(di.Name) AndAlso IsNumeric(di.Parent.Name) Then
                    processFile(targetDirectory)
                    ' End If
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
        Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
        Try
            For Each fi As FileInfo In di.GetFiles("*.JPG")
                imgEdit.Open(fi.FullName)
                'If imgEdit.Image.Resolution.X <> 300 Then
                '    imgEdit.Image = ChangeResolution(300, 300, imgEdit.Image)
                '    imgEdit.Save(ImgFile, en)
                'End If
                If imgEdit.Image.Resolution.X = 300 And imgEdit.Image.Width < 3000 Then
                    imgEdit.Image.Resolution = New Dpi(200, 200, ResolutionUnit.DotsPerInch)
                End If
                imgEdit.Image = ChangeResolution(300, 300, imgEdit.Image)
                imgEdit.Save(fi.FullName, en)
                TotImgChanged += 1
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ChangeResolution(ByVal X As Integer, ByVal Y As Integer, ByVal myAtalaImage As AtalaImage) As AtalaImage
        Dim Target As New Dpi(X, Y, ResolutionUnit.DotsPerInch)

        Dim tarX As Single = CSng(Target.X) / CSng(myAtalaImage.Resolution.X)
        Dim tarY As Single = CSng(Target.Y) / CSng(myAtalaImage.Resolution.Y)

        Dim Ratio As New PointF(tarX, tarY)
        Dim newSize As New SizeF(Ratio.X * myAtalaImage.Width, Ratio.Y * myAtalaImage.Height)

        Dim resample As New ResampleCommand(newSize.ToSize())

        Dim myNewAtalaImage As AtalaImage = resample.ApplyToImage(myAtalaImage)

        myNewAtalaImage.Resolution = Target

        Return myNewAtalaImage
    End Function
End Class