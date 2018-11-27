ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btnconfirm", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar && myarray.length >= 1) {
        ClassDataAccess.OpenWindows("#div-confirmacion", "Confirmación :", 120, 300);
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})

ClassDataAccess.Events("#btn-clean", "click", function () {
    ClassDataAccess.LimpiarCampos("[required]")
})

ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion")
})

ClassDataAccess.Events("#btn-close-message", "click", function () {
    $("#lblmessage").text("");
    ClassDataAccess.LimpiarCampos("[required]");
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
})