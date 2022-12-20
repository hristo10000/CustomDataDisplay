function showView(viewName) {
    $('.view').hide();
    $('#' + viewName).show();
    HideSelectedModelForEditingName();
    ResetForm();
    HideModelForm();
}
