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
    ClassDataAccess.Ajax(
        "/api/Clientes/DetalledelCliente/" + $("#lblcliente").val(),
        '',
        function (datos) {
            js = JSON.parse(datos);
            $("#txtcupoasig").val(js.CUPOASIGNADO);
            $("#txtcupodisp").val(js.CUPODISPONIBLE);
            $("#txtdeuda").val(js.CUPOENCARTERA);
            $("#txtcupoven").val(js.CUPOVENCIDO);
            $("#txtdias").val(js.DIASVEN);

        }
    );
});

ClassDataAccess.Events("#cmbtpsol", "change", function () {
    if ($(this).val() == "2") {
        $("#div-detalle").fadeIn("slow");
    } else {
        $("#div-detalle").fadeOut("slow");
    }
});
/*
ClassDataAccess.FileUp("#upload", "/api/Clientes/Prueba", "xls,xlsx",
    function () {
        alert("Guardo");
    }
);
*/