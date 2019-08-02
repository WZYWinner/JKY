<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LqAdminHomePage.aspx.cs" Inherits="UI.DEMO.LqAdminHomePage" %>
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
    <form id="form1" runat="server">
    <div id="outerwrap">
        <div id ="innerwrap">
            <div id="contentwrap">
                <div id="content">
                    <h6>APP项目</h6>
                    <div class="contentint">
                        <div class="function div_manual_flow">
                            <div class="function_title">
                                <h3>设备管理</h3>
                            </div>
                            <ul class="flow_pic">
                                <li><a href="../WebUI/SysAdmin/DeviceManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">设备管理</a></li>
                                <li><a href="../WebUI/SysAdmin/UpgradeRecord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">升级记录</a></li>
                            </ul>
                        </div>
                        <div class="noticewrap">
                            <div class="notice mr">
                                <div class="notice_top">
                                    <h3>设备管理</h3>
                                    <a href="/WebUI/SysAdmin/DeviceManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">更多>></a>
                                </div>
                                
                                <ul>
                                    <asp:Repeater ID="repDevice" runat="server">
                                        <ItemTemplate>
                                          <li><a href="/WebUI/SysAdmin/DeviceManage_Detail.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&id=<%#Eval("DeviceId") %>"><%#Eval("RestaurantName") %><span><%#Eval("UpgradeTime") %></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="notice">
                                <div class="notice_top msg">
                                    <h3>升级记录</h3>
                                    <a href="/WebUI/SysAdmin/UpgradeRecord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>">更多>></a>
                                </div>
                                <ul>
                                    <asp:Repeater ID="repPgrade" runat="server">
                                        <ItemTemplate>
                                           <li><a href="/WebUI/SysAdmin/UpgradeRecord_Detail.aspx?rnd=<%=YaohuaID.GenRandomInt()%>&id=<%#Eval("DeviceId") %>"><%#Eval("Imei") %><span><%#Eval("UpgradeTime") %></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
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
