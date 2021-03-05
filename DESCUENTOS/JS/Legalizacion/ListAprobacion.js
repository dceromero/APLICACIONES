

ClassDataAccess = new AccesosDatos();

Grilla();
id = 0;
aprob = 0

ClassDataAccess.Events("#btnconfirm", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar) {
        alt = 110;
        ancho = 300;
        $("#lblpregunta").text("Aprobar");
        aprob = 2;
        id = $(this).attr("data");
        ClassDataAccess.OpenWindows("#div-confirmacion", "Confirmación :", alt, ancho);
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

}
);
ClassDataAccess.Events("#btnreject", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[validarcampos] [required]");
    if (validar) {
        alt = 160;
        ancho = 300;
        $("#div-confirmacion2 #lblpregunta").text("Rechazar");
        aprob = 1;
        id = $(this).attr("data");
        $("#div-confirmacion2 #div-ctr-rech").show();
        ClassDataAccess.OpenWindows("#div-confirmacion2", "Confirmación :", alt, ancho);
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

}
);

ClassDataAccess.Events("#btndoc", "click", function () {
    data = JSON.parse($(this).attr("data"));
    $("#table-griddetail").html("");
    for (d in data) {

        $("#table-griddetail").append('<tr><td class="text-left"><a target="_black" href="../../ArchivoLegalizacion/' + data[d].NOMBRE_ARCHIVO + '" class="btn btn-sm    btn-outline-success">' + data[d].NOMBRE_ARCHIVO + '</a></td></tr>');
    }
    ClassDataAccess.OpenWindows("#div-document", "Documentos", "200", "420")
    $("#div-confirmacion_wnd_title").addClass("text-center")
})
ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
});

ClassDataAccess.Events("#btncancel1", "click", function () {
    $("#div-confirmacion2 #txtrech").val("");
    ClassDataAccess.CloseWindows("#div-confirmacion2");
});

ClassDataAccess.Events("#btn-close-message", "click", function () {
    $("#lblmessage").text("");
    ClassDataAccess.LimpiarCampos("[required]");
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
});

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});

ClassDataAccess.Events("#btnsave", "click", function () {
    if (aprob == 2) {
        ClassDataAccess.CloseWindows("#div-confirmacion");
    } else {
        ClassDataAccess.CloseWindows("#div-confirmacion2");
    }
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 110, 300);
    var mensaje = aprob == 2 ? "Oki" : $("#div-confirmacion2 #txtrech").val();
    nota = {
        APROBCOORTD: aprob,
        ID_MCNOTAXPRECIO: id,
        OBS_COORTRADE: mensaje
    }
    ClassDataAccess.Ajax('/api/Trade/aprobLegalizacion/', JSON.stringify(nota),
        function (datos) {
            Mensaje = datos == null ? "Comuniquese con Sistemas" : datos.JEFE;
            $("#lblmessage").text(Mensaje);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 110, 300);
        });
})

ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "./listaprobacion";
});

function Grilla() {
    ClassDataAccess.getAjax('/api/Trade/listAprobacionLegal/', '', function (datos) {
        ClassDataAccess.Grilla("#div-grid-aprobacion", datos,
            [
                {
                    field: "FEC_INGRESO",
                    width: 25,
                    title: "Fecha Ingreso",
                    template: function (d) {
                        fec = d.FEC_INGRESO.replace("T", " Hr: ").split('.')
                        fec1 = fec[0].split(':')
                        return fec1[0] + fec1[1] + ':' + fec1[2];
                    }
                },
                {
                    field: "FEC_LEGALIZA",
                    width: 25,
                    title: "Fecha Legalización",
                    template: function (d) {
                        fec = d.FEC_LEGALIZA.replace("T", " Hr: ").split('.')
                        fec1 = fec[0].split(':')
                        return fec1[0] + fec1[1] + ':' + fec1[2];
                    }
                },
                {
                    field: "CONCEPTO",
                    width: 30,
                    title: "Concepto"
                },
                {
                    field: "SOLICITANTE",
                    width: 40,
                    title: "Supervisor"
                },
                {
                    field: "CLIENTE",
                    width: 40,
                    title: "Cliente"
                },
                {
                    field: "VALSOL",
                    width: 15,
                    title: "Solicit",
                    template: function (d) {
                        return '<div><strong> ' + kendo.toString(d.VALSOL, "c0") + '</strong></div>';
                    }
                },
                {
                    field: "VALLEG",
                    width: 15,
                    title: "Legaliz",
                    template: function (d) {
                        return '<div><strong> ' + kendo.toString(d.VALLEG, "c0") + '</strong></div>';
                    }
                },
                {
                    field: "ID_LEGALIZA",
                    width: 30,
                    title: "Aprobacíon",
                    template: function (d) {
                        /*
                         *<button class="btn btn-outline-info" >Aprobar</button>
                         *<button class="btn btn-outline-danger" >Rechazar</button>
                         */
                        return `<div style="width: 100%; text-align: center!important;">
                                    <img id="btnconfirm" data="${d.ID_MCNOTACOMERCIAL}" data-toggle="tooltip" title="Aprobar" src="../Image/Aprobar.ico" style="width:32px; height:32px"/>
                                    <img id="btnreject" data="${d.ID_MCNOTACOMERCIAL}"  data-toggle="tooltip" title="Rechazar"  src="../Image/cancelar.ico" style="width:32px; height:32px"/>
                                    <a target='_black' href='./aprobacion/${d.ID_MCNOTACOMERCIAL}'><img  data-toggle="tooltip" title="Detalle"  src="../Image/Detalle.png" style="width:28px; height:28px"/><a/>
                                    <img id="btndoc" data='${JSON.stringify(d.listDocument).toString()}'  data-toggle="tooltip" title="Documentos"  src="../Image/pdf.ico" style="width:28px; height:28px"/>
                                 <div>`;

                    }
                }
            ]
        )
    })

}