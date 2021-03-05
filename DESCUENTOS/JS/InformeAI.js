ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-info-inv", "click", function () {
    if ($("#txtfecinv").val() == "") {

    } else {
        ClassDataAccess.getAjax("/api/LogInventario/listInforme/" + $("#txtfecinv").val() + "-01", '',
            function (data) {
                ClassDataAccess.GrillaExcelGrupable("#div-info-inventario", data,
                    [
                        {
                            field: "CD",
                            width: 20,
                            title: "Centro Distribucíon",
                        },                        
                        {
                            field: "RESPONSABLE",
                            width: 20,
                            title: "Responsable",
                            template: function (d) {
                                resp = d.RESPONSABLE.split("-")
                                return resp[1];
                            }
                        },
                        {
                            field: "BODEGA",
                            width: 20,
                            title: "Alamacen",
                            footerTemplate: function () {
                                return "Total Ajustar :"
                            }
                        },
                        {
                            field: "VALORTOTAL",
                            width: 20,
                            title: "Valor Ajuste",
                            aggregates: ["sum"],
                            groupHeaderColumnTemplate: "Total: #=sum#",
                            footerTemplate: "#: sum #",
                        },
                    ],
                    [
                        { field: "VALORTOTAL", aggregate: "sum" },
                    ]
                )
            })
    }
})