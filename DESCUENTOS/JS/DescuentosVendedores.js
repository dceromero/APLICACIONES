ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {
    validar = ClassDataAccess.ValidarCampos('[required]');
    if (validar) {
        $("#profile-tab").removeClass("active show")
        $("#home-tab").addClass("active show")
        $("#profile").removeClass("active show")
        $("#home").addClass("active show")
        Grilla();
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})


ClassDataAccess.Events("#profile-tab", "click", function () {
    validar = ClassDataAccess.ValidarCampos('[required]');
    if (validar) {
        GrillaDetalle();
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})


ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
})

function Grilla() {
    MCDESCUENTOS = {
        FECING: $("#txtfecini").val(),
        FECFIN: $("#txtfecfin").val()
    }
    ClassDataAccess.Ajax(
        '/api/Solicitudes/listaDescuentos',
        JSON.stringify(MCDESCUENTOS),
        function (datos) {
            jsdata = JSON.parse(datos);
            ClassDataAccess.Grilla("#div-grid-descuentos", jsdata,
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
                        title: "Fecha Inicio"
                    },
                    {
                        field: "FECFIN",
                        width: 20,
                        title: "Fecha Fin"
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
                ]
            )
        }
    );
}


function GrillaDetalle() {
    MCDESCUENTOS = {
        FECING: $("#txtfecini").val(),
        FECFIN: $("#txtfecfin").val()
    }
    ClassDataAccess.Ajax(
        '/api/Solicitudes/detalleDescuentos',
        JSON.stringify(MCDESCUENTOS),
        function (datos) {
            jsdata = JSON.parse(datos);
            ClassDataAccess.Grilla("#div-grid-detdescuentos", jsdata,
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
                        title: "Fecha Inicio"
                    },
                    {
                        field: "FECFIN",
                        width: 20,
                        title: "Fecha Fin"
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
                        field: "DESCRIPCION",
                        width: 40,
                        title: "Producto"
                    },
                    {
                        field: "PORCENDESC",
                        width: 20,
                        title: "% Descuento"
                    },
                    {
                        field: "CANT",
                        width: 20,
                        title: "Cantidad"
                    },
                    {
                        field: "nivel",
                        width: 20,
                        title: "Estado",
                        template: function (d) {
                            if (d.nivel == 9 && d.DONWLOADEXCEL==1) {
                                return '<button style="height: 1em!important;" class="btn btn-outline-success"><span style="padding=0.5px!important">Finalizado</span></button> ';
                            } else if (d.nivel == 9 && d.DONWLOADEXCEL == 10) {
                                return '<button style="height: 1em!important;" class="btn btn-outline-danger"><span style="padding=0.5px!important">Error SAP</span></button> ';
                            } else if (d.nivel == 8) {
                                return '<button style="height: 1em!important;" class="btn btn-outline-primary"><span style="padding=0.5px!important">Pend. SAP</span></button> ';
                            }else if (d.nivel == -1) {
                                return '<button style="height: 1em!important;" class="btn btn-outline-danger"><span style="padding=0.5px!important">Rechazado</span></button> ';
                            } else {
                                return '<button style="height: 1em!important;" class="btn btn-outline-info"><span style="padding=0.5px!important">Pend. Aut ' + d.nivel + '</span></button> ';
                            }
                        }
                    },
                ]
            )
        }
    );
}
