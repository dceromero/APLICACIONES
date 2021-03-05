ClassDataAccess = new AccesosDatos();

ClassDataAccess.Tab("#div-tab");

GrillaSinRegistrar(0);

ClassDataAccess.Events("[data-proceso]", "click", function () {
    id = $(this).attr("data-proceso");
    if (id == 0) {
        GrillaSinRegistrar(id);
    } else if (id == 1) {
        GrillaRegistrados(id);
    } else {
        GrillaRechazados(id);
    }

});

ClassDataAccess.Events("[download]", "click",
    function () {
        ClassDataAccess.Ajax("/api/Cartera/Download/" + $(this).attr("download"), '',
            function (dato) {
                window.open("../../FORMATOCUPO/" + dato + ".pdf");
            }
        );
    }
);

ClassDataAccess.Events("[sendNotify]", "click",
    function () {
        ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje", 100, 300);
        ClassDataAccess.Ajax(
            "/api/Cartera/Notificacion/" + $(this).attr("sendNotify"),
            '',
            function (datos) {
                ClassDataAccess.CloseWindows("#div-mensaje");
                $("#lblmessage").text(datos);
                ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 100, 300);
            }
        );
    });

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
    location.href = "/Cartera/InformeGeneral/";
});

function GrillaRechazados(id) {
    ClassDataAccess.Ajax(
        "/api/Cartera/InformeGeneral/" + id,
        '',
        function (datos) {
            datosjs = JSON.parse(datos);
            ClassDataAccess.Grilla("#grid-rc", datosjs,
                [
                    {
                        field: "FECSOL",
                        width: 50,
                        title: "Fecha Solicitud",
                        template: function (d) {
                            return '<strong> ' + d.FECSOL.replace("T", " H: ") + '</strong>';
                        }
                    },
                    {
                        field: "NOMBRE",
                        width: 70,
                        title: "Vendedor"
                    },
                    {
                        field: "CLIENTE",
                        width: 70,
                        title: "Cliente"
                    },
                    {
                        field: "TSOL",
                        width: 60,
                        title: "Tipo Solicitud"
                    },
                    {
                        field: "OBS",
                        width: 80,
                        title: "Observación"
                    }
                ]
            );
        });
}
function GrillaRegistrados(id) {
    ClassDataAccess.Ajax(
        "/api/Cartera/InformeGeneral/" + id,
        '',
        function (datos) {
            datosjs = JSON.parse(datos);
            ClassDataAccess.Grilla("#grid-rs", datosjs,
                [
                    {
                        field: "FECSOL",
                        width: 50,
                        title: "Fecha Solicitud",
                        template: function (d) {
                            return '<strong> ' + d.FECSOL.replace("T", " H: ") + '</strong>';
                        }
                    },
                    {
                        field: "NOMBRE",
                        width: 70,
                        title: "Vendedor"
                    },
                    {
                        field: "CLIENTE",
                        width: 70,
                        title: "Cliente"
                    },
                    {
                        field: "TSOL",
                        width: 70,
                        title: "Tipo Solicitud"
                    },
                    {
                        field: "IDSOL",
                        width: 30,
                        title: "Descargar",
                        template: function (d) {
                            return '<img download="' + d.IDSOL + '" style="max-width=2em; max-height: 3em;" src="../Image/pdf.ico" />';
                        }
                    }
                ]
            );
        });
}
function GrillaSinRegistrar(id) {
    ClassDataAccess.Ajax(
        "/api/Cartera/InformeGeneral/" + id,
        '',
        function (datos) {
            datosjs = JSON.parse(datos);
            ClassDataAccess.Grilla("#grid-sr", datosjs,
                [
                    {
                        field: "FECSOL",
                        width: 50,
                        title: "Fecha Solicitud",
                        template: function (d) {
                            return '<strong> ' + d.FECSOL.replace("T", " H: ") + '</strong>';
                        }
                    },
                    {
                        field: "NOMBRE",
                        width: 70,
                        title: "Vendedor"
                    },
                    {
                        field: "CLIENTE",
                        width: 70,
                        title: "Cliente"
                    },
                    {
                        field: "TSOL",
                        width: 70,
                        title: "Tipo Solicitud"
                    },
                    {
                        field: "IDSOL",
                        width: 30,
                        title: "Descargar",
                        template: function (d) {
                            return '<img download="' + d.IDSOL + '" style="max-width=2em; max-height: 3em;" src="../Image/pdf.ico" />';
                        }
                    },
                    {
                        field: "IDSOL",
                        width: 30,
                        title: "Notificar",
                        template: function (d) {
                            return '<img sendNotify="' + d.IDSOL + '" style="max-width=2em; max-height: 3em;" src="../Image/send.ico" />';
                        }
                    }
                ]
            );
        });
}