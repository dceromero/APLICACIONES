ClassDataAccess = new AccesosDatos();


var servicio = '/api/Legalizacion/actualizarPlanitilla/';

ClassDataAccess.Events("#btn-difprecio", "click", function () {
    ClassDataAccess.getAjax('/api/Trade/planilla/', '', function (datos) {
        servicio = '/api/trade/ActualizarFecha/';
        Grilla(datos)
    })
})

ClassDataAccess.Events("#btn-rprov", "click", function () {
    ClassDataAccess.getAjax('/api/Trade/PlanillaRProv/', '', function (datos) {
        servicio = '/api/Legalizacion/actualizarPlanRProv/';
        Grilla(datos)
    })
})


ClassDataAccess.Events("#btn-prov", "click", function () {
    ClassDataAccess.getAjax('/api/Trade/PlanillaProv/', '', function (datos) {
        servicio = '/api/Legalizacion/actualizarPlanProv/';
        Grilla(datos)
    })
})


ClassDataAccess.Events("#btn-legal", "click", function () {
    ClassDataAccess.getAjax('/api/Legalizacion/plantillaLegalizacion/', '', function (datos) {
        servicio = '/api/Legalizacion/actualizarPlanitilla/';
        Grilla(datos)
    })
})

function Grilla(datos) {
    console.log(servicio);
    if ($("#div-grid-detalle").attr('data-role') == 'grid') {
        ClassDataAccess.DestruirGrilla("#div-grid-detalle")

    }
    ClassDataAccess.GrillaExcel("#div-grid-detalle", datos,
        [
            {
                field: "documento",
                width: 12,
                title: "D"
            },
            {
                field: "docventa",
                width: 22,
                title: "Doct V"
            },
            {
                field: "codorganizacion",
                width: 20,
                title: "Org"
            },
            {
                field: "id_canal",
                width: 20,
                title: "Canal"
            },
            {
                field: "codsector",
                width: 20,
                title: "Sector"
            },
            {
                field: "solicitante",
                width: 25,
                title: "Solicit"
            },
            {
                field: "motivo",
                width: 25,
                title: "Mot"
            },
            {
                field: "bloqueofactura",
                width: 12,
                title: "B"
            },
            {
                field: "concepto",
                width: 40,
                title: "Concepto"
            },
            {
                field: "posicion",
                width: 20,
                title: "Posc"
            },
            {
                field: "codproducto",
                width: 30,
                title: "Código"
            },
            {
                field: "cantidad",
                width: 20,
                title: "Cant"
            },
            {
                field: "valor",
                width: 20,
                title: "Valor"
            },
            {
                field: "centro",
                width: 20,
                title: "Cent"
            },
            {
                field: "fecfact",
                width: 20,
                title: "Fecha"
            },
            {
                field: "tipofactura",
                width: 20,
                title: "Tipo Factura"
            }
        ]
    )

}



ClassDataAccess.Events(".k-grid-excel", "click", function () {
    ClassDataAccess.Ajax(
        servicio,
        '',
        function () {
            location.href = "/Legalizacion/planilla";
        });
});