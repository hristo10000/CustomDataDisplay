﻿var isCustomContextMenuOpened = false;
var isCustomContextMenuFillInTableOptionSelected = false;
var currentRightClickedElementClass;
var isUseInSearchOptionDisabled = false;

$("table").mousedown(function (ev) {
    if (ev.which == 3) {
        currentRightClickedElementClass = ev.target;
        if (ev.target.classList[0] == "row-number" || ev.target.classList[0] == "Date" || ev.target.parentElement.classList[0] != "data-row") {
            $(".contextMenuOptionFillInTable").addClass("unavailable-option");
            isUseInSearchOptionDisabled = true;
        } else {
            $(".contextMenuOptionFillInTable").removeClass("unavailable-option");
        isUseInSearchOptionDisabled = false;
        }
        $(".custom-context-menu-wrapper").css("display", "block");
        console.log("mouse X:", mouseX(ev))
        console.log("window width:", window.innerWidth)
        console.log("menu width:", $(".contextMenu").width())
        console.log(mouseX(ev) + $(".contextMenu").width(), window.innerWidth)
        //console.log("mouse Y:", mouseY(ev))
        //console.log("window height:", window.innerHeight)
        if (mouseX(ev) + $(".contextMenu").width() > window.innerWidth) {
            console.log("too much to the left");
            $(".contextMenu").css("left", mouseX(ev) - $(".contextMenu").width());
        } else {
            $(".contextMenu").css("left", mouseX(ev));
        }
        if (mouseY(ev) + $(".contextMenu").height() > window.innerHeight) {
            console.log("too much to the bottom");
            $(".contextMenu").css("top", mouseY(ev) - $(".contextMenu").height());
        } else {
            $(".contextMenu").css("top", mouseY(ev));
        }
        isCustomContextMenuOpened = true;
    }
});

$("html").mousedown(function (ev) {
    if (ev.which != 1) return;
    switch (ev.target.classList[1]) {
        case "contextMenuOptionFillInTable":
            if (ev.which == 1) {
                isCustomContextMenuFillInTableOptionSelected = true;
                $(currentRightClickedElementClass).click();

            }
            break;
        case "contextMenuOptionGoToTheTop":
            if (ev.which == 1) {
                window.scrollTo(0, 0);
            }
            break;
        default:
            break;
    }
    $(".custom-context-menu-wrapper").css("display", "none");
    isCustomContextMenuOpened = false;
});

function CtrlSelectFromTable(value, columnName) {
    if (isCustomContextMenuFillInTableOptionSelected || event.ctrlKey) {
        document.querySelector(`.${columnName}`).value = value;
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

function NavigateToTop(e) {
    var evtobj = window.event ? event : e
    if (evtobj.keyCode == 38 && evtobj.ctrlKey) window.scrollTo(0, 0);;
}
