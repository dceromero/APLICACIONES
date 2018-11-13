ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btnsave", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar && myarray.length >= 1) {
        ClassDataAccess.OpenWindows("#div-confirmacion", "Confirmacion :", 100, 300);
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