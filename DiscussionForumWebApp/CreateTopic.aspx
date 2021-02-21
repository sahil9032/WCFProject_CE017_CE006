<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTopic.aspx.cs" Inherits="DiscussionForumWebApp.CreateTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        * {
            margin: 0;
            padding: 0;
            text-decoration: none;
            font-family: apple-system, BlinkMacSystemFont, sans-serif;
            box-sizing: border-box;
        }

        body {
            min-height: 100vh;
            background-image: linear-gradient(120deg,#f0b501,#8e44ad);
        }

        .login-form {
            width: 360px;
            background: #f1f1f1;
            height: 580px;
            padding: 80px 40px;
            border-radius: 10px;
            position: absolute;
            left: 50%;
            top: 50%;
            transform: translate(-50%,-50%);
        }

            .login-form h1 {
                text-align: center;
                margin-bottom: 60px;
            }

        .txtb {
            border-bottom: 2px solid #adadad;
            position: relative;
            margin: 30px 0;
        }

            .txtb input {
                font-size: 15px;
                color: #333;
                border: none;
                width: 100%;
                outline: none;
                background: none;
                padding: 0 5px;
                height: 40px;
            }

            .txtb span::before {
                content: attr(data-placeholder);
                position: absolute;
                top: 50%;
                left: 5px;
                color: #adadad;
                transform: translateY(-50%);
                z-index: -1;
                transition: .5s;
            }

            .txtb span::after {
                content: '';
                position: absolute;
                width: 0%;
                height: 2px;
                background: linear-gradient(120deg,#f0b501,#8e44ad);
                transition: .5s;
            }

        .focus + span::before {
            top: -5px;
        }

        .focus + span::after {
            width: 100%;
        }

        .logbtn {
            display: block;
            width: 100%;
            height: 50px;
            border: none;
            background: linear-gradient(120deg,#f0b501,#8e44ad,#f0b501);
            background-size: 200%;
            color: #fff;
            outline: none;
            cursor: pointer;
            transition: .5s;
        }

            .logbtn:hover {
                background-position: right;
            }

        .bottom-text {
            margin-top: 60px;
            text-align: center;
            font-size: 13px;
        }
    </style>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lora" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Ubuntu" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="assets/css/styles.min.css" />
    <title></title>
    <script>
        function OnClick(Id) {
            window.location.href = "/Topic.aspx?Id=" + Id;
        }
    </script>
</head>
<body>
    <nav class="navbar navbar-dark navbar-expand-md bg-primary">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">Discussion Forum</a>
            <button data-toggle="collapse" class="navbar-toggler" data-target="#navcol-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-end" id="navcol-1">
                <ul class="nav navbar-nav">
                    <li class="nav-item"><a class="nav-link active" href="/TopicIndex.aspx">Home</a></li>
                    <li class="nav-item"><a class="nav-link" href="/CreateTopic.aspx">Create Topic</a></li>
                    <li class="nav-item"><a class="nav-link" href="/Logout.aspx">Log out</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <form id="form1" runat="server" class="login-form">
        <div class="txtb">
            <asp:Label ID="Label1" runat="server" Text="Topic Name: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div class="txtb">
            <asp:Label ID="Label2" runat="server" Text="Topic Description: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="logbtn" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/script.min.js"></script>
</body>
</html>
