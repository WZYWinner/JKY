/*返回数字*/
String.prototype.toInt = function () {
    var number = this.replace(RegExp("[^0-9]", "g"), "");
    return isNaN(parseInt(parseFloat(number))) ? 0 : parseInt(parseFloat(number));
}
function BaseWindow() {
    this.myTag;             //窗口对象
    this.myHtml;            //窗口Html
    this.myStyle;           //窗口样式
    this.myIsDisplayScroll  //禁止滚动
    this.myCloseCallback;   //窗口关闭执行方法
    this.myWindow;          //当前窗口对象

    var _this = this;

    var myImportTag;
    var myImportHtml;
    var myImportTagOriginalHtml;

    var myBaseWindowStyle;
    var myBaseWindowCloseCallback;

    var myBaseWindowParentBackground;
    var myBaseWindowParentIframe;

    var myBaseWindowBackground;
    var myBaseWindowIframe;
    var myBaseWindow;

    var windowTopDomain = (window.top.location.host + window.top.location.pathname).toLocaleLowerCase();
    var windowDomain = (window.location.host + window.location.pathname).toLocaleLowerCase();

    var myBaseWindowCount = $(".base_window_background").length++;

    //初始化
    function initialize() {
        myImportTag = _this.myTag;
        myImportHtml = _this.myHtml;
        myBaseWindowStyle = _this.myStyle;
        myBaseWindowCloseCallback = _this.myCloseCallback;

        if (myImportTag == undefined || myImportTag.html() == null) {
            myImportTag = undefined;
        }

        if (myImportHtml == undefined) {
            myImportHtml = undefined;
        }

        if (myBaseWindowCloseCallback == undefined) {
            myBaseWindowCloseCallback = undefined;
        }

        if (myBaseWindowStyle == undefined) {
            myBaseWindowStyle = {};
        }

        if (!_this.verifyElementEvent()) {
            var tips = new Tips();
            tips.myHtml = "弹窗未接收到任何元素";
            tips.show();
            return false;
        }

        if (myImportTag != undefined) {
            myImportTagOriginalHtml = myImportTag[0].outerHTML;
        }
        return _this.initializeEvent();
    }

    this.verifyElementEvent = function () {
        return myImportTag != undefined || myImportHtml != undefined;
    }

    //初始化事件
    this.initializeEvent = function () { return true; }

    //显示
    this.show = function (callback) {
        if (!initialize()) {
            return false;
        }

        var baseWindowBackgroundClassName = "base_window_background_" + myBaseWindowCount;
        var baseWindowIframeClassName = "base_window_iframe_" + myBaseWindowCount;
        var baseWindowClassName = "base_window_" + myBaseWindowCount;

        var beforeTemplateHtml = "";
        beforeTemplateHtml += "<div class=\"base_window_background " + baseWindowBackgroundClassName + "\"></div>";
        beforeTemplateHtml += "<iframe class=\"base_window_iframe " + baseWindowIframeClassName + "\"></iframe>";
        beforeTemplateHtml += "<div class=\"base_window " + baseWindowClassName + "\">";

        var afterTemplateHtml = "";
        afterTemplateHtml += "<div class=\"clear\"></div>";
        afterTemplateHtml += "</div>";

        if (myImportTag != undefined) {
            myImportTag.before(beforeTemplateHtml + myImportTagOriginalHtml + afterTemplateHtml);
            myImportTag.remove();
        }
        else {
            $(document.body).append(beforeTemplateHtml + myImportHtml + afterTemplateHtml);
        }

        if (windowTopDomain != windowDomain) {
            $("." + baseWindowBackgroundClassName, parent.document).remove();
            $("." + baseWindowIframeClassName, parent.document).remove();

            $(parent.document.body).append("<div class=\"base_window_background " + baseWindowBackgroundClassName + "\"></div>");
            $(parent.document.body).append("<iframe class=\"base_window_iframe " + baseWindowIframeClassName + "\"></iframe>");
        }
        myBaseWindowBackground = $("." + baseWindowBackgroundClassName);
        myBaseWindowIframe = $("." + baseWindowIframeClassName);
        myBaseWindow = $("." + baseWindowClassName);

        myBaseWindowParentBackground = $("." + baseWindowBackgroundClassName, parent.document);
        myBaseWindowParentIframe = $("." + baseWindowIframeClassName, parent.document);

        _this.myWindow = myBaseWindow;

        _this.windowStyle();
        $(window).resize(function () {
            _this.windowStyle();
        });

        if (_this.myIsDisplayScroll == false) {
            if ($.browser.msie && ($.browser.version == "6.0" || $.browser.version == "7.0")) {
                $("html").css({ "overflow": "hidden", "overflow-x": "hidden", "overflow-y": "hidden" });
            }
            else {
                $("body").css({ "overflow": "hidden" });
            }
        }

        if (callback != undefined) {
            callback();
        }
    }

    //样式
    this.windowStyle = function () {
        if (!initialize()) {
            return;
        }

        myBaseWindowParentBackground.hide();
        myBaseWindowParentIframe.hide();
        myBaseWindowBackground.hide();
        myBaseWindowIframe.hide();

        if (myImportTag != undefined) {
            _this.myWindow.find("[class=\"" + myImportTag.attr("class") + "\"]").show();
        }

        var bodyScrollTop = document.documentElement.scrollTop == 0 ? document.body.scrollTop : document.documentElement.scrollTop;

        var bodyParentScrollWidth = parent.document.documentElement.scrollWidth == 0 ? parent.document.body.scrollWidth : parent.document.documentElement.scrollWidth;

        var windowsHeight = window.innerHeight != undefined ? window.innerHeight : document.documentElement.clientHeight;
        var windowsParentHeight = window.parent.innerHeight != undefined ? window.parent.innerHeight : parent.document.documentElement.clientHeight;
        var parentBackgroundHeight = windowsParentHeight - windowsHeight;

        if (windowTopDomain != windowDomain) {
            windowsHeight -= parentBackgroundHeight;

            myBaseWindowParentBackground.show();
            myBaseWindowParentIframe.show();

            myBaseWindowParentBackground.css({ width: bodyParentScrollWidth, height: parentBackgroundHeight, top: 0, left: 0 });
            myBaseWindowParentIframe.css({ width: bodyParentScrollWidth, height: parentBackgroundHeight, top: 0, left: 0 });
        }

        var bodyScrollWidth = document.documentElement.scrollWidth == 0 ? document.body.scrollWidth : document.documentElement.scrollWidth;
        var bodyHeight = document.documentElement.scrollHeight > windowsHeight ? document.documentElement.scrollHeight : windowsHeight;

        var baseWindowBackgroundOffset = myBaseWindowBackground.offset();
        var baseWindowIframeOffset = myBaseWindowIframe.offset();
        var baseWindowOffset = myBaseWindow.offset();

        myBaseWindowBackground.show();
        myBaseWindowIframe.show();
        myBaseWindowBackground.css({ "z-index": myBaseWindowBackground.css("z-index").toString().toInt() + myBaseWindowCount, width: bodyScrollWidth, height: bodyHeight, top: 0, left: 0 });
        myBaseWindowIframe.css({ "z-index": myBaseWindowBackground.css("z-index").toString().toInt() + myBaseWindowCount, width: bodyScrollWidth, height: bodyHeight, top: 0, left: 0 });
        myBaseWindow.css({ "z-index": myBaseWindow.css("z-index").toString().toInt() + myBaseWindowCount });

        if (myBaseWindowStyle["vertical-align"] == "middle") {
            myBaseWindowStyle.top = bodyScrollTop;
            myBaseWindowStyle.top += (windowsHeight >= myBaseWindow.height() ? windowsHeight - parentBackgroundHeight - myBaseWindow.height() : (windowsHeight - parentBackgroundHeight) / 4) / 2;
        }

        if (myBaseWindowStyle["text-align"] == "center") {
            myBaseWindow.css({ float: "left", width: "auto" });
            myBaseWindowStyle.left = (bodyScrollWidth >= myBaseWindow.width() ? bodyScrollWidth - myBaseWindow.width() : bodyScrollWidth / 4) / 2;
        }

        if (myBaseWindowStyle.top == undefined) {
            myBaseWindowStyle.top = bodyScrollTop + 100;
        }

        if (myBaseWindowStyle.left != undefined) {
            myBaseWindow.css({ left: myBaseWindowStyle.left });
        }
        myBaseWindow.css({ top: myBaseWindowStyle.top });
    }

    //关闭主背景
    this.clsoeParentBackground = function (callback) {
        if (!initialize()) {
            return;
        }

        if (myBaseWindowParentBackground != undefined) {
            myBaseWindowParentBackground.remove();
        }

        if (myBaseWindowParentIframe != undefined) {
            myBaseWindowParentIframe.remove();
        }

        if (callback != undefined) {
            callback();
        }
    }

    //关闭背景
    this.clsoeBackground = function (callback) {
        if (!initialize()) {
            return;
        }

        _this.clsoeParentBackground();

        myBaseWindowBackground.remove();
        myBaseWindowIframe.remove();

        if (callback != undefined) {
            callback();
        }
    }

    //清除所有背景
    this.clearBackground = function (callback) {
        $(".base_window_background").remove();
        $(".base_window_iframe").remove();

        $(".base_window_background", parent.document).remove();
        $(".base_window_iframe", parent.document).remove();

        if (callback != undefined) {
            callback();
        }
    }

    //关闭
    this.close = function (callback) {
        if (!initialize()) {
            return;
        }

        _this.clsoeBackground();

        if (myImportTag != undefined) {
            myBaseWindow.before(myImportTagOriginalHtml);
        }
        myBaseWindow.remove();

        if (callback != undefined) {
            callback();
        }

        if (_this.myIsDisplayScroll == false) {
            if ($.browser.msie && ($.browser.version == "6.0" || $.browser.version == "7.0")) {
                $("html").css({ "overflow": "auto", "overflow-x": "hidden", "overflow-y": "auto" });
            }
            else {
                $("body").css({ "overflow": "auto" });
            }
        }

        if (myBaseWindowCloseCallback != undefined) {
            myBaseWindowCloseCallback();
        }
    }
}
var setInval;
//图片预览
function PreviewImageBase() {
    this.image_src;
    var _This = this;
    function bindHtml() {
        var html = "";
        html += "<div class=\"preview_img_content\">";

        html += "</div>";
        return html;
    }

    this.show = function () {
        var windowsWidth = window.innerWidth != undefined ? window.innerWidth : document.documentElement.clientWidth;
        var windowsHeight = window.innerHeight != undefined ? window.innerHeight : document.documentElement.clientHeight;

        var bw = new BaseWindow();
        bw.myHtml = bindHtml();
        bw.myIsDisplayScroll = false;
        bw.myStyle = { top: document.documentElement.scrollTop == 0 ? document.body.scrollTop : document.documentElement.scrollTop };
        bw.show();

        $(".base_window_background").stop().animate({ "opacity": "0.8" }, 500);
        $(".base_window").height("100%");
        $(".preview_img_content").css({ "text-align": "center" });
        if (setInval != undefined)
            clearInterval(setInval);
        setInval = setInterval(function () {
            var obj = $(".preview_img_content");
            if (obj.find("img").length <= 0) {
                obj.append('<div><img src="' + _This.image_src + '" /></div><b></b>');
                var preview_obj_width = obj.find('div:eq(0)').width(), preview_img_width = obj.find('img:eq(0)').width();
                if (preview_img_width > preview_obj_width) {
                    var width_img_temp = preview_obj_width - 20;
                    obj.find('img').width(width_img_temp);
                    //obj.find('img').height(obj.find('img').outerHeight() * width_img_temp / width_img);
                    preview_img_width = width_img_temp;
                }
                obj.find('b').css('right', preview_obj_width > preview_img_width ? (preview_obj_width - preview_img_width) / 2 - 10 : 0);
            }
            if (obj.height() > 0) {
                clearInterval(setInval);
                //关闭
                $(".base_window").unbind("click");
                $(".base_window").click(function (e) {
                    e = e || window.event;
                    var target = e.target || e.srcElement;
                    if (target.tagName == "IMG") {
                        return;
                    }
                    bw.close();
                    $(".base_window").css("overflow-y", "hidden");
                    $(".base_window_background").css("opacity", "0.2");
                });
                //关闭按钮事件
                obj.find('b').unbind('click').click(function () { $(".base_window").click(); });
                var previewHeight = $(".preview_img_content").height();
                if (previewHeight > windowsHeight) {
                    $(".base_window").css("overflow-y", "scroll");
                } else {
                    var scrollHeight = document.documentElement.scrollTop == 0 ? document.body.scrollTop : document.documentElement.scrollTop;
                    bw.myStyle = { top: (scrollHeight + ((windowsHeight - previewHeight) / 2)) };
                    bw.windowStyle();
                }
            }
        }, 200);

    }
}
//调用图片
function imageShow(obj) {
    $(obj).click(function () {
        var pib = new PreviewImageBase();
        pib.image_src = $(this).attr("src");
        pib.show();
    });
}