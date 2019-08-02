/// <reference path="jquery-1.8.2.js" />
$(function () {
    //页面初始化加载时
    $(".update_head a").eq(0).addClass("head_over_0");
    $(".create_list").eq(1).css("display", "none");
    //激活选项卡
    $(".update_head a").click(function () {
        //选项卡切换样式
        $(this).addClass("head_over_" + $(this).index()).siblings("a").removeClass();
        //显示/隐藏相应的数据
        $(".create_list:eq(" + $(this).index() + ")").show().siblings(".create_list").hide();
        //审核信息一直都是显示在下面（对比审核时）
        $(".audit_info").show();
    });

    // 新增页面的匹配按钮
    $(".match_gx a").click(function () {
        //////////////////////////////////////////////////////////// 清除匹配的时候
        if ($(this).text() == "清除匹配") {

            // 药品标签列表
            $(".tag_list").val("");
            // 特殊人群
            $(".drug_special_crowd").val("");
            // 适用人群
            $(".drug_suit_crowd").val("");
            // 药品有效期(有效期不应该用日期格式的字段。)
            $(".valid_time").val("");
            // 功能主治
            $(".drug_function").val("");
            // 贮藏
            $(".drug_storage").val("");
            // 药理作用
            $(".drug_pharmacologic").val("");
            // 药物相互作用
            $(".drug_interations").val("");
            // 注意事项
            $(".drug_announcement").val("");
            // 禁忌
            $(".drug_taboo").val("");
            // 不良反应
            $(".adverse_effects").val("");
            // 适应症
            $(".drug_indication").val("");
            // 性状
            $(".drug_character").val("");
            // 成分
            $(".drug_material").val("");
            // 用法用量
            $(".drug_instruction").val("");
            // SEO开关
            $(".is_seo option[value='默认']").attr("selected", "selected"); ;
            // SEO标题
            $(".seo_title").val("");
            // SEO关键字
            $(".seo_keywords").val("");
            // SEO描述
            $(".seo_description").val("");

            $('.match_gx span').text('您可以按照通用名匹配我们功效库中已有的功效并在上面编辑修改相关信息！');
            $('.match_gx a').text('匹配功效');
            return;
        }

        /////////////////////////////////////////////////////////////// 匹配的时候

        // 为服务器控件药品通用名称添加上generic_name样式(服务端id到生成为html发送到客户端的时候id有可能会变动，所以不要直接去id)
        var generic_name = $(".generic_name").val();
        // 获取数据
        $.post("/WebHandler/DrugInfoCreate.ashx", { type: "match", generic_name: generic_name }, function (data, status) {
            // 失败
            if (status != "success") {
                alert('获取失败');
                ;
                return;
            }

            var entity = $.parseJSON(data);
            // 对数据进行回填页面
            if (!entity) {
                $(".match_gx span").html('对不起，功效库中无法寻找到您要匹配的药品功效，请手动输入！');
                return;
            }
            // 页面上的dom对象都为他们添加上样式名称
            // 药品标签列表
            $(".tag_list").val(entity.TagList);
            // 特殊人群
            $(".drug_special_crowd").val(entity.DrugSpecialCrowd);
            // 适用人群
            $(".drug_suit_crowd").val(entity.DrugSuitCrowd);
            // 药品有效期(有效期不应该用日期格式的字段。)
            $(".valid_time").val(entity.ValidTime);
            // 功能主治
            $(".drug_function").val(entity.DrugFunction);
            // 贮藏
            $(".drug_storage").val(entity.DrugStorage);
            // 药理作用
            $(".drug_pharmacologic").val(entity.DrugPharmacologic);
            // 药物相互作用
            $(".drug_interations").val(entity.DrugInterations);
            // 注意事项
            $(".drug_announcement").val(entity.DrugAnnouncement);
            // 禁忌
            $(".drug_taboo").val(entity.DrugTaboo);
            // 不良反应
            $(".adverse_effects").val(entity.AdverseEffects);
            // 适应症
            $(".drug_indication").val(entity.DrugIndication);
            // 性状
            $(".drug_character").val(entity.DrugCharacter);
            // 成分
            $(".drug_material").val(entity.DrugMaterial);
            // 用法用量
            $(".drug_instruction").val(entity.DrugInstruction);
            // SEO开关
            $(".is_seo option[value='" + entity.IsSeo + "']").attr("selected", "selected"); ;
            // SEO标题
            $(".seo_title").val(entity.SeoTitle);
            // SEO关键字
            $(".seo_keywords").val(entity.SeoKeywords);
            // SEO描述
            $(".seo_description").val(entity.SeoDescription);

            //判断匹配信息中SEO开关是否是自定义，如果是自定义的，则将SEO信息显示
            if ($(".is_seo option:selected").attr("value") == "自定义") {
                $(".is_seo").parent("li").nextAll().slice(0, 3).show();
            }

            $(".match_gx span").text('如果匹配的功效不是您想要的，您可以清除匹配的功效！');
            $(".match_gx a").text("清除匹配");
        });
    });
});