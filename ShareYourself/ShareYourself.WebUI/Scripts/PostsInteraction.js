function getPostsCountOnThePage() {
    return $('.post-element').length;
}

function inputSkipInit(id) {
    $("#" + id).val(getPostsCountOnThePage());
}

function showNextPostsFormOnSuccess(data) {
    /*if (data == "" || data == null) {
        var element = $('#showNextPostsSpan');
        element.removeClass('glyphicon-chevron-down');
        element.addClass('glyphicon-remove');
    } */
}

function showElement(id) {
    $('#' + id).show();
}

function addClass(id, className) {
    $('#' + id).addClass(className);
}

function removeClass(id, className) {
    $('#' + id).removeClass(className);
}

    


