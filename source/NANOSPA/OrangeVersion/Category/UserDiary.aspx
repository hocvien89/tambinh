<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="UserDiary.aspx.vb" Inherits="NANO_SPA.UserDiary" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>LỊCH SỬ CÔNG VIỆC</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Key: </li>
            <li class="text_title">
                <dx:ASPxTextBox ID="txt_key" runat="server" Width="100px"></dx:ASPxTextBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset class="field_tt_right>" style="width: 98%; margin: auto; height: auto">
        <legend><span style="font-weight: bold; color: green;">Sự kiện</span></legend>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="IDNhatky" Width="100%">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="IDNhatky"  VisibleIndex="-1" Visible="false"/>
                <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Caption="Người thực hiện" VisibleIndex="0"/>
                <dx:GridViewDataTextColumn FieldName="Tendangnhap" Caption="Tài khoản thực hiện" VisibleIndex="0"/>
                <dx:GridViewDataTextColumn FieldName="hanhdong" Caption="Hành động" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"/>
                <dx:GridViewDataTextColumn FieldName="ngaygio" PropertiesTextEdit-DisplayFormatString="dd/MM/yyy hh:mm" Caption="Ngày thực hiện" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" />
            </Columns>
              <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
            <SettingsPager PageSize="17" Summary-Text="Trang {0}/{1} ({2} Sự kiện)"></SettingsPager>
        </dx:ASPxGridView>

        </fieldset>
</asp:Content>
