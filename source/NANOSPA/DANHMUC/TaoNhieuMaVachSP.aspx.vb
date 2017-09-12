Imports System.Drawing
Imports System.Drawing.Imaging
Imports iTextSharp.text.pdf
Imports System.IO

Partial Public Class TaoNhieuMaVachSP
    Inherits System.Web.UI.Page
    Dim BC As TaoMaVachSP
    Private objFC As New BO.QLMH_DM_MATHANGFacade
    Private objEn As New CM.QLMH_DM_MATHANGEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub
    Private Sub LoadData()
        BC = New TaoMaVachSP
        
        Dim dtbarcode As New DataTable
        dtbarcode.Columns.Add(New DataColumn("BarcodeImg1", System.Type.GetType("System.Byte[]")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeImg2", System.Type.GetType("System.Byte[]")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeImg3", System.Type.GetType("System.Byte[]")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeImg4", System.Type.GetType("System.Byte[]")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeText1", System.Type.GetType("System.String")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeText2", System.Type.GetType("System.String")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeText3", System.Type.GetType("System.String")))
        dtbarcode.Columns.Add(New DataColumn("BarcodeText4", System.Type.GetType("System.String")))
        Dim k As Integer = 1
        Dim j As Integer = 0
        Dim strcode As String
        Dim strDS_SP As String = Session("DS_SPBarcode").ToString
        Dim i As Integer = 2
        Dim barcode As Barcode

        While i < strDS_SP.Length
            If IsNumeric(strDS_SP(i)) Then
                strcode = Mid(strDS_SP, i, 13)
                i += 14
                barcode = New BarcodeEAN
            Else : strcode = Mid(strDS_SP, i, 10)
                i += 11
                barcode = New Barcode128
            End If
            barcode.BarHeight = 50
            If k = 1 Then
                dtbarcode.Rows.Add(dtbarcode.NewRow)
                dtbarcode.Rows(j)("BarcodeText1") = strcode
                barcode.Code = strcode
                dtbarcode.Rows(j)("BarcodeImg1") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
            End If
            If k = 2 Then
                dtbarcode.Rows(j)("BarcodeText2") = strcode
                barcode.Code = strcode
                dtbarcode.Rows(j)("BarcodeImg2") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
            End If
            If k = 3 Then
                dtbarcode.Rows(j)("BarcodeText3") = strcode
                barcode.Code = strcode
                dtbarcode.Rows(j)("BarcodeImg3") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
            End If
            If k = 4 Then
                dtbarcode.Rows(j)("BarcodeText4") = strcode
                barcode.Code = strcode
                dtbarcode.Rows(j)("BarcodeImg4") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
            End If
            If k = 4 Then
                k = 1
                j += 1
            Else : k += 1
            End If
        End While
        BC.SetDataSource(dtbarcode)
        CrvMaVachSP.ReportSource = BC
    End Sub
    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim imgStream As MemoryStream = New MemoryStream()

        img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)

        imgStream.Close()
        Dim byteArray As Byte() = imgStream.ToArray()
        imgStream.Dispose()

        Return byteArray
    End Function

    Private Sub TapNhieuMaVach_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        If Not BC Is Nothing Then
            BC.Close()
            BC.Dispose()
            BC = Nothing
        End If
    End Sub
End Class