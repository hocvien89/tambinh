Imports DevExpress.Web.ASPxGridView

Public Class Unit_Product
    Inherits System.Web.UI.Page
    Private objEnDonvi As CM.DMDonviEntity
    Private objFcDonvi As BO.DMDonviFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        LoadGrid()
    End Sub
#Region "Gridview Event"

    Protected Sub Grid_UnitProduct_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim madonvi As String
        madonvi = e.Keys(0).ToString
        Try
            objFcDonvi.DeleteByID(madonvi)
            Grid_UnitProduct.CancelEdit()
            e.Cancel = True
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_UnitProduct_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnDonvi = New CM.DMDonviEntity
        objFcDonvi = New BO.DMDonviFacade
        Dim ma As String = e.NewValues("madonvi").ToString
        Dim ten As String = e.NewValues("tendonvi").ToString
        Dim ghichu As String = e.NewValues("ghichu")
        Try
            If CheckInsertMa(ma) = 1 Then
                objEnDonvi.madonvi = ma
            Else
                Return
            End If
            objEnDonvi.tendonvi = ten
            objEnDonvi.ghichu = ghichu
            objFcDonvi.Insert(objEnDonvi)
            Grid_UnitProduct.CancelEdit()
            e.Cancel = True
            LoadGrid()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Grid_UnitProduct_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnDonvi = New CM.DMDonviEntity
        objFcDonvi = New BO.DMDonviFacade
        Dim madonvi As String
        madonvi = e.Keys(0).ToString
        Try
            objEnDonvi.madonvi = e.NewValues("madonvi").ToString
            objEnDonvi.tendonvi = e.NewValues("tendonvi").ToString
            objEnDonvi.ghichu = e.NewValues("ghichu")
            objFcDonvi.Update(objEnDonvi)
            Grid_UnitProduct.CancelEdit()
            e.Cancel = True
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub


    'Protected Sub Grid_UnitProduct_RowValidating(sender As Object, e As DevExpress.Web.Data.ASPxDataValidationEventArgs)
    '    For Each column As GridViewColumn In Grid_UnitProduct.Columns
    '        Dim DataColumn As GridViewDataColumn = TryCast(column, GridViewDataColumn)
    '        If DataColumn Is Nothing Then
    '            Continue For
    '        End If
    '        'If e.NewValues(DataColumn.FieldName) Is Nothing Then
    '        '    e.Errors(DataColumn) = "Không thể để trống"
    '        'End If
    '        If e.NewValues("madonvi") Is Nothing Then
    '            AddError(e.Errors, Grid_UnitProduct.Columns("madonvi"), "Mã đơn vị không để trống")
    '        End If
    '        If CheckInsertMa(e.NewValues("madonvi")) = 0 Then
    '            AddError(e.Errors, Grid_UnitProduct.Columns("madonvi"), "Trùng mã đơn vị")
    '        End If
    '        If e.NewValues("tendonvi") Is Nothing Then
    '            AddError(e.Errors, Grid_UnitProduct.Columns("tendonvi"), "Tên đơn vị không để trống")
    '        End If
    '    Next
    'End Sub

    'Protected Sub Grid_UnitProduct_StartRowEditing(sender As Object, e As DevExpress.Web.Data.ASPxStartRowEditingEventArgs)
    '    If Grid_UnitProduct.IsNewRowEditing Then
    '        Grid_UnitProduct.DoRowValidation()
    '    Else

    '    End If
    'End Sub

    Protected Sub Grid_UnitProduct_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs)
        If Grid_UnitProduct.IsNewRowEditing Or Grid_UnitProduct.IsEditing Then
            If TypeOf e.Exception Is NullReferenceException Then
                e.ErrorText = "Không được để trống"
            ElseIf TypeOf e.Exception Is Exception Then
                e.ErrorText = "Kiểm tra lại dữ liệu"
            End If
        End If
    End Sub
#End Region

#Region "load dữ liệu"
    Public Sub LoadGrid()
        objFcDonvi = New BO.DMDonviFacade
        Dim dt As DataTable
        Try
            dt = objFcDonvi.SelectAllTable()
            Grid_UnitProduct.DataSource = dt
            Grid_UnitProduct.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Support"
    Private Function CheckInsertMa(ma As String) As Integer
        objEnDonvi = New CM.DMDonviEntity
        Dim i As Integer = 0
        objEnDonvi = objFcDonvi.SelectByID(ma)
        If objEnDonvi.madonvi <> "" Then
            Return i ' da ton tai ma nay
        Else
            i += 1 'chua co ma nay
            Return i
        End If

    End Function

    Private Sub AddError(errors As Dictionary(Of GridViewColumn, String), column As GridViewColumn, errorText As String)
        If errors.ContainsKey(column) Then
            Return
        End If
        errors(column) = errorText
    End Sub
#End Region

End Class