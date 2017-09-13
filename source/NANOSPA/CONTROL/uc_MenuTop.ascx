<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="uc_MenuTop.ascx.vb" Inherits="NANO_SPA.uc_MenuTop" %>
<ul id="css3menu_top" class="topmenu">
    <li class="topmenu hiddenipad" style="display:none;"><a href="#" style="height: 24px; line-height: 24px;">
        <img src="../../../../../images/orange/or_chrome.png" alt="">MARKETING</a>
        <div class="submenu" style="width: 250px;">
            <div class="column">
                <ul>
                    <li><a href="../../../../OrangeVersion/Marketing/CustomerCare.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Chăm sóc khách hàng</a></li>
                    <li><a href="../../../../OrangeVersion/Marketing/MarketingStatistic.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Thống kê chăm sóc</a></li>
                    <%-- <li><a href="../CTKM/Thietlap_ChuongtrinhKM.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">C.Tr khuyến mại</a></li>
                    <li><a href="../MARKETING/SendMail.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Gửi mail chăm sóc KH</a></li>
                    <li><a href="../MARKETING/SendSMS.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Tin nhắn chăm sóc KH</a></li>--%>
                         <%--       <li><a href="../../../../OrangeVersion/Marketing/AddCTKM.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Chương trình khuyến mãi</a></li>
                    <li><a href="../../../../OrangeVersion/Marketing/AddChiendich.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Chiến dịch maketing</a></li>--%>
                     <li><a href="../../../../OrangeVersion/Marketing/SendSMS.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="" />GỬI SMS</a></li>
                    <li><a href="../../../../OrangeVersion/Marketing/SendEmail.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="" />GỬI Email</a></li>
                    <li><a href="../../../../OrangeVersion/Marketing/Report_Form_MKT.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="" />Báo cáo chăm sóc khách hàng</a></li>
                      <li><a href="../../../../OrangeVersion/Customer/CustomerBirthday.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Sinh nhật khách hàng</a></li>
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu"><a href="#" style="height: 24px; line-height: 24px;">
        <img src="../../../../../images/orange/or_user.png" alt="">BỆNH NHÂN</a>
        <div class="submenu" style="width: 121%">
            <div class="column">
                <ul>
<%--                    <li><a href="../../../../OrangeVersion/Scheduling/SetBed.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Đặt giường</a></li>--%>
                    <li><a href="../../../../OrangeVersion/Customer/CustomerList.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Quản lý bệnh nhân</a></li>
                    <li><a href="../../../../OrangeVersion/Customer/CustomerBirthday.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Sinh nhật bệnh nhân</a></li>
<%--                        <img src="../../../../../images/16x16/star.png" alt="">Thẻ tài khoản KH</a></li>
                    <li><a href="../../../../OrangeVersion/Card/LoyaltyCard_Manage.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Thẻ thành viên</a></li>--%>
                  
                    <%-- <li><a href="../../../../OrangeVersion/Customer/Contract_Print.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">In hợp đồng Mẹ & Bé</a></li>--%>
                    <%--<li>
                        <a href="../../../../OrangeVersion/Customer/CustomerCard.aspx">
                            <img src="../../../../../images/16x16/star.png" alt="">Thẻ khách hàng</a>
                    </li>--%>
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu"><a href="#" style="height: 24px; line-height: 24px;">
        <img src="../../../../../images/orange/or_bank.png" alt="">TÀI CHÍNH</a>
        <div class="submenu" style="width: 116%">
            <div class="column">
                <ul>
                    <li><a href="../../../../OrangeVersion/Finance/ReceiptPayment.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Theo dõi Thu Chi</a></li>
                    <li><a href="../../../../OrangeVersion/Finance/Debt.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Công nợ bệnh nhân</a></li>
                    <li><a href="../../../../OrangeVersion/Finance/DebtSupplier.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Công nợ nhà cung cấp</a></li>
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu"><a href="#" style="height: 24px; line-height: 24px;"><span>
        <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
        <span class='number_notice'></span>
        <img src="../../../../../images/orange/or_clock.png" alt="">LỊCH HẸN</span></a>
        <div class="submenu" style="width: 100%">
            <div class="column">
                <ul>
                    <li><a href="../../../../OrangeVersion/Scheduling/MyScheduling.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Thiết lập lịch hẹn</a></li>
<%--                      <li><a href="../../../../OrangeVersion/Category/DM_Calamviec.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Thiết lập ca làm việc </a></li>--%>
                    <%--<li><a href="../QLPHONG/Phong_ThietlapCa.aspx"><img src="../../../../../images/16x16/star.png" alt="">Thiết lập phòng</a></li>--%>
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu"><a href="#" style="height: 24px; line-height: 24px;"><span>
        <img src="../../../../../images/orange/or_box.png" alt="">THUỐC</span></a>
        <div class="submenu" style="width: 100%">
            <div class="column">
                <ul>
                    <li><a href="../../../../OrangeVersion/Product/WareHousing.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Nhập thuốc</a></li>
                    <li><a href="../../../../OrangeVersion/Product/ExportProduct.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Bán thuốc</a></li>
                    <li><a href="../../../../OrangeVersion/Product/WarehouseTranfer.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Chuyển Kho</a></li>
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu"><a href="#" style="height: 24px; line-height: 24px;">
        <img src="../../../../../images/orange/or_thamso.png" alt="">BÁO CÁO</a>
        <div class="submenu" style="width: 126%">
            <div class="column">
                <ul>
                    <li><a href="../../../../OrangeVersion/Finance/ReportForm_Finance.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Báo cáo tài chính</a></li>
                    <li><a href="../../../../OrangeVersion/Product/ReportForm_Product.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Báo cáo thuốc </a></li>
                    <li><a href="../../../../OrangeVersion/Customer/ReportForm_Cus.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Báo cáo dịch vụ</a></li>
<%--                    <li><a href="../../../../OrangeVersion/Finance/ReportForm_HH.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Báo cáo hoa hồng</a></li>--%>
                    <li><a href="../../../../OrangeVersion/Report/Rp_Web/Rp_Sheduler/rp_SchedulerReport.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Báo cáo lịch hẹn</a></li>
<%--                     <li><a href="../../../../OrangeVersion/Product/ReportForm_Sevice.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Báo cáo dịch vụ</a></li>--%>
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu hiddenipad"><a href="#" style="height: 24px; line-height: 24px;">
        <img src="../../../../../images/orange/or_list.png" alt="">DANH MỤC</a>
        <div class="submenu" style="width: 337px;">
            <div class="column" style="width: 45%; float: left">
                <ul>
                    <li><a href="../../../../OrangeVersion/Category/DMThuchi.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM Thu Chi</a></li>
                   <li><a href="../../../../OrangeVersion/Category/DM_Resources.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM phòng</a></li>
<%--                       <li><a href="../../../../OrangeVersion/Category/Marketing_Tag.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM Tag</a></li>--%>
                    <li><a href="../../../../OrangeVersion/Category/Warehouse.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM kho</a></li>
                    <li><a href="../../../../OrangeVersion/Category/Supplier.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM nhà cung cấp</a></li>
                     <li><a href="../../../../OrangeVersion/Category/Unit_Product.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM Đơn vị</a></li>
<%--                    <li><a href="../../../../OrangeVersion/Card/LoyaltyCard_Catelory.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM thẻ thành viên</a></li>--%>
<%--                    <li><a href="../../../../OrangeVersion/Category/Stages.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM công đoạn</a></li>--%>
<%--                 <li><a href="../../../../OrangeVersion/Category/Origin.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM xuất xứ</a></li>
                     <li><a href="../../../../OrangeVersion/Category/Stages.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM công đoạn</a></li>
                 <li><a href="../../../../OrangeVersion/Category/Promotion.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM Khuyến mãi</a></li>--%>
                    <%--<li><a href="../../../../OrangeVersion/Category/GroupServices_EditForm.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM mệnh giá tiền</a></li>--%>
                    
                </ul>
            </div>
            <div class="column" style="width: 55%; float: left">
                <ul>
                    <li><a href="../../../../OrangeVersion/Category/GroupServices.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM nhóm dịch vụ</a></li>
                    <li><a href="../../../../OrangeVersion/Category/Services.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM dịch vụ</a></li>
                    <li><a href="../../../../OrangeVersion/Category/Type_Product.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM loại thuốc</a></li>
                    <li><a href="../../../../OrangeVersion/Category/Group_Product.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM nhóm thuốc</a></li>
                    <li><a href="../../../../OrangeVersion/Category/Product.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM thuốc</a></li>
                     <li><a href="../../../../OrangeVersion/Category/Other.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Danh mục khác</a></li>
  
                    
                    <%--<li><a href="../../../../OrangeVersion/Category/GroupServices_EditForm.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">DM đánh giá</a></li>--%>
                   
                </ul>
            </div>
        </div>
    </li>
    <li class="topmenu"><a href="#" style="height: 24px; line-height: 24px;">
        <img src="../../../../../images/orange/or_setting.png" alt="">QUẢN TRỊ</a>
        <div class="submenu" style="width: 100%">
            <div class="column">
                <ul>
                    <li><a href="../../../../Default.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Trang chủ</a></li>
                    <li><a href="../../../../OrangeVersion/Category/System_parameter.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Cấu hình hệ thống</a></li>
                    <li><a href="../../../../../../OrangeVersion/Category/Personel.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Quản lý nhân viên</a></li>
                       <%--       <li><a href="../../../../OrangeVersion/Personnel/ManageSalaries.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Quản lý lương</a></li>--%>
                    <%--<li><a href="../../../QUANTRI/Add_TaikhoanKH.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Thiết lập TK KH</a></li>--%>
<%--                    <li><a href="../../../../OrangeVersion/Category/Security.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Phân quyền</a></li>--%>
                    <%--<li><a href="../../../QUANTRI/FormBaoCao.aspx"><img src="../../../../../images/16x16/star.png" alt="">Báo cáo quản trị</a></li>--%>
                    <li><a href="../../../../OrangeVersion/Category/UserDiary.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Nhật ký hệ thống</a></li>
                    <li><a href="../../../../OrangeVersion/Category/PasswordChange.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Đổi mật khẩu</a></li>
                    <li><a href="../../../../LoginSys.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Đăng xuất</a></li>
                </ul>
            </div>
        </div>
    </li>
</ul>

<link href="../../../../../Css/responsivemenu/flexy-menu.css" rel="stylesheet" />
<style>
   
</style>
<script src="../../../../../../../Css/responsivemenu/flexy-menu.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".flexy-menu").flexymenu({ speed: 400, type: "horizontal", align: "right", indicator: true });
    });
</script>
<ul class="flexy-menu thick orange">
    <li class="right" style="display: block;">
        <a href="javascript:void(0)"><i class="icon-th"></i>QUẢN TRỊ</a>
        <ul>
            <li><a href="../../../../SetBed.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Trang chủ</a></li>
            <li><a href="../../../QUANTRI/SettingSpa.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Cấu hình hệ thống</a></li>
            <li><a href="../../../../OrangeVersion/Category/Personel.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Quản lý nhân viên</a></li>
            <%--<li><a href="../../../QUANTRI/Add_TaikhoanKH.aspx">
                        <img src="../../../../../images/16x16/star.png" alt="">Thiết lập TK KH</a></li>--%>
            <li><a href="../../../../OrangeVersion/Category/Security.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Phân quyền</a></li>
            <%--<li><a href="../../../QUANTRI/FormBaoCao.aspx"><img src="../../../../../images/16x16/star.png" alt="">Báo cáo quản trị</a></li>--%>
            <li><a href="../../../../OrangeVersion/Category/UserDiary.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Nhật ký hệ thống</a></li>
            <li><a href="../../../../OrangeVersion/Category/PasswordChange.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Đổi mật khẩu</a></li>
            <li><a href="../../../../LoginSys.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Đăng xuất</a></li>
        </ul>
        <span class="indicator">+</span>
    </li>
    <li class="right" style="display: block;">
        <a href="javascript:void(0)"><i class="icon-th"></i>KHÁCH HÀNG</a>
        <ul>
            <li><a href="../../../../OrangeVersion/Customer/CustomerList.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Quản lý khách hàng</a></li>
            <li><a href="../../../../OrangeVersion/Customer/AccountCard.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Thẻ tài khoản KH</a></li>
        </ul>
        <span class="indicator">+</span>
    </li>
    <li class="right" style="display: block;">
        <a href="javascript:void(0)"><i class="icon-th"></i>TÀI CHÍNH</a>
        <ul>
            <li><a href="../../../../OrangeVersion/Finance/ReceiptPayment.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Theo dõi Thu Chi</a></li>
            <li><a href="../../../../OrangeVersion/Finance/Debt.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Công nợ khách hàng</a></li>
        </ul>
        <span class="indicator">+</span>
    </li>
    <li class="right" style="display: block;">
        <a href="javascript:void(0)"><i class="icon-th"></i>LỊCH HẸN</a>
        <ul>
            <li><a href="../../../../OrangeVersion/Scheduling/MyScheduling.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Thiết lập lịch hẹn</a></li>
        </ul>
        <span class="indicator">+</span>
    </li>
    <li class="right" style="display: block;">
        <a href="javascript:void(0)"><i class="icon-th"></i>MỸ PHẨM</a>
        <ul>
            <li><a href="../../../../OrangeVersion/Product/WareHousing.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Nhập hàng</a></li>
            <li><a href="../../../../OrangeVersion/Product/ExportProduct.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Xuất hàng</a></li>
            <li><a href="../../../../OrangeVersion/Product/WarehouseTranfer.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Chuyển Kho</a></li>
        </ul>
        <span class="indicator">+</span>
    </li>
    <li class="right" style="display: block;">
        <a href="javascript:void(0)"><i class="icon-th"></i>BÁO CÁO</a>
        <ul>
            <li><a href="../../../../OrangeVersion/Finance/ReportForm_Finance.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Báo cáo tài chính</a></li>
            <li><a href="../../../../OrangeVersion/Product/ReportForm_Product.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Báo cáo mặt hàng</a></li>
            <li><a href="../../../../OrangeVersion/Customer/ReportForm_Cus.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Báo cáo khách hàng</a></li>
            <li><a href="../../../../OrangeVersion/Finance/ReportForm_HH.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Báo cáo hoa hồng</a></li>
            <li><a href="../../../../OrangeVersion/Report/Rp_Web/Rp_Sheduler/rp_SchedulerReport.aspx">
                <img src="../../../../../images/16x16/star.png" alt="">Báo cáo lịch hẹn</a></li>
        </ul>
        <span class="indicator">+</span>
    </li>
</ul>
