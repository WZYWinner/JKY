<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DICOS.PRINT.ADMIN.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="_css/login.css" rel="stylesheet" />
    <script src="_js/jquery-1.8.2.js"></script>
        <script type="text/javascript">
        //读取cookies 
        function getCookie(name) {
            var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
            arr = document.cookie.match(reg);
            return arr ? unescape(arr[2]) : null;
        }
        $(function () {

            // 复选框单击事件
            $("#cb_autoLogin").click(function () {
                if ($(this).attr("checked") == "checked") {
                    $("#cb_rememberPsd").attr("checked", "checked");
                    $("#cb_rememberPsd").attr("disabled", "disabled");
                }
                else {
                    $("#cb_rememberPsd").removeAttr("disabled");
                }
            });
            $("#cb_rememberPsd").click(function () {
                if ($(this).attr("checked") != "checked") {
                    $("#cb_autoLogin").removeAttr("checked");
                }
            });


            var psd = getCookie("psd");
            if (psd != null) {
                var name = getCookie("userName");
                $(".userName").val(name);
                $("#cb_rememberPsd").attr("checked", "checked");
                $(".hd_password").val(psd);
                $(".password").val("********");
                var autoLogin = getCookie("autoLogin");
                if (autoLogin != null) {
                    $("#cb_autoLogin").attr("checked", "checked");
                    $("#btn_Login").click();
                }
            }

            if ($("#cb_autoLogin").attr("checked") == "checked") {
                $("#cb_rememberPsd").attr("checked", "checked");
            }

        });
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login">
 
        <div class="login_box">
            <div runat="server" id="divErrMsg" visible="false" class="wrong">
                <h4>
                    <asp:Label ID="lbErrMsg" runat="server" Text="Label"></asp:Label>
                </h4>
            </div>
        <div class="login-wrap">
            <input type="text" id="txtUserName" runat="server" placeholder="账号"  class="name userName form-control" value="" />
            <input type="password" id="txtPassword" runat="server" placeholder="密码" class="password form-control" value="" />
            <input type="hidden" id="hd_password" runat="server" class="hd_password" value="" />
            <input type="text" id="txt_code" placeholder="验证码" runat="server" class="name input_code form-control" value="" style="width:160px;" />
            <img id="imgValidate" alt="验证码" title="看不清，换一个" src="/WebHandler/VCode.ashx" onclick="javascript:this.src='/WebHandler/VCode.ashx?'+new Date()" style="cursor:pointer" />
        
            <p>
                <asp:CheckBox ID="cb_rememberPsd" runat="server" Text="记住密码" CssClass="ck_1" />
                <asp:CheckBox ID="cb_autoLogin" runat="server" Text="自动登录" Class="23pxck_2" />
            </p>
            <asp:Button ID="btn_Login" runat="server" Text="登录" CssClass="btn btn-lg btn-login btn-block" OnClick="btn_Login_Click" />
        </div>
        </div>
         
    </div>
        <div>
             <p>
                 <h3>帐号：admin       密码：admin</h3>
             </p>
         </div>
    </form>
</body>
</html>
