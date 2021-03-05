ClassDataAccess = new AccesosDatos();

ClassDataAccess.FileUp("#div-upload-docsap", "/api/Legalizacion/guardarDocumentos/", "pdf",
    function (data) {
        console.log(data);
        ClassDataAccess.CloseWindows("#div-mensaje");
        $("#lblmessage").text("Su solicitud ha sido Cargada")
        ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 140, 300);
        // 
    }
);

var idLegalizacion = 0;

$("[required]").attr('disabled', 'disabled');
$("#txtobs").removeAttr('disabled')

$("#btnconfirm").text("Guardar");
$("#btnreject").text("Cancelar").attr('id', 'btnreject2');

ClassDataAccess.Events("#btnreject2", "click", function () {
    location.href = "/trade/estados";
})

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
        idLegalizacion = datos.datosLegalizacion.ID_LEGALIZA;
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
                        return  kendo.toString(parseFloat(d.VALOR), "c0") ;
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
                        return '<button class="btn btn-outline-success" name="' + d.CODPRODUCTO+'" valor="' + d.VALOR +'" del="' + d.ID_MDLEGALIZACION + '"><span class="fa fa-minus-circle">&nbsp;&nbsp;Modificar</span></button>'
                    }
                }
            ],
            [
                { field: "VALOR", aggregate: "sum" },
            ]
        )
    });


ClassDataAccess.Events("[del]", "click", function () {
    $("#lblcodprod").val($(this).attr("del"));
    $("#txtproduct").val($(this).attr("name")).attr('disabled', 'disabled');;
    $("#txtvalor").val($(this).attr("valor"));

});


ClassDataAccess.Events("#btnadd", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-detalle [required]");
    if (validar) {
        var desc = {
            ID_LEGALIZA:  $("#lblcodprod").val(),
            VALOR: parseFloat($("#txtvalor").val()),
        };

        ClassDataAccess.Ajax('/api/Legalizacion/guardar/', JSON.stringify(desc),
            function () {
                location.href = "../index/" + $("#lblid").val();
            });

    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "/trade/estados";
});


$(".plupload_start ").remove();
$(".plupload_header_text").remove("");

ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    parametros = {
        ID_LEGALIZA: idLegalizacion,
    }

    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    var uploader = $('#div-upload-docsap').pluploadQueue();
    uploader.setOption('multipart_params', parametros)
    uploader.start()
})

