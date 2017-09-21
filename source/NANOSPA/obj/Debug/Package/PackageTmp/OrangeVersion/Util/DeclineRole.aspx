<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DeclineRole.aspx.vb" Inherits="NANO_SPA.DeclineRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <style type="text/css">
        .content_error p
        {
            color: #666;
            font-family: "Century Gothic";
            font-size: 2em;
            text-align: center;
        }

        .content_error p
        {
            margin: 18px 0 45px;
        }

            .content_error p span
            {
                color: #e54040;
                font-size: 25px;
                font-weight: bold;
            }
    </style>
    <div class="content_error">
        <img style="margin-left:328px" src="../../images/error-img.png" alt="" />
        <p>
            <span>Ohh......BẠN KHÔNG CÓ QUYỀN TRUY CẬP TRANG NÀY</span>
        </p>
    </div>
</asp:Content>
