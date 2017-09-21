var img_url = '';
function jo_IsString(input) {
    var value = "";
    if (input == "" || input == null || isNaN(input) == true) {
        value = "0";
    }
    else {
        value = input;
    }
    return value;
}
function jo_FormatMoney(input) {
    return input.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
function jo_ThousanSereprate(id) {
    var textbox = id;
    id.value = jo_FormatMoney(id.value.replace(/,/g, ""));
    return false;
}