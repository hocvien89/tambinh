<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Marketing_Tag.aspx.vb" Inherits="NANO_SPA.Marketing_Tag" %>
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


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             var param_dt = "{'uId_Chucnang':'b77cdcc0-d4df-4910-afad-0ae93911e9de'}";
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
         //Comment
         var _fieldName = '';
         function grid_FocusedRowChanged(s, e) {
             if (s.cpIsEditing) {
                 s.UpdateEdit();
             }
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
         function ClearText()
         {

         }
         function Close(s, e)
         {
             pcTags.Hide();
             Grid_DMTag.Refresh();
         }
         function AddTag()
         {
             pcTags.Show();
             ClearText();
             
         }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH MỤC TAGS</p>
    </div>   
    <fieldset class="field_tt_left" style="width: 49%; height: auto; margin: auto;float:left" >
         <legend><span style="font-weight: bold; color: green">Danh mục loại Tags</span></legend>
        <div style="height:28px">
            <ul >
                <li class="text_title">
                    <dx:ASPxButton Enabled="false" Visible="false" ID="ASPxButton1" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Thêm Tag">
                    </dx:ASPxButton>
                </li>
            </ul>
           
        </div>
        <dx:ASPxGridView ID="Grid_DMLoaiTag" runat="server" KeyFieldName="i_Thutu" Width="100%" >
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="" FieldName="Id_LoaiTag" Name="Id_LoaiTag">
                </dx:GridViewDataTextColumn>     
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1"   Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Mã loại tag" FieldName="i_Thutu" Name="i_Thutu">
                </dx:GridViewDataTextColumn>             
                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Tên loại tag" FieldName="nv_TenLoaiTag_vn" >
                </dx:GridViewDataColumn>
                               
                <dx:GridViewCommandColumn Width="100px" VisibleIndex="4" Caption="Edit" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                    <CancelButton>
                        <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                    </CancelButton>
                    <UpdateButton>
                        <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                    </UpdateButton>
                    <EditButton Visible="true" Image-Url="../../images/btn_Edit.png" Image-AlternateText="Sửa">
                    </EditButton>  
                    <NewButton Visible="true" Image-Url="../../images/btn_add.png" Image-AlternateText="Thêm">
                        <Image AlternateText="New" Url="../../images/btn_add.png"></Image>
                    </NewButton>        
                </dx:GridViewCommandColumn>
                <dx:GridViewCommandColumn VisibleIndex="6" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image Url="~/images/btn_Delete.png"></Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>
            
            <SettingsEditing Mode="Inline" />
            <SettingsPager PageSize="15">
            </SettingsPager>
           
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
   
<fieldset class="field_tt_left" style="width: 48%;float:right" >
     <legend><span style="font-weight: bold; color: green">Danh mục Tags</span></legend>
        <div >

            <ul>
        
               
                <li class="text_title">
                    <dx:ASPxButton ID="btnAdd" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Thêm Tag"> <ClientSideEvents Click="function(s, e) { AddTag(); }" />
                    </dx:ASPxButton>
                </li>
            </ul>
        </div>
        <dx:ASPxGridView ID="Grid_DMTag" runat="server" KeyFieldName="uId_Tags" Width="100%" ClientInstanceName="Grid_DMTag">
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="" FieldName="uId_Tags" Name="uId_Tags">
                </dx:GridViewDataTextColumn>     
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1"   Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Mã loại tag" FieldName="MaLoai" Name="MaLoai">
                </dx:GridViewDataTextColumn>             
                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Tên tag" FieldName="nv_TagName_vn" >
                </dx:GridViewDataColumn>
                               
                <dx:GridViewCommandColumn Width="100px" VisibleIndex="4" Caption="Edit" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                    <CancelButton>
                        <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                    </CancelButton>
                    <UpdateButton>
                        <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                    </UpdateButton>
                    <EditButton Visible="true" Image-Url="../../images/btn_Edit.png" Image-AlternateText="Sửa">
                    </EditButton> 
                    
                </dx:GridViewCommandColumn>
                <dx:GridViewCommandColumn VisibleIndex="6" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image Url="~/images/btn_Delete.png"></Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>
            
            <SettingsEditing Mode="Inline" />
            <SettingsPager PageSize="15">
            </SettingsPager>
           
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
    <dx:ASPxPopupControl ID="pcTags" runat="server" CloseAction="OuterMouseClick" Modal="True" ShowCloseButton="true" ShowMaximizeButton="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcTags"
        HeaderText="Thêm/Sửa Tag" AllowDragging="True" PopupAnimationType="None">
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
                                                <td class="info_table_td">Loại Tag:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="cbo_LoaiTag" runat="server"  Width="200px" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                                <td class="info_table_td">Tên Tag:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtTentag" Width="190px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                              
                                            </tr>
                                          
                                             <tr>
                                                <td colspan="3">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btOK" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" OnClick="btOK_Click" runat="server" Text="Lưu (F4)" Style="float: left; margin-right: 8px">
                                                          <ClientSideEvents Click=""/>  
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="Close" />
                                                        </dx:ASPxButton>                                                      
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