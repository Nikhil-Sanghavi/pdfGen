Imports System.IO
Imports Microsoft.Office.Interop


Public Class frmMapListToExcel
    Dim _Excel As New Excel.Application
    Dim WB As Excel.Workbook = _Excel.Workbooks.Add(Type.Missing)
    Dim Ws As Excel.Worksheet = Nothing

    Dim intTotFiles As Integer = 0
    Dim strExePath As String = Application.StartupPath
    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        btnProcess.Enabled = False
        Dim mydir As DirectoryInfo = New DirectoryInfo(txtMapFolder.Text)

        Ws = WB.Sheets(1)
        Ws.Name = "SUMMARY"
        Ws.Cells(1, 1).Value = "SrNo"
        Ws.Cells(1, 2).Value = "Folder"
        Ws.Cells(1, 3).Value = "File"

        processFolder(mydir)

        lblMessage.Text = ""
        Ws.Range("A2").Select()
        _Excel.ActiveWindow.FreezePanes = True

        Ws.Cells(1, 1).EntireRow.Font.Bold = False
        Ws.Cells(1, 1).EntireRow.Font.Bold = True

        Ws.Range("C1").EntireColumn.AutoFit()
        _Excel.DisplayAlerts = False

        Dim strDate As String = Today.ToString("yyyyMMdd")
        Dim strSaveFileName As String = txtMapFolder.Text & "\MapList_" & strDate & ".xls"
        WB.SaveAs(strSaveFileName, Excel.XlFileFormat.xlAddIn)
        WB.Close(Nothing, Nothing, Nothing)

        Clipboard.SetText(strSaveFileName)

        Dim swriter As New StreamWriter(strExePath & "\MapListToExcel.dat", False)
        swriter.Write(txtMapFolder.Text)
        swriter.Close()

        If Not IsNothing(_Excel) Then
            _Excel.Workbooks.Close()
            _Excel.Application.Quit()
            _Excel.Quit()
        End If
        If Not IsNothing(WB) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(WB)
        End If
        If Not IsNothing(Ws) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Ws)
        End If
        If Not IsNothing(_Excel) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_Excel)
        End If
        WB = Nothing
        Ws = Nothing
        _Excel = Nothing

        lblMessage.Text = "Total Files Processed " & intTotFiles
        btnProcess.Enabled = True
    End Sub
    Private Sub processFolder(mydir As DirectoryInfo)
        lblMessage.ForeColor = Color.Red
        lblMessage.Text = mydir.FullName

        Dim f As FileInfo() = mydir.GetFiles()
        Dim file As FileInfo
        For Each file In f
            intTotFiles += 1
            Ws.Cells(intTotFiles + 1, 1).Value = intTotFiles
            Ws.Cells(intTotFiles + 1, 2).Value = mydir.FullName
            Ws.Cells(intTotFiles + 1, 3).Value = file.Name

        Next file

        Dim d As DirectoryInfo() = mydir.GetDirectories()
        Dim dir As DirectoryInfo
        For Each dir In d
            processFolder(dir)
        Next

    End Sub
    Private Sub btnOpenFolderDialog_Click(sender As Object, e As EventArgs) Handles btnOpenFolderDialog.Click
        If Not String.IsNullOrEmpty(txtMapFolder.Text) Then
            FolderBrowserDialog1.SelectedPath = txtMapFolder.Text
        End If
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtMapFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmMapListToExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim fileReader As String
        If My.Computer.FileSystem.FileExists(strExePath & "\MapListToExcel.dat") Then
            fileReader = My.Computer.FileSystem.ReadAllText(strExePath & "\MapListToExcel.dat")
            txtMapFolder.Text = fileReader
        End If
    End Sub
End Class