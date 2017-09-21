<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ajaxDefault.aspx.vb" Inherits="NANO_SPA.ajaxDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-8" style="float: left; width: 73%">
        <div class="home_box_top">
            <div class="home_box home_box_1">
                <div class="home_box_row">
                    <div class="home_box_row_left">
                        <i class="fa fa-group fa-fw fa-3x"></i>
                    </div>
                    <div class="home_box_row_right">
                        <span class="box_text_header">TỔNG SỐ BỆNH NHÂN</span>
                        <asp:Literal ID="ltrSumCus" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="home_box home_box_2">
                <div class="home_box_row">
                    <div class="home_box_row_left">
                        <i class="fa fa-usd fa-fw fa-3x"></i>
                    </div>
                    <div class="home_box_row_right">
                        <span class="box_text_header">DOANH THU TRONG NGÀY</span>
                        <h2 style="font-size:28px;">
                            <asp:Literal ID="ltrDoanhthu" runat="server"></asp:Literal></h2>
                    </div>
                </div>
            </div>
            <div class="clearboth_ipad"></div>
            <div class="home_box home_box_3">
                <div class="home_box_row">
                    <div class="home_box_row_left">
                        <i class="fa fa-clock-o fa-fw fa-3x"></i>
                    </div>
                    <div class="home_box_row_right">
                        <span class="box_text_header">LỊCH HẸN TRONG NGÀY</span>
                        <div class="clearboth_ipad"></div>
                        <asp:LinkButton Style="font-size: 45px; position: relative; color: White; top: 10px"
                            runat="server" ID="lbtLichhen" PostBackUrl="../../../OrangeVersion/Scheduling/MyScheduling.aspx" OnClick="lbtLichhen_Click" Text="0"></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="home_box home_box_4">
                <div class="home_box_row">
                    <div class="home_box_row_left">
                        <i class="fa fa-birthday-cake fa-fw fa-3x"></i>
                    </div>
                    <div class="home_box_row_right">
                        <span class="box_text_header">SINH NHẬT BỆNH NHÂN</span><div class="clearboth_ipad"></div> <span style="font-size: 18px;
                            position: relative; top: 8px"><i class="fa fa-angle-double-right"></i>Trong ngày:
                            <asp:LinkButton OnClick="lbtnViewDate_Click" PostBackUrl="../../../OrangeVersion/Customer/CustomerBirthday.aspx" Style="font-size: 18px; position: relative; color: White" runat="server"
                                ID="lbtnViewDate" Text="0"></asp:LinkButton>
                        </span><div class="clearboth_ipad"></div> <span style="font-size: 18px; position: relative; top: 18px"><i class="fa fa-angle-double-right">
                        </i>Trong tháng:
                            <asp:LinkButton OnClick="lbtnViewMont_Click" PostBackUrl="../../../OrangeVersion/Customer/CustomerBirthday.aspx" Style="font-size: 18px; position: relative; color: White" runat="server"
                                ID="lbtnViewMont" Text="0"></asp:LinkButton></span> <div class="clearboth_ipad"></div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       
        <div id="div_crack" style="padding-bottom:20px;">
        </div>
        <div id="graph">
            Loading...</div>

        <script type="text/javascript">
        var myChart = new JSChart('graph', 'bar');
//        myChart.setDataXML("Control/data.xml");
        myChart.setDataXML("AjaxPage/customer.xml");
        myChart.setTitle('Thống kê khách hàng theo ngày');
        myChart.setLegendShow(false);
        myChart.draw();
        </script>

    </div>
    <div class="col-md-4" style="float: left; width: 22.333%; margin-top: 16px;">
        <div class="panel panel-primary">
            <div class="panel-heading box_text_header">
                Hoạt động giao dịch
            </div>
            <div class="panel-body" style="width: 257px; height: 461px">
                <ul class="chat">
                    <asp:Repeater ID="rptNhatky" runat="server">
                        <ItemTemplate>
                            <li class="left clearfix">
                                <span class="chat-img pull-left" style="width:45px; height:50px;border:dashed thin; text-align:center;border-color:orange">
                                <%--<img src="images/16x16/no_avatar.jpg" alt="User Avatar" style="width: 35px">--%>
                                <img src="<%#Eval("nv_Quequan_en")%>" alt="not avatar" style="width: 35px;height:35px" >
                            </span>
                                &nbsp;&nbsp;<div class="chat-body clearfix" style="padding-left:10px">
                                    <div class="header">
                                        <strong class="primary-font" style="font-size:12px">
                                            <%#Eval("nv_Hoten_vn")%></strong> <small class="pull-right text-muted">
                                                <%#BO.Util.FormatNearTime(Eval("ngaygio"))%></small>
                                    </div>
                                    <p style="font-size:12px; line-height:16px;">
                                        <%#Eval("hanhdong")%>
                                    </p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Panel ID="pnNoItem" runat="server" Visible="false">
                        <li class="left clearfix"><span class="chat-img pull-left">
                            <img src="images/16x16/no_avatar.jpg" alt="User Avatar" style="width: 56px">
                        </span>
                            &nbsp;&nbsp;&nbsp;&nbsp;<div class="chat-body clearfix">
                                <div class="header">
                                    <strong class="primary-font">
                                       Hệ thống</strong>
                                </div>
                                <p>
                                    Chào mừng bạn đến với NANO-SPA 2015
                                </p>
                            </div>
                        </li>
                    </asp:Panel>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
