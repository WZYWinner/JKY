<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceManager.aspx.cs" Inherits="UI.DEMO.ServiceManager" %>

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
        .viewFramework-sidebar .sidebar-nav ul{background:#485368;}
        div.nav-icon.sidebar-trans, .nav-icon{padding-top: 13px;}
        .sidebar-title-icon, .sidebar-title-icon span{line-height: 45px; }
        [ng\:cloak],[ng-cloak],[data-ng-cloak],[x-ng-cloak],.ng-cloak,.x-ng-cloak,.ng-hide{display:none !important;}
        ng\:form{display:block;}
        .ng-animate-start{border-spacing:1px 1px;-ms-zoom:1.0001;}
        .ng-animate-active{border-spacing:0px 0px;-ms-zoom:1;}
        .ShowRed{color:#ff9900;}
        .aliyun-console-topbar .topbar-logo{width:auto;padding:0px 10px;}
        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-panel.android_panel{width:400px;}
        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-panel{width:150px;}
        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-image{width:120px;}
        .aliyun-console-topbar .topbar-qrcode .topbar-qrcode-image.android_img{margin-right:5px;float:left;}
        .img_phone{width:120px;height:120px;float:left;}
        .aliyun-console-topbar .topbar-qrcode .android_panel .topbar-qrcode-title{float:left;width:126px;}
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
                            class="">建科院检测系统</span></a>
                        <!-- ngIf: !versionGreaterThan1_3_21 -->
                        <!-- ngIf: versionGreaterThan1_3_21 -->
                        <a href="javascript:showRight('ServiceManagerHomePage.aspx')" class="topbar-home-link topbar-btn topbar-left ng-scope">
                            <span class="ng-binding">业务员经理</span></a><!-- end ngIf: versionGreaterThan1_3_21 --></div>
                    <div class="topbar-nav topbar-left dropdown">
                        <a href="javascript:void(0)" class="dropdown-toggle topbar-btn topbar-nav-btn"><span
                            class="ng-binding">快捷操作</span><span class="icon-arrow-down"></span></a>
                        <div class="dropdown-menu topbar-nav-list topbar-clearfix">
                            <div class="topbar-nav-col ng-scope" >
                                <div class="topbar-nav-item ng-scope">
                                    <p class="topbar-nav-item-title ng-binding">
                                        设备管理</p>
                                    <ul>
                                        <li class="ng-scope"><a href="javascript:showRight('/WebUI/ServiceManager/DeviceManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>')"><span class="topbar-nav-item-icon icon-yunxunizhuji">
                                                </span><span class="ng-binding">设备管理</span> <span class="topbar-nav-item-short ng-binding">
                                                </span></a></li>
                                        <li class="ng-scope"><a href="javascript:showRight('/WebUI/ServiceManager/UpgradeRecord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>')"><span class="topbar-nav-item-icon icon-form">
                                                </span><span class="ng-binding">升级记录</span> <span class="topbar-nav-item-short ng-binding">
                                                </span></a></li>
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
                                <%--<div class="dropdown topbar-info-item ng-scope">
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
                                            class="ng-binding">退出</span></a></li><!-- end ngRepeat: link in navLinks.userLink.links -->
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
                        
                        
                         <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="合同管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">合同管理</span> 
                                </div>
                             </div>
                                <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope"    title="合同信息审核" src="/WebUI/ServiceManager/ContractInfoAudit_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">合同信息审核</span></a></li>
                             <li class="nav-item ng-scope"    title="立项单审核" src="/WebUI/ServiceManager/BuildItemBillAudit_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">立项单审核</span></a></li>
                            <li class="nav-item ng-scope"    title="简易合同审核" src="/WebUI/ServiceManager/SimpleContractAudit_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">简易合同审核</span></a></li>
                                </ul>
                        </div>

                         <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="收费管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">收费管理</span> 
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope"    title="收费单" src="/WebUI/FinanceManager/ChargeBill_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">收费单</span></a></li>
                                <li class="nav-item ng-scope"    title="财务收费" src="/WebUI/FinanceManager/FinanceCharge_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">财务收费</span></a></li>
                                <li class="nav-item ng-scope"    title="实验通知单" src="/WebUI/FinanceManager/TestInformBill_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">实验通知单</span></a></li>
                                <li class="nav-item ng-scope"    title="实验收费" src="/WebUI/FinanceManager/TestCharge_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">实验收费</span></a></li>
                                <li class="nav-item ng-scope"    title="费用汇总" src="/WebUI/FinanceManager/CostGather_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">费用汇总</span></a></li>
                            </ul>
                        </div>
                        <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="客户账户管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">客户账户管理</span> 
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope"    title="客户管理" src="/WebUI/FinanceManager/CustManage_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">客户管理</span></a></li>
                                <li class="nav-item ng-scope"    title="客户账户" src="/WebUI/FinanceManager/CustAccount_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">客户账户</span></a></li>
                                <li class="nav-item ng-scope"    title="账户结算审核" src="/WebUI/FinanceManager/AccountSettlementAudit_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">账户结算审核</span></a></li>
                                    </ul>
                        </div>
                        <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="报告管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">报告管理</span> 
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope"    title="检测报告" src="/WebUI/FinanceManager/DetectRepord_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">检测报告</span></a></li>
                                 </ul>
                        </div>
                         <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="消息管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">消息管理</span> 
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope"    title="消息通知" src="/WebUI/FinanceManager/NewsInform_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">消息通知</span></a></li>
                                </ul>
                        </div>
                        <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="个人用户管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">个人用户管理</span> 
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <li class="nav-item ng-scope"    title="个人信息" src="/WebUI/FinanceManager/PeosonInfo_List.aspx?rnd=<%=YaohuaID.GenRandomInt()%>"><a href="javascript:void(0)" class="sidebar-trans ng-scope"><div class="nav-icon sidebar-trans"><span class="icon-form"></span> </div><span class="nav-title ng-binding">个人信息</span></a></li>
                                 </ul>
                        </div>
                          <div class="sidebar-nav sidebar-nav-fold">
                            <div class="sidebar-title" title="权限管理">
                                <div class="sidebar-title-inner ng-scope">
                                    <span class="sidebar-title-icon"><span class="icon-arrow-down"></span></span><span
                                        class="sidebar-title-text ng-binding">权限管理</span> <span class="sidebar-manage ng-scope">
                                            <a class="icon-setup ng-isolate-scope"></a></span>
                                </div>
                            </div>
                            <ul style="" class="entrance-nav sidebar-trans">
                                <!-- ngRepeat: item in serviceList -->
                                <li class="nav-item ng-scope" title="后台用户" src="/WebUI/ServiceManager/SysUser_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-account-2"></span>
                                    </div>
                                    <span class="nav-title ng-binding">后台用户</span>
                                </a></li>
                                <li class="nav-item ng-scope" title="后台角色" src="/WebUI/ServiceManager/SysRole_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-account"></span>
                                    </div>
                                    <span class="nav-title ng-binding">后台角色</span>
                                </a></li>
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
                                <li class="nav-item ng-scope" title="系统菜单" src="/WebUI/ServiceManager/SysMenu_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-remove-2"></span>
                                    </div>
                                    <span class="nav-title ng-binding">系统菜单</span>
                                </a></li>
                                <li class="nav-item ng-scope" title="数据回收站" src="/WebUI/ServiceManager/SysDelete_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-remove-2"></span>
                                    </div>
                                    <span class="nav-title ng-binding">数据回收站</span>
                                </a></li>
                                <li class="nav-item ng-scope" title="通用配置信息" src="/WebUI/ServiceManager/SysConfig_List.aspx"><a class="ng-scope" href="javascript:void(0)">
                                    <div class="nav-icon">
                                        <span class="icon-threshold"></span>
                                    </div>
                                    <span class="nav-title ng-binding">通用配置信息</span>
                                </a></li>
                            </ul>
                        </div>

                    </div>
                    <!-- end ngIf: !loadingState -->
                    <!-- ngIf: loadingState -->
                </div>
                <!-- /sidebar -->
            </div>
            <!--二级菜单展开时 <div class="viewFramework-product viewFramework-product-col-1"> -->
            <div class="viewFramework-product">
                <div  style="display:none;" class="viewFramework-product-navbar ng-scope">
                    <!-- product nav -->
                    <div class="product-nav-stage ng-scope product-nav-stage-main">
                        <div class="product-nav-scene product-nav-main-scene">
                            <div class="product-nav-title ng-binding">
                                工单系统</div>
                            <div class="product-nav-list">
                                <ul>
                                    <li class="active" src="ServiceManagerHomePage.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    首页</div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="../WebUI/ServiceManager/StudentInfo_List.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    列表</div>
                                                <div class="nav-extend">
                                                    <span>
                                                        <span class="total-unread-count ng-scope ng-binding">1</span></span></div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="../WebUI/ServiceManager/TeacherInfo_List.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    图片列表</div>
                                            </a>
                                        </div>
                                    </li>
                                    <li src="detail2.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    详细</div>
                                            </a>
                                        </div>
                                    </li>
                                     <li  src="../WebUI/ServiceManager/StudentInfo_Modify.aspx?id=8458KTQE006670Y0">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    编辑</div>
                                            </a>
                                        </div>
                                    </li>
                                    <li  src="upload.aspx">
                                        <div class="ng-isolate-scope">
                                            <a class="ng-scope" href="javascript:void(0)">
                                                <div class="nav-icon">
                                                </div>
                                                <div class="nav-title ng-binding">
                                                    导入</div>
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
                <div  style="display:none;" class="viewFramework-product-navbar-collapse ng-scope">
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
                    <iframe id="mainFrame" frameborder="0" runat="server" src="ServiceManagerHomePage.aspx" style="height: 100%; width: 100%;
                        border:0px;"></iframe>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

