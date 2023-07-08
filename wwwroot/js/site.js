$(document).ready(function () {
    getDataTable("#table-professores");
    getDataTable("#table-cursos");
    getDataTable("#table-disciplinas");



    $(".close-alert").click(function () {
        $(".alert").hide();
    });

    $('#Celular').mask('(00)00000-0000');
    $('#Telefone').mask('(00)0000-0000');

    $('.btn-availability').click(function () {
        event.preventDefault();
        if ($(this).hasClass('btn-success')) {
            $(this).removeClass('btn-success');
            $(this).addClass('btn-danger');
            $(this).text('Indisponível');
        } else {
            $(this).removeClass('btn-danger');
            $(this).addClass('btn-success');
            $(this).text('Disponível');
        }
    });
});


function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    }
    );
}