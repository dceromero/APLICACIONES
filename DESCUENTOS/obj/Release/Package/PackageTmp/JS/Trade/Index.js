ClassDataAccess = new AccesosDatos();
$("#cmbtpsolicitud").attr('disabled', 'disabled');


ClassDataAccess.getAjax('/api/Trade/listNotas/', '', function (datos) {
    ClassDataAccess.Combox("#cmbtpnota", datos, "ID_TIPONOTA", "NOMBRE");
})


ClassDataAccess.Events("#cmbtpmotivo", "change", function () {
    if ($(this).val() == 15) {
        $("[data-oculto]").addClass("d-none")
        $("#txtfecini").val("2020-12-31");
        $("#txtfecfin").val("2020-12-31");
        $("#txtvalprom").val(0);
        $("#txtvalesp").val(0);
    } else {
        $("[data-oculto]").removeClass("d-none")
        $("#txtfecini").val("");
        $("#txtfecfin").val("");
        $("#txtvalprom").val("");
        $("#txtvalesp").val("");
    }

    ClassDataAccess.getAjax('/api/Trade/listTipoSolicitud/' + $(this).val(), '', function (datos) {
        $("#cmbtpsolicitud").html("").append("<option value='" + datos[0].ID_SOLICITD + "'>" + datos[0].DESCRIPCION + "</option>")

    })
})

ClassDataAccess.Ajax(
    "/api/Clientes/ListarClientexVendedor",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtcliente", js, "CODCLIENTE", "RAZSOCCLIENTE", "#lblcliente");
    }
);

var myarray = new Array;
var ultimo = 0;
ClassDataAccess.Events("#btnadd", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-detalle [required]");
    if (validar) {
        var desc = { CODPRODUCTO: $("#lblcodprod").val(), nameproduc: $("#txtproduct").val(), VALOR: parseFloat($("#txtvalor").val()), quitar: ultimo };
        myarray.push(desc);
        ultimo++
        ClassDataAccess.GrillaAgregate("#div-grid-detalle", myarray,
            [
                {
                    field: "nameproduc",
                    width: 70,
                    title: "Producto",
                    footerTemplate: "Valor Total Nota : "
                },
                {
                    field: "VALOR",
                    width: 20,
                    title: "Valor",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(parseFloat(d.VALOR), "c0") + '</strong>';
                    },
                    footerTemplate: function (d) {
                        console.log(d);
                        return '<strong> ' + kendo.toString(parseFloat(d.VALOR.sum), "c0") + '</strong>';
                    }
                },
                {
                    field: "quitar",
                    width: 10,
                    title: "Quitar",
                    template: function (d) {
                        return '<button class="btn btn-outline-danger" del="' + d.quitar + '"><span class="fa fa-minus-circle">&nbsp;&nbsp;Quitar</span></button>'
                    }
                }
            ],
            [
                { field: "VALOR", aggregate: "sum" },
            ]
        )
        ClassDataAccess.LimpiarCampos("#div-detalle [required]");
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 110, 300);
    }
});

ClassDataAccess.Events.Blur("#txtcliente", "#lblcliente");

ClassDataAccess.Events("#txtcliente", "blur", function () {

    if ($("#lblcliente").val() != "") {

        ClassDataAccess.Ajax(
            "/api/Clientes/DetalledelCliente/" + $("#lblcliente").val(),
            '',
            function (datos) {
                js = JSON.parse(datos);
                $("#txtclientePrincipa").val(`${js.CODRESPAGO} - ${js.RAZSOCRESP}`);
                $("#nitcliente").val(js.CODRESPAGO);
            }
        );


        ClassDataAccess.getAjax('/api/Trade/listConceptos/' + $("#lblcliente").val(), '', function (datos) {
            ClassDataAccess.Combox("#cmbtpmotivo", datos, "ID_CONCEPTO", "CONCEPTO");
        })

        param = {
            CODCLIENTE: $("#lblcliente").val()
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


    }

});

ClassDataAccess.Events("[del]", "click", function () {
    $("#lblid").val($(this).attr("del"));
    ClassDataAccess.OpenWindows("#div-confirmacion-del-item", "Remover Item", 110, 300);
});

ClassDataAccess.Events("#btnremove", "click", function () {
    for (x in myarray) {
        if (myarray[x].quitar == $("#lblid").val()) {
            myarray.splice(x, 1);
        }
    }
    ClassDataAccess.refreshGrilla("#div-grid-detalle")
    ClassDataAccess.CloseWindows("#div-confirmacion-del-item");
});


ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    var nota = {
        ID_SOLICITD: $("#cmbtpsolicitud").val(),
        ID_CONCEPTO: $("#cmbtpmotivo").val(),
        ID_TIPONOTA: $("#cmbtpnota").val(),
        COD_CLIEN: $("#lblcliente").val(),
        NIT: $("#nitcliente").val(),
        NUM_FACTURA: $("#txtnumfact").val(),
        JUSTIFICACION: $("#txtmot").val(),
        FECHA_INIAC: $("#txtfecini").val(),
        FECHA_FINAC: $("#txtfecfin").val(),
        VENTA_PROMEDIO: $("#txtvalprom").val(),
        VENTA_ESPERADA: $("#txtvalesp").val(),
        listMDNotasXPrecios: myarray
    };
    ClassDataAccess.Ajax(
        '/api/Trade/saveNota',
        JSON.stringify(nota),
        function (datos) {
            $("#lblmessage").text(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        });
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "/trade/estados";
});

ClassDataAccess.Events("#btn-clean", "click", function () {
    location.href = "/trade/";
})
