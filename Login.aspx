<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hotel.WebForm1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>计科1班 32021010048 李圣贤 酒店预订管理系统</title>
    <link rel="stylesheet" href="Assets/Libraries/Bootstrap/css/bootstrap.min.css" />
    <style>
        /*背景图片*/
        body{
            background-image:url(../Assets/Images/hotel22.jpg);
            /*background-image:url(../Assets/Images/hotel4.jpg);*/
            /*background-image:url(../Assets/Images/hotel22.webp);*/
            background-size:cover;
        }
        /*样式透明度*/
        .container-fluid{
            opacity:0.9;
        }
    </style>
</head>
<body> 
       <!-- 网页中央文字 -->
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
        <div class="row" style="height:200px"></div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 bg-light rounded-3">
                <h1 class="text-text-success text-center">欢迎登录酒店预订管理系统</h1>
                <form>
  <div class="mb-3">
       <!-- 账号密码 -->
    <label for="UserTb" class="form-label">账号名</label>
    <input type="text" class="form-control" id="UserTb" runat="server" >
  </div>
  <div class="mb-3">
    <label for="PasswordTb" class="form-label">密码</label>
    <input type="password" class="form-control" id="PasswordTb" runat="server" >
  </div>
  <!-- label选择管理员或用户 -->
  <div class="mb-3">
      <label id="ErrMsg" class="text-danger" runat="server"></label>
    <input type="radio" id="AdminCb" runat="server" name="Role"><label class="text-success">管理员</label>
    <input type="radio" id="UserCb" runat="server" name="Role"><label class="text-success">用户</label>

  </div>
                    <div class="d-grid">       
                        <asp:Button ID="LoginBtn" runat="server" Text="登录" class="btn btn-success btn-block" OnClick="LoginBtn_Click" />
                    </div>
                    <br />
                    <div class="d-grid">       
                        <asp:Button ID="Button1" runat="server" Text="注册" class="btn btn-success btn-block" OnClick="signup_Click" />
                    </div>
                    <br />
</form>
            </div>
            <div class="col-md-4"></div>
        </div>
        
    </div>
        </div>
    </form>
</body>
</html>
