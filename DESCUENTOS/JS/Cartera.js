ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Clientes/ListarClientexVendedor",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtcliente", js, "CODCLIENTE", "RAZSOCCLIENTE", "#lblcliente");
    }
);

ClassDataAccess.Events("#txtcliente", "blur", function () {

});

ClassDataAccess.Events("#cmbtpsol", "change", function () {
    if ($(this).val() == "2") {
        $("#div-detalle").fadeIn("slow");
    } else {
        $("#div-detalle").fadeOut("slow");
    }
});