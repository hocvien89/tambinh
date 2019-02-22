<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginSys.aspx.vb" Inherits="NANO_SPA.LoginSys" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..::NANO-CLINIC 2019 - Đăng nhập::..</title>
    <link rel="shortcut icon" href="/favicon.ico"/>
    <meta name="title" content="Phần mềm quản lý spa, Salon, Thẩm mỹ viện" />
    <meta name="keywords" content="Quan ly spa, Quan ly salon, Quan ly tham my vien" />
    <meta name="description" content="Phần mềm quản lý spa cho phép khách hàng đăng nhập sử dụng miễn phí phần mềm quản lý spa, Salon, Thẩm mỹ viện" />
    <meta name="keywords" content="Phần mềm quản lý spa, Phần mềm quản lý salon, Phần mềm quản lý thẩm mỹ viện" />
    <meta name="keywords" content="Phần mềm thẩm mỹ viện Phần mềm spa, Phần mềm salon" />
    <meta name="keywords" content="Phan mem quan ly spa, Phan mem quan ly salon, Phan mem quan ly tham my vien" />
    <meta name="keywords" content="Phan mem tham my vien, Phan mem spa, Phan mem salon" />
    <meta name="author" content="Nanosoft" />
    <meta name="owner" content="Nanosoft jcs" />
    <meta name="copyright" content="(c) NANO-SPA 2016" />
    <link rel="stylesheet" href="Css/assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="Css/assets/css/style.css"/>
</head>
<body>
    <form id="form1" runat="server" class="login">
        <div class="header">
            <div class="container">
                <div class="row">
                    <img style="float: left; position: relative; top: 2px; width: 74px" src="images/icon_logo/LogoSpa_pts.png" alt="" />
                    <div class="logo">
                        <h1><a href="">NANO-CLINIC 2019 - <span class="red">Perfect solution Great successful</span></a></h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="register-container container">
            <div class="row">
                <div class="register span6">
                    <h2>LOGIN - <span class="red"><strong>PK - TRƯỜNG SINH</strong></span></h2>
                    <label for="UserName">UserName</label>
                    <asp:TextBox ID="txtTendangnhap" CssClass="inputlogin" placeholder="enter your username..." runat="server"></asp:TextBox>
                    <label for="password">Password</label>
                    <asp:TextBox ID="txtMatkhau" TextMode="Password" CssClass="inputlogin" placeholder="enter password" runat="server"></asp:TextBox>
                    <asp:Button ID="cmdDangnhap" CssClass="btnLogin" Text="Login" runat="server" />
                    <div style="clear: both"></div>
                    <asp:Label CssClass="error" runat="server" ID="lblTrangthai"></asp:Label>
                    <p style="font-size: 12px; margin-top: 10px;">Tư vấn hỗ trợ: </p>
                </div>
            </div>
        </div>

        <!-- Javascript -->
        <script src="Css/assets/js/jquery-1.8.2.min.js"></script>
        <script src="Css/assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="Css/assets/js/jquery.backstretch.min.js"></script>
        <script src="Css/assets/js/scripts.js"></script>
        <%--<script type="text/javascript">
            $(document).ready(function () {
                $.backstretch([
                         "Css/assets/img/backgrounds/1.jpg"
                       , "Css/assets/img/backgrounds/2.jpg"
                       , "Css/assets/img/backgrounds/3.jpg"
                       , "Css/assets/img/backgrounds/4.jpg"
                       , "Css/assets/img/backgrounds/5.jpg"
                       , "Css/assets/img/backgrounds/6.jpg"
                ], { duration: 5000, fade: 750 });
            });
         </script>--%>
        <div id="footer">
            <div id="footer_inside">
                <p>
                    <span style="color: #999; text-shadow: 1px 1px #fff;">&copy; 2014 NANOSOFT</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					Design by : <a href="http://nanosoft.vn/" target="_blank" style="color: #000; font-size: 11px; text-shadow: 1px 1px #fff;">Nanosoft Joinstock Company
                    </a>&nbsp;-&nbsp; <a target="_blank" href="http://nanosoft.vn/">http://nanosoft.vn/</a>
                </p>
            </div>
            <script lang="javascript">
                (function () {
                    var _h1 = document.getElementsByTagName('title')[0] || false;
                    var product_name = ''; if (_h1) { product_name = _h1.textContent || _h1.innerText; } var ga = document.createElement('script'); ga.type = 'text/javascript';
                    ga.src = '//live.vnpgroup.net/js/web_client_box.php?hash=8343f1835ee1d76de186c7f40b228cae&data=eyJzc29faWQiOjIyOTM5OTksImhhc2giOiJmNDBiZWU3ZGRiZjQ5MDJjNGRhNTc1Yjc3N2Q1YzI5MyJ9&pname=' + product_name;
                    var s = document.getElementsByTagName('script'); s[0].parentNode.insertBefore(ga, s[0]);
                })();
</script>	
        </div>
    </form>
</body>
</html>
