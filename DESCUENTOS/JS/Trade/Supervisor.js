$("[required]").attr('disabled', 'disabled');

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
        $("#txtproduct, #txtvalor").removeAttr('disabled')

        client = datos.cliente.split('-');
        param = {
            CODCLIENTE: parseInt(client[0])
        }
        ClassDataAccess.Ajax(
            "/api/Productos/ListadoProductos",
            JSON.stringify(param),
            function (datos) {
                js = JSON.parse(datos);
                ClassDataAccess.AutoCompletePersonalizado("#txtproduct", js, "VALOR", "DESCRIPCION", function (e) {
                    item = e.item;
                    DataItem = this.dataItem(e.item.index());
                    $("#lblVALOR").val(DataItem["VALOR"])
                    cod = DataItem["DESCRIPCION"].split(" - ")
                    $("#lblcodprod").val(cod[0])
                })
            }
        );

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
                        return kendo.toString(parseFloat(d.VALOR), "c0");
                    },
                    footerTemplate: function (d) {
                        return '<strong> ' + kendo.toString(parseFloat(d.VALOR.sum), "c0") + '</strong>';
                    }
                },
                {
                    field: "ID_MDNOTACOMERCIAL",
                    width: 10,
                    title: "Eliminar",
                    template: function (d) {
                        return '<button class="btn btn-outline-danger" del="' + d.ID_MDNOTACOMERCIAL + '"><span class="fa fa-minus-circle">&nbsp;&nbsp;Quitar</span></button>'
                    }
                }

            ],
            [
                { field: "VALOR", aggregate: "sum" },
            ]
        )
    });


ClassDataAccess.Events("[del]", "click", function () {
    ClassDataAccess.getAjax('/api/Trade/eliminar/' + $(this).attr("del"),
        '',
        function () {
            location.href = "../Modificacion/" + $("#lblid").val();
        })
});


ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    var aprob = $("#lblpregunta").text() == "Aprobar" ? 2 : 1;
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
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        });
})


ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "../listsupvisor";
});


ClassDataAccess.Events("#btnadd", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-detalle [required]");
    if (validar) {
        var desc = {
            ID_MCNOTAXPRECIO: $("#lblid").val(),
            CODPRODUCTO: $("#lblcodprod").val(),
            VALOR: parseFloat($("#txtvalor").val()),
        };

        ClassDataAccess.Ajax('/api/Trade/saveDetail/', JSON.stringify(desc),
            function () {
                location.href = "../Modificacion/" + $("#lblid").val();
        });

    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});