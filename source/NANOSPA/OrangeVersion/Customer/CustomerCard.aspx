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
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CustomerCard.aspx.vb" Inherits="NANO_SPA.CustomerCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <script type="text/javascript">
         //$(document).ready(function () {
         //    var param_dt = "{'uId_Chucnang':'TKH_PageLoad'}";
         //    var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
         //    $.ajax({
         //        type: "POST",
         //        url: pageUrl,
         //        data: param_dt,
         //        contentType: "application/json; charset=utf-8",
         //        dataType: "json",
         //        async: false,
         //        success: function (msg) {
         //            if (msg.d == "false") {
         //                window.location.href = "../../OrangeVersion/Util/DeclineRole.aspx";
         //            }
         //        },
         //        error: onFail
         //    });
         //});
         document.onkeyup = KeyCheck;
         function KeyCheck(e) {
             var KeyID = (window.event) ? event.keyCode : e.keyCode;           
                if (KeyID == 115) {
                    document.getElementById('<%=btOK.ClientID%>').click();

                }
                if (KeyID == 120) {
                    document.getElementById('<%=btnClear.ClientID%>').click();

                }
                if (KeyID == 27) {
                    document.getElementById('<%=btCancel.ClientID%>').click();
                }
            }
           
         function SelChanged(s, e) {
             if (!e.isSelected) {
             } else {
                 client_grid.GetRowValues(e.visibleIndex, 'uId_Thechuyentien', OnGridSelectionComplete);
             }
         }
         //Comment
         var _fieldName = '';
         function grid_FocusedRowChanged(s, e) {
             if (s.cpIsEditing) {
                 s.UpdateEdit();
             }
         }
         function ClearText()
         {
             var txtSotien = document.getElementById("<%=txtsotien.ClientID%>");
             txtSotien.value = "";
             var cbo_Khachhang = document.getElementById("<%=cbo_Khachhang.ClientID%>");
             cbo_Khachhang.SetText("");
      
             var lbl_Thongbao = document.getElementById('<%=lbl_Thongbao.ClientID%>');
             lbl_Thongbao.innerHTML = "";
             
         }
         function grid_EndCallback(s, e) {
             var edit = s.GetEditor(1);
             if (s.cpIsEditing) {
                 var editor = s.GetEditor(_fieldName);
                 if (editor != null) {
                     editor.SelectAll();
                     editor.Focus();
                 }
             }
             if (s.cpShowError) {
                 lberror.SetText(s.cpText);
             }

         }
         function ShowAddWindow()
         {
             pcNapthe.Show();             
            ClearText();
         }
         function ClosePopup(s, e) {
             pcNapthe.Hide();           
             client_grid.Refresh();
             
         }
    </script>
     <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ THẺ KHÁCH HÀNG</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin thẻ của khách hàng</span></legend>
        <ul>                     
            <li class="text_title">
                <dx:ASPxButton ID="btnNaptien" Image-Url="~/images/16x16/add.png" ClientInstanceName="btnNaptien" Height="20px" Style="top: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Nạp tiền">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                </dx:ASPxButton>
            </li>           
        </ul>
                <dx:ASPxGridView ID="Grid_Thongtinthe" Width="100%" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Khachhang" SettingsPager-Position="Bottom"  Style="top: 15px; position: relative" >
        <Columns>
           
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                 HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Thechuyentien"
                Name="uId_Thechuyentien">
            </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                 HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang"
                Name="uId_Khachhang">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                 HeaderStyle-HorizontalAlign="Center" Caption="Mã khách hàng" FieldName="v_Makhachang"
                Name="v_Makhachang" Width="10%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1"  Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" Caption="Tên khách hàng" FieldName="nv_Hoten_vn"
                Name="nv_Hoten_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn  VisibleIndex="2" Caption="Số tiền" CellStyle-ForeColor="Red"  Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="f_Sotien" Name="f_Sotien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
        </Columns>
                    <Templates>
                             <DetailRow>
                                   <div style="padding: 3px 3px 2px 3px">
                                     <dx:ASPxGridView ID="Grid_Lichsu" OnBeforePerformDataSelect="Grid_Lichsu_BeforePerformDataSelect" Width="100%" runat="server" ClientInstanceName="client_grid"
                                        AutoGenerateColumns="false" KeyFieldName="uId_Lichsuchuyentien"
                                        SettingsPager-Position="Bottom" >
                                            <Columns>        
                                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                   HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Lichsuchuyentien"
                                                    Name="uId_Lichsuchuyentien">
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                   HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang"
                                                    Name="uId_Khachhang">
                                                </dx:GridViewDataTextColumn>
                                            
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                     HeaderStyle-HorizontalAlign="Center" Caption="Mã khách hàng" FieldName="v_Makhachang"
                                                    Name="v_Makhachang">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                                                     HeaderStyle-HorizontalAlign="Center" Caption="Ngày chuyển" FieldName="d_Ngaychuyen"
                                                    Name="d_Ngaychuyen">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn  VisibleIndex="2" CellStyle-ForeColor="Red" Caption="Số tiền" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" FieldName="f_Sotien"  Name="f_Sotien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                            
                                                </dx:GridViewDataTextColumn>
                                               <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Lí do" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" FieldName="nv_Lido" Name="nv_Lido">
                                                </dx:GridViewDataTextColumn>
                                                 
                                            </Columns>
              
                                                <SettingsEditing Mode="Inline" />
                                                <SettingsPager PageSize="15" >
                                                </SettingsPager>
                                                <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
     

                                                <Styles>
                                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                    </AlternatingRow>
                                                </Styles>
                                            </dx:ASPxGridView>            
                                                        </div>
                                                    </DetailRow>
                                                </Templates>    
                                        <SettingsEditing Mode="Inline" />
                                        <SettingsPager PageSize="15" >
                                        </SettingsPager>
                                        <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
     
                                        <SettingsDetail ShowDetailRow="true" />
                                        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    </fieldset>
     <div ></div>
    
    <dx:ASPxPopupControl ID="pcNapthe" runat="server" CloseAction="OuterMouseClick" Modal="True" ShowCloseButton="true" ShowMaximizeButton="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcNapthe"
        HeaderText="Nạp tiền vào tài khoản" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcNapthe.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="600px" Height="120px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <asp:UpdatePanel ID="upKhachhang" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Thông tin khách hàng</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Tên khách hàng:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="cbo_Khachhang" ClientInstanceName="cbo_Khachhang" runat="server"  Width="200px" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                                <td class="info_table_td">Số tiền:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtsotien" Width="190px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                              
                                            </tr>
                                           <tr>
                                                <td colspan="5">
                                                    <div id="diverror" class="error">
                                                        <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                        <asp:Literal ID="ltrSuccess" runat="server" ></asp:Literal>
                                                    </div>

                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="3">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btOK" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" OnClick="btOK_Click" runat="server" Text="Lưu (F4)" Style="float: left; margin-right: 8px">
                                                          <ClientSideEvents Click=""/>  
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClearText" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopup" />
                                                        </dx:ASPxButton>                                                      
                                                    </div>
                                                      <div style="width: 300px; float: right; color: green;">
                                                <asp:Label ID="lbl_Thongbao" CssClass="divThongBao" Text="" runat="server" Font-Bold="true"></asp:Label>
                                            </div>

                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </fieldset>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="upKhachhang" DisplayAfter="0" DynamicLayout="false">
                                        <ProgressTemplate>
                                            <img alt="In progress..." src="../../images/progress.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
