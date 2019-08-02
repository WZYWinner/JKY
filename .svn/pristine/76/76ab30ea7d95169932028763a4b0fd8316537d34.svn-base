<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Plupload2.ascx.cs" Inherits="Yaohuasoft.Framework.Web.UC_Plupload2" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<%@ Import Namespace="System.IO" %>
<link href="/Plupload/script/jquery.plupload.queue2/css/jquery.plupload.queue.css" rel="stylesheet" />
<link href="/Plupload/script/fancybox/jquery.fancybox.css" rel="stylesheet" />
<style>
    #<%=this.ID%>_uploader_queue_add .plupload_queue_preview ul li {
        float: left; margin-right: 10px; margin-top: 8px; position: relative; width: 100px;
        line-height: 0;overflow: initial;
    }
    #<%=this.ID %>_content_queue_detail ul li{
        float: left;
    margin-right: 10px;
    margin-top: 8px;
    position: relative;
    width: 140px;
    }
    #<%=this.ID %>_content_queue_detail img{
        border: 1px solid #ddd;
    border-radius: 2px;
    height: 140px;
    outline: 0 none;
    overflow: hidden;
    width: 140px;
    background-image:url('/_images/default.png');
    }
    #<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul li.plupload_file_li .plupload_file_dummy span,#<%=this.ID %>_content_queue_detail ul li.plupload_file_li .plupload_file_dummy span{
        font-size: 21px;
    line-height: 70px;
    padding: 0;
    }
    #<%=this.ID %>_uploader_queue_add  .plupload_queue_preview ul li.plupload_file_li .plupload_file_name span,#<%=this.ID %>_content_queue_detail ul li.plupload_file_li .plupload_file_name span{
        padding:0px;
    }
</style>
<%switch (PageType)
    {
        case "读写":
        case "只写":
%>
<!--读写-->
<!--只写--->
<div id="<%=this.ID %>_uploader_queue_add" style="margin: 8px;display:inline-block;position: relative;">
   <p>你的浏览器有没Flash，Html4，Html5支持</p>
</div>
<%
        break;
    case "只读":
%>
<!--只读-->
<%if(!string.IsNullOrEmpty(UploadUrl)) { %>
<div class="plupload_queue_preview" id="<%=this.ID %>_content_queue_detail" style="margin: 8px;position: relative;display:inline-block;">
    <ul>
        <%
            string[] uploaderUrlList = UploadUrl.Split(new char[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries);
             %>
        <%foreach (var item in uploaderUrlList)
            {%>
         <%if (IsPicMode)
             {
                 var szExt =Regex.Match(item.Trim(), "\\.[^./]+$").Value.ToLower();
                 if (szExt.Equals(".pdf"))
                 {%>
        <li>
            <a href="<%=item.Trim() %>" class="uploader_url">
                <img src="<%=Regex.Replace(item.Trim(),@"\.[pP][dD][fF]$",".jpg",RegexOptions.IgnoreCase) %>"/>
            </a>
        </li>
                 <%}
                 else
                 {%>
        <li>
            <a href="<%=item.Trim() %>" class="fancybox uploader_url" rel="group">
                <img src="<%=item.Trim() %>"/>
            </a>
        </li>
                 <%}%>
        
        <%}
            else
            {
                string fileName = Path.GetFileName(item.Trim());
                string ext = Path.GetExtension(item.Trim()).TrimStart('.').ToLower();%>
        <li class="plupload_file_li">
            <a href="<%=item %>" class="uploader_url">
                <div class="plupload_file_dummy">
                    <span><%=ext %></span>
                </div>
                <div class="plupload_file_name" title="<%=fileName %>">
                    <span><%=fileName %></span>
                </div>
            </a>
        </li>
        <%} %>
            <%}%>
    </ul>
</div>
<%} %>
<%
        break;
    } %>
<asp:HiddenField ID="HiddenPageType" runat="server" />
<asp:HiddenField ID="UploaderFileUrl" runat="server" />
<script src="/Plupload/script/fancybox/jquery.fancybox.pack.js"></script>
<script src="/Plupload/script/plupload.full.min.js"></script>
<script src="/Plupload/script/jquery.plupload.queue2/jquery.plupload.queue.js"></script>
<script src="/Plupload/script/i18n/zh-cn.js"></script>
<script type="text/javascript">
    //组装图片地址
    function assemble<%=this.ID%>UploaderFile(name) {
        var url_list = "";
        $("#"+name+" ul li").each(function (i, value) {
            var url = $(this).find(".uploader_url").attr("href");
            url_list += url + ";";
        });
        $("#<%=this.ID %>_UploaderFileUrl").val(url_list);
    }
    //删除图片
    function delete<%=this.ID%>UploaderFile(_this,name) {
        var li = $(_this).parent().parent();
        li.remove();
        assemble<%=this.ID%>UploaderFile(name);
    }
    String.prototype.regex = function (regexString) { return regexString.test(this); }
    /*字符床格式化*/
    String.prototype.format = function (array) { var str = this.toString(); for (var i in array) { str = str.replace(eval('/\\{' + i + '\\}/g'), array[i]); } return str; }
    //是否只由汉字、字母、数字组成下划线
    String.prototype.isChinaOrNumbOrLett = function () { return this.regex(/^[0-9a-zA-Z\_\-\u4e00-\u9fa5]+$/); }
    //去空格  返回值:去空后的字符串
    //删除左右两端的空格
    String.prototype.trim = function (c) { return this.replace(eval('/(^{0}*)|({0}*$)/g'.replace(/\{0\}/g, !c ? '\\s' : (c.isChinaOrNumbOrLett() ? c : '\\' + c))), ""); }
    <%
    switch (PageType)
    {
        case "读写":
        case "只写":
            %>
    var is_pic_mode_<%=this.ID%> = "<%=IsPicMode%>".toLowerCase() == "true";
    var is_pic_pdf_<%=this.ID%>="<%=IsPicPdf%>".toLowerCase() == "true";
    var html_<%=this.ID%> = is_pic_mode_<%=this.ID%> ? '<li>' +
                    '<a href="{0}" {1}>' +
                            '<img src="{2}" />' +
                    '</a>' +
                    '<div class="plupload_file_action">' +
                        '<a href="javascript:void(0)" class="plupload_delete" onclick="delete<%=this.ID%>UploaderFile(this,\'<%=this.ID %>_uploader_queue_add .plupload_queue_preview\')"></a>' +
                    '</div>' +
                '</li>' :
                '<li class="plupload_file_li">' +
                    '<a href="{0}" class="uploader_url">' +
                        '<div class="plupload_file_dummy">' +
                            '<span>{1}</span>' +
                        '</div>' +
                        '<div class="plupload_file_name" title="{2}">' +
                            '<span>{2}</span>' +
                        '</div>' +
                        '<div class="plupload_file_action">' +
                            '<a href="javascript:void(0)" class="plupload_delete" onclick="delete<%=this.ID%>UploaderFile(this,\'<%=this.ID %>_uploader_queue_add .plupload_queue_preview\')"></a>' +
                    '</div>' +
                    '</a>' +
                '</li>';
    var mine_types_<%=this.ID%>=is_pic_mode_<%=this.ID%>?(is_pic_pdf_<%=this.ID%>?[{ title: "Image files", extensions: "jpg,jpeg,pdf" }]:[{ title: "Image files", extensions: "jpg,jpeg" }]):[{ title: "Zip files", extensions: "zip,rar,pdf" }];
    $("#<%=this.ID %>_uploader_queue_add " + ".fancybox").fancybox();
    $("#<%=this.ID %>_uploader_queue_add").pluploadQueue({
        runtimes: 'html5,html4,flash',
        url: '/Plupload/uploader.ashx'+(is_pic_mode_<%=this.ID%>?"?file_type=img":""),
        filters: {
            max_file_size: '2mb',
            mime_types: mine_types_<%=this.ID%>
        },
        // Flash settings
        // plupload.flash.swf 的所在路径
        flash_swf_url: '/Plupload/script/Moxie.swf',

        // Silverlight settings
        // silverlight所在路径
        //silverlight_xap_url: 'script/Moxie.xap',
        //初始化
        init: {
            PostInit: function (uploader) {
                var uploader_url = $("#<%=this.ID %>_UploaderFileUrl").val();
                if (uploader_url.length > 0) {
                    var uploader_url_items = uploader_url.split(/;|；/);
                    if(uploader_url_items.length>0) {
                        for (var i = 0; i < uploader_url_items.length; i++) {
                            var uploader_url_item = uploader_url_items[i];
                            if (uploader_url_item != undefined && uploader_url_item.length > 0) {
                                var ext = uploader_url_item.trim().substring(uploader_url_item.trim().lastIndexOf(".") + 1).toLowerCase();
                                if (is_pic_mode_<%=this.ID%>) {
                                    if (ext=="pdf") {
                                        $("#<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul").append(html_<%=this.ID%>.format([uploader_url_item.trim(),"class=\"uploader_url\"",uploader_url_item.trim().replace(/\.pdf$/ig,".jpg")]));
                                    }else{
                                        $("#<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul").append(html_<%=this.ID%>.format([uploader_url_item.trim(),"class=\"fancybox uploader_url\" rel=\"group\"",uploader_url_item.trim()]));
                                    }
                                } else {
                                    //文件名
                                    var fileName = uploader_url_item.trim().substring(uploader_url_item.trim().lastIndexOf("/") + 1);
                                    $("#<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul").append(html_<%=this.ID%>.format([uploader_url_item.trim(), ext, fileName]));
                                }
                            }

                        }
                    }
                }
            },
            FileUploaded: function (uploader, file, info) {
                if (info.response != null) {
                    var jsonstr = eval("(" + info.response + ")");
                    if (jsonstr.result_state) {
                        for (var i = 0; i < jsonstr.list.length; i++) {
                            var url = jsonstr.list[i];
                            if (url != undefined && url.length > 0) {
                                var parts = /^(.+)\.([^.]+)$/.exec(file.name);
                                if (is_pic_mode_<%=this.ID%>) {
                                    var ext=parts[2].toLowerCase();
                                    if (ext=="pdf") {
                                        $("#<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul").append(html_<%=this.ID%>.format([url.trim(),"class=\"uploader_url\"",url.trim().replace(/\.pdf$/ig,".jpg")]));
                                    }else{
                                        $("#<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul").append(html_<%=this.ID%>.format([url.trim(),"class=\"fancybox uploader_url\" rel=\"group\"",url.trim()]));
                                    }
                                } else {
                                    $("#<%=this.ID %>_uploader_queue_add .plupload_queue_preview ul").append(html_<%=this.ID%>.format([url.trim(), parts[2], file.name]));
                                }
                            }
                        }
                    } else {
                        alert(file.name + "的文件:" + jsonstr.msg);
                    }
                } else {
                    alert(file.name + "的文件上传发生错误，请重新试一试");
                }
            },
            UploadComplete: function (uploader, files) {
                assemble<%=this.ID%>UploaderFile("<%=this.ID %>_uploader_queue_add .plupload_queue_preview");
            }
        }
    });
        <%
        break;
    case "只读":
            %>
    $("#<%=this.ID %>_content_queue_detail " + ".fancybox").fancybox();
    <%
        break;
    }
    %>
</script>
