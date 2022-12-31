<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadCDOPDF
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.lblDist = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnupload = New System.Windows.Forms.Button()
        Me.chkDownloadBatch = New System.Windows.Forms.CheckBox()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.btnSaveDM = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtTPwd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.txtLinkPage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMDBExportPath = New System.Windows.Forms.Label()
        Me.txtPDFPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMetadataXlsPath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBrowsePDFPath = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.Button1)
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFPath)
        Me.GrpMain.Controls.Add(Me.txtMetadataXlsPath)
        Me.GrpMain.Controls.Add(Me.Label5)
        Me.GrpMain.Controls.Add(Me.txtPDFPath)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.lblMDBExportPath)
        Me.GrpMain.Controls.Add(Me.lblDist)
        Me.GrpMain.Controls.Add(Me.btnStart)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnupload)
        Me.GrpMain.Controls.Add(Me.chkDownloadBatch)
        Me.GrpMain.Controls.Add(Me.chkAuto)
        Me.GrpMain.Controls.Add(Me.txtDelay)
        Me.GrpMain.Controls.Add(Me.btnSaveDM)
        Me.GrpMain.Controls.Add(Me.btnSave)
        Me.GrpMain.Controls.Add(Me.txtTPwd)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.txtTId)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.btnGo)
        Me.GrpMain.Controls.Add(Me.txtLinkPage)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(12, 4)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(1186, 165)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'lblDist
        '
        Me.lblDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDist.ForeColor = System.Drawing.Color.Red
        Me.lblDist.Location = New System.Drawing.Point(882, 51)
        Me.lblDist.Name = "lblDist"
        Me.lblDist.Size = New System.Drawing.Size(275, 43)
        Me.lblDist.TabIndex = 69
        Me.lblDist.Text = "-"
        Me.lblDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart
        '
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Location = New System.Drawing.Point(573, 45)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 68
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(755, 45)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 67
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnupload
        '
        Me.btnupload.Enabled = False
        Me.btnupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupload.Location = New System.Drawing.Point(661, 45)
        Me.btnupload.Name = "btnupload"
        Me.btnupload.Size = New System.Drawing.Size(75, 23)
        Me.btnupload.TabIndex = 66
        Me.btnupload.Text = "Upload"
        Me.btnupload.UseVisualStyleBackColor = True
        '
        'chkDownloadBatch
        '
        Me.chkDownloadBatch.Location = New System.Drawing.Point(506, 73)
        Me.chkDownloadBatch.Name = "chkDownloadBatch"
        Me.chkDownloadBatch.Size = New System.Drawing.Size(109, 21)
        Me.chkDownloadBatch.TabIndex = 65
        Me.chkDownloadBatch.Text = "Batch Mode"
        Me.chkDownloadBatch.UseVisualStyleBackColor = True
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Checked = True
        Me.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAuto.Location = New System.Drawing.Point(506, 45)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(48, 17)
        Me.chkAuto.TabIndex = 61
        Me.chkAuto.Text = "Auto"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'txtDelay
        '
        Me.txtDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelay.Location = New System.Drawing.Point(1127, 15)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(48, 20)
        Me.txtDelay.TabIndex = 60
        Me.txtDelay.Text = "100"
        '
        'btnSaveDM
        '
        Me.btnSaveDM.Enabled = False
        Me.btnSaveDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveDM.Location = New System.Drawing.Point(1033, 12)
        Me.btnSaveDM.Name = "btnSaveDM"
        Me.btnSaveDM.Size = New System.Drawing.Size(69, 23)
        Me.btnSaveDM.TabIndex = 59
        Me.btnSaveDM.Text = "Save DM"
        Me.btnSaveDM.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(980, 13)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(43, 23)
        Me.btnSave.TabIndex = 58
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'txtTPwd
        '
        Me.txtTPwd.Location = New System.Drawing.Point(849, 14)
        Me.txtTPwd.MaxLength = 100
        Me.txtTPwd.Name = "txtTPwd"
        Me.txtTPwd.Size = New System.Drawing.Size(124, 20)
        Me.txtTPwd.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(815, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Pwd"
        '
        'txtTId
        '
        Me.txtTId.Location = New System.Drawing.Point(684, 16)
        Me.txtTId.MaxLength = 100
        Me.txtTId.Name = "txtTId"
        Me.txtTId.Size = New System.Drawing.Size(124, 20)
        Me.txtTId.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(662, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Id"
        '
        'btnGo
        '
        Me.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGo.Location = New System.Drawing.Point(549, 16)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(60, 23)
        Me.btnGo.TabIndex = 11
        Me.btnGo.Text = "&Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtLinkPage
        '
        Me.txtLinkPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinkPage.Location = New System.Drawing.Point(100, 16)
        Me.txtLinkPage.Name = "txtLinkPage"
        Me.txtLinkPage.Size = New System.Drawing.Size(431, 20)
        Me.txtLinkPage.TabIndex = 10
        Me.txtLinkPage.Text = "https://edharadocs.gujarat.gov.in"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Link Page"
        '
        'lblMDBExportPath
        '
        Me.lblMDBExportPath.AutoSize = True
        Me.lblMDBExportPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMDBExportPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMDBExportPath.Location = New System.Drawing.Point(6, 66)
        Me.lblMDBExportPath.Name = "lblMDBExportPath"
        Me.lblMDBExportPath.Size = New System.Drawing.Size(11, 13)
        Me.lblMDBExportPath.TabIndex = 70
        Me.lblMDBExportPath.Text = "-"
        '
        'txtPDFPath
        '
        Me.txtPDFPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPDFPath.Location = New System.Drawing.Point(100, 100)
        Me.txtPDFPath.Name = "txtPDFPath"
        Me.txtPDFPath.Size = New System.Drawing.Size(431, 20)
        Me.txtPDFPath.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "PDF Path"
        '
        'txtMetadataXlsPath
        '
        Me.txtMetadataXlsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMetadataXlsPath.Location = New System.Drawing.Point(100, 126)
        Me.txtMetadataXlsPath.Name = "txtMetadataXlsPath"
        Me.txtMetadataXlsPath.Size = New System.Drawing.Size(431, 20)
        Me.txtMetadataXlsPath.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Metadata Xls Path"
        '
        'btnBrowsePDFPath
        '
        Me.btnBrowsePDFPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsePDFPath.Location = New System.Drawing.Point(549, 100)
        Me.btnBrowsePDFPath.Name = "btnBrowsePDFPath"
        Me.btnBrowsePDFPath.Size = New System.Drawing.Size(38, 27)
        Me.btnBrowsePDFPath.TabIndex = 75
        Me.btnBrowsePDFPath.Text = "..."
        Me.btnBrowsePDFPath.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(549, 131)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 27)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmUploadCDOPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 450)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmUploadCDOPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUploadCDOPDF"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents txtDelay As TextBox
    Friend WithEvents btnSaveDM As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtTPwd As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTId As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGo As Button
    Friend WithEvents txtLinkPage As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkAuto As CheckBox
    Friend WithEvents chkDownloadBatch As CheckBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnupload As Button
    Friend WithEvents lblDist As Label
    Friend WithEvents lblMDBExportPath As Label
    Friend WithEvents txtPDFPath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMetadataXlsPath As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnBrowsePDFPath As Button
    Friend WithEvents Button1 As Button
End Class
