ClassDataAccess = new AccesosDatos();


ClassDataAccess.Ajax(
    "/api/LogInventario/viewAprobacion/" + $("#lblid").val(),
    '',
    function (datos) {
        $("#txtusuario").val(datos.NOMBRE);
        $("#txtdocsap").val(datos.DOCUMENSAP);
        let fec = datos.FECINV.replace("T00:00:00", "")
        fecha = fec.split("-");
        $("#txtfeinv").val(`${fecha[0]}-${fecha[1]}-${fecha[2]}`);
        $("#txtmot").val(datos.OBSERVACION);
        $("#txtcentro").val(datos.CD);
        $("#txtcantsku").val(datos.CANTSKU);
        $("#txttotalinv").val(datos.VALTOTALINV);
        ajustep = 0;
        ajusten = 0;
        difeinv = 0;
        cont = 0;
        ClassDataAccess.GrillaAgregate("#div-grid-product", datos.detAI,
            [
                {
                    field: "CODPRODUCTO",
                    width: 20,
                    title: "Referencia"
                },
                {
                    field: "DESCRIPCION",
                    width: 50,
                    title: "Descripción",
                    footerTemplate: "Total Ajuste : "
                },
                {
                    field: "BODEGA",
                    width: 20,
                    title: "Bodega"
                },
                {
                    field: "UNDMED",
                    width: 20,
                    title: "Medida"
                },
                {
                    field: "CANTTEORICA",
                    width: 20,
                    title: "Teórica",
                    template: function (d) {
                        return `<div>${kendo.toString(d.CANTTEORICA, "n")}</div>`
                    },
                    footerTemplate: function (d) {
                        return `<div>${kendo.toString(d.CANTTEORICA.sum, "n")}</div>`;
                    }
                },
                {
                    field: "CANTIDAD",
                    width: 23,
                    title: "Cant Real",
                    template: function (d) {
                        return `<div>${kendo.toString(d.CANTIDAD, "n")}</div>`
                    },
                    footerTemplate: function (d) {
                        return `<div>${kendo.toString(d.CANTIDAD.sum, "n")}</div>`
                    }
                },
                {
                    field: "CANTDIF",
                    width: 22,
                    title: "Diferencia",
                    template: function (d) {
                        return `<div>${kendo.toString(d.CANTDIF, "n")}</div>`
                    },
                    footerTemplate: function (d) {
                        return `<div>${kendo.toString(d.CANTDIF.sum, "n")}</div>`
                    }
                },
                {
                    field: "VALORp",
                    width: 25,
                    title: "Valor (+)",
                    template: function (d) {
                        if (d.AJUSTAR == "NO") {
                            ajustep = ajustep + d.VALORp
                        }
                        return `<div>${kendo.toString(d.VALORp, "n")}</div>`
                    },
                    footerTemplate: function (d) {
                        ajuste = 0
                        return `<div>${kendo.toString(d.VALORp.sum, "n")}</div>`
                    }
                },
                {
                    field: "VALORn",
                    width: 25,
                    title: "Valor (-)",
                    template: function (d) {
                        if (d.AJUSTAR == "NO") {
                            ajusten = ajusten + d.VALORn
                        }
                        cont = cont + 1;
                        return `<div>${kendo.toString(d.VALORn, "n")}</div>`
                    },
                    footerTemplate: function (d) {
                        if (cont == 0) {
                            $("#txtpexactitud").val("No tienen Items");
                        } else {
                            tcont = ((($("#txtcantsku").val() - cont) / $("#txtcantsku").val()) * 100);
                            console.log(tcont);
                            $("#txtpexactitud").val(tcont.toString().substring(0, 8));
                        }

                        return `<div>${kendo.toString(d.VALORn.sum - ajusten, "n")}</div>`
                    }
                },
                {
                    field: "AJUSTAR",
                    width: 15,
                    title: "Ajuste",
                    footerTemplate: function (datos) {
                        difeinv = (datos.VALORp.sum + datos.VALORn.sum) - (ajusten + ajustep);
                        console.log("diferencia :" + difeinv);
                        $("#txtdifinv").val(difeinv);

                        if (difeinv == 0) {
                            $("#txtpdiferencia").val("No tiene Diferencia")
                        } else {
                            tdif = ((difeinv / $("#txttotalinv").val()) * 100)
                            $("#txtpdiferencia").val(tdif.toString().substring(0, 8));
                        }
                        return `<div>${kendo.toString(difeinv, "n")}</div>`
                    }
                },
                {
                    field: "JUSTIFICACION",
                    width: 30,
                    title: "Justificación"
                },

            ],
            [
                { field: "CANTTEORICA", aggregate: "sum" },
                { field: "CANTIDAD", aggregate: "sum" },
                { field: "CANTDIF", aggregate: "sum" },
                { field: "VALORp", aggregate: "sum" },
                { field: "VALORn", aggregate: "sum" }
            ]
        )

        ClassDataAccess.Grilla("#div-grid-files", datos.listDocSap,
            [
                {
                    field: "NOM_DOCUMENTO",
                    width: 20,
                    title: "Soportes",
                    template: function (d) {
                        return '<a  target="_blank" href="/ArchivosSap/' + d.NAMEFILE + '" class="btn btn-outline-success" aprob><span class="fa fa-file-pdf-o">' + d.NAMEFILE + '</span></a>'
                    },
                }
            ])

    })

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
    location.href = "/LogInventario/ListInventario/";
});


ClassDataAccess.Events("#btnconfirm", "click", function () {
    parametros = {
        ID_MOVCABAJ: $("#lblid").val(),
        APROBGRFI: 2,
    }

    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    ClassDataAccess.Ajax('/api/LogInventario/AprobacionAI/', JSON.stringify(parametros),
        function (data) {
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text("La Solicitud ha sido aprobada")
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 140, 300);
        }
    )
});

ClassDataAccess.Events("#btnreject", "click", function () {
    parametros = {
        ID_MOVCABAJ: $("#lblid").val(),
        APROBGRFI: 1,
    }
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    ClassDataAccess.Ajax('/api/LogInventario/AprobacionAI/', JSON.stringify(parametros),
        function (data) {
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text("La Solicitud ha sido Rechazada")
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 140, 300);
        }
    )
})

