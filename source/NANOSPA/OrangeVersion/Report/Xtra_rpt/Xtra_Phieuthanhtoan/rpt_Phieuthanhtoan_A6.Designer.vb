<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rpt_Phieuthanhtoan_A6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rpt_Phieuthanhtoan_A6))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.lblTencuahang = New DevExpress.XtraReports.UI.XRRichText()
        Me.lblDiachicuahang = New DevExpress.XtraReports.UI.XRRichText()
        Me.pic_Logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.lblNhanvien = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTenKH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiachi = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNgaylap = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lbctkm = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblHinhThucTT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbTienthutext = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTienthua = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblKhachtra = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblConlai = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblGiamgia = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTongtien = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.f_Dongia = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Giamgia = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Soluong = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Tongtien = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_Tendichvu_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.nv_Nguon_vn = New DevExpress.XtraReports.UI.CalculatedField()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTencuahang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDiachicuahang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.BorderWidth = 0
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 13.97059!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseBorderWidth = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTable1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.BorderWidth = 1
        Me.XrTable1.Font = New System.Drawing.Font("Times New Roman", 10.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(5.522209!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(288.0!, 13.97059!)
        Me.XrTable1.StylePriority.UseBorderDashStyle = False
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseBorderWidth = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UsePadding = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell8})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.StylePriority.UseBorders = False
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Dongia", "{0:#,##}")})
        Me.XrTableCell1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell1.Weight = 1.0580499312982705R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Soluong", "{0:#,##}")})
        Me.XrTableCell2.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "XrTableCell2"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell2.Weight = 0.366084811328478R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Giamgia", "{0:#,##}")})
        Me.XrTableCell3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,##}"
        Me.XrTableCell3.Summary = XrSummary1
        Me.XrTableCell3.Text = "XrTableCell3"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell3.Weight = 1.032566781559471R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Tongtien", "{0:#,##}")})
        Me.XrTableCell8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseBorders = False
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "XrTableCell8"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell8.Weight = 1.40623214666082R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 4.0!
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
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTencuahang, Me.lblDiachicuahang, Me.pic_Logo, Me.XrLine1, Me.lblNhanvien, Me.XrLabel3, Me.XrLabel6, Me.lblTenKH, Me.lblDiachi, Me.XrLabel10, Me.XrLabel1, Me.lblNgaylap})
        Me.ReportHeader.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.ReportHeader.HeightF = 114.8635!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'lblTencuahang
        '
        Me.lblTencuahang.Font = New System.Drawing.Font("Times New Roman", 10.25!)
        Me.lblTencuahang.LocationFloat = New DevExpress.Utils.PointFloat(57.11514!, 0.0!)
        Me.lblTencuahang.Name = "lblTencuahang"
        Me.lblTencuahang.SerializableRtfString = resources.GetString("lblTencuahang.SerializableRtfString")
        Me.lblTencuahang.SizeF = New System.Drawing.SizeF(230.8848!, 11.19942!)
        Me.lblTencuahang.StylePriority.UseFont = False
        '
        'lblDiachicuahang
        '
        Me.lblDiachicuahang.Font = New System.Drawing.Font("Times New Roman", 10.25!)
        Me.lblDiachicuahang.LocationFloat = New DevExpress.Utils.PointFloat(57.11514!, 11.19942!)
        Me.lblDiachicuahang.Name = "lblDiachicuahang"
        Me.lblDiachicuahang.SerializableRtfString = resources.GetString("lblDiachicuahang.SerializableRtfString")
        Me.lblDiachicuahang.SizeF = New System.Drawing.SizeF(230.8848!, 11.19942!)
        Me.lblDiachicuahang.StylePriority.UseFont = False
        '
        'pic_Logo
        '
        Me.pic_Logo.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 0.0!)
        Me.pic_Logo.Name = "pic_Logo"
        Me.pic_Logo.SizeF = New System.Drawing.SizeF(46.98758!, 34.73874!)
        Me.pic_Logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLine1
        '
        Me.XrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 47.69368!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(258.0!, 2.0!)
        Me.XrLine1.StylePriority.UseBorderDashStyle = False
        '
        'lblNhanvien
        '
        Me.lblNhanvien.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblNhanvien.LocationFloat = New DevExpress.Utils.PointFloat(83.8411!, 101.6667!)
        Me.lblNhanvien.Multiline = True
        Me.lblNhanvien.Name = "lblNhanvien"
        Me.lblNhanvien.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNhanvien.SizeF = New System.Drawing.SizeF(220.9902!, 13.19682!)
        Me.lblNhanvien.StylePriority.UseFont = False
        Me.lblNhanvien.StylePriority.UseTextAlignment = False
        Me.lblNhanvien.Text = "lblNhanvien"
        Me.lblNhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(5.522209!, 101.6667!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(78.3189!, 13.19682!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Người bán:"
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(5.522209!, 68.18918!)
        Me.XrLabel6.Multiline = True
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(77.75516!, 22.3018!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = "Khách hàng:"
        '
        'lblTenKH
        '
        Me.lblTenKH.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblTenKH.LocationFloat = New DevExpress.Utils.PointFloat(83.27737!, 68.18918!)
        Me.lblTenKH.Multiline = True
        Me.lblTenKH.Name = "lblTenKH"
        Me.lblTenKH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTenKH.SizeF = New System.Drawing.SizeF(220.9902!, 22.3018!)
        Me.lblTenKH.StylePriority.UseFont = False
        Me.lblTenKH.Text = "lblTenKH"
        '
        'lblDiachi
        '
        Me.lblDiachi.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblDiachi.LocationFloat = New DevExpress.Utils.PointFloat(84.40488!, 90.49097!)
        Me.lblDiachi.Multiline = True
        Me.lblDiachi.Name = "lblDiachi"
        Me.lblDiachi.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDiachi.SizeF = New System.Drawing.SizeF(220.9902!, 11.1757!)
        Me.lblDiachi.StylePriority.UseFont = False
        Me.lblDiachi.Text = "lblDiachi"
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(5.522209!, 90.49098!)
        Me.XrLabel10.Multiline = True
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(78.88268!, 11.17569!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.Text = "Địa chỉ:"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(57.11513!, 49.69368!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(177.013!, 18.4955!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PHIẾU THANH TOÁN DỊCH VỤ"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNgaylap
        '
        Me.lblNgaylap.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblNgaylap.LocationFloat = New DevExpress.Utils.PointFloat(56.98754!, 23.0!)
        Me.lblNgaylap.Multiline = True
        Me.lblNgaylap.Name = "lblNgaylap"
        Me.lblNgaylap.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNgaylap.SizeF = New System.Drawing.SizeF(166.2371!, 11.73874!)
        Me.lblNgaylap.StylePriority.UseFont = False
        Me.lblNgaylap.Text = "lblNgaylap" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'XrTable2
        '
        Me.XrTable2.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.XrTable2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable2.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(5.522209!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(288.0!, 14.95097!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell7})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.StylePriority.UseBorders = False
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.CanGrow = False
        Me.XrTableCell4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(14, 0, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UsePadding = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "Đơn giá"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell4.Weight = 0.92532735881632755R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.CanGrow = False
        Me.XrTableCell5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.Text = "SL"
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell5.Weight = 0.32016254620121259R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.CanGrow = False
        Me.XrTableCell6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.Text = "Giảm giá"
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell6.Weight = 0.90304071616393766R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell7.CanGrow = False
        Me.XrTableCell7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseBorders = False
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.Text = "Thành tiền"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell7.Weight = 1.2298318641195427R
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lbctkm, Me.XrLabel5, Me.lblHinhThucTT, Me.XrLabel4, Me.lbTienthutext, Me.lblTienthua, Me.XrLabel19, Me.lblKhachtra, Me.lblConlai, Me.XrLabel16, Me.lblGiamgia, Me.XrLabel14, Me.lblTongtien, Me.XrLabel12, Me.XrLabel26})
        Me.ReportFooter.HeightF = 147.0858!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lbctkm
        '
        Me.lbctkm.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lbctkm.LocationFloat = New DevExpress.Utils.PointFloat(90.60417!, 86.4117!)
        Me.lbctkm.Multiline = True
        Me.lbctkm.Name = "lbctkm"
        Me.lbctkm.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbctkm.SizeF = New System.Drawing.SizeF(219.3958!, 10.74509!)
        Me.lbctkm.StylePriority.UseFont = False
        Me.lbctkm.Text = "lblHinhthucTT"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(6.66666!, 85.18623!)
        Me.XrLabel5.Multiline = True
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(83.93751!, 11.97058!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "CTKM:"
        '
        'lblHinhThucTT
        '
        Me.lblHinhThucTT.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblHinhThucTT.LocationFloat = New DevExpress.Utils.PointFloat(90.60412!, 71.82837!)
        Me.lblHinhThucTT.Multiline = True
        Me.lblHinhThucTT.Name = "lblHinhThucTT"
        Me.lblHinhThucTT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHinhThucTT.SizeF = New System.Drawing.SizeF(219.3958!, 10.74509!)
        Me.lblHinhThucTT.StylePriority.UseFont = False
        Me.lblHinhThucTT.Text = "lblHinhthucTT"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(6.666605!, 70.60288!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(83.93751!, 11.97058!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "Hình thức TT:"
        '
        'lbTienthutext
        '
        Me.lbTienthutext.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lbTienthutext.LocationFloat = New DevExpress.Utils.PointFloat(6.666659!, 59.85781!)
        Me.lbTienthutext.Multiline = True
        Me.lbTienthutext.Name = "lbTienthutext"
        Me.lbTienthutext.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbTienthutext.SizeF = New System.Drawing.SizeF(83.93756!, 10.74509!)
        Me.lbTienthutext.StylePriority.UseFont = False
        Me.lbTienthutext.Text = "Còn nợ:"
        '
        'lblTienthua
        '
        Me.lblTienthua.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblTienthua.LocationFloat = New DevExpress.Utils.PointFloat(90.60412!, 59.85789!)
        Me.lblTienthua.Multiline = True
        Me.lblTienthua.Name = "lblTienthua"
        Me.lblTienthua.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTienthua.SizeF = New System.Drawing.SizeF(219.3958!, 10.74509!)
        Me.lblTienthua.StylePriority.UseFont = False
        Me.lblTienthua.Text = "lblTienthua"
        '
        'XrLabel19
        '
        Me.XrLabel19.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(6.666659!, 48.50004!)
        Me.XrLabel19.Multiline = True
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(83.93755!, 11.35785!)
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.Text = "Tiền khách trả:"
        '
        'lblKhachtra
        '
        Me.lblKhachtra.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblKhachtra.LocationFloat = New DevExpress.Utils.PointFloat(90.6042!, 48.49998!)
        Me.lblKhachtra.Multiline = True
        Me.lblKhachtra.Name = "lblKhachtra"
        Me.lblKhachtra.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblKhachtra.SizeF = New System.Drawing.SizeF(219.3957!, 11.35783!)
        Me.lblKhachtra.StylePriority.UseFont = False
        Me.lblKhachtra.Text = "lblKhachtra"
        '
        'lblConlai
        '
        Me.lblConlai.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblConlai.LocationFloat = New DevExpress.Utils.PointFloat(90.6042!, 33.32843!)
        Me.lblConlai.Multiline = True
        Me.lblConlai.Name = "lblConlai"
        Me.lblConlai.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblConlai.SizeF = New System.Drawing.SizeF(219.3957!, 12.58335!)
        Me.lblConlai.StylePriority.UseFont = False
        Me.lblConlai.Text = "lblConlai"
        '
        'XrLabel16
        '
        Me.XrLabel16.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(6.666659!, 33.32848!)
        Me.XrLabel16.Multiline = True
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(83.93756!, 12.58334!)
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.Text = "Khách cần trả:"
        '
        'lblGiamgia
        '
        Me.lblGiamgia.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblGiamgia.LocationFloat = New DevExpress.Utils.PointFloat(90.6042!, 21.97058!)
        Me.lblGiamgia.Multiline = True
        Me.lblGiamgia.Name = "lblGiamgia"
        Me.lblGiamgia.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGiamgia.SizeF = New System.Drawing.SizeF(219.3958!, 11.35784!)
        Me.lblGiamgia.StylePriority.UseFont = False
        Me.lblGiamgia.Text = "lblGiamgia"
        '
        'XrLabel14
        '
        Me.XrLabel14.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(6.666659!, 21.97063!)
        Me.XrLabel14.Multiline = True
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(83.93755!, 11.35785!)
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.Text = "Giảm giá phiếu:"
        '
        'lblTongtien
        '
        Me.lblTongtien.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lblTongtien.LocationFloat = New DevExpress.Utils.PointFloat(90.6042!, 9.999999!)
        Me.lblTongtien.Multiline = True
        Me.lblTongtien.Name = "lblTongtien"
        Me.lblTongtien.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTongtien.SizeF = New System.Drawing.SizeF(219.3958!, 11.97059!)
        Me.lblTongtien.StylePriority.UseFont = False
        Me.lblTongtien.Text = "lblTongtien"
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(6.666659!, 9.999999!)
        Me.XrLabel12.Multiline = True
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(83.93756!, 11.97059!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "Tổng tiền:"
        '
        'XrLabel26
        '
        Me.XrLabel26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(5.522212!, 120.5856!)
        Me.XrLabel26.Multiline = True
        Me.XrLabel26.Name = "XrLabel26"
        Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel26.SizeF = New System.Drawing.SizeF(282.4777!, 16.50028!)
        Me.XrLabel26.StylePriority.UseFont = False
        Me.XrLabel26.StylePriority.UseTextAlignment = False
        Me.XrLabel26.Text = "Xin chân thành cảm ơn. Hẹn gặp lại quý khách!"
        Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'f_Dongia
        '
        Me.f_Dongia.Name = "f_Dongia"
        '
        'f_Giamgia
        '
        Me.f_Giamgia.Name = "f_Giamgia"
        '
        'f_Soluong
        '
        Me.f_Soluong.Name = "f_Soluong"
        '
        'f_Tongtien
        '
        Me.f_Tongtien.Name = "f_Tongtien"
        '
        'nv_Tendichvu_vn
        '
        Me.nv_Tendichvu_vn.Name = "nv_Tendichvu_vn"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("nv_Tendichvu_vn", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.HeightF = 13.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Tendichvu_vn")})
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(5.522208!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(287.9999!, 13.0!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "XrLabel2"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.PageHeader.HeightF = 14.95097!
        Me.PageHeader.Name = "PageHeader"
        '
        'nv_Nguon_vn
        '
        Me.nv_Nguon_vn.Name = "nv_Nguon_vn"
        '
        'rpt_Phieuthanhtoan_A6
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter, Me.GroupHeader1, Me.PageHeader})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.f_Dongia, Me.f_Giamgia, Me.f_Soluong, Me.f_Tongtien, Me.nv_Tendichvu_vn, Me.nv_Nguon_vn})
        Me.DataSource = Me.BindingSource1
        Me.Margins = New System.Drawing.Printing.Margins(2, 0, 4, 0)
        Me.PageHeight = 583
        Me.PageWidth = 332
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTencuahang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDiachicuahang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTenKH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiachi As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents f_Dongia As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Giamgia As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Soluong As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Tongtien As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_Tendichvu_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblTongtien As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblGiamgia As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblConlai As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblKhachtra As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbTienthutext As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTienthua As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNhanvien As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents lblHinhThucTT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents pic_Logo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents nv_Nguon_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents lbctkm As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNgaylap As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTencuahang As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents lblDiachicuahang As DevExpress.XtraReports.UI.XRRichText
End Class
