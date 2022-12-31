Imports System.IO
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.Events

Public Class frmUploadCDOPDF
    Dim blnExit As Boolean = False
    Dim blnCancel As Boolean = False
    'Dim ExportFileDir As String
    Dim ExportPDfPath As String

    Dim con As OleDb.OleDbConnection
    Dim da As OleDb.OleDbDataAdapter
    Dim cb As OleDb.OleDbCommandBuilder
    Dim commSelect As New OleDb.OleDbCommand
    Dim drREader As OleDb.OleDbDataReader


    Dim ds As New DataSet
    Dim dr As DataRow

    Dim strQ As String = ""
    Dim indVal As String = ""
    Dim strUploadFilePath As String = ""
    Dim PdfFileList As String = ""

    Dim driver As IWebDriver
    Dim wait As WebDriverWait
    Dim AppPath As String = Application.StartupPath()
    Dim DrvHdl As IntPtr
    Dim eventDriver As EventFiringWebDriver

    Private Sub frmUploadCDOPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class