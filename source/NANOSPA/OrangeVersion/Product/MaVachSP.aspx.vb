Imports System.Drawing
Imports System.Drawing.Imaging
Imports iTextSharp.text.pdf
Imports System.IO

Partial Public Class MaVachSP
    Inherits System.Web.UI.Page
    Private objFcThamsohethong As New BO.clsB_QT_THAMSOHETHONG

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim barcode As String = CStr(Request.QueryString("value"))
            ProcessBarCode(barcode)
        End If
    End Sub
    Protected Sub ProcessBarCode(ByVal value As String)
        Dim sList() As String
        sList = value.Split("$")
        Dim code As String = sList(1)
        If sList(0) = "EAN" Then
            Dim barcode As New BarcodeEAN
            barcode.BarHeight = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("BcodeH").v_Giatri.ToString)
            If code.Length = 12 Then
                code = InsertCheckSum(code)
            End If
            If IsNumeric(code) And code.Length = 13 Then
                barcode.Code = code
                Dim bc As System.Drawing.Image = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White)
                Dim bm As Bitmap = New Bitmap(bc)
                Dim ms As New MemoryStream
                Response.ContentType = "image/png"
                bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                ms.WriteTo(Response.OutputStream)
                bm.Dispose()
                bc.Dispose()
            Else
                Dim b As New Bitmap(200, 65, Imaging.PixelFormat.Format32bppArgb)
                Dim g As Graphics = Graphics.FromImage(b)
                g.FillRectangle(Brushes.White, 0, 0, 200, 65)
                Dim textBrush As New SolidBrush(Color.Black)
                g.FillRectangle(Brushes.White, 0, 0, 200, 65)
                g.DrawString("Mã vạch không hợp lệ!", New Font("Arial", 10), textBrush, 0, 0)
                g.DrawString("Không thể tạo mã vạch :", New Font("Arial", 10), textBrush, 0, 15)
                g.DrawString(code, New Font("Arial", 10), textBrush, 0, 30)
                g.DrawString("Xin nhập đúng chuẩn EAN13", New Font("Arial", 10), textBrush, 0, 45)
                Dim ms As New MemoryStream
                Response.ContentType = "image/png"
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                ms.WriteTo(Response.OutputStream)
                b.Dispose()
            End If
        Else
            Dim barcode As New Barcode128
            barcode.BarHeight = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("BcodeH").v_Giatri.ToString)
            barcode.Code = code
            barcode.GenerateChecksum = True
            Dim bc As System.Drawing.Image = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White)
            Dim bm As Bitmap = New Bitmap(bc)
            Dim ms As New MemoryStream
            Response.ContentType = "image/png"
            bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            ms.WriteTo(Response.OutputStream)
            bm.Dispose()
            bc.Dispose()
        End If
    End Sub
    Private Function InsertCheckSum(ByVal code As String) As String
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim j As Integer = 11
        For i As Integer = 1 To 12
            If i Mod 2 = 0 Then
                X += Val(code(j))
            Else
                Y += Val(code(j))
            End If
            j -= 1
        Next

        Dim Z As Integer = X + (3 * Y)
        Return code + ((10 - (Z Mod 10)) Mod 10).ToString
    End Function
End Class