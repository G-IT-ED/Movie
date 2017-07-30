(function () {
    // Функция вызывается при загрузке скрипта и делает асинхронный запрос на сервер
    $.ajax({

        url: "/",

        success: function (names) {

            var list = $("#names"); // находим элемент на странцие

            for (var i = 0; i < names.length; i++) { // names - JSON объект полученый со стороны сервера.
                var name = names[i];
                list.append("<li>" + name + "</li>");
            }
        }
    });

    // после загрузки документа, находим на страцние кнопку и добавляем метод getName как обработчик на событие click
    $(document).ready(function () {
        $("#button").on("click", getName);
    });

    function getName() {
        var movie = { name: $("#elementId").val(), timeBegin: $("#elementTime").val() };

        $.ajax({
            url: '/Registration/Create',
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            //data: JSON.stringify('test'),
            //data: JSON.stringify({ movie: { name: 'Rintu', timeBegin: '2015-06-28T13:51:13-07:00' } }),
            data: JSON.stringify(movie),
            async: true,
            processData: false,
            cache: false,
            success: function (data) {
                alert(data);
            },
            error: function (xhr) {
                alert('error');
            }
        });
    };
})();