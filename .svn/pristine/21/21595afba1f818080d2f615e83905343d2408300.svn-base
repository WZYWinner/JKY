<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiuAddressList.aspx.cs" Inherits="Yaohuasoft.Framework.WebUI.SysAdmin.LiuAddressList" ValidateRequest="false" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<%@ Register TagPrefix="wc" Namespace="net91com.WebControls" Assembly="net91com.WebControls" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>用户地址列表 | </title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="renderer" content="webkit">
<link href="/_css/common2016/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/angular-growl.min.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/console1412.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/ticketSystem/ticketSystem.console.css" rel="stylesheet" type="text/css" />
<link href="/_css/common2016/common.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.console-title{min-height:inherit;}
</style>
<script src="/_js/jquery-1.8.2.js" type="text/javascript"></script>
<script src="/_js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="/_js/common.js" type="text/javascript"></script>
<script src="/_js/layer/layer.js" type="text/javascript"></script>
<script src="/_js/page_common.js" type="text/javascript"></script>
<script src="/_js/colResizable-1.3.min.js"></script><!-- table制作的列表页的列可拖拉插件 -->
<%--自定义List的Script标签--%>
<script type="text/javascript">
$(function () {
var colspan = $("td.no-hover-white").attr("colspan");
if (colspan) {
var length = $(".table th").length
$("td.no-hover-white").attr("colspan", length);
}
var more_info_length = $(".pic_list .more_info font").length;
if (more_info_length<=0) {
$(".pic_list .more_info").hide();
}
$("input:checkbox:not(#selectAll)").click(function () {
selectcheckIsCheck();
});
//js自定义List内容
});
//js自定义List函数内容
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
//自定义弹窗按钮(列表页面)
function btn_pop_list(title, url, x, y) {
////layer.closeAll();
// 处理url
url = url + '&Id=';
// 获取参数
var ids = '';
$("div.pic_list .ck :checked,table.table .ck :checked").each(function () {
var id = $(this).parent().parent().attr("dateid");
if (id == undefined) {
return;
}
ids += id + ",";
});
if (ids != '') {
url += ids;
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
else {
layer.msg("请选择列表项!");
}
}
//弹窗的详细页面
function pic_list_click(obj) {
$(obj).parent().addClass("click_select_color").siblings("tr").removeClass("click_select_color");
var url = $(obj).attr("_url");
if (url == undefined||url == "") {
// 绑定事件
url='LiuAddress_Detail.aspx?&id=' + encodeURIComponent($(obj).parent().attr('dateid')) + '&rnd=<%=YaohuaID.GenRandomInt()%>&query=' + encodeURIComponent($('#QueryString').val())+'';
}
 var title = $(this).attr("_title");
 //iframe窗
 layer.open({
 type: 2,
 title: " ",
 shadeClose: false,
 shade: false,
 maxmin: true, //开启最大化最小化按钮
 area: ['90%', '90%'], // ['1150px', '650px'],
 content: url
 });
 // 移除最小化
 //$(".layui-layer-min").remove();
}
function ischeck(type) {
var i = 0;
$("input:checkbox").each(function (index, item) {
if (item.id != "selectAll") {
if (item.checked) {
i++;
}
}
});
if ($("input:checkbox").length == 1) {
layer.msg("没有可"+type+"的数据!");
return false;
}
if (i == 0) {
layer.msg("请选择要"+type+"的数据!");
return false;
}
else {
return confirm("确定要"+type+"选中数据？");
}
}
function selectcheck(type) {
$("input:checkbox").each(function () {
if (type == '0') {
$(this).removeAttr('checked');
} else {
$(this).attr('checked', 'checked');
}
});
}
function selectcheckAll() {
var ifall = $('#selectAll').attr('checked');
$("input:checkbox").each(function () {
if ($(this).attr('id') != 'selectAll')
if (ifall) {
$(this).attr('checked', 'checked');
} else {
$(this).removeAttr('checked');
}
});
};
function selectcheckReverse() {
$("input:checkbox").each(function () {
//if ($(this).attr('id') != 'selectAll')
if ($(this).attr('checked')) {
$(this).removeAttr('checked');
} else {
$(this).attr('checked', 'checked');
}
});
}
function selectcheckIsCheck() {
if ($("input:checkbox").length>1) {
$("input:checkbox:not(#selectAll)").each(function () {
if (!$(this).attr('checked')) {
$("#selectAll").removeAttr('checked');
return;
}
});
}
}
</script>
</head>
<body style="min-width: 1150px">
<form id="form1" runat="server" class="form-inline ng-valid ng-valid-required">
<input id="QueryString" type="hidden" runat="server" />
<div>
<div class="console-container ng-scope">
<div class="ng-scope">
<div class="row ng-scope">
<div class="col-sm-12">
<div>
<div class="ng-isolate-scope">
<div class="ticket-list ng-scope" >
<div class="console-title list_title console-title-border clearfix" style="padding-top: 10px; padding-bottom: 10px">
<h4>用户地址列表(共<asp:Label ID="listcount" runat="server" Text="0" ForeColor="#0099CC"></asp:Label>条数据)</h4>
</div>
<div style="float:left;">
<div class="simple-form-field ng-scope ng-isolate-scope"><div class="form-group ng-scope"><div class="form-control-wrap"> <a onclick="javascript:pic_list_click(this)" class="btn btn-primary J_btnOpenContentDialog" _url="LiuAddress_Create.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>">新增</a> </div></div></div>
</div>
<div style="display:none">
<div style="float:left;">
<div class="simple-form-field ng-scope ng-isolate-scope"><div class="form-group ng-scope"><div class="form-control-wrap"><asp:DropDownList ID="ddlTextInOne" AutoPostBack="True" runat="server" CssClass ="form-control select-w pull-left" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged"></asp:DropDownList><asp:TextBox ID="txtTextInOne" AutoPostBack="True" CssClass ="form-control ng-pristine ng-valid ng-valid-required" OnTextChanged ="txt_TextChanged" runat="server"></asp:TextBox></div></div></div>
<div class="simple-form-field ng-scope ng-isolate-scope"><div class="form-group ng-scope"><div class="form-control-wrap"><asp:Button ID="btn_Search" runat="server" Text="搜索" OnClick="txt_TextChanged" CssClass="btn btn-primary" /></div></div></div>
</div>
</div>
<div class="pull-right title_r">
<!--新增按钮作废代码-->
<div style="display:none">
<asp:DropDownList ID="ddlSortList" AutoPostBack="True" runat="server" CssClass ="form-control" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" Width="150px"></asp:DropDownList>
</div>
</div>
<div class="ng-scope">
<div class="searchSection">
</div>
<div class="gridSection">
 <!--列表模式-->
 <table class="table table-hover">
 <thead>
 <tr>
 <th style="width:40px;">
 <input id="selectAll" type="checkbox" onclick="selectcheckAll()"/>
 </th>
<th style="    min-width: 80px;">省份</th>
<th style="    min-width: 80px;">收货地址</th>
<th style="    min-width: 80px;">收货人</th>
<th style="    min-width: 80px;">收货人电话</th>
<th style="    min-width: 80px;">标签</th>
<th style="    min-width: 80px;">用户ID</th>
 </tr>
 </thead>
 <tbody>
 <wc:Repeater ID="UiDataList" runat="server">
 <ItemTemplate>
 <tr dateid="<%#Eval("LiuAddressId") %>" class="data_list">
 <td class="ck">
 <asp:CheckBox ID="chkSelect" runat="server" />
 <asp:HiddenField ID="hiddenID" runat="server" Value='<%# Eval("LiuAddressId") %>' />
 </td>
 <td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("Province").ToStrCn()) %> </span></td>
 <td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("Address").ToStrCn()) %> </span></td>
 <td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("Receiver").ToStrCn()) %> </span></td>
 <td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("Telephone").ToStrCn()) %> </span></td>
 <td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("Laber").ToStrCn()) %> </span></td>
 <td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("UserId").ToStrCn()) %> </span></td>
 </tr>
 </ItemTemplate>
 <EmptyDataTemplate>
 <!--**** 没有数据的情况 ****-->
 <tr>
 <td class="no-hover-white" align="center" colspan="7"><div class="none-data-info text-center">
 <span class="text-primary icon-info-1 margin-right"></span>
 没有查询到符合条件的数据，请尝试更改其它查询条件
 </div></td>
 </tr>
 </EmptyDataTemplate>
 </wc:Repeater>
 </tbody>
 </table>
<div class="tfoot">
<div class="pull-left">
<span class="ck_span">选择：<a href="javascript:void(0);" onclick="selectcheck('1')">全选</a> - <a href="javascript:void(0);" onclick="selectcheck('0')">无</a> - <a href="javascript:void(0);"
onclick="selectcheckReverse()">反选</a></span>
<asp:Button ID="btn_Delete" runat="server" Text="删除" OnClientClick="return ischeck('删除');" OnClick="btn_Delete_Click" CssClass="btn btn-primary" />
<a class="btn btn-primary" href="LiuAddress_Upload.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>">导入</a>
<asp:Button ID="btn_Export" runat="server" Text="导出" OnClick="btn_Export_Click" CssClass="btn btn-primary" />
<asp:DropDownList ID="ddl_PageSize" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" CssClass="select_page" runat="server" AutoPostBack="True">
<asp:ListItem Value="10">每页10条</asp:ListItem>
<asp:ListItem Value="15">每页15条</asp:ListItem>
<asp:ListItem Value="30">每页30条</asp:ListItem>
<asp:ListItem Value="50">每页50条</asp:ListItem>
<asp:ListItem Value="100">每页100条</asp:ListItem>
<asp:ListItem Value="100">每页200条</asp:ListItem>
<asp:ListItem Value="500">每页500条</asp:ListItem>
<asp:ListItem Value="1000">每页1000条</asp:ListItem>
</asp:DropDownList>
</div>
<div class="ng-scope pull-right page_list select-width">
<wc:AspNetPager ID="pager" runat="server" AlwaysShow="false" AlwaysShowFirstLastPageNumber="False"
FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CustomInfoHTML=""
ShowPageIndexBox ="Always"
PageIndexBoxType="DropDownList" ShowCustomInfoSection="Left" OnPageChanged="pager_PageChanged" ShowPageIndex ="false"
PageSize="10" CurrentPageButtonClass="curent_page"></wc:AspNetPager>
</div>
</div>
</div>
<div class="simple-grid-none-data-wrap">
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</form>
</body>
</html>
