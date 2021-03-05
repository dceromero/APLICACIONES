ClassDataAccess = new AccesosDatos();

grillaMasiva();

ClassDataAccess.Events("#btn-aprob-max", "click", function () {
    var myarray = [];
    count = 0;
    $("[type='checkbox']").each(function (key, element) {
        aprob = $(element).is(':checked') ? '2' : '1';
        count++
        parametros = {
            ID_MOVCABAJ: $(element).val(),
            APROBGRFI: aprob,
        }
        if (count <= 20) {
            myarray.push(parametros);
            return;
        }
    });
    ClassDataAccess.Ajax('/api/LogInventario/AprobacionAIMax/', JSON.stringify(myarray),
        function (data) {
            $("#lblmessage").text("La Solicitud ha sido aprobada")
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 140, 300);
            grillaMasiva()
        }
    )
});

function grillaMasiva() {
    ClassDataAccess.Ajax(
        "/api/LogInventario/listAprobMasiva",
        '',
        function (datos) {
            ClassDataAccess.Grilla("#div-aprob-inventario", datos,
                [

                    {
                        field: "ID_MOVCABAJ",
                        width: 15,
                        title: "<label id='check-all' data-todos = '0'>Selecionar (*)</label>",
                        template: function (d) {
                            return '<input type="checkbox"  value="' + d.ID_MOVCABAJ + '">';
                        }
                    },
                    {
                        field: "FECINV",
                        width: 15,
                        title: "Fecha Inventario",
                        template: function (d) {
                            return '<strong> ' + d.FECINV.replace("T00:00:00", "") + '</strong>';
                        }
                    },
                    {
                        field: "CD",
                        width: 40,
                        title: "Centro Distribución"
                    },
                    {
                        field: "BODEGA",
                        width: 30,
                        title: "Almacen"
                    },
                    {
                        field: "RESPONSABLE",
                        width: 40,
                        title: "Jefe Almacen",
                        template: function (d) {
                            resp = d.RESPONSABLE.split("-")
                            return resp[1];
                        }
                    },
                    {
                        field: "VALORTOTAL",
                        width: 15,
                        title: "Valor Ajustar"
                    },
                ])

        }
    )
}
