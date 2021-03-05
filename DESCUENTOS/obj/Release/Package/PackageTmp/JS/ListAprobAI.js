ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/LogInventario/listAprobacion",
    '',
    function (datos) {
        ClassDataAccess.Grilla("#div-detail-inventario", datos,
            [
                {
                    field: "FECING",
                    width: 30,
                    title: "Fecha Ingreso",
                    template: function (d) {
                        return '<strong> ' + d.FECING.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "FECINV",
                    width:25,
                    title: "Fecha Inventario",
                    template: function (d) {
                        return '<strong> ' + d.FECINV.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "DOCUMENSAP",
                    width: 25,
                    title: "Documento SAP"
                },
                {
                    field: "NOMBRE",
                    width: 30,
                    title: "Supervisor Logística"
                },
                {
                    field: "OBSERVACION",
                    width: 40,
                    title: "Observación"
                },
                {
                    field: "ID_MOVCABAJ",
                    width: 30,
                    title: "Detalle",
                    template: function (d) {
                        return '<a  href="/LogInventario/DetalleInventario/' + d.ID_MOVCABAJ + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Ir al Detalle</span></a>'
                    }
                }
            ])
       
    }
)