<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Xtr_InLichsu_TheTT
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txt_cuahang = New DevExpress.XtraReports.UI.XRLabel()
        Me.txt_Ngay = New DevExpress.XtraReports.UI.XRLabel()
        Me.txt_Nhanvienlap = New DevExpress.XtraReports.UI.XRLabel()
        Me.txt_nhanvien = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txt_Ngaylap = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txt_khachhang = New DevExpress.XtraReports.UI.XRLabel()
        Me.nv_Hoten_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.uId_Phieu = New DevExpress.XtraReports.UI.CalculatedField()
        Me.f_Sotien = New DevExpress.XtraReports.UI.CalculatedField()
        Me.d_Ngay = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nv_Tenthe_vn = New DevExpress.XtraReports.UI.CalculatedField()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'TopMargin
        '
        Me.TopMargin.HeightF = 6.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txt_Ngaylap, Me.txt_Ngay, Me.txt_cuahang, Me.XrLabel1})
        Me.ReportHeader.HeightF = 109.375!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.PageHeader.HeightF = 25.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txt_khachhang, Me.XrLabel2, Me.txt_nhanvien, Me.txt_Nhanvienlap})
        Me.ReportFooter.HeightF = 136.4583!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel1
        '
        Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Tenthe_vn")})
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(248.9583!, 44.75001!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(320.8334!, 45.25!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txt_cuahang
        '
        Me.txt_cuahang.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cuahang.LocationFloat = New DevExpress.Utils.PointFloat(20.83333!, 10.00001!)
        Me.txt_cuahang.Name = "txt_cuahang"
        Me.txt_cuahang.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txt_cuahang.SizeF = New System.Drawing.SizeF(322.9167!, 23.0!)
        Me.txt_cuahang.StylePriority.UseFont = False
        '
        'txt_Ngay
        '
        Me.txt_Ngay.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Ngay.LocationFloat = New DevExpress.Utils.PointFloat(551.0417!, 10.00001!)
        Me.txt_Ngay.Name = "txt_Ngay"
        Me.txt_Ngay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txt_Ngay.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.txt_Ngay.StylePriority.UseFont = False
        Me.txt_Ngay.StylePriority.UseTextAlignment = False
        Me.txt_Ngay.Text = "Ngày lập"
        Me.txt_Ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txt_Nhanvienlap
        '
        Me.txt_Nhanvienlap.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Nhanvienlap.LocationFloat = New DevExpress.Utils.PointFloat(551.0417!, 10.00001!)
        Me.txt_Nhanvienlap.Name = "txt_Nhanvienlap"
        Me.txt_Nhanvienlap.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txt_Nhanvienlap.SizeF = New System.Drawing.SizeF(113.5417!, 23.0!)
        Me.txt_Nhanvienlap.StylePriority.UseFont = False
        Me.txt_Nhanvienlap.StylePriority.UseTextAlignment = False
        Me.txt_Nhanvienlap.Text = "Nhân viên lập"
        Me.txt_Nhanvienlap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txt_nhanvien
        '
        Me.txt_nhanvien.LocationFloat = New DevExpress.Utils.PointFloat(495.1389!, 92.00004!)
        Me.txt_nhanvien.Name = "txt_nhanvien"
        Me.txt_nhanvien.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txt_nhanvien.SizeF = New System.Drawing.SizeF(237.7083!, 24.04166!)
        Me.txt_nhanvien.StylePriority.UseTextAlignment = False
        Me.txt_nhanvien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(60.41667!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(652.0833!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.StylePriority.UseBorders = False
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Phiếu thanh toán"
        Me.XrTableCell1.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Số tiền"
        Me.XrTableCell2.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.Text = "Ngày thanh toán"
        Me.XrTableCell3.Weight = 1.0R
        '
        'XrTable2
        '
        Me.XrTable2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(60.41673!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(652.0833!, 25.0!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "uId_Phieu")})
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UsePadding = False
        Me.XrTableCell4.Weight = 2.1736109924316409R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "f_Sotien")})
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.XrTableCell5.StylePriority.UsePadding = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell5.Weight = 2.1736109924316409R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "d_Ngay")})
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell6.StylePriority.UseBorders = False
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.Weight = 2.1736105346679691R
        '
        'txt_Ngaylap
        '
        Me.txt_Ngaylap.LocationFloat = New DevExpress.Utils.PointFloat(651.0417!, 10.00001!)
        Me.txt_Ngaylap.Name = "txt_Ngaylap"
        Me.txt_Ngaylap.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txt_Ngaylap.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.txt_Ngaylap.StylePriority.UseTextAlignment = False
        Me.txt_Ngaylap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(108.3333!, 10.00001!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(113.5417!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Khách hàng"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txt_khachhang
        '
        Me.txt_khachhang.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "nv_Hoten_vn")})
        Me.txt_khachhang.LocationFloat = New DevExpress.Utils.PointFloat(41.66679!, 92.00004!)
        Me.txt_khachhang.Name = "txt_khachhang"
        Me.txt_khachhang.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txt_khachhang.SizeF = New System.Drawing.SizeF(237.7083!, 24.04166!)
        Me.txt_khachhang.StylePriority.UseTextAlignment = False
        Me.txt_khachhang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'nv_Hoten_vn
        '
        Me.nv_Hoten_vn.Name = "nv_Hoten_vn"
        '
        'uId_Phieu
        '
        Me.uId_Phieu.Name = "uId_Phieu"
        '
        'f_Sotien
        '
        Me.f_Sotien.Name = "f_Sotien"
        '
        'd_Ngay
        '
        Me.d_Ngay.Name = "d_Ngay"
        '
        'nv_Tenthe_vn
        '
        Me.nv_Tenthe_vn.Name = "nv_Tenthe_vn"
        '
        'Xtr_InLichsu_TheTT
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.nv_Hoten_vn, Me.uId_Phieu, Me.f_Sotien, Me.d_Ngay, Me.nv_Tenthe_vn})
        Me.DataSource = Me.BindingSource1
        Me.Margins = New System.Drawing.Printing.Margins(34, 36, 6, 100)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents txt_Ngaylap As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txt_Ngay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txt_cuahang As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents txt_khachhang As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txt_nhanvien As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txt_Nhanvienlap As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents nv_Hoten_vn As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents uId_Phieu As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents f_Sotien As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents d_Ngay As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents nv_Tenthe_vn As DevExpress.XtraReports.UI.CalculatedField
End Class
