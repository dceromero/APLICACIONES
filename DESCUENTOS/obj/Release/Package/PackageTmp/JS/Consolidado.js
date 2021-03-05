ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        var fechas = {
            FECINI: $("#txtfecini").val(),
            FECFIN: $("#txtfecfin").val()
        };
        ClassDataAccess.Ajax("/api/Reportes/ExportExcel/", JSON.stringify(fechas),
            function (datos) {
                jsdatos = JSON.parse(datos);
                ClassDataAccess.GrillaExcelGrupable("#div-grid-download", jsdatos,
                    [
                        {
                            field: "ID_CANAL",
                            width: 20,
                            title: "Canal"
                        },
                        {
                            field: "CODCLIENTE",
                            width: 20,
                            title: "Nit"
                        },
                        {
                            field: "RAZSOCCLIENTE",
                            width: 40,
                            title: "Razon Social"
                        },
                        {
                            field: "producto",
                            width: 20,
                            title: "Producto"
                        },
                        {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        }, {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        }, {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        },
                        {
                            field: "PORCENDESC",
                            width: 20,
                            title: "Porcentaje"
                        }, {
                            field: "simbolo",
                            width: 20,
                            title: "vaciol"
                        },
                        {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        },
                        {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        },
                        {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        },
                        {
                            field: "vacio1",
                            width: 20,
                            title: "vacio"
                        },
                        {
                            field: "FECINI",
                            width: 20,
                            title: "Fecha Inicio"
                        },
                        {
                            field: "FECFIN",
                            width: 20,
                            title: "Fecha Fin"
                        },
                        {
                            field: "CANT",
                            width: 20,
                            title: "Cantidad"
                        },
                        {
                            field: "material",
                            width: 45,
                            title: "Material"
                        },
                    ]
                )
            }
        )
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})