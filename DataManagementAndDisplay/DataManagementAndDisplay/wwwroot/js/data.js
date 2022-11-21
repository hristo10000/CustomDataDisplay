var currentlyDisplayedModelName;

$(document).ready(function () {
    document.onkeydown = NavigateToTop;
    $('#form').submit(function (event) {
        event.preventDefault();
        SearchAndDisplay();
    });
    SearchAndDisplay();
});

function SearchAndDisplay() {
    var form_data = GetData();
    $('.loading').show();
    $('.table-to-be-hidden').hide();
    $('.message-to-be-hidden').hide();
    $.ajax({
        type: 'POST',
        url: '/Search',
        data: JSON.stringify(form_data),
        contentType: 'application/json',
        dataType: 'json',
        success: function (JsonData) {
            $('.data-row').remove();
            $('.loading').hide();
            if (JsonData.length == 0) {
                $('.message-to-be-hidden').show();
                return;
            }
            $('.message-to-be-hidden').hide();
            $('#table-result').show();
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
    var timeControl = $('.time-control');
    var Time = {};
    SearchModel.Fields = [];
    Time['InternalName'] = timeControl.attr('id');
    Time['Value'] = timeControl.val();
    SearchModel.Time = Time;
    var fields = $('.data-control')

    $.each(fields, function (id, value) {
        var Field = {};
        Field['InternalName'] = value.id;
        Field['Value'] = value.value;
        SearchModel.Fields[id] = Field;
    });
    return SearchModel;
}

function FillAllModels() {
    $.ajax({
        type: 'GET',
        url: '/Models',
        success: function (JsonData) {
            var AppendToDiv = $('.all-models');
            AppendToDiv.empty();
            for (var i = 0; i < JsonData.length; i++) {
                var div = $('<div></div>').attr('class', 'model-name-for-all-models-list');
                var mySpan = $(`<span onclick="ChooseAsDisplayedModel('${JsonData[i].name }')" class="model-name-button"></span>`).text(JsonData[i].name);
                div.append(mySpan);
                div.append(`<div onclick="DeleteModel('${ JsonData[i].name }')" class="delete-model-button">❌</div>`)
                AppendToDiv.append(div);
            }
        }  
    });
}

function FillModelNamesInSelect() {
    $.ajax({
        type: 'GET',
        url: '/Models',
        success: function (JsonData) {
            var select = $('.select-for-displayed-model');
            select.empty();
            for (var i = 0; i < JsonData.length; i++) {
                if (currentlyDisplayedModelName == JsonData[i].name) {
                    select.append(`<option class="model-name-option-${i}" value="${JsonData[i].name} selected disabled">${JsonData[i].name}</option>`);
                    break;
                }
            }
            for (var i = 0; i < JsonData.length; i++) {
                if (currentlyDisplayedModelName == JsonData[i].name) continue;
                select.append(`<option class="model-name-option-${i}" value="${JsonData[i].name}">${JsonData[i].name}</option>`);
            }
        }
    });
}

function ChangeSelectedElement() {
    currentlyDisplayedModelName = $(".select-for-displayed-model :selected").text();
    var NameOfModel = {};
    NameOfModel.name = currentlyDisplayedModelName;
    $.ajax({
        type: 'POST',
        url: '/DispayModels',
        data: JSON.stringify(NameOfModel),
        contentType: 'application/json',
        success: function (JsonData) {
            SearchMenu = $(".search").empty();
            var formByTheNewModel = ' <form id="form">' +
                '< div class="search-form-top-row" >' +
                '<h2>Search</h2>' +
                '<button class="clear-search-form-button" type="reset">Reset Search</button>' +
                '</div >' +
                `for (int i = 0; i < ${JsonData.fields.length}; i++)` +
                '{' +
                `if (${JsonData.fields['i'].displayName} != "Date")` +
                '{' +
                `if (${JsonData.fields['i'].possibleValues.length} == 0)` +
                '{' +
                '<div class="form-group">' +
                `<label class="control-label">${JsonData.fields['i'].displayName}</label>` +
                `<input class="form-control data-control ${JsonData.fields['i'].displayName} id="${JsonData.fields['i'].internalName}" value="${JsonData.fields['i'].value}" data-type="${JsonData.fields['i'].fieldType.stringify}" />` +
                '</div>' +
                '}' +
                'else' +
                '{' +
                '<div class="form-group">' +
                `${JsonData.fields['i'].displayName}` +
                `<select id="${JsonData.fields['i'].internalName}" class="form-control data-control ${JsonData.fields['i'].displayName}">` +
                '<option selected></option>' +
                `for (int j = 0; j < ${JsonData.fields['i'].possibleValues.length}; j++)` +
                '{' +
                `<option value="${JsonData.fields['i'].possibleValues['j']}">${JsonData.fields['i'].possibleValues['j']}</option>` +
                '}' +
                '</select>' +
                '</div>' +
                '}}}' +
                '<div class="form-group">' +
                '< input style = "width:318px;" id = "btnGet" type = "submit" value = "Search" class="btn btn-primary" />' +
                '</div >' +
                '</form >';
            $('.search').append(formByTheNewModel);
        }
    });
}

function DeleteModel(modelName) {
    var NameOfModel = {};
    NameOfModel.name = modelName;
    $.ajax({
        type: 'POST',
        url: '/DeleteModel',
        data: JSON.stringify(NameOfModel),
        contentType: 'application/json',
        success: function (JsonData) {
            FillAllModels();
        }
    });
}