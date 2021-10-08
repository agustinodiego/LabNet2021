function insertUpdateCategory() {

    var model = {
        CategoryId: $('#CategoryId').val(),
        CategoryName: $('#CategoryName').val(),
        Description: $('#Description').val()
    }

    $.ajax({
        type: 'POST',
        url: '/Categories/InsertUpdate',
        data: model,
        success: function (result) {
            $("body").html(result);
        }
    });
}

function openModalDelete(model) {

    $.ajax({
        type: 'GET',
        url: '/Categories/ModalDelete',
        data: model,
        success: function (result) {
            $("#Modal").html(result);
            $("#ModalDelete").modal();
        }
    });
}
