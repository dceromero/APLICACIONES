ClassDataAccess = new AccesosDatos();


ClassDataAccess.Events("[btn-pdf]", "click", function () {
    ClassDataAccess.getAjax('/api/LogInventario/viewPDf/' + $(this).attr("btn-pdf"), '',
        function (data) {
            var jsondato = data;
            location.target = "_blank";
            location.href = `/FORMATOSAP/${jsondato}.pdf`;
        });
})

ClassDataAccess.Ajax(
    "/api/LogInventario/listStateSup",
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
                    title: "Documeto SAP"
                },
                {
                    field: "OBSERVACION",
                    width: 40,
                    title: "Observación"
                },
                {
                    field: "APROBJFCD",
                    width: 40,
                    title: "Aprobación",
                    template: function (d) {
                        if (d.APROBJFCD == 0) {
                            return "Pendiente por Jefatura"
                        } else if (d.APROBJFCD == 1) {
                            return "Rechazado por Jefatura"
                        } else {
                            if (d.APROBJFAL == 0) {
                                return "Pendiente por Jefatura Nacional"
                            } else if (d.APROBJFAL == 1) {
                                return "Rechazado por Jefatura Nacional"
                            } else {
                                if (d.APROBCONTB == 0) {
                                    return "Pendiente Líder de Contabilidad "
                                } else if (d.APROBJFAL == 1) {
                                    return "Rechazado Líder de Contabilidad "
                                } else {
                                    if (d.APROBGTSC == 0) {
                                        return "Pendiente por Gerencia de Supply"
                                    } else if (d.APROBGTSC == 1) {
                                        return "Rechazado por Gerencia de Supply"
                                    } else {
                                        if (d.APROBGRFI == 0) {
                                            return "Pendiente por Gerencia  Financiera"
                                        } else if (d.APROBGRFI == 1) {
                                            return "Rechazado por Gerencia Financiera"
                                        } else {
                                            if (d.APROBGERGEN == 0) {
                                                return "Pendiente por Gerencia  General"
                                            } else if (d.APROBGERGEN == 1) {
                                                return "Rechazado por Gerencia General"
                                            } else {
                                                return '<a  href="/LogInventario/DetalleSupervisor/' + d.ID_MOVCABAJ + '" class="btn btn-outline-success" aprob><span class="fa fa-file-pdf-o">Detalle</span></a> &nbsp <a btn-pdf ="' + d.ID_MOVCABAJ + '" class="btn btn-outline-danger" aprob><span class="fa fa-file-pdf-o">PDF</span></a>'

                                            }
                                        }
                                    }
                                }
                            }
                        }


                    }
                },
                {
                    field: "ID_MOVCABAJ",
                    width: 30,
                    title: "Detalle",
                    template: function (d) {
                        return '<a  href="/LogInventario/DetalleSupervisor/' + d.ID_MOVCABAJ + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Ir al Detalle</span></a>'
                    }
                }
            ])
       
    }
)