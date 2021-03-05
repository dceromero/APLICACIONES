ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    '/api/Canales/EncabezadoInforme',
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
                    field: "OFICINA",
                    width: 25,
                    title: "Oficina"
                },
                {
                    field: "CANAL",
                    width: 40,
                    title: "Canal"
                },
                {
                    field: "GRPCLIENTES",
                    width: 40,
                    title: "Grp. Clientes"
                },
                {
                    field: "DESCMOTIVO",
                    width: 30,
                    title: "Tipo Solicitud"
                },
                {
                    field: "NIVEL",
                    width: 20,
                    title: "Nivel"
                },
                {
                    field: "ID_MCDESCUENTO",
                    width: 20,
                    title: "Descargar",
                    template: function (d) {
                        if (d.NIVEL == 8 && d.ESTADO == 1) {
                            return '<button class="btn btn-outline-info" btn="' + d.ID_MCDCTOCANAL + '"><span class="fa fa-eye"></span></button> ';
                        } if (d.NIVEL == 9 && d.ESTADO == 1) {
                            return '<button class="btn btn-outline-info" btn="' + d.ID_MCDCTOCANAL + '"><span class="fa fa-file-download"></span></button> ';
                        } else {
                            return '<button class="btn btn-outline-info"><span class="fa fa-times-circle"></span></button> ';
                        }
                    }
                }
            ]
        );
    }
);


ClassDataAccess.Events(".k-grid-excel", "click", function () {
    alert("Descargado Archivo");
    ClassDataAccess.Ajax(
        '/api/Canales/DownloadExcel/'  + $("#lblidm").val(),
        '',
        function () { });
});

ClassDataAccess.Events("[btn]", "click", function () {
    $("#lblidm").val($(this).attr("btn"));
    ClassDataAccess.Ajax(
        '/api/Canales/ExportExcel/' + $(this).attr("btn"),
        '',
        function (data) {
            jsdata = JSON.parse(data);
            ClassDataAccess.OpenWindows.funcionCerrar("#div-exp", "Formulario para Exportar a Excel : ", 500, 1200,
                function () {
                    ClassDataAccess.DestruirGrilla("#grid-exp-desc");
                }
            );
            ClassDataAccess.GrillaExcel("#grid-exp-desc", jsdata,
                [
                    {
                        field: "ORGANIZACION",
                        width: 20,
                        title: "Organización"
                    },
                    {
                        field: "ID_CANAL",
                        width: 20,
                        title: "Canal"
                    },
                    {
                        field: "ID_OFICVENTA",
                        width: 20,
                        title: "Oficina"
                    },
                    {
                        field: "GRPCLIENTE",
                        width: 20,
                        title: "Grp. Clientes"
                    },
                    {
                        field: "producto",
                        width: 20,
                        title: "Productos"
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
                        field: "PORCENDCTO",
                        width: 20,
                        title: "Porcentaje"
                    }, {
                        field: "simbolo",
                        width: 20,
                        title: "%"
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
                        field: "fecini",
                        width: 20,
                        title: "Fecha Inicio"
                    },
                    {
                        field: "fecfin",
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
                    }
                ]
            );
        });
});

ClassDataAccess.Events("#btn-close-div-exp", "click", function () {
    ClassDataAccess.Ajax(
        '/api/Canales/EncabezadoInforme',
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
                        field: "OFICINA",
                        width: 25,
                        title: "Oficina"
                    },
                    {
                        field: "CANAL",
                        width: 40,
                        title: "Canal"
                    },
                    {
                        field: "GRPCLIENTES",
                        width: 40,
                        title: "Grp. Clientes"
                    },
                    {
                        field: "DESCMOTIVO",
                        width: 30,
                        title: "Tipo Solicitud"
                    },
                    {
                        field: "NIVEL",
                        width: 20,
                        title: "Nivel"
                    },
                    {
                        field: "ID_MCDESCUENTO",
                        width: 20,
                        title: "Descargar",
                        template: function (d) {
                            if (d.NIVEL == 8 && d.ESTADO == 1) {
                                return '<button class="btn btn-outline-info" btn="' + d.ID_MCDCTOCANAL + '"><span class="fa fa-eye"></span></button> ';
                            } if (d.NIVEL == 9 && d.ESTADO == 1) {
                                return '<button class="btn btn-outline-info" btn="' + d.ID_MCDCTOCANAL + '"><span class="fa fa-file-download"></span></button> ';
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

});