function AddTextColumn() {
    var textColumn = '<div class="field-column-input">' +
        '<input type="text" class="new-model-dispay-name" for="new-model-dispay-name" placeholder="Display Name"/>' +
        '<input type="text" class="new-model-internal-name" for="new-model-internal-name" placeholder="Internal Name"/>' +
        '</div>';
    $('.added-columns-list').append(textColumn);
}