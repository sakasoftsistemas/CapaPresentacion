$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "_tipoProducto.aspx/obtenerTipoProductos",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (resultado) {
            var longitud = resultado.d.length;
            for (var i = 0; i < longitud; i++) {
                $("#itemCatalogo").append("<a class='enlace' id='" + resultado.d[i].idTipoProducto + "'  href='FormPresentacion.aspx?idTipoProducto=" + resultado.d[i].idTipoProducto +"'>" + resultado.d[i].descripcion + "</a>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            aler(error.Message);
        }
    });
});