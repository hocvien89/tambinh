Imports DevExpress.Web.ASPxEditors

Public Class CustomerBirthday
    Inherits System.Web.UI.Page
    Private objFcKhahhang As BO.CRM_DM_KhachhangFacade
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadCuahang()
            LoadTime()
            cbo_Nam.SelectedIndex = 0
            cbo_Ngay.Value = Date.Now.Day
            cbo_Thang.Value = Date.Now.Month
            cbo_Cuahang.SelectedIndex = 0
        End If
        loadGrid()
    End Sub

#Region "load du lieu"
    Private Function Getdata() As DataTable
        Dim dt As New DataTable
        objFcKhahhang = New BO.CRM_DM_KhachhangFacade
        Dim Ngay As Integer = 0
        Dim Thang As Integer = 0
        Dim Nam As Integer = 0
        Dim uId_Cuahang As String
        Dim itype As Integer
        uId_Cuahang = cbo_Cuahang.Value
        Try
            If cbo_Cuahang.SelectedIndex = 0 Then
                uId_Cuahang = ""
            Else
                uId_Cuahang = cbo_Cuahang.Value
            End If
            If cbo_Ngay.SelectedIndex = 0 And cbo_Thang.SelectedIndex = 0 And cbo_Nam.SelectedIndex = 0 Then
                itype = 0
            End If
            If cbo_Ngay.SelectedIndex <> 0 Then
                Ngay = cbo_Ngay.Value
                itype = 1
            End If
            If cbo_Thang.SelectedIndex <> 0 Then
                Thang = cbo_Thang.Value
                itype = 2
            End If
            If cbo_Nam.SelectedIndex <> 0 Then
                Nam = cbo_Nam.Value
                itype = 3
            End If
            If cbo_Ngay.SelectedIndex <> 0 And cbo_Thang.SelectedIndex <> 0 Then
                Ngay = cbo_Ngay.Value
                Thang = cbo_Thang.Value
                itype = 4
            End If
            If cbo_Thang.SelectedIndex <> 0 And cbo_Nam.SelectedIndex <> 0 Then
                Thang = cbo_Thang.Value
                Nam = cbo_Nam.Value
                itype = 5
            End If
            If cbo_Ngay.SelectedIndex <> 0 And cbo_Thang.SelectedIndex <> 0 And cbo_Nam.SelectedIndex <> 0 Then
                Ngay = cbo_Ngay.Value
                Thang = cbo_Thang.Value
                Nam = cbo_Nam.Value
                itype = 6
            End If
            dt = objFcKhahhang.SelectByBirthday(Ngay, Thang, Nam, uId_Cuahang, itype)

        Catch ex As Exception

        End Try
        Return dt
    End Function

    Private Sub LoadCuahang()
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        Try
            dt = objFcCuahang.SelectAllTable()
            Dim item As New ListEditItem
            item.Text = "Tất cả"
            item.Value = "Tatca"
            cbo_Cuahang.Items.Add(item)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim items As New ListEditItem
                    items.Text = row("nv_Tencuahang_vn")
                    items.Value = row("uId_Cuahang")
                    cbo_Cuahang.Items.Add(items)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadTime()
        ' load nam(year)
        For i As Integer = Date.Now.Year - 100 To Date.Now.Year - 18 Step 1
            Dim itemyear As New ListEditItem
            itemyear.Text = i.ToString
            itemyear.Value = i
            cbo_Nam.Items.Add(itemyear)
        Next
        ' load thang (month)
        For i As Integer = 1 To 12 Step 1
            Dim itemmonth As New ListEditItem
            itemmonth.Text = i.ToString
            itemmonth.Value = i
            cbo_Thang.Items.Add(itemmonth)
        Next
        ' load Ngay cua thang (day of month)
        For i As Integer = 1 To 31 Step 1
            Dim itemday As New ListEditItem
            itemday.Text = i.ToString
            itemday.Value = i
            cbo_Ngay.Items.Add(itemday)
        Next
    End Sub

    Private Sub loadGrid()
        Dim dt As DataTable
        dt = Getdata()
        Grid_KH_Sinhnhat.DataSource = dt
        Grid_KH_Sinhnhat.DataBind()
    End Sub
#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadGrid()
    End Sub

    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
End Class