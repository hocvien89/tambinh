<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rpt_Phieuthanhtoan_SP_A6
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
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTenKH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNgaylap = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTongtien = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTongtienchu = New DevExpress.XtraReports.UI.XRLabel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.f_Dongia = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Giamgia = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Soluong = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Tongtien = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_TenMathang_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.tendonvi = New DevExpress.XtraReports.UI.CalculatedField()
        Me.lblHoadon = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 13.97059!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTable1.BorderWidth = 1
        Me.XrTable1.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.000005699249!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(190.0!, 13.97059!)
        Me.XrTable1.StylePriority.UseBorderDashStyle = False
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseBorderWidth = False
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.XrTableCell11, Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell10, Me.XrTableCell8})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_TenMathang_vn")})
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,#}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber
        XrSummary1.IgnoreNullValues = True
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrTableCell3.Summary = XrSummary1
        Me.XrTableCell3.Text = "XrTableCell3"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell3.Weight = 0.15789462554403719R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_TenMathang_vn")})
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseBorders = False
        Me.XrTableCell11.StylePriority.UseTextAlignment = False
        Me.XrTableCell11.Text = "XrTableCell11"
        Me.XrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell11.Weight = 0.868421061797635R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "tendonvi", "{0:#,##}")})
        Me.XrTableCell1.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseBorders = False
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell1.Weight = 0.31578946190029178R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Soluong", "{0:#,##}")})
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseBorders = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "XrTableCell2"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell2.Weight = 0.43258417005779021R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Dongia", "{0:#,##}")})
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseBorders = False
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "XrTableCell10"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell10.Weight = 0.50278701193130826R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Tongtien", "{0:#,##}")})
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseBorders = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "XrTableCell8"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell8.Weight = 0.72252366876893759R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 5.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 5.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblHoadon, Me.XrLabel6, Me.XrLabel1, Me.lblTenKH, Me.lblNgaylap})
        Me.ReportHeader.HeightF = 62.21061!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 49.90874!)
        Me.XrLabel6.Multiline = True
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(24.14281!, 12.30182!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = "BN:"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(24.1428!, 19.67456!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(155.8572!, 18.4955!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PHIẾU THU"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTenKH
        '
        Me.lblTenKH.Font = New System.Drawing.Font("Times New Roman", 6.0!, System.Drawing.FontStyle.Bold)
        Me.lblTenKH.LocationFloat = New DevExpress.Utils.PointFloat(24.1428!, 49.90879!)
        Me.lblTenKH.Multiline = True
        Me.lblTenKH.Name = "lblTenKH"
        Me.lblTenKH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTenKH.SizeF = New System.Drawing.SizeF(88.2542!, 12.30181!)
        Me.lblTenKH.StylePriority.UseFont = False
        Me.lblTenKH.Text = "lblTenKH"
        '
        'lblNgaylap
        '
        Me.lblNgaylap.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.lblNgaylap.LocationFloat = New DevExpress.Utils.PointFloat(112.397!, 50.47186!)
        Me.lblNgaylap.Multiline = True
        Me.lblNgaylap.Name = "lblNgaylap"
        Me.lblNgaylap.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNgaylap.SizeF = New System.Drawing.SizeF(73.49562!, 11.73874!)
        Me.lblNgaylap.StylePriority.UseFont = False
        Me.lblNgaylap.Text = "lblNgaylap" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel12, Me.lblTongtien, Me.lblTongtienchu})
        Me.ReportFooter.HeightF = 82.07172!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(86.92068!, 10.0!)
        Me.XrLabel12.Multiline = True
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(68.60421!, 11.97059!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Tổng cộng:"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'lblTongtien
        '
        Me.lblTongtien.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.lblTongtien.LocationFloat = New DevExpress.Utils.PointFloat(155.5249!, 10.00002!)
        Me.lblTongtien.Multiline = True
        Me.lblTongtien.Name = "lblTongtien"
        Me.lblTongtien.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTongtien.SizeF = New System.Drawing.SizeF(34.47511!, 11.97059!)
        Me.lblTongtien.StylePriority.UseFont = False
        Me.lblTongtien.StylePriority.UseTextAlignment = False
        Me.lblTongtien.Text = "lblTongtien"
        Me.lblTongtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'lblTongtienchu
        '
        Me.lblTongtienchu.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.lblTongtienchu.LocationFloat = New DevExpress.Utils.PointFloat(0.000006622738!, 21.97064!)
        Me.lblTongtienchu.Multiline = True
        Me.lblTongtienchu.Name = "lblTongtienchu"
        Me.lblTongtienchu.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTongtienchu.SizeF = New System.Drawing.SizeF(190.0!, 28.28493!)
        Me.lblTongtienchu.StylePriority.UseFont = False
        Me.lblTongtienchu.Text = "Tổng tiền bằng chữ: "
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
        'nv_TenMathang_vn
        '
        Me.nv_TenMathang_vn.Name = "nv_TenMathang_vn"
        '
        'tendonvi
        '
        Me.tendonvi.Name = "tendonvi"
        '
        'lblHoadon
        '
        Me.lblHoadon.Font = New System.Drawing.Font("Times New Roman", 6.0!)
        Me.lblHoadon.LocationFloat = New DevExpress.Utils.PointFloat(65.0!, 38.17006!)
        Me.lblHoadon.Multiline = True
        Me.lblHoadon.Name = "lblHoadon"
        Me.lblHoadon.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHoadon.SizeF = New System.Drawing.SizeF(73.49562!, 11.73874!)
        Me.lblHoadon.StylePriority.UseFont = False
        Me.lblHoadon.StylePriority.UseTextAlignment = False
        Me.lblHoadon.Text = "lblNgaylap" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblHoadon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'rpt_Phieuthanhtoan_SP_A6
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.f_Dongia, Me.f_Giamgia, Me.f_Soluong, Me.f_Tongtien, Me.nv_TenMathang_vn, Me.tendonvi})
        Me.DataSource = Me.BindingSource1
        Me.Margins = New System.Drawing.Printing.Margins(5, 5, 5, 5)
        Me.PageHeight = 583
        Me.PageWidth = 200
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents lblNgaylap As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTenKH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTongtien As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTongtienchu As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents f_Dongia As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Giamgia As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Soluong As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Tongtien As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_TenMathang_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents tendonvi As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblHoadon As DevExpress.XtraReports.UI.XRLabel
End Class
