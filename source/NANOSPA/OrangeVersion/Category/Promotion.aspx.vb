Public Class Promotion
    Inherits System.Web.UI.Page
    Dim objEn_MKT_SALES As CM.icls_MKT_SALES
    Dim objFc_MKT_SALES As BO.clsB_MKT_SALES
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            d_Tungay.Date = DateTime.Now.ToString
            d_Denngay.Date = DateTime.Now.ToString
            txt_Start.Date = DateTime.Now.ToString
            txt_End.Date = DateTime.Now.ToString
            Load_DATA()
        End If
    End Sub
#Region "Gridview event"
    Protected Sub Grid_Promotion_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFc_MKT_SALES = New BO.clsB_MKT_SALES
        Dim uId_Sale As String
        uId_Sale = e.Keys(0).ToString
        Try
            objFc_MKT_SALES.DeleteByID(uId_Sale)
            Grid_Promotion.CancelEdit()
            e.Cancel = True
            Load_DATA()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Load_DATA()
        objFc_MKT_SALES = New BO.clsB_MKT_SALES
        Dim dt As DataTable = objFc_MKT_SALES.Select_All_Table()
            Grid_Promotion.DataSource = dt
            Grid_Promotion.DataBind()
    End Sub
#End Region
    Protected Sub btn_Themmoi_Click(sender As Object, e As EventArgs)
        objEn_MKT_SALES = New CM.cls_MKT_SALES
        objFc_MKT_SALES = New BO.clsB_MKT_SALES
        With objEn_MKT_SALES
            .nv_Tenchuongtrinh_vn = txt_Chuongtrinh.Text
            If txt_percent.Text <> "" Then
                .f_Giamgia_percent = Convert.ToInt16(txt_percent.Text)
            Else
                .f_Giamgia_percent = 0
            End If
            If txt_Money.Text <> "" Then
                .f_Giamgia_money = Convert.ToInt32(txt_Money.Text)
            Else
                .f_Giamgia_money = 0
            End If

            .d_Start = txt_Start.Date
            .d_End = txt_End.Date
        End With
        If (Session("uId_Sale") <> Nothing Or Session("uId_Sale") <> "") Then
            Try
                With objEn_MKT_SALES
                    .uId_Sale = Session("uId_Sale")
                    .nv_Tenchuongtrinh_vn = txt_Chuongtrinh.Text
                    If txt_percent.Text <> "" Then
                        .f_Giamgia_percent = Convert.ToInt16(txt_percent.Text)
                    Else
                        .f_Giamgia_percent = 0
                    End If
                    If txt_Money.Text <> "" Then
                        .f_Giamgia_money = Convert.ToInt32(txt_Money.Text)
                    Else
                        .f_Giamgia_money = 0
                    End If
                    .d_Start = txt_Start.Date
                    .d_End = txt_End.Date
                End With
                objFc_MKT_SALES.Update(objEn_MKT_SALES)
                Load_DATA()
            Catch ex As Exception
            End Try
        Else
            Try
                objFc_MKT_SALES.Insert(objEn_MKT_SALES)
                Load_DATA()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        objFc_MKT_SALES = New BO.clsB_MKT_SALES
        Dim dt As DataTable = objFc_MKT_SALES.Search_By_Date(d_Tungay.Date, d_Denngay.Date)
        If dt.Rows.Count > 0 Then
            Grid_Promotion.DataSource = dt
            Grid_Promotion.DataBind()
        Else
            Grid_Promotion.DataSource = Nothing
            Grid_Promotion.DataBind()
        End If
    End Sub
End Class