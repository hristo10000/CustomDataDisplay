function AddTextColumn() {
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
    var textColumn = '<input type="text" class="new-model-dispay-name" for="new-model-dispay-name" placeholder="Value"/>' +
        '<div id="add-new-option" class="add-new-option" onclick="AddNewOption()">+</div>';
    $('.field-column-input').last().append(textColumn);
}
function AddNewOption() {
    var buttonToRemove = document.getElementsByClassName('add-new-option');
    buttonToRemove[buttonToRemove.length - 1].remove();
    var textColumn = '<input type="text" class="new-model-dispay-name" for="new-model-dispay-name" placeholder="Value"/>' +
        '<div id="add-new-option" class="add-new-option" onclick="AddNewOption()">+</div>';
    $('.field-column-input').last().append(textColumn);
}