ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#check-all", "click", function () {
    if ($("#check-all").attr('data-todos') != 0) {
        $("#check-all").attr('data-todos', 0)
        $("[type='checkbox']").removeAttr('checked');
    } else {
        $("#check-all").attr('data-todos', 1)
        $("[type='checkbox']").attr('checked', true);
    }
});

myarray = new Array();
count = 0;
countrec = 0;

grillaTrade();
ClassDataAccess.Events("#btnsend", "click", function () {
    /* var grid = $("#gridtrade").data("kendoGrid");
     console.log(grid._data);
     datos = grid._data
     user = datos.map(d => ({ id: d.ID_MDDESCUENTO}));
     console.log(user);*/

    ClassDataAccess.OpenWindows("#div-confirmacion-aprob", "Confirmación :", 200, 400);
    $("[type='checkbox']").each(function (key, element) {
        aprob = $(element).is(':checked') ? '2' : '1';
        countrec = aprob == 1  ? countrec + 1 : countrec
        count++
        var md = {
            ID_MDDESCUENTO: $(element).val(),
            VERIFICA1: aprob,
            OBS: "Oki"
        }
        if (count <= 20) {
            myarray.push(md);
            return;
        }

    });
    if (countrec > 0) {
        $("#div-motrech").fadeIn()
        $("#lblmensajerech").text("Vas a rechazar " + countrec + " registros, ")
        countrec = 0;
    } else {
        $("#div-motrech").fadeOut()
        $("#lblmensajerech").text("Vas a rechazar " + countrec + " registros, ")
        countrec = 0;
    }
    count = 0;
    console.log(myarray);
})



ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion-aprob");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    for (i in myarray) {
        if (myarray[i].VERIFICA1 == 1) {
            myarray[i].OBS = $("#txtmtrec").val();
        }
    }
    ClassDataAccess.Ajax(
        '/api/Solicitudes/ActualizarMasivo/',
        JSON.stringify(myarray),
        function (datos) {
            jsdata = JSON.parse(datos);
            grillaTrade();
            $("#lblmessage").text(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        }
    )
});

ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion-aprob");
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
});

function grillaTrade() {
ClassDataAccess.Ajax(
    "/api/Solicitudes/ListaTrade",
    '',
    function (datos) {
        jsdata = JSON.parse(datos);

        ClassDataAccess.Grilla("#gridtrade", jsdata,
            [
                {
                    field: "ID_MDDESCUENTO",
                    width: 30,
                    title: "<label id='check-all' data-todos = '0'>Selecionar (*)</label>",
                    template: function (d) {
                        return '<input type="checkbox"  value="' + d.ID_MDDESCUENTO + '">';
                    }
                },
                {
                    field: "FECING",
                    width: 80,
                    title: "Fec Solicitud",
                    template: function (d) {
                        return '<strong> ' + d.FECING.replace("T", " H ") + '</strong>';
                    }
                },
                {
                    field: "DESCRIPCION",
                    width: 50,
                    title: "Motivo"
                },
                {
                    field: "NAMECOMPLETE",
                    width: 110,
                    title: "Vendedor"
                },
                {
                    field: "OFICINA",
                    width: 70,
                    title: "Oficina "
                },
                {
                    field: "CANAL",
                    width: 60,
                    title: "Canal"
                },
                {
                    field: "RAZSOCCLIENTE",
                    width:90,
                    title: "Cliente"
                },
                {
                    field: "PRODUCTO",
                    width: 130,
                    title: "Producto"
                },
                {
                    field: "FECINI",
                    width: 40,
                    title: "Fec Inicio",
                    template: function (d) {
                        return '<strong> ' + d.FECINI.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "FECFIN",
                    width: 40,
                    title: "Fec Final",
                    template: function (d) {
                        return '<strong> ' + d.FECFIN.replace("T00:00:00", "") + '</strong>';
                    }
                },
                {
                    field: "PORCENDESC",
                    width: 30,
                    title: "% Descuento"
                },
                {
                    field: "CANT",
                    width: 30,
                    title: "Cantidad"
                },

                {
                    field: "MOTIVO",
                    width: 140,
                    title: "Justificación"
                }
            ]);
    }
)
}
