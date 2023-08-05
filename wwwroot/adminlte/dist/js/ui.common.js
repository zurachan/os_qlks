uiUtils = {
    BackToTop: function () {
        if ($('#back-to-top').length) {
            var scrollTrigger = 100, // px
                backToTop = function () {
                    var scrollTop = $(window).scrollTop();
                    if (scrollTop > scrollTrigger) {
                        $('#back-to-top').addClass('show');
                    } else {
                        $('#back-to-top').removeClass('show');
                    }
                };
            backToTop();
            $(window).on('scroll', function () {
                backToTop();
            });
            $('#back-to-top').on('click', function (e) {
                e.preventDefault();
                $('html,body').animate({
                    scrollTop: 0
                }, 700);
            });
        }
    },

    // TODO QQ Upload files to host
    // selector: file-uploader
    CreateFileUploader: function (url, selector, index) {
        var uploader = new qq.FileUploader({
            element: document.getElementById(selector + index),
            action: url,
            debug: false,
            multiple: false,
            onSubmit: function (id, fileName) {
                $("div#" + selector + index + " .qq-upload-list li").remove();
            },
            onComplete: function (id, fileName, responseJSON) {
                if (responseJSON.success) {
                    $("#hdFileName" + index).val(fileName);
                    $("#hdFilePath" + index).val(responseJSON.serverPath);
                } else {
                    $("#hdFileName" + index).val(fileName);
                    $("#hdFilePath" + index).val("");
                    alert("Upload không thành công.");
                }
                $("div#" + selector + index + " .qq-upload-list li").append('<span><a onclick="uiUtils.RemoveFileUploader(this,' + index + ');" style="cursor: pointer; cursor: hand;" title="Xoá"><i class="la la-trash"></i> </a></span>');
            }
        });
    },

    //TODO: Remove file uploader
    RemoveFileUploader: function (obj, index) {
        $(obj).parents('li').remove();
        $("#hdFileName" + index).val("");
        $("#hdFilePath" + index).val("");
    },

    CreateTableRowTemplate: function (obj, htmlRowContent) {
        // get table id attribute
        var tableId = $(obj).closest('table').attr("id");
        // count total row in body
        var rowCount = $("#" + tableId + " tbody tr").length;
        // increment row number
        var totalRow = $("#" + tableId).attr("data-total-row");
        var rowIndex = parseInt(totalRow) + 1;

        // Row template
        var htmlTemplate = "";
        htmlTemplate = htmlTemplate + htmlRowContent.replaceAll("{{RowIndex}}", rowIndex);

        if (rowCount <= 0) {
            $("#" + tableId + " tbody").html(htmlTemplate);
        } else {
            $("#" + tableId + " tbody tr:last").after(htmlTemplate);
        }
        $("#" + tableId).attr("data-total-row", rowIndex);

        return rowIndex;
    },

    /*
        Created by: thupa - 2014.05.20
        TODO: Nhom cac row giong nhau cua table lại thanh 1 dong
        Exp: uiUtils.MergeCells($('#grdList tr:has(td)'), 2, 2); $('#gvSearchRecord .deleted').remove();
    */
    MergeCells: function ($rows, startIndex, total) {
        if (total === 0) {
            return;
        }

        var i, currentIndex = startIndex, count = 1, lst = [];
        //find columns in row
        var tds = $rows.find('td:eq(' + currentIndex + ')');
        var ctrl = $(tds[0]);
        lst.push($rows[0]);

        for (i = 1; i <= tds.length; i++) {
            if (ctrl.text() == $(tds[i]).text()) {
                count++;
                $(tds[i]).addClass('deleted');
                lst.push($rows[i]);
            }
            else {
                if (count > 1) {
                    ctrl.attr('rowspan', count);
                    uiUtils.MergeCells($(lst), startIndex + 1, total - 1)
                }
                count = 1;
                lst = [];
                ctrl = $(tds[i]);
                lst.push($rows[i]);
            }
        }
    }, // End: rowspan


    /*
        Created by thupa - 2014.05-20
        TODO: cho phep nguoi dung chi duoc nhap du lieu vao la so
        Exp: uiUtils.InputNumberOnly(txtPrice, 1);
    */
    InputNumberOnly: function (controlId, controlIndex) {
        $("#" + controlId + controlIndex).keydown(function (e) {
            // Allow: backspace, delete, tab, escape, enter and .
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A
                (e.keyCode == 65 && e.ctrlKey === true) ||
                // Allow: home, end, left, right
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            }
            // Ensure that it is a number and stop the keypress
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        });
    }, // End: Input Number


    /*
        Createed by: thupa - 2017.03.18
        TODO: Convert Dictionary to Json string
        maps: array
        uiUtils.ConvertDictionaryToJson(arr);
    */
    ConvertDictionaryToJson: function (maps) {
        var obj = "{";
        $.map(maps, function (item, index) {
            obj = obj + "\"" + item.key + "\":";
            obj = obj + ((item.value != null) ? "\"" + item.value + "\"" : "null");
            if (index < maps.length - 1) {
                obj = obj + ",";
            }

        });
        obj = obj + "}";

        return JSON.parse(obj);
    },
    /*
        Createed by: thupa - 2017.03.18
        get value from cotrols and push to array
        Exp: uiUtils.PushValueToArray(".input-search");
    */
    PushValueToArray: function (selector) {
        var arrKeyword = [];
        $(selector).each(function () {

            var md = $(this).attr("md");
            if (md != undefined) {
                if ($(this).attr('control-type') == 'checkbox') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this)[0].checked;
                    inputValue = inputValue == true ? 1 : 0;
                    arrKeyword.push({ "key": md, "value": inputValue });

                }
                else if ($(this).attr('control-type') == 'date') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val() != "" ? moment($(this).val(), "DD/MM/YYYY").format("YYYY/MM/DD") : "";

                    arrKeyword.push({ "key": md, "value": inputValue });
                }
                else if ($(this).attr('control-type') == 'date-range') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();

                    if (inputValue != "") {
                        var arrValue = inputValue.split('-');

                        var date1 = moment(arrValue[0], "DD/MM/YYYY").format("YYYY/MM/DD");
                        var date2 = moment(arrValue[1], "DD/MM/YYYY").format("YYYY/MM/DD");

                        inputValue = date1.concat("-", date2);
                    }
                    arrKeyword.push({ "key": md, "value": inputValue });
                }
                else if ($(this).attr('control-type') == 'datetime') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();

                    if (inputValue != "") {
                        var arrValue = inputValue.split(' ');

                        var date = moment(arrValue[0], "DD/MM/YYYY").format("YYYY/MM/DD");
                        var time = moment(arrValue[1], "HH:mm").format("HH:mm:ss");

                        inputValue = date.concat(" ", time);
                    }
                    arrKeyword.push({ "key": md, "value": inputValue });
                }

                else if ($(this).attr('control-type') == 'textbox') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val().trim();

                    arrKeyword.push({ "key": md, "value": inputValue.replace(/(\r\n|\n\r|\r|\n)/g, '\\n') });
                }
                else if ($(this).attr('control-type') == 'numberic') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();

                    arrKeyword.push({ "key": md, "value": inputValue.noCommas() });
                }
                else if ($(this).attr('control-type') == 'hidden') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();

                    arrKeyword.push({ "key": md, "value": inputValue });
                }
                else if ($(this).attr('control-type') == 'dropdown') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();
                    if (inputValue == null || inputValue == undefined) {
                        inputValue = 0;
                    }

                    arrKeyword.push({ "key": md, "value": inputValue });
                }
                else if ($(this).attr('control-type') == 'multichoice') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();
                    if (inputValue == null || inputValue == undefined) {
                        inputValue = "";
                    } else {
                        inputValue = inputValue.join();
                    }

                    arrKeyword.push({ "key": md, "value": inputValue });
                }
                else if ($(this).attr('control-type') == 'input-number') {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();
                    if (inputValue == null || inputValue == undefined) {
                        inputValue = 0;
                    }
                    arrKeyword.push({ "key": md, "value": parseInt(inputValue) });
                }
                else {

                    var inputId = $(this).attr('id');
                    var inputValue = $(this).val();

                    arrKeyword.push({ "key": md, "value": inputValue.replace(/(\r\n|\n\r|\r|\n)/g, '\\n') });
                }
            }
        });

        return arrKeyword;
    },

    GetUrlParameter: function (sParam) {
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] == sParam) {
                return sParameterName[1];
            }
        }
    },

    formatDateTime: function (inputValue) {
        if (inputValue != "") {
            var arrValue = inputValue.split(' ');

            var date = moment(arrValue[0], "DD/MM/YYYY").format("YYYY/MM/DD");
            var time = moment(arrValue[1], "HH:mm").format("HH:mm:ss");

            inputValue = date.concat(" ", time);

            return inputValue;
        }
        return "";
    },

    formatDateTimeVietNamese: function (inputValue) {
        if (inputValue != "") {
            var arrValue = inputValue.split(' ');

            var date = moment(arrValue[0], "DD/MM/YYYY").format("DD/MM/YYYY");
            var time = moment(arrValue[1], "HH:mm").format("HH:mm:ss");

            inputValue = date.concat(" ", time);

            return inputValue;
        }
        return "";
    },

    getColumnIndex: function (tableId, columnName) {
        var tr, td;
        tr = $('#' + tableId + ' thead tr:eq(0)');
        td = tr.find('[column-name=' + columnName + ']');
        return td.index();
    },

    getTdFromName: function (tableId, trObj, columnName) {
        var idx;
        idx = uiUtils.getColumnIndex(tableId, columnName);
        return $($(trObj).find('td')[idx]);
    },

    gettFootColumnIndex: function (tableId, columnName) {
        var tr, td;
        tr = $('#' + tableId + ' tfoot tr:eq(0)');
        td = tr.find('[column-name=' + columnName + ']');
        return td.index();
    },

    groupBy: function (dataSource, key) {
        return dataSource.reduce(function (rv, item) {
            (rv[item[key]] = rv[item[key]] || []).push(item);
            return rv;
        }, {});
    },
    /*
    Created by: duonght2 - 2023.01.09
    group an array by value of a property
    Exp: uiUtils.groupBy(array, 'name');
    */

    serializeArrayIncludingDisabledFields: function (form) {
        var fields = form.find('[disabled]');
        fields.prop('disabled', false);
        var array = form.serializeArray();
        fields.prop('disabled', true);
        return array;
    },

    groupByMulti: function (array, func) {
        let groups = {};
        array.forEach(function (item) {
            let group = JSON.stringify(func(item));
            groups[group] = groups[group] || [];
            groups[group].push(item);
        });
        return Object.keys(groups).map(function (group) {
            return groups[group];
        })
    },
    /*
    Created by: duonght2 - 2023.02.27
    group an array by value of multi properties
    Exp: 
        let result = uiUtils.groupBy(array, function(item){
            return [item.propterty1, item.property2,....]
        });
    */

    objectifyForm: function (formArray) {
        //serialize data function
        var returnArray = {};
        for (var i = 0; i < formArray.length; i++) {
            returnArray[formArray[i]['name']] = formArray[i]['value'];
        }
        return returnArray;
    },

}

/***************************************
= String Format
-------------------------------------- */
//#region
String.format = function (text) {
    //check if there are two arguments in the arguments list
    if (arguments.length <= 1) {
        //if there are not 2 or more arguments there's nothing to replace
        //just return the original text
        return text;
    }

    //decrement to move to the second argument in the array
    var tokenCount = arguments.length - 2;
    for (var token = 0; token <= tokenCount; token++) {
        //iterate through the tokens and replace their placeholders from the original text in order
        text = text.replace(new RegExp("\\{" + token + "\\}", "gi"),
            arguments[token + 1]);
    }
    return text;
};
//#endregion

/***************************************
= Replaces all instances of the given substring.
-------------------------------------- */
String.prototype.replaceAll = function (
    strTarget, // The substring you want to replace
    strSubString // The string you want to replace in.
) {
    var strText = this;
    var intIndexOfMatch = strText.indexOf(strTarget);

    // Keep looping while an instance of the target string
    // still exists in the string.
    while (intIndexOfMatch != -1) {
        // Relace out the current instance.
        strText = strText.replace(strTarget, strSubString);

        // Get the index of any next matching substring.
        intIndexOfMatch = strText.indexOf(strTarget);
    }

    // Return the updated string with ALL the target strings
    // replaced out with the new substring.
    return (strText);
};

Number.prototype.withCommas = function () {
    return this.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
};

String.prototype.noCommas = function () {
    return this != undefined ? this.replace(/,/g, "") : 0;
};

Number.prototype.formatNumber = function () {
    return this.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
};

notifier = {

    info: function (msg) {
        toastr.info(msg, "", {
            "closeButton": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "showDuration": "300",
            "hideDuration": "3000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        });
    },

    warning: function (msg) {
        toastr.warning(msg, "", {
            "closeButton": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "showDuration": "300",
            "hideDuration": "3000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        });
    },

    success: function (msg) {
        toastr.success(msg, "", {
            "closeButton": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "showDuration": "300",
            "hideDuration": "3000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        });
    },

    error: function (msg) {
        toastr.error(msg, "Cảnh báo lỗi", {
            "closeButton": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "showDuration": "300",
            "hideDuration": "3000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        });
    }
}
