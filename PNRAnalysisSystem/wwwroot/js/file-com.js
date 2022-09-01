function createCsvFile(filename, csvString) {
    var subfilename = ".csv";
    const csvContent = "data:text/csv;charset=utf-8,\ufeff" + csvString;
    const encodedUri = encodeURI(csvContent);
    const link = document.createElement("a");
    link.setAttribute("href", encodedUri);
    link.setAttribute("download", filename + subfilename);
    document.body.appendChild(link);
    link.click();
}
//DemoFormat
function getRandomData() {
    var header = "第一欄,第二欄,第三欄,第四欄,第五欄\n";
    var data = "";
    for (var i = 0; i < 50; i++) {
        for (var j = 0; j < 5; j++) {
            if (j > 0) {
                data = data + ",";
            }
            data = data + "Item" + i + "_" + j;
        }
        data = data + "\n";
    }
    return header + data;
}

function createTxtFile(filename, txtString) {
    const txtContent = "data:application/octet-stream;charset=utf-16le;base64" + txtString;
    const link = document.createElement("a");
    link.setAttribute("href", txtContent);
    link.setAttribute("download", filename + ".txt");
    document.body.appendChild(link);
    link.click();
} 

function createXmlFile(filename, xmltext) {
    var filename = filename+".xml";
    var link = document.createElement('a');
    var bb = new Blob([xmltext], { type: 'text/plain' });
    link.setAttribute('href', window.URL.createObjectURL(bb));
    link.setAttribute('download', filename);
    link.dataset.downloadurl = ['text/plain', link.download, link.href].join(':');
    link.draggable = true;
    link.classList.add('dragout');
    link.click();
}

function createXlsFile(filename, target) {
    $("#" + target).table2excel({
        exclude: ".noExl",
        name: "Worksheet Name",
        filename: filename,
        fileext: ".xls" 
    });
}