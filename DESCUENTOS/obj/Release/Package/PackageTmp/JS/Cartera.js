ClassDataAccess = new AccesosDatos();
var myarray = "1";

$("[data-date]").fadeOut("slow");

var fec = new Date();

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
            $("#txtcupoasig").val(parseInt(js.CUPOASIGNADO).toLocaleString('es-Es'));
            $("#txtcupodisp").val(parseInt(js.CUPODISPONIBLE).toLocaleString('es-Es'));
            $("#txtdeuda").val(parseInt(js.CUPOENCARTERA).toLocaleString('es-Es'));
            $("#txtcupoven").val(0);
            $("#txtdias").val(js.DIASVEN);
            $("#txtcodrespago").val(js.CODRESPAGO);
            $("#txtrespago").val(js.RAZSOCRESP);
            $("#txtmot").val(js.OBS);
        }
    );
});

ClassDataAccess.Events("#cmbtpsol", "change", function () {
    if ($(this).val() == "2") {
        $('[type="date"]').val("");
        $("#txtfecini").val(fec.getDate()+ "/" + (fec.getMonth() +1)+ "/" + fec.getFullYear());
        $("#div-detalle, [data-date]").fadeIn("slow");
    } else {
        $("#div-detalle, [data-date]").fadeOut("slow");
        $('[type="date"]').val("1999-01-01");
    }
});




ClassDataAccess.Events("#txtcuposol", "focus", function () {
    valor = $(this).val().replace(/\./g, '');
    $(this).val(valor);
});
ClassDataAccess.Events.Moneda("#txtcuposol");

ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    var CupoCredito = {
        TIPOSOL: $("#cmbtpsol").val(),
        CODCLIENTE: $("#lblcliente").val(),
        CUPOSOLICITADO: $("#txtcuposol").val().replace(/\./g,''),
        VIGENCIA: $("#txtfecfin").val(),
        OBS:$("#txtmot").val()
    };
    ClassDataAccess.Ajax(
        '/api/Cartera/Guadarsolicitud',
        JSON.stringify(CupoCredito),
        function (datos) {
            $("#lblmessage").text(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        });
});



