<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ErrorPage.aspx.vb" Inherits="NANO_SPA.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <style type="text/css">
        .error_p
        {
            padding: 10px;
            font-family: Tahoma;
            font-size: 12px;
            width: 500px;
            height: 215px;
            background: #eee;
            margin: 88px auto;
            border: 1px solid #ccc;
            border-radius: 5px;
            text-align: center;
        }

            .error_p b
            {
               color: background;
                font-size: 15px;
                font-style: normal;
                position: relative;
                top: 9px;
            }

            .error_p p
            {
                bottom: 4px;
                line-height: 20px;
                position: relative;
            }

                .error_p p a
                {
                    text-decoration: underline;
                    color: #497AD3;
                }

                    .error_p p a:hover
                    {
                        color: #E97D13;
                    }
    </style>
     <div class="brest_crum">
        <p class="p_header">.</p>
    </div>
    <div style="clear: both"></div>
    <div class="error_p">
        <img src="updatting_item.gif" />
        <div>
            <b>THAO TÁC LỖI! VUI LÒNG THỬ LẠI</b>
            <%--<div class="back_home" style="position: relative; left: 145px; top: 28px">
                <span style="float: left">Tự động quay lại <a href="../Default.aspx">trang chủ</a> sau&nbsp</span>
                <form style="float: left; width: 13px" name="counter">
                    <input type="Text" style="border: none; color: Red; font-weight: bold !important; background-color: #EEEEEE; width: 22px" value="0.0" name="d2">
                </form>
                <span style="float: left">giây </span>
            </div>--%>
            </br>
            </br>
            Quay lại <asp:LinkButton runat="server" OnClick="btnJust_Click" Text="trang vừa truy cập" ID="btnJust"></asp:LinkButton> hoặc <a href="../Default.aspx">trang chủ</a>
        </div>
    </div>
    <script>
        //window.setTimeout(function () {
        //    location.href = "../Default.aspx";
        //}, 3000)
    </script>
    <script>
        var milisec = 0
        var seconds = 4
        document.counter.d2.value = '3'

        function display() {
            if (milisec <= 0) {
                milisec = 9
                seconds -= 1
            }
            if (seconds <= -1) {
                milisec = 0
                seconds += 1
            }
            else
                milisec -= 1
            document.counter.d2.value = seconds
            setTimeout("display()", 100)
        }
        display()
    </script>
</asp:Content>
