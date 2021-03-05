ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        parametros = {
            FECHA_INIAC: $("#txtfecini").val(),
            FECHA_FINAC: $("#txtfecfin").val(),
        }
        ClassDataAccess.Ajax('/api/Trade/informeSolicitudes/', JSON.stringify(parametros), function (datos) {

            ClassDataAccess.GrillaExcel("#div-grid", datos,
                [
                    {
                        field: "FEC_INGRESO",
                        width: 25,
                        title: "Fecha Ingreso",
                        format: "yyyy-MM-dd",
                        template: function (d) {
                            fec = d.FEC_INGRESO.replace("T", " Hr: ").split('.')
                            fec1 = fec[0].split(':')
                            return fec1[0] + fec1[1] + ':' + fec1[2];
                        }
                    },
                    {
                        field: "SOLICITANTE",
                        width: 30,
                        title: "Solicitante"
                    },
                    {
                        field: "NAMEREGIONAL",
                        width: 30,
                        title: "Regional"
                    },
                    {
                        field: "Canal",
                        width: 30,
                        title: "Canal"
                    },
                    {
                        field: "CLIENTE",
                        width: 40,
                        title: "Cliente"
                    },
                    {
                        field: "PRODUCTO",
                        width: 45,
                        title: "Producto"
                    },
                    {
                        field: "NOMBRE",
                        width: 45,
                        title: "Tipo Nota"
                    },
                    {
                        field: "DESCRIPCION",
                        width: 45,
                        title: "Descripción"
                    },
                    {
                        field: "CONCEPTO",
                        width: 45,
                        title: "Conceptos"
                    },
                    {
                        field: "FECHA_INIAC",
                        width: 45,
                        title: "Fec Inicial Actividad",
                        template: function (d) {
                            fec = d.FECHA_INIAC.replace("T", " Hr: ").split('.')
                            fec1 = fec[0].split(':')
                            return fec1[0] + fec1[1] + ':' + fec1[2];
                        }
                    },
                    {
                        field: "FECHA_FINAC",
                        width: 45,
                        title: "Fec Final Actividad",
                        template: function (d) {
                            fec = d.FECHA_FINAC.replace("T", " Hr: ").split('.')
                            fec1 = fec[0].split(':')
                            return fec1[0] + fec1[1] + ':' + fec1[2];
                        }
                    },
                    {
                        field: "VALOR",
                        width: 15,
                        title: "Valor",
                        template: function (d) {
                            return '<strong> ' + kendo.toString(d.VALOR, "c0") + '</strong>';
                        }
                    },
                    {
                        field: "VENTA_PROMEDIO",
                        width: 15,
                        title: "Venta Promedio",
                        template: function (d) {
                            return '<strong> ' + kendo.toString(d.VENTA_PROMEDIO, "c0") + '</strong>';
                        }
                    },
                    {
                        field: "VENTA_ESPERADA",
                        width: 15,
                        title: "Venta Esperada",
                        template: function (d) {
                            return '<strong> ' + kendo.toString(d.VENTA_ESPERADA, "c0") + '</strong>';
                        }
                    },
                    {
                        field: "JUSTIFICACION",
                        width: 23,
                        title: "Justificación"
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