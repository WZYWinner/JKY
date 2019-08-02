function txt_preview(obj) {
    $(obj).css("cursor", "pointer").mouseover(function (event) {
        var obj = $(this);
        var txt = obj.text();
        var left = $(this).offset().left;
        var top = $(this).offset().top;
        var scrollLeft = document.documentElement.scrollLeft || document.body.scrollLeft;
        var scrollTop = document.documentElement.scrollTop || document.body.scrollTop;
        var x = event.clientX + scrollLeft - document.documentElement.clientLeft;
        var y = event.clientY + scrollTop - document.documentElement.clientTop;
        obj.parent().append("<div class='txt_content'>" + txt + "</div>");
        $(".txt_content").css({ "top": (y - top) + "px", "left": (x - left + 15) + "px" });
    }).mouseout(function () {
        $(this).parent().find(".txt_content").remove();
    });
}