<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="SysUser_Upload.aspx.cs" Inherits=" Yaohuasoft.Framework.WebUI.WzyAdmin.SysUserUpload" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>导入后台用户 | </title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/_css/common2016/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/console1412.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/common.css" rel="stylesheet" type="text/css" />
<script src="/_js/jquery-1.8.2.min.js" type="text/javascript"></script>
<script src="/_js/common.js" type="text/javascript"></script>
<script src="/_js/page_common.js" type="text/javascript"></script>
<%--自定义Upload的Script标签--%>
<script>
$(function () {
//js自定义Upload内容
});
//js自定义Upload函数内容
</script>
</head>
<body style="min-width: 1150px">
<form id="form1" runat="server">
<div class="console-title console-title-border drds-detail-title clearfix">
<small class="title_small" style="padding-left: 15px;">
<h4 class="txt_title" style="float: left">导入后台用户</h4>
<div class="btn_left" style="overflow: hidden; float: left; margin-left: 30px"><a class="btn btn-primary" href="javascript:window.location.href='SysUser_List.aspx?&id=<%=HttpUtility.UrlEncode(Request["id"])%>&rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>'" name="del">返回</a></div>
</small>
</div>
<div class="console-container ng-scope">
<div class="row ng-scope">
<div class="col-sm-12">
<div class="margin-top-3">
<div class="margin-top-1">
<small class="alert alert-info upload_small">
<span><font>选择导入文件：</font><asp:FileUpload ID="FileUpload1" runat="server" CssClass="input_upload" /></span>
<asp:Button ID="btn_Import" runat="server" Text="确定导入" CssClass="btn btn-primary" OnClientClick="return checkdata();" onclick="btn_Import_Click"/>
<asp:Label ID="lbMessage" runat="server" CssClass="text-danger" Text="（请选择你要导入的EXCEL文件！）"></asp:Label>
</small>
</div>
<div class="margin-top-1">
<div class="alert alert-tip">
<b>温馨提示：</b>
<p>
1、上传文件格式支持xls和xlsx。
<br>
2、每次最多可导入10000条数据。
<br>
3、如数据量较大，需等待。
</p>
</div>
</div>
</div>
</div>
</div>
</div>
</form>
</body>
</html>
