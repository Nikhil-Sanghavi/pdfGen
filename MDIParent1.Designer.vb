<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.AdminMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RetrivePDFDocumentPaperSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangingResolutionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImageSizeSummaryFromExportedImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapPDFSizeSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapListIntoExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MergeMapImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateDataAndCreateLicDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportLizFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblEMail = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.lblPhNo1 = New System.Windows.Forms.Label()
        Me.lblAdd1 = New System.Windows.Forms.Label()
        Me.lblIntro = New System.Windows.Forms.Label()
        Me.lblLicNo = New System.Windows.Forms.Label()
        Me.lblOrgnization = New System.Windows.Forms.Label()
        Me.lblOwner = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.lblSwDescription = New System.Windows.Forms.Label()
        Me.RegenerateReplaceRepairSingalPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminMenu, Me.LicenseToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1267, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'AdminMenu
        '
        Me.AdminMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.RegenerateReplaceRepairSingalPDFToolStripMenuItem, Me.ToolStripSeparator5, Me.RetrivePDFDocumentPaperSizeToolStripMenuItem, Me.ToolStripSeparator1, Me.ChangingResolutionToolStripMenuItem, Me.ToolStripSeparator2, Me.ImageSizeSummaryFromExportedImagesToolStripMenuItem, Me.MapPDFSizeSummaryToolStripMenuItem, Me.MapListIntoExcelToolStripMenuItem, Me.ToolStripSeparator3, Me.MergeMapImagesToolStripMenuItem})
        Me.AdminMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.AdminMenu.Name = "AdminMenu"
        Me.AdminMenu.Size = New System.Drawing.Size(55, 20)
        Me.AdminMenu.Text = "&Admin"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.NewToolStripMenuItem.Text = "CDO &PDF Generation"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(222, 6)
        '
        'RetrivePDFDocumentPaperSizeToolStripMenuItem
        '
        Me.RetrivePDFDocumentPaperSizeToolStripMenuItem.Name = "RetrivePDFDocumentPaperSizeToolStripMenuItem"
        Me.RetrivePDFDocumentPaperSizeToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.RetrivePDFDocumentPaperSizeToolStripMenuItem.Text = "Set Size to PDF/JPG/TIFF"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(222, 6)
        '
        'ChangingResolutionToolStripMenuItem
        '
        Me.ChangingResolutionToolStripMenuItem.Name = "ChangingResolutionToolStripMenuItem"
        Me.ChangingResolutionToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ChangingResolutionToolStripMenuItem.Text = "Changing Resolution"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'ImageSizeSummaryFromExportedImagesToolStripMenuItem
        '
        Me.ImageSizeSummaryFromExportedImagesToolStripMenuItem.Name = "ImageSizeSummaryFromExportedImagesToolStripMenuItem"
        Me.ImageSizeSummaryFromExportedImagesToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ImageSizeSummaryFromExportedImagesToolStripMenuItem.Text = "Filewise Size Summary"
        '
        'MapPDFSizeSummaryToolStripMenuItem
        '
        Me.MapPDFSizeSummaryToolStripMenuItem.Name = "MapPDFSizeSummaryToolStripMenuItem"
        Me.MapPDFSizeSummaryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.MapPDFSizeSummaryToolStripMenuItem.Text = "Map (PDF) Size Summary"
        '
        'MapListIntoExcelToolStripMenuItem
        '
        Me.MapListIntoExcelToolStripMenuItem.Name = "MapListIntoExcelToolStripMenuItem"
        Me.MapListIntoExcelToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.MapListIntoExcelToolStripMenuItem.Text = "MapList into Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(222, 6)
        '
        'MergeMapImagesToolStripMenuItem
        '
        Me.MergeMapImagesToolStripMenuItem.Name = "MergeMapImagesToolStripMenuItem"
        Me.MergeMapImagesToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.MergeMapImagesToolStripMenuItem.Text = "Merge Map Images"
        '
        'LicenseToolStripMenuItem
        '
        Me.LicenseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateDataAndCreateLicDataToolStripMenuItem, Me.ImportLizFileToolStripMenuItem})
        Me.LicenseToolStripMenuItem.Name = "LicenseToolStripMenuItem"
        Me.LicenseToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.LicenseToolStripMenuItem.Text = "License"
        '
        'GenerateDataAndCreateLicDataToolStripMenuItem
        '
        Me.GenerateDataAndCreateLicDataToolStripMenuItem.Name = "GenerateDataAndCreateLicDataToolStripMenuItem"
        Me.GenerateDataAndCreateLicDataToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.GenerateDataAndCreateLicDataToolStripMenuItem.Text = "Generate Data And Create Lic Data"
        '
        'ImportLizFileToolStripMenuItem
        '
        Me.ImportLizFileToolStripMenuItem.Name = "ImportLizFileToolStripMenuItem"
        Me.ImportLizFileToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ImportLizFileToolStripMenuItem.Text = "Import Liz File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.lblVersion)
        Me.Panel1.Controls.Add(Me.lblEMail)
        Me.Panel1.Controls.Add(Me.lblFax)
        Me.Panel1.Controls.Add(Me.lblPhNo1)
        Me.Panel1.Controls.Add(Me.lblAdd1)
        Me.Panel1.Controls.Add(Me.lblIntro)
        Me.Panel1.Controls.Add(Me.lblLicNo)
        Me.Panel1.Controls.Add(Me.lblOrgnization)
        Me.Panel1.Controls.Add(Me.lblOwner)
        Me.Panel1.Controls.Add(Me.lblProduct)
        Me.Panel1.Controls.Add(Me.lblSwDescription)
        Me.Panel1.Location = New System.Drawing.Point(552, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 722)
        Me.Panel1.TabIndex = 13
        Me.Panel1.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(334, 34)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(141, 14)
        Me.lblVersion.TabIndex = 15
        Me.lblVersion.Text = "(Version 1.19.7.18)"
        '
        'lblEMail
        '
        Me.lblEMail.AutoSize = True
        Me.lblEMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblEMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEMail.Location = New System.Drawing.Point(10, 513)
        Me.lblEMail.Name = "lblEMail"
        Me.lblEMail.Size = New System.Drawing.Size(192, 13)
        Me.lblEMail.TabIndex = 14
        Me.lblEMail.Text = "E-mail : sanghavicomp@sify.com"
        Me.lblEMail.Visible = False
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.Location = New System.Drawing.Point(183, 493)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(131, 13)
        Me.lblFax.TabIndex = 13
        Me.lblFax.Text = "Fax : 91-2822-233003"
        Me.lblFax.Visible = False
        '
        'lblPhNo1
        '
        Me.lblPhNo1.AutoSize = True
        Me.lblPhNo1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblPhNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhNo1.Location = New System.Drawing.Point(10, 493)
        Me.lblPhNo1.Name = "lblPhNo1"
        Me.lblPhNo1.Size = New System.Drawing.Size(153, 13)
        Me.lblPhNo1.TabIndex = 12
        Me.lblPhNo1.Text = "PhNo : 91-2822-233001-2"
        Me.lblPhNo1.Visible = False
        '
        'lblAdd1
        '
        Me.lblAdd1.AutoSize = True
        Me.lblAdd1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd1.Location = New System.Drawing.Point(10, 471)
        Me.lblAdd1.Name = "lblAdd1"
        Me.lblAdd1.Size = New System.Drawing.Size(408, 13)
        Me.lblAdd1.TabIndex = 11
        Me.lblAdd1.Text = """SANGHAVI CAMPUS"", 8  Shakti Plot, Morbi - 363641 (Gujarat - India)"
        Me.lblAdd1.Visible = False
        '
        'lblIntro
        '
        Me.lblIntro.AutoSize = True
        Me.lblIntro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblIntro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntro.Location = New System.Drawing.Point(10, 449)
        Me.lblIntro.Name = "lblIntro"
        Me.lblIntro.Size = New System.Drawing.Size(211, 13)
        Me.lblIntro.TabIndex = 10
        Me.lblIntro.Text = "Sanghavi Computer Center Pvt. Ltd."
        Me.lblIntro.Visible = False
        '
        'lblLicNo
        '
        Me.lblLicNo.AutoSize = True
        Me.lblLicNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblLicNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicNo.Location = New System.Drawing.Point(10, 261)
        Me.lblLicNo.Name = "lblLicNo"
        Me.lblLicNo.Size = New System.Drawing.Size(103, 17)
        Me.lblLicNo.TabIndex = 8
        Me.lblLicNo.Text = "Not Licensed"
        '
        'lblOrgnization
        '
        Me.lblOrgnization.AutoSize = True
        Me.lblOrgnization.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrgnization.Location = New System.Drawing.Point(10, 178)
        Me.lblOrgnization.Name = "lblOrgnization"
        Me.lblOrgnization.Size = New System.Drawing.Size(103, 17)
        Me.lblOrgnization.TabIndex = 7
        Me.lblOrgnization.Text = "Not Licensed"
        Me.lblOrgnization.Visible = False
        '
        'lblOwner
        '
        Me.lblOwner.AutoSize = True
        Me.lblOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwner.Location = New System.Drawing.Point(10, 150)
        Me.lblOwner.Name = "lblOwner"
        Me.lblOwner.Size = New System.Drawing.Size(103, 17)
        Me.lblOwner.TabIndex = 6
        Me.lblOwner.Text = "Not Licensed"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(6, 122)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(212, 17)
        Me.lblProduct.TabIndex = 5
        Me.lblProduct.Text = "This Product is License For:"
        '
        'lblSwDescription
        '
        Me.lblSwDescription.AutoSize = True
        Me.lblSwDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSwDescription.Location = New System.Drawing.Point(2, 14)
        Me.lblSwDescription.Name = "lblSwDescription"
        Me.lblSwDescription.Size = New System.Drawing.Size(351, 39)
        Me.lblSwDescription.TabIndex = 1
        Me.lblSwDescription.Text = "Document Scanning "
        '
        'RegenerateReplaceRepairSingalPDFToolStripMenuItem
        '
        Me.RegenerateReplaceRepairSingalPDFToolStripMenuItem.Name = "RegenerateReplaceRepairSingalPDFToolStripMenuItem"
        Me.RegenerateReplaceRepairSingalPDFToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.RegenerateReplaceRepairSingalPDFToolStripMenuItem.Text = "Regenerate/Replace/Repair Singal PDF"
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 741)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDF Generation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LicenseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateDataAndCreateLicDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportLizFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblEMail As Label
    Friend WithEvents lblFax As Label
    Friend WithEvents lblPhNo1 As Label
    Friend WithEvents lblAdd1 As Label
    Friend WithEvents lblIntro As Label
    Friend WithEvents lblLicNo As Label
    Friend WithEvents lblOrgnization As Label
    Friend WithEvents lblOwner As Label
    Friend WithEvents lblProduct As Label
    Friend WithEvents lblSwDescription As Label
    Friend WithEvents RetrivePDFDocumentPaperSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ChangingResolutionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ImageSizeSummaryFromExportedImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MapPDFSizeSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MapListIntoExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MergeMapImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegenerateReplaceRepairSingalPDFToolStripMenuItem As ToolStripMenuItem
End Class
