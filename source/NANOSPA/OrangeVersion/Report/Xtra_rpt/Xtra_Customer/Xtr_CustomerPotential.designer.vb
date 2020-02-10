<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Xtr_CustomerPotential
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.v_Makhachhang = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_Hoten_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.d_Ngaysinh = New DevExpress.XtraReports.UI.CalculatedField()
        Me.Gioitinh = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_Diachi_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.v_DienthoaiDD = New DevExpress.XtraReports.UI.CalculatedField()
        Me.d_Ngaynhap = New DevExpress.XtraReports.UI.CalculatedField()
        Me.d_Ngay = New DevExpress.XtraReports.UI.CalculatedField()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl_Denngay = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl_Tungay = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl_Ngaythangnam = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDienthoai = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPKName = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiachi = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox_logo = New DevExpress.XtraReports.UI.XRPictureBox()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(1094.0!, 25.0!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell12, Me.XrTableCell13, Me.XrTableCell14, Me.XrTableCell15, Me.XrTableCell16})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "v_Makhachang")})
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseTextAlignment = False
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrTableCell9.Summary = XrSummary1
        Me.XrTableCell9.Text = "[v_Makhachang]"
        Me.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell9.Weight = 0.17118799820672093R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "v_Makhachhang")})
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "XrTableCell10"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell10.Weight = 0.3757334527521754R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Hoten_vn")})
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100.0!)
        Me.XrTableCell11.StylePriority.UsePadding = False
        Me.XrTableCell11.StylePriority.UseTextAlignment = False
        Me.XrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell11.Weight = 0.67072287005974363R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "d_Ngaysinh", "{0:dd/mm/yyyy}")})
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100.0!)
        Me.XrTableCell12.StylePriority.UsePadding = False
        Me.XrTableCell12.StylePriority.UseTextAlignment = False
        Me.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell12.Weight = 0.29056552542603431R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Gioitinh")})
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseTextAlignment = False
        Me.XrTableCell13.Text = "XrTableCell13"
        Me.XrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell13.Weight = 0.20144645783700738R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Diachi_vn")})
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100.0!)
        Me.XrTableCell14.StylePriority.UsePadding = False
        Me.XrTableCell14.StylePriority.UseTextAlignment = False
        Me.XrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell14.Weight = 0.701604592612515R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "v_DienthoaiDD")})
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.StylePriority.UseBorders = False
        Me.XrTableCell15.Text = "XrTableCell15"
        Me.XrTableCell15.Weight = 0.3144153428195578R
        '
        'XrTableCell16
        '
        Me.XrTableCell16.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "d_Ngaynhap", "{0:dd/mm/yyyy}")})
        Me.XrTableCell16.Name = "XrTableCell16"
        Me.XrTableCell16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100.0!)
        Me.XrTableCell16.StylePriority.UseBorders = False
        Me.XrTableCell16.StylePriority.UsePadding = False
        Me.XrTableCell16.StylePriority.UseTextAlignment = False
        Me.XrTableCell16.Text = "XrTableCell16"
        Me.XrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell16.Weight = 0.27432376028624528R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'v_Makhachhang
        '
        Me.v_Makhachhang.Name = "v_Makhachhang"
        '
        'nv_Hoten_vn
        '
        Me.nv_Hoten_vn.Name = "nv_Hoten_vn"
        '
        'd_Ngaysinh
        '
        Me.d_Ngaysinh.Name = "d_Ngaysinh"
        '
        'Gioitinh
        '
        Me.Gioitinh.Name = "Gioitinh"
        '
        'nv_Diachi_vn
        '
        Me.nv_Diachi_vn.Name = "nv_Diachi_vn"
        '
        'v_DienthoaiDD
        '
        Me.v_DienthoaiDD.Name = "v_DienthoaiDD"
        '
        'd_Ngaynhap
        '
        Me.d_Ngaynhap.Name = "d_Ngaynhap"
        '
        'd_Ngay
        '
        Me.d_Ngay.Name = "d_Ngay"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDienthoai, Me.lblPKName, Me.lblDiachi, Me.XrPictureBox_logo, Me.XrLabel6, Me.lbl_Denngay, Me.lbl_Tungay, Me.XrLabel4, Me.XrLabel1})
        Me.ReportHeader.HeightF = 172.9167!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel6
        '
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(523.7361!, 133.5416!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(65.59671!, 23.0!)
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Đến ngày:"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl_Denngay
        '
        Me.lbl_Denngay.LocationFloat = New DevExpress.Utils.PointFloat(589.3329!, 133.5416!)
        Me.lbl_Denngay.Name = "lbl_Denngay"
        Me.lbl_Denngay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl_Denngay.SizeF = New System.Drawing.SizeF(94.14063!, 23.0!)
        Me.lbl_Denngay.StylePriority.UseTextAlignment = False
        Me.lbl_Denngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lbl_Tungay
        '
        Me.lbl_Tungay.LocationFloat = New DevExpress.Utils.PointFloat(433.1112!, 133.5416!)
        Me.lbl_Tungay.Name = "lbl_Tungay"
        Me.lbl_Tungay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl_Tungay.SizeF = New System.Drawing.SizeF(90.625!, 23.0!)
        Me.lbl_Tungay.StylePriority.UseTextAlignment = False
        Me.lbl_Tungay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(374.7639!, 133.5416!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(58.34708!, 23.0!)
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Từ ngày:"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(339.8483!, 97.66668!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(560.2922!, 35.87502!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "DANH SÁCH KHÁCH HÀNG TIỀM NĂNG"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.PageHeader.HeightF = 25.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1094.0!, 25.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell7})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "STT"
        Me.XrTableCell8.Weight = 0.17118799820672093R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Mã khách hàng"
        Me.XrTableCell1.Weight = 0.3757334527521754R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Họ và tên"
        Me.XrTableCell2.Weight = 0.67072303743220141R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "Ngày sinh"
        Me.XrTableCell3.Weight = 0.29056552451309364R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "Giới tính"
        Me.XrTableCell4.Weight = 0.201446290350432R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = "Địa chỉ"
        Me.XrTableCell5.Weight = 0.70160501207071746R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseBorders = False
        Me.XrTableCell6.Text = "Số điện thoại"
        Me.XrTableCell6.Weight = 0.31441492438841345R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseBorders = False
        Me.XrTableCell7.Text = "Ngày nhập"
        Me.XrTableCell7.Weight = 0.27432376028624528R
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.lbl_Ngaythangnam})
        Me.ReportFooter.HeightF = 162.5!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel3
        '
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(724.7897!, 63.52227!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(154.517!, 22.99999!)
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "CÁN BỘ LẬP BÁO CÁO"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl_Ngaythangnam
        '
        Me.lbl_Ngaythangnam.LocationFloat = New DevExpress.Utils.PointFloat(702.0485!, 25.97774!)
        Me.lbl_Ngaythangnam.Name = "lbl_Ngaythangnam"
        Me.lbl_Ngaythangnam.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl_Ngaythangnam.SizeF = New System.Drawing.SizeF(198.0919!, 22.99999!)
        Me.lbl_Ngaythangnam.StylePriority.UseTextAlignment = False
        Me.lbl_Ngaythangnam.Text = "Ngày.....Tháng.....Năm......"
        Me.lbl_Ngaythangnam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDienthoai
        '
        Me.lblDienthoai.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDienthoai.LocationFloat = New DevExpress.Utils.PointFloat(106.2223!, 73.20169!)
        Me.lblDienthoai.Multiline = True
        Me.lblDienthoai.Name = "lblDienthoai"
        Me.lblDienthoai.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDienthoai.SizeF = New System.Drawing.SizeF(125.2118!, 25.0!)
        Me.lblDienthoai.StylePriority.UseFont = False
        Me.lblDienthoai.Text = "ĐT: 094 511 1556"
        '
        'lblPKName
        '
        Me.lblPKName.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPKName.LocationFloat = New DevExpress.Utils.PointFloat(106.2223!, 23.20169!)
        Me.lblPKName.Name = "lblPKName"
        Me.lblPKName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPKName.SizeF = New System.Drawing.SizeF(280.356!, 25.0!)
        Me.lblPKName.StylePriority.UseFont = False
        Me.lblPKName.StylePriority.UseTextAlignment = False
        Me.lblPKName.Text = "lblPKName"
        Me.lblPKName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblDiachi
        '
        Me.lblDiachi.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiachi.LocationFloat = New DevExpress.Utils.PointFloat(106.2224!, 48.20169!)
        Me.lblDiachi.Name = "lblDiachi"
        Me.lblDiachi.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDiachi.SizeF = New System.Drawing.SizeF(226.3001!, 25.0!)
        Me.lblDiachi.StylePriority.UseFont = False
        Me.lblDiachi.Text = "Số 50 - Ngõ 435 Xuân Đỉnh - Bắc Từ Liêm - Hà Nội"
        '
        'XrPictureBox_logo
        '
        Me.XrPictureBox_logo.LocationFloat = New DevExpress.Utils.PointFloat(13.67168!, 22.32669!)
        Me.XrPictureBox_logo.Name = "XrPictureBox_logo"
        Me.XrPictureBox_logo.SizeF = New System.Drawing.SizeF(92.55074!, 76.18!)
        Me.XrPictureBox_logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'Xtr_CustomerPotential
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.v_Makhachhang, Me.nv_Hoten_vn, Me.d_Ngaysinh, Me.Gioitinh, Me.nv_Diachi_vn, Me.v_DienthoaiDD, Me.d_Ngaynhap, Me.d_Ngay})
        Me.DataSource = Me.BindingSource1
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(39, 36, 0, 0)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents v_Makhachhang As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_Hoten_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents d_Ngaysinh As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents Gioitinh As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_Diachi_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents v_DienthoaiDD As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents d_Ngaynhap As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents d_Ngay As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Public WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents lbl_Denngay As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents lbl_Tungay As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents lbl_Ngaythangnam As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDienthoai As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPKName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiachi As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox_logo As DevExpress.XtraReports.UI.XRPictureBox
End Class
