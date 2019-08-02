<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LxcSubmit_Detail.aspx.cs" Inherits="Yaohuasoft.Framework.WebUI.SysAdmin.LxcSubmitDetail" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>提交订单详情 | </title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/_css/common2016/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/console1412.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/common.css" rel="stylesheet" type="text/css" />
<script src="/_js/jquery-1.8.2.js" type="text/javascript"></script>
<script src="/_js/xheditor/xheditor-1.1.14-zh-cn.min.js" type="text/javascript"></script>
<script src="/_js/xheditor/xheditor_plugins/ubb.min.js" type="text/javascript"></script>
<script src="/_js/myxheditor.js" type="text/javascript"></script>
<script src="/_js/layer/layer.js" type="text/javascript"></script>
<script src="/_js/common.js" type="text/javascript"></script>
<script src="/_js/page_common.js" type="text/javascript"></script>
<script src="/_js/colResizable-1.3.min.js"></script>
<%--自定义Detail的Script标签--%>
<script type="text/javascript">
//自定义弹窗按钮
function btn_pop(title,url,x,y) {
////layer.closeAll();
layer.open({
type: 2,
title: title,
shadeClose: true,
shade: false,
maxmin: true, //开启最大化最小化按钮
area: [x,y],
content: url
});
}
$(function () {
//js自定义Detail内容
});
//js自定义Detail函数内容
</script>
<style>
.titlebg > td:hover, .titlebg > td {
border-left: 6px solid #09C;
padding-top: 8px !important;
padding-bottom: 8px !important;
}
</style>
</head>
<body style="min-width: 1150px">
<form id="form1" runat="server">
<div class="console-title console-title-border clearfix">
<small class="title_small" style="padding-left: 15px;">
<h4 class="txt_title" style="float: left">查看提交订单</h4>
<asp:Label ID="errormsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
<div class="btn_left" style="overflow: hidden; float: left; margin-left: 30px">
<%--自定义Detail的按钮标签之前--%>
<a class="btn btn-primary" hidefocus="" href="LxcSubmit_Modify.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>&id=<%=HttpUtility.UrlEncode(Request["id"])%>" >编辑</a>
<%= entity._CustomCode["DETAIL"] %>
<%--<asp:Button ID="btn_Delete" CssClass="btn btn-primary" runat="server" Text="删除" OnClientClick="return confirm('确定要删除该数据？');" onclick="btn_Delete_Click" />--%>
<%--自定义Detail的按钮标签之后--%>
</div>
</small>
</div>
<asp:HiddenField ID="hiddenID" runat="server" />
<%--自定义Detail的隐藏域标签--%>
<div class="console-container ng-scope">
<div class="row ng-scope">
<div class="col-sm-12">
<ul class="nav"></ul>
<table class="table table_create contact-template-form">
<tbody>
<tr> <td  title ="" colspan ="3"><span class="col_name">商品名称：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitName.ToStr()) %></td><td  title ="" colspan ="3"><span class="col_name">商品价格：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitPrice.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">商品图片：</span><input type="hidden" name="hidden_fileLxcSubmitPic" class=""/><UC:UC_PluploadSingle PageType ="只读" ID="fileLxcSubmitPic" runat="server" /></td><td  title ="" colspan ="2"><span class="col_name">商品数量：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitNum.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">下单用户：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitAddressName.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">手机号：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitAddressPhone.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">下单地址：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitAddressAdres.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">下单时间：</span><%=HttpUtility.HtmlEncode(entity.LxcSubmitAddressTime.ToStr()) %></td> </tr>
</tbody>
</table>
</div>
</div>
</div>
</form>
</body>
</html>
