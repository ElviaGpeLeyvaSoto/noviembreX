function eliminar(id) {

    if (confirm("¿Esta seguro que desea eliminar el registro?")) {
        var url = "/Estado/Eliminar/" + id;
        window.location.href = url;
    }

}