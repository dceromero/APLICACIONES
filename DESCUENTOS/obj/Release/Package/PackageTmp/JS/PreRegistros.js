
ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Empresas/ListadoEmpresas",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbemp", js, "NIT_EMPRESA", "NAMEEMPRESA");;
    }
)

ClassDataAccess.Ajax(
    "/api/Cencos/ListadoDeCentrosCostos",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtcencos", js, "ID_CENCOS", "NAMECENCOS", "#lblcencos")
    }
)


ClassDataAccess.Ajax(
    "/api/Cargos/ListaDeCargos",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtcargo", js, "ID_CARGO", "NAMECARGO", "#lblcargo")
    }
)

ClassDataAccess.Ajax(
    "/api/Usuarios/ListadoDeJefes",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtjf", js, "CEDULA", "NombreCompleto", "#lbljf")
    }
)

ClassDataAccess.Events.Blur("#txtcargo", "#lblcargo");

ClassDataAccess.Events.Blur("#txtcencos", "#lblcencos");

AccesosDatos.prototype.Events.BlurSoloNumeros('[type="number"]');

AccesosDatos.prototype.Events.BlurEmail();


ClassDataAccess.Events("#btnconfirm", "click", function () {
    validar = ClassDataAccess.ValidarCampos("[required]");
    if (validar) {
        ClassDataAccess.OpenWindows("#div-confirmacion", "Confirmación :", 100, 300);
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }
})

ClassDataAccess.Events("#btn-close-advertencia", "click", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
})

ClassDataAccess.Events("#btncancel", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion")
})

ClassDataAccess.Events("#btn-atras", "click", function () {
    location.href = "/Home/Index";
})

ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    usuario = {
        CEDULA: $("#txtcedula").val(),
        CODIGO: $("#txtcod").val(),
        NOMBRES: $("#txtnombres").val(),
        APELLIDOS: $("#txtapel").val(),
        CLAVE: $("#txtclave").val(),
        JEFEAREA: $("#lbljf").val(),
        MAIL: $("#txtmail").val(),
        TELEFONO: $("#txtmovil").val(),
        NIT_EMPRESA: $("#cmbemp").val(),
        ID_CENCOS: $("#lblcencos").val(),
        ID_CARGO: $("#lblcargo").val()
    };
    ClassDataAccess.Ajax(
        "/api/Usuarios/PreRegistro",
        JSON.stringify(usuario),
        function (datos) {
            js = JSON.parse(datos)
            ClassDataAccess.LimpiarCampos("[required]");
            ClassDataAccess.CloseWindows("#div-mensaje");
            $("#lblmessage").text(js.message);
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 120, 300);
        }
    );
})

ClassDataAccess.Events("#btn-close-message", "click", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
})
