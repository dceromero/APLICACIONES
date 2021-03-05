ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btnconfirm", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    urlactual = window.location.href.toString().split("/");
    if (urlactual[3] == "LogInventario") {
        myarray = $(".plupload_upload_status").text();
        if (validar && myarray >= 1) {
            div = urlactual[4] == "Autorizacion" || urlactual[4] == "AutorizacionCanal" ? "#div-confirmacion-aprob" : "#div-confirmacion";
            alt = 0;
            ancho = 0;
            if (urlactual[4] == "Autorizacion" || urlactual[4] == "AutorizacionCanal") {
                alt = 200;
                ancho = 400;
            } else {
                alt = 100;
                ancho = 300;
            }
            ClassDataAccess.OpenWindows(div, "Confirmación :", alt, ancho);
        } else {
            ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
        }
    } else {
        if (validar && myarray.length >= 1) {
            div = urlactual[4] == "Autorizacion" || urlactual[4] == "AutorizacionCanal" ? "#div-confirmacion-aprob" : "#div-confirmacion";
            alt = 0;
            ancho = 0;
            if (urlactual[4] == "Autorizacion" || urlactual[4] == "AutorizacionCanal") {
                alt = 200;
                ancho = 400;
            } else {
                alt = 100;
                ancho = 300;
            }
            ClassDataAccess.OpenWindows(div, "Confirmación :", alt, ancho);
        } else {
            ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
        }

    }
    
});

ClassDataAccess.Events("#btn-clean", "click", function () {
    ClassDataAccess.LimpiarCampos("[required]")
});

ClassDataAccess.Events("#btncancel", "click", function () {
    urlactual = window.location.href.toString().split("/");
    div = urlactual[4] == "Autorizacion" || urlactual[4] == "AutorizacionCanal" ? "#div-confirmacion-aprob" : "#div-confirmacion";
    ClassDataAccess.CloseWindows(div);
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    $("#lblmessage").text("");
    ClassDataAccess.LimpiarCampos("[required]");
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
});

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});