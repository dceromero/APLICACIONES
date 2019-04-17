ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "../api/Canales/ListaXAutirizar",
    '',
    function (datos) {
        jsdatos = JSON.parse(datos);
        console.log(jsdatos)
        ClassDataAccess.Grilla("#grid-autorizaciones", jsdatos,
            [
                {
                    field: "FECING",
                    width: 60,
                    title: "Fecha Ingreso",
                    template: function (d) {
                        return '<strong> ' + d.FECING.replace("T", "Hora: ") + '</strong>';
                    }
                },
                {
                    field: "VENDEDOR",
                    width: 65,
                    title: "Vendedor / Raz "
                },
                {
                    field: "NAMEOFICVENTA",
                    width: 40,
                    title: "Oficina"
                },
                {
                    field: "GRPNOMBRE",
                    width: 40,
                    title: "Grupo Cliente"
                },
                {
                    field: "FECINI",
                    width: 32,
                    title: "Fecha Inicio",
                    template: function (d) {
                        return '<strong> ' + d.FECINI.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "FECFIN",
                    width: 32,
                    title: "Fecha Final",
                    template: function (d) {
                        return '<strong> ' + d.FECFIN.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "DESCUENTO",
                    width: 33,
                    title: "Valor DCTO",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.DESCUENTO, "c0") + '</strong>';
                    }
                },
                {
                    field: "TOTAL",
                    width: 35,
                    title: "Valor Pedido",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.TOTAL, "c0") + '</strong>';
                    }
                },
                {
                    field: "ID_MCDCTOCANAL",
                    width: 43,
                    title: "Aprobar",
                    template: function (d) {
                        return '<a  href="/Descuentos/AutorizacionCanal/' + d.ID_MCDCTOCANAL + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Ir al Detalle</span></a>'
                    }
                }
            ]
        );
    }
);