<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMergeMap
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
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnMergeMap = New System.Windows.Forms.Button()
        Me.btnBrowsePDFFolder = New System.Windows.Forms.Button()
        Me.txtMapImagePath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowseImagesFolder = New System.Windows.Forms.Button()
        Me.txtExportImagesPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.lblMsg)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnMergeMap)
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFFolder)
        Me.GrpMain.Controls.Add(Me.txtMapImagePath)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.btnBrowseImagesFolder)
        Me.GrpMain.Controls.Add(Me.txtExportImagesPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(51, 33)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(628, 279)
        Me.GrpMain.TabIndex = 2
        Me.GrpMain.TabStop = False
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
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(300, 117)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 48)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnMergeMap
        '
        Me.btnMergeMap.Location = New System.Drawing.Point(209, 117)
        Me.btnMergeMap.Name = "btnMergeMap"
        Me.btnMergeMap.Size = New System.Drawing.Size(75, 48)
        Me.btnMergeMap.TabIndex = 16
        Me.btnMergeMap.Text = "&3> Merge Map"
        Me.btnMergeMap.UseVisualStyleBackColor = True
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
        'txtMapImagePath
        '
        Me.txtMapImagePath.Location = New System.Drawing.Point(177, 54)
        Me.txtMapImagePath.Name = "txtMapImagePath"
        Me.txtMapImagePath.Size = New System.Drawing.Size(405, 20)
        Me.txtMapImagePath.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "&2> Select Map Images Path"
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
        'frmMergeMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 372)
        Me.Controls.Add(Me.GrpMain)
        Me.Name = "frmMergeMap"
        Me.Text = "Merge Map"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents lblMsg As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnMergeMap As Button
    Friend WithEvents btnBrowsePDFFolder As Button
    Friend WithEvents txtMapImagePath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBrowseImagesFolder As Button
    Friend WithEvents txtExportImagesPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
End Class
