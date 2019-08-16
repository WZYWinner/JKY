﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysAdmin.aspx.cs" Inherits="UI.DEMO.SysAdmin" %>

<%@ Import Namespace="Yaohuasoft.Framework.Library" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统管理员后台</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link href="/_css/common2016/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="/_css/common2016/angular-growl.min.css" rel="stylesheet" type="text/css" />
    <link href="/_css/common2016/console1412.css" rel="stylesheet" type="text/css" />
    <link href="/_css/common2016/ticketSystem/ticketSystem.console.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .viewFramework-sidebar .sidebar-nav ul {
            background: #485368;
        }

        div.nav-icon.sidebar-trans, .nav-icon {
            padding-top: 13px;
        }

        .sidebar-title-icon, .sidebar-title-icon span {
            line-height: 45px;
        }

        [ng\:cloak], [ng-cloak], [data-ng-cloak], [x-ng-cloak], .ng-cloak, .x-ng-cloak, .ng-hide {
            display: none !important;
        }

        ng\:form {
            display: block;
        }

        .ng-animate-start {
            border-spacing: 1px 1px;
            -ms-zoom: 1.0001;
        }

        .ng-animate-active {
            border-spacing: 0px 0px;
            -ms-zoom: 1;
        }

        .ShowRed {
            color: #ff9900;
        }

        .aliyun-console-topbar .topbar-logo {
            width: auto;
            padding: 0px 10px;
        }

        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-panel.android_panel {
            width: 400px;
        }

        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-panel {
            width: 150px;
        }

        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-image {
            width: 120px;
        }

            .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-image.android_img {
                margin-right: 5px;
                float: left;
            }

        .img_phone {
            width: 120px;
            height: 120px;
            float: left;
        }

        .aliyun-console-topbar .topbar-qrcode .android_panel .topbar-qrcode-title {
            float: left;
            width: 126px;
        }
    </style>
    <script src="/_js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="/_js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // 顶部缩放
            $(".sidebar-fold").on("click", function () {
                $(".viewFramework-body").toggleClass("viewFramework-sidebar-mini");
                $(".viewFramework-body").toggleClass("viewFramework-sidebar-full");
                $(".sidebar-fold").toggleClass("icon-fold");
                $(".sidebar-fold").toggleClass("icon-unfold")
            });
            // 侧滑
            $(".product-navbar-collapse").on("click", function () {
                $(".viewFramework-product").toggleClass("viewFramework-product-col-1");
            })
            //去除二级菜单，主菜单点击，iframe地址切换
            $(".nav-item").on("click", function () {
                $(".nav-item").removeClass("active");
                $(this).addClass("active");
                $("#mainFrame").attr("src", $(this).attr("src"));
            });
            //只有大菜单的时候点击，iframe地址切换
            $(".sidebar-title-inner").on("click", function () {
                $(".nav-item").removeClass("active");
                $(this).addClass("active");
                $("#mainFrame").attr("src", $(this).attr("src"));
                $(this).parent().parent().toggleClass("sidebar-nav-fold");
                $(this).parent().parent().siblings(".sidebar-nav").addClass("sidebar-nav-fold");
            });
            // 侧滑选项
            $(".product-nav-list li").on("click", function () {
                $(this).addClass("active").siblings().removeClass("active");
                $("#mainFrame").attr("src", $(this).attr("src"));
            });

            // 下拉
            $(".dropdown").on("click", function () {
                $(this).toggleClass("open");
            }).mouseleave(function () {
                if ($(this).hasClass("open")) {
                    $(this).toggleClass("open");
                }
            });
        });
        function showRight(src) {
            $("#mainFrame").attr("src", src);
        }
    </script>
</head>
<body>
    <div>
        <!-- ngIf: config.showTopbar -->
        <div class="viewFramework-topbar ng-scope">
            <!-- topbar -->
            <div class="aliyun-console-topbar ng-isolate-scope">
                <div class="topbar-wrap topbar-clearfix">
                    <div class="topbar-head topbar-left">
                        <a href="javascript:void(0)" target="_blank" class="topbar-logo topbar-left"><span
                            class="">实习项目</span></a>
                        <!-- ngIf: !versionGreaterThan1_3_21 -->
                        <!-- ngIf: versionGreaterThan1_3_21 -->
                        <a href="javascript:showRight('SysAdminHomePage.aspx')" class="topbar-home-link topbar-btn topbar-left ng-scope">
                            <span class="ng-binding">系统管理员</span></a><!-- end ngIf: versionGreaterThan1_3_21 -->
                    </div>
                    <div class="topbar-nav topbar-left dropdown">
                        <a href="javascript:void(0)" class="dropdown-toggle topbar-btn topbar-nav-btn"><span
                            class="ng-binding">快捷操作</span><span class="icon-arrow-down"></span></a>
                        <div class="dropdown-menu topbar-nav-list topbar-clearfix">
                            <div class="topbar-nav-col ng-scope">
                                <div class="topbar-nav-item ng-scope">
                                    <p class="topbar-nav-item-title ng-binding">
                                        设备管理
                                    </p>
                                    <ul>
                                        <li class="ng-scope"><a href="javascript:showRight('/WebUI/SysAdmin/DeviceManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>')"><span class="topbar-nav-item-icon icon-yunxunizhuji"></span><span class="ng-binding">设备管理</span> <span class="topbar-nav-item-short ng-binding"></span></a></li>
                                        <li class="ng-scope"><a href="javascript:showRight('/WebUI/SysAdmin/UpgradeRecord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>')"><span class="topbar-nav-item-icon icon-form"></span><span class="ng-binding">升级记录</span> <span class="topbar-nav-item-short ng-binding"></span></a></li>
                                    </ul>
                                    <div class="topbar-nav-gap ng-scope">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="topbar-info topbar-right">
                        <div class="topbar-right">
                            <!-- end ngRepeat: entry in navLinks.entrances -->
                            <div class="topbar-left ng-scope">
                                <!-- ngIf: $index != 0 -->
                                <span class="topbar-info-gap ng-scope"></span>
                                <!-- end ngIf: $index != 0 -->
                                <!-- ngIf: !entry.links -->
                                <!-- ngIf: entry.links -->
                                <%--<div class="dropdown tHHopbar-info-item ng-scope">
                                    <a href="javascript:void(0)" class="dropdown-toggle topbar-btn"><span class="ng-binding">
                                        工单服务</span><span class="icon-arrow-down"></span></a><ul class="dropdown-menu">
                                            <!-- ngRepeat: link in entry.links -->
                                            <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                                class="ng-binding">列表</span></a> </li>
                                            <!-- end ngRepeat: link in entry.links -->
                                            <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                                class="ng-binding">详细</span></a></li>
                                                <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                                class="ng-binding">新增</span></a></li>
                                            <!-- end ngRepeat: link in entry.links -->
                                        </ul>
                                </div>--%>
                                <!-- end ngIf: entry.links -->
                            </div>
                            <!-- end ngRepeat: entry in navLinks.entrances -->
                            <%--<div class="topbar-left ng-scope">
                                <!-- ngIf: $index != 0 -->
                                <span class="topbar-info-gap ng-scope"></span>
                                <!-- end ngIf: $index != 0 -->
                                <!-- ngIf: !entry.links -->
                                <div class="topbar-info-item ng-scope">
                                    <a href="javascript:void(0)" target="_blank" class="topbar-btn ng-binding">备案</a></div>
                                <!-- end ngIf: !entry.links -->
                                <!-- ngIf: entry.links -->
                            </div>--%>
                            <!-- end ngRepeat: entry in navLinks.entrances -->
                            <%--<div class="topbar-left ng-scope">
                                <!-- ngIf: $index != 0 -->
                                <span class="topbar-info-gap ng-scope"></span>
                                <!-- end ngIf: $index != 0 -->
                                <!-- ngIf: !entry.links -->
                                <!-- ngIf: entry.links -->
                                <div class="dropdown topbar-info-item ng-scope">
                                    <a href="javascript:void(0)" class="dropdown-toggle topbar-btn"><span class="ng-binding">
                                        帮助</span><span class="icon-arrow-down"></span></a>
                                    <ul class="dropdown-menu">
                                        <!-- ngRepeat: link in entry.links -->
                                        <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                            class="ng-binding">新版FAQ</span></a></li><!-- end ngRepeat: link in entry.links -->
                                        <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                            class="ng-binding">帮助中心</span></a></li><!-- end ngRepeat: link in entry.links -->
                                        <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                            class="ng-binding">文档中心</span></a></li><!-- end ngRepeat: link in entry.links -->
                                        <li class="topbar-info-btn ng-scope"><a href="javascript:void(0)" target="_blank"><span
                                            class="ng-binding">论坛</span></a></li><!-- end ngRepeat: link in entry.links -->
                                    </ul>
                                </div>
                                <!-- end ngIf: entry.links -->
                            </div>--%>
                            <!-- end ngRepeat: entry in navLinks.entrances -->
                            <div class="topbar-left">
                                <span class="topbar-info-gap"></span>
                                <div class="dropdown topbar-info-item">
                                    <a href="javascript:void(0)" class="dropdown-toggle topbar-btn"><span class="ng-binding">
                                        <%=Session["UserName"] %></span><span class="icon-arrow-down"></span></a>
                                    <ul class="dropdown-menu">
                                        <!-- ngRepeat: link in navLinks.userLink.links -->
                                        <li class="topbar-info-btn ng-scope"><a href="/Logout.aspx"><span
                                            class="ng-binding">退出</span></a></li>
                                        <!-- end ngRepeat: link in navLinks.userLink.links -->
                                    </ul>
                                </div>
                            </div>
                            <div class="topbar-qrcode topbar-left ng-scope">
                                <a href="/Logout.aspx" class="topbar-btn">安全退出</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /topbar -->
        </div>
        <!-- end ngIf: config.showTopbar -->
        <div class="viewFramework-body viewFramework-sidebar-full">
            <div class="viewFramework-sidebar">
                <!-- sidebar -->
                <div type="full" class="sidebar-content">
                    <!-- ngIf: !loadingState -->
                    <div class="sidebar-inner ng-scope">
                        <!-- ngIf: versionGreaterThan1_3_21 -->
                        <div class="sidebar-fold ng-scope icon-unfold">
                        </div>
                        <!-- end ngIf: versionGreaterThan1_3_21 -->

<%--                        <div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="用户管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">用户管理</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope" title="用户登录" src="/WebUI/SysAdmin/LxcUser_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">用户登录</span></a></li>
                                <li class="nav-item ng-scope" title="菜单分类" src="/WebUI/SysAdmin/LanMenu_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">菜单分类</span></a></li>
                                <li class="nav-item ng-scope" title="全部商品" src="/WebUI/SysAdmin/LanGoods_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">全部商品</span></a></li>
                                
                                                            
                            </ul>
                        </div>

						 <div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="林谢铖项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">林谢铖项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope" title="用户登录" src="/WebUI/SysAdmin/LxcUser_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">用户登录</span></a></li>
                                <li class="nav-item ng-scope" title="收货地址" src="/WebUI/SysAdmin/LxcAddress_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">收货地址</span></a></li>
                                <li class="nav-item ng-scope" title="提交订单" src="/WebUI/SysAdmin/LxcSubmit_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">提交订单</span></a></li>

                                <li class="nav-item ng-scope" title="商城商品" src="/WebUI/SysAdmin/LxcGoods_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">商城商品</span></a></li>
                                <li class="nav-item ng-scope" title="轮播图" src="/WebUI/SysAdmin/LxcCarousel_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">轮播图</span></a></li>



                                                            
                            </ul>
                        </div>

						<div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="兰岚星项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">兰岚星项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                               <li class="nav-item ng-scope" title="菜单分类" src="/WebUI/SysAdmin/LanMenu_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">菜单分类</span></a></li>
                                <li class="nav-item ng-scope" title="菜单明细" src="/WebUI/SysAdmin/LanSecondMenu_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">菜单明细</span></a></li>
                               <li class="nav-item ng-scope" title="全部商品" src="/WebUI/SysAdmin/LanGoods_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">全部商品</span></a></li>
                               <li class="nav-item ng-scope" title="LAN订单" src="/WebUI/SysAdmin/LanOrderList_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">LAN订单</span></a></li>
                                <li class="nav-item ng-scope" title="收货地址" src="/WebUI/SysAdmin/LanAddress_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">收货地址</span></a></li>
                                <li class="nav-item ng-scope" title="轮播图" src="/WebUI/SysAdmin/LanCarousel_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">LAN轮播图</span></a></li>
                                <li class="nav-item ng-scope" title="LAN用户" src="/WebUI/SysAdmin/LanUser_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">LAN用户</span></a></li>
                            </ul>
                        </div>

						<div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="马忠琴项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">马忠琴项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
							<li class="nav-item ng-scope" title="商城商品" src="/WebUI/SysAdmin/MzqGoods_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">商城商品</span></a></li> 
                            <li class="nav-item ng-scope" title="购物车" src="/WebUI/SysAdmin/MzqShoppingcar_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">购物车</span></a></li>
							<li class="nav-item ng-scope" title="门店活动" src="/WebUI/SysAdmin/Activity_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">门店活动</span></a></li>
                            <li class="nav-item ng-scope" title="轮播图一" src="/WebUI/SysAdmin/CarouselOne_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">轮播图一</span></a></li>	
							<li class="nav-item ng-scope" title="轮播图二" src="/WebUI/SysAdmin/CarouselTwo_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">轮播图二</span></a></li>
							<li class="nav-item ng-scope" title="用户信息表" src="/WebUI/SysAdmin/UserInfo_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">用户信息表</span></a></li>
							<li class="nav-item ng-scope" title="商品推荐" src="/WebUI/SysAdmin/GoodsRecommend_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">商品推荐</span></a></li>
							<li class="nav-item ng-scope" title="订单" src="/WebUI/SysAdmin/MzqOrder_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">订单</span></a></li>
							<li class="nav-item ng-scope" title="支付" src="/WebUI/SysAdmin/MzqPay_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">支付</span></a></li>
							<li class="nav-item ng-scope" title="签到有奖" src="/WebUI/SysAdmin/SignInprize_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">签到有奖</span></a></li>
							<li class="nav-item ng-scope" title="领劵中心" src="/WebUI/SysAdmin/SecuritiesCentre_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">领劵中心</span></a></li>						                       
                            <li class="nav-item ng-scope" title="收货地址" src="/WebUI/SysAdmin/MzqAddress_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">收货地址</span></a></li>
                            </ul>
                        </div>

                        <div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="黄乾项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">黄乾项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope" title="HUANG用户" src="/WebUI/SysAdmin/HuangUser_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">HUANG用户</span></a></li>


                                                            
                            </ul>
                        </div>--%>

                        <div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="王兆宇项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">王兆宇项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
<li class="nav-item ng-scope" title="订单管理" src="/WebUI/SysAdmin/OrderForm_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">订单管理</span></a></li>
<li class="nav-item ng-scope" title="订单明细" src="/WebUI/SysAdmin/OrderDetail_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">订单明细</span></a></li>
<li class="nav-item ng-scope" title="订单明细" src="/WebUI/SysAdmin/WangUser_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">王用户</span></a></li>
                            </ul>
                        </div>
                       
                        <div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="郭韶帆项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">郭韶帆项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                 <li class="nav-item ng-scope" title="郭用户" src="/WebUI/SysAdmin/GuoUser_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">郭用户</span></a></li>
                                 <li class="nav-item ng-scope" title="郭地址" src="/WebUI/SysAdmin/GuoAddress_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">郭地址</span></a></li>
                                 <li class="nav-item ng-scope" title="商家分类" src="/WebUI/SysAdmin/MerchantSort_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商家分类</span></a></li>
                                 <li class="nav-item ng-scope" title="商家" src="/WebUI/SysAdmin/GuoMerchant_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商家</span></a></li>
                                 <li class="nav-item ng-scope" title="商品分类" src="/WebUI/SysAdmin/GoodsSort_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商品分类</span></a></li>
                                 <li class="nav-item ng-scope" title="商品" src="/WebUI/SysAdmin/GuoGoods_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商品</span></a></li>
                            </ul>
                        </div>

                       <div class="sidebar-nav main-nav">
                            <div class="sidebar-title" title="刘庆项目">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">刘庆项目</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                 <li class="nav-item ng-scope" title="刘用户" src="/WebUI/SysAdmin/LiuUser_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">刘用户</span></a></li>
                                <li class="nav-item ng-scope" title="用户地址" src="/WebUI/SysAdmin/LiuAddress_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">用户地址</span></a></li>
                                <li class="nav-item ng-scope" title="商家分类" src="/WebUI/SysAdmin/MerchantClassify_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商家分类</span></a></li>
                               <li class="nav-item ng-scope" title="商家列表" src="/WebUI/SysAdmin/MerchantList_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商家列表</span></a></li>
                               <li class="nav-item ng-scope" title="商品分类" src="/WebUI/SysAdmin/GoodsClassify_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商品分类</span></a></li>
                               <li class="nav-item ng-scope" title="商品列表" src="/WebUI/SysAdmin/GoodsList_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">商品列表</span></a></li>

                            </ul>
                        </div>
                       
                        <div class="sidebar-nav sidebar-nav">
                            <div class="sidebar-title" title="系统设置">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">系统设置</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope" title="消息通知" src="/WebUI/SysAdmin/NewsInform_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope">
                                    <div class="nav-icon sidebar-trans"><span class="icon-form"></span></div>
                                    <span class="nav-title ng-binding">消息通知</span></a></li>

                                    <li class="nav-item ng-scope" title="后台角色" src="/WebUI/SysAdmin/SysRole_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">后台角色</span></a>
                                        



                                    </li>
                                    <li class="nav-item ng-scope" title="客户公司" src="/WebUI/SysAdmin/SysCorp_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">客户公司</span></a></li>
                                    <li class="nav-item ng-scope" title="通用配置信息" src="/WebUI/SysAdmin/SysConfig_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">通用配置信息</span></a></li>
                                    <li class="nav-item ng-scope" title="地区" src="/WebUI/SysAdmin/SysArea_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">地区</span></a></li>
                                    <li class="nav-item ng-scope" title="后台用户" src="/WebUI/SysAdmin/SysUser_List.aspx?&rnd=<%=YaohuaID.GenRandomInt()%>"><a class="ng-scope" href="javascript:void(0)"><div class="nav-icon"><span class="icon-yunxunizhuji"></span></div><span class="nav-title ng-binding">后台用户</span></a></li>
                               </ul>
                        </div>

                       

<%--                           <div class="sidebar-title" title="个人用户管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">个人用户管理</span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope" title="客户公司" src="/WebUI/SysAdmin/SysCorp_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope">
                                    <div class="nav-icon sidebar-trans"><span class="icon-form"></span></div>
                                    <span class="nav-title ng-binding">客户公司</span></a></li>
                                <li class="nav-item ng-scope" title="个人信息" src="/WebUI/SysAdmin/PeosonInfo_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope">
                                    <div class="nav-icon sidebar-trans"><span class="icon-form"></span></div>
                                    <span class="nav-title ng-binding">个人信息</span></a></li>
                                <li class="nav-item ng-scope" title="部门" src="/WebUI/SysAdmin/SysDepartment_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope">
                                    <div class="nav-icon sidebar-trans"><span class="icon-form"></span></div>
                                    <span class="nav-title ng-binding">部门</span></a></li>
                                <li class="nav-item ng-scope" title="分公司管理" src="/WebUI/SysAdmin/CompanyManagement_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope">
                                    <div class="nav-icon sidebar-trans"><span class="icon-form"></span></div>
                                    <span class="nav-title ng-binding">分公司管理</span></a></li>
                            </ul>
                        </div>--%>

                       <%-- <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="权限管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">权限管理</span> <span class="sidebar-manage ng-scope">
                                            <a class="icon-setup ng-isolate-scope"></a></span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <!-- ngRepeat: item in serviceList -->
                                <li class="nav-item ng-scope" title="后台用户" src="/WebUI/SysAdmin/SysUser_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-account-2"></span>
                                    </div>
                                    <span class="nav-title ng-binding">后台用户</span>
                                </a></li>
                                <li class="nav-item ng-scope" title="后台角色" src="/WebUI/SysAdmin/SysRole_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-account"></span>
                                    </div>
                                    <span class="nav-title ng-binding">后台角色</span>
                                </a></li>
                                <li class="nav-item ng-scope"    title="学生管理" src="/WebUI/SysAdmin/Student_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">学生管理</span></a></li>
                            </ul>
                        </div>

                        <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="通用配置信息">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">通用配置信息</span> <span class="sidebar-manage ng-scope">
                                            <a class="icon-setup ng-isolate-scope"></a></span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <!-- ngRepeat: item in serviceList -->
                                <li class="nav-item ng-scope" title="系统菜单" src="/WebUI/SysAdmin/SysMenu_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-remove-2"></span>
                                    </div>
                                    <span class="nav-title ng-binding">系统菜单</span>
                                </a></li>
                                <li class="nav-item ng-scope" title="数据回收站" src="/WebUI/SysAdmin/SysDelete_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-remove-2"></span>
                                    </div>
                                    <span class="nav-title ng-binding">数据回收站</span>
                                </a></li>
                                <li class="nav-item ng-scope" title="通用配置信息" src="/WebUI/SysAdmin/SysConfig_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-threshold"></span>
                                    </div>
                                    <span class="nav-title ng-binding">通用配置信息</span>
                                </a></li>
                            </ul>
                        </div>--%>

                    </div>
                    <!-- end ngIf: !loadingState -->
                    <!-- ngIf: loadingState -->
                </div>
                <!-- /sidebar -->
            </div>
            <!--二级菜单展开时 <div class="viewFramework-product viewFramework-product-col-1"> -->
            <div class="viewFramework-product">
                <div style="display: none;" class="viewFramework-product-navbar ng-scope">
                    <!-- product nav -->
                    <div class="product-nav-stage ng-scope product-nav-stage-main">
                        <div class="product-nav-scene product-nav-main-scene">
                            <div class="product-nav-title ng-binding">
                                工单系统
                            </div>
                            <div class="product-nav-list">
                                <ul>
                                    <li class="active" src="SysAdminHomePage.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    首页
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="../WebUI/SysAdmin/StudentInfo_List.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    列表
                                                </div>
                                                <div class="nav-extend">
                                                    <span>
                                                        <span class="total-unread-count ng-scope ng-binding">1</span></span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="../WebUI/SysAdmin/TeacherInfo_List.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    图片列表
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="detail2.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    详细
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="../WebUI/SysAdmin/StudentInfo_Modify.aspx?id=8458KTQE006670Y0">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    编辑
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="upload.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    导入
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="product-nav-scene product-nav-sub-scene">
                            <div class="product-nav-title">
                            </div>
                            <div class="product-nav-list">
                                <ul>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end ngIf: config.productNavBar != 'disabled' -->
                <!-- product nav collapse-->
                <!-- ngIf: config.productNavBar != 'disabled' -->
                <div style="display: none;" class="viewFramework-product-navbar-collapse ng-scope">
                    <div class="product-navbar-collapse-inner">
                        <div class="product-navbar-collapse-bg">
                        </div>
                        <div class="product-navbar-collapse">
                            <span class="icon-collapse-left"></span><span class="icon-collapse-right"></span>
                        </div>
                    </div>
                </div>
                <!-- end ngIf: config.productNavBar != 'disabled' -->
                <!-- /product nav collapse-->
                <div class="viewFramework-product-body">
                    <iframe id="mainFrame" frameborder="0" runat="server" src="SysAdminHomePage.aspx" style="height: 100%; width: 100%; border: 0px;"></iframe>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

