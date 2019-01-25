ClassDataAccess = new AccesosDatos();
$("[required]").attr('disabled', 'disabled');
ClassDataAccess.Ajax(
    "/api/Solicitudes/Encabezados/" + $("#lblid").val(),
    '',
    function (datos) {
        jsdata = JSON.parse(datos)
        $("#cmbtpsol").html("").append("<option>" + jsdata.DESCRIPCION + "</option>");
        $("#cmbtpmot").html("").append("<option>" + jsdata.DESCMOTIVO + "</option>");
        $("#txtcliente").val(jsdata.RAZSOCCLIENTE);
        $("#txtfecini").val(jsdata.FECINI.replace("T00:00:00", ""));
        $("#txtfecfin").val(jsdata.FECFIN.replace("T00:00:00", ""));
        $("#txtmot").val(jsdata.MOTIVO);

        ClassDataAccess.Grilla("#div-detail-descuento", jsdata.VIEW_VALORPORCLIENTE,
            [

                {
                    field: "ID_MDDESCUENTO",
                    width: 30,
                    title: "<label id='check-all' data-todos = '0'>Selecionar (*)</label>",
                    template: function (d) {
                        console.log(d.estado)
                        if (d.estado == 0) {
                            return '<span class="fa fa-minus-circle"></span>'
                        } else {
                            return '<input type="checkbox" checked value="' + d.ID_MDDESCUENTO + '">';
                        }
                    }
                },
                {
                    field: "Material",
                    width: 60,
                    title: "Material"
                },
                {
                    field: "PORCENDESC",
                    width: 20,
                    title: "% Desc"
                },
                {
                    field: "CANT",
                    width: 25,
                    title: "Cantidad"
                },
                {
                    field: "subtotal",
                    width: 25,
                    title: "Subtotal",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.subtotal, "c0") + '</strong>';
                    }
                },
                {
                    field: "Descuento",
                    width: 25,
                    title: "Descuento",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.Descuento, "c0") + '</strong>';
                    }
                },
                {
                    field: "total",
                    width: 25,
                    title: "Total",
                    template: function (d) {
                        return '<strong> ' + kendo.toString(d.total, "c0") + '</strong>';
                    }
                }
            ]
        )
    })

ClassDataAccess.Events("#check-all", "click", function () {
    if ($("#check-all").attr('data-todos') != 0) {
        $("#check-all").attr('data-todos', 0)
        $("[type='checkbox']").removeAttr('checked');
    } else {
        $("#check-all").attr('data-todos', 1)
        $("[type='checkbox']").attr('checked', true);
    }
})

$("#div-justi").fadeIn()

myarray = new Array()
count = 0;
ClassDataAccess.Events("#btnconfirm", "click", function () {
    $("[type='checkbox']").each(function (key, element) {
        aprob = $(element).is(':checked') ? '2' : '1';
        count = aprob == 1 ? count + 1 : count
        var md = {
            ID_MDDESCUENTO: $(element).val(),
            VERIFICA1: aprob,
            OBS:"Oki"
        }
        myarray.push(md);
    });
    if (count > 0) {
        $("#div-motrech").fadeIn()
        $("#lblmensajerech").text("Vas a rechazar " + count + " registros, ")
        count = 0;
    } else {
        $("#div-motrech").fadeOut()
        $("#lblmensajerech").text("Vas a rechazar " + count + " registros, ")
        count = 0;
    }
})

ClassDataAccess.Events("#btnsave", "click", function () {
    urlactual = window.location.href.toString().split("/");
    div = urlactual[4] == "Autorizacion" ? "#div-confirmacion-aprob" : "#div-confirmacion"
    ClassDataAccess.CloseWindows(div);
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    for (i in myarray) {
        if (myarray[i].VERIFICA1 == 1) {
            myarray[i].OBS = $("#txtmtrec").val();
        }
    }
    ClassDataAccess.Ajax(
        '/api/Solicitudes/ActualizarSolicitud/',
        JSON.stringify(myarray),
        function (datos) {
            jsdata = JSON.parse(datos);
            $("#lblmessage").text(jsdata.message);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        }
    )
})

ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "/Descuentos/Autorizaciones";
})
