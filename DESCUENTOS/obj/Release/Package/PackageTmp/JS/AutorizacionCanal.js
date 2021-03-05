ClassDataAccess = new AccesosDatos();
$("[required]").attr('disabled', 'disabled');


$("#div-justi").fadeIn();
ClassDataAccess.Ajax(
    "/api/Canales/Encabezado/" + $("#lblid").val(),
    '',
    function (datos) {
        jsdata = JSON.parse(datos);
        console.log(jsdata);
        $("#cmbreg").html("").append("<option>" + jsdata.NAMEOFICVENTA + "</option>");
        $("#cmbofi").html("").append("<option>" + jsdata.NAMEOFICVENTA + "</option>");
        $("#cmbcanal").html("").append("<option>" + jsdata.NAMECANALES + "</option>");
        $("#cmbgrpclient").html("").append("<option>" + jsdata.GRPNOMBRE + "</option>");
        $("#txtfecini").val(jsdata.FECINI.replace("T00:00:00", ""));
        $("#txtfecfin").val(jsdata.FECFIN.replace("T00:00:00", ""));
        $("#cmbtpmot").html("").append("<option>" + jsdata.NAMEOFICVENTA + "</option>");
        $("#txtmot").val(jsdata.JUSTIFICACION);

        ClassDataAccess.Grilla("#div-detail-descuento", jsdata.VIEW_VALORPORCANAL,
            [

                {
                    field: "ID_MDDCTOCANAL",
                    width: 30,
                    title: "<label id='check-all' data-todos = '0'>Selecionar (*)</label>",
                    template: function (d) {
                        console.log(d.estado);
                        if (d.estado == 0) {
                            return '<span class="fa fa-minus-circle"></span>';
                        } else {
                            return '<input type="checkbox" checked value="' + d.ID_MDDCTOCANAL + '">';
                        }
                    }
                },
                {
                    field: "Material",
                    width: 60,
                    title: "Material"
                },
                {
                    field: "PORCENDCTO",
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
        );
    });

myarray = new Array();
count = 0;
ClassDataAccess.Events("#btnconfirm", "click", function () {
    $("[type='checkbox']").each(function (key, element) {
        aprob = $(element).is(':checked') ? '2' : '1';
        count = aprob == 1 ? count + 1 : count;
        var md = {
            ID_MDDCTOCANAL: $(element).val(),
            VERIFICA1: aprob,
            OBS: "Oki"
        };
        myarray.push(md);
    });
    if (count > 0) {
        $("#div-motrech").fadeIn();
        $("#lblmensajerech").text("Vas a rechazar " + count + " registros, ");
        count = 0;
    } else {
        $("#div-motrech").fadeOut();
        $("#lblmensajerech").text("Vas a rechazar " + count + " registros, ");
        count = 0;
    }
});

ClassDataAccess.Events("#btnsave", "click", function () {
    urlactual = window.location.href.toString().split("/");
    div = urlactual[4] == "Autorizacion" || urlactual[4] == "AutorizacionCanal"? "#div-confirmacion-aprob" : "#div-confirmacion";
    ClassDataAccess.CloseWindows(div);
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    for (i in myarray) {
        if (myarray[i].VERIFICA1 == 1) {
            myarray[i].OBS = $("#txtmtrec").val();
        }
    }
    ClassDataAccess.Ajax(
        '/api/Canales/ActualizarMD/',
        JSON.stringify(myarray),
        function (datos) {
            jsdata = JSON.parse(datos);            
            $("#lblmessage").text(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        }
    );
});

ClassDataAccess.Events("#btn-close-message, #btnatras", "click", function () {
    ClassDataAccess.Redirect("/Descuentos/AutorizacionesCanal");
});