ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Regionales/ListadoRegionales",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbreg", js, "ID_REGIONAL", "NAMEREGIONAL");
    }
);

ClassDataAccess.Ajax(
    "/api/Canales/ListaDeCanales",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbcanal", js, "ID_CANAL", "NAMECANALES");
    }
);

var myarray = new Array;
var ultimo = 0;
ClassDataAccess.Events("#btnadd", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-detalle [required]");
    if (validar) {
        var desc = { CODPRODUCTO: $("#lblcodprod").val(), nameproduc: $("#txtproduct").val(), CANT: $("#txtcant").val(), PORCENDCTO: $("#txtporc").val(), dcto: $("#txtval").val(), valor: $("#lblVALOR").val(), quitar: ultimo };
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
                    field: "PORCENDCTO",
                    width: 40,
                    title: "Porcentaje"
                },
                {
                    field: "dcto",
                    width: 50,
                    title: "Descuento"
                },
                {
                    field: "quitar",
                    width: 40,
                    title: "Quitar",
                    template: function (d) {
                        return '<button class="btn btn-outline-danger" del><span class="fa fa-minus-circle">&nbsp;&nbsp;Quitar</span></button>'
                    }
                }
            ]
        );
        ClassDataAccess.LimpiarCampos("#div-detalle [required]");
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});

ClassDataAccess.Events("#cmbreg", "change", function () {    
    ClassDataAccess.Ajax(
        "/api/Oficinas/ListadoOfixReg/" + $(this).val(),
        '',
        function (datos) {
            js = JSON.parse(datos);
            ClassDataAccess.Combox("#cmbofi", js, "ID_OFICVENTA", "NAMEOFICVENTA");
        }
    );
});

ClassDataAccess.Events("#cmbcanal", "change", function () {
    ClassDataAccess.Ajax(
        "/api/GrupoClientes/ListaGruClient/" + $(this).val(),
        '',
        function (datos) {
            js = JSON.parse(datos);
            ClassDataAccess.Combox("#cmbgrpclient", js, "GRPCLIENTE", "GRPNOMBRE");
        }
    );
});

ClassDataAccess.Events("#cmbgrpclient", "change", function () {

    if ( $("#cmbofi").val() != "-1" && $("#cmbcanal").val() != "-1") {

        pr = {
            OFICINA: $("#cmbofi").val(),
            ID_CANAL: $("#cmbcanal").val(),
            GRUPOCLI: $(this).val()
        };
        ClassDataAccess.Ajax(
            "/api/Productos/ListaProductxCanal",
            JSON.stringify(pr),
            function (datos) {
                js = JSON.parse(datos);
                ClassDataAccess.AutoCompletePersonalizado("#txtproduct", js, "VALOR", "DESCRIPCION", function (e) {
                    item = e.item;
                    DataItem = this.dataItem(e.item.index());
                    $("#lblVALOR").val(DataItem["VALOR"]);
                    cod = DataItem["DESCRIPCION"].split(" - ");
                    $("#lblcodprod").val(cod[0]);
                })
            }
        )
    }

});

ClassDataAccess.Events("#btnsave", "click", function () {
    headerDescuentos = {
        ID_OFICVENTA: $("#cmbofi").val(),
        ID_CANAL: $("#cmbcanal").val(),
        GRPCLIENTE: $("#cmbgrpclient").val(),
        FECINI: $("#txtfecini").val(),
        FECFIN: $("#txtfecfin").val(),
        JUSTIFICACION: $("#txtmot").val(),
        IDMOTIVOS: $("#cmbtpmot").val(),
        MDDCTOCANAL: myarray
    };
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    ClassDataAccess.Ajax(
        '/api/Canales/Guadarsolicitud',
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