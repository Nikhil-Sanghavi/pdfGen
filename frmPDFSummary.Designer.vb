<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPDFSummary
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
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRetriveDocPDFSize = New System.Windows.Forms.Button()
        Me.btnBrowsePDFFolder = New System.Windows.Forms.Button()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.lblStatus)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnRetriveDocPDFSize)
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFFolder)
        Me.GrpMain.Controls.Add(Me.txtImagePath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(133, 47)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(562, 237)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(33, 169)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(16, 13)
        Me.lblStatus.TabIndex = 23
        Me.lblStatus.Text = "..."
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(285, 94)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 48)
        Me.btnExit.TabIndex = 22
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRetriveDocPDFSize
        '
        Me.btnRetriveDocPDFSize.Enabled = False
        Me.btnRetriveDocPDFSize.Location = New System.Drawing.Point(191, 94)
        Me.btnRetriveDocPDFSize.Name = "btnRetriveDocPDFSize"
        Me.btnRetriveDocPDFSize.Size = New System.Drawing.Size(87, 48)
        Me.btnRetriveDocPDFSize.TabIndex = 21
        Me.btnRetriveDocPDFSize.Text = "Retrive Map (PDF) Size"
        Me.btnRetriveDocPDFSize.UseVisualStyleBackColor = True
        '
        'btnBrowsePDFFolder
        '
        Me.btnBrowsePDFFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsePDFFolder.Location = New System.Drawing.Point(482, 42)
        Me.btnBrowsePDFFolder.Name = "btnBrowsePDFFolder"
        Me.btnBrowsePDFFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowsePDFFolder.TabIndex = 19
        Me.btnBrowsePDFFolder.Text = "..."
        Me.btnBrowsePDFFolder.UseVisualStyleBackColor = True
        '
        'txtImagePath
        '
        Me.txtImagePath.Location = New System.Drawing.Point(157, 42)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(306, 20)
        Me.txtImagePath.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&1>Select PDF Path"
        '
        'frmPDFSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GrpMain)
        Me.Name = "frmPDFSummary"
        Me.Text = "Map (PDF) Size Summary"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtImagePath As TextBox
    Friend WithEvents btnBrowsePDFFolder As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRetriveDocPDFSize As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblStatus As Label
End Class
