var ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    "/api/MenusSubMenus/Menus/",
    null,
    function (datos) {
        js = JSON.parse(datos);
        Controles(js);
    }
)

ClassDataAccess.Ajax(
    "/Api/Usuarios/Usuario",
    '',
    function (datos) {
        js = JSON.parse(datos);
        console.log(js);
        $("#lbluser").text(js.NombreCompleto)
    }
)


function Controles(datos) {
    var a = "";
    for (var i in datos) {
        for (var x in datos[i].SUBMENU) {
            a = a + '<a class="dropdown-item" href="' + datos[i].SUBMENU[x].URLSUBMENU + '"><strong>' + datos[i].SUBMENU[x].NAMESUBMENU + '</strong></a>'
        }
        $("#div-menu").append(
            '<li class="nav-item dropdown">' +
            '<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
            '<strong>' +
            datos[i].NAMEMENU +
            '</strong>' +
            ' </a>' +
            '<div class="dropdown-menu" aria-labelledby="navbarDropdown">' +
            a +
            '</div>' +
            '</li>'
        )
    }
}