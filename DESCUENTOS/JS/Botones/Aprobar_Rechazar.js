ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btnconfirm", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar) {
        alt = 100;
        ancho = 300;
        $("#lblpregunta").text("Aprobar");
        ClassDataAccess.OpenWindows("#div-confirmacion", "Confirmación :", alt, ancho);
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

}
);
ClassDataAccess.Events("#btnreject", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar) {
        alt = 100;
        ancho = 300;
        $("#lblpregunta").text("Rechazar")
        ClassDataAccess.OpenWindows("#div-confirmacion", "Confirmación :", alt, ancho);
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

}
);

ClassDataAccess.Events("#btn-clean", "click", function () {
    ClassDataAccess.LimpiarCampos("[required]")
});

ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    $("#lblmessage").text("");
    ClassDataAccess.LimpiarCampos("[required]");
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
});

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});