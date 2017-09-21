var kPortal = new Object({
    OpenDialog: function (url, width, minheight) {
        if (width == null) width = 600;
        if (minheight == null) minheight = 400;
        $('body').append('<div id="kZoom" class="padding60"><div class="k-dialog" style="width: ' + width + 'px; min-height: ' + minheight + 'px;"><a href="javascript:void(0)" class="x-close"><span class="close"></span></a><div id="kbox"></div></div></div>');
        $('body').addClass('noscroll');
        $('.x-close').click(function () { kPortal.CloseBox(); });
        $('#kbox').html('<div>Đang tải...<img src="/vnkresource/images/loading.gif"></div>');
        $('#kbox').load(url, (function (response, status, xhr) {
            if (status == "error") {
                var msg = "Sorry but there was an error: "; $("#kbox").html(msg + xhr.status + " " + xhr.statusText);
            }
        }));
    },
    LoadBox: function (url) {
        $('body').append('<div id="kZoom" class=""><div class="kboxpanel" id="kbox"></div></div>');
        $('body').addClass('noscroll');
        $('#kZoom').click(function () {
            if (!kPortal._isbox)
                kPortal.CloseBox();
            kPortal._isbox = false;
        });
        $('#kbox').click(function () {
            kPortal._isbox = true;
        });
        $('#kbox').load(url + ' #content', (function () { }));
    },
    CloseBox: function () {
        parent.$('body').removeClass('noscroll');
        parent.$('#kZoom').remove();
    },
    kBox: function (css) {
        $(css).click(function () {
            kPortal.LoadBox($(this).attr('href'));
            return false;
        });
    },
    _isbox: false
});