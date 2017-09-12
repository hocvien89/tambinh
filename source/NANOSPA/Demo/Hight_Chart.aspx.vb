Imports System.Web.Services

Public Class Hight_Chart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <WebMethod> _
    Public Shared Function GetTime() As List(Of CM.CRM_DM_KhachhangEntity)
        Dim objFcKH = New BO.CRM_DM_KhachhangFacade
        Dim list As New System.Collections.Generic.List(Of CM.CRM_DM_KhachhangEntity)
        Dim objFC_dmdichvu As New BO.TNTP_DM_DICHVUFacade
        Dim ab As New System.Collections.Generic.List(Of CM.TNTP_DM_DICHVUEntity)()
        ab = objFC_dmdichvu.SelectAll()
        list = objFcKH.ThongkeKH((Now.Date.AddDays(-Now.Day - 1)), Now.Date)
        Return list
    End Function
End Class