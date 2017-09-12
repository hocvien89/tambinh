Imports System.Xml

Partial Public Class ajaxDefault
    Inherits System.Web.UI.Page
    Dim oB_CRM_DM_Khachhang As New BO.CRM_DM_KhachhangFacade
    Private objFCBaocaoKhachhang As New BO.clsB_BaoCao_Khachhang
    Dim objFcAppoint As New BO.AppointmentsFacade
    Dim objFcBaoCaoTC As New BO.clsB_Baocao_Taichinh
    Private objNhatKy As New BO.NHATKYSUDUNGFacade
    Dim iSoKhachhang As Int32 = 0
    Dim iSolichhen_Homnay As Int16 = 0
    Dim iSoKhachhang_Sinhnhat As Int16 = 0
    Dim iSoKhachhang_SN_Thang As Int16 = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DT_Temp As DataTable

        '1. Canh bao
        '-- Dem so lich hen ngay hom nay
        DT_Temp = objFcAppoint.SelectByDate(DateTime.Now, DateTime.Now, Session("uId_Cuahang"), 0, "", "")
        If DT_Temp.Rows.Count > 0 Then
            iSolichhen_Homnay = DT_Temp.Rows.Count
        End If
        lbtLichhen.Text = iSolichhen_Homnay
        '2. Thong ke
        '-- Tong so khach hang
        DT_Temp = oB_CRM_DM_Khachhang.SelectAllTable(Session("uId_Cuahang"))
        If DT_Temp.Rows.Count > 0 Then
            iSoKhachhang = DT_Temp.Rows.Count
            ltrSumCus.Text = "<h2 style='font-size:45px'>" & String.Format("{0:#,###}", iSoKhachhang) & "</h2>"
        End If

        '3. Khac
        '-- Danh sach sinh nhat ngay
        DT_Temp = oB_CRM_DM_Khachhang.SelectAll_DS_Sinhnhat_By_NgayTuanThang(Session("uId_Cuahang"), 1)
        If DT_Temp.Rows.Count > 0 Then
            iSoKhachhang_Sinhnhat = DT_Temp.Rows.Count
            lbtnViewDate.Text = iSoKhachhang_Sinhnhat
        End If

        '-- Danh sach sinh nhat thang
        DT_Temp = oB_CRM_DM_Khachhang.SelectAll_DS_Sinhnhat_By_NgayTuanThang(Session("uId_Cuahang"), 2)
        If DT_Temp.Rows.Count > 0 Then
            iSoKhachhang_SN_Thang = DT_Temp.Rows.Count
            lbtnViewMont.Text = iSoKhachhang_SN_Thang
        End If

        '--Doanh thu cua cua hang
        Dim DoanhThu As Double = CDbl(BO.Util.IsDouble(objFcBaoCaoTC.ThongKeDoanhThuTheoThoiGian(DateTime.Now, DateTime.Now, Session("uId_Cuahang"))))
        ltrDoanhthu.Text = String.Format("{0:N0}", DoanhThu)

        WriteXML()
        LoadNhatKy()
    End Sub
    Private Sub LoadNhatKy()
        Dim dt As DataTable
        dt = objNhatKy.SelectAllTable(DateTime.Now, DateTime.Now, "")
        If dt.Rows.Count > 0 Then
            pnNoItem.Visible = False
            rptNhatky.DataSource = dt
            rptNhatky.DataBind()
        Else
            pnNoItem.Visible = True
        End If
    End Sub
    Private Sub WriteXML()
        Dim doc_option As New XmlDocument()
        doc_option.Load(Server.MapPath("~/AjaxPage/customer.xml"))
        Dim node As XmlNode = doc_option.SelectSingleNode("/JSChart/optionset/option[@set = 'setIntervalEndY']")
        If node IsNot Nothing Then
            node.ParentNode.RemoveChild(node)
            doc_option.Save(Server.MapPath("~/AjaxPage/customer.xml"))
        End If
        Dim d_TuNgay As DateTime
        Dim d_Denngay As DateTime
        Dim doc As XDocument = XDocument.Load(Server.MapPath("~/AjaxPage/customer.xml"))
        doc.Descendants("data").Skip(1).Remove()
        Dim count As String = ""
        For i As Integer = 1 To DateTime.Now.Day
            d_TuNgay = DateAndTime.DateSerial(DateTime.Now.Year, DateTime.Now.Month, i)
            d_Denngay = DateAndTime.DateSerial(DateTime.Now.Year, DateTime.Now.Month, i)
            'Dim dt As DataTable = objFCBaocaoKhachhang.SelectThongkeKH_ByTime(DateTime.Now.Month & "/" & i & "/" & DateTime.Now.Year, DateTime.Now.Month & "/" & i & "/" & DateTime.Now.Year, Session("uId_Cuahang").ToString)
            Dim dt As DataTable = objFCBaocaoKhachhang.SelectThongkeKH_ByTime(d_TuNgay, d_Denngay, Session("uId_Cuahang").ToString)
            count += dt.Rows.Count & ";"
            doc.Descendants("data").Last().AddAfterSelf(New XElement("data", New XAttribute("unit", i), New XAttribute("value", dt.Rows.Count)))
        Next
        Dim arr As Array = count.Split(";")
        Dim imax As Integer = 0
        For x As Integer = 1 To arr.Length - 1
            If arr(x) <> "" Then
                If Integer.Parse(arr(imax)) < Integer.Parse(arr(x)) Then
                    imax = x
                End If
            End If
        Next
        doc.Descendants("option").Last().AddAfterSelf(New XElement("option", New XAttribute("set", "setIntervalEndY"), New XAttribute("value", Integer.Parse(arr(imax)) + 10)))
        doc.Save(Server.MapPath("~/AjaxPage/customer.xml"))
    End Sub

    Protected Sub lbtLichhen_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/OrangeVersion/Scheduling/MyScheduling.aspx")
    End Sub

    Protected Sub lbtnViewDate_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/OrangeVersion/Customer/CustomerBirthday.aspx")
    End Sub

    Protected Sub lbtnViewMont_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/OrangeVersion/Customer/CustomerBirthday.aspx")
    End Sub
End Class