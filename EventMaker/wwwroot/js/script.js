$(document).ready(function () {
    $('#sortTable').DataTable({
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
});