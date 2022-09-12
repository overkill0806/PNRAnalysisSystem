function LoadRoute(route) {
    $('#contentpage').load(route);
} 
function LoadTable(target, route) {
    $('#' + target).load(route);
}
function PopActive(pop_content, page) {
    if (pop_content != undefined || pop_content != '') {
        if (page != undefined)
            $('#pop-content').html(pop_content);
        else
            $('#pop-content').load(pop_content);
    }
    $('#varPop').modal('show');
}
function PopDisActive() {
    $('#varPop').modal('hide');
}
window.onclick = function (event) {
    var modal = document.getElementById("varPop");
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


