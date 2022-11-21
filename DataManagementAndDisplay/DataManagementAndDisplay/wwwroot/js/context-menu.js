var isCustomContextMenuOpened = false;
var isCustomContextMenuFillInTableOptionSelected = false;
var isUseInSearchOptionDisabled = false;
var targetTableCell;

$('table').mousedown(function (ev) {
    if (ev.which != 3) return;
    targetTableCell = ev.target;
    $(targetTableCell).addClass('current-target-for-context-menu');
    if (ev.target.classList[0] == 'row-number' || ev.target.classList[0] == 'Date' || ev.target.parentElement.classList[0] != 'data-row') {
        $('.context-menu-option-fill-in-table').addClass('unavailable-option');
        isUseInSearchOptionDisabled = true;
    } else {
        $('.context-menu-option-fill-in-table').removeClass('unavailable-option');
    isUseInSearchOptionDisabled = false;
    }
    $('.custom-context-menu-wrapper').css('display', 'block');
    $('.custom-context-menu-wrapper').css('height', $('.main-wrapper-from-mcs').height());
    if (mouseX(ev) + $('.context-menu').width() > window.innerWidth + document.documentElement.scrollLeft) {
        $('.context-menu').css('left', mouseX(ev) - $('.context-menu').width());
    } else {
        $('.context-menu').css('left', mouseX(ev));
    }
    console.log(window.innerHeight, document.documentElement.scrollTop);
    if (mouseY(ev) + $('.context-menu').height() > window.innerHeight + document.documentElement.scrollTop) {
        $('.context-menu').css('top', mouseY(ev) - $('.context-menu').height());
    } else {
        $('.context-menu').css('top', mouseY(ev));
    }
    isCustomContextMenuOpened = true;
});

function CtrlSelectFromTable(value, columnName) {
    if (isCustomContextMenuFillInTableOptionSelected || event.ctrlKey) {
        document.querySelector(`.${columnName}`).value = value;
        isCustomContextMenuFillInTableOptionSelected = false;
    }
}

function mouseX(evt) {
    return evt.clientX - document.documentElement.scrollLeft;
}

function mouseY(evt) {
    return evt.clientY + document.documentElement.scrollTop;
}

function NavigateToTop(e) {
    var evtobj = window.event ? event : e
    if (evtobj.keyCode == 38 && evtobj.ctrlKey) window.scrollTo(0, 0);;
}

addEventListener('scroll', (event) => {
    if (isCustomContextMenuOpened) {
        $('.custom-context-menu-wrapper').css('display', 'none');
        $(targetTableCell).removeClass('current-target-for-context-menu');
        isCustomContextMenuOpened = false;
    }
});