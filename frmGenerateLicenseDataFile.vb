'Imports IOEx
Imports System.Management
Imports System.Security.Cryptography
Imports System.Text
Imports System
Public Class frmGenerateLicenseDataFile
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrganization As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOrganization = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOwner = New System.Windows.Forms.TextBox
        Me.GrpMain = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.txtZipCode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Organization"
        '
        'txtOrganization
        '
        Me.txtOrganization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrganization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrganization.Location = New System.Drawing.Point(208, 16)
        Me.txtOrganization.Name = "txtOrganization"
        Me.txtOrganization.Size = New System.Drawing.Size(256, 20)
        Me.txtOrganization.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Owner(Displayed on Startup Screen)"
        '
        'txtOwner
        '
        Me.txtOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOwner.Location = New System.Drawing.Point(208, 48)
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.Size = New System.Drawing.Size(256, 20)
        Me.txtOwner.TabIndex = 3
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnGenerate)
        Me.GrpMain.Controls.Add(Me.txtZipCode)
        Me.GrpMain.Controls.Add(Me.Label6)
        Me.GrpMain.Controls.Add(Me.txtPhone)
        Me.GrpMain.Controls.Add(Me.Label5)
        Me.GrpMain.Controls.Add(Me.txtCity)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.txtCountry)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.txtOwner)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.txtOrganization)
        Me.GrpMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GrpMain.Location = New System.Drawing.Point(21, 12)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(496, 274)
        Me.GrpMain.TabIndex = 4
        Me.GrpMain.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Location = New System.Drawing.Point(240, 216)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "E&xit"
        '
        'btnGenerate
        '
        Me.btnGenerate.Enabled = False
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenerate.Location = New System.Drawing.Point(152, 216)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerate.TabIndex = 12
        Me.btnGenerate.Text = "&Generate"
        '
        'txtZipCode
        '
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZipCode.Location = New System.Drawing.Point(208, 176)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(256, 20)
        Me.txtZipCode.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Zip Code"
        '
        'txtPhone
        '
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhone.Location = New System.Drawing.Point(208, 144)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(256, 20)
        Me.txtPhone.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Phone"
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(208, 80)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(256, 20)
        Me.txtCity.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "City"
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Location = New System.Drawing.Point(208, 112)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(256, 20)
        Me.txtCountry.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Country"
        '
        'frmGenerateLicenseDataFile
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(539, 314)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmGenerateLicenseDataFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate License DataFile"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim LicDataVar As LicVar
    Dim rsa As RSACryptoServiceProvider
    Private Sub frmGenerateLicenseFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            GrpMain.Enabled = False
            ResetStructValue(LicDataVar)
            GenerateHddInfo(LicDataVar)
            If LicDataVar.HddNo = "" Then
                MsgBox("You are Not Authorized Person to Generate Lic Data")
                End
            End If
            If LicDataVar.HddRevision = "" Then
                MsgBox("You are Not Authorized Person to Generate Lic Data")
                End
            End If
            SubSetRegValue(encrypt(Trim(LicDataVar.HddNo)), encrypt(Trim(LicDataVar.HddRevision)))
            If txtOrganization.Text.Trim() <> "" Then
                LicDataVar.Orgnization = txtOrganization.Text.Trim()
            End If
            If txtOwner.Text.Trim <> "" Then
                LicDataVar.OwnerUsr = txtOwner.Text.Trim
            End If
            If txtCity.Text.Trim <> "" Then
                LicDataVar.City = txtCity.Text
            End If
            If txtCountry.Text.Trim <> "" Then
                LicDataVar.Country = txtCountry.Text.Trim
            End If
            If txtPhone.Text.Trim <> "" Then
                LicDataVar.Phone = txtPhone.Text.Trim
            End If
            If txtZipCode.Text.Trim <> "" Then
                LicDataVar.ZipCode = txtZipCode.Text.Trim
            End If
            LicDataVar.PrjTitle = PrjTitle
            rsa = New RSACryptoServiceProvider()
            'rsa.ImportCspBlob(System.IO.File.ReadAllBytes("Key.snk"))
            Dim LicenseText As String
            LicenseText = LicDataVar.HddNo & "|" & LicDataVar.HddRevision & "|" & LicDataVar.ProcessorId & "|" & LicDataVar.ProcessorLevel & "|" & LicDataVar.ProcessorRevision & "|" & LicDataVar.BaseBoardProduct & _
                       "|" & LicDataVar.Orgnization & "|" & LicDataVar.OwnerUsr & "|" & LicDataVar.City & "|" & LicDataVar.Country & "|" & LicDataVar.Phone & "|" & LicDataVar.ZipCode & "|" & LicDataVar.PrjTitle & "|"

            Dim LicenseData() As Byte = Encoding.UTF8.GetBytes(LicenseText)
            Dim Signature() As Byte = rsa.SignData(LicenseData, New System.Security.Cryptography.SHA1CryptoServiceProvider())
            Dim PubKey As String = rsa.ToXmlString(False)
            Dim PubsData() As Byte = Encoding.UTF8.GetBytes(PubKey)
            Dim LicDateAndTimeDAta As String = Convert.ToBase64String(Encoding.UTF8.GetBytes("LICENSING DATE: -" + Format(Today, "dd/MM/yyyy") + " Time: -" + Format(Now, "hh:MM:ss")))
            System.IO.File.WriteAllText("licenseData.txt", Convert.ToBase64String(LicenseData) + Environment.NewLine + Convert.ToBase64String(PubsData) + Environment.NewLine + LicDateAndTimeDAta + Environment.NewLine + Convert.ToBase64String(Signature))

            'Dim rsa1 As New RSACryptoServiceProvider
            'rsa1.FromXmlString(PubKey)
            'Dim LicenseLines() As String = System.IO.File.ReadAllLines("licenseData.txt")
            'LicenseData = Convert.FromBase64String(LicenseLines(0))
            'System.IO.File.WriteAllText("licenseData.txt", LicenseLines(0) + LicenseLines(1) + LicenseLines(2) + LicenseLines(3))
            'If Not (rsa1.VerifyData(LicenseData, New System.Security.Cryptography.SHA1CryptoServiceProvider(), Convert.FromBase64String(LicenseLines(2)))) Then
            '    MsgBox("")
            'End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(rsa) Then
                rsa = Nothing
            End If
        End Try
        GrpMain.Enabled = True
        MsgBox("Over")
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCity.Enter
        txtCity.SelectAll()
    End Sub
    Private Sub txtCountry_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCountry.Enter
        txtCountry.SelectAll()
    End Sub
    Private Sub txtOrganization_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrganization.Enter
        txtOrganization.SelectAll()
    End Sub
    Private Sub txtOwner_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOwner.Enter
        txtOwner.SelectAll()
    End Sub
    Private Sub txtPhone_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone.Enter
        txtPhone.SelectAll()
    End Sub
    Private Sub txtZipCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZipCode.Enter
        txtZipCode.SelectAll()
    End Sub
    Private Sub txtCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress
        process_KeyPress(e, False)
    End Sub
    Private Sub txtCountry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCountry.KeyPress
        process_KeyPress(e, False)
    End Sub
    Private Sub txtOrganization_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrganization.KeyPress
        process_KeyPress(e, False)
    End Sub
    Private Sub txtOwner_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOwner.KeyPress
        process_KeyPress(e, False)
    End Sub
    Private Sub txtPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone.KeyPress
        process_KeyPress(e, True)
    End Sub
    Private Sub txtZipCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZipCode.KeyPress
        process_KeyPress(e, True)
    End Sub
    Private Sub txtOrganization_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrganization.TextChanged
        If txtOrganization.Text.Trim = "" Or txtOwner.Text.Trim = "" Then
            btnGenerate.Enabled = False
        Else
            btnGenerate.Enabled = True
        End If
    End Sub
    Private Sub txtOwner_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOwner.TextChanged
        If txtOrganization.Text.Trim = "" Or txtOwner.Text.Trim = "" Then
            btnGenerate.Enabled = False
        Else
            btnGenerate.Enabled = True
        End If
    End Sub
End Class
