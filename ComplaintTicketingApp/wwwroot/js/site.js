function CreateDatePicker(id, spanid) {
    $('#' + id).datepicker({
        format: 'dd/mm/yyyy',
        uiLibrary: 'bootstrap4',
        iconsLibrary: 'fontawesome'
    }).on('change', function (ev) {
        $("#" + spanid).html(CheckDateValidation($('#' + id).val(), id));
    });
}
function FromDatePicker(date) {
    var ddd = date.split("/");
    var f = new Date(ddd[2], ddd[1] - 1, ddd[0])
    var dateDay = f.getDate() < 10 ? '0' + f.getDate() : f.getDate();
    var dateMon = (f.getMonth() + 1) < 10 ? '0' + (f.getMonth() + 1) : (f.getMonth() + 1);
    var dateDone = dateMon + "/" + dateDay + "/" + f.getFullYear();
    return dateDone;
}

function FormatDateDayFirst(date) {
    //Convert Date format to: "dd/mm/yyyy"
    var date1 = new Date(date);
    var dateDay = date1.getDate() < 10 ? '0' + date1.getDate() : date1.getDate();
    var dateMon = (date1.getMonth() + 1) < 10 ? '0' + (date1.getMonth() + 1) : (date1.getMonth() + 1);
    var dateDone = dateDay + "/" + dateMon + "/" + date1.getFullYear();
    return dateDone;
}

function FormatDateMonthFirst(date) {
    //Convert Date format to: "mm/dd/yyyy"
    var date1 = new Date(date);
    var dateDay = date1.getDate() < 10 ? '0' + date1.getDate() : date1.getDate();
    var dateMon = (date1.getMonth() + 1) < 10 ? '0' + (date1.getMonth() + 1) : (date1.getMonth() + 1);
    var dateDone = dateMon + "/" + dateDay + "/" + date1.getFullYear();
    return dateDone;
}

function GetTime(date) {
    var dateTime = new Date(date);

    return dateTime.getHours().toString().padStart(2, "0") + ":" + dateTime.getMinutes().toString().padStart(2, "0") + ":" + dateTime.getSeconds().toString().padStart(2, "0");
}

function ApiCall(apiurl, type, datatype, data) {

    var result;
    $.ajax({
        url: apiurl,
        type: type,
        async: false,
        dataType: datatype, // added data type
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(data),
        success: function (res) {
            result = res;
        },
        error: function (res) {
            //alert('oops, something bad happened');    
            result = res;
        },
        fail: function (res) {

            result = res;
            alert(res);
        }
    });
    return result;
}

function ValidationChangeCss(item) {
    item.css({
        "border": "1px solid red",
        "background": "#FFCECE"
    });
}

function ValidationResetCss(item) {
    item.css({
        "border": "",
        "background": ""
    });
}

function CheckNullValidation(controlid) {
    var msg = "";
    var onumVal = $('#' + controlid).val();
    if (onumVal == "" || onumVal == null) {
        isValid = false;
        ValidationChangeCss($('#' + controlid));
        msg = "This field is required.";
    }
    else {
        ValidationResetCss($('#' + controlid));
        msg = "";
    }

    return msg;
}

function CheckDateValidation(dateval, datecontrol) {
    var msg = "";
    if (dateval == "") {
        isValid = false;
        ValidationChangeCss($('#' + datecontrol));
        msg = "This field is required.";
    }
    else {
        var dateDone = FormatDateMonthFirst(new Date($.now()));
        if (new Date(FromDatePicker(dateval)) > new Date(dateDone)) {
            msg = false;
            ValidationChangeCss($('#' + datecontrol));
            msg = "Date must be less than or equal today.";
        }
        else {
            ValidationResetCss($('#' + datecontrol));
            msg = "";
        }
    }

    return msg;
}

function CompareTwoDate(dateval1, dateval2) {
    var msg = false;
    if (dateval1 != "" && dateval2 != "") {
        if (new Date(FromDatePicker(dateval1)) > new Date(FromDatePicker(dateval2))) {
            msg = true;
        }
    }

    return msg;
}

function EmptyHtml(formid) {
    var inp = $('#' + formid + ' * > input').each(function () {
        $(this).val('');
        ValidationResetCss($(this));
    });

    var inp = $('#' + formid + ' * > textarea').each(function () {
        $(this).val('');
        ValidationResetCss($(this));
    });
    
    var inp = $('#' + formid + ' .optionclass').each(function () {
        $(this).remove();        
    });

    var inp = $('#' + formid + ' .mdb-select').each(function () {
        ValidationResetCss($(this));
    });

    var inp = $('#' + formid + ' .validation-span').each(function () {   
        $(this).html("");
        ValidationResetCss($(this));
    });
}
