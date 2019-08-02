/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery.messager.js" />

$(function () {
    $("textarea.tbox").each(function () {
        var _area_id = $(this).attr("id");
        try {
            $("#" + _area_id).textareafullscreen();
        } catch (e) {
            console.log(e);
        }
        
    })
    ///
    /// 提示
    ///
    var isTips = true;
    var index;
    $("._tips").on("focus", function () {
        if (isTips) {
            if ($(this).val().length <= 0) {
                // 获取提示内容
                var text = $(this).parent().find("i:eq(0)").text();
                //小tips
                index = layer.tips(text, $(this), {
                    tips: [1, '#3595CC'],
                    time: 5000
                });
                isTips = false;

            }

        }
    }).on("blur", function () {
        isTips = true;
        layer.close(index);
    });

    // 将内容放在标签样式为item_ctn下，自动生成选项卡，多个item_ctn就有多个选项卡，一一对应
    //             <div class='item_ctn' item_name='选项卡1'>内容内容</div>
    // 页面需要以下样式
    /*
    <style type="text/css">
    .p_item {
    float: left;
    width: 100%;
    }
    .p_item span {
    border: 1px solid gray;
    border-radius: 3px;
    cursor: pointer;
    float: left;
    margin: 5px;
    padding: 5px;
    }
    .p_item span.item_cur{
    border-color:#1e93d8;   
    }
    </style>
    */


    // <p class="p_item"><span></span><span></span></p>
    // 1.获取item_ctn判断需要几个选项卡
        if ($(".item_ctn").length > 0) {
        var html = '';
        var arr_item = new Array();

        $(".item_ctn").each(function (index) {
            var item_name = $(this).attr("item_name");
            arr_item[index] = item_name;
        });
        $.unique(arr_item);
        for (var i = 0; i < arr_item.length; i++) {
            html += "<li class='state-selector-item ng-scope'><a href='javascript:;' class='ng-binding'>{0}</a></li>".format([arr_item[i]]);
        }

        // 2.创建选项卡
        if (html.length > 0) {
            $(".nav").append(html).addClass("nav-tabs");
            // 2.1 绑定事件
            $(".nav li").on("click", function () {
                $(this).siblings().removeClass("active");
                $(this).addClass("active");
                $("table tr").hide();
                var _item_name = $(this).children("a").text();
                $("table tr[item_name='" + _item_name + "']").show();
            });
            // 2.2 默认只显示第一个选项卡对应的内容
            $(".nav li:eq(0)").addClass("active");
            var _first_item_name = $("table tr:eq(0)").attr("item_name");
            $("table tr[item_name!='"+_first_item_name+"']").hide();
        }
    }

    // 需要转变为tab标签类型的下拉框加上select_tab样式,并且需要显示条数的话，在该option加上_count属性
    // <select class='select_tab'><option _count='99'>全部</option><option _count='30'>条件1</option></select>

    if ($(".select_tab").length > 0) {
        // 1. 获取判断有几项
        $(".select_tab").each(function () {
            $(this).css("display", "none")
            var selectedText = $(this).find(":selected").text();
            var html = '';
            var id = $(this).attr("id");
            $(this).find("option").each(function () {
                // 2. 创建html标签
                var cls = $(this).text().trim() == selectedText.trim() ? "tab_selected" : "";
                var _count = $(this).attr("_count");
                _count = _count ? _count : "0";
                _count = "";
                //            _count = "（<b>{0}</b>条）".format([_count]);
                html += "<li><a href='javascript:void(0)' class='{0}'>{1}{2}</a></li>".format([cls, $(this).text(), _count]);
            });
            if (html.length > 0) {
                // 附加到页面
                html = "<ul class='list_tab {0}' style='float:left;'>{1}</ul>".format([id, html]);
                $(".toolbg:eq(0) small").append(html);
                // 3. 绑定标签事件
                $("small .{0} li".format([id])).on("click", function () {
                    var i = $(this).index();
                    $("#{0} option:eq({1})".format([id, i])).attr("selected", "selected");
                    $("#" + id).change();
                });
            }
        });
    }

    // 对颜色显示进行处理,c_color(cell_color)、c_key(cell_key)
    // 前置条件：本身拥有c_color与c_key属性，
    // 条件：该标签显示的某个文本值(因为文本值可能由多个值组成的，用逗号隔开的形式)被包含于属性c_key的值
    // 结论：满足条件的将该格颜色置c_color

    // 1.获取所有拥有c_color属性的项
    if ($("[_Color]").length > 0) {
        $("[_Color]").each(function () {
            // 2.满足条件的置于颜色
            var color = $(this).attr("_Color");
            var key = $(this).attr("_Key");
            if (!color || !key) {
                return;
            }
            color = "," + color.trim(',') + ",";
            key = ',' + key.trim(',') + ',';            
            var txtArr = $(this).children("span").text().trim();
            var keys = key.split(",");
            for (var i = 0; i < keys.length; i++) {
                if (keys[i] == txtArr) {
                    $(this).css("background-color", color.split(',')[i]);
                    break;
                }               
            }

        });
    }
});
// 
// 添加小提示
//
function add_tips(obj, msg) {
    obj.attr("class", "").addClass("i_f");
    var _index;
    obj.on("mouseover", function () {
        // 小tips
        _index = layer.open({ type: 4,
            content: [msg, obj[0]],
            closeBtn: false
        });
        var _top = $("#layui-layer" + _index).css("top");
        $("#layui-layer" + _index).css("top", (parseInt(_top) - 16) + "px")
    }).on("mouseout", function () {
        layer.close(_index);
    });
}

function checkdata() {
    var validate = $("#form1").validate({
        onfocusout: false,
        onkeyup: false,
        ignore: "",
        //debug:true,
        onclick:false,
        errorPlacement: function (error, element) {
            add_tips(element.parent().find("b"), error.text());
        },
        success: function (label, elemet) {
            $(elemet).parent().find("b").off("mouseover");
            $(elemet).parent().find("b").removeClass("i_f").addClass("i_t");
        }
    });
    // 邮政编码验证   
    jQuery.validator.addMethod("isZip", function (value, element) {
        return this.optional(element) || (value.isZip());
    }, "请正确填写您的邮政编码");
    // 手机号码验证   
    jQuery.validator.addMethod("isMobile", function (value, element) {
        return this.optional(element) || (value.isMobile());
    }, "请正确填写您的手机号码");
    // 电话号码验证   
    jQuery.validator.addMethod("isPhone", function (value, element) {
        return this.optional(element) || (value.isPhone());
    }, "请正确填写您的电话号码");
    // 手机或电话号码验证   
    jQuery.validator.addMethod("isPhoneOrMobile", function (value, element) {
        return this.optional(element) || (value.isPhoneOrMobile());
    }, "请正确填写您的手机或电话号码");
    // 校验金额
    jQuery.validator.addMethod("isMoney", function (value, element) {
        return this.optional(element) || (value.isMoney());
    }, "请正确填写符合金额格式(格式定义为带小数的正数，小数点后最多2位 )");
    // 传真
    jQuery.validator.addMethod("isFax", function (value, element) {
        return this.optional(element) || (value.isFax());
    }, "请正确填写传真");
    // 由英文字母和数字和下划线组成
    jQuery.validator.addMethod("isNumberOr_Letter", function (value, element) {
        return this.optional(element) || (value.isNumberOr_Letter());
    }, "由英文字母和数字和下划线组成");
    // 由英文字母和数字组成
    jQuery.validator.addMethod("isNumberOrLetter", function (value, element) {
        return this.optional(element) || (value.isNumberOrLetter());
    }, "由英文字母和数字组成");
    // 由汉字、字母、数字组成下划线
    jQuery.validator.addMethod("isChinaOrNumbOrLett", function (value, element) {
        return this.optional(element) || (value.isChinaOrNumbOrLett());
    }, "由汉字、字母、数字组成下划线");
    // 由汉字、字母组成
    jQuery.validator.addMethod("isChinaOrLett", function (value, element) {
        return this.optional(element) || (value.isChinaOrNumbOrLett());
    }, "由汉字、字母组成");
    //当适用于多图片,多文件
    jQuery.validator.addMethod("requiredUploadFiles", function (value, element, param) {
        return jQuery(element).parent().find(":hidden#files" + param + "_UploaderFileUrl").val().length > 0;
    }, "上传文件或者图片不能为空");
    //适用于单图片
    jQuery.validator.addMethod("requiredUploadImg", function (value, element, param) {        
        return jQuery(element).parent().find(":hidden#file" + param + "_UploaderFileUrl").val().length > 0;
    }, "上传文件或者图片不能为空");
    // 身份证号码
    jQuery.validator.addMethod("isPID", function (value, element) {
        return this.optional(element) || (value.isPID());
    }, "请正确填写您的身份证号码");
	//适用于三级地区输入框
    jQuery.validator.addMethod("requiredThreeLevel", function (value, element, param) {
        return jQuery(element).parent().find(":text#input" + param + "_Autocomplete").val().length > 0;
    }, "地区不能为空");    return validate.form();
}
//动画效果
function MoveBox(obj, obj2, btn_obj) {
    var obj_clone = $(obj).clone();
    $(obj).parent().append(obj_clone);
    //隐藏原来的
    $(obj).hide();
    $("" + obj2 + "").animate({ "left": ($(btn_obj).offset().left) + "px", "top": $(btn_obj).offset().top + "px", "width": "20px", "height": "20px", "opacity": "0.5" }, 1000, function () {
        //setTimeout(function () { $("" + obj2 + ":visible").remove() }, 50);
        $("" + obj2 + ":visible").remove();
    });
}

//确认框
function layer_confirm(opt) {
    layer.confirm(opt.msg, { icon: 3, title: '提示', btn: ['确定', '取消'], shade: [0.5, '#000'] }, function (index) {
        if (opt.yesfun) {
            opt.yesfun();
        }
        layer.close(index);
    }, function (index) {
        if (opt.nofun) {
            opt.nofun();
        }
    });
}
//消息框
function layer_msg(msg, type, title, end) {
    var layer_ico = 3;
    type = type ? type : "";
    switch (type) {
        case "警告":
            layer_ico = 0;
            break;
        case "正确":
            layer_ico = 1;
            break;
        case "错误":
            layer_ico = 2;
            break;
        default:
            layer_ico = 3;
            break;
    }
    //layer.alert(msg, { icon: layer_ico, closeBtn: false, title: title ? title : "信息" });
    layer.msg(msg, { icon: layer_ico, closeBtn: false, title: title ? title : "信息", end: end });
}
//弹出框
function layer_alert(msg, type, title, end) {
    var layer_ico = 3;
    type = type ? type : "";
    switch (type) {
        case "警告":
            layer_ico = 0;
            break;
        case "正确":
            layer_ico = 1;
            break;
        case "错误":
            layer_ico = 2;
            break;
        default:
            layer_ico = 3;
            break;
    }
    layer.alert(msg, { shade: [0.6, '#000'], icon: layer_ico, title: title ? title : "信息", end: end });
}
//加载中
function layer_loading() {
    layer.load(1, {
        shade: [0.1, '#fff'], //0.1透明度的白色背景
        time: 10*1000
    });
}
function layer_close() {
    layer.closeAll('loading');
}