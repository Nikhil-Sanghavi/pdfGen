Imports System.Runtime.InteropServices
Public Class setSysDate
    <StructLayout(LayoutKind.Sequential)> _
     Public Structure SYSTEMTIME
        <MarshalAs(UnmanagedType.U2)> Public Year As Short
        <MarshalAs(UnmanagedType.U2)> Public Month As Short
        <MarshalAs(UnmanagedType.U2)> Public DayOfWeek As Short
        <MarshalAs(UnmanagedType.U2)> Public Day As Short
        <MarshalAs(UnmanagedType.U2)> Public Hour As Short
        <MarshalAs(UnmanagedType.U2)> Public Minute As Short
        <MarshalAs(UnmanagedType.U2)> Public Second As Short
        <MarshalAs(UnmanagedType.U2)> Public Milliseconds As Short
    End Structure

    <DllImport("kernel32.dll")> _
    Public Shared Sub GetLocalTime(ByRef time As SYSTEMTIME)
    End Sub

    <DllImport("kernel32.dll")> _
    Public Shared Function SetLocalTime(ByRef time As SYSTEMTIME) As Boolean
    End Function
    Public Sub SetsLocalTimeHourToEight()
        Dim currentTime As SYSTEMTIME
        GetLocalTime(currentTime)

        currentTime.Hour = 8

        SetLocalTime(currentTime)
    End Sub

End Class
