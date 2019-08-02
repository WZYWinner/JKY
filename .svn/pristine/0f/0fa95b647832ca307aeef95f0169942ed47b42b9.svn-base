/// <reference path="jquery-1.8.2.js" />
$(function () {
    //页面初始化加载时，SEO开关为默认活为空的，则隐藏下面的SEO信息
    if ($("#tbIsSeo option:selected").attr("value") == "") {
        $("#tbIsSeo").parent("li").nextAll().slice(0, 3).hide();
    }
    $("#tbIsSeo").change(function () {
        if ($("#tbIsSeo option:selected").attr("value") == "默认" || $("#tbIsSeo option:selected").attr("value") == "") {
            $("#tbIsSeo").parent("li").nextAll().slice(0, 3).hide();
        } else {
            $("#tbIsSeo").parent("li").nextAll().slice(0, 3).show();
        }
    });
})