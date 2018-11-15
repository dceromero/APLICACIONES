
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

AccesosDatos.prototype.Events.Blur = function (selector,selectorhidden) {
    $("body").on("blur", selector, function () {
        if ($(selectorhidden).val() == "") {
            $(selector).val("");
        }
    });
}

AccesosDatos.prototype.Events.BlurSoloNumeros = function (selector) {
    $("body").on("blur", selector, function () {
        validar = parseInt($(this).val());
        if (validar.toString() == "NaN") {
            $(this).val("")
        }
    });
}

AccesosDatos.prototype.Events.BlurEmail = function () {
    $("body").on("blur", '[type="email"]', function () {
        emailRegex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
        //Se muestra un texto a modo de ejemplo, luego va a ser un icono
        if (!emailRegex.test($(this).val())) {
            $(this).val("")
        }
    });
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

AccesosDatos.prototype.refreshGrilla = function (selector) {
    $(selector).data('kendoGrid').dataSource.read();
    $(selector).data("kendoGrid").refresh();
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

AccesosDatos.prototype.Combox = function (selector,datasources, displayId, displayMember) {
    $(selector).html("").append("<option value='-1'>Seleccione</option>");    
    for (var x in datasources) {
        $(selector).append("<option value='" + datasources[x][displayId] + "'>" + datasources[x][displayMember] + "</option>");
    }
}

AccesosDatos.prototype.AutoComplete = function (selector, datasources, displayId, displayMember,selectorhidden) {
    $(selector).kendoAutoComplete({
        filter: "contains",
        dataSource: datasources,
        dataTextField: displayMember,
        dataValueField: displayId,
        select: function (e) {
            item = e.item;
            DataItem = this.dataItem(e.item.index());
            $(selectorhidden).val(DataItem[displayId])
        }
    });
}

AccesosDatos.prototype.AutoCompletePersonalizado = function (selector, datasources, displayId, displayMember, funcion) {
    $(selector).kendoAutoComplete({
        filter: "contains",
        dataSource: datasources,
        dataTextField: displayMember,
        dataValueField: displayId,
        select: funcion
    });
}