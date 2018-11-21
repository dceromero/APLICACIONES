ClassDataAccess = new AccesosDatos();
$("[required]").attr('disabled', 'disabled');
ClassDataAccess.Ajax(
    "/api/Solicitudes/Encabezados/"+$("#lblid").val(),
    '',
    function (datos) {
        jsdata = JSON.parse(datos)
        $("#cmbtpsol").html("").append("<option>" + jsdata.DESCRIPCION + "</option>")
        $("#txtcliente").val(jsdata.RAZSOCCLIENTE)
        $("#txtfecini").val(jsdata.FECINI.replace("T00:00:00", ""))
        $("#txtfecfin").val(jsdata.FECFIN.replace("T00:00:00", ""))

        ClassDataAccess.Grilla("#div-detail-descuento", jsdata.VIEW_VALORPORCLIENTE,
            [

                {
                    field: "ID_MDDESCUENTO",
                    width: 30,
                    title: "Seleccionar",
                    template: function (d) {
                        return '<input type="checkbox" value="' + d.ID_MDDESCUENTO+'">';
                    }
                },
                {
                    field: "Material",
                    width: 60,
                    title: "Material"
                },
                {
                    field: "PORCENDESC",
                    width: 20,
                    title: "% DESC"
                },
                {
                    field: "CANT",
                    width: 25,
                    title: "Cantidad"
                },
                {
                    field: "subtotal",
                    width: 25,
                    title: "subtotal",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.subtotal, "c0") + '</strong>';
                    }
                },
                {
                    field: "Descuento",
                    width: 25,
                    title: "Descuento",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.Descuento, "c0") + '</strong>';
                    }
                },
                {
                    field: "total",
                    width: 25,
                    title: "Total",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.total, "c0") + '</strong>';
                    }
                }
            ]
        )
    })