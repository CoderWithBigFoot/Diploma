function getPostsCountOnThePage() {
    return $('.post-element').length;
}

function inputSkipInit(id) {
    $("#" + id).val(getPostsCountOnThePage());
}

function showNextPostsFormOnSuccess(data) {
    alert(data);
    if (data == "" || data == null) {
        $('#showNextPostsButton').text('<span class="glyphicon glyphicon-remove"></span>');
    }
}

function showElement(id) {
    $('#' + id).show();
}