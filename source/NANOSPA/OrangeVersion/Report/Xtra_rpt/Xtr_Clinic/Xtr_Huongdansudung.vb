Public Class Xtr_Huongdansudung
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents DetailBand1 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand

    Private Sub InitializeComponent()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.DetailBand1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'DetailBand1
        '
        Me.DetailBand1.Name = "DetailBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'Xtr_Huongdansudung
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMarginBand1, Me.DetailBand1, Me.BottomMarginBand1})
        Me.Version = "12.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
End Class