<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateExcelFromPDFPaperSize
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRetriveDocPDFSize = New System.Windows.Forms.Button()
        Me.btnBrowsePDFImageFolder = New System.Windows.Forms.Button()
        Me.txtPDFImagePath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkRenameMapFolderName = New System.Windows.Forms.CheckBox()
        Me.chkRenameImagesForAdditionalImages = New System.Windows.Forms.CheckBox()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.chkRenameMapFolderName)
        Me.GrpMain.Controls.Add(Me.chkRenameImagesForAdditionalImages)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnRetriveDocPDFSize)
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFImageFolder)
        Me.GrpMain.Controls.Add(Me.txtPDFImagePath)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Location = New System.Drawing.Point(39, 23)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(678, 253)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(349, 94)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 48)
        Me.btnExit.TabIndex = 20
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRetriveDocPDFSize
        '
        Me.btnRetriveDocPDFSize.Enabled = False
        Me.btnRetriveDocPDFSize.Location = New System.Drawing.Point(245, 94)
        Me.btnRetriveDocPDFSize.Name = "btnRetriveDocPDFSize"
        Me.btnRetriveDocPDFSize.Size = New System.Drawing.Size(97, 48)
        Me.btnRetriveDocPDFSize.TabIndex = 19
        Me.btnRetriveDocPDFSize.Text = "Set Size to PDF/JPG/TIFF"
        Me.btnRetriveDocPDFSize.UseVisualStyleBackColor = True
        '
        'btnBrowsePDFImageFolder
        '
        Me.btnBrowsePDFImageFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsePDFImageFolder.Location = New System.Drawing.Point(607, 26)
        Me.btnBrowsePDFImageFolder.Name = "btnBrowsePDFImageFolder"
        Me.btnBrowsePDFImageFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowsePDFImageFolder.TabIndex = 18
        Me.btnBrowsePDFImageFolder.Text = "..."
        Me.btnBrowsePDFImageFolder.UseVisualStyleBackColor = True
        '
        'txtPDFImagePath
        '
        Me.txtPDFImagePath.Location = New System.Drawing.Point(196, 28)
        Me.txtPDFImagePath.Name = "txtPDFImagePath"
        Me.txtPDFImagePath.Size = New System.Drawing.Size(405, 20)
        Me.txtPDFImagePath.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "&1> Select  Image Path"
        '
        'chkRenameMapFolderName
        '
        Me.chkRenameMapFolderName.AutoSize = True
        Me.chkRenameMapFolderName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRenameMapFolderName.Location = New System.Drawing.Point(43, 218)
        Me.chkRenameMapFolderName.Name = "chkRenameMapFolderName"
        Me.chkRenameMapFolderName.Size = New System.Drawing.Size(350, 24)
        Me.chkRenameMapFolderName.TabIndex = 26
        Me.chkRenameMapFolderName.Text = "Rename Map Folder Name(Z_XXX->XXXXX)"
        Me.chkRenameMapFolderName.UseVisualStyleBackColor = True
        '
        'chkRenameImagesForAdditionalImages
        '
        Me.chkRenameImagesForAdditionalImages.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRenameImagesForAdditionalImages.Location = New System.Drawing.Point(43, 159)
        Me.chkRenameImagesForAdditionalImages.Name = "chkRenameImagesForAdditionalImages"
        Me.chkRenameImagesForAdditionalImages.Size = New System.Drawing.Size(317, 52)
        Me.chkRenameImagesForAdditionalImages.TabIndex = 25
        Me.chkRenameImagesForAdditionalImages.Text = "Rename Images For Additional Pages" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Check For Only Other than Maps)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.chkRenameImagesForAdditionalImages.UseVisualStyleBackColor = True
        '
        'frmGenerateExcelFromPDFPaperSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 337)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmGenerateExcelFromPDFPaperSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Size to PDF/JPG/TIFF"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents btnBrowsePDFImageFolder As Button
    Friend WithEvents txtPDFImagePath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRetriveDocPDFSize As Button
    Friend WithEvents chkRenameMapFolderName As CheckBox
    Friend WithEvents chkRenameImagesForAdditionalImages As CheckBox
End Class
