ClassDataAccess = new AccesosDatos();


ClassDataAccess.Events.Blur("#txtproduct", "#lblcodprod");

ClassDataAccess.Ajax(
    "/api/Motivos/MotivosDesc",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbtpmot", js, "idmotivos", "descMotivo");
    }
);


ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
});

ClassDataAccess.Events.BlurSoloNumeros('[type="number"]');

ClassDataAccess.Events("#cmbtpmot", "change", function () {
    if ($(this).val() != -1) {
        $("#div-justi").fadeIn("slow");
        $("#lblmot ").text($("#cmbtpmot :selected").text());
    } else {
        $("#div-justi").fadeOut("slow");
        $("#lblmot ").text("");
    }

});

ClassDataAccess.Events("[del]", "click", function () {
    $("#lblid").val($(this).attr("id"));
    ClassDataAccess.OpenWindows("#div-confirmacion-del-item", "Remover Item", 100, 300);
});

ClassDataAccess.Events("#btnremove", "click", function () {
    for (x in myarray) {
        if (myarray[x].quitar == $("#lblid").val()) {
            myarray.splice(x, 1);
        }
    }
    ClassDataAccess.refreshGrilla("#grid-add-descuento")
    ClassDataAccess.CloseWindows("#div-confirmacion-del-item");
});

ClassDataAccess.Events("#btncancel-item", "click", function () {
    $("#lblid").val("");
    ClassDataAccess.CloseWindows("#div-confirmacion-del-item");
});

ClassDataAccess.Events("#txtcant", "blur", function () {
    valorprod = $(this).val() * $("#lblVALOR").val();
    descuento = valorprod * ($("#txtporc").val() / 100);
    valortotal = valorprod - descuento;
    textformarval = kendo.toString(descuento, "c0");
    textformarvalprod = kendo.toString(valorprod, "c0");
    textformarvaltotal = kendo.toString(valortotal, "c0");
    $("#txtvalprod").val(textformarvalprod);
    $("#txtvaltotal").val(textformarvaltotal);
    $("#txtval").val(textformarval);
});

ClassDataAccess.Events("#txtporc", "blur", function () {
    if ($("#txtporc").val() > 99) {
        $("#txtporc").val("");
    }
    if ($("#txtcant").val() != "") {
        valorprod = $("#txtcant").val() * $("#lblVALOR").val();
        descuento = valorprod * ($(this).val() / 100);
        valortotal = valorprod - descuento;
        textformarval = kendo.toString(descuento, "c0");
        textformarvalprod = kendo.toString(valorprod, "c0");
        textformarvaltotal = kendo.toString(valortotal, "c0");
        $("#txtvalprod").val(textformarvalprod);
        $("#txtvaltotal").val(textformarvaltotal);
        $("#txtval").val(textformarval);
    }
});