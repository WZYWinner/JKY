<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecuritiesCentre_Detail.aspx.cs" Inherits="Yaohuasoft.Framework.WebUI.SysAdmin.SecuritiesCentreDetail" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>领劵中心详情 | </title>
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
<h4 class="txt_title" style="float: left">查看领劵中心</h4>
<asp:Label ID="errormsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
<div class="btn_left" style="overflow: hidden; float: left; margin-left: 30px">
<%--自定义Detail的按钮标签之前--%>
<a class="btn btn-primary" hidefocus="" href="SecuritiesCentre_Modify.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>&id=<%=HttpUtility.UrlEncode(Request["id"])%>" >编辑</a>
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
<tr> <td  title ="" colspan ="3"><span class="col_name">领劵次数：</span><%=HttpUtility.HtmlEncode(entity.Num.ToStr()) %></td><td  title ="" colspan ="3"><span class="col_name">领劵类型：</span><%=HttpUtility.HtmlEncode(entity.Type.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">商品ID：</span><%=HttpUtility.HtmlEncode(entity.GoodsId.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">券图：</span><input type="hidden" name="hidden_fileTicketPic" class=""/><UC:UC_PluploadSingle PageType ="只读" ID="fileTicketPic" runat="server" /></td><td  title ="" colspan ="2"><span class="col_name">卖家：</span><%=HttpUtility.HtmlEncode(entity.Seller.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">用户ID：</span><%=HttpUtility.HtmlEncode(entity.UserId.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">券信息：</span><%=HttpUtility.HtmlEncode(entity.TicketInfo.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">券结束时间：</span><%=HttpUtility.HtmlEncode(entity.EndTime.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">领劵开始时间：</span><%=HttpUtility.HtmlEncode(entity.SecuritiesCentreTime.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">不可用券：</span><%=HttpUtility.HtmlEncode(entity.Disable.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">最近修改人员：</span><%=HttpUtility.HtmlEncode(entity.EditUser.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="6"><span class="col_name">最近修改时间：</span><%=HttpUtility.HtmlEncode(entity.EditTime.ToStr()) %></td> </tr>
</tbody>
</table>
</div>
</div>
</div>
</form>
</body>
</html>
