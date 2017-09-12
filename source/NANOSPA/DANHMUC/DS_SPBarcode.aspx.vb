Imports System.Drawing
Imports System.Drawing.Imaging
Imports iTextSharp.text.pdf
Imports System.IO

Partial Public Class DS_SPBarcode
    Inherits System.Web.UI.Page
    Private objFCNhommathang As New BO.QLMH_DM_NHOMMATHANGFacade
    Private objEnNhommathang As New CM.QLMH_DM_NHOMMATHANGEntity
    Private objFC As New BO.QLMH_DM_MATHANGFacade
    Private objEn As New CM.QLMH_DM_MATHANGEntity
    Dim BC As TaoMaVachSP
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDropDownListNhommathang()
            LoadData()
        End If
        'LoadCrystal()
    End Sub
    Private Sub LoadData()
        Dim dt As DataTable
        dt = objFC.SelectAllBarcode(ddlNhomMH.SelectedValue)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
        End If
        GvSPBarcode.DataSource = dt
        GvSPBarcode.DataBind()
        Dim chk As CheckBox
        Dim checkboxIdsList As New List(Of String)

        For Each rowItem As GridViewRow In GvSPBarcode.Rows
            chk = CType(rowItem.Cells(0).FindControl("ChkChon"), CheckBox)
            checkboxIdsList.Add(chk.ClientID)
        Next

        Dim checkboxIds As String = String.Join("|", checkboxIdsList.ToArray())
        CType(GvSPBarcode.HeaderRow.Cells(0).FindControl("chkSelectAll"), CheckBox).Attributes.Add("onclick", "selectAll('" & checkboxIds & "',this)")
        If Session("DS_SPBarcode").ToString <> "" Then
            Dim strDS_SP As String = Session("DS_SPBarcode").ToString
            For i As Integer = 0 To GvSPBarcode.Rows.Count - 1
                If (InStr(strDS_SP, GvSPBarcode.Rows(i).Cells(3).Text) > 0) Then
                    CType(GvSPBarcode.Rows(i).Cells(0).FindControl("ChkChon"), CheckBox).Checked = True
                End If
            Next
        End If
    End Sub
    Private Sub LoadDropDownListNhommathang()
        ddlNhomMH.DataSource = objFCNhommathang.SelectAllTable()
        ddlNhomMH.DataTextField = "nv_Tennhommathang_vn"
        ddlNhomMH.DataValueField = "uId_Nhommathang"
        ddlNhomMH.DataBind()
    End Sub
    Private Sub SaveDS_SP()
        Dim strDS_Sp As String = Session("DS_SPBarcode").ToString
        For i As Integer = 0 To GvSPBarcode.Rows.Count - 1
            If (CType(GvSPBarcode.Rows(i).Cells(0).FindControl("ChkChon"), CheckBox).Checked) Then
                If (InStr(strDS_Sp, GvSPBarcode.Rows(i).Cells(3).Text) = 0) And (GvSPBarcode.Rows(i).Cells(3).Text.Length > 9) Then
                    strDS_Sp = strDS_Sp + ";" + GvSPBarcode.Rows(i).Cells(3).Text
                End If
            Else : strDS_Sp = strDS_Sp.Replace(";" + GvSPBarcode.Rows(i).Cells(3).Text, "")
            End If
        Next
        Session("DS_SPBarcode") = strDS_Sp
    End Sub
    Protected Sub GvSPBarcode_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvSPBarcode.PageIndexChanging
        SaveDS_SP()
        GvSPBarcode.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub ddlNhomMH_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlNhomMH.SelectedIndexChanged
        SaveDS_SP()
        LoadData()
    End Sub
    Protected Sub btnLuu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
        SaveDS_SP()
        If Session("DS_SPBarcode").ToString <> "" Then
            'Response.Redirect("TaoNhieuMaVachSP.aspx")
            LoadCrystal()
        Else : ShowMessage(Me, "Xin chọn ít nhất 1 sản phẩm.")
        End If

    End Sub
    'Private Sub LoadCrystal()
    '    BC = New TaoMaVachSP
    '    Dim dtbarcode As New DataTable
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg1", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg2", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg3", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg4", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText1", System.Type.GetType("System.String")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText2", System.Type.GetType("System.String")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText3", System.Type.GetType("System.String")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText4", System.Type.GetType("System.String")))
    '    Dim k As Integer = 1
    '    Dim j As Integer = 0
    '    Dim strcode As String
    '    Dim strDS_SP As String = Session("DS_SPBarcode").ToString
    '    Dim i As Integer = 2
    '    Dim barcode As Barcode

    '    While i < strDS_SP.Length
    '        If IsNumeric(strDS_SP(i)) Then
    '            strcode = Mid(strDS_SP, i, 13)
    '            i += 14
    '            barcode = New BarcodeEAN
    '        Else : strcode = Mid(strDS_SP, i, 10)
    '            i += 11
    '            barcode = New Barcode128
    '        End If
    '        barcode.BarHeight = 50
    '        If k = 1 Then
    '            dtbarcode.Rows.Add(dtbarcode.NewRow)
    '            dtbarcode.Rows(j)("BarcodeText1") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg1") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 2 Then
    '            dtbarcode.Rows(j)("BarcodeText2") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg2") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 3 Then
    '            dtbarcode.Rows(j)("BarcodeText3") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg3") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 4 Then
    '            dtbarcode.Rows(j)("BarcodeText4") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg4") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 4 Then
    '            k = 1
    '            j += 1
    '        Else : k += 1
    '        End If
    '    End While
    '    BC.SetDataSource(dtbarcode)
    '    CrvMaVachSP.ReportSource = BC
    'End Sub
    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim imgStream As MemoryStream = New MemoryStream()

        img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)

        imgStream.Close()
        Dim byteArray As Byte() = imgStream.ToArray()
        imgStream.Dispose()

        Return byteArray
    End Function

    Private Sub Crystal_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        If Not BC Is Nothing Then
            BC.Close()
            BC.Dispose()
            BC = Nothing
        End If
    End Sub

End Class