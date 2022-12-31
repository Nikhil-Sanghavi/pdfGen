<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageSummary
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
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnBrowsePDFImageFolder = New System.Windows.Forms.Button()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFImageFolder)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnRetriveDocPDFSize)
        Me.GrpMain.Controls.Add(Me.txtImagePath)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Location = New System.Drawing.Point(48, 36)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(678, 253)
        Me.GrpMain.TabIndex = 1
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
        Me.btnRetriveDocPDFSize.Location = New System.Drawing.Point(255, 94)
        Me.btnRetriveDocPDFSize.Name = "btnRetriveDocPDFSize"
        Me.btnRetriveDocPDFSize.Size = New System.Drawing.Size(87, 48)
        Me.btnRetriveDocPDFSize.TabIndex = 19
        Me.btnRetriveDocPDFSize.Text = "Image Doc Size Summary"
        Me.btnRetriveDocPDFSize.UseVisualStyleBackColor = True
        '
        'txtImagePath
        '
        Me.txtImagePath.Location = New System.Drawing.Point(196, 28)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(405, 20)
        Me.txtImagePath.TabIndex = 17
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
        'btnBrowsePDFImageFolder
        '
        Me.btnBrowsePDFImageFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsePDFImageFolder.Location = New System.Drawing.Point(619, 28)
        Me.btnBrowsePDFImageFolder.Name = "btnBrowsePDFImageFolder"
        Me.btnBrowsePDFImageFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowsePDFImageFolder.TabIndex = 21
        Me.btnBrowsePDFImageFolder.Text = "..."
        Me.btnBrowsePDFImageFolder.UseVisualStyleBackColor = True
        '
        'frmImageSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 343)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmImageSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Size Summary"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRetriveDocPDFSize As Button
    Friend WithEvents txtImagePath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnBrowsePDFImageFolder As Button
End Class
