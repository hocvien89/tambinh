<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Promotion.aspx.vb" Inherits="NANO_SPA.Promotion" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script  type="text/javascript">
        function ShowAddWindow() {
            ClearText();
            pc_Add_Sale.Show();
        }
        function Close_Popup() {
            pc_Add_Sale.Hide();
        }
        function ShowEditWindow() {
            btn_Themmoi.SetText("Sửa");
            pc_Add_Sale.Show();
        }
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                Grid_Promotion.GetRowValues(e.visibleIndex, 'uId_Sale;', OnGridSelectionComplete);
            }
        }
        function OnGridSelectionComplete(values) {
            //Gan gia tri cho hidden field uId khachhang de sua thong tin khach hoac lam gi do
            jo_CreateSession("uId_Sale", values[0]);
            var param_dt = "{'uId_Sale':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/Load_MKT_Sale";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCall,
                error: onFail
            });
            //Create  1 session uId_Dichvu_cd
        }
        function OnSuccessCall(msg) {
            if (msg.d != "Error") {
                var defaultdata = msg.d.split("$");
                txt_Chuongtrinh.SetText(defaultdata[1]);
                txt_percent.SetText(defaultdata[2]);
                txt_Money.SetText(defaultdata[3])
                var d_Start = new Date(defaultdata[4]);
                txt_Start.SetDate(d_Start);
                var d_End = new Date(defaultdata[5]);
                txt_End.SetDate(d_End);
            }
        }
        function ClearText()
        {
            jo_CreateSession("uId_Sale", "");
            btn_Themmoi.SetText("Thêm");
            txt_Chuongtrinh.SetText("");
            txt_percent.SetText("");
            txt_Money.SetText("")
        }
    </script>
      <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ DANH MỤC KHUYẾN MÃI</p>
    </div>
      <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit runat="server" EditFormat="DateTime" AutoPostBack="false" ID="d_Tungay" DisplayFormatString="dd/MM/yyyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày:  </li>
            <li class="text_title">
                <dx:ASPxDateEdit runat="server" EditFormat="DateTime" AutoPostBack="false" ID="d_Denngay" DisplayFormatString="dd/MM/yyyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc" AutoPostBack="false" OnClick="btnFilter_Click">
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnThemmoi" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Thêm mới">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_Promotion" runat="server" KeyFieldName="uId_Sale" Width="100%" OnRowDeleting="Grid_Promotion_RowDeleting"
           ClientInstanceName="Grid_Promotion">
            <Columns>
                <dx:GridViewDataColumn VisibleIndex="1" FieldName="uId_Sale" Visible="false"
                    Name="uId_Sale" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" Width="15%">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Tên chương trình " VisibleIndex="1" FieldName="nv_Tenchuongtrinh_vn" Visible="true"
                    Name="nv_Tenchuongtrinh_vn" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" Width="25%">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                    Caption="Mức giảm giá (%)" FieldName="f_Giamgia_percent" Width="10%" Name="f_Giamgia_percent">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" Caption="Mức tiền giảm giá" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                     FieldName="f_Giamgia_money" Name="f_Giamgia_money" Width="10%" PropertiesTextEdit-DisplayFormatString="{0:0,0}" >
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Visible="true" Caption="Ngày bắt đầu" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                     FieldName="d_Start" Name="d_Start" Width="10%" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Visible="true" Caption="Ngày kết thúc" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                     FieldName="d_End" Name="d_End" Width="10%">
                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" Caption="Sửa">
                    <DataItemTemplate>
                        <a id="popup" title="Sửa thông tin" href='javascript:void(0)' onclick="return ShowEditWindow()">
                            <img src="../../../images/btn_Edit.png" /></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewCommandColumn VisibleIndex="4" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
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
        <ClientSideEvents  SelectionChanged="function(s, e) { SelChanged(s, e); }" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
        </dx:ASPxGridView>
    </fieldset>
      <dx:ASPxPopupControl ID="pc_Add_Sale" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pc_Add_Sale" Font-Size="25px"
        HeaderText="" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="650px" Height="200px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server" Width="650px">
                            <div style="width: 650px; height: 200px">
                                <fieldset class="field_tt" style="width: 640px; height: 180px; margin: auto">
                                    <legend><dx:ASPxLabel runat="server" Text="Thêm mới thông tin" ForeColor="Green" Font-Size="18px"></dx:ASPxLabel></legend>
                                     <table class="info_table">
                                         <tr>
                                             <td class="info_table_td">
                                                 Tên chương trình
                                             </td>
                                             <td class="info_table_td">
                                                 <dx:ASPxTextBox runat="server" ID="txt_Chuongtrinh" ClientInstanceName="txt_Chuongtrinh" AutoPostBack="false" Width="200px"></dx:ASPxTextBox>
                                             </td>
                                             <td class="info_table_td">
                                                 Giảm giá(%):
                                             </td>
                                             <td class="info_table_td">
                                                 <dx:ASPxSpinEdit runat="server" ID="txt_percent" ClientInstanceName="txt_percent" MaxValue="100" MinValue="0" Width="200px"></dx:ASPxSpinEdit>
                                             </td>
                                               
                                         </tr>
                                         <tr>
                                               <td class="info_table_td">Ngày bắt đầu:</td>
                                               <td class="info_table_td">
                                                   <dx:ASPxDateEdit ID="txt_Start" UseMaskBehavior="true" ClientInstanceName="txt_Start" AutoPostBack="false" EditFormat="DateTime" runat="server" DisplayFormatString="dd/MM/yyyy" Width="200px"></dx:ASPxDateEdit>
                                               </td>
                                               <td class="info_table_td">
                                                   Ngày kết thúc:
                                               </td>
                                               <td class="info_table_td">
                                                   <dx:ASPxDateEdit ID="txt_End" UseMaskBehavior="true" ClientInstanceName="txt_End" AutoPostBack="false" EditFormat="DateTime"  runat="server" DisplayFormatString="dd/MM/yyyy" Width="200px"></dx:ASPxDateEdit>
                                               </td>
                                         </tr>
                                         <tr>
                                             <td class="info_table_td">
                                                   Giảm giá tiền :
                                               </td>
                                               <td class="info_table_td">
                                                   <dx:ASPxTextBox   runat="server" ClientInstanceName="txt_Money" ID="txt_Money" Width="200px"></dx:ASPxTextBox>
                                               </td>
                                               
                                               <td  class="info_table_td">
                                                   <dx:ASPxButton runat="server" AutoPostBack="false" ID="btn_Themmoi" ClientInstanceName="btn_Themmoi" Text="Thêm" Image-Url="~/images/16x16/add.png" Width="100px" OnClick="btn_Themmoi_Click"></dx:ASPxButton>
                                               </td>
                                             <td class="info_table_td">
                                                 <dx:ASPxButton runat="server" ID="btn_Thoat" AutoPostBack="false" Image-Url="~/images/16x16/cancel.png" Text="Thoát" Width="100px">
                                                     <ClientSideEvents Click="Close_Popup" />
                                                 </dx:ASPxButton>
                                             </td>
                                         </tr>
                                     </table>
                                </fieldset>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
