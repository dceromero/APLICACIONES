ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/Vendedores/CodigosVendedores",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbcodven", js, "COD_VENDEDOR", "NAMEVENDEDOR");
    }
)

ClassDataAccess.Ajax(
    "/api/Empresas/ListadoEmpresas",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.Combox("#cmbemp", js, "NIT_EMPRESA", "NAMEEMPRESA");
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
    "/api/Roles/ListadoDeRoles",
    '',
    function (datos) {
        js = JSON.parse(datos);
        ClassDataAccess.AutoComplete("#txtrol", js, "ID_ROL", "NAMEROL", "#lblrol")
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


ClassDataAccess.Ajax(
    "/api/Usuarios/Userconfig/" + $("#lblid").val(),
    '',
    function (data) {
        jsdatos = JSON.parse(data);
        $("#cmbemp").val(jsdatos.NIT_EMPRESA);
        $("#txtcedula").val(jsdatos.CEDULA);
        $("#txtcod").val(jsdatos.CODIGO);
        $("#txtnombres").val(jsdatos.NOMBRES);
        $("#txtapel").val(jsdatos.APELLIDOS);
        $("#txtmail").val(jsdatos.MAIL);
        $("#lbljf").val(jsdatos.JEFEAREA);
        $("#txtjf").val(jsdatos.JEFEAREA);
        $("#txtcencos").val(jsdatos.ID_CENCOS);
        $("#lblcencos").val(jsdatos.ID_CENCOS);
        $("#txtcargo").val(jsdatos.ID_CARGO);
        $("#lblcargo").val(jsdatos.ID_CARGO);
        $("#txtmovil").val(jsdatos.TELEFONO);
        $("#txtclave").val(jsdatos.CLAVE);
        $("#cmbnivel").val(jsdatos.NIVELUSUARIO);
        $("#txtrol").val(jsdatos.ID_ROL);
        $("#lblrol").val(jsdatos.ID_ROL);
        $("#cmbcodven").append("<option value='" + jsdatos.COD_VENDEDOR + "' selected>VENDEDOR " + jsdatos.COD_VENDEDOR+ "</option>");
    }
)