<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ReportForm_HH.aspx.vb" Inherits="NANO_SPA.ReportForm_HH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'849770b3-8293-4fa4-8218-7bd8a0a8560b'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>Báo cáo hoa hồng</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Báo cáo</span></legend>
        <table class="info_table" style="margin:0 auto;">
            <tbody>
                <tr>
                 <%--   <td class="info_table_td_report">
                        <a href="../Category/PersonelRevenue.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Doanh thu của nhân viên</a>
                    </td>--%>
                    <td class="info_table_td_report">
                        <a href="../../OrangeVersion/Report/Rp_web/Rp_Taichinh/Rpt_DoanhthuNVTuvan.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo doanh thu nhân viên tư vấn</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Baocao_Nhanvien_Kythuat.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo nhân viên kỹ thuật</a>
                    </td>
                   <%-- <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/rpt_HH_Phieudichvu.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo HH bán dịch vụ</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Hoahong_BanSP.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                           Báo cáo HH bán sản phẩm</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Hoahong_Thuchien.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo HH thực hiện</a>
                    </td>--%>
                    <%--<td class="info_table_td_report">
                        <a href="../Report/Rp_web/Rp_Taichinh/Rp_Hoahong_Phieudichvu.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo HH bán phiếu dịch vụ</a>
                    </td>--%>
                </tr>
            </tbody>
        </table>
    </fieldset>
</asp:Content>
