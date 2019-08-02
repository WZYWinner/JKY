<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysAdminHomePage.aspx.cs" Inherits="UI.DEMO.SysAdminHomePage" %>
<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<%@ Import Namespace="Yaohuasoft.Framework.DAL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>
    <link rel="stylesheet" type="text/css" href="/_css/index.css" />
    <link rel="stylesheet" type="text/css" href="/_css/common.css" />
    <style type="text/css">
        body{padding-left:15px;}
        .marquee_moudle{text-indent:2em;overflow:hidden;line-height:24px;text-align:left;margin-left:-20px;background:#fff;padding:10px 0px;}
        .marquee_moudle em{display:inline-block;float:left;color:#666;font-weight:600;}
        .marquee_moudle span{float:left;text-indent:0px;color:red;font-size:12px;padding:0px 10px;}
        .total{
        padding: 0;
        }
        a{
        text-decoration:none
        }
        .top{
        display: flex;
        justify-content: space-between;
        border: 1px solid #ccc;
        background-color: whitesmoke;
        }
        .top1{
        background-color: white;
        border: 1px solid #CCCCCC;
        font-size: 15px;
        }
        .top1_top{
        border-bottom: 1px solid #CCCCCC;
        display: flex;
        padding: 20px;
        justify-content: space-between;
        }
        .top1_bottom{
        padding: 20px;
        }
        .top1_top_right{
        margin-left: 80px;
        }
        .top1_bottom1{
        display: flex;
        justify-content: space-between;
        margin-top: 20px;
        }
        .top1_bottom2,.top1_bottom3,.top1_bottom4{
        margin-top: 10px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        }
        .top1_bottom2_left,.top1_bottom4_left{
        width: 80%;
        height: 7px;
        background-color: whitesmoke;
        }
        .top1_bottom2_right,.top1_bottom4_right{
        color: #ccc;
        font-size: 12px;
        }
        .bottom{
        display: flex;
        justify-content: space-between;
        border: 1px solid whitesmoke;
        margin-top: 30px;
        }
        .bottom_left{
        width: 60%;
        padding: 0 10px;
        }
        .bottom_left ul, .bottom_right ul{
        display: flex;
        }
        .bottom_left li{
        line-height: 40px;
        width: 80px;
        text-align: center;
        color: #777777;
        }
        .bottom_right li{
        line-height: 40px;
        width: 40px;
        text-align: center;
        color: #777777;
        border: whitesmoke 1px solid;
        }
    </style>
    <script src="/_js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="/_js/layer/layer.js" type="text/javascript"></script>
    <script type="text/javascript">
        //自定义弹窗按钮
        function btn_pop(title, url, x, y) {
            layer.closeAll();
            layer.open({
                type: 2,
                title: title,
                shadeClose: true,
                shade: false,
                maxmin: false, //开启最大化最小化按钮
                area: [x, y],
                content: url
            });
        }
    </script>
</head>
<body>
    <div class="total">
    <div class="top">
    <div class="top1">
    <div class="top1_top">
    <div class="top1_top_left1">
    打印总量
    </div>
    <div class="top1_top_right">
    0张
    </div>
    </div>
    <div class="top1_bottom">
    <div class="top1_bottom1">
    <div class="top1_bottom1_left">黑色打印量</div>
    <div class="top1_bottom1_right">0张</div>
    </div>
    <div class="top1_bottom2">
        <div class="top1_bottom2_left"></div>
        <div class="top1_bottom2_right">0%</div>
        </div>
        <div class="top1_bottom3">
            <div class="top1_bottom3_left">彩色打印量</div>
            <div class="top1_bottom3_right">0张</div>
            </div>
            <div class="top1_bottom4">
                <div class="top1_bottom4_left"></div>
                <div class="top1_bottom4_right">0%</div>
            </div>
    </div>
</div>

<div class="top1">
    <div class="top1_top">
    <div class="top1_top_left1">
    任务总量
    </div>
    <div class="top1_top_right">
    0条
    </div>
    </div>
    <div class="top1_bottom">
    <div class="top1_bottom1">
    <div class="top1_bottom1_left">故障量</div>
    <div class="top1_bottom1_right">0条</div>
    </div>
    <div class="top1_bottom2">
        <div class="top1_bottom2_left"></div>
        <div class="top1_bottom2_right">0%</div>
        </div>
        <div class="top1_bottom3">
            <div class="top1_bottom3_left">预警量</div>
            <div class="top1_bottom3_right">0条</div>
            </div>
            <div class="top1_bottom4">
                <div class="top1_bottom4_left"></div>
                <div class="top1_bottom4_right">0%</div>
            </div>
    </div>
</div>
<div class="top1">
    <div class="top1_top">
    <div class="top1_top_left1">
    工单总量
    </div>
    <div class="top1_top_right">
    0单
    </div>
    </div>
    <div class="top1_bottom">
    <div class="top1_bottom1">
    <div class="top1_bottom1_left">已完成工单</div>
    <div class="top1_bottom1_right">0单</div>
    </div>
    <div class="top1_bottom2">
        <div class="top1_bottom2_left"></div>
        <div class="top1_bottom2_right">0%</div>
        </div>
        <div class="top1_bottom3">
            <div class="top1_bottom3_left">待完成工单</div>
            <div class="top1_bottom3_right">0单</div>
            </div>
            <div class="top1_bottom4">
                <div class="top1_bottom4_left"></div>
                <div class="top1_bottom4_right">0%</div>
            </div>
    </div>
</div>
<div class="top1">
    <div class="top1_top">
    <div class="top1_top_left1">
    账单总量
    </div>
    <div class="top1_top_right">
    0单
    </div>
    </div>
    <div class="top1_bottom">
    <div class="top1_bottom1">
    <div class="top1_bottom1_left">已支付账单</div>
    <div class="top1_bottom1_right">0单</div>
    </div>
    <div class="top1_bottom2">
        <div class="top1_bottom2_left"></div>
        <div class="top1_bottom2_right">0%</div>
        </div>
        <div class="top1_bottom3">
            <div class="top1_bottom3_left">未支付账单</div>
            <div class="top1_bottom3_right">0单</div>
            </div>
            <div class="top1_bottom4">
                <div class="top1_bottom4_left"></div>
                <div class="top1_bottom4_right">0%</div>
            </div>
    </div>
</div>
<div class="top1">
    <div class="top1_top">
    <div class="top1_top_left1">
    打租户总量
    </div>
    <div class="top1_top_right">
    0位
    </div>
    </div>
    <div class="top1_bottom">
    <div class="top1_bottom1">
    <div class="top1_bottom1_left">签约租户</div>
    <div class="top1_bottom1_right">0位</div>
    </div>
    <div class="top1_bottom2">
        <div class="top1_bottom2_left"></div>
        <div class="top1_bottom2_right">0%</div>
        </div>
        <div class="top1_bottom3">
            <div class="top1_bottom3_left">待签约租户</div>
            <div class="top1_bottom3_right">0位</div>
            </div>
            <div class="top1_bottom4">
                <div class="top1_bottom4_left"></div>
                <div class="top1_bottom4_right">0%</div>
            </div>
    </div>
</div>
<div class="top1">
    <div class="top1_top">
    <div class="top1_top_left1">
    设备总量
    </div>
    <div class="top1_top_right">
    0台
    </div>
    </div>
    <div class="top1_bottom">
    <div class="top1_bottom1">
    <div class="top1_bottom1_left">签约设备</div>
    <div class="top1_bottom1_right">0台</div>
    </div>
    <div class="top1_bottom2">
        <div class="top1_bottom2_left"></div>
        <div class="top1_bottom2_right">0%</div>
        </div>
        <div class="top1_bottom3">
            <div class="top1_bottom3_left">待签约设备</div>
            <div class="top1_bottom3_right">0台</div>
            </div>
            <div class="top1_bottom4">
                <div class="top1_bottom4_left"></div>
                <div class="top1_bottom4_right">0%</div>
            </div>
    </div>
</div>

</div>
    <div class="bottom">
    <div class="bottom_left">
    <ul>
   <a href=""><li>打印量</li></a>
    <a href=""><li>任务量</li></a>
    <a href=""><li>工单量</li></a>
    <a href=""><li>账单量</li></a>
    <a href=""><li>租户量</li></a>
    <a href=""><li>设备量</li></a>
</ul>
    </div>
<div class="bottom_right">
<ul>
<li>日</li>
<li>月</li>
<li>年</li>
</ul>
</div>
</div>
</div>
    <%--<form id="form1" runat="server">--%>
    <%--<div id="outerwrap">--%>
        <%--<div id ="innerwrap">--%>
            <%--<div id="contentwrap">--%>
                <%--<div id="content">--%>
                    <%--<h6>APP项目</h6>--%>
                    <%--<div class="contentint">--%>
                        <%--<div class="function div_manual_flow">--%>
                            <%--<div class="function_title">--%>
                                <%--<h3>设备管理</h3>--%>
                            <%--</div>--%>
                            <%--<ul class="flow_pic">--%>
                                <%--<li><a href="../WebUI/SysAdmin/DeviceManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">设备管理</a></li>--%>
                                <%--<li><a href="../WebUI/SysAdmin/UpgradeRecord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">升级记录</a></li>--%>
                            <%--</ul>--%>
                        <%--</div>--%>
                        <%--<div class="noticewrap">--%>
                            <%--<div class="notice mr">--%>
                                <%--<div class="notice_top">--%>
                                    <%--<h3>设备管理</h3>--%>
                                    <%--<a href="/WebUI/SysAdmin/DeviceManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">更多>></a>--%>
                                <%--</div>--%>
                                <%----%>
                                <%--<ul>--%>
                                    <%--<asp:Repeater ID="repDevice" runat="server">--%>
                                        <%--<ItemTemplate>--%>
                                          <%--<li><a href="/WebUI/SysAdmin/DeviceManage_Detail.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&id=<%#Eval("DeviceId") %>"><%#Eval("RestaurantName") %><span><%#Eval("UpgradeTime") %></span></a></li>--%>
                                        <%--</ItemTemplate>--%>
                                    <%--</asp:Repeater>--%>
                                <%--</ul>--%>
                            <%--</div>--%>
                            <%--<div class="notice">--%>
                                <%--<div class="notice_top msg">--%>
                                    <%--<h3>升级记录</h3>--%>
                                    <%--<a href="/WebUI/SysAdmin/UpgradeRecord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">更多>></a>--%>
                                <%--</div>--%>
                                <%--<ul>--%>
                                    <%--<asp:Repeater ID="repPgrade" runat="server">--%>
                                        <%--<ItemTemplate>--%>
                                           <%--<li><a href="/WebUI/SysAdmin/UpgradeRecord_Detail.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&id=<%#Eval("DeviceId") %>"><%#Eval("Imei") %><span><%#Eval("UpgradeTime") %></span></a></li>--%>
                                        <%--</ItemTemplate>--%>
                                    <%--</asp:Repeater>--%>
                                <%--</ul>--%>
                            <%--</div>--%>
                        <%--</div>--%>
                    <%--</div>--%>
                    <%--</div>--%>
            <%--</div>--%>
        <%--</div>--%>
    <%--</div> --%>
    <%--</form>--%>
</body>
</html>
