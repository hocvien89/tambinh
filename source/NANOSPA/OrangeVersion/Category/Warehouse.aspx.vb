Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Public Class Warehouse
    Inherits System.Web.UI.Page
    Private objEnKho As CM.QLMH_DM_KHOEntity
    Private objFcKho As BO.QLMH_DM_KHOFacade
    Private objEnCuahang As CM.IQT_DM_CUAHANGEntity
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
        End If
        'objFcCuahang = New BO.QT_DM_CUAHANGFacade
        'Dim gridcolumn As GridViewDataComboBoxColumn = Grid_Warehouse.Columns("nv_Tencuahang_vn")
        'gridcolumn.PropertiesComboBox.DataSource = objFcCuahang.SelectAllTable()
        'gridcolumn.PropertiesComboBox.TextField = "nv_Tencuahang_vn"
        'gridcolumn.PropertiesComboBox.ValueField = "uId_Cuahang"
        'gridcolumn.PropertiesComboBox.ValueType = GetType(String)
        loaddata()
    End Sub
#Region "Load dữ liệu"
    Private Sub loaddata()
        objEnKho = New CM.QLMH_DM_KHOEntity
        objFcKho = New BO.QLMH_DM_KHOFacade
        Dim dt As DataTable
        Try
            dt = objFcKho.SelectAllTable(Nothing)
            Grid_Warehouse.DataSource = dt
            Grid_Warehouse.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Function checkMakho(makho As String) As Boolean
        objFcKho = New BO.QLMH_DM_KHOFacade
        Dim dt As DataTable
        Dim i As Integer = 0
        Try

            dt = objFcKho.SelectAllTable(Nothing)
            For Each row As DataRow In dt.Rows
                If row("v_Makho").ToString = makho Then
                    i += 1
                End If
            Next
        Catch ex As Exception

        End Try
        If i > 0 Then
            Return True 'da ton tai
        Else
            Return False 'chua co trong data
        End If
    End Function
    Private Sub loadcuahang()
        Dim dt As DataTable
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        dt = objFcCuahang.SelectAllTable()

    End Sub
#End Region
#Region "Grid_Kho Event"
    Protected Sub Grid_Warehouse_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_Warehouse.RowDeleting
        Dim uId_Kho As String
        objFcKho = New BO.QLMH_DM_KHOFacade
        uId_Kho = e.Keys(0).ToString
        Try
            objFcKho.DeleteByID(uId_Kho)
            Grid_Warehouse.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Warehouse_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_Warehouse.RowInserting
        objEnKho = New CM.QLMH_DM_KHOEntity
        objFcKho = New BO.QLMH_DM_KHOFacade
        Dim uId_cuahang As String = e.NewValues("nv_Tencuahang_vn").ToString

        Try
            With objEnKho
                .nv_Tenkho_vn = e.NewValues("nv_Tenkho_vn").ToString
                .uId_Cuahang = uId_cuahang
                If checkMakho(e.NewValues("v_Makho")) = True Then
                    Return
                Else
                    .v_Makho = e.NewValues("v_Makho").ToString
                End If
                .nv_Tenkho_en = ""
            End With
            objFcKho.Insert(objEnKho)
            Grid_Warehouse.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Warehouse_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
        If e.Column.FieldName = "nv_Tencuahang_vn" Then
            objFcCuahang = New BO.QT_DM_CUAHANGFacade
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            cmb.DataSource = objFcCuahang.SelectAllTable()
            cmb.ValueField = "uId_Cuahang"
            cmb.ValueType = GetType(String)
            cmb.TextField = "nv_Tencuahang_vn"
            cmb.DataBindItems()
        End If
    End Sub

    Protected Sub Grid_Warehouse_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnKho = New CM.QLMH_DM_KHOEntity
        objFcKho = New BO.QLMH_DM_KHOFacade
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        Dim uId_Kho As String
        Dim uId_Cuahang As String = e.NewValues("nv_Tencuahang_vn").ToString
        Dim ui As String = e.OldValues("nv_Tencuahang_vn").ToString
        dt = objFcCuahang.SelectAllTable()
        If uId_Cuahang <> ui Then
            objEnKho.uId_Cuahang = uId_Cuahang
        Else
            For Each row As DataRow In dt.Rows
                If ui = row("nv_Tencuahang_vn").ToString Then
                    objEnKho.uId_Cuahang = row("uId_Cuahang").ToString
                End If
            Next
        End If
        uId_Kho = e.Keys(0).ToString
        Try
            With objEnKho
                .nv_Tenkho_en = ""
                .nv_Tenkho_vn = e.NewValues("nv_Tenkho_vn").ToString
                .uId_Kho = uId_Kho
                .v_Makho = e.NewValues("v_Makho").ToString
            End With
            objFcKho.Update(objEnKho)
            Grid_Warehouse.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub
#End Region
    
End Class