$(document).ready(function () {
    $("#ctl00_ContentPlaceHolder_Main_pcAddKhachhang_Panel1_btnInphieukham_BTC").click(function () {
        var $dialog = $('<div></div>')
         .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Print.aspx?type=phieukham" width="850px" height="100%"></iframe>')
         .dialog({
             autoOpen: false,
             modal: true,
             height: 634,
             width: 855.733,
             title: "In phiếu Khám",
             buttons: {
                 "Close": function () { $dialog.dialog('close'); }
             },
             close: function (event, ui) {
                 pcAddKhachhang.Show();
             }
         });
        $dialog.dialog('open');
        pcAddKhachhang.Hide();
        return false;
    });
})