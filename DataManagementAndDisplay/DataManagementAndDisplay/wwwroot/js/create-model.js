var numberOfFields = 0;
$(document).ready(function () {
    $('#create-model-form').submit(function (event) {
        event.preventDefault();
        CreateModel();
    });
});

function CreateModel() {
    var Model = {};
    Model.Name = event.currentTarget[0].value;
    Model.Description = event.currentTarget[1].value;
    Model.Fields = [];
    var inputs = $('.field-column-input')
    for (var i = 0; i < inputs.length; i++) {
        var field = inputs[i];  
        Model.Fields[i] = {};
        for (var j = 0; j < field.children.length - 1; j++) {     
            var input = field.children[j].value;
            if (j == 0) {
                Model.Fields[i].DisplayName = input;
            } else if (j == 1) {
                Model.Fields[i].InternalName = input;
            } else if (j == 2) {
                Model.Fields[i].PossibleValues = [];
                Model.Fields[i].PossibleValues[0] = {};
                Model.Fields[i].PossibleValues[0].PossibleOptionValue = input;
            }
            else {
                Model.Fields[i].PossibleValues[Model.Fields[i].PossibleValues.length] = {};
                Model.Fields[i].PossibleValues[Model.Fields[i].PossibleValues.length - 1].PossibleOptionValue = input;
            }
        }
    }
    
    var form_data = Model;
    $.ajax({
        type: 'POST',
        url: '/CreateModel',
        data: JSON.stringify(form_data),
        contentType: 'application/json',
        success: function (JsonData) {
            FillAllModels();
        }
    });
}

function AddTextColumn() {
    numberOfFields = $('.field-column-input').length;
    var divForTextColumn = $('<div></div>').addClass("field-column-input").attr("id", `field-column-input${numberOfFields}`);
    var inputForDisplayName = $('<input></input>').addClass("new-model-dispay-name").attr("type", "text").attr("placeholder", "Display Name");
    var inputForInternalName = $('<input></input>').addClass("new-model-internal-name").attr("type", "text").attr("placeholder", "Internal Name");
    var divForNewColumn = $('<div></div>').addClass("add-new-enum-column").attr("id", `add-new-enum-column${numberOfFields}`).attr("onclick", "AddOptionValues(this.id)").text("+ Add Possible Values");
    divForTextColumn.append(inputForDisplayName);
    divForTextColumn.append(inputForInternalName);
    divForTextColumn.append(divForNewColumn);
    $('.added-columns-list').append(divForTextColumn);
}

function AddOptionValues(id) {
    var button = $(`#${id}`);
    var div = button.parent();
    var idOfDiv = div.attr('id')
    button.remove();
    var divForValues = $('<div></div>').addClass("values-list").attr("id", `values-list-${id}`);
    var divForNewValue = $('<div></div>').addClass("add-new-enum-column").attr("id", `add-new-option-${idOfDiv}`).attr("onclick", "AddNewOption(this.id)").text("+");
    var inputForValue = $('<input></input>').addClass("new-model-value").attr("type", "text").attr("placeholder", "Value").attr('required', '');
    divForValues.append(divForNewValue);
    divForValues.append(inputForValue);
    div.append(divForValues);
}

function AddNewOption(id) {
    var button = $(`#${id}`);
    var div = button.parent();
    var inputForValue = $('<input></input>').addClass("new-model-value").attr("type", "text").attr("placeholder", "Value");
    div.append(inputForValue);
}
function ResetForm() {
    $('#create-model-form').trigger("reset");
}
