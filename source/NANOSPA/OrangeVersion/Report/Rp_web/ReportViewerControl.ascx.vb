Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Web
Imports DevExpress.Web.ASPxClasses
Public Class ReportViewerControl
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property ReportViewer() As ReportViewer
        Get
            Return ReportViewer1
        End Get
    End Property
    Public Property Report() As XtraReport
        Get
            Return ReportViewer1.Report
        End Get
        Set(ByVal value As XtraReport)
            ReportViewer1.Report = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ReportViewer1_CacheReportDocument(sender As Object, e As CacheReportDocumentEventArgs)
        e.Key = Guid.NewGuid().ToString()
        Page.Session(e.Key) = e.SaveDocumentToMemoryStream()
    End Sub

    Protected Sub ReportViewer1_RestoreReportDocumentFromCache(sender As Object, e As RestoreReportDocumentFromCacheEventArgs)
        Dim stream As Stream = TryCast(Page.Session(e.Key), Stream)
        If stream IsNot Nothing Then
            e.RestoreDocumentFromStream(stream)
        End If
    End Sub

    Protected Sub ReportViewer1_Unload(sender As Object, e As EventArgs) Handles ReportViewer1.Unload
        DirectCast(sender, ReportViewer).Report = Nothing
    End Sub
End Class