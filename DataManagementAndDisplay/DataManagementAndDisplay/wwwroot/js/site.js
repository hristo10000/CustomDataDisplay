var isCustomContextMenuOpened = false;
var isCustomContextMenuFillInTableOptionSelected = false;
var currentRightClickedElementClass;

//todo: make it work with td
$("table").mousedown(function (ev) {
    if (ev.which == 3) {
        currentRightClickedElementClass = this.classList[0];
        $(".contextMenu").css("display", "block");
        $(".contextMenu").css("top", mouseY(ev) );
        $(".contextMenu").css("left", mouseX(ev) );
        isCustomContextMenuOpened = true;
    }
});

$(".contextMenuOptionFillInTable").mousedown(function (ev) {
    if (ev.which == 1) {
        isCustomContextMenuFillInTableOptionSelected = true;
        $(currentRightClickedElementClass).click();
    }
});

$("html").mousedown(function (ev) {
    if (ev.which == 1 && isCustomContextMenuOpened == true) {
        $(".contextMenu").css("display", "none");
        isCustomContextMenuOpened = false;
        return;
    }
});

$(document).ready(function () {
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
                row = '<tr class="data-row"><td></td>';
                for (var j = 0; j < tableNames.length; j++) {
                    if (j == tableNames.length - 1) {
                        row += '<td>' + JsonData[i][tableNames[j]] + '</td>';
                    }
                    else {
                        var a = JsonData[i][tableNames[j]];
                        var selectedElements = $(`th:nth-child(${j + 2})`);
                        row += `<td class="${selectedElements.text()}" onclick="CtrlSelectFromTable('${a}','${selectedElements.text()}');">` + a + '</td>';
                    }
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

function CtrlSelectFromTable(value, columnName) {
    if (isCustomContextMenuFillInTableOptionSelected || event.ctrlKey) {
        const overlay = document.querySelector(`.${columnName}`).value = value;
        isCustomContextMenuFillInTableOptionSelected = false;
    }
}

function mouseX(evt) {
    if (evt.pageX) {
        return evt.pageX;
    } else if (evt.clientX) {
        return evt.clientX + (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    } else {
        return null;
    }
}

function mouseY(evt) {
    if (evt.pageY) {
        return evt.pageY;
    } else if (evt.clientY) {
        return evt.clientY + (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    } else {
        return null;
    }
}
