ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Cartera/ListadoXAprobar",
    '',
    function (datos) {
        jsdata = JSON.parse(datos);
        ClassDataAccess.Grilla("#grid-autorizaciones", jsdata,
            [
                {
                    field: "FECSOL",
                    width: 50,
                    title: "Fec Solicitud"
                },
                {
                    field: "NOMBRE",
                    width: 70,
                    title: "Nombre"
                },
                {
                    field: "TSOL",
                    width: 70,
                    title: "Solicitud"
                },
                {
                    field: "CLIENTE",
                    width: 70,
                    title: "Cliente"
                },
                {
                    field: "CUPOSOLICITADO",
                    width: 40,
                    title: "Cupo Solicitado",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.CUPOSOLICITADO, "c0") + '</strong>';
                    }
                },
                {
                    field: "IDSOL",
                    width: 30,
                    title: "Detalle",
                    template: function (d) {
                        return '<a  href="/Cartera/Aprobacion/' + d.IDSOL + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Ir</span></a>'
                    }
                }
            ]);
    }
)