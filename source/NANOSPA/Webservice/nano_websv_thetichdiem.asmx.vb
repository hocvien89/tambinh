Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class nano_websv_thetichdiem
    Inherits System.Web.Services.WebService
    Private objEnTTDChuyendoi As CM.cls_TTV_DM_Thetichdiem_ChuyendoiEntity
    Private objFcTTDChuyendoi As BO.clsB_TTV_DM_Thetichdiem_Chuyendoi
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class