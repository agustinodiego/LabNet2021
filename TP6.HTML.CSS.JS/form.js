"use strict";

function validateForm() {
    if (!$('#fname').val() || !$('#lname').val()) {
        alert('Los campos Nombre y Apellido son obligatorios.');
        return false;
    } else {
        alert('Solicitud Completa. Datos almacenados con exito!');
    }
    return true;
};

function clearData() {
    $('#fname').val('');
    $('#lname').val('');
    $('#age').val('');
    $('#enterprise').val('');
}

