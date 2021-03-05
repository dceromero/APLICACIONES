ClassDataAccess = new AccesosDatos();


ClassDataAccess.getAjax('/api/Trade/listAdmonComercial/', '', function (datos) {

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
                field: "SOLICITANTE",
                width: 40,
                title: "Supervisor de Venta"
            },
            {
                field: "RESPONSABLE",
                width: 45,
                title: "Cliente"
            },
            {
                field: "VALSOL",
                width: 15,
                title: "Solic",
                template: function (d) {
                    return '<strong> ' + kendo.toString(d.VALSOL, "c0") + '</strong>';
                }
            },
            {
                field: "VALLEG",
                width: 15,
                title: "Legal",
                template: function (d) {
                    return '<strong> ' + kendo.toString(d.VALLEG, "c0") + '</strong>';
                }
            },
            {
                field: "NRO_PROV",
                width: 23,
                title: "N° Provis",
                template: function (d) {
                    if (!d.PROVISION) {
                        return '<button  class="btn btn-outline-info" aprob><span >Sin Provisión</span></button>'
                    } else {
                        if (d.NRO_PROV == 0) {
                            return '<button btnidpr="' + d.ID_LEGALIZA + '" class="btn btn-outline-success" aprob><span>Sin Registrar</span></button>'
                        } else {
                            return '<button  class="btn btn-outline-success" aprob><span >&nbsp;' + d.NRO_PROV + '</span></button>'
                        }
                    }
                }
            },
            {
                field: "NRO_REVPROV",
                width: 23,
                title: "Rev Provis",
                template: function (d) {
                    if (!d.PROVISION) {
                        return '<button  class="btn btn-outline-info" aprob><span>Sin Provisión</span></button>'
                    } else {
                        if (d.NRO_PROV != 0 && d.NRO_REVPROV == 0) {
                            return '<button btnidrp="' + d.ID_LEGALIZA + '" class="btn btn-outline-success" aprob><span>Sin Registrar</span></button>'
                        } else {
                            if (d.NRO_PROV == 0) {
                                return '<button  class="btn btn-outline-success" aprob><span >Sin Registrar</span></button>'
                            } else {
                                return '<button class="btn btn-outline-success" aprob><span >&nbsp;' + d.NRO_REVPROV + '</span></button>'
                            }
                        }
                    }
                }
            },
            {
                field: "NRO_SAP",
                width: 23,
                title: "Núm SAP",
                template: function (d) {
                    if (!d.PROVISION && d.NRO_SAP == 0) {
                        return '<button btnid="' + d.ID_LEGALIZA + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">Sin Registrar</span></button>'
                    } else {
                        if (d.NRO_REVPROV != 0 && d.NRO_SAP == 0) {
                            return '<button btnid="' + d.ID_LEGALIZA + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">Sin Registrar</span></button>'
                        } else {
                            if (d.NRO_SAP == 0) {
                                return '<button  class="btn btn-outline-success" aprob><span class="fa fa-check-circle">Sin Registrar</span></button>'
                            } else {
                                return '<button  class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;' + d.NRO_SAP + '</span></button>'
                            }
                        }
                    }
                }
            }
        ]
    )
})


ClassDataAccess.Events("[btnid]", "click", function () {
    $("#lblidtc").val($(this).attr("btnid"));
    ClassDataAccess.getAjax("/api/Legalizacion/detailMDLegaliza/" + $(this).attr("btnid"), '',
        function (data) {
            $("#table-griddetail").html("");

            for (d in data) {

                const amount = data[d].VALOR;
                const options2 = { style: 'currency', currency: 'USD' };
                const numberFormat2 = new Intl.NumberFormat('en-US', options2);
                $("#table-griddetail").append('<tr><td class="text-left">' + data[d].CODPRODUCTO + '</td><td class="text-right">' + numberFormat2.format(amount) + '</td></tr>');
            }

        }
    )
    ClassDataAccess.OpenWindows("#div-confirmacion", "Estado de la Nota", "200", "420");
    $("#div-confirmacion_wnd_title").addClass("text-center")
}
);

ClassDataAccess.Events("[btnidrp]", "click", function () {
    $("#lblidtcrp").val($(this).attr("btnidrp"));
    ClassDataAccess.getAjax("/api/Legalizacion/detailMDLegaliza/" + $(this).attr("btnidrp"), '',
        function (data) {
            $("#table-griddetailrp").html("");

            for (d in data) {

                const amount = data[d].VALOR;
                const options2 = { style: 'currency', currency: 'USD' };
                const numberFormat2 = new Intl.NumberFormat('en-US', options2);
                $("#table-griddetailrp").append('<tr><td class="text-left">' + data[d].CODPRODUCTO + '</td><td class="text-right">' + numberFormat2.format(amount) + '</td></tr>');
            }

        }
    )
    ClassDataAccess.OpenWindows("#div-confirmacion-rprov", "Estado de la Nota :", "200", "420");
    $("#div-confirmacion_wnd_title").addClass("text-center")
}
);

ClassDataAccess.Events("[btnidpr]", "click", function () {
    $("#lblidtcprov").val($(this).attr("btnidpr"));
    ClassDataAccess.getAjax("/api/Legalizacion/detailMDLegaliza/" + $(this).attr("btnidpr"), '',
        function (data) {
            $("#table-griddetailpr").html("");

            for (d in data) {

                const amount = data[d].VALOR;
                const options2 = { style: 'currency', currency: 'USD' };
                const numberFormat2 = new Intl.NumberFormat('en-US', options2);
                $("#table-griddetailpr").append('<tr><td class="text-left">' + data[d].CODPRODUCTO + '</td><td class="text-right">' + numberFormat2.format(amount) + '</td></tr>');
            }

        }
    )
    ClassDataAccess.OpenWindows("#div-confirmacion-prov", "Estado de la Nota :", "200", "420");
    $("#div-confirmacion_wnd_title").addClass("text-center")
}
);



ClassDataAccess.Events("#btnsaverp", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-confirmacion-rprov [validarcampos] [required]");
    if (validar) {
        parametros = {
            ID_LEGALIZA: $("#lblidtcrp").val(),
            NRO_PROV: $("#txtrprov").val(),
        }
        ClassDataAccess.CloseWindows("#div-confirmacion-rprov");
        ClassDataAccess.OpenWindows("#div-mensaje", "Espere por favor :", 100, 300);
        ClassDataAccess.Ajax("/api/Legalizacion/actualizarRprov", JSON.stringify(parametros), function (datos) {
            console.table(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text("Se ha actualizado la nota");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje:", 125, 300);
        });
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

});

ClassDataAccess.Events("#btnsaveprov", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-confirmacion-prov [validarcampos] [required]");
    if (validar) {
        parametros = {
            ID_LEGALIZA: $("#lblidtcprov").val(),
            NRO_PROV: $("#txtprov").val(),
        }
        ClassDataAccess.CloseWindows("#div-confirmacion-prov");
        ClassDataAccess.OpenWindows("#div-mensaje", "Espere por favor :", 100, 300);
        ClassDataAccess.Ajax("/api/Legalizacion/actualizarNprov", JSON.stringify(parametros), function (datos) {
            console.table(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text("Se ha actualizado la nota");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje:", 125, 300);
        });
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

});


ClassDataAccess.Events("#btnsave", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-confirmacion [validarcampos] [required]");
    if (validar) {
        parametros = {
            ID_LEGALIZA: $("#lblidtc").val(),
            NRO_PROV: $("#txtnumsap").val(),
        }
        ClassDataAccess.CloseWindows("#div-confirmacion");
        ClassDataAccess.OpenWindows("#div-mensaje", "Espere por favor :", 100, 300);
        ClassDataAccess.Ajax("/api/Legalizacion/actualizarNSap", JSON.stringify(parametros), function (datos) {
            console.table(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text("Se ha actualizado la nota");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje:", 125, 300);
        });
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

});


ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
});

ClassDataAccess.Events("#btncancelprov", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion-prov");
});

ClassDataAccess.Events("#btncancelrp", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion-rprov");
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.LimpiarCampos("[required]");
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
    location.href = "/legalizacion/listadmonsales";
});

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});
