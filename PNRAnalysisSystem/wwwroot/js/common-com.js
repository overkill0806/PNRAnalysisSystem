function LoadRoute(route) {
    $('#contentpage').load(route);
} 
function LoadTable(target, route) {
    $('#' + target).load(route);
}
function PopActive(pop_content, page) {
    var modal = document.getElementById("varPop");
    if (pop_content != undefined || pop_content != '') {
        if (page != undefined)
            $('#pop-content').html(pop_content);
        else
            $('#pop-content').load(pop_content);
    }
    modal.style.display = "block";
}
function PopDisActive() {
    var modal = document.getElementById("varPop");
    modal.style.display = "none";
}
window.onclick = function (event) {
    var modal = document.getElementById("varPop");
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


