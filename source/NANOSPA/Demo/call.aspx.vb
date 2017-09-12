Imports System.Web.Services

Public Class _call
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <WebMethod> _
    Public Shared Function GetTime() As List(Of CM.TNTP_DM_DICHVUEntity)
        Dim objFC_dmdichvu As New BO.TNTP_DM_DICHVUFacade
        Dim ab As New System.Collections.Generic.List(Of CM.TNTP_DM_DICHVUEntity)()
        ab = objFC_dmdichvu.SelectAll()
        Return ab
    End Function
End Class