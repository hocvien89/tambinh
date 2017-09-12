<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Xtra_Product_InBarcode
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
        Me.BarcodeText1 = New DevExpress.XtraReports.UI.CalculatedField()
        Me.BarcodeText2 = New DevExpress.XtraReports.UI.CalculatedField()
        Me.BarcodeText3 = New DevExpress.XtraReports.UI.CalculatedField()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BarcodeText4 = New DevExpress.XtraReports.UI.CalculatedField()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 312.0833!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.BottomMargin.HeightF = 231.25!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BarcodeText1
        '
        Me.BarcodeText1.Name = "BarcodeText1"
        '
        'BarcodeText2
        '
        Me.BarcodeText2.Name = "BarcodeText2"
        '
        'BarcodeText3
        '
        Me.BarcodeText3.Name = "BarcodeText3"
        '
        'BarcodeText4
        '
        Me.BarcodeText4.Name = "BarcodeText4"
        '
        'Xtra_Product_InBarcode
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.BarcodeText1, Me.BarcodeText2, Me.BarcodeText3, Me.BarcodeText4})
        Me.DataSource = Me.BindingSource1
        Me.Margins = New System.Drawing.Printing.Margins(22, 26, 0, 231)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BarcodeText1 As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents BarcodeText2 As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents BarcodeText3 As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents BarcodeText4 As DevExpress.XtraReports.UI.CalculatedField
End Class
