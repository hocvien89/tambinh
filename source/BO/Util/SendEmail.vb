Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Mime
Imports System.Linq
Public Class SendEmail
    Private m_strFromEmail As String = ""

    Public Property StrFromEmail() As String
        Get
            Return m_strFromEmail
        End Get
        Set(ByVal value As String)
            m_strFromEmail = value
        End Set
    End Property
    Private m_strDisplayName As String = ""

    Public Property StrDisplayName() As String
        Get
            Return m_strDisplayName
        End Get
        Set(ByVal value As String)
            m_strDisplayName = value
        End Set
    End Property
    Private m_strHost As String = ""
    'smtp.Host = "smtp.gmail.com";//"webmail.neu.edu.vn/exchange";
    Public Property StrHost() As String
        Get
            Return m_strHost
        End Get
        Set(ByVal value As String)
            m_strHost = value
        End Set
    End Property
    Private m_strToEmail As String = ""
    ' Cach nhau boi dau ,
    Public Property StrToEmail() As String
        Get
            Return m_strToEmail
        End Get
        Set(ByVal value As String)
            m_strToEmail = value
        End Set
    End Property
    Private m_strCCEmail As String = ""
    ' Cach nhau boi dau ,
    Public Property StrCCEmail() As String
        Get
            Return m_strCCEmail
        End Get
        Set(ByVal value As String)
            m_strCCEmail = value
        End Set
    End Property
    Private m_strBCCEmail As String = ""
    ' Cach nhau boi dau ,
    Public Property StrBCCEmail() As String
        Get
            Return m_strBCCEmail
        End Get
        Set(ByVal value As String)
            m_strBCCEmail = value
        End Set
    End Property
    Private m_strBodyMessege As String = ""

    Public Property StrBodyMessege() As String
        Get
            Return m_strBodyMessege
        End Get
        Set(ByVal value As String)
            m_strBodyMessege = value
        End Set
    End Property
    Private m_strSubject As String = ""

    Public Property StrSubject() As String
        Get
            Return m_strSubject
        End Get
        Set(ByVal value As String)
            m_strSubject = value
        End Set
    End Property
    Private m_bIsBodyHtml As Boolean = False

    Public Property BIsBodyHtml() As Boolean
        Get
            Return m_bIsBodyHtml
        End Get
        Set(ByVal value As Boolean)
            m_bIsBodyHtml = value
        End Set
    End Property
    Private m_iport As Integer = 25

    Public Property Iport() As Integer
        Get
            Return m_iport
        End Get
        Set(ByVal value As Integer)
            m_iport = value
        End Set
    End Property
    Private m_strCreEmail As String = ""

    Public Property StrCreEmail() As String
        Get
            Return m_strCreEmail
        End Get
        Set(ByVal value As String)
            m_strCreEmail = value
        End Set
    End Property
    Private m_strCrePass As String = ""

    Public Property StrCrePass() As String
        Get
            Return m_strCrePass
        End Get
        Set(ByVal value As String)
            m_strCrePass = value
        End Set
    End Property
    Private m_bEndableSLL As Boolean = False

    Public Property BEndableSLL() As Boolean
        Get
            Return m_bEndableSLL
        End Get
        Set(ByVal value As Boolean)
            m_bEndableSLL = value
        End Set
    End Property

    Private m_strDefaultUrl As String = ""

    Public Property StrDefaultUrl() As String
        Get
            Return m_strDefaultUrl
        End Get
        Set(ByVal value As String)
            m_strDefaultUrl = value
        End Set
    End Property
    Public m_plainTextBody As String = ""
    Public Property PlainTextBody() As String
        Get
            Return m_plainTextBody
        End Get
        Set(ByVal value As String)
            m_plainTextBody = value
        End Set
    End Property
    Public m_htmlBody As String = ""
    Public Property HtmlBody() As String
        Get
            Return m_htmlBody
        End Get
        Set(ByVal value As String)
            m_htmlBody = value
        End Set
    End Property

    Public Sub New()
    End Sub
    Public Function SentEmail() As Boolean
        Dim status As Boolean = False
        Dim smtpClient As New SmtpClient()
        Dim message As New MailMessage()
        Dim plainTextView As AlternateView = AlternateView.CreateAlternateViewFromString(m_plainTextBody, Nothing, MediaTypeNames.Text.Plain)
        message.AlternateViews.Add(plainTextView)
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(m_htmlBody, Nothing, MediaTypeNames.Text.Html)
        message.AlternateViews.Add(htmlView)
        Try
            Dim fromAddress As New MailAddress(m_strFromEmail, m_strDisplayName)
            smtpClient.Host = m_strHost
            ' 25;465
            smtpClient.Port = m_iport
            message.From = fromAddress
            message.[To].Add(m_strToEmail)
            message.Subject = m_strSubject
            message.IsBodyHtml = True


            If Me.m_strCCEmail <> "" Then
                message.CC.Add(m_strCCEmail)
            End If
            If Me.m_strBCCEmail <> "" Then
                message.Bcc.Add(m_strBCCEmail)
            End If

            message.IsBodyHtml = False
            message.Body = Me.m_strBodyMessege
            If Me.m_strDefaultUrl <> "" Then
                message.Body += vbLf & " Website:" + Me.m_strDefaultUrl
            End If

            ' Send SMTP mail
            smtpClient.Credentials = New NetworkCredential(Me.m_strCreEmail, Me.m_strCrePass)
            smtpClient.EnableSsl = m_bEndableSLL
            smtpClient.Send(message)
            status = True
        Catch ex As Exception
            ' return status;
            Throw New Exception(ex.Message.ToString() + ex.StackTrace)
        End Try
        Return status
    End Function
End Class
