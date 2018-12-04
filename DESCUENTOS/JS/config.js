ClassDataAccess = new AccesosDatos();

ClassDataAccess.Ajax(
    '/api/Usuarios/ListaUsuarios',
    '',
    function (datos) {
        jsdatos = JSON.parse(datos);
        ClassDataAccess.Grilla("#div-grid-usuarios", jsdatos,
            [
                {
                    field: "CEDULA",
                    width: 60,
                    title: "Cedula"
                },
                {
                    field: "NAMECOMPLETO",
                    width: 60,
                    title: "Nombres"
                },
                {
                    field: "COD_VENDEDOR",
                    width: 60,
                    title: "Código Vendedor"
                },
                {
                    field: "ESTADO",
                    width: 60,
                    title: "Estado",
                    template: function (d) {
                        clase = d.ESTADO ? "fa fa-user-check" : "fa fa-user-times";
                        return '<strong><span class="' + clase + '"></span></strong>';
                    }
                },
                {
                    field: "CEDULA",
                    width: 60,
                    title: "Configuración",
                    template: function (d) {
                        return '<a href="/Config/Usuario/'+d.CEDULA+'" class="btn btn-outline-info"><strong><span class="fa fa-users-cog">&nbsp;&nbsp;Configuración</span></strong></a>';
                    }
                }
            ]
        )
    }
)