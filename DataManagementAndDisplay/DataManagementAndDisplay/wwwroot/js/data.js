var currentlyDisplayedModelName;
var currentlyDisplayedModelNameForPage2;
var sec = 5;

$(document).ready(function () {
    document.onkeydown = NavigateToTop;
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
                div.append(`<div onclick="ConfirmDeleteModel('${JsonData[i].name}')" class="delete-model-button">❌</div>
                            <audio id="alarm" src="/audios/alarm.mp3"></audio>`)
                AppendToDiv.append(div);
            }
        }  
    });
}

function PlayErrorSound() {
    var audio = document.getElementById("alarm");
    audio.loop = true;
    audio.play();
}

function StopAlarm() {
    var audio = document.getElementById("alarm");
    audio.pause();
    audio.currentTime = 0;
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
    if (!NameOfModel.name) {
        return;
    }
    $.ajax({
        type: 'POST',
        url: '/DispayModels',
        data: JSON.stringify(NameOfModel),
        contentType: 'application/json',
        success: function (JsonData) {
            console.log(JsonData);
            SearchMenu = $(".search").empty();
            var form = $("<div></div>").attr('id', "form");
            var firstDivOfSearch = $("<div></div>").addClass("search-form-top-row");
            var headerOfTheSearch = $("<h2></h2>").text("Search");
            var resetButton = $("<button></button>").attr('type', "reset").addClass("clear-search-form-button").text("Reset");
            firstDivOfSearch.append(headerOfTheSearch);
            firstDivOfSearch.append(resetButton);
            form.append(firstDivOfSearch);
            var DivWithTimestamps = $("<div></div>").addClass("form-group");
            var labelForField = $("<label></label>").text(JsonData.timeField.displayName);
            var selectForField = $("<select></select>").addClass("form-control time-control").attr('id', JsonData.timeField.internalName);
            var emptyOptionForTimestamp = $("<option selected></option>");
            selectForField.append(emptyOptionForTimestamp);
            for (var i = 0; i < JsonData.timestamps.length; i++)
            {
                var optionForTimestamps = $("<option></option>").attr('value', JsonData.timestamps[i].internalName).text(JsonData.timestamps[i].displayName);
                selectForField.append(optionForTimestamps);
            }
            DivWithTimestamps.append(labelForField);
            DivWithTimestamps.append(selectForField);
            form.append(DivWithTimestamps);
            
            for (var i = 0; i < JsonData.fields.length; i++) {
                if (JsonData.fields[i].displayName != "Date") {
                    if (JsonData.fields[i].possibleValues.length == 0) {
                        var divForField = $("<div></div>").addClass("form-group");
                        var labelForField = $("<label></label>").addClass("control-label").text(JsonData.fields[i].displayName);
                        var inputForField = $(`<input data-type="String"></input>`).addClass("form-control data-control").addClass(JsonData.fields[i].displayName).attr({ id: JsonData.fields[i].internalName, type: JsonData.fields[i].fieldType.stringify, value: JsonData.fields[i].value });
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
                            var optionForField = $("<option></option>").attr('value', JsonData.fields[i].possibleValues[j].possibleOptionValue).text(JsonData.fields[i].possibleValues[j].possibleOptionValue);
                            selectForField.append(optionForField);
                        }
                        divForField.append(selectForField);
                        form.append(divForField);
                    }
                }
            }
            var SubmitDiv = $("<div></div>").addClass("form-group");
            var SubmitInput = $("<input></input>").addClass("btn btn-primary").attr('value', "Search").attr('type', "submit").attr('id', "btnGet").attr('style', "width:318px;");
            SubmitInput.click(function (event) {
                event.preventDefault();
                SearchAndDisplay();
            });
            SubmitDiv.append(SubmitInput);
            form.append(SubmitDiv);
            $('.search').append(form);
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
    var $content = '<div class="dialog-ovelay">' +
        '<div class="dialog"><header>' +
        '<h3>' + title + '</h3>' +
        '<i class="fa fa-close"></i>' +
        '</header>' +
        '<div class="dialog-msg">' +
        '<p>' + msg + '</p>' +
        '</div>' +
        '<footer>' +
        '<div class="controls">' +
        '   <button class="button button-danger doAction btnDisable" type="button" disabled>' + $true + '</button> ' +
        '   <button class="button button-default cancelAction">' + $false + '</button> ' +
        '</div>' +
        '</footer>' +
        '</div>' +
        '</div>';
    $('body').prepend($content);
    countDown();
    $('.doAction').click(function () {
        $(this).parents('.dialog-ovelay').fadeOut(500, function () {
            $(this).remove();
        });
        DeleteModel(modelName)
        StopAlarm();
        sec = 5;
        $('.doAction').removeClass('btnEnable').addClass('btnDisable');
    });
    $('.cancelAction, .fa-close').click(function () {
        $(this).parents('.dialog-ovelay').fadeOut(500, function () {
            $(this).remove();
        });
        StopAlarm();
        sec = 5;
        $('.doAction').removeClass('btnEnable').addClass('btnDisable');
    });
}

function ConfirmDeleteModel(modelName) {
    PlayErrorSound();
    Confirm('Delete Model', 'Are you sure you want to DELETE this model PERMANENTLY?', 'Confirm', 'Cancel', modelName);
}

function countDown() {
    $('.doAction').text(sec);
    if (sec == 0) {
        $('.doAction').removeAttr('disabled');
        $('.doAction').removeClass('btnDisable').addClass('btnEnable');
        $('.doAction').text('Yes');
        return;
    } else {
        sec -= 1;
        window.setTimeout(countDown, 1000);
    }
}

$('body').on('mousedown', '.model-name-button', function (ev) {
    currentlyDisplayedModelNameForPage2 = ev.target.textContent;
    ConfirmSelection('Selected Successfuly',`You selected "${ev.target.textContent}"!`);
});

function ConfirmSelection(title, msg) {
    var $content = '<div class="dialog-ovelay-selection">' +
        '<div class="dialog"><header>' +
        '<h3>' + title + '</h3>' +
        '<i class="fa fa-close"></i>' +
        '</header>' +
        '<div class="dialog-msg">' +
        '<p>' + msg + '</p>' +
        '</div>' +
        '<footer>' +
        '<div class="controls">' +
        '   <button class="button button-default Iknow">I Know</button> ' +
        '</div>' +
        '</footer>' +
        '</div>' +
        '</div>';
    $('body').prepend($content);
    $('.Iknow').click(function () {
        $(this).parents('.dialog-ovelay-selection').fadeOut(500, function () {
            $(this).remove();
        });
    });
}
