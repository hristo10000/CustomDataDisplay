var numberOfFieldsForNewModel = 0;
localStorage.setItem("isAddedNewModel", false);
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
        dataType: 'json',
        success: function (JsonData) {
            FillAllModels();
        }
    });
}

function AddTextColumn() {
    numberOfFieldsForNewModel;
    var textColumn = '<div class="field-column-input">' +
        '<input type="text" class="new-model-dispay-name" for="new-model-dispay-name" placeholder="Display Name"/>' +
        '<input type="text" class="new-model-internal-name" for="new-model-internal-name" placeholder="Internal Name"/>' +
        '<div id="add-new-enum-column" class="add-new-enum-column" onclick="AddOptionValues()">+ New enum column</div>' +
        '</div>';
    $('.added-columns-list').append(textColumn);
}
function AddOptionValues() {
    var buttonToRemove = document.getElementById('add-new-enum-column');
    buttonToRemove.remove();
    var textColumn = '<input type="text" class="new-model-value" for="new-model-value" placeholder="Value"/>' +
        '<div id="add-new-option" class="add-new-option" onclick="AddNewOption()">+</div>';
    $('.field-column-input').last().append(textColumn);
}
function AddNewOption() {
    var buttonToRemove = document.getElementsByClassName('add-new-option');
    buttonToRemove[buttonToRemove.length - 1].remove();
    var textColumn = '<input type="text" class="new-model-value" for="new-model-value" placeholder="Value"/>' +
        '<div id="add-new-option" class="add-new-option" onclick="AddNewOption()">+</div>';
    $('.field-column-input').last().append(textColumn);
}
