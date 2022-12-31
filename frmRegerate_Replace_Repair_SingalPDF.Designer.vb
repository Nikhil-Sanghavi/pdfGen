<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegerate_Replace_Repair_SingalPDF
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
        Me.GrpMain = New System.Windows.Forms.GroupBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.chkSingalPDF = New System.Windows.Forms.CheckBox()
        Me.chkSkipNoPageToDisplay = New System.Windows.Forms.CheckBox()
        Me.cmbMB = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBrowsePDFFolder = New System.Windows.Forms.Button()
        Me.txtExportPDFPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowseImagesFolder = New System.Windows.Forms.Button()
        Me.txtExportImagesPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GrpSub = New System.Windows.Forms.GroupBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnGeneratePDF = New System.Windows.Forms.Button()
        Me.txtFileNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBranch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.GrpMain.SuspendLayout()
        Me.GrpSub.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.btnConnect)
        Me.GrpMain.Controls.Add(Me.chkSingalPDF)
        Me.GrpMain.Controls.Add(Me.chkSkipNoPageToDisplay)
        Me.GrpMain.Controls.Add(Me.cmbMB)
        Me.GrpMain.Controls.Add(Me.Label4)
        Me.GrpMain.Controls.Add(Me.btnBrowsePDFFolder)
        Me.GrpMain.Controls.Add(Me.txtExportPDFPath)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.btnBrowseImagesFolder)
        Me.GrpMain.Controls.Add(Me.txtExportImagesPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(26, 25)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(731, 138)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(282, 85)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 31)
        Me.btnConnect.TabIndex = 35
        Me.btnConnect.Text = "&Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'chkSingalPDF
        '
        Me.chkSingalPDF.AutoSize = True
        Me.chkSingalPDF.Location = New System.Drawing.Point(531, 109)
        Me.chkSingalPDF.Name = "chkSingalPDF"
        Me.chkSingalPDF.Size = New System.Drawing.Size(156, 17)
        Me.chkSingalPDF.TabIndex = 32
        Me.chkSingalPDF.TabStop = False
        Me.chkSingalPDF.Text = "Singal PDF / Unlimited Size"
        Me.chkSingalPDF.UseVisualStyleBackColor = True
        '
        'chkSkipNoPageToDisplay
        '
        Me.chkSkipNoPageToDisplay.AutoSize = True
        Me.chkSkipNoPageToDisplay.Checked = True
        Me.chkSkipNoPageToDisplay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipNoPageToDisplay.Location = New System.Drawing.Point(531, 85)
        Me.chkSkipNoPageToDisplay.Name = "chkSkipNoPageToDisplay"
        Me.chkSkipNoPageToDisplay.Size = New System.Drawing.Size(145, 17)
        Me.chkSkipNoPageToDisplay.TabIndex = 31
        Me.chkSkipNoPageToDisplay.TabStop = False
        Me.chkSkipNoPageToDisplay.Text = "Skip No Page To Display"
        Me.chkSkipNoPageToDisplay.UseVisualStyleBackColor = True
        '
        'cmbMB
        '
        Me.cmbMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMB.FormattingEnabled = True
        Me.cmbMB.Location = New System.Drawing.Point(201, 77)
        Me.cmbMB.Name = "cmbMB"
        Me.cmbMB.Size = New System.Drawing.Size(65, 21)
        Me.cmbMB.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(118, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = ">MB"
        '
        'btnBrowsePDFFolder
        '
        Me.btnBrowsePDFFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsePDFFolder.Location = New System.Drawing.Point(612, 49)
        Me.btnBrowsePDFFolder.Name = "btnBrowsePDFFolder"
        Me.btnBrowsePDFFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowsePDFFolder.TabIndex = 21
        Me.btnBrowsePDFFolder.TabStop = False
        Me.btnBrowsePDFFolder.Text = "..."
        Me.btnBrowsePDFFolder.UseVisualStyleBackColor = True
        '
        'txtExportPDFPath
        '
        Me.txtExportPDFPath.Location = New System.Drawing.Point(201, 51)
        Me.txtExportPDFPath.Name = "txtExportPDFPath"
        Me.txtExportPDFPath.Size = New System.Drawing.Size(405, 20)
        Me.txtExportPDFPath.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "&2> Select Export PDF Path"
        '
        'btnBrowseImagesFolder
        '
        Me.btnBrowseImagesFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseImagesFolder.Location = New System.Drawing.Point(612, 21)
        Me.btnBrowseImagesFolder.Name = "btnBrowseImagesFolder"
        Me.btnBrowseImagesFolder.Size = New System.Drawing.Size(26, 22)
        Me.btnBrowseImagesFolder.TabIndex = 18
        Me.btnBrowseImagesFolder.TabStop = False
        Me.btnBrowseImagesFolder.Text = "..."
        Me.btnBrowseImagesFolder.UseVisualStyleBackColor = True
        '
        'txtExportImagesPath
        '
        Me.txtExportImagesPath.Location = New System.Drawing.Point(201, 23)
        Me.txtExportImagesPath.Name = "txtExportImagesPath"
        Me.txtExportImagesPath.Size = New System.Drawing.Size(405, 20)
        Me.txtExportImagesPath.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "&1> Select Export Images Path"
        '
        'GrpSub
        '
        Me.GrpSub.Controls.Add(Me.btnDisconnect)
        Me.GrpSub.Controls.Add(Me.lblMsg)
        Me.GrpSub.Controls.Add(Me.btnExit)
        Me.GrpSub.Controls.Add(Me.btnGeneratePDF)
        Me.GrpSub.Controls.Add(Me.txtFileNo)
        Me.GrpSub.Controls.Add(Me.Label5)
        Me.GrpSub.Controls.Add(Me.cmbBranch)
        Me.GrpSub.Controls.Add(Me.Label3)
        Me.GrpSub.Location = New System.Drawing.Point(26, 169)
        Me.GrpSub.Name = "GrpSub"
        Me.GrpSub.Size = New System.Drawing.Size(731, 98)
        Me.GrpSub.TabIndex = 0
        Me.GrpSub.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(6, 73)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(10, 13)
        Me.lblMsg.TabIndex = 37
        Me.lblMsg.Text = "-"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(627, 17)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 35)
        Me.btnExit.TabIndex = 5
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnGeneratePDF
        '
        Me.btnGeneratePDF.Enabled = False
        Me.btnGeneratePDF.Location = New System.Drawing.Point(538, 17)
        Me.btnGeneratePDF.Name = "btnGeneratePDF"
        Me.btnGeneratePDF.Size = New System.Drawing.Size(75, 37)
        Me.btnGeneratePDF.TabIndex = 4
        Me.btnGeneratePDF.Text = "&3> Generate PDF"
        Me.btnGeneratePDF.UseVisualStyleBackColor = True
        '
        'txtFileNo
        '
        Me.txtFileNo.Location = New System.Drawing.Point(428, 17)
        Me.txtFileNo.MaxLength = 7
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.Size = New System.Drawing.Size(100, 20)
        Me.txtFileNo.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(361, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "FileNo"
        '
        'cmbBranch
        '
        Me.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(100, 20)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(209, 21)
        Me.cmbBranch.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "&Branch"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(586, 59)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(93, 31)
        Me.btnDisconnect.TabIndex = 38
        Me.btnDisconnect.TabStop = False
        Me.btnDisconnect.Text = "&Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'frmRegerate_Replace_Repair_SingalPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 331)
        Me.Controls.Add(Me.GrpSub)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmRegerate_Replace_Repair_SingalPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regerate/Replace/Repair/Singal PDF"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.GrpSub.ResumeLayout(False)
        Me.GrpSub.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpMain As GroupBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents btnBrowsePDFFolder As Button
    Friend WithEvents txtExportPDFPath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBrowseImagesFolder As Button
    Friend WithEvents txtExportImagesPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMB As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkSingalPDF As CheckBox
    Friend WithEvents chkSkipNoPageToDisplay As CheckBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents GrpSub As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbBranch As ComboBox
    Friend WithEvents txtFileNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnGeneratePDF As Button
    Friend WithEvents lblMsg As Label
    Friend WithEvents btnDisconnect As Button
End Class
