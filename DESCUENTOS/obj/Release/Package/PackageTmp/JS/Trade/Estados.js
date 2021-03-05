ClassDataAccess = new AccesosDatos();

ClassDataAccess.Events("#profile-tab", "click", function () {

    $("#profile-tab").removeClass("active show")
    $("#legal-tab").removeClass("active show")
    $("#home-tab").addClass("active show")
    $("#profile").removeClass("active show")
    $("#legal").removeClass("active show")
    $("#home").addClass("active show")
    ClassDataAccess.getAjax('/api/Trade/listNotasXActivacion/', '', function (datos) {
        ClassDataAccess.Grilla("#div-grid-activacion", datos,
            [
                {
                    field: "FEC_INGRESO",
                    width: 25,
                    title: "Fecha Ingreso",
                    template: function (d) {
                        fec = d.FEC_INGRESO.replace("T", " Hr: ").split('.')
                        fec1 = fec[0].split(':')
                        return fec1[0] + fec1[1] +':'+ fec1[2];
                    }
                },
                {
                    field: "CONCEPTO",
                    width: 30,
                    title: "Concepto"
                },
                {
                    field: "cliente",
                    width: 50,
                    title: "Cliente"
                },
                {
                    field: "VALOR",
                    width: 15,
                    title: "Valor Nota",
                    template: function (d) {
                        return '<div><strong> ' + kendo.toString(d.VALOR, "c0") + '</strong></div>';
                    }
                },
                {
                    field: "DOCSAP",
                    width: 15,
                    title: "Núm Nota"
                },
                {
                    field: "APROBCOORTD",
                    width: 30,
                    title: "Estado",
                    template: function (d) {
                        mensaje = '';
                        clase = 'btn btn-sm btn-outline-info';
                        boton = `<button class="${clase}" >${mensaje}</button>`;
                        if (d.APROBGERREG == 0) {
                            mensaje = 'Pendiente Gerencia Regional'
                            boton = `<button class="${clase}" >${mensaje}</button>`;
                        } else if (d.APROBGERREG == 1) {
                            mensaje = 'Anulado Gerencia Regional'
                            boton = `<button class="${clase}" >${mensaje}</button>`;
                        } else {
                            if (d.APROBCOORTD == 0) {
                                mensaje = 'Pendiente Coordinador Trade'
                                boton = `<button class="${clase}" >${mensaje}</button>`;
                            }
                            else if (d.APROBCOORTD == 1 && d.APROBGERCOM == 0) {
                                mensaje = 'Anulado Coord Trade'
                                boton = `<button class="${clase}" >${mensaje}</button>`;
                            }
                            else {
                                if (d.APROBGERCOM == 0) {
                                    mensaje = 'Pendiente Gerencia Comercial'
                                    boton = `<button class="${clase}" >${mensaje}</button>`;
                                }
                                else if (d.APROBGERCOM == 1) {
                                    mensaje = 'Anulado Gerencia Comercial'
                                    boton = `<button class="${clase}" >${mensaje}</button>`;
                                }
                                else {
                                    if (d.APROBJFTRADE == 0) {
                                        mensaje = 'Pendiente Jefe Trade'
                                        boton = `<button class="${clase}" >${mensaje}</button>`;
                                    }
                                    else if (d.APROBJFTRADE == 1) {
                                        mensaje = 'Anulado Jefe Trade'
                                        boton = `<button class="${clase}" >${mensaje}</button>`;
                                    }
                                    else {
                                        mensaje = 'Legalizar'
                                        clase = 'btn btn-sm btn-outline-success';
                                        boton = `<a href='/legalizacion/index/${d.ID_MCNOTACOMERCIAL}' class="${clase}" >${mensaje}</a>`;
                                    }
                                }
                            }
                        }
                        return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;
                    }

                },
            ]
        )
    })
});

ClassDataAccess.Events("#legal-tab", "click", function () {

    $("#profile-tab").removeClass("active show")
    $("#home-tab").removeClass("active show")
    $("#legal-tab").addClass("active show")

    $("#profile").removeClass("active show")
    $("#home").removeClass("active show")
    $("#legal").addClass("active show")
    ClassDataAccess.getAjax('/api/Trade/listLegalizacionSup/', '', function (datos) {
        ClassDataAccess.Grilla("#div-grid-legal", datos,
            [
                {
                    field: "FEC_INGRESO",
                    width: 20,
                    title: "Fecha Ingreso",
                    template: function (d) {
                        fec = d.FEC_INGRESO.replace("T", " Hr: ").split('.')
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
                    field: "CLIENTE",
                    width: 40,
                    title: "Cliente"
                },
                {
                    field: "VALSOL",
                    width: 15,
                    title: "Solicitado",
                    template: function (d) {
                        return '<div><strong> ' + kendo.toString(d.VALSOL, "c0") + '</strong></div>';
                    }
                },
                {
                    field: "VALLEG",
                    width: 15,
                    title: "Legalizado",
                    template: function (d) {
                        return '<div><strong> ' + kendo.toString(d.VALLEG, "c0") + '</strong></div>';
                    }
                },
                {
                    field: "NRO_PROV",
                    width: 15,
                    title: "Provisión"
                },
                {
                    field: "NRO_REVPROV",
                    width: 15,
                    title: "Rev Provis"
                },
                {
                    field: "NRO_SAP",
                    width: 15,
                    title: "Núm Nota"
                },                   
                {
                    field: "APROBCOORTD",
                    width: 25,
                    title: "Estado",
                    template: function (d) {
                        mensaje = '';
                        clase = 'btn btn-sm btn-outline-info';
                        if (d.APROBGERREG == 0) {
                            mensaje = 'Pendiente Gerencia Regional'
                            boton = `<button class="${clase}" >${mensaje}</button>`;
                            return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;

                        } else if (d.APROBGERREG == 1) {
                            mensaje = 'Anulado Gerencia Regional'
                            boton = `<a href='/legalizacion/index/${d.ID_MCNOTACOMERCIAL}' class="${clase}" >${mensaje}</a>`;
                            return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;
                        }
                        else {
                            if (d.APROBCOORDTRADE == 0) {
                                mensaje = 'Pendiente Coordinador Trade'
                                boton = `<button class="${clase}" >${mensaje}</button>`;
                                return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;

                            }
                            else if (d.APROBCOORDTRADE == 1) {
                                mensaje = 'Anulado Coordinador Trade'
                                boton = `<a href='/legalizacion/index/${d.ID_MCNOTACOMERCIAL}' class="${clase}" >${mensaje}</a>`;
                                return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;

                            }
                            else {
                                if (d.APROBGERCOM == 0) {
                                    mensaje = 'Pendiente Gerencia Comercial'
                                    boton = `<button class="${clase}" >${mensaje}</button>`;
                                    return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;
                                }
                                else if (d.APROBGERCOM == 1) {
                                    mensaje = 'Anulado Gerencia Comercial'
                                    boton = `<a  href='/legalizacion/index/${d.ID_MCNOTACOMERCIAL}' class="${clase}" >${mensaje}</a>`;
                                    return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;

                                }
                                else {
                                    if (d.APROBJFTRADE == 0) {
                                        mensaje = 'Pendiente Jefe Trade'
                                        boton = `<button class="${clase}" >${mensaje}</button>`;
                                        return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;

                                    }
                                    else if (d.APROBJFTRADE == 1) {
                                        mensaje = 'Anulado Jefe Trade'
                                        boton = `<a href='/legalizacion/index/${d.ID_MCNOTACOMERCIAL}' class="${clase}" >${mensaje}</a>`;
                                        return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;

                                    } else {
                                        console.log("Entro en Finalizado")
                                        mensaje = 'Finalizado'
                                        clase = 'btn btn-sm btn-outline-success';
                                        boton = `<a class="${clase}" >${mensaje}</a>`;
                                        return `<div style="width: 100%; text-align: center!important;">${boton}<div>`;
                                    }
                                }
                            }
                        }
                    }
                },
            ]
        )
    })
});

ClassDataAccess.getAjax('/api/Trade/listEstadoNotas/', '', function (datos) {
    ClassDataAccess.Grilla("#div-grid-detalle", datos,
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
                width: 30,
                title: "Concepto"
            },
            {
                field: "cliente",
                width: 50,
                title: "Cliente"
            },
            {
                field: "VALOR",
                width: 15,
                title: "Valor Nota",
                template: function (d) {
                    return '<div><strong> ' + kendo.toString(d.VALOR, "c0") + '</strong></div>';
                }
            },
            {
                field: "DOCSAP",
                width: 15,
                title: "Núm Nota"
            },
            {
                field: "APROBCOORTD",
                width: 30,
                title: "Estado",
                template: function (d) {
                    mensaje = '';
                    if (d.ESTADO == 1) {
                        mensaje = 'Pendiente Desbloqueo'
                    } else if (d.ESTADO == 2) {
                        mensaje = 'Finalizado'
                    } else if (d.APROBGERREG == 2 && d.NOTI == true) {
                        mensaje = 'Pendiente Admin Ventas'
                    } else if (d.APROBGERREG == 2 && d.NOTI == false) {
                        mensaje = 'Pendiente x Carga SAP'
                    } else if (d.APROBGERREG == 1 && d.APROBSOL == 2) {
                        mensaje = 'Rechazado x Gerencia Area'
                    } else if (d.APROBREV == 0) {
                        mensaje = 'Pendiente x ReveNew'
                    } else if (d.APROBSOL == 0) {
                        mensaje = 'Pendiente x Modificación'
                    } else if (d.APROBSOL == 1) {
                        mensaje = 'Anulado'
                    } else if (d.APROBGERREG == 0) {
                        mensaje = 'Pend x Gerencia Regional'
                    }
                    return `<div style="width: 100%; text-align: center!important;"><button class="btn btn-sm btn-outline-info"  >${mensaje}</button><div>`;
                }
            },
        ]
    )
})
