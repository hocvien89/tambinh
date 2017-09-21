<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Report_Form_MKT.aspx.vb" Inherits="NANO_SPA.Report_Form_MKT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             var param_dt = "{'uId_Chucnang':'61BA738B-D1E5-4B27-94C6-F2EBB0595164'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>Báo cáo thống kê Marketing</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Báo cáo Marketing</span></legend>
        <table class="info_table" style="margin:0 auto;">
            <tbody>
                <tr>
                    <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Customer/CustomerPotential.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo danh sách KH tiềm năng</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../Customer/TherapyList.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                           Báo cáo liệu trình</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Category/DSKhachHangHuyDV.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo khách hàng hủy dịch vụ</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
</asp:Content>
