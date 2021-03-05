ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {

    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        parametros = {
                FEC_INGRESO: $("#txtfecini").val(),
                FEC_DESCARGA: $("#txtfecfin").val(),
            }
        ClassDataAccess.Ajax('/api/Trade/Informe/', JSON.stringify(parametros), function (datos) {
            
            ClassDataAccess.GrillaExcel("#div-grid-detalle", datos,
                [
                    {
                        field: "fec_ingreso",
                        width: 30,
                        title: "Fecha Ingreso",
                        template: function (d) {
                            return d.fec_ingreso.replace("T", " Hora: ");
                        }
                    },
                    {
                        field: "solicitante",
                        width: 30,
                        title: "Solicitante"
                    },
                    {
                        field: "aprobador",
                        width: 30,
                        title: "Aprobador"
                    },
                    {
                        field: "concepto",
                        width: 30,
                        title: "Concepto"
                    },
                    {
                        field: "cliente",
                        width: 30,
                        title: "Cliente"
                    },
                    {
                        field: "oficina",
                        width: 30,
                        title: "Oficina"
                    },
                    {
                        field: "canal",
                        width: 30,
                        title: "Canal"
                    },
                    {
                        field: "producto",
                        width: 30,
                        title: "Producto"
                    },
                    {
                        field: "valor",
                        width: 30,
                        title: "Valor"
                    },
                    {
                        field: "num_factura",
                        width: 30,
                        title: "Num Factura"
                    },
                    {
                        field: "tiposolicitud",
                        width: 30,
                        title: "Tipo Nota"
                    },
                    {
                        field: "docsap",
                        width: 30,
                        title: "Documento SAP"
                    },
                ]
            );
        });
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

});


ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});
