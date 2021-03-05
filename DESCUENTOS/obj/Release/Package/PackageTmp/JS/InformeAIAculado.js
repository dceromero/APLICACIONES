ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#btn-info-inv", "click", function () {
    if ($("#txtfecinv").val() == "") {
        console.log("entro")
    } else {

        parametro = {
            FECINV: $("#txtfecinv").val() + "-01",
            FECING: $("#txtfechasta").val() + "-01",
        };

        ClassDataAccess.Ajax("/api/LogInventario/listInformeAcumulado/" , JSON.stringify(parametro),
            function (data) {
                ClassDataAccess.GrillaExcelGrupable("#div-info-inventario", data,
                    [
                        {
                            field: "FECINV",
                            width: 20,
                            title: "Fecha Inv",
                            template:function(d) {
                                return d.FECINV.replace("-01T00:00:00","");
                            }
                        },  
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