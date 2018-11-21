ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Solicitudes/ListarEncabezados",
    '',
    function (datos) {
        jsdata = JSON.parse(datos);
        ClassDataAccess.Grilla("#grid-autorizaciones", jsdata,
            [
                {
                    field: "CODCLIENTE",
                    width: 30,
                    title: "Nit"
                },
                {
                    field: "RAZSOCCLIENTE",
                    width: 70,
                    title: "Nombre Cliente"
                },
                {
                    field: "NAMEOFICVENTA",
                    width: 50,
                    title: "Oficina"
                },
                {
                    field: "FECINI",
                    width: 30,
                    title: "Fecha Inicio",
                    template: function (d) {
                            return '<strong> ' + d.FECINI.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "FECFIN",
                    width: 30,
                    title: "Fecha Fin",
                    template: function (d) {
                        return '<strong> ' + d.FECFIN.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "subtotal",
                    width: 30,
                    title: "Sub Total",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.subtotal, "c0")+ '</strong>';
                    }
                },
                {
                    field: "Descuento",
                    width: 30,
                    title: "Descuento",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.Descuento, "c0") + '</strong>';
                    }
                },
                {
                    field: "total",
                    width: 30,
                    title: "Total",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.total, "c0") + '</strong>';
                    }
                },
                {
                    field: "ID_MCDESCUENTO",
                    width: 40,
                    title: "Aprobar",
                    template: function (d) {
                        return '<a  href="/Descuentos/Autorizacion/' + d.ID_MCDESCUENTO+'" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Aprobar</span></a>'
                    }
                }
            ])
    }
)
