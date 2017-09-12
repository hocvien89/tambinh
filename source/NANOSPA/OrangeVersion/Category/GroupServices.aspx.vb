Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Public Class GroupServices
    Inherits System.Web.UI.Page
    Private objFC As BO.TNTP_DM_NHOMDICHVUFacade
    Private objDV As BO.TNTP_DM_DICHVUFacade
    Private obj As CM.TNTP_DM_NHOMDICHVUEntity
    Private objBoCuahang As New BO.QT_DM_CUAHANGFacade
    Private objCmCuahang As New CM.QT_DM_CUAHANGEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadCuahang()
            cmbCuahang.SelectedIndex = 0
        End If
        loadNhomDv(Nothing)
    End Sub
    Public Sub loadNhomDv(uid As String)
        objFC = New BO.TNTP_DM_NHOMDICHVUFacade
        Dim dt As New DataTable
        dt = objFC.SelectAllTable(uid)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        dgvDev.DataSource = dt
        dgvDev.DataBind()
    End Sub

    Protected Sub dgvDev_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles dgvDev.RowUpdating
        obj = New CM.TNTP_DM_NHOMDICHVUEntity
        objFC = New BO.TNTP_DM_NHOMDICHVUFacade
        Try
            Dim uId_Nhomdichvu As String
            uId_Nhomdichvu = e.Keys(0).ToString
            obj.nv_TennhomDichvu_vn = e.NewValues("nv_TennhomDichvu_vn").ToString
            obj.uId_Nhomdichvu = uId_Nhomdichvu
            obj.nv_Ghichu_en = ""
            obj.nv_Ghichu_vn = ""
            obj.nv_TennhomDichvu_en = ""
            obj.uId_Cuahang = Session("uId_Cuahang")
            obj.vType = e.NewValues("vType").ToString
            objFC.Update(obj)
            dgvDev.CancelEdit()
            e.Cancel = True
            If cmbCuahang.SelectedIndex = 0 Then
                loadNhomDv(Nothing)
            Else
                loadNhomDv(cmbCuahang.Value.ToString)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub dgvDev_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles dgvDev.RowInserting
        obj = New CM.TNTP_DM_NHOMDICHVUEntity
        objFC = New BO.TNTP_DM_NHOMDICHVUFacade
        Try
            obj.nv_TennhomDichvu_vn = e.NewValues("nv_TennhomDichvu_vn").ToString

            obj.nv_TennhomDichvu_en = ""
            obj.nv_Ghichu_vn = ""
            obj.nv_Ghichu_en = ""
            obj.vType = e.NewValues("vType").ToString
            If cmbCuahang.SelectedIndex <> 0 Then
                obj.uId_Cuahang = cmbCuahang.Value.ToString
            Else
                obj.uId_Cuahang = Session("uId_Cuahang")
            End If
            objFC.Insert(obj)
            If cmbCuahang.SelectedIndex = 0 Then
                loadNhomDv(Nothing)
            Else
                loadNhomDv(cmbCuahang.Value.ToString)
            End If
        Catch ex As Exception

        End Try
        dgvDev.CancelEdit()
        e.Cancel = True
    End Sub

    Protected Sub dgvDev_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles dgvDev.RowDeleting
        Dim uId_nhomdichvu As String = e.Keys(0).ToString
        objDV = New BO.TNTP_DM_DICHVUFacade
        Try
            If objDV.SelectByIDNhomdichvu(uId_nhomdichvu) = False Then
                objFC.DeleteByID(uId_nhomdichvu)
            End If
        Catch ex As Exception
        End Try
        e.Cancel = True
        If cmbCuahang.SelectedIndex = 0 Then
            loadNhomDv(Nothing)
        Else
            loadNhomDv(cmbCuahang.Value.ToString)
        End If
    End Sub
    Public Sub loadCuahang()
        Dim dt As DataTable
        dt = objBoCuahang.SelectAllTable()
        Try
            If dt.Rows.Count > 0 Then
                Dim item As New ListEditItem
                item.Value = ""
                item.Text = "Tất cả"
                cmbCuahang.Items.Add(item)
                For Each row As DataRow In dt.Rows
                    Dim newitem As New ListEditItem
                    newitem.Value = row("uId_Cuahang")
                    newitem.Text = row("nv_Tencuahang_vn")
                    cmbCuahang.Items.Add(newitem)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cmbCuahang_SelectedIndexChanged1(sender As Object, e As EventArgs)
        Try
            If cmbCuahang.SelectedIndex <> 0 Then
                Dim uid As String = cmbCuahang.Value.ToString
                loadNhomDv(cmbCuahang.Value.ToString)
            Else
                loadNhomDv(Nothing)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub dgvDev_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
        If e.Column.FieldName = "vType" Then
            objDV = New BO.TNTP_DM_DICHVUFacade
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            cmb.ValueType = GetType(String)
            Dim item1 As New ListEditItem
            Dim item2 As New ListEditItem
            Dim item3 As New ListEditItem
            Dim item4 As New ListEditItem
            item1.Value = "DICHVU"
            item1.Text = "Dịch vụ"
            item2.Value = "THELE"
            item2.Text = "Thẻ lẻ"
            item3.Value = "THEGOI"
            item3.Text = "Thẻ gói"
            item4.Value = "TAIKHOAN"
            item4.Text = "Thẻ tài khoản"
            cmb.Items.Add(item1)
            cmb.Items.Add(item2)
            cmb.Items.Add(item3)
            cmb.Items.Add(item4)
        End If
    End Sub
End Class