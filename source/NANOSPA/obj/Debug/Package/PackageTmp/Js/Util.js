function ThousandSeparate() {
    if (arguments.length == 1) {
        var V = arguments[0].value;
        V = V.replace(/,/g, '');
        var R = new RegExp('(-?[0-9]+)([0-9]{3})');
        while (R.test(V)) {
            V = V.replace(R, '$1,$2');
        }
        arguments[0].value = V;
    }
    else if (arguments.length == 2) {
        var V = document.getElementById(arguments[0]).value;
        var R = new RegExp('(-?[0-9]+)([0-9]{3})');
        while (R.test(V)) {
            V = V.replace(R, '$1,$2');
        }
        document.getElementById(arguments[1]).innerHTML = V;
    }
    else return false;
}

function ConvertDateToDDMMYYY(input) {
    var output = input.split("/");
    return output[1] + "/" + output[0] + "/" + output[2];
}

function ConvertSex(input) {
    var output = "0";
    if (input == "True") {
        output = "1";
    }
    return output;
}

function jo_RemoveSession(sessionname) {
    var param_dt = "{'sessionname':'" + sessionname + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/ClearSession";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            // Do something interesting here.
        },
        error: onFail
    });
}
function jo_CreateSession(sessionname, value) {
    var param_dt = "{'sessionname':'" + sessionname + "', 'value':'" + value + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateSession";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            // Do something interesting here.
        },
        error: onFail
    });
}
function jo_GetSession(sessionname) {
    var value = "";
    var param_dt = "{'sessionname':'" + sessionname + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/GetSession";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.d != "") {
                value = msg.d;
            }
        },
        error: onFail
    });
    return value;
}
function convert_IsString(input) {
    var value = "";
    if (input == "" || input == null) {
        value = "0";
    }
    else {
        value = input;
    }
    return value;
}
function onFail(ex) {
    alert(ex._message + " fail");
    return false;
}
function jo_FormatMoney(input) {
    return input.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
}
function jo_ThousanSereprate(id) {
    var textbox = id;
    id.value = jo_FormatMoney(id.value);
    return false;
}
function Jo_CheckRole(input) {
    var value = "";
    var param_dt = "{'uId_Chucnang':'" + input + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            value = msg.d
        },
        error: function () {
            value = "false"
        }
    });
    return value;
}