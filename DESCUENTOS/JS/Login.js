var ClassDataAccess = new AccesosDatos();

ClassDataAccess.ViewMobile();

$("body").on("click", "#btningresar", function () {
    validar = ClassDataAccess.ValidarCampos('[required]');
    if (validar) {
        param = {
            CEDULA: $("#txtuser").val(),
            CLAVE: $("#txtpsw").val()
        }
        ClassDataAccess.Ajax(
            "/api/Usuarios/Validar",
            JSON.stringify(param),
            function (datos) {
                if (datos == 0) {
                    ClassDataAccess.OpenWindows("#div-alert-error", "Mensaje :", 120, 300);
                } else {
                    location.href = "/Home/Inicio"
                }
            }
        )
    } else {
        ClassDataAccess.OpenWindows("#div-advertencia", "Advertencia :", 100, 300);
    }

});

$("body").on("click", "#btn-close-advertencia", function () {
    ClassDataAccess.CloseWindows("#div-advertencia");
})
$("body").on("click", "#btn-close-alert-error", function () {
    ClassDataAccess.CloseWindows("#div-alert-error");
})

ClassDataAccess.Events("#ver-psw","click", function () {
    if ($("#txtpsw").attr("type") == "password") {
        $(this).removeClass("fa-eye-slash").addClass("fa-eye");
        $("#txtpsw").attr("type", "text");
    } else {
        $(this).removeClass("fa-eye").addClass("fa-eye-slash");
        $("#txtpsw").attr("type", "password");
    }
})

$("body").on("click", "#btnregister", function () {
    location.href = "/Home/Register";
    //ClassDataAccess.OpenWindows("#div-register", "Pre Registro", 420, 820);
})

$("body").on("click", "#a-psw", function () {
    $("#div-motrech").fadeIn()
    $("#lblmensajerech").text("Ingresa tu numero de cédula")
    ClassDataAccess.OpenWindows("#div-recuperar_psw", "Recuperar PSW :", 130, 200);
})

$("body").on("click", "#btnsave", function () {
    ClassDataAccess.CloseWindows("#div-recuperar_psw");
    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    ClassDataAccess.Ajax(
        `/api/Usuarios/Userconfig/${$(txtccrec).val()}`,
        '',
        function (datos) {
            $("#lblmessage").text(datos);
            ClassDataAccess.CloseWindows("#div-mensaje");
            ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje :", 140, 300);
        }
    )
})

$("body").on("click", "#btn-close-message", function () {
    ClassDataAccess.CloseWindows("#div-mensaje-respuesta");
})