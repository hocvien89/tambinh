Imports DevExpress.Web.ASPxEditors

Public Class Room
    Inherits System.Web.UI.Page
    Private objFcPhong As BO.QLP_DM_PHONGFacade
    Private objEnPhong As CM.QLP_DM_PHONGEntity
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
#Region "Load dữ liệu"
    Private Sub loaddata()
        objFcPhong = New BO.QLP_DM_PHONGFacade
        Dim dt As DataTable
        dt = objFcPhong.SelectAllTable(Nothing)
        Try
            Grid_Room.DataSource = dt
            Grid_Room.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Protected Sub Grid_Room_CellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        If e.Column.FieldName = "nv_Tencuahang_vn" Then
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            cmb.DataSource = objFcCuahang.SelectAllTable()
            cmb.ValueField = "uId_Cuahang"
            cmb.ValueType = GetType(String)
            cmb.TextField = "nv_Tencuahang_vn"
            cmb.DataBind()
        End If
    End Sub

    Protected Sub Grid_Room_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhong = New BO.QLP_DM_PHONGFacade
        Dim uId_Phong As String
        uId_Phong = e.Keys(0).ToString
        Try
            objFcPhong.DeleteByID(uId_Phong)
            Grid_Room.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Room_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnPhong = New CM.QLP_DM_PHONGEntity
        objFcPhong = New BO.QLP_DM_PHONGFacade
        Dim uId_Cuahang As String = e.NewValues("nv_Tencuahang_vn").ToString
        Try
            With objEnPhong
                .uId_Cuahang = uId_Cuahang
                .nv_Tenphong_vn = e.NewValues("nv_Tenphong_vn").ToString
                .i_Thutu = e.NewValues("i_Thutu")
                .i_Sokhachtoida = e.NewValues("i_Sokhachtoida")
                .v_Dienthoai = e.NewValues("v_Dienthoai")
                .v_Mauchu = e.NewValues("v_Mauchu")
                .v_Maunen = e.NewValues("v_Maunen")
            End With
            objFcPhong.Insert(objEnPhong)
            Grid_Room.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Room_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnPhong = New CM.QLP_DM_PHONGEntity
        objFcPhong = New BO.QLP_DM_PHONGFacade
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        Dim uid_Cuahang_new As String = e.NewValues("nv_Tencuahang_vn").ToString
        Dim uid_Cuahang_old As String = e.OldValues("nv_Tencuahang_vn").ToString
        dt = objFcCuahang.SelectAllTable()
        Try
            With objEnPhong
                .uId_Phong = e.Keys(0).ToString
                If uid_Cuahang_new <> uid_Cuahang_old Then
                    .uId_Cuahang = uid_Cuahang_new
                Else
                    For Each row As DataRow In dt.Rows
                        If uid_Cuahang_old = row("nv_Tencuahang_vn").ToString Then
                            .uId_Cuahang = row("uId_Cuahang").ToString
                        End If
                    Next
                End If
                .nv_Tenphong_vn = e.NewValues("nv_Tenphong_vn").ToString
                .i_Thutu = e.NewValues("i_Thutu")
                .i_Sokhachtoida = e.NewValues("i_Sokhachtoida")
                .v_Dienthoai = e.NewValues("v_Dienthoai")
                .v_Mauchu = e.NewValues("v_Mauchu")
                .v_Maunen = e.NewValues("v_Maunen")
            End With
            objFcPhong.Update(objEnPhong)
            Grid_Room.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub
End Class