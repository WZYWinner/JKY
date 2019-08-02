﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="SysConfig_Modify.aspx.cs" Inherits=" Yaohuasoft.Framework.WebUI.SysAdmin.SysConfigModify" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>修改通用配置信息 | </title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="renderer" content="webkit">
<link href="/_css/common2016/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/console1412.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/common.css" rel="stylesheet" type="text/css" />
<script src="/_js/jquery-1.8.2.js" type="text/javascript"></script>
<script src="/_js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="/_js/layer/layer.js" type="text/javascript"></script>
<script src="/_js/jquery.validate.js" type="text/javascript"></script>
<script src="/_js/messages_zh.js" type="text/javascript"></script>
<script src="/_js/jquery.metadata.js" type="text/javascript"></script>
<script src="/_js/common.js" type="text/javascript"></script>
<link href="/_js/textareaFullScreen/textareafullscreen.css" rel="stylesheet" />
<script src="/_js/textareaFullScreen/jquery.textareafullscreen.js"></script>
<script src="/_js/page_common.js" type="text/javascript"></script>
<%--自定义Modify的Script标签--%>
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
//js自定义Modify内容
});
//js自定义Modify函数内容
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
<h4 class="txt_title" style="float: left">编辑通用配置信息</h4>
<asp:Label ID="errormsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
<div class="btn_left" style="overflow: hidden; float: left; margin-left: 30px">
<%--自定义Modify的按钮标签之前--%>
 <asp:Button ID="btn_Save" runat="server" Text="保存" CssClass="btn btn-primary" OnClientClick="return checkdata();" onclick="btn_Save_Click" />
<a class="btn btn-primary" href="javascript:window.location.href='SysConfig_Detail.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>&id=<%=HttpUtility.UrlEncode(Request["id"])%>'" name="del">返回</a>
<%= entity._CustomCode["MODIFY"] %>
<%--<asp:Button ID="btn_Delete" CssClass="btn btn-primary" runat="server" Text="删除" OnClick="btn_Delete_Click" OnClientClick="return confirm('确定要删除该数据？');" />--%>
<%--自定义Modify的按钮标签之后--%>
</div>
</small>
</div>
<asp:HiddenField ID="hiddenID" runat="server" />
<%--自定义Modify的隐藏域标签--%>
<div class="console-container ng-scope">
<div class="row ng-scope">
<div class="col-sm-12">
<ul class="nav"></ul>
<table class="table table_create contact-template-form">
<tbody>
<tr> <td  title ="数据类型" colspan ="3"><span class="col_name">数据类型：</span><asp:TextBox ID="tbTypeId" MaxLength="200" runat="server" CssClass="tbox  " ></asp:TextBox><b></b></td><td  title ="权重" colspan ="3"><span class="col_name">权重：</span><asp:TextBox ID="tbPowerIndex" MaxLength="200" runat="server" CssClass="tbox  " ></asp:TextBox><b></b></td> </tr>
<tr> <td  title ="代码" colspan ="2"><span class="col_name">代码：</span><asp:TextBox ID="tbCode" MaxLength="200" runat="server" CssClass="tbox  " ></asp:TextBox><b></b></td><td  title ="名称" colspan ="2"><span class="col_name">名称：</span><asp:TextBox ID="tbName" MaxLength="200" runat="server" CssClass="tbox  " ></asp:TextBox><b></b></td><td  title ="描述" colspan ="2"><span class="col_name">描述：</span><asp:TextBox ID="tbDescript" runat="server" CssClass="tbox  " TextMode="MultiLine" ></asp:TextBox><b></b></td> </tr>
</tbody>
</table>
</div>
</div>
</div>
</form>
</body>
</html>
