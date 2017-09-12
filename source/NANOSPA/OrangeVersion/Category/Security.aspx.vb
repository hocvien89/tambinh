Imports DevExpress.Web.ASPxGridView
Imports System.Drawing

Public Class Security
    Inherits System.Web.UI.Page
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Private objEnNhanvien As CM.QT_DM_NHANVIENEntity
    Private objFcPhanhe As BO.QT_DM_PHANHEFacade
    Private objEnPhanhe As CM.QT_DM_PHANHEEntity
    Dim objFcChucnang As BO.QT_DM_CHUCNANGFacade
    Private objEnChucnang As CM.QT_DM_CHUCNANGEntity
    Private objFcQuyenhan As BO.QT_PHANQUYENFacade
    Private objEnQuyenhan As CM.QT_PHANQUYENEntity
    Private nano As nano_websv
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ApplyLayout()
            loadNhanvien()
        End If
        loadGrid()
        loaddata()
        loadNhanvien()
    End Sub
#Region "load dữ liệu"
    Private Sub loadNhanvien()
        objEnNhanvien = New CM.QT_DM_NHANVIENEntity
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Try
            dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
            Grid_Nhanvien.DataSource = dt
            Grid_Nhanvien.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    'load thong tin phan quyen cua nhan vien duoc chon tu gridview nhan vien 
    Private Function Loadphanuyen() As DataTable
        Dim uId_Nhanvien As String = hdfuIdNhanvien.Value.ToString
        objFcQuyenhan = New BO.QT_PHANQUYENFacade
        Dim dtpq As New DataTable
        If uId_Nhanvien <> "" Then
            dtpq = objFcQuyenhan.SelectByuId_Nhanvien(uId_Nhanvien)
            If dtpq.Rows.Count = 0 Then
                dtpq.Rows.Add(dtpq.NewRow)
            End If
        End If
        Return dtpq
    End Function

    Private Sub loadGrid()
        Dim dt As DataTable = Loadphanuyen()
        If hdfuIdNhanvien.Value <> "" Then
            Grid_Chucnang_Nhanvien.DataSource = dt
            Grid_Chucnang_Nhanvien.DataBind()
        End If
    End Sub

    Private Sub loaddata()
        objFcChucnang = New BO.QT_DM_CHUCNANGFacade
        Dim dt As DataTable
        Dim dtpq As DataTable = Loadphanuyen()
        Try
            If hdfuIdNhanvien.Value <> "" Then
                dt = objFcChucnang.Selectquyenhan()
                If dt.Rows.Count > 0 Then
                    If dtpq.Rows.Count > 0 Then
                        Dim col As New DataColumn
                        col.ColumnName = "Check_Active"
                        col.DataType = GetType(Boolean)
                        col.DefaultValue = False
                        dt.Columns.Add(col)
                        For Each row As DataRow In dt.Rows
                            For Each row2 As DataRow In dtpq.Rows
                                If row("uId_Chucnang").ToString = row2("uId_Chucnang").ToString Then
                                    row("Check_Active") = True
                                End If
                            Next
                        Next
                    End If
                End If
                Grid_Chucnang.DataSource = dt
                Grid_Chucnang.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Grid"
    'group chuc nang
    Private Sub ApplyLayout()
        Grid_Chucnang.BeginUpdate()
        Try
            Grid_Chucnang.ClearSort()
            Grid_Chucnang.GroupBy(Grid_Chucnang.Columns("nv_Tenphanhe_vn"))
        Finally
            Grid_Chucnang.EndUpdate()
        End Try
        Grid_Chucnang.CollapseAll()
    End Sub
#End Region

    Protected Sub Grid_Chucnang_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs)
        If e.RowType = GridViewRowType.Data Then
            Dim StyleRow As Boolean = e.GetValue("Check_Active")
            If StyleRow = True Then
                e.Row.ForeColor = System.Drawing.Color.Red
            End If
        End If
    End Sub
End Class