<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MyDataviewControl.ascx.vb" Inherits="NANO_SPA.MyDataviewControl" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<dx:ASPxDataView ID="DavDMGiuong" runat="server">
    <ItemTemplate>
        <div style="width:70px; height:70px">
            <div style="width:70px; height:50px">
            </div>
            <div>
                <div style="width:20px; float:left">
                    <<dx:ASPxLabel ID="lblGuong" runat="server" Text='<%# Eval("nv_TenGiuong_vn")%>'></dx:ASPxLabel>
                </div>
            </div>
        </div>
    </ItemTemplate>
</dx:ASPxDataView>
