ClassDataAccess = new AccesosDatos();

$("[required]").attr('disabled', 'disabled');
$("#txtobs").removeAttr('disabled')
$("#btnconfirm, #btnreject").fadeOut()
ClassDataAccess.getAjax("/api/Trade/notaAprobar/" + $("#lblid").val()
    , '',
    function (datos) {
        $("#cmbtpnota").html("").append("<option>" + datos.NOMBRE + "</option>");
        $("#cmbtpsolicitud").html("").append("<option>" + datos.DESCRIPCION + "</option>");
        $("#cmbtpmotivo").html("").append("<option>" + datos.CONCEPTO + "</option>");
        $("#txtcliente").val(datos.cliente);
        $("#txtclientePrincipa").val(datos.RESPONSABLE);
        $("#txtnumfact").val(datos.NUM_FACTURA);
        $("#txtmot").val(datos.JUSTIFICACION);
        $("#txtobs").val(datos.OBSERVACION);

        ClassDataAccess.GrillaAgregate("#div-grid-detalle", datos.datosLegalizacion.detailLegalizacion,
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
                        return kendo.toString(parseFloat(d.VALOR), "c0");
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
        for (d in datos.datosLegalizacion.documentosLegal) {

            $("#table-griddetail").append('<tr><td class="text-left"><a target="_black" href="../../ArchivoLegalizacion/' + datos.datosLegalizacion.documentosLegal[d].NOMBRE_ARCHIVO + '" class="btn btn-sm    btn-outline-dark"><strong>' + datos.datosLegalizacion.documentosLegal[d].NOMBRE_ARCHIVO + '</strong></a></td></tr>');
        }
    });