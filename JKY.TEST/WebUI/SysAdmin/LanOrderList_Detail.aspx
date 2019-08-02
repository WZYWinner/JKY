<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LanOrderList_Detail.aspx.cs" Inherits="Yaohuasoft.Framework.WebUI.SysAdmin.LanOrderListDetail" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<%@ Register TagPrefix="wc" Namespace="net91com.WebControls" Assembly="net91com.WebControls" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>LAN订单详情 | </title>
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
$(function () {
//js自定义Detail内容
});
//js自定义Detail函数内容
//弹窗的详细页面
function pic_list_click(obj) {
$(obj).parent().addClass("click_select_color").siblings("tr").removeClass("click_select_color");
var url = $(obj).attr("_url");
if (url == undefined||url == "") {
// 绑定事件
url='LanOrderGood_Detail.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&id=' + encodeURIComponent($(obj).parent().attr('dateid')) + '&query=' + encodeURIComponent($('#QueryString').val())+'';
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
<input id="QueryString" type="hidden" runat="server" />
<div class="console-title console-title-border clearfix">
<small class="title_small" style="padding-left: 15px;">
<h4 class="txt_title" style="float: left">查看LAN订单</h4>
<asp:Label ID="errormsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
<div class="btn_left" style="overflow: hidden; float: left; margin-left: 30px">
<%--自定义Detail的按钮标签之前--%>
<a class="btn btn-primary" hidefocus="" href="LanOrderList_Modify.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>&id=<%=HttpUtility.UrlEncode(Request["id"])%>" >编辑</a>
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
<tr> <td  title ="" colspan ="3"><span class="col_name">商品数量：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListGoodsnum.ToStr()) %></td><td  title ="" colspan ="3"><span class="col_name">商品总价：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListSumgoodsprice.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">配送费：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListSentprice.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">订单合计金额：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListSumprice.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">支付方式：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListType.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">下单时间：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListAddtime.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">支付时间：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListOktime.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">用户编号：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListUserid.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">收货人：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListUsername.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">收货人电话：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListUsertel.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">收货地址：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListAddress.ToStr()) %></td> </tr>
<tr> <td  title ="" colspan ="2"><span class="col_name">配送员：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListSenduser.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">配送员电话：</span><%=HttpUtility.HtmlEncode(entity.LanOrderListSendusertel.ToStr()) %></td><td  title ="" colspan ="2"><span class="col_name">订单状态：</span><%=HttpUtility.HtmlEncode(entity.LanOrderType.ToStr()) %></td> </tr>
</tbody>
</table>
<div class="console-title list_title console-title-border clearfix" style="padding-top: 5px; padding-bottom: 10px; min-height :50px ;">
<h4>相关的LAN订单明细(共<asp:Label ID="listcount" runat="server" Text="0" ForeColor="#0099CC"></asp:Label>条数据)</h4>
</div>
<div style="float:left;">
<div class="simple-form-field ng-scope ng-isolate-scope"><div class="form-group ng-scope"><div class="form-control-wrap"> <a onclick="javascript:pic_list_click(this)" class="btn btn-primary J_btnOpenContentDialog" _url="LanOrderGood_Create.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>">新增</a> </div></div></div>
<div class="simple-form-field ng-scope ng-isolate-scope"><div class="form-group ng-scope"><div class="form-control-wrap"><asp:DropDownList ID="ddlTextInOne" AutoPostBack="True" runat="server" CssClass ="form-control select-w pull-left" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged"></asp:DropDownList><asp:TextBox ID="txtTextInOne" AutoPostBack="True" CssClass ="form-control ng-pristine ng-valid ng-valid-required" OnTextChanged ="txt_TextChanged" runat="server"></asp:TextBox></div></div></div>
</div>
<div class="pull-right title_r">
<!--新增按钮作废代码-->
<asp:DropDownList ID="ddlSortList" AutoPostBack="True" runat="server" CssClass ="form-control" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" Width="150px"></asp:DropDownList>
</div>
<div class="ng-scope">
<div class="searchSection">
</div>
<div class="gridSection">
<!--列表模式-->
<table class="table table-hover">
<thead>
<tr>
<th style="width:30px;">
<input id="selectAll" type="checkbox" onclick="selectcheckAll()"/>
</th>
<th style="">商品名称</th>
<th style="">商品展示图标</th>
<th style="">商品单价</th>
<th style="">商品数量</th>
<th style="">当前商品总价</th>
</tr>
</thead>
<tbody>
<wc:Repeater ID="UiDataList" runat="server">
<ItemTemplate>
<tr dateid="<%#Eval("LanOrderGoodId") %>" class="data_list">
<td class="ck">
<asp:CheckBox ID="chkSelect" runat="server" />
<asp:HiddenField ID="hiddenID" runat="server" Value='<%# Eval("LanOrderGoodId") %>' />
</td>
<td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("GoodsMsg").ToStrCn()) %></span></td>
<td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("GoodsShowimg").ToStrCn()) %></span></td>
<td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("GoodsPrice").ToStrCn()) %></span></td>
<td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("LanOrderGoodNum").ToStrCn()) %></span></td>
<td class="c_point" _url="" _Color="" _Key="" onclick="javascript:pic_list_click(this)" ><span> <%#HttpUtility.HtmlEncode(Eval("LanOrderGoodsSumprice").ToStrCn()) %></span></td>
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
<asp:Button ID="btn_Delete_B" runat="server" Text="删除" OnClientClick="return ischeck('删除');" OnClick="btn_Delete_B_Click" CssClass="btn btn-primary" />
<a class="btn btn-primary" href="LanOrderGood_Upload.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&query=<%=HttpUtility.UrlEncode(Request["query"])%>">导入</a>
<asp:Button ID="btn_Export" runat="server" Text="导出" OnClick="btn_Export_Click" CssClass="btn btn-primary" />
<asp:DropDownList ID="ddl_PageSize" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" CssClass="select_page" runat="server" AutoPostBack="True"><asp:ListItem Value="10">每页10条</asp:ListItem><asp:ListItem Value="15">每页15条</asp:ListItem><asp:ListItem Value="30">每页30条</asp:ListItem><asp:ListItem Value="50">每页50条</asp:ListItem></asp:DropDownList>
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
</div>
</div>
</form>
</body>
</html>
