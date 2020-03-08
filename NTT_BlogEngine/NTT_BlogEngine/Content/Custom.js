$(function () {

    var getPostList = function (event) {
        event.preventDefault()

        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-lvd-target");
            $(target).replaceWith(data);

            $('html, body').animate({
                scrollTop: $(target).offset().top - 150
            });
            window.history.pushState(null, null, options.url);
        });
    }

    var getCommentList = function (event) {
        event.preventDefault();
        var $form = $(this)

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $form.attr("data-lvd-target");
            $(target).replaceWith(data);

            $form[0].reset();
            $('html, body').animate({
                scrollTop: $(target).offset().top - 40
            }, 500);

        }).fail(function (jqXHR, textStatus, errorThrown) { // TODO: Refactor this fail case code

            console.log(jqXHR)
            alert(jqXHR + "    " + textStatus + "    " + errorThrown);
        });
    } 

    $(".main-content").on("click", ".pagedList a", getPostList);    // Hook Paging event

    $("form[data-lvd-ajax='true']").submit(getCommentList);         // Hook Comment Post event
})