<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="NANO_SPA.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">    
    <title>NANO-SPA 2014 - Đăng nhập</title>
    <link type="text/css" rel="stylesheet" href="Css/CssMain.css" />
    <link rel="shortcut icon" href="/favicon.ico"> 
    <meta name="title" content="Phần mềm quản lý spa, Salon, Thẩm mỹ viện" />
    <meta name="keywords" content="Quan ly spa, Quan ly salon, Quan ly tham my vien" />
    <meta name="description" content="Phần mềm quản lý spa cho phép khách hàng đăng nhập sử dụng miễn phí phần mềm quản lý spa, Salon, Thẩm mỹ viện" />
    <meta name="keywords" content="Phần mềm quản lý spa, Phần mềm quản lý salon, Phần mềm quản lý thẩm mỹ viện" />
    <meta name="keywords" content="Phần mềm thẩm mỹ viện Phần mềm spa, Phần mềm salon" />
    <meta name="keywords" content="Phan mem quan ly spa, Phan mem quan ly salon, Phan mem quan ly tham my vien" />
    <meta name="keywords" content="Phan mem tham my vien, Phan mem spa, Phan mem salon" />    
    <meta name="author" content="Nanosoft" />
    <meta name="owner" content="Nanosoft jcs" />
    <meta name="copyright" content="(c) NANO-SPA 2014" />    
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-49581466-2', 'quanlyspa.net');
  ga('send', 'pageview');

</script>  
      
     
     
     
</head>
<body>
<div class="body-left">
	<ul>
		<li class="head-logo">
		<br /><br />	
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="http://www.quanlyspa.com/" target="_blank" ><img src="../images/NANOSPA_Logo.png"  alt="Phần mềm quản lý spa"/></a>
			 <p class="help">			    
			    <font color="blue">Tư vấn:</font> <font color="red">Mr.Thắng - 0914 633 643</font> 
			 </p>
			 
			<%--<p class="title1">Giá trị đem lại niềm tin</p>
			<p class="title2"><a href="http://www.quanlyspa.net/" target="_blank" > NANO-SPA 1.0</a> : Giải pháp quản lý Spa - Salon của <a href="http://nanosoft.vn/home/" target="_blank" >NANOSOFT</a> </p>--%>
			<br />
			
		</li>
		<li class="head-logo child">
			<img src="../images/help.png" alt="Quản lý spa"/>
			<p class="title3">Chạy trên nền tảng Web, công nghệ điện toán đám mây,<br/> quản lý mọi lúc, mọi nơi. Không cần cài đặt, không tốn phí bảo trì.</p>
		</li>
		<li class="head-logo child">
			<img src="../images/Report_2.png" alt="Quản lý thẩm mỹ viện"/>
			<p class="title4">Tích hợp đồng bộ cơ chế tự động gửi Mail, tin nhắn tới khách hàng<br/> ngay trên giao diện phần mềm.</p>
		</li>
		<li class="head-logo child">
			<img src="../images/web.png"  alt="Quản lý salon"/>
			<p class="title5">Hệ thống hướng dẫn online thông minh trên từng chức năng sản phẩm,<br/> giao diện thân thiện dễ sử dụng.</p>
		</li>
		<li class="head-logo child">
			<a href ="/KH/Login.aspx" target ="_blank" ><img class="img-login" src="../images/LoginCustomer.jpg" alt="Download miễn phí"/></a>
			<p class="title6">Đặc biệt <a href="http://www.quanlyspa.com/" target="_blank" >NANO-SPA</a> có hệ thống đăng nhập độc lập <br/> dành cho khách hàng 
						tích hợp đi kèm(tính năng chỉ có tại <a href="http://www.quanlyspa.com/" target="_blank" >NANO-SPA</a> ).
			</p>
		</li>
		<li class="head-logo child">				
			<p class="title7">NANO-SPA một sản phẩm của <a href="http://www.nanosoft.vn" target="_blank" style="font-size:22px;" >NANOSOFT!</a></p>
		</li>
	</ul>
</div>
<div class="body-right">
<center>    
      <form id="frmDangnhap" runat="server" >
      <div id="Div_Login" >
      
       <asp:Table ID="tblLogin" runat="server" Width="100%" Height="100%">
       
       <asp:TableRow>
       <asp:TableCell RowSpan="3" Width="40%" HorizontalAlign="Left">
        <!--b>NANO-SPA 1.0</b><br /><br />    
      < - Nhanh nhất!<br /><br />
       - Chính xác nhất!<br /><br />
       - Hiệu quả nhất!<br /><br /-->
       
       </asp:TableCell>
       <asp:TableCell >
       <b><p class="lbl-login">Đăng Nhập</p></b> 
	   <a class="title-soft">NANO-SPA 2014</a> 
       </asp:TableCell>
       </asp:TableRow>
       
       <asp:TableRow Height="40px">
            
            <asp:TableCell HorizontalAlign="Left"  Font-Size="12px" Font-Names="Arial">
                  <p class="lbl-user">  Tên đăng nhập</p><br />
                    <asp:TextBox ID="txtTendangnhap" runat="server" Font-Size="X-Large"  Width="200px" MaxLength="50" BackColor="#F3F3F3" ForeColor="#595959"></asp:TextBox>
            </asp:TableCell>            
       </asp:TableRow>
       
       <asp:TableRow Height="30px">            
            <asp:TableCell HorizontalAlign="Left" Font-Size="12px" Font-Names="Arial" >
                   <p class="lbl-pass"> Mật khẩu </p><br />
                    <asp:TextBox ID="txtMatkhau" TextMode="Password" Font-Size="X-Large" Width="200px" MaxLength="50" BackColor="#F3F3F3" ForeColor="#595959" runat="server" ></asp:TextBox>
                          </asp:TableCell>            
       </asp:TableRow>
       
       <asp:TableRow Height="30px">           
            <asp:TableCell HorizontalAlign="Center" ColumnSpan ="2" Width ="100%">
                    <asp:Button ID="cmdDangnhap" Text="Đăng nhập" runat="server"  OnClick="cmdDangnhap_Click"/>
                    <asp:Button ID="cmdThoat" Text="Thoát" runat="server" OnClick="cmdThoat_Click"/>                      
                    <asp:Button ID="cmdDangky" Text="Đăng ký" runat="server" OnClick="cmdDangky_Click"/>                   
             </asp:TableCell>            
       </asp:TableRow>
       
        <asp:TableRow>            
            <asp:TableCell HorizontalAlign="Center"  Font-Size="12px" Font-Names="Arial" ColumnSpan="2">
                   
					<p class="lbl-status">Xin mời đăng nhập hệ thống</p>
                <asp:Label ID="lblTrangthai" runat="server" Text=""></asp:Label>
					<asp:Label ID="lblDate" runat="server"></asp:Label>
             </asp:TableCell>            
       </asp:TableRow>
       
       </asp:Table>     
      </div>  
 </form>
 
 
 </center>
 </div>
</body>

</html>
