Imports System.Windows.Forms
Imports System.IO
Imports System.Text

Public Class MDIParent1

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim frm As New frmCDOPDFGeneration
        frm.ShowDialog()
    End Sub

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim ConfigFile As String
            ConfigFile = Application.ExecutablePath + ".config"
            If (Not File.Exists(ConfigFile)) Then
                Dim SourceFileName As String = ""
                Dim configDI As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
                Dim configFI As FileInfo() = configDI.GetFiles("*.config")
                Dim configFileSource As FileInfo
                For Each configFileSource In configFI
                    If (MessageBox.Show("Take This Config File " & configFileSource.Name, "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                        SourceFileName = configFileSource.FullName
                        Exit For
                    End If
                Next
                If (SourceFileName <> "") Then
                    File.Copy(SourceFileName, ConfigFile)
                    End
                End If
            End If


            strMachineName = UCase(System.Net.Dns.GetHostName)


            intTimeout = Val(System.Configuration.ConfigurationManager.AppSettings("TimeOut"))

            If Not IsNothing(System.Configuration.ConfigurationManager.AppSettings("DBServer")) Then
                DBServer = System.Configuration.ConfigurationManager.AppSettings("DBServer")
            End If

            If Not IsNothing(System.Configuration.ConfigurationManager.AppSettings("DBCatalog")) Then
                DBCatalog = System.Configuration.ConfigurationManager.AppSettings("DBCatalog")
            End If


            If Not IsNothing(System.Configuration.ConfigurationManager.AppSettings("targetDir")) Then
                targetDir = System.Configuration.ConfigurationManager.AppSettings("targetDir")
            End If

            If DBServer = "" OrElse DBCatalog = "" OrElse targetDir = "" Then 'SQL CONNECTION
                MsgBox("PLEASE SET CONFIG FOR SQL CONNECTION")
                End
            End If

            If Not IsNothing(System.Configuration.ConfigurationManager.AppSettings("WindowsAuth")) Then
                blnWindowsAuthentication = System.Configuration.ConfigurationManager.AppSettings("WindowsAuth")
            End If

            If blnWindowsAuthentication Then
                strSQLConString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" & DBCatalog & ";Data Source=" & DBServer & ";timeout=1000"
            Else
                strSQLConString = "USER ID=sa;password=sa123;Initial Catalog=" & DBCatalog & ";Data Source=" & DBServer & ";timeout=1000" 'Persist Security Info=False;Integrated Security=False;packet size=4096;
            End If

            ExportImgPAth = System.Configuration.ConfigurationManager.AppSettings("ExportImgPath")
            ExportPDFPath = System.Configuration.ConfigurationManager.AppSettings("ExportPDFPath")

            MinlngFileSeries = System.Configuration.ConfigurationManager.AppSettings("MinFileSeries")
            MaxlngFileSeries = System.Configuration.ConfigurationManager.AppSettings("MaxFileSeries")

            If (MinlngFileSeries > MaxlngFileSeries) Then
                MessageBox.Show("PLEASE CHECK MIN RANGE MUST BE LESS THEN MAX RANGE")
                End
            End If

            If checkDefaultLocale() = False Then
                End
            End If

            If File.Exists(PrjTitle & ".INI") Then
                Dim LicenseLines() As String = System.IO.File.ReadAllLines(PrjTitle & ".INI")
                If LicenseLines.Length = 7 Then
                    lblLicNo.Text = "License-Number: " & Mid(LicenseLines(1), InStr(LicenseLines(1), "=") + 1)
                    Dim Hddata() As String = Encoding.UTF8.GetString(Convert.FromBase64String(LicenseLines(5))).Split("|")
                    Dim data() As String = Encoding.UTF8.GetString(Convert.FromBase64String(LicenseLines(6))).Split("|")
                    LizInfoData.Orgnization = Mid(data(0), InStr(data(0), "=") + 1)
                    LizInfoData.OwnerUsr = data(1)
                    LizInfoData.City = data(2)
                    LizInfoData.Country = data(3)
                    LizInfoData.Phone = data(4)
                    LizInfoData.ZipCode = data(5)
                    LizInfoData.Revision = data(6)
                    LizInfoData.prjTitle = data(7)
                    If LizInfoData.prjTitle.ToUpper() <> PrjTitle.ToUpper() Then
                        MsgBox("Invalid License File For Project " & PrjTitle)
                        End
                    End If
                    LizInfoData.Serial = Mid(LicenseLines(1), InStr(LicenseLines(1), "=") + 1)
                    LizInfoData.Key = Mid(LicenseLines(2), InStr(LicenseLines(2), "=") + 1)
                    LicenseLines(3) = LicenseLines(3).Replace("-", "/")
                    LicenseLines(4) = LicenseLines(4).Replace("-", "/")
                    LizInfoData.ExpiryDate = Date.ParseExact(Mid(LicenseLines(3), InStr(LicenseLines(3), "=") + 1), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    LizInfoData.GenerateDate = Date.ParseExact(Mid(LicenseLines(4), InStr(LicenseLines(4), "=") + 1), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)

                    If Today > LizInfoData.ExpiryDate Or Year(Today) < 2014 Or Today < LizInfoData.GenerateDate Then
                        If Today < LizInfoData.GenerateDate AndAlso Today >= New Date(2014, 4, 4) AndAlso Today <= New Date(2014, 4, 9) Then 'this period allow for black conversion
                        Else
                            MsgBox("License Expired")
                            End
                        End If
                    End If

                    LicExpiryDt = LizInfoData.ExpiryDate

                    If DateDiff("D", Today, LicExpiryDt) <= 10 Then
                        MsgBox("LICENSE WILL EXPIRE ON " & LicExpiryDt)
                    End If

                    lblOwner.Text = LizInfoData.OwnerUsr
                    lblOrgnization.Text = LizInfoData.Orgnization
                    Dim LicStr As String
                    Dim ProductId As String = Mid(LizInfoData.Serial, 1, 6)
                    Dim Key() As String = Split(LizInfoData.Key, "-")
                    LicStr = SwapData(Mid(Hddata(0), InStr(Hddata(0), "=") + 1)) & SwapData(Hddata(1)) & SwapData(Hddata(2)) & SwapData(Hddata(3)) & SwapData(Hddata(4)) & SwapData(Hddata(5)) & SwapData(ProductId)
                    Dim cRegNo As New GenerateSrNo.GenerteSrNo
                    If cRegNo.IsKeyOK(Key(0) & Key(1) & Key(2) & Key(3), LicStr, lblOrgnization.Text) Then
                        Dim LicVarData As New LicVar
                        Dim srKey As String
                        GenerateHddInfo(LicVarData)
                        If LicVarData.HddNo = "" Then
                            SubGetRegValue(LicVarData.HddNo, LicVarData.HddRevision)
                        End If
                        LicStr = SwapData(LicVarData.HddNo) & SwapData(LicVarData.HddRevision) & SwapData(LicVarData.ProcessorId) & SwapData(LicVarData.ProcessorLevel) & SwapData(LicVarData.ProcessorRevision) & SwapData(LicVarData.BaseBoardProduct) & SwapData(ProductId)
                        srKey = cRegNo.GenerateKey(LicStr, lblOrgnization.Text)
                        If srKey <> Key(0) & Key(1) & Key(2) & Key(3) Then
                            MsgBox("Not A Valid License")
                            End
                        End If
                    Else
                        MsgBox("Not A Valid License")
                        End
                    End If
                    cRegNo = Nothing
                Else
                    MsgBox("Not A Valid License")
                    End
                End If
skip:


                LicenseToolStripMenuItem.Enabled = False 'dis 260309
            Else
                AdminMenu.Enabled = False
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        Finally

        End Try

        ' txtName.Focus()

        If Directory.Exists(targetDir) = False Then
            Directory.CreateDirectory(targetDir)
        End If
        Application.DoEvents()
        Me.Refresh()
        Exit Sub
Out:
        End
    End Sub

    Private Sub GenerateDataAndCreateLicDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateDataAndCreateLicDataToolStripMenuItem.Click
        Dim frmGenerateLicDataFile As New frmGenerateLicenseDataFile
        frmGenerateLicDataFile.ShowDialog()
    End Sub

    Private Sub ImportLizFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportLizFileToolStripMenuItem.Click
        Dim frmImpLizFile As New frmImportLizFile
        frmImpLizFile.ShowDialog()
    End Sub

    Private Sub MDIParent1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    End Sub

    Private Sub RetrivePDFDocumentPaperSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetrivePDFDocumentPaperSizeToolStripMenuItem.Click
        Dim frm As New frmGenerateExcelFromPDFPaperSize
        frm.ShowDialog()
    End Sub

    Private Sub ChangingResolutionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangingResolutionToolStripMenuItem.Click
        Dim frm As New frmChangingResolution
        frm.ShowDialog()
    End Sub

    Private Sub ImageSizeSummaryFromExportedImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageSizeSummaryFromExportedImagesToolStripMenuItem.Click
        Dim frm As New frmImageSummary
        frm.ShowDialog()
    End Sub

    Private Sub MapPDFSizeSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapPDFSizeSummaryToolStripMenuItem.Click
        Dim frm As New frmPDFSummary
        frm.ShowDialog()
    End Sub

    Private Sub MapListIntoExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapListIntoExcelToolStripMenuItem.Click
        Dim frm As New frmMapListToExcel
        frm.ShowDialog()

    End Sub

    Private Sub MergeMapImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeMapImagesToolStripMenuItem.Click
        Dim frm As New frmMergeMap
        frm.ShowDialog()
    End Sub

    Private Sub RegenerateReplaceRepairSingalPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegenerateReplaceRepairSingalPDFToolStripMenuItem.Click
        Dim frm As New frmRegerate_Replace_Repair_SingalPDF
        frm.ShowDialog()
    End Sub
End Class
