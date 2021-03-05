ClassDataAccess = new AccesosDatos();


ClassDataAccess.Events("[btn-pdf]", "click", function () {
    ClassDataAccess.getAjax('/api/LogInventario/viewPDf/' + $(this).attr("btn-pdf"), '',
        function (data) {
            var jsondato = data;
            location.target = "_blank";
            location.href = `/FORMATOSAP/${jsondato}.pdf`;
        });
})

ClassDataAccess.Events("#btn-info-inv", "click", function () {
    if ($("#txtfecinv").val() == "") {
        console.log("entro")
    } else {

        parametro = {
            FECINV: $("#txtfecinv").val() + "-01",
            FECING: $("#txtfechasta").val() + "-01",
        };

        ClassDataAccess.Ajax("/api/LogInventario/infoState/" , JSON.stringify(parametro),
            function (data) {
                ClassDataAccess.GrillaExcelGrupable("#div-info-inventario", data,
                    [
                        {
                            field: "FECINV",
                            width: 10,
                            title: "Fecha Inv",
                            template:function(d) {
                                return d.FECINV.replace("T00:00:00","");
                            }
                        },
                        {
                            field: "SUPERVISOR",
                            width: 20,
                            title: "Responsable",
                        },  
                        {
                            field: "CENTRO",
                            width: 20,
                            title: "Centro Distribucíon",
                        },       
                        {
                            field: "BODEGA",
                            width: 20,
                            title: "Alamacen"
                        },
                        {
                            field: "APROBJFCD",
                            width: 20,
                            title: "Estado Solicitud",
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
                    ],
                )
            })
    }
})