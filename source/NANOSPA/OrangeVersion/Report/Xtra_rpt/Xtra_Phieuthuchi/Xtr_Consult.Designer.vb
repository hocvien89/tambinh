<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Xtr_Consult
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbSDT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbDiachi = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtHoten = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.lbl_Diachi = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSpaName = New DevExpress.XtraReports.UI.XRLabel()
        Me.lb_sdt = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.lbSDT, Me.lbDiachi, Me.txtHoten, Me.XrTable1})
        Me.Detail.HeightF = 434.375!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(10.00002!, 395.8333!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(1099.0!, 38.54169!)
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Italic)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "Hàng dễ vỡ, vui lòng nhẹ tay !"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell3.Weight = 1.0R
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 340.625!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(262.9166!, 31.75003!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "SĐT                   :"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 278.125!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(262.9166!, 31.75!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Đ/C                    :"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 214.5833!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(262.9166!, 31.75!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NGƯỜI NHẬN :"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lbSDT
        '
        Me.lbSDT.Font = New System.Drawing.Font("Times New Roman", 20.0!)
        Me.lbSDT.LocationFloat = New DevExpress.Utils.PointFloat(492.0832!, 340.625!)
        Me.lbSDT.Name = "lbSDT"
        Me.lbSDT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbSDT.SizeF = New System.Drawing.SizeF(431.0835!, 31.75!)
        Me.lbSDT.StylePriority.UseFont = False
        Me.lbSDT.StylePriority.UseTextAlignment = False
        Me.lbSDT.Text = "sdt"
        Me.lbSDT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lbDiachi
        '
        Me.lbDiachi.Font = New System.Drawing.Font("Times New Roman", 20.0!)
        Me.lbDiachi.LocationFloat = New DevExpress.Utils.PointFloat(492.0832!, 278.125!)
        Me.lbDiachi.Name = "lbDiachi"
        Me.lbDiachi.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbDiachi.SizeF = New System.Drawing.SizeF(431.0835!, 31.75!)
        Me.lbDiachi.StylePriority.UseFont = False
        Me.lbDiachi.StylePriority.UseTextAlignment = False
        Me.lbDiachi.Text = "dc"
        Me.lbDiachi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtHoten
        '
        Me.txtHoten.Font = New System.Drawing.Font("Times New Roman", 20.0!)
        Me.txtHoten.LocationFloat = New DevExpress.Utils.PointFloat(492.0832!, 214.5833!)
        Me.txtHoten.Name = "txtHoten"
        Me.txtHoten.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtHoten.SizeF = New System.Drawing.SizeF(431.0835!, 31.74998!)
        Me.txtHoten.StylePriority.UseFont = False
        Me.txtHoten.StylePriority.UseTextAlignment = False
        Me.txtHoten.Text = "ten"
        Me.txtHoten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(114.5834!, 10.00001!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(881.4999!, 156.25!)
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.StylePriority.UseBorders = False
        Me.XrTableRow1.Weight = 4.3120156221611552R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XrLabel4, Me.lbl_Diachi, Me.lblSpaName, Me.lb_sdt})
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Weight = 1.0R
        '
        'lbl_Diachi
        '
        Me.lbl_Diachi.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lbl_Diachi.Font = New System.Drawing.Font("Times New Roman", 18.0!)
        Me.lbl_Diachi.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 55.58332!)
        Me.lbl_Diachi.Name = "lbl_Diachi"
        Me.lbl_Diachi.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl_Diachi.SizeF = New System.Drawing.SizeF(715.2499!, 29.25!)
        Me.lbl_Diachi.StylePriority.UseBorders = False
        Me.lbl_Diachi.StylePriority.UseFont = False
        Me.lbl_Diachi.StylePriority.UseTextAlignment = False
        Me.lbl_Diachi.Text = "lbl_Diachi"
        Me.lbl_Diachi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblSpaName
        '
        Me.lblSpaName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblSpaName.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblSpaName.LocationFloat = New DevExpress.Utils.PointFloat(21.87499!, 10.00001!)
        Me.lblSpaName.Name = "lblSpaName"
        Me.lblSpaName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSpaName.SizeF = New System.Drawing.SizeF(855.8749!, 34.45834!)
        Me.lblSpaName.StylePriority.UseBorders = False
        Me.lblSpaName.StylePriority.UseFont = False
        Me.lblSpaName.StylePriority.UseTextAlignment = False
        Me.lblSpaName.Text = "lblSpaName"
        Me.lblSpaName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lb_sdt
        '
        Me.lb_sdt.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lb_sdt.Font = New System.Drawing.Font("Times New Roman", 18.0!)
        Me.lb_sdt.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 97.83334!)
        Me.lb_sdt.Name = "lb_sdt"
        Me.lb_sdt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lb_sdt.SizeF = New System.Drawing.SizeF(715.2499!, 31.74999!)
        Me.lb_sdt.StylePriority.UseBorders = False
        Me.lb_sdt.StylePriority.UseFont = False
        Me.lb_sdt.StylePriority.UseTextAlignment = False
        Me.lb_sdt.Text = "lb_sdt"
        Me.lb_sdt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 25.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 25.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(21.87498!, 55.58332!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(137.9166!, 31.74999!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Địa chỉ :"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(21.87498!, 97.83334!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(137.9166!, 31.74999!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "ĐT : "
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'Xtr_Consult
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblSpaName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl_Diachi As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lb_sdt As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtHoten As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbSDT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbDiachi As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
End Class
