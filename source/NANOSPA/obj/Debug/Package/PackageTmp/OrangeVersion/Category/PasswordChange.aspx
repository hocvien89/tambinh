<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="PasswordChange.aspx.vb" Inherits="NANO_SPA.PasswordChange" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function Check_data() {
            var Newpass = document.getElementById("<%=txt_NewPass.ClientID%>")
            var NewpassreWrite = document.getElementById("<%=txt_NewPassRewrite.ClientID%>")
            var lbl_Thongbao = document.getElementById("<%=lbl_Thongbao.ClientID%>")
            var NewPassre_Err = document.getElementById("<%=NewPassre_Err.ClientID%>")
            lbl_Thongbao.innerHTML = "";
            NewPassre_Err.innerHTML = "";
            if (Newpass.value != NewpassreWrite.value) {
                lbl_Thongbao.innerHTML = "Mật khẩu nhập lại không chính xác";
                NewPassre_Err.innerHTML = "!";
                NewpassreWrite.value = "";
                NewpassreWrite.focus();
                e.processOnServer = false;
            }
        }
        function Enter_OldPass(e) {
            if (e.keyCode == 13) {
                var oldPass = document.getElementById("<%=txt_OldPass.ClientID%>");
                var newpass = document.getElementById("<%=txt_NewPass.ClientID%>");
                var lbl_Thongbao = document.getElementById("<%=lbl_Thongbao.ClientID%>");
                if (oldPass == "") {
                    oldPass.focus();
                    lbl_Thongbao.innerHTML = "Hãy nhập vào mật khẩu cũ";
                }
                else
                    newpass.focus();
                return false;
            }

        }
        function Enter_NewPass(e) {
            if (e.keyCode == 13) {
                var txt_NewPassRewrite = document.getElementById("<%=txt_NewPassRewrite.ClientID%>");
                txt_NewPassRewrite.focus();
                return false;
            }

        }
        function Enter_NewPassReWrite(e) {
            if (e.keyCode == 13) {
                var Newpass = document.getElementById("<%=txt_NewPass.ClientID%>")
                var txt_NewPassRewrite = document.getElementById("<%=txt_NewPassRewrite.ClientID%>");
                var lbl_Thongbao = document.getElementById("<%=lbl_Thongbao.ClientID%>");
                var NewPassre_Err = document.getElementById("<%=NewPassre_Err.ClientID%>")
                var btn_Change = document.getElementById("<%=btn_Change.ClientID%>")
                lbl_Thongbao.innerHTML = "";
                NewPassre_Err.innerHTML = "";
                if (Newpass.value != NewpassreWrite.value) {
                    lbl_Thongbao.innerHTML = "Mật khẩu nhập lại không chính xác";
                    NewPassre_Err.innerHTML = "!";
                    NewpassreWrite.value = "";
                    NewpassreWrite.focus();
                }
                else
                    btn_Change.click();
                return false;
            }

        }
    </script>
     <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THAY ĐỔI MẬT KHẨU</p>
    </div>
    <center>
        <div style="width: 300px; height: 169px; margin: auto; border: 1px solid">
        <table class="info_table">
            <tr>
                <td class="info_table_td" style="font:bold">Tên đăng nhập: </td> 
                <td class="info_table_td">
                    <asp:TextBox ID="txt_UserName" runat="server" ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td class="info_table_td"  style="font:bold">Mật khẩu cũ: </td>
                <td class="info_table_td">
                    <asp:TextBox ID="txt_OldPass" runat="server" onkeypress="return Enter_OldPass(event)" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td class="info_table_td"  style="font:bold">Mật khẩu mới: </td>
                <td class="info_table_td">
                    <asp:TextBox ID="txt_NewPass" runat="server" onkeypress="return Enter_NewPass(event)" TextMode="Password"/>
                </td>
            </tr>
            <tr>
                <td class="info_table_td"  style="font:bold">Nhập lại mật khẩu: </td>
                <td class="info_table_td">
                    <asp:TextBox ID="txt_NewPassRewrite" runat="server" onkeypress="return Enter_NewPassReWrite(event)" TextMode="Password" /><asp:Label ID="NewPassre_Err" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="info_table_td" style="height:16px">
                    <asp:Label ID="lbl_Thongbao" runat="server" CssClass="alert-success"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="pcmButton" style="float:left;padding-left:20px">
        <dx:ASPxButton ID="btn_Change" Image-Url="~/images/btn_Save.png" runat="server" Text="Lưu" AutoPostBack="false" Style="float: left; margin-right: 8px"
            OnClick="btn_Change_Click">
            <ClientSideEvents Click="Check_data" />
        </dx:ASPxButton>
            <dx:ASPxButton ID="btn_Exit" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="false" Style="float: left; margin-right: 8px">
        </dx:ASPxButton>
    </div>
    </div>
    </center> 
</asp:Content>
