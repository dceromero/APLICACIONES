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

var jsdata;
function Grilla() {
    MCDESCUENTOS = {
        FECING: $("#txtfecini").val(),
        FECFIN: $("#txtfecfin").val()
    }
    ClassDataAccess.Ajax(
        '/api/Solicitudes/detalleConsolidado',
        JSON.stringify(MCDESCUENTOS),
        function (datos) {
            jsdata = JSON.parse(datos);
            ClassDataAccess.GrillaExcel("#div-grid-descuentos", jsdata,
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
                        field: "CODOFICINA",
                        width: 25,
                        title: "Oficina"
                    },
                    {
                        field: "CODCANAL",
                        width: 25,
                        title: "Canal"
                    },
                    {
                        field: "SUPERVISOR",
                        width: 25,
                        title: "Super Visor"
                    },
                    {
                        field: "CODUSUARIORAZ",
                        width: 25,
                        title: "Raz"
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
                        field: "CODPRODUCTO",
                        width: 25,
                        title: "Cod Producto "
                    },
                    {
                        field: "DESCRIPCION",
                        width: 40,
                        title: "Producto"
                    },
                    {
                        field: "PORCENDESC",
                        width: 40,
                        title: "% Desc"
                    },
                    {
                        field: "CANT",
                        width: 40,
                        title: "Cant"
                    }
                ]
            )
        }
    );
}


function GrillaDetalle() {
    ClassDataAccess.GrillaExcel("#div-grid-detdescuentos", jsdata,
        [
            {
                field: "CODOFICINA",
                width: 25,
                title: "Oficina"
            },
            {
                field: "CODCANAL",
                width: 25,
                title: "Canal"
            },
            {
                field: "CODCLIENTE",
                width: 25,
                title: "Nit"
            },
            {
                field: "CODPRODUCTO",
                width: 25,
                title: "Cod Producto "
            },
            {
                field: "PORCENDESC",
                width: 40,
                title: "% Desc"
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
        ]
    );

}
