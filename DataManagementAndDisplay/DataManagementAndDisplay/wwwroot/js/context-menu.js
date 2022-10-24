var isCustomContextMenuOpened = false;
var isCustomContextMenuFillInTableOptionSelected = false;
var currentRightClickedElementClass;

$("table").mousedown(function (ev) {
    if (ev.which == 3 && ev.target.classList[0] != "date") {
        currentRightClickedElementClass = ev.target;
        $(".contextMenu").css("display", "block");
        $(".contextMenu").css("top", mouseY(ev));
        $(".contextMenu").css("left", mouseX(ev));
        isCustomContextMenuOpened = true;
    }
});

$(".contextMenuOptionFillInTable").mousedown(function (ev) {
    if (ev.which == 1) {
        isCustomContextMenuFillInTableOptionSelected = true;
        $(currentRightClickedElementClass).click();
    }
});

$("html").mousedown(function (ev) {
    if (ev.which == 1 && isCustomContextMenuOpened == true) {
        $(".contextMenu").css("display", "none");
        isCustomContextMenuOpened = false;
        return;
    }
});

function CtrlSelectFromTable(value, columnName) {
    if (isCustomContextMenuFillInTableOptionSelected || event.ctrlKey) {
        const overlay = document.querySelector(`.${columnName}`).value = value;
        isCustomContextMenuFillInTableOptionSelected = false;
    }
}

function mouseX(evt) {
    if (evt.pageX) {
        return evt.pageX;
    } else if (evt.clientX) {
        return evt.clientX + (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    } else {
        return null;
    }
}

function mouseY(evt) {
    if (evt.pageY) {
        return evt.pageY;
    } else if (evt.clientY) {
        return evt.clientY + (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    } else {
        return null;
    }
}