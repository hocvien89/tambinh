var ConfigBillingService={
    settings: {
        btnxemphieuxuat:''
    },
    valid: true,
    init: function (Settings) {
        this.buttomClick();
    },
    buttomClick: function () {
        $('.btnDanhsach').click(function () {
            $('#ctl00_ContentPlaceHolder_Main_pcDanhsachphieu_CLW-1').show();
        })
    }
}