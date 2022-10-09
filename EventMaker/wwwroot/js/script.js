$(document).ready(function () {
    $('#sortTable').DataTable({
        columnDefs: [
            { orderable: false, targets: 0 }
        ],
        "language": {
            "lengthMenu": 'Показывать <select>' +
                '<option value="5">5</option>' +
                '<option value="10">10</option>' +
                '<option value="15">15</option>' +
                '<option value="30">30</option>' +
                '<option value="-1">All</option>' +
                '</select> Мероприятий',
            "search": "Поиск мероприятий:",
            "paginate":
            {
                "next": "Следующая",
                "previous": "Предыдущая"
            },
            "info": "Показывать с _START_ по _END_ из _TOTAL_ мероприятий",
            "zeroRecords": "Не найдено совпадений",
            "infoEmpty": "",
            "infoFiltered": "",
           
        }
    });

    $('#ActivitiesTable').DataTable({
        "language": {
            "lengthMenu": 'Показывать <select>' +
                '<option value="5">5</option>' +
                '<option value="10">10</option>' +
                '<option value="-1">Все</option>' +
                '</select> Мероприятий',
            "paginate":
            {
                "next": "Следующая",
                "previous": "Предыдущая"
            },
            "info": "Показывать с _START_ по _END_ из _TOTAL_ мероприятий",
            
        },
        "ordering": false,
        "searching": false,

    });

    $('#MembersTable').DataTable({
        "language": {
            "lengthMenu": 'Показывать <select>' +
                '<option value="5">5</option>' +
                '<option value="10">10</option>' +
                '<option value="-1">Все</option>' +
                '</select> Участников',
            "paginate":
            {
                "next": "Следующая",
                "previous": "Предыдущая"
            },
            "info": "Показывать с _START_ по _END_ из _TOTAL_ Участников",
            "search": "Поиск Участников:",
            "info": "Показывать с _START_ по _END_ из _TOTAL_ Участников",
            "zeroRecords": "Не найдено совпадений",
            "infoEmpty": "",
            "infoFiltered": "",
        },
        

    });

    $('#JuryTable').DataTable({
        "language": {
            "lengthMenu": 'Показывать <select>' +
                '<option value="5">5</option>' +
                '<option value="10">10</option>' +
                '<option value="-1">Все</option>' +
                '</select> Жюри',
            "paginate":
            {
                "next": "Следующая",
                "previous": "Предыдущая"
            },
            "info": "Показывать с _START_ по _END_ из _TOTAL_ жюри",
            "search": "Поиск Участников:",
            "info": "Показывать с _START_ по _END_ из _TOTAL_ жюри",
            "zeroRecords": "Не найдено совпадений",
            "infoEmpty": "",
            "infoFiltered": "",
        },


    });


});