ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        var reporte = {
            FECINI: $("#txtfecini").val(),
            FECFIN: $("#txtfecfin").val()
        };
        ClassDataAccess.Ajax("/api/Reportes/InformeVendedor/", JSON.stringify(reporte),
            function (datos) {
                jsdatos = JSON.parse(datos);
                ClassDataAccess.Grilla("#div-grid-pedidos", jsdatos,
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
                            field: "ID_MCDESCUENTO",
                            width: 40,
                            title: "Aprobar",
                            template: function (d) {
                                return '<a  href="/Descuentos/DetalleDescuento/' + d.ID_MCDESCUENTO + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Ir al Detalle</span></a>'
                            }
                        }
                    ]
                )
            }
        )
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})