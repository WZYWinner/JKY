<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_PluploadSingle.ascx.cs" Inherits="Yaohuasoft.Framework.Web.UC_PluploadSingle" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<%@ Import Namespace="System.IO" %>
<link href="/Plupload/script/jquery.plupload.single/css/jquery.plupload.single.css" rel="stylesheet" />
<link href="/Plupload/script/fancybox/jquery.fancybox.css" rel="stylesheet" />
<link href="/Plupload/css/upload_file.css" rel="stylesheet" />
<style>
    #<%=this.ID %>_content_detail img { border: 1px solid #ddd; border-radius: 2px; height: 140px; outline: 0 none; overflow: hidden; width: 140px; background-image: url('/_images/default.png'); }
    #<%=this.ID %>_content_detail { margin: 10px; }
</style>
<%switch (PageType)
    {
        case "可写":
%>
<!--可写-->
<div id="<%=this.ID %>_uploader_add" style="margin: 8px; display: inline-block;">
    <p>你的浏览器有没Flash，Html4，Html5支持</p>
</div>
<%
        break;
%>
<%
    case "只读":
%>
<!--只读-->
<%if (!string.IsNullOrEmpty(UploadUrl))
    { %>
<div class="plupload_preview" id="<%=this.ID %>_content_detail">
    <%
        UploadUrl = UploadUrl.TrimEnd(new char[] { ';', '；' });
        var szExt = Regex.Match(UploadUrl.Trim(), "\\.[^./]+$").Value.ToLower();
        if (szExt.Equals(".pdf"))
        {%>
    <a href="<%=UploadUrl.Trim() %>">
        <img src="<%=Regex.Replace(UploadUrl.Trim(),@"\.[pP][dD][fF]$",".jpg",RegexOptions.IgnoreCase) %>" />
    </a>
    <%}
        else
        {%>
    <a href="<%=UploadUrl.Trim() %>" class="fancybox" rel="group">
        <img src="<%=UploadUrl.Trim() %>" />
    </a>
    <%}%>
</div>
<%} %>
<%
        break;
    } %>
<asp:HiddenField ID="HiddenPageType" runat="server" />
<asp:HiddenField ID="UploaderFileUrl" runat="server" />
<script src="/Plupload/script/fancybox/jquery.fancybox.pack.js"></script>
<script src="/Plupload/script/plupload.full.min.js"></script>
<script src="/Plupload/script/jquery.plupload.single/jquery.plupload.single.js"></script>
<script src="/Plupload/script/i18n/zh-cn.js"></script>
<script>
    String.prototype.regex = function (regexString) { return regexString.test(this); }
    //是否只由汉字、字母、数字组成下划线
    String.prototype.isChinaOrNumbOrLett = function () { return this.regex(/^[0-9a-zA-Z\_\-\u4e00-\u9fa5]+$/); }
    String.prototype.trim = function (c) { return this.replace(eval('/(^{0}*)|({0}*$)/g'.replace(/\{0\}/g, !c ? '\\s' : (c.isChinaOrNumbOrLett() ? c : '\\' + c))), ""); }
    <%
    switch (PageType)
    {
        case "可写":
            %>
    var is_pic_pdf_<%=this.ID%> = "<%=IsPicPdf%>".toLowerCase() == "true";
    var mine_types_<%=this.ID%> = is_pic_pdf_<%=this.ID%> ? [{ title: "Image files", extensions: "jpg,jpeg,pdf" }] : [{ title: "Image files", extensions: "jpg,jpeg" }];
    $("#<%=this.ID %>_uploader_add " + ".fancybox").fancybox();
    $("#<%=this.ID %>_uploader_add").pluploadSingle({
        runtimes: 'html5,html4,flash',
        url: '/Plupload/uploader.ashx' + "?file_type=img",
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
                    if (uploader_url.length > 0 && uploader_url != undefined) {
                        uploader_url = uploader_url.trim(';').trim('；');
                        var ext = uploader_url.trim().substring(uploader_url.trim().lastIndexOf(".") + 1).toLowerCase();
                        if (ext == "pdf") {
                            $("#<%=this.ID %>_uploader_add .plupload_preview a").attr("href", uploader_url.trim()).removeAttr("class", "fancybox").removeAttr("rel", "group");
                            $("#<%=this.ID %>_uploader_add .plupload_preview  img").attr("src", uploader_url.trim().replace(/\.pdf$/ig, ".jpg"));
                        } else {
                            $("#<%=this.ID %>_uploader_add .plupload_preview a").attr("href", uploader_url.trim()).removeAttr("class", "fancybox").removeAttr("rel", "group").attr("class", "fancybox").attr("rel", "group");
                            $("#<%=this.ID %>_uploader_add .plupload_preview  img").attr("src", uploader_url.trim());
                        }
                        $("#<%=this.ID %>_uploader_add .plupload_preview").show();
                    }
                },
                FileUploaded: function (uploader, file, info) {
                    if (info.response != null) {
                        var jsonstr = eval("(" + info.response + ")");
                        if (jsonstr.result_state) {
                            $("#<%=this.ID %>_uploader_add .plupload_preview").show();
                            for (var i = 0; i < jsonstr.list.length; i++) {
                                var url = jsonstr.list[i];
                                var ext = url.trim().substring(url.trim().lastIndexOf(".") + 1).toLowerCase();
                                if (ext == "pdf") {
                                    $("#<%=this.ID %>_uploader_add .plupload_preview a").attr("href", url.trim()).removeAttr("class", "fancybox").removeAttr("rel", "group");
                                    $("#<%=this.ID %>_uploader_add .plupload_preview img").attr("src", url.trim().replace(/\.pdf$/ig, ".jpg"));
                                } else {
                                    $("#<%=this.ID %>_uploader_add .plupload_preview a").attr("href", url.trim()).removeAttr("class", "fancybox").removeAttr("rel", "group").attr("class", "fancybox").attr("rel", "group");
                                    $("#<%=this.ID %>_uploader_add .plupload_preview img").attr("src", url.trim());
                                }
                                $("#<%=this.ID %>_UploaderFileUrl").val(url.trim());
                            }
                        } else {
                            alert(jsonstr.msg);
                        }
                    } else {
                        alert("上传发生错误，请重新试一试");
                    }
                }
            }
        });
        <%
        break;
    case "只读":
            %>
    $("#<%=this.ID %>_content_detail " + ".fancybox").fancybox();
    <%
        break;
    }
    %>
</script>
