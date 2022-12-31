<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMapListToExcel
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMapFolder = New System.Windows.Forms.TextBox()
        Me.btnOpenFolderDialog = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Map Folder"
        '
        'txtMapFolder
        '
        Me.txtMapFolder.Location = New System.Drawing.Point(162, 33)
        Me.txtMapFolder.Name = "txtMapFolder"
        Me.txtMapFolder.Size = New System.Drawing.Size(537, 20)
        Me.txtMapFolder.TabIndex = 1
        '
        'btnOpenFolderDialog
        '
        Me.btnOpenFolderDialog.Location = New System.Drawing.Point(720, 33)
        Me.btnOpenFolderDialog.Name = "btnOpenFolderDialog"
        Me.btnOpenFolderDialog.Size = New System.Drawing.Size(47, 23)
        Me.btnOpenFolderDialog.TabIndex = 1
        Me.btnOpenFolderDialog.Text = "..."
        Me.btnOpenFolderDialog.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(218, 114)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(135, 38)
        Me.btnProcess.TabIndex = 2
        Me.btnProcess.Text = "Map &List to Excel"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnExit.Location = New System.Drawing.Point(406, 114)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(116, 38)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(162, 196)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(108, 13)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Process Folder Name"
        '
        'frmMapListToExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnOpenFolderDialog)
        Me.Controls.Add(Me.txtMapFolder)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMapListToExcel"
        Me.Text = "Map List to Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMapFolder As TextBox
    Friend WithEvents btnOpenFolderDialog As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnProcess As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblMessage As Label
End Class
