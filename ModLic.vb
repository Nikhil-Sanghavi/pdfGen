Imports System.Management
Module ModLic
    Public strVersion As String = "1.0"
    Public LizInfoData As New LizInfo
    Public ExpiryDay As Integer
    Public PrjTitle As String = "ImgPDFProcLic" & LastFolderNm
    Public RegKey As String = "SOFTWARE\SCC"
    Public RegSubKey As String = "SOFTWARE\SCC\ImgPDFProcLic" & LastFolderNm
    Structure LicVar
        Dim HddNo As String
        Dim HddRevision As String
        Dim ProcessorId As String
        Dim ProcessorLevel As String
        Dim ProcessorRevision As String
        Dim BaseBoardProduct As String
        Dim IpAdd As String
        Dim SubNetAdd As String
        Dim MacAdd As String
        Dim Orgnization As String
        Dim OwnerUsr As String
        Dim City As String
        Dim Country As String
        Dim Phone As String
        Dim ZipCode As String
        Dim PrjTitle As String
    End Structure
    Structure LizInfo
        Dim Orgnization As String
        Dim OwnerUsr As String
        Dim City As String
        Dim Country As String
        Dim Phone As String
        Dim ZipCode As String
        Dim Revision As Integer
        Dim prjTitle As String
        Dim Key As String
        Dim Serial As String
        Dim GenerateDate As Date
        Dim ExpiryDate As Date
    End Structure
    Public Function encrypt(ByVal value As String) As String
        value = value.ToUpper
        Dim i As Int16
        Dim newstring As String = ""
        Dim chrset1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_."
        Dim chrset2 As String = "4Z_5ABCD8VWTXY9.EFG1U6HIJKLM23NQRS7OP0"
        Dim mychar, newchar As Char
        Dim Position As Int16
        For i = 0 To value.Length - 1
            mychar = value.Chars(i)
            Position = chrset1.IndexOf(mychar)
            If Position = -1 Then
                newchar = mychar
            Else
                newchar = chrset2.Chars(Position)
            End If
            newstring = newstring & newchar
        Next
        Return newstring
    End Function
    Public Function decrypt(ByVal value As String) As String
        Dim i As Int16
        Dim newstring As String = ""
        Dim chrset1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_."
        Dim chrset2 As String = "4Z_5ABCD8VWTXY9.EFG1U6HIJKLM23NQRS7OP0"
        Dim mychar, newchar As Char
        Dim Position As Int16
        For i = 0 To value.Length - 1
            mychar = value.Chars(i)
            Position = chrset2.IndexOf(mychar)
            If Position = -1 Then
                newchar = mychar
            Else
                newchar = chrset1.Chars(Position)
            End If
            newstring = newstring & newchar
        Next
        Return newstring
    End Function
    Public Function SwapData(ByVal str As String) As String
        Dim ind As Integer
        Dim c As Char
        Dim SwapString As String = ""
        Dim TempStr() As Char = str.ToCharArray
        For ind = str.Length - 1 To 0 Step -1
            c = TempStr(ind)
            SwapString = SwapString & c
        Next
        Return (encrypt(SwapString))
    End Function
    Public Sub GenerateHddInfo(ByRef LicDataVar As LicVar)
        Try
            'HDD(Information)
            Dim Serial As String = ""
            Dim Revision As String = ""
            Dim HInfo As New GenerateSrNo.HddInfo
            HInfo.GetHddInfo(Serial, Revision)
            If Serial <> "" Then
                LicDataVar.HddNo = Serial.Trim
            End If
            If Revision <> "" Then
                LicDataVar.HddRevision = Revision.Trim
            End If

            'Dim HddInfo As DriveListEx = New DriveListEx()
            'HddInfo.Load()
            'LicDataVar.HddNo = HddInfo.Item(0).SerialNumber().ToString()
            'LicDataVar.HddRevision = HddInfo.Item(0).RevisionNumber.ToString()
            'HddInfo.Clear()
            'If Not IsNothing(HddInfo) Then
            '    HddInfo.Dispose()
            'End If
            'PROCESSOR INFORMATION

            Dim SearchRec As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT ProcessorId,Level,Revision,DeviceId FROM Win32_Processor")
            If IsNothing(SearchRec) Then
                SearchRec = New ManagementObjectSearcher("SELECT ProcessorId,Level,DeviceId FROM Win32_Processor")
            End If
            Dim share As ManagementObject
            For Each share In SearchRec.Get()
                LicDataVar.ProcessorId = share("ProcessorId").ToString()
                LicDataVar.ProcessorLevel = share("Level").ToString()
                'LicDataVar.ProcessorRevision = share("Revision").ToString()
                Try
                    LicDataVar.ProcessorRevision = share("Revision").ToString() 'revision is null
                Catch ex As Exception
                    LicDataVar.ProcessorRevision = share("DeviceId").ToString()
                End Try
                Exit For
            Next
            If Not IsNothing(SearchRec) Then
                SearchRec.Dispose()
            End If

            'BASE BOARD INFORMATION
            Dim BasedSearchRec As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT Product,SerialNumber FROM Win32_BaseBoard")
            For Each share In BasedSearchRec.Get()
                Try
                    If IsNothing(share("Product")) = False Then
                        LicDataVar.BaseBoardProduct = share("Product").ToString()
                    Else
                        LicDataVar.BaseBoardProduct = share("SerialNumber").ToString() 'dis 17072017 as product is blank we will go with serial number
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
                Exit For
            Next

            If Not IsNothing(BasedSearchRec) Then
                BasedSearchRec.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Error in GetHdInfo" & vbNewLine & ex.Message)
            Throw ex
        End Try
    End Sub
    Public Sub SubGetRegValue(ByRef HddNo As String, ByRef HddRevision As String)
        Dim rg As New GenerateSrNo.RegFun
        Try
            HddNo = rg.GetStringValue("HKEY_LOCAL_MACHINE\" & RegSubKey, "HN")
            HddRevision = rg.GetStringValue("HKEY_LOCAL_MACHINE\" & RegSubKey, "HR")
            If HddNo.Trim().ToUpper() = "ERROR" Then
                HddNo = ""
            Else
                HddNo = decrypt(Trim(HddNo))
            End If
            'Dim hd() As Char = HddNo.ToCharArray()
            'Dim i As Integer
            'For i = 0 To hd.Length
            '    If hd(i) = Nothing Then
            '        Dim t As String() = HddNo.Split(hd(i)) 'chr(0)
            '        Exit For
            '    End If
            'Next
            If HddRevision.Trim().ToUpper() = "ERROR" Then
                HddRevision = ""
            Else
                HddRevision = decrypt(Trim(HddRevision))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(rg) Then
                rg = Nothing
            End If
        End Try
    End Sub
    Public Sub SubSetRegValue(ByVal HddNo As String, ByVal HddRevision As String)
        Dim rg As New GenerateSrNo.RegFun
        Try
            rg.CreateKey("HKEY_LOCAL_MACHINE\" & RegKey)
            rg.CreateKey("HKEY_LOCAL_MACHINE\" & RegSubKey)
            rg.SetStringValue("HKEY_LOCAL_MACHINE\" & RegSubKey, "HN", HddNo)
            rg.SetStringValue("HKEY_LOCAL_MACHINE\" & RegSubKey, "HR", HddRevision)
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(rg) Then
                rg = Nothing
            End If
        End Try
    End Sub
    Public Sub ResetStructValue(ByRef LicDataVar As LicVar)
        LicDataVar.BaseBoardProduct = ""
        LicDataVar.City = ""
        LicDataVar.Country = ""
        LicDataVar.HddNo = ""
        LicDataVar.HddRevision = ""
        LicDataVar.IpAdd = ""
        LicDataVar.MacAdd = ""
        LicDataVar.Orgnization = ""
        LicDataVar.OwnerUsr = ""
        LicDataVar.Phone = ""
        LicDataVar.ProcessorId = ""
        LicDataVar.ProcessorLevel = ""
        LicDataVar.ProcessorRevision = ""
        LicDataVar.SubNetAdd = ""
        LicDataVar.ZipCode = ""
    End Sub
    Public Sub process_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal BlnNumeric As Boolean)
        Select Case e.KeyChar
            Case ControlChars.Cr
                SendKeys.Send(ControlChars.Tab)
            Case ControlChars.Back
            Case "0" To "9"
            Case Else
                If BlnNumeric Then
                    e.Handled = True
                End If
        End Select
    End Sub
    Public Function checkDefaultLocale() As Boolean
        Try
            Dim LCID As Integer
            Dim CurLocal As String
            Dim curShortFormat As String
            LCID = GetSystemDefaultLCID()

            CurLocal = GetUserLocaleInfo(LCID, LOCALE_SLANGUAGE)
            curShortFormat = GetUserLocaleInfo(LCID, LOCALE_SSHORTDATE)
            If CurLocal <> "English (United States)" Then
                MsgBox("Please Set Current Local To English (United States) In Regional Settings")
                Return False
            End If
            If curShortFormat <> "dd/MM/yyyy" Then
                MsgBox("Please Set Current Date Format To dd/MM/yyyy In Regional Settings")
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module
