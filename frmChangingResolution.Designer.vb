<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangingResolution
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
        Me.btnChangingResolution = New System.Windows.Forms.Button()
        Me.btnBrowseImagesFolder = New System.Windows.Forms.Button()
        Me.txtExportImagesPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.lblMsg)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnChangingResolution)
        Me.GrpMain.Controls.Add(Me.btnBrowseImagesFolder)
        Me.GrpMain.Controls.Add(Me.txtExportImagesPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(58, 37)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(628, 279)
        Me.GrpMain.TabIndex = 2
        Me.GrpMain.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(36, 192)
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
        'btnChangingResolution
        '
        Me.btnChangingResolution.Location = New System.Drawing.Point(209, 117)
        Me.btnChangingResolution.Name = "btnChangingResolution"
        Me.btnChangingResolution.Size = New System.Drawing.Size(75, 48)
        Me.btnChangingResolution.TabIndex = 16
        Me.btnChangingResolution.Text = "&3> Changing Resolution"
        Me.btnChangingResolution.UseVisualStyleBackColor = True
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
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "&1> Select Images Path"
        '
        'frmChangingResolution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 371)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmChangingResolution"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Changing Resolution"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents lblMsg As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnChangingResolution As Button
    Friend WithEvents btnBrowseImagesFolder As Button
    Friend WithEvents txtExportImagesPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
