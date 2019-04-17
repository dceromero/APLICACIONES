ClassDataAccess = new AccesosDatos();



ClassDataAccess.Ajax(
    "/api/Solicitudes/ListarTiposSolicitudes",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbtpsol", js, "ID_SOLICITD", "DESCRIPCION");
    }
);


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
        var desc = { CODPRODUCTO: $("#lblcodprod").val(), nameproduc: $("#txtproduct").val(), CANT: $("#txtcant").val(), PORCENDESC: $("#txtporc").val(), valor: $("#txtval").val(), VUNI: $("#lblVALOR").val(), quitar: ultimo };
        myarray.push(desc);
        ultimo++
        ClassDataAccess.Grilla("#grid-add-descuento", myarray,
            [
                {
                    field: "nameproduc",
                    width: 90,
                    title: "Producto"
                },
                {
                    field: "CANT",
                    width: 50,
                    title: "Cantidad"
                },
                {
                    field: "PORCENDESC",
                    width: 40,
                    title: "Porcentaje"
                },
                {
                    field: "valor",
                    width: 50,
                    title: "Descuento"
                },
                {
                    field: "quitar",
                    width: 40,
                    title: "Quitar",
                    template: function (d) {
                        ///return '<img alt="Estado" del="true" id="' + d.quitar + '" style="max-width=2em; max-height: 2em;" src="../Image/cancel.ico" />';
                        return '<button class="btn btn-outline-danger" del><span class="fa fa-minus-circle">&nbsp;&nbsp;Quitar</span></button>'
                    }
                }
            ]
        )
        ClassDataAccess.LimpiarCampos("#div-detalle [required]");
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});

ClassDataAccess.Events.Blur("#txtcliente", "#lblcliente");

ClassDataAccess.Events("#txtcliente", "blur", function () {

    if ($("#lblcliente").val() != "") {

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
        )
    }

});

ClassDataAccess.Events("#btnsave", "click", function () {

    headerDescuentos = {
        ID_SOLICITD: $("#cmbtpsol").val(),
        CODCLIENTE: $("#lblcliente").val(),
        FECINI: $("#txtfecini").val(),
        FECFIN: $("#txtfecfin").val(),
        MOTIVO: $("#txtmot").val(),
        idmotivos: $("#cmbtpmot").val(),
        MDDESCUENTO: myarray
    }
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    ClassDataAccess.Ajax(
        '/api/Solicitudes/Guadarsolicitud',
        JSON.stringify(headerDescuentos),
        function (datos) {
            $("#lblmessage").text(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            myarray.splice(0, myarray.length);
            $("#grid-add-descuento").data('kendoGrid').dataSource.read();
            $("#grid-add-descuento").data("kendoGrid").refresh();
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        }
    )
});


