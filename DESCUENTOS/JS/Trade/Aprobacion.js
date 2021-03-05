ClassDataAccess = new AccesosDatos();


$("[required]").attr('disabled', 'disabled');
$("#txtobs").removeAttr('disabled')

ClassDataAccess.getAjax(
    "/api/Trade/notaAprobar/" + $("#lblid").val(),
    '',
    function (datos) {
        $("#cmbtpnota").html("").append("<option>" + datos.NOMBRE + "</option>");
        $("#cmbtpsolicitud").html("").append("<option>" + datos.DESCRIPCION + "</option>");
        $("#cmbtpmotivo").html("").append("<option>" + datos.CONCEPTO + "</option>");
        $("#txtcliente").val(datos.cliente);
        $("#txtclientePrincipa").val(datos.RESPONSABLE);
        $("#txtnumfact").val(datos.NUM_FACTURA);
        $("#txtmot").val(datos.JUSTIFICACION);
        $("#txtobs").val(datos.OBSERVACION);
        if (datos.DESCRIPCION == "5.1 - DIFERENCIA DE PRECIOS") {
            $("[data-oculto]").addClass("d-none")
        } else {
            $("[data-oculto]").removeClass("d-none")
            $("#txtfecini").attr("type", "text").val(datos.FECHA_INIAC.replace("T00:00:00",''));
            $("#txtfecfin").attr("type", "text").val(datos.FECHA_FINAC.replace("T00:00:00",''));
            $("#txtvalprom").val(datos.VENTA_PROMEDIO);
            $("#txtvalesp").val(datos.VENTA_ESPERADA);
        }
        ClassDataAccess.GrillaAgregate("#div-grid-detalle", datos.listDetail,
            [
                {
                    field: "CODPRODUCTO",
                    width: 40,
                    title: "Producto",
                    footerTemplate: "Valor Total Nota : "
                },
                {
                    field: "VALOR",
                    width: 40,
                    title: "Valor",
                    template: function (d) {
                        return  kendo.toString(parseFloat(d.VALOR), "c0") ;
                    },
                    footerTemplate: function (d) {
                        return '<strong> ' + kendo.toString(parseFloat(d.VALOR.sum), "c0") + '</strong>';
                    }
                }
            ],
            [
                { field: "VALOR", aggregate: "sum" },
            ]
        )
    });


ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 120, 300);
    aprob = $("#div-confirmacion #lblpregunta").text() == "Aprobar" ? 2 : 1;
    nota = {
        APROBCOORTD: aprob,
        ID_MCNOTAXPRECIO: $("#lblid").val(),
        OBS_COORTRADE: $("#txtobs").val()
    }
    ClassDataAccess.Ajax("/api/Trade/Aprobacion", JSON.stringify(nota), 
        function (datos) {
            Mensaje = datos == null ? "Comuniquese con Sistemas" : datos.JEFE;
            $("#lblmessage").text(Mensaje);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 120, 300);
        });
})


ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "../listaprobacion";
});