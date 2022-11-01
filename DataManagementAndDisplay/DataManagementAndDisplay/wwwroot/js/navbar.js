var isNavbarOpen = false;
var eventIndex = 0;

$("html").mousedown(function (ev) {
    if (eventIndex == 1) {
        eventIndex = 0;
        return;
    }
    if (isNavbarOpen) {
        switch (ev.target.classList[1]) {
            case "navbar-option-view-model":
                if (ev.which == 1) showView('page1');
                break;
            case "navbar-option-create-model":
                if (ev.which == 1) {
                    showView('page2');
                    GetAllModels();
                }
                break;
            default:
                break;
        }
        $(".navbar").css("display", "none");
        $(".navbar-button").css("display", "flex");
        isNavbarOpen = false;
    } else if (isCustomContextMenuOpened && ev.which == 1) {
        switch (ev.target.classList[1]) {
            case "contextMenuOptionFillInTable":
                    isCustomContextMenuFillInTableOptionSelected = true;
                    $(targetTableCell).click();
                break;
            case "contextMenuOptionGoToTheTop":
                window.scrollTo(0, 0);
                break;
            default:
                break;
        }
        $(".custom-context-menu-wrapper").css("display", "none");
        $(targetTableCell).removeClass("current-target-for-context-menu");
        isCustomContextMenuOpened = false;
    }
});

$(".navbar-button").mousedown(function (ev) {
    if (ev.which != 1) return;
    $(".navbar-button").css("display", "none");
    $(".navbar").css("display", "flex");
    isNavbarOpen = true;
    eventIndex = 1;
});
