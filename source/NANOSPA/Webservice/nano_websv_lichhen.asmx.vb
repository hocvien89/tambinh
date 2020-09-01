Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class nano_websv_lichhen
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function LoadInfoStaff(uidNhanvien As String, dStart As DateTime, dEnd As DateTime) As String
        Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim str As String = "Yes"
        Try
            objFcNhanvien = New BO.QT_DM_NHANVIENFacade
            dt = objFcNhanvien.SelectnhanvienByLichhen(Session("uId_Nhanvien"), dStart, dEnd, uidNhanvien)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If row("uId_Nhanvien").ToString = uidNhanvien Then
                        If row("trangthai").ToString = "1" Then
                            str = "No"
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
        Return str
    End Function

End Class