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
                div.append(`<div onclick="ConfirmDeleteModel('${ JsonData[i].name }')" class="delete-model-button">❌</div>`)
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
            var form = $("<form></form>").attr('id', "form");
            var firstDivOfSearch = $("<div></div>").addClass("search-form-top-row");
            var headerOfTheSearch = $("<h2></h2>").text("Search");
            var resetButton = $("<button></button>").attr('type', "reset").addClass("clear-search-form-button").text("Reset");
            firstDivOfSearch.append(headerOfTheSearch);
            firstDivOfSearch.append(resetButton);
            form.append(firstDivOfSearch);
            for (var i = 0; i < JsonData.fields.length; i++) {
                if (JsonData.fields[i].displayName != "Date") {
                    if (JsonData.fields[i].possibleValues.length == 0) {
                        var divForField = $("<div></div>").addClass("form-group");
                        var labelForField = $("<label></label>").addClass("control-label").text(JsonData.fields[i].displayName);
                        var inputForField = $("<input></input>").addClass("form-control data-control").addClass(JsonData.fields[i].displayName).attr('id', JsonData.fields[i].internalName).attr('data-type', JsonData.fields[i].fieldType.stringify).attr('value', JsonData.fields[i].value);
                        divForField.append(labelForField);
                        divForField.append(inputForField);
                        form.append(divForField);
                    }
                    else {
                        var divForField = $("<div></div>").addClass("form-group");
                        var labelForField = $("<label></label>").addClass("control-label").text(JsonData.fields[i].displayName);
                        var selectForField = $("<select></select>").addClass("form-control data-control").addClass(JsonData.fields[i].displayName).attr('id', JsonData.fields[i].internalName);
                        var emptyOptionForField = $("<option selected></option>");
                        selectForField.append(emptyOptionForField);
                        divForField.append(labelForField);
                        
                        for (var j = 0; j < JsonData.fields[i].possibleValues.length; j++) {
                            var optionForField = $("<option></option>").attr('value', JsonData.fields[i].possibleValues[j]).text(JsonData.fields[i].possibleValues[j]);
                            selectForField.append(optionForField);
                        }
                        divForField.append(selectForField);
                        form.append(divForField);
                    }
                }
            }
            var SubmitDiv = $("<div></div>").addClass("form-group");
            var SubmitInput = $("<input></input>").addClass("btn btn-primary").attr('value', "Search").attr('type', "submit").attr('id', "btnGet").attr('style', "width:318px;");
            SubmitDiv.append(SubmitInput);
            form.append(SubmitDiv);
            $('.search').append(form);

/*
                '<div class="form-group">' +
                '< input style = "width:318px;" id = "btnGet" type = "submit" value = "Search" class="btn btn-primary" />' +
                '</div >' +
                '</form >';
            $('.search').append(formByTheNewModel);
        */}
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

function ChooseAsDisplayedModel(modelName) {
    var NameOfModel = {};
    NameOfModel.name = modelName;
    $.ajax({
        type: 'POST',
        url: '/DispayModels',
        data: JSON.stringify(NameOfModel),
        contentType: 'application/json',
        success: function (JsonData) {

        }
    });
}

function ShowCreateModelForm() {
    $('.create-model-form').css('display', 'flex');
}

function Confirm(title, msg, $true, $false, modelName) {
    var $content = "<div class='dialog-ovelay'>" +
        "<div class='dialog'><header>" +
        " <h3> " + title + " </h3> " +
        "<i class='fa fa-close'></i>" +
        "</header>" +
        "<div class='dialog-msg'>" +
        " <p> " + msg + " </p> " +
        "</div>" +
        "<footer>" +
        "<div class='controls'>" +
        " <button class='button button-danger doAction'>" + $true + "</button> " +
        " <button class='button button-default cancelAction'>" + $false + "</button> " +
        "</div>" +
        "</footer>" +
        "</div>" +
        "</div>";
    $('body').prepend($content);
    $('.doAction').click(function () {
        $(this).parents('.dialog-ovelay').fadeOut(500, function () {
            $(this).remove();
        });
        DeleteModel(modelName)
    });
    $('.cancelAction, .fa-close').click(function () {
        $(this).parents('.dialog-ovelay').fadeOut(500, function () {
            $(this).remove();
        });
    });
}

function ConfirmDeleteModel(modelName) {
    Confirm('Delete Model', 'Are you sure you want to DELETE this model PERMANENTLY', 'Yes', 'Cancel', modelName);
}
