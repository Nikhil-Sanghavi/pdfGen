Imports System.IO
Imports System.Management
Imports System.Security.Cryptography
Imports System.Text
Public Class frmImportLizFile
    Dim rsa As RSACryptoServiceProvider
    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        txtLizFilePath.Text = ""
        OpenFileDialog1.Filter = "License files (*.Liz)|*.liz"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLizFilePath.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub txtLizFilePath_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLizFilePath.TextChanged
        If txtLizFilePath.Text.Trim = "" Then
            btnImport.Enabled = False
        Else
            btnImport.Enabled = True
        End If
    End Sub
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            rsa = New RSACryptoServiceProvider()
            Dim LicenseData() As Byte
            Dim Line As String
            Dim Data() As String
            Dim pubsData() As Byte
            Dim PubsKey As String
            Dim InIContent As String
            Dim LicenseLines() As String = System.IO.File.ReadAllLines(txtLizFilePath.Text)
            If (LicenseLines.Length = 3) Then
                LicenseData = Convert.FromBase64String(LicenseLines(0))
                pubsData = Convert.FromBase64String(LicenseLines(1))
                PubsKey = Encoding.UTF8.GetString(pubsData)
                rsa.FromXmlString(PubsKey)
                If (rsa.VerifyData(LicenseData, New System.Security.Cryptography.SHA1CryptoServiceProvider(), Convert.FromBase64String(LicenseLines(2)))) Then
                    Line = Encoding.UTF8.GetString(LicenseData)
                    Data = Line.Split(Environment.NewLine)
                    InIContent = Data(0) & Data(1) & Data(2) & Data(3) & Data(4) & Environment.NewLine
                    InIContent = InIContent & Convert.ToBase64String(Encoding.UTF8.GetBytes(Data(5))) & Environment.NewLine & Convert.ToBase64String(Encoding.UTF8.GetBytes(Data(6))) & Environment.NewLine
                    If PrjTitle.ToUpper() <> Data(6).Split("|")(7).ToUpper() Then
                        MsgBox("Invalid License File For Project " & PrjTitle)
                        GrpMain.Enabled = True
                        Exit Sub
                    End If
                    If File.Exists(PrjTitle & ".INI") Then
                        System.IO.File.SetAttributes(PrjTitle & ".INI", FileAttributes.Normal)
                        File.Delete(PrjTitle & ".INI")
                    End If
                    System.IO.File.WriteAllText(PrjTitle & ".INI", InIContent)
                    System.IO.File.SetAttributes(PrjTitle & ".INI", FileAttributes.ReadOnly)
                    End
                Else
                    MsgBox("Invalid Liz Signature")
                End If
            Else
                MsgBox("Invalid Liz File")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class