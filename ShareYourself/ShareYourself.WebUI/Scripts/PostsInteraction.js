function getPostsCountOnThePage() {
    return $('.post-element').length;
}

function inputSkipInit(id) {
    $("#" + id).val(getPostsCountOnThePage());
}

function showNextPostsFormOnSuccess(data) {
    if (data == "") {
        $('#show-next-posts-form-container').hide();
    }
}

function showElement(id) {
    $('#' + id).show();
}