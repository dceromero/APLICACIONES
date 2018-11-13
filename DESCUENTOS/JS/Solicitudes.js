ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Productos/ListadoProductos",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtproduct", js, "CODPRODUCTO", "DESCRIPCION", "#lblcodprod")
    }
)

ClassDataAccess.Ajax(
    "/api/Solicitudes/ListarTiposSolicitudes",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbtpsol", js, "ID_SOLICITD", "DESCRIPCION");;
    }
)

ClassDataAccess.Ajax(
    "/api/Clientes/ListarClientexVendedor",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtcliente", js, "CODCLIENTE", "RAZSOCCLIENTE", "#lblcliente")
    }
)

ClassDataAccess.Events.Blur("#txtproduct", "#lblcodprod");

ClassDataAccess.Events.Blur("#txtcliente", "#lblcliente");

ClassDataAccess.Events.BlurSoloNumeros('[type="number"]');

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
})

var myarray = new Array;
var ultimo = 0
ClassDataAccess.Events("#btnadd", "click", function () {
    validar = ClassDataAccess.ValidarCampos("#div-detalle [required]");
    if (validar) {
        var desc = { prod: $("#lblcodprod").val(), porc: $("#txtporc").val(), quitar: ultimo }
        myarray.push(desc);
        ultimo++
        ClassDataAccess.Grilla("#grid-add-descuento", myarray,
            [
                {
                    field: "prod",
                    width: 90,
                    title: "Producto"
                },
                {
                    field: "porc",
                    width: 90,
                    title: "Porcentaje"
                },
                {
                    field: "quitar",
                    width: 90,
                    title: "Quitar",
                    template: function (d) {
                        return '<img alt="Estado" del="true" id="' + d.quitar + '" style="max-width=2em; max-height: 2em;" src="../Image/cancel.ico" />';
                    }
                }
            ]
        )
        ClassDataAccess.LimpiarCampos("#div-detalle [required]");
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})

ClassDataAccess.Events("[del]", "click", function () {
    $("#lblid").val($(this).attr("id"));
    ClassDataAccess.OpenWindows("#div-confirmacion-del-item", "Remover Item", 100, 300);
})

ClassDataAccess.Events("#btnremove", "click", function () {
    for (x in myarray) {
        if (myarray[x].quitar == $("#lblid").val()) {
            myarray.splice(x, 1)
        }
    }
    ClassDataAccess.refreshGrilla("#grid-add-descuento")
    ClassDataAccess.CloseWindows("#div-confirmacion-del-item");
})

ClassDataAccess.Events("#btncancel-item", "click", function () {
    $("#lblid").val("");
    ClassDataAccess.CloseWindows("#div-confirmacion-del-item");
})

