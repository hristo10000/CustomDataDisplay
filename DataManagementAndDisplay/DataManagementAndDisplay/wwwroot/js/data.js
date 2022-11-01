﻿$(document).ready(function () {
    document.onkeydown = NavigateToTop;
    $("#form").submit(function (event) {
        event.preventDefault();
        SearchAndDisplay();
    });
    SearchAndDisplay();
});

function SearchAndDisplay() {
    var form_data = GetData();
    $(".loading").show();
    $(".tableToBeHidden").hide();
    $(".messageToBeHidden").hide();
    $.ajax({
        type: "POST",
        url: "/Search",
        data: JSON.stringify(form_data),
        contentType: 'application/json',
        dataType: 'json',
        success: function (JsonData) {
            $('.data-row').remove();
            $(".loading").hide();
            if (JsonData.length == 0) {
                $(".messageToBeHidden").show();
                return;
            }
            $(".messageToBeHidden").hide();
            $("#table-result").show();
            var tableNames = [];
            tableNames = Object.getOwnPropertyNames(JsonData[0]);
            for (i = 0; i < JsonData.length; i++) {
                row = '<tr class="data-row"><td class="row-number"></td>';
                for (var j = 0; j < tableNames.length; j++) {
                    var a = JsonData[i][tableNames[j]];
                    var selectedElements = $(`th:nth-child(${j + 2})`);
                        row += `<td class="${selectedElements.text()}" onclick="CtrlSelectFromTable('${a}','${selectedElements.text()}');">` + a + '</td>';
                    }
                row += '</tr>'
                $('#table-result').append(row);
            }
        }
    });
}

function GetData() {
    var SearchModel = {};
    var timeControl = $(".time-control");
    var Time = {};
    SearchModel.Fields = [];
    Time["InternalName"] = timeControl.attr('id');
    Time["Value"] = timeControl.val();
    SearchModel.Time = Time;

    var fields = $(".data-control")
    $.each(fields, function (id, value) {
        var Field = {};
        Field["InternalName"] = value.id;
        Field["Value"] = value.value;
        SearchModel.Fields[id] = Field;
    });
    return SearchModel;
}


function GetAllModels() {
    console.log("b");
    $.ajax({
        type: "GET",
        url: "/Models",
        success: function (JsonData) {
            console.log(JsonData);
        }
    });
}