ClassDataAccess = new AccesosDatos();


ClassDataAccess.getAjax('/api/Trade/listNotasComerciales/', '', function (datos) {
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
                field: "CONCEPTO",
                width: 40,
                title: "Concepto"
            },
            {
                field: "cliente",
                width: 40,
                title: "Cliente"
            },
            {
                field: "VALOR",
                width: 20,
                title: "Valor Nota",
                template: function (d) {
                    return '<strong> ' + kendo.toString(d.VALOR, "c0") + '</strong>';
                }
            },
            {
                field: "ID_MCNOTACOMERCIAL",
                width: 20,
                title: "Aprobación",
                template: function (d) {
                    return '<a  href="/Trade/Modificacion/' + d.ID_MCNOTACOMERCIAL + '" class="btn btn-outline-success" aprob><span class="fa fa-check-circle">&nbsp;&nbsp;Detalle</span></a>'
                }
            }
        ]
    )
})
