<%@ Page Language='vb' MasterPageFile='~/frmMain.Master' AutoEventWireup='false'
    CodeBehind='Default.aspx.vb' Inherits='NANO_SPA._Default' %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID='Content_Default' ContentPlaceHolderID='ContentPlaceHolder_Main'
    runat='Server'>

    <script>
    $(document).ready(function(){
        $('#id_box').html("<div style='width: 100%; position: fixed; z-index: 1001; top: 45px; right:530px' id='loading'><div style='padding: 4px'><table cellspacing='0' cellpadding='6' align='right' style='border: #8AAFE1 1px solid;background-color: #BBD3F2'><tbody><tr><td style='text-align: center'><span style='font-size: 8pt; font-family: Tahoma; color: #0E4380'><b>Đang tải dữ liệu ...</b></span><br><img src='../images/progress.gif' style='border: 0' alt=''></td></tr></tbody></table></div></div>");
        $('#id_box').load('../AjaxPage/ajaxDefault.aspx',function(responseTxt,statusTxt,xhr){
          if(statusTxt=='error')
            alert('Error: '+xhr.status+': '+xhr.statusText);
        });
    });
    </script>
        <div class='row' id='id_box'>
    </div>
   
</asp:Content>
