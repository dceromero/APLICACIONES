ClassDataAccess = new AccesosDatos();

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
                    field: "estado",
                    width: 20,
                    title: "Nivel"
                },
                {
                    field: "ID_MCDESCUENTO",
                    width: 20,
                    title: "ver",
                    template: function (d) {
                        return '<button class="btn btn-outline-info" btn="' + d.ID_MCDESCUENTO +'"><span class="fa fa-eye"></span></button> ';
                    }
                },
            ]
        )
    }
)


ClassDataAccess.Events("[btn]", "click", function () {
    ClassDataAccess.Ajax(
        '/api/Solicitudes/ExportExcel/' + $(this).attr("btn"),
        '',
        function (data) {
            jsdata = JSON.parse(data)
            ClassDataAccess.OpenWindows.funcionCerrar("#div-exp", "Formulario para Exportar a Excel : ", 500, 1200,
                function () {
                    ClassDataAccess.DestruirGrilla("#grid-exp-desc");
                }
            );
            ClassDataAccess.GrillaExcel("#grid-exp-desc", jsdata,
                [
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
    ClassDataAccess.CloseWindows("#div-exp")
    ClassDataAccess.DestruirGrilla("#grid-exp-desc");
})