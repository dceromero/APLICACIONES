
function AccesosDatos() {

}
AccesosDatos.prototype.Ajax = function (url, datos, funcion) {
    $.ajax({
        type: "POST",
        url: url,
        data: datos,
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: funcion
    }).done()
}



AccesosDatos.prototype.Events = function (id, evento, funcion) {
    $("body").on(evento, id, funcion);
}

AccesosDatos.prototype.CloseWindows = function (selector) {
    var dialog = $(selector).data("kendoWindow");
    dialog.close();
}

AccesosDatos.prototype.OpenWindows = function (selector, titulo, altura, ancho) {
    $(selector).kendoWindow({
        modal: true,
        height: altura,
        title: titulo,
        visible: true,
        width: ancho
    });
    formfind = $(selector).data("kendoWindow");
    formfind.center();
    formfind.open();
}

AccesosDatos.prototype.Grilla = function (selector, datos, ArrayColumna) {
    $(selector).kendoGrid({
        dataSource: datos,
        groupable: false,
        sortable: true,
        filterable: {
            messages: {
                info: "Mostrar items que:",
                filter: "Aplicar",
                clear: "Borrar"
            },
            extra: false,
            operators: {
                string: {
                    contains: "Contiene",
                    doesnotcontain: "No contiene",
                    startswith: "Comienza con",
                    eq: "Es igual a",
                    neq: "No es igual a",
                    gte: "Mayor o igual a"
                }
            }
        },
        pageable: {
            refresh: true,
            pageSizes: true
        },
        columns: ArrayColumna
    });
}

AccesosDatos.prototype.Upload = function (selector, script, namebutton) {
    /*----------------------Uploadify----------------------*/
    $(selector).uploadify({
        'FILESIZELIMIT': '0',
        'uploader': '../../css/Flash/uploadify.swf',
        'script': script,
        'cancelImg': '../../css/Flash/cancel.png',
        'folder': '../../Documentos',
        'fileDesc': '*.*',
        'fileExt': '*.*',
        'auto': false,
        'multi': true,
        'buttonText': namebutton
    })
    /*------------------------------------------------------*/
}

AccesosDatos.prototype.ValidarCampos = function (control) {
    validar = true;
    $(control).each(function (key, element) {
        if (element.nodeName != "SPAN") {
            if ($(element).val() == "-1" || $(element).val() == "") {
                validar = false;
            }
        }

    });
    return validar
}

AccesosDatos.prototype.LimpiarCampos = function (control) {
    $(control).each(function (key, element) {
        if (element.nodeName == "SELECT") {
            $(element).val("-1");
        } else {
            $(element).val("");
        }
    });
}