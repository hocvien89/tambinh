<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MyitemTemplate.ascx.vb" Inherits="NANO_SPA.MyitemTemplate" %>
  <div id='<%# Eval("uId_Hinhanh_Congdoan").ToString() +"$"+ Eval("nv_Hinhanh_vn").ToString()%>' onclick="onClick(event)">
                    <table style="margin: 0 auto">
                        <tr>
                            <td>
                                <dx:ASPxImage ID="img_Congdoan" runat="server" ImageUrl='<%# Eval("nv_Hinhanh_vn")%>' ShowLoadingImage="true" Width="60px" Height="80px" ClientInstanceName="img_Congdoan">
                                </dx:ASPxImage>
                            </td>
                        </tr>
                    </table>
                </div>
