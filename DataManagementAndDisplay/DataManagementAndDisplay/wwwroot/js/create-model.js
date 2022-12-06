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
        for (var j = 0; j < field.children.length; j++) {     
            var input = field.children[j].value;
            if (j == 0) {
                Model.Fields[i].DisplayName = input;
            } else if (j == 1) {
                Model.Fields[i].InternalName = input;
            } else if (j == 2) { 
                input = field.children[j];
                Model.Fields[i].PossibleValues = []; 
                for (var k = 1; k < input.children.length; k++) {
                    value = input.children[k].value;
                    Model.Fields[i].PossibleValues[Model.Fields[i].PossibleValues.length] = {};
                    Model.Fields[i].PossibleValues[Model.Fields[i].PossibleValues.length - 1].PossibleOptionValue = value;
                }
            }
            else {
                Model.Fields[i].PossibleValues[Model.Fields[i].PossibleValues.length] = {};
                Model.Fields[i].PossibleValues[Model.Fields[i].PossibleValues.length - 1].PossibleOptionValue = input;
            }
        }
        HideModelForm();
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
    var divForTextColumn = $('<div></div>').addClass('field-column-input').attr('id', `field-column-input${numberOfFields}`);
    var inputForDisplayName = $('<input></input>').addClass('new-model-dispay-name').attr('type', 'text').attr('placeholder', 'Display Name').attr('required', '');
    var inputForInternalName = $('<input></input>').addClass('new-model-internal-name').attr('type', 'text').attr('placeholder', 'Internal Name');
    var divForNewColumn = $('<div></div>').addClass('add-new-enum-column').attr('id', `add-new-enum-column${numberOfFields}`).attr('onclick', 'AddOptionValues(this.id)').text('+ Add possible values');
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
    var divForValues = $('<div></div>').addClass('values-list').attr('id', `values-list-${id}`);
    var divForNewValue = $('<div></div>').addClass('add-new-enum-column').attr('id', `add-new-option-${idOfDiv}`).attr('onclick', 'AddNewOption(this.id)').text('+ Add a possible value');
    var inputForValue = $('<input></input>').addClass('new-model-value').attr('type', 'text').attr('placeholder', 'Value').attr('required', '');
    divForValues.append(divForNewValue);
    divForValues.append(inputForValue);
    div.append(divForValues);
}

function AddNewOption(id) {
    var button = $(`#${id}`);
    var div = button.parent();
    var inputForValue = $('<input></input>').addClass('new-model-value').attr('type', 'text').attr('placeholder', 'Value');
    div.append(inputForValue);
}

function ResetForm() {
    var form = $('#create-model-form').empty();
    var divForNameAndDescription = $('<div></div>').addClass('create-model-form-element-for-name-and-password');
    var inputForName = $('<input></input>').addClass('new-model-name').attr('type', 'text').attr('placeholder', 'Name').attr('required', '');
    var inputForDescription = $('<input></input>').addClass('new-model-description').attr('type', 'text').attr('placeholder', 'Description').attr('required', '');
    var resetButton = $('<button></button>').attr('type', 'button').addClass('clear-create-model-form-button').attr('onclick', 'ConfirmResetModelForm("Reset Form", "Are you sure you want to COMPLETELY RESET this form? This action CANNOT be undone!", "Confirm", "Cancel")').text('Reset');
    var resetButtonDiv = $('<div></div>');
    resetButtonDiv.append(resetButton);
    divForNameAndDescription.append(inputForName);
    divForNameAndDescription.append(inputForDescription);
    form.append(divForNameAndDescription);
    var divForCreateFields = $('<div></div>').addClass('create-model-form-element-for-custom-fields');
    var divForAddedColumns = $('<div></div>').addClass('added-columns-list');
    var divForNewTextColumn = $('<div></div>').addClass('add-new-text-column').attr('onclick', 'AddTextColumn()').text('+ New Column');
    var inputForSubmit = $('<input></input>').attr('type', 'submit').attr('value', 'Create Model').addClass('submit-button-for-create-model');
    divForCreateFields.append(divForAddedColumns);
    divForCreateFields.append(divForNewTextColumn);
    form.append(divForCreateFields);
    form.append(inputForSubmit);
    form.append(resetButtonDiv);
}

function EditModel() {
    var form = $('#create-model-form').empty();
    var divForNameAndDescription = $('<div></div>').addClass('create-model-form-element-for-name-and-password');
    var inputForName = $('<input></input>').addClass('new-model-name').attr('type', 'text').attr('placeholder', 'Name').attr('required', '');
    var inputForDescription = $('<input></input>').addClass('new-model-description').attr('type', 'text').attr('placeholder', 'Description').attr('required', '');
    divForNameAndDescription.append(inputForName);
    divForNameAndDescription.append(inputForDescription);
    form.append(divForNameAndDescription);
    var divForCreateFields = $('<div></div>').addClass('create-model-form-element-for-custom-fields');
    var divForAddedColumns = $('<div></div>').addClass('added-columns-list');
    var divForNewTextColumn = $('<div></div>').addClass('add-new-text-column').attr('onclick', 'AddTextColumn()').text('+ New Column');
    var inputForSubmit = $('<input></input>').attr('type', 'submit').attr('value', 'Save Changes').addClass('submit-button-for-create-model');
    divForCreateFields.append(divForAddedColumns);
    divForCreateFields.append(divForNewTextColumn);
    form.append(divForCreateFields);
    form.append(inputForSubmit);
}

function ConfirmResetModelForm(title, msg, $true, $false) {
    var mainDiv = $('<div></div>').addClass('dialog-ovelay');
    var dialogDiv = $('<div></div>').addClass('dialog');
    var header = $('<header></header>');
    var h3 = $('<h3></h3>').text(title);
    var i = $('<i></i>').addClass('fa fa-close');
    header.append(i);
    header.append(h3);
    dialogDiv.append(header);
    var div = $('<div></div>').addClass('dialog-msg');
    var p = $('<p></p>').text(msg);
    div.append(p);
    dialogDiv.append(div);
    var footer = $('<footer></footer>');
    var divInFooter = $('<div></div>').addClass('controls');
    var firstButton = $('<button></button>').addClass('button button-danger doAction btnEnable').attr('type', 'button').text($true);
    var secondButton = $('<button></button>').addClass('button button-default cancelAction').attr('type', 'button').text($false);
    divInFooter.append(firstButton);
    divInFooter.append(secondButton);
    footer.append(divInFooter);
    dialogDiv.append(footer);
    mainDiv.append(dialogDiv);
    $('body').prepend(mainDiv);
    $('.doAction').click(function () {
        $(this).parents('.dialog-ovelay').fadeOut(500, function () {
            $(this).remove();
        });
        ResetForm();
    });
    $('.cancelAction, .fa-close').click(function () {
        $(this).parents('.dialog-ovelay').fadeOut(500, function () {
            $(this).remove();
        });
    });
}
