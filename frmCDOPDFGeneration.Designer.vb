<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCDOPDFGeneration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnSearchablePDF = New System.Windows.Forms.Button()
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.chkSkipNoPageToDisplay = New System.Windows.Forms.CheckBox()
        Me.chkASKForDelete = New System.Windows.Forms.CheckBox()
        Me.ChkPerPagePDF = New System.Windows.Forms.CheckBox()
        Me.cmbMB = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNoOfImagesPerBatch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkMapPDF = New System.Windows.Forms.CheckBox()
        Me.chkUseFormatII = New System.Windows.Forms.CheckBox()
        Me.chkSetPDFCompression = New System.Windows.Forms.CheckBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.chkSplitGenerateAndMergePDf = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnGeneratePDF = New System.Windows.Forms.Button()
        Me.btnBrowsePDFFolder = New System.Windows.Forms.Button()
        Me.txtExportPDFPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowseImagesFolder = New System.Windows.Forms.Button()
        Me.txtExportImagesPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnMergePDF = New System.Windows.Forms.Button()
        Me.chkSingalPDF = New System.Windows.Forms.CheckBox()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearchablePDF
        '
        Me.btnSearchablePDF.Location = New System.Drawing.Point(285, 12)
        Me.btnSearchablePDF.Name = "btnSearchablePDF"
        Me.btnSearchablePDF.Size = New System.Drawing.Size(75, 54)
        Me.btnSearchablePDF.TabIndex = 0
        Me.btnSearchablePDF.Text = "Searchable PDF"
        Me.btnSearchablePDF.UseVisualStyleBackColor = True
        Me.btnSearchablePDF.Visible = False
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.chkSingalPDF)
        Me.GrpMain.Controls.Add(Me.chkSkipNoPageToDisplay)
        Me.GrpMain.Controls.Add(Me.chkASKForDelete)
        Me.GrpMain.Controls.Add(Me.ChkPerPagePDF)
        Me.GrpMain.Controls.Add(Me.cmbMB)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.txtNoOfImagesPerBatch)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.chkMapPDF)
        Me.GrpMain.Controls.Add(Me.chkUseFormatII)
        Me.GrpMain.Controls.Add(Me.chkSetPDFCompression)
        Me.GrpMain.Controls.Add(Me.lblMsg)
        Me.GrpMain.Controls.Add(Me.chkSplitGenerateAndMergePDf)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnGeneratePDF)
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFFolder)
        Me.GrpMain.Controls.Add(Me.txtExportPDFPath)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.btnBrowseImagesFolder)
        Me.GrpMain.Controls.Add(Me.txtExportImagesPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(84, 88)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(628, 236)
        Me.GrpMain.TabIndex = 1
        Me.GrpMain.TabStop = False
        '
        'chkSkipNoPageToDisplay
        '
        Me.chkSkipNoPageToDisplay.AutoSize = True
        Me.chkSkipNoPageToDisplay.Checked = True
        Me.chkSkipNoPageToDisplay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipNoPageToDisplay.Location = New System.Drawing.Point(419, 180)
        Me.chkSkipNoPageToDisplay.Name = "chkSkipNoPageToDisplay"
        Me.chkSkipNoPageToDisplay.Size = New System.Drawing.Size(145, 17)
        Me.chkSkipNoPageToDisplay.TabIndex = 29
        Me.chkSkipNoPageToDisplay.Text = "Skip No Page To Display"
        Me.chkSkipNoPageToDisplay.UseVisualStyleBackColor = True
        '
        'chkASKForDelete
        '
        Me.chkASKForDelete.AutoSize = True
        Me.chkASKForDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkASKForDelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkASKForDelete.Location = New System.Drawing.Point(300, 180)
        Me.chkASKForDelete.Name = "chkASKForDelete"
        Me.chkASKForDelete.Size = New System.Drawing.Size(113, 17)
        Me.chkASKForDelete.TabIndex = 28
        Me.chkASKForDelete.Text = "ASK For Delete"
        Me.chkASKForDelete.UseVisualStyleBackColor = True
        Me.chkASKForDelete.Visible = False
        '
        'ChkPerPagePDF
        '
        Me.ChkPerPagePDF.AutoSize = True
        Me.ChkPerPagePDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPerPagePDF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChkPerPagePDF.Location = New System.Drawing.Point(418, 152)
        Me.ChkPerPagePDF.Name = "ChkPerPagePDF"
        Me.ChkPerPagePDF.Size = New System.Drawing.Size(111, 17)
        Me.ChkPerPagePDF.TabIndex = 27
        Me.ChkPerPagePDF.Text = "Per Image PDF"
        Me.ChkPerPagePDF.UseVisualStyleBackColor = True
        '
        'cmbMB
        '
        Me.cmbMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMB.FormattingEnabled = True
        Me.cmbMB.Location = New System.Drawing.Point(119, 152)
        Me.cmbMB.Name = "cmbMB"
        Me.cmbMB.Size = New System.Drawing.Size(65, 21)
        Me.cmbMB.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = ">MB"
        '
        'txtNoOfImagesPerBatch
        '
        Me.txtNoOfImagesPerBatch.Location = New System.Drawing.Point(119, 125)
        Me.txtNoOfImagesPerBatch.MaxLength = 3
        Me.txtNoOfImagesPerBatch.Name = "txtNoOfImagesPerBatch"
        Me.txtNoOfImagesPerBatch.Size = New System.Drawing.Size(65, 20)
        Me.txtNoOfImagesPerBatch.TabIndex = 24
        Me.txtNoOfImagesPerBatch.Text = "100"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 40)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "No Of Images Per Batch"
        '
        'chkMapPDF
        '
        Me.chkMapPDF.AutoSize = True
        Me.chkMapPDF.Checked = True
        Me.chkMapPDF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMapPDF.Location = New System.Drawing.Point(147, 94)
        Me.chkMapPDF.Name = "chkMapPDF"
        Me.chkMapPDF.Size = New System.Drawing.Size(71, 17)
        Me.chkMapPDF.TabIndex = 22
        Me.chkMapPDF.Text = "Map PDF"
        Me.chkMapPDF.UseVisualStyleBackColor = True
        '
        'chkUseFormatII
        '
        Me.chkUseFormatII.AutoSize = True
        Me.chkUseFormatII.Location = New System.Drawing.Point(418, 125)
        Me.chkUseFormatII.Name = "chkUseFormatII"
        Me.chkUseFormatII.Size = New System.Drawing.Size(67, 17)
        Me.chkUseFormatII.TabIndex = 21
        Me.chkUseFormatII.Text = "FormatII "
        Me.chkUseFormatII.UseVisualStyleBackColor = True
        '
        'chkSetPDFCompression
        '
        Me.chkSetPDFCompression.AutoSize = True
        Me.chkSetPDFCompression.Location = New System.Drawing.Point(435, 94)
        Me.chkSetPDFCompression.Name = "chkSetPDFCompression"
        Me.chkSetPDFCompression.Size = New System.Drawing.Size(128, 17)
        Me.chkSetPDFCompression.TabIndex = 20
        Me.chkSetPDFCompression.Text = "Set PDF compression"
        Me.chkSetPDFCompression.UseVisualStyleBackColor = True
        Me.chkSetPDFCompression.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(36, 199)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(10, 13)
        Me.lblMsg.TabIndex = 19
        Me.lblMsg.Text = "-"
        '
        'chkSplitGenerateAndMergePDf
        '
        Me.chkSplitGenerateAndMergePDf.AutoSize = True
        Me.chkSplitGenerateAndMergePDf.Checked = True
        Me.chkSplitGenerateAndMergePDf.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSplitGenerateAndMergePDf.Location = New System.Drawing.Point(224, 94)
        Me.chkSplitGenerateAndMergePDf.Name = "chkSplitGenerateAndMergePDf"
        Me.chkSplitGenerateAndMergePDf.Size = New System.Drawing.Size(178, 17)
        Me.chkSplitGenerateAndMergePDf.TabIndex = 18
        Me.chkSplitGenerateAndMergePDf.Text = "Split , Generate And Merge PDF"
        Me.chkSplitGenerateAndMergePDf.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(300, 117)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 48)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnGeneratePDF
        '
        Me.btnGeneratePDF.Location = New System.Drawing.Point(209, 117)
        Me.btnGeneratePDF.Name = "btnGeneratePDF"
        Me.btnGeneratePDF.Size = New System.Drawing.Size(75, 48)
        Me.btnGeneratePDF.TabIndex = 16
        Me.btnGeneratePDF.Text = "&3> Generate PDF"
        Me.btnGeneratePDF.UseVisualStyleBackColor = True
        '
        'btnBrowsePDFFolder
        '
        Me.btnBrowsePDFFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsePDFFolder.Location = New System.Drawing.Point(588, 52)
        Me.btnBrowsePDFFolder.Name = "btnBrowsePDFFolder"
        Me.btnBrowsePDFFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowsePDFFolder.TabIndex = 15
        Me.btnBrowsePDFFolder.Text = "..."
        Me.btnBrowsePDFFolder.UseVisualStyleBackColor = True
        '
        'txtExportPDFPath
        '
        Me.txtExportPDFPath.Location = New System.Drawing.Point(177, 54)
        Me.txtExportPDFPath.Name = "txtExportPDFPath"
        Me.txtExportPDFPath.Size = New System.Drawing.Size(405, 20)
        Me.txtExportPDFPath.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "&2> Select Export PDF Path"
        '
        'btnBrowseImagesFolder
        '
        Me.btnBrowseImagesFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseImagesFolder.Location = New System.Drawing.Point(588, 24)
        Me.btnBrowseImagesFolder.Name = "btnBrowseImagesFolder"
        Me.btnBrowseImagesFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowseImagesFolder.TabIndex = 12
        Me.btnBrowseImagesFolder.Text = "..."
        Me.btnBrowseImagesFolder.UseVisualStyleBackColor = True
        '
        'txtExportImagesPath
        '
        Me.txtExportImagesPath.Location = New System.Drawing.Point(177, 26)
        Me.txtExportImagesPath.Name = "txtExportImagesPath"
        Me.txtExportImagesPath.Size = New System.Drawing.Size(405, 20)
        Me.txtExportImagesPath.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "&1> Select Export Images Path"
        '
        'btnMergePDF
        '
        Me.btnMergePDF.Location = New System.Drawing.Point(366, 12)
        Me.btnMergePDF.Name = "btnMergePDF"
        Me.btnMergePDF.Size = New System.Drawing.Size(75, 54)
        Me.btnMergePDF.TabIndex = 2
        Me.btnMergePDF.Text = "Merge PDF"
        Me.btnMergePDF.UseVisualStyleBackColor = True
        Me.btnMergePDF.Visible = False
        '
        'chkSingalPDF
        '
        Me.chkSingalPDF.AutoSize = True
        Me.chkSingalPDF.Location = New System.Drawing.Point(419, 204)
        Me.chkSingalPDF.Name = "chkSingalPDF"
        Me.chkSingalPDF.Size = New System.Drawing.Size(156, 17)
        Me.chkSingalPDF.TabIndex = 30
        Me.chkSingalPDF.Text = "Singal PDF / Unlimited Size"
        Me.chkSingalPDF.UseVisualStyleBackColor = True
        '
        'frmCDOPDFGeneration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 400)
        Me.Controls.Add(Me.btnMergePDF)
        Me.Controls.Add(Me.GrpMain)
        Me.Controls.Add(Me.btnSearchablePDF)
        Me.KeyPreview = True
        Me.Name = "frmCDOPDFGeneration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CDO PDF Generation"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSearchablePDF As Button
    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents btnBrowseImagesFolder As Button
    Friend WithEvents txtExportImagesPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBrowsePDFFolder As Button
    Friend WithEvents txtExportPDFPath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents btnExit As Button
    Friend WithEvents btnGeneratePDF As Button
    Friend WithEvents btnMergePDF As Button
    Friend WithEvents chkSplitGenerateAndMergePDf As CheckBox
    Friend WithEvents lblMsg As Label
    Friend WithEvents chkSetPDFCompression As CheckBox
    Friend WithEvents chkUseFormatII As CheckBox
    Friend WithEvents chkMapPDF As CheckBox
    Friend WithEvents txtNoOfImagesPerBatch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMB As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ChkPerPagePDF As CheckBox
    Friend WithEvents chkASKForDelete As CheckBox
    Friend WithEvents chkSkipNoPageToDisplay As CheckBox
    Friend WithEvents chkSingalPDF As CheckBox
End Class
