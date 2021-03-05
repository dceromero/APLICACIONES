ClassDataAccess = new AccesosDatos();


ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
})




function aleatorio(inferior, superior) {
    numPosibilidades = superior - inferior
    aleat = Math.random() * numPosibilidades
    aleat = Math.floor(aleat)
    return parseInt(inferior) + aleat
}

function dame_color_aleatorio() {
    hexadecimal = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F")
    color_aleatorio = "#";
    for (i = 0; i < 6; i++) {
        pos = aleatorio(0, hexadecimal.length)
        color_aleatorio += hexadecimal[pos]
    }
    return color_aleatorio
}


ClassDataAccess.Events("#btn-reptsolicitud", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        ClassDataAccess.Ajax(
            '/api/Reportes/DetalleSolicitud/?FECINI=' + $("#txtfecini").val() + '&FECFIN=' + $("#txtfecfin").val(),
            '',
            function (datos) {
                jsdatos = JSON.parse(datos);
                ClassDataAccess.GrillaExcelGrupable("#div-grid-rep-det-sol", jsdatos,
                    [
                        {
                            field: "VENDEDOR",
                            width: 90,
                            title: "Supervisor"
                        },
                        {
                            field: "TPSOL",
                            width: 90,
                            title: "Tipo Solicitud"
                        },
                        {
                            field: "FECING",
                            width: 90,
                            title: "Fecha de Elaboración"
                        },
                        {
                            field: "NAMECANALES",
                            width: 90,
                            title: "Canal"
                        },
                        {
                            field: "GRUPOCLI",
                            width: 90,
                            title: "Grupo Cliente"
                        },
                        {
                            field: "NAMEOFICVENTA",
                            width: 90,
                            title: "Oficina De Ventas"
                        },
                        {
                            field: "NIT",
                            width: 90,
                            title: "Nit"
                        },
                        {
                            field: "RAZSOCCLIENTE",
                            width: 90,
                            title: "Razón Social"
                        },
                        {
                            field: "FECINI",
                            width: 90,
                            title: "Fecha Inicial del Dscto"
                        },
                        {
                            field: "FECFIN",
                            width: 90,
                            title: "Fecha Final del Dscto"
                        },
                        {
                            field: "MATERIAL",
                            width: 90,
                            title: "Material"
                        },
                        {
                            field: "PORCENDESC",
                            width: 90,
                            title: "% Dscto"
                        },
                        {
                            field: "CANT",
                            width: 90,
                            title: "Cantidad"
                        },
                        {
                            field: "DESCMOTIVO",
                            width: 90,
                            title: "Motivo"
                        },
                        {
                            field: "JUSTMOT",
                            width: 90,
                            title: "Justificación del Motivo"
                        },
                        {
                            field: "VALOR",
                            width: 90,
                            title: "VALOR"
                        },
                        {
                            field: "SUBTOTAL",
                            width: 90,
                            title: "SUBTOTAL"
                        },
                        {
                            field: "DESCUENTO",
                            width: 90,
                            title: "DESCUENTO"
                        },
                        {
                            field: "TOTAL",
                            width: 90,
                            title: "TOTAL"
                        },
                        {
                            field: "OBS",
                            width: 90,
                            title: "Observación"
                        },
                        {
                            field: "ESTADO",
                            width: 90,
                            title: "Estado"
                        },

                    ]
                )

                ArrayColor = new Array();
                ArrayValores = new Array();
                ArrayTitles = new Array();
                for (j in jsdatos) {
                    ArrayColor[j] = dame_color_aleatorio();
                    ArrayValores[j] = jsdatos[j].VALOR;
                    ArrayTitles[j] = jsdatos[j].RAZSOCCLIENTE;
                }
                ClassDataAccess.Charts(
                    "Prueba",
                    "div-chart-rep-det-sol",
                    ArrayTitles,
                    ArrayColor,
                    ArrayValores,
                )
                
            }
        )

        ClassDataAccess.DestruirGrilla("#div-grid-rep-det-sol");
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

})