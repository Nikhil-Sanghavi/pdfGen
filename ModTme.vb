Module ModTme
    Public Const LOCALE_SLANGUAGE As Integer = &H2S 'localized name of language
    Public Const LOCALE_SSHORTDATE As Integer = &H1FS 'short date format string
    Public Const LOCALE_SLONGDATE As Integer = &H20S 'long date format string
    Public Const DATE_LONGDATE As Integer = &H2S
    Public Const DATE_SHORTDATE As Integer = &H1S
    Public Const HWND_BROADCAST As Integer = &HFFFF
    Public Const WM_SETTINGCHANGE As Integer = &H1AS

    Public Declare Function GetSystemDefaultLCID Lib "kernel32" () As Integer

    Public Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer

    Public Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Integer
    Public Function GetUserLocaleInfo(ByVal dwLocaleID As Integer, ByVal dwLCType As Integer) As String
        Dim sReturn As String = ""
        Dim r As Integer

        'call the function passing the Locale type
        'variable to retrieve the required size of
        'the string buffer needed
        r = GetLocaleInfo(dwLocaleID, dwLCType, sReturn, Len(sReturn))

        'if successful..
        If r Then
            'pad the buffer with spaces
            sReturn = Space(r)
            'and call again passing the buffer
            r = GetLocaleInfo(dwLocaleID, dwLCType, sReturn, Len(sReturn))
            'if successful (r > 0)
            If r Then
                'r holds the size of the string
                'including the terminating null
                GetUserLocaleInfo = Left(sReturn, r - 1)
            Else
                Return sReturn
            End If
        Else
            Return sReturn
        End If
    End Function
End Module
