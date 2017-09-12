Public Class ReportForm_Finance
    Inherits System.Web.UI.Page
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objFCPhieuDV As New BO.TNTP_PHIEUDICHVUFacade
    Private objFCNhatKy As New BO.NHATKYSUDUNGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnKhoaso_Click(sender As Object, e As ImageClickEventArgs)
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If dt.Rows.Count = 0 Then
            ShowMessage(Me, "Bạn không có quyền khóa phiếu!")
        Else
            Try
                objFCPhieuDV.KhoaSoNghiepVu(DateTime.Now)
                ShowMessage(Me, "Khóa sổ đến ngày " & DateTime.Now.Day & "/" & DateTime.Now.Month & "/" & DateTime.Now.Year & " thành công!")
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Khóa sổ đến ngày " & DateTime.Now.Day & "/" & DateTime.Now.Month & "/" & DateTime.Now.Year)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class