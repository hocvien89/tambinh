<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ReportForm_Finance.aspx.vb" Inherits="NANO_SPA.ReportForm_Finance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'7E0D6600-502C-479C-8B4B-51E04C32FFBD'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d == "false") {
                        window.location.href = "../../OrangeVersion/Util/DeclineRole.aspx";
                    }
                },
                error: onFail
            });
        });
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>Báo cáo doanh thu</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Báo cáo</span></legend>
        <table class="info_table" style="margin: 0 auto;">
            <tbody>
                <tr>
<%--                     <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Dichvu_Khachhang.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Tài chính Charm Nguyễn Spa</a>
                    </td>--%>
   <%--                 <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Taichinh_Tonghop.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Tài chính tổng hợp</a>
                    </td>--%>
  <%--                  <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/RP_Tonghop_DV.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC Doanh thu tổng hợp</a>
                    </td>--%>
                   <td class="info_table_td_report">
                        <a href="../../OrangeVersion/Report/Rp_web/Rp_Taichinh/Rp_Chitiet_Doanhthu_Tonghop.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo doanh thu khách hàng</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Chitiet_Doanhthu_DV.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC Doanh thu DV chi tiết</a>
                    </td>
                   <%-- <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Tonghop_MH.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC Doanh thu MH tổng hợp</a>
                    </td>--%>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Chitiet_Doanhthu_MH.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC Doanh thu MH chi tiết</a>
                    </td>
                     <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Congno_Khachhang.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC công nợ khách hàng</a>
                    </td>
                </tr>
                <tr>
<%--                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Doanhthu_Nhomphieu.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC Doanh thu theo nhóm phiếu</a>
                    </td>--%>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Thuhoi_Congno.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC thu hồi công nợ</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Phieu_Thuchi.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            BC Thu - chi</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../../OrangeVersion/Report/Rp_web/Rp_Taichinh/Rpt_DoanhthuNVTuvan.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo doanh thu nhân viên tư vấn</a>
                    </td>
                    <td class="info_table_td_report">
                        <%-- <a href="../Report/Rp_web/Rp_Taichinh/Rp_Sonhatky_Chung.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Sổ nhật ký</a>--%>
<%--                        <asp:ImageButton ID="btnKhoaso" OnClick="btnKhoaso_Click" ImageUrl="../../images/orange/reporticon.png" CssClass="img-login" runat="server"></asp:ImageButton></br>
                        Khóa sổ--%>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
</asp:Content>
