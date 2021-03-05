ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        parametros = {
            FEC_INGRESO: $("#txtfecini").val(),
            FEC_DESCARGA: $("#txtfecfin").val(),
        }
        ClassDataAccess.Ajax('/api/Trade/listAdmonComercial/', JSON.stringify(parametros), function (datos) {

            ClassDataAccess.GrillaExcel("#div-grid", datos,
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
                        title: "N° Provis"
                    },
                    {
                        field: "NRO_REVPROV",
                        width: 23,
                        title: "Rev Provis"
                    },
                    {
                        field: "NRO_SAP",
                        width: 23,
                        title: "Núm SAP"
                    }
                ]
            );
        });
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
});


ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia")
})