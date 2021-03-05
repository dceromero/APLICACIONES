ClassDataAccess = new AccesosDatos();
var myarray = "1";

$("[required]").attr('disabled', 'disabled');

$("#txtfecfin").attr("type", "text");


codigo = 0
ClassDataAccess.Ajax(
    "/api/Cartera/VistaAprobacion/" + $("#lblid").val(),
    '',
    function (datos) {
        js = JSON.parse(datos);
        $("#cmbtpsol").val(js.TIPOSOL);
        $("#txtcliente").val(js.cliente);
        $("#txtcupoasig").val(parseInt(js.CUPOASIGNADO).toLocaleString('es-Es'));
        $("#txtcupodisp").val(parseInt(js.CUPODISPONIBLE).toLocaleString('es-Es'));
        $("#txtdeuda").val(parseInt(js.CUPOENCARTERA).toLocaleString('es-Es'));

        $("#txtcuposol").val(parseInt(js.CUPOSOLICITADO).toLocaleString('es-Es'));
        $("#txtfecini").val(js.FECSOL.replace("T", " H: "));
        $("#txtfecfin").val(js.VIGENCIA.replace("T00:00:00", ""));
        $("#txtcupoven").val(0);
        $("#txtdias").val(0);
        $("#txtcodrespago").val(js.CODRESPAGO);
        $("#txtrespago").val(js.RAZSOCRESP);
        $("#txtmot").val(js.OBS);
        if (js.TIPOSOL == 2) {
            $("#div-detalle, #div-upload, [data-date]").fadeIn("slow");
            if ($("#lblnivel").val() == 4) {
                $("#txtcupoven, #txtdias, #txthipoteca, #txtPignoración").removeAttr('disabled');
            }
        }
    }
);

ClassDataAccess.FileUp("#upload", "/api/Cartera/Prueba/" + $("#lblid").val(), "xls,xlsx",
    function () {
        alert("Guardo");
    }
);

var aprob;
ClassDataAccess.Events("[msj]", "click", function () {
    $("#lblmsjct").text($(this).attr("msj"));
    aprob = $(this).attr("msj") == "Aprobar" ? 2 : 1;
    altura = 100;
    if (aprob == 1) {
        $("#div-ctr-rech").fadeIn("slow");
        altura = 180;
        $("#txtrech").val("");
    } else {
        $("#div-ctr-rech").fadeOut("slow");
        $("#txtrech").val($("#txtmot").val());
    }
    ClassDataAccess.OpenWindows("#div-confirmacion-cartera", "Confirmación", altura, 300);

});

ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion-cartera");
});



ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion-cartera");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje", 100, 300);
    CupoCredito = {
        IDSOL: $("#lblid").val(),
        APROBJF: aprob,
        CUPOAPROBADO: 0,
        OBS: $("#txtrech").val(),
        CUPOENCARTERA: $("#txtdeuda").val().replace(/\./g, ''),
        CUPOVENCIDO: $("#txtcupoven").val().replace(/\./g, ''),
        CUPODISPONIBLE: $("#txtcupodisp").val().replace(/\./g, ''),
        DIASVEN: $("#txtdias").val(),
        hipoteca: $("#txthipoteca").val(),
        pignoracion: $("#txtPignoración").val()

    };
    ClassDataAccess.Ajax("/api/Cartera/aprobacionsolicitud", JSON.stringify(CupoCredito),
        function (datos) {
            ClassDataAccess.CloseWindows("#div-mensaje");
            if (datos.indexOf("enviado") == -1) {
                window.open("../../FORMATOCUPO/" + datos.replace(/"/g, "") + ".pdf");
            }
            $("#lblmessage").text(datos);
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 100, 300);

        }
    );
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
    location.href = "/Cartera/Aprobaciones/";
});