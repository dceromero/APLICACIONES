ClassDataAccess = new AccesosDatos();

var myarray = $(".plupload_upload_status").text();

ClassDataAccess.FileUp("#div-upload-docsap", "/api/LogInventario/Archivos/", "xls,xlsx,pdf",
    function (data) {
        console.log(data);
        ClassDataAccess.CloseWindows("#div-mensaje");
        $("#lblmessage").text("Su solicitud ha sido Cargada")
        ClassDataAccess.OpenWindows("#div-mensaje-respuesta", "Mensaje", 140, 300);
        // 
    }
);

ClassDataAccess.Events("#btn-close-message", "click", function () {
    location.href = "/LogInventario/ListSupervisor";
})

$(".plupload_start ").remove();
$(".plupload_header_text").remove("");

ClassDataAccess.Events("#btnsave", "click", function () {
    ClassDataAccess.CloseWindows("#div-confirmacion");
    parametros = {
        docsap: $("#txtdocsap").val(),
        fecinv: $("#txtfeinv").val(),
        justifi: $("#txtjust").val(),
        codcentro: $("#cmbcentro").val(),
        cantsku: $("#txtcantsku").val(),
        valtotalinv: $("#txtvaltotalinv").val()
    }

    ClassDataAccess.OpenWindows("#div-mensaje", "Mensaje :", 100, 300);
    var uploader = $('#div-upload-docsap').pluploadQueue();
    uploader.setOption('multipart_params', parametros)
    uploader.start()
})


ClassDataAccess.getAjax('/api/LogInventario/listCentro/', '', function (datos) {
    ClassDataAccess.Combox("#cmbcentro", datos, "CODCENTRO", "NOMBRE");
});
