ClassDataAccess = new AccesosDatos();

ClassDataAccess.getAjax(
    "/api/LiqGanadero/ApiListDateLiq",
    '',
    function (datos) {
        $("#cmbfecLiq").html("").append("<option value='-1'>Seleccione</option>");
        for (var x in datos) {
            $("#cmbfecLiq").append("<option value='" + datos[x].replace('T00:00:00', '') + "'>" + datos[x].replace('T00:00:00', '') + "</option>");
        }
    }
);

ClassDataAccess.getAjax(
    "/api/LiqGanadero/ApiListAcopi",
    '',
    function (datos) {
        $("#cmbacopio").html("").append("<option value='-1'>Seleccione</option>");
        for (var x in datos) {
            $("#cmbacopio").append("<option value='" + datos[x] + "'>" + datos[x] + "</option>");
        }
    }
);


$("body").on("click", "#btn-close-advertencia", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
})


$("body").on("click", "#btn-close-message", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
})

$("body").on("click", "#btn-all", function () {
    validar = ClassDataAccess.ValidarCampos('[required]');
    if (validar) {
        liquidacion = {
            ACOPIO: $("#cmbacopio").val(),
            FEC_LIQ: $("#cmbfecLiq").val()
        }
        ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
        ClassDataAccess.Ajax(
            '/api/LiqGanadero/Ganadero',
            JSON.stringify(liquidacion),
            function (datos) {
                ClassDataAccess.CloseWindows("#div-mensaje");
                $("#lblmessage").text(datos);
                ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 120, 300);
            }
        )
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});


$("body").on("click", "#btn-by-user", function () {
    validar = ClassDataAccess.ValidarCampos('[required]');
    if (validar && $("#txtnit").val() !="") {
        liquidacion = {
            NIT_CED: $("#txtnit").val(),
            ACOPIO: $("#cmbacopio").val(),
            FEC_LIQ: $("#cmbfecLiq").val()
        }
        ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
        ClassDataAccess.Ajax(
            '/api/LiqGanadero/getGanadero',
            JSON.stringify(liquidacion),
            function (datos) {
                ClassDataAccess.CloseWindows("#div-mensaje");
                $("#lblmessage").text(datos);
                ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 120, 300);
            }
        )
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});