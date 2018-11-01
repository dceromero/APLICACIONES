

ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btnconfirm", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {

    } else {

    }
})