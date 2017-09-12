function grid_EndCallback(s, e) {

    if (s.cpShowError) {
        lberror.SetText(s.cpText);
    }
}
function jo_ThousanSereprate(id) {
    //var textbox = id;
    id.value = jo_FormatMoney(id.value.replace(/,/g, ""));
    return false;
}
function jo_ThousanSereprates(str) {
    var strconvert
    strconvert = jo_FormatMoney(str.replace(/,/g, ""));
    return strconvert;
}
function ShowEditWindow() {
    pcAddMathang.Show();
}
function ClosePopup(s, e) {
    pcAddMathang.Hide();
    PcImportExcel.Hide();
    client_grid.Refresh();
    grvinmavach.Refresh();
}
// su ly su kien tren gridview load du lieu len popup 
function SelChanged(s, e) {
    if (!e.isSelected) {
    } else {
        client_grid.GetRowValues(e.visibleIndex, 'uId_Mathang;', OnGridSelectionComplete);
    }
}
function CallPrint(e, s) {
    var prtContent = document.getElementById('divPrint');
    var WinPrint = window.open('', '', 'width=150,height=150,toolbar=0,scrollbars=0,status=0');
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
}
function cbomavachSelect(s, e) {
    GetMavach(cboloaimavach.GetValue());
}

function btnlocClick(s, e) {
    client_grid.Refresh();
    grvinmavach.Refresh();
}
function chkallChange(s, e) {
    if (s.GetChecked())
        grvinmavach.SelectRows();
    else
        grvinmavach.UnselectRows();
}
