Imports DevExpress.Web.ASPxEditors

Public Class ProcessSetup
    Inherits System.Web.UI.Page
    Private objEnQuytrinh As CM.CM_PROCESS_DETAIL
    Private objFcQuytrinh As BO.BO_PROCESS_DETAIL
    Private objFcPhongban As BO.PQP_DM_PHONGBANFacade
    Private objFcRoot As BO.BO_PROCESS_ROOT
    Private objFCRootstep As BO.BO_PROCESS_ROOT_STEP
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadPhongban()
            loadQuytrinh()
            cbo_Phongban.SelectedIndex = 0
            cbo_Quytrinh.SelectedIndex = 0
            loadbuocthuchien()
            chk_All.Checked = True
        End If
        loadQuytrinh()
        loadbuocthuchien()
        cbo_Buoc.SelectedIndex = 0
        LoadgrvQuytrinh()
    End Sub
#Region "Load data"
    Private Sub loadPhongban()
        objFcPhongban = New BO.PQP_DM_PHONGBANFacade
        Dim dt As DataTable
        'cbo_Phongban.Items.Clear()
        dt = objFcPhongban.SelectByIdCuahang(Session("uId_Cuahang"))
        'Dim item As New ListEditItem
        'item.Value = "Tatca"
        'item.Text = "Tất cả"
        'cbo_Phongban.Items.Add(item)
        If dt.Rows.Count > 0 Then
            'For Each row As DataRow In dt.Rows
            '    Dim items As New ListEditItem
            '    items.Value = row("uId_Phong").ToString
            '    items.Text = row("nv_Tenphong_vn").ToString
            '    cbo_Phongban.Items.Add(items)
            'Next
            cbo_Phongban.ValueField = "uId_Phong"
            cbo_Phongban.TextField = "nv_Tenphong_vn"
            cbo_Phongban.DataSource = dt
            cbo_Phongban.DataBind()
        End If
    End Sub

    Private Sub loadQuytrinh()
        objFcRoot = New BO.BO_PROCESS_ROOT
        Dim dt As DataTable
        'cbo_Quytrinh.Items.Clear()
        dt = objFcRoot.SelectAllTable()
        'Dim item As New ListEditItem
        'item.Value = "Tatca"
        'item.Text = "Tất cả"
        'cbo_Quytrinh.Items.Add(item)
        If dt.Rows.Count > 0 Then
            'For Each row As DataRow In dt.Rows
            '    Dim items As New ListEditItem
            '    items.Value = row("Code").ToString
            '    items.Text = row("Process_Name").ToString
            '    cbo_Quytrinh.Items.Add(items)
            'Next
            cbo_Quytrinh.ValueField = "Code"
            cbo_Quytrinh.TextField = "Process_Name"
            cbo_Quytrinh.DataSource = dt
            cbo_Quytrinh.DataBind()
        End If
    End Sub

    Private Sub loadbuocthuchien()
        Dim uId_Quytrinh As String
        'If cbo_Quytrinh.SelectedIndex = 0 Then
        '    uId_Quytrinh = ""
        'Else
        '    uId_Quytrinh = cbo_Quytrinh.Value.ToString
        'End If
        uId_Quytrinh = cbo_Quytrinh.Value.ToString
        loadBuoc(uId_Quytrinh)
    End Sub
    Private Sub loadBuoc(uId_Quytrinh As String)
        objFCRootstep = New BO.BO_PROCESS_ROOT_STEP
        'cbo_Buoc.Items.Clear()
        Dim dt As DataTable
        'If uId_Quytrinh = "Tatca" Then
        '    uId_Quytrinh = ""
        'End If
        dt = objFCRootstep.SelectByRootId(uId_Quytrinh)
        'Dim item As New ListEditItem
        'item.Value = "Tatca"
        'item.Text = "Tất cả"
        'cbo_Buoc.Items.Add(item)
        If dt.Rows.Count > 0 Then
            'For Each row As DataRow In dt.Rows
            '    Dim items As New ListEditItem
            '    items.Value = row("uId_Step").ToString
            '    items.Text = row("StepName").ToString
            '    cbo_Buoc.Items.Add(items)
            'Next
            cbo_Buoc.ValueField = "uId_Step"
            cbo_Buoc.TextField = "Stepname"
            cbo_Buoc.DataSource = dt
            cbo_Buoc.DataBind()
        End If
    End Sub

    Private Sub LoadgrvQuytrinh()

        Dim Code As String
        Dim uId_Phong As String
        Dim uId_Step As String
        'If cbo_Quytrinh.SelectedIndex = 0 Then
        '    Code = ""
        'Else
        '    Code = cbo_Quytrinh.Value
        'End If
        'If cbo_Phongban.SelectedIndex = 0 Then
        '    uId_Phong = ""
        'Else
        '    uId_Phong = cbo_Phongban.Value
        'End If
        'If cbo_Buoc.SelectedIndex = 0 Then
        '    uId_Step = ""
        'Else
        '    uId_Step = cbo_Buoc.Value
        'End If
        Code = cbo_Quytrinh.Value
        uId_Phong = cbo_Phongban.Value
        uId_Step = cbo_Buoc.Value
        If chk_All.Checked = True Then
            GetGrvData("", "", "")
        Else
            GetGrvData(Code, uId_Phong, uId_Step)
        End If
    End Sub

    Private Sub GetGrvData(code As String, uid_phong As String, uid_step As String)
        Dim dt As DataTable
        objFcQuytrinh = New BO.BO_PROCESS_DETAIL
        dt = objFcQuytrinh.SelectByAllId(code, uid_phong, uid_step)
        If dt.Rows.Count > 0 Then
            Grv_Quytrinh.DataSource = dt
        Else
            Grv_Quytrinh.DataSource = Nothing
        End If
        Grv_Quytrinh.DataBind()
    End Sub
#End Region

    Private Sub cbo_Quytrinh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Quytrinh.SelectedIndexChanged
        loadbuocthuchien()
        LoadgrvQuytrinh()
    End Sub

    Private Sub cbo_Buoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Buoc.SelectedIndexChanged
        LoadgrvQuytrinh()
    End Sub

    'Protected Sub cbo_Buoc_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
    '    loadBuoc(e.Parameter)
    'End Sub

    Protected Sub cbo_Buoc_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        loadBuoc(e.Parameter)
    End Sub

    Protected Sub Grv_Quytrinh_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim Id As String
        Id = e.Keys(0).ToString
        objFcQuytrinh = New BO.BO_PROCESS_DETAIL
        objFcQuytrinh.DeleteByID(Id)
        e.Cancel = True
        LoadgrvQuytrinh()
    End Sub
End Class