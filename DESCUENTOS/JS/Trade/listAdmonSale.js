ClassDataAccess = new AccesosDatos();


ClassDataAccess.getAjax('/api/Trade/listAdmonVentas/', '', function (datos) {
    ClassDataAccess.Grilla("#div-grid-aprobacion", datos,
        [
            {
                field: "FEC_INGRESO",
                width: 25,
                title: "Fecha Ingreso",
                template: function (d) {
                    fec = d.FEC_INGRESO.replace("T", " Hr: ").split('.')
                    fec1 = fec[0].split(':')
                    return fec1[0] + fec1[1] + ':' + fec1[2];
                }
            },
            {
                field: "CONCEPTO",
                width: 30,
                title: "Concepto"
            },
            {
                field: "solicitante",
                width: 40,
                title: "Supervisor de Venta"
            },
            {
                field: "cliente",
                width: 45,
                title: "Cliente"
            },
            {
                field: "VALOR",
                width: 15,
                title: "Valor Nota",
                template: function (d) {
                    return '<strong> ' + kendo.toString(d.VALOR, "c0") + '</strong>';
                }
            },
            {
                field: "ID_MCNOTACOMERCIAL",
                width: 23,
                title: "Detalle",
                template: function (d) {
                    return '<button btnid="' + d.ID_MCNOTACOMERCIAL + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Observación</span></button>'
                }
            }
        ]
    )
})


ClassDataAccess.Events("[btnid]", "click", function () {
    $("#lblidtc").val($(this).attr("btnid"));
    ClassDataAccess.OpenWindows("#div-confirmacion", "Estado de la Nota :", "145", "285");
}
);

ClassDataAccess.Events("[name='opt']", "click", function () {
    if ($(this).attr("id") == "optnumsap") {
        $("#txtnumsap").removeAttr("disabled").val("");
    } else {

        $("#txtnumsap").attr("disabled", "disabled").val("Bloqueado SAP");;
    }
});

ClassDataAccess.Events("#btnsave", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar) {
        var estado =1
        if ($("#optnumsap").prop('checked')) {
            estado = 2;
        }
        parametros = {
            ID_MCNOTAXPRECIO: $("#lblidtc").val(),
            OBS_COORTRADE: $("#txtnumsap").val(),
            APROBCOORTD : estado
        }
        ClassDataAccess.CloseWindows("#div-confirmacion");
        ClassDataAccess.OpenWindows("#div-mensaje", "Espere por favor :", 100, 300);
        ClassDataAccess.Ajax("/api/Trade/aprobAdmonVenta", JSON.stringify(parametros), function (datos) {
            console.table(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text("Se ha enviado la Notificación al Lider Comercial");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje:", 125, 300);
        });
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

});


ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.LimpiarCampos("[required]");
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
    location.href = "/TRade/listadmonsale";
});

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});
