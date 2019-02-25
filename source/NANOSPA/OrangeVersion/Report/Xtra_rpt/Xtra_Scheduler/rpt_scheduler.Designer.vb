<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rpt_scheduler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rpt_scheduler))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.lblDenngay = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTungay = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNgaylap = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lblNgay = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNhanvien = New DevExpress.XtraReports.UI.XRLabel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Location = New DevExpress.XtraReports.UI.CalculatedField()
        Me.Subject = New DevExpress.XtraReports.UI.CalculatedField()
        Me.Description = New DevExpress.XtraReports.UI.CalculatedField()
        Me.trangthai = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_Hoten_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_HotenNhanvien = New DevExpress.XtraReports.UI.CalculatedField()
        Me.UniqueID = New DevExpress.XtraReports.UI.CalculatedField()
        Me.StartDate = New DevExpress.XtraReports.UI.CalculatedField()
        Me.EndDate = New DevExpress.XtraReports.UI.CalculatedField()
        Me.d_Start_Hour = New DevExpress.XtraReports.UI.CalculatedField()
        Me.d_End_Hour = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_Tendichvu_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.ResourceName = New DevExpress.XtraReports.UI.CalculatedField()
        Me.XrPictureBox_logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.lblSdt = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiachi = New DevExpress.XtraReports.UI.XRRichText()
        Me.lblPKName = New DevExpress.XtraReports.UI.XRRichText()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDiachi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPKName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1109.0!, 25.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UsePadding = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell11, Me.XrTableCell15, Me.XrTableCell12, Me.XrTableCell20, Me.XrTableCell3, Me.XrTableCell13, Me.XrTableCell14})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "UniqueID")})
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrTableCell1.Summary = XrSummary1
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell1.Weight = 0.13661584521746184R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StartDate")})
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "XrTableCell11"
        Me.XrTableCell11.Weight = 0.49967904896263138R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EndDate")})
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Text = "XrTableCell15"
        Me.XrTableCell15.Weight = 0.49549011250922892R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Tendichvu_vn")})
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "XrTableCell12"
        Me.XrTableCell12.Weight = 1.0432953924020554R
        '
        'XrTableCell20
        '
        Me.XrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ResourceName")})
        Me.XrTableCell20.Name = "XrTableCell20"
        Me.XrTableCell20.Text = "XrTableCell20"
        Me.XrTableCell20.Weight = 0.52078779133650954R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "trangthai")})
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "XrTableCell3"
        Me.XrTableCell3.Weight = 0.52078779133650954R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Hoten_vn")})
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Text = "XrTableCell13"
        Me.XrTableCell13.Weight = 0.66487927730856888R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_HotenNhanvien")})
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Text = "XrTableCell14"
        Me.XrTableCell14.Weight = 0.57825026371523769R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 12.54168!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0.1668294!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox_logo, Me.lblSdt, Me.lblDiachi, Me.lblPKName, Me.lblDenngay, Me.XrLabel4, Me.lblTungay, Me.XrLabel2, Me.lblNgaylap, Me.XrLabel1, Me.XrTable2})
        Me.ReportHeader.HeightF = 186.4585!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblDenngay
        '
        Me.lblDenngay.LocationFloat = New DevExpress.Utils.PointFloat(616.5365!, 125.25!)
        Me.lblDenngay.Multiline = True
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDenngay.SizeF = New System.Drawing.SizeF(128.8125!, 23.0!)
        Me.lblDenngay.Text = "lblDenngay"
        '
        'XrLabel4
        '
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(550.9115!, 125.25!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(65.62497!, 23.0!)
        Me.XrLabel4.Text = "Đến ngày:"
        '
        'lblTungay
        '
        Me.lblTungay.LocationFloat = New DevExpress.Utils.PointFloat(458.5158!, 125.25!)
        Me.lblTungay.Multiline = True
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTungay.SizeF = New System.Drawing.SizeF(90.27078!, 23.0!)
        Me.lblTungay.Text = "lblTungay"
        '
        'XrLabel2
        '
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(403.3075!, 125.25!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(55.2083!, 23.0!)
        Me.XrLabel2.Text = "Từ ngày:"
        '
        'lblNgaylap
        '
        Me.lblNgaylap.LocationFloat = New DevExpress.Utils.PointFloat(983.1667!, 0.0!)
        Me.lblNgaylap.Multiline = True
        Me.lblNgaylap.Name = "lblNgaylap"
        Me.lblNgaylap.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNgaylap.SizeF = New System.Drawing.SizeF(145.8333!, 23.0!)
        Me.lblNgaylap.Text = "lblNgaylap" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(273.0992!, 86.625!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(558.9581!, 25.08332!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "BÁO CÁO LỊCH HẸN"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTable2
        '
        Me.XrTable2.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 155.2084!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(1109.0!, 31.25!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell10, Me.XrTableCell16, Me.XrTableCell7, Me.XrTableCell19, Me.XrTableCell8, Me.XrTableCell6, Me.XrTableCell9})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.CanGrow = False
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "TT"
        Me.XrTableCell4.Weight = 0.1328753964830659R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.CanGrow = False
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "Từ ngày"
        Me.XrTableCell10.Weight = 0.48599808245288989R
        '
        'XrTableCell16
        '
        Me.XrTableCell16.CanGrow = False
        Me.XrTableCell16.Name = "XrTableCell16"
        Me.XrTableCell16.Text = "Đến ngày"
        Me.XrTableCell16.Weight = 0.48192386673270171R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.CanGrow = False
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Text = "Dịch vụ"
        Me.XrTableCell7.Weight = 1.0147303892231918R
        '
        'XrTableCell19
        '
        Me.XrTableCell19.CanGrow = False
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.Text = "Phòng"
        Me.XrTableCell19.Weight = 0.506529005311541R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.CanGrow = False
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "Trạng thái"
        Me.XrTableCell8.Weight = 0.506529005311541R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.CanGrow = False
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Text = "Khách hàng"
        Me.XrTableCell6.Weight = 0.64667546623256089R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.CanGrow = False
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "Người hẹn"
        Me.XrTableCell9.Weight = 0.56241771295796961R
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblNgay, Me.XrLabel3, Me.lblNhanvien})
        Me.ReportFooter.HeightF = 110.2499!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblNgay
        '
        Me.lblNgay.LocationFloat = New DevExpress.Utils.PointFloat(891.3959!, 9.916687!)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNgay.SizeF = New System.Drawing.SizeF(201.5624!, 20.91666!)
        Me.lblNgay.StylePriority.UseTextAlignment = False
        Me.lblNgay.Text = "Ngày:.....Tháng.....Năm........."
        Me.lblNgay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(891.3959!, 30.83334!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(201.5624!, 20.91666!)
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Người lập"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNhanvien
        '
        Me.lblNhanvien.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNhanvien.LocationFloat = New DevExpress.Utils.PointFloat(891.3959!, 51.74999!)
        Me.lblNhanvien.Multiline = True
        Me.lblNhanvien.Name = "lblNhanvien"
        Me.lblNhanvien.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNhanvien.SizeF = New System.Drawing.SizeF(201.5624!, 23.0!)
        Me.lblNhanvien.StylePriority.UseFont = False
        Me.lblNhanvien.StylePriority.UseTextAlignment = False
        Me.lblNhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'Location
        '
        Me.Location.Name = "Location"
        '
        'Subject
        '
        Me.Subject.Name = "Subject"
        '
        'Description
        '
        Me.Description.Name = "Description"
        '
        'trangthai
        '
        Me.trangthai.Name = "trangthai"
        '
        'nv_Hoten_vn
        '
        Me.nv_Hoten_vn.Name = "nv_Hoten_vn"
        '
        'nv_HotenNhanvien
        '
        Me.nv_HotenNhanvien.Name = "nv_HotenNhanvien"
        '
        'UniqueID
        '
        Me.UniqueID.Name = "UniqueID"
        '
        'StartDate
        '
        Me.StartDate.Name = "StartDate"
        '
        'EndDate
        '
        Me.EndDate.Name = "EndDate"
        '
        'd_Start_Hour
        '
        Me.d_Start_Hour.Name = "d_Start_Hour"
        '
        'd_End_Hour
        '
        Me.d_End_Hour.Name = "d_End_Hour"
        '
        'nv_Tendichvu_vn
        '
        Me.nv_Tendichvu_vn.Name = "nv_Tendichvu_vn"
        '
        'ResourceName
        '
        Me.ResourceName.Name = "ResourceName"
        '
        'XrPictureBox_logo
        '
        Me.XrPictureBox_logo.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 0.0!)
        Me.XrPictureBox_logo.Name = "XrPictureBox_logo"
        Me.XrPictureBox_logo.SizeF = New System.Drawing.SizeF(76.0!, 76.0!)
        Me.XrPictureBox_logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'lblSdt
        '
        Me.lblSdt.LocationFloat = New DevExpress.Utils.PointFloat(97.98854!, 46.0!)
        Me.lblSdt.Name = "lblSdt"
        Me.lblSdt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSdt.SizeF = New System.Drawing.SizeF(185.4167!, 23.0!)
        Me.lblSdt.Text = "lblSdt"
        '
        'lblDiachi
        '
        Me.lblDiachi.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblDiachi.LocationFloat = New DevExpress.Utils.PointFloat(97.98854!, 22.99995!)
        Me.lblDiachi.Name = "lblDiachi"
        Me.lblDiachi.SerializableRtfString = resources.GetString("lblDiachi.SerializableRtfString")
        Me.lblDiachi.SizeF = New System.Drawing.SizeF(417.0609!, 23.0!)
        '
        'lblPKName
        '
        Me.lblPKName.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblPKName.LocationFloat = New DevExpress.Utils.PointFloat(97.98854!, 0.0!)
        Me.lblPKName.Name = "lblPKName"
        Me.lblPKName.SerializableRtfString = resources.GetString("lblPKName.SerializableRtfString")
        Me.lblPKName.SizeF = New System.Drawing.SizeF(417.0609!, 23.0!)
        '
        'rpt_scheduler
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Location, Me.Subject, Me.Description, Me.trangthai, Me.nv_Hoten_vn, Me.nv_HotenNhanvien, Me.UniqueID, Me.StartDate, Me.EndDate, Me.d_Start_Hour, Me.d_End_Hour, Me.nv_Tendichvu_vn, Me.ResourceName})
        Me.DataSource = Me.BindingSource1
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(17, 23, 13, 0)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDiachi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPKName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNgaylap As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTungay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDenngay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Location As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents Subject As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents Description As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents trangthai As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_Hoten_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_HotenNhanvien As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents UniqueID As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents lblNhanvien As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents StartDate As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents EndDate As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents XrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents d_Start_Hour As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents d_End_Hour As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_Tendichvu_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents ResourceName As DevExpress.XtraReports.UI.CalculatedField
    Public WithEvents lblNgay As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox_logo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblSdt As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiachi As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents lblPKName As DevExpress.XtraReports.UI.XRRichText
End Class
