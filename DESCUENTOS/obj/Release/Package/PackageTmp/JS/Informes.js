ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    '/api/Solicitudes/ListadoInforme',
    '',
    function (datos) {
        jsdata = JSON.parse(datos);
        ClassDataAccess.Grilla("#grid-info-desc", jsdata,
            [
                {
                    field: "VENDEDOR",
                    width: 40,
                    title: "Vendedor"
                },
                {
                    field: "FECING",
                    width: 30,
                    title: "Fecha Ingreso",
                    template: function (d) {
                        fec = d.FECING.replace("T", " Hora : ");
                        f = fec.split(".")
                        return '<strong> ' + f[0] + '</strong>';
                    }
                },
                {
                    field: "FECINI",
                    width: 20,
                    title: "Fecha Inicio",
                    template: function (d) {
                        return '<strong> ' + d.FECINI.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "FECFIN",
                    width: 20,
                    title: "Fecha Fin",
                    template: function (d) {
                        return '<strong> ' + d.FECFIN.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "DESCRIPCION",
                    width: 30,
                    title: "Tipo Solicitud"
                },
                {
                    field: "CODCLIENTE",
                    width: 25,
                    title: "Nit"
                },
                {
                    field: "RAZSOCCLIENTE",
                    width: 40,
                    title: "Razón Social"
                },
                {
                    field: "nivel",
                    width: 20,
                    title: "Nivel"
                },
                {
                    field: "ID_MCDESCUENTO",
                    width: 20,
                    title: "Descargar",
                    template: function (d) {
                        if (d.nivel == 8 && d.estado == 1) {
                            return '<button class="btn btn-outline-info" btn="' + d.ID_MCDESCUENTO + '"><span class="fa fa-eye"></span></button> ';
                        } if (d.nivel == 9 && d.estado == 1) {
                            return '<button class="btn btn-outline-info" btn="' + d.ID_MCDESCUENTO + '"><span class="fa fa-file-download"></span></button> ';
                        } else {
                            return '<button class="btn btn-outline-info"><span class="fa fa-times-circle"></span></button> ';
                        }
                    }
                },
            ]
        )
    }
);


ClassDataAccess.Events(".k-grid-excel", "click", function () {
    alert("Descargado Archivo");
    ClassDataAccess.Ajax(
        '/api/Solicitudes/Download/' + $("#lblidm").val(),
        '',
        function () { });
});

ClassDataAccess.Events("[btn]", "click", function () {
    $("#lblidm").val($(this).attr("btn"));
    ClassDataAccess.Ajax(
        '/api/Solicitudes/ExportExcel/' + $(this).attr("btn"),
        '',
        function (data) {
            jsdata = JSON.parse(data);
            ClassDataAccess.OpenWindows.funcionCerrar("#div-exp", "Formulario para Exportar a Excel : ", 500, 1200,
                function () {
                    ClassDataAccess.DestruirGrilla("#grid-exp-desc");
                }
            );
            ClassDataAccess.GrillaExcel("#grid-exp-desc", jsdata,
                [{
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
        })
})

ClassDataAccess.Events("#btn-close-div-exp", "click", function () {
    ClassDataAccess.Ajax(
        '/api/Solicitudes/ListadoInforme',
        '',
        function (datos) {
            jsdata = JSON.parse(datos)
            ClassDataAccess.Grilla("#grid-info-desc", jsdata,
                [
                    {
                        field: "FECING",
                        width: 30,
                        title: "Fecha Ingreso",
                        template: function (d) {
                            fec = d.FECING.replace("T", " Hora : ");
                            f = fec.split(".")
                            return '<strong> ' + f[0] + '</strong>';
                        }
                    },
                    {
                        field: "FECINI",
                        width: 20,
                        title: "Fecha Inicio",
                        template: function (d) {
                            return '<strong> ' + d.FECINI.replace("T00:00:00", "") + '</strong>';
                        }
                    },
                    {
                        field: "FECFIN",
                        width: 20,
                        title: "Fecha Fin",
                        template: function (d) {
                            return '<strong> ' + d.FECFIN.replace("T00:00:00", "") + '</strong>';
                        }
                    },
                    {
                        field: "DESCRIPCION",
                        width: 30,
                        title: "Tipo Solicitud"
                    },
                    {
                        field: "CODCLIENTE",
                        width: 25,
                        title: "Nit"
                    },
                    {
                        field: "RAZSOCCLIENTE",
                        width: 40,
                        title: "Razón Social"
                    },
                    {
                        field: "nivel",
                        width: 20,
                        title: "Nivel"
                    },
                    {
                        field: "ID_MCDESCUENTO",
                        width: 20,
                        title: "Descargar",
                        template: function (d) {
                            if (d.nivel == 8 && d.estado == 1) {
                                return '<button class="btn btn-outline-info" btn="' + d.ID_MCDESCUENTO + '"><span class="fa fa-eye"></span></button> ';
                            } if (d.nivel == 9 && d.estado == 1) {
                                return '<button class="btn btn-outline-info" btn="' + d.ID_MCDESCUENTO + '"><span class="fa fa-file-download"></span></button> ';
                            } else {
                                return '<button class="btn btn-outline-info"><span class="fa fa-times-circle"></span></button> ';
                            }
                        }
                    }
                ]
            );
        }
    );
    ClassDataAccess.CloseWindows("#div-exp");
    ClassDataAccess.DestruirGrilla("#grid-exp-desc");

})