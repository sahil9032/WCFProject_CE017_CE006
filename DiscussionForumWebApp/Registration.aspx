﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DiscussionForumWebApp.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server" class="login-form">
        <div class="txtb">
            <asp:Label ID="Label1" runat="server" Text="Enter unique user name: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>

        <div class="txtb">
            <asp:Label ID="Label2" runat="server" Text="Enter unique email: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div class="txtb">
            <asp:Label ID="Label3" runat="server" Text="Enter password: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="txtb">
            <asp:Label ID="Label4" runat="server" Text="Enter confirm password: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button class="logbtn" ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    </form>
</body>
</html>
