<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="DiscussionForumWebApp.Topic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <li class="nav-item"><a class="nav-link" href="/TopicIndex.aspx">Home</a></li>
                    <li class="nav-item"><a class="nav-link" href="/CreateTopic.aspx">Create Topic</a></li>
                    <li class="nav-item"><a class="nav-link" href="/Logout.aspx">Log out</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="article-clean">
        <div class="container">
            <div class="row">
                <div class="col-lg-10 col-xl-8 offset-lg-1 offset-xl-2">
                    <div class="intro">
                        <h1 class="text-center">
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </h1>
                        <p class="text-center">
                            <span class="by">
                                <asp:Label ID="Label5" runat="server"></asp:Label></span>
                        </p>
                        <h2>
                            <asp:Label ID="Label4" runat="server" Font-Bold="true"></asp:Label>
                        </h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <% foreach (var i in topicPage.comments)
            { %>
        <div class="row">
            <div class="col-lg-10 col-xl-8 offset-lg-1 offset-xl-2">
                <ul>
                    <li class="list-group-item"><%= i.Comment %>
                        <div class="text-right"><sub>By <%= i.Author %> at <%= i.Timestamp %></sub></div>
                    </li>
                </ul>
            </div>
        </div>
        <% } %>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-lg-10 col-xl-8 offset-lg-1 offset-xl-2">
                <form runat="server">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Add Comment: "></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
                        <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="footer-basic">
        <footer>
            <div class="social">
                <a href="#">
                    <i class="icon ion-social-instagram"></i></a><a href="#"><i class="icon ion-social-snapchat"></i></a><a href="#"><i class="icon ion-social-twitter"></i></a><a href="#"><i class="icon ion-social-facebook"></i>
                    </a>
            </div>
            <ul class="list-inline">
                <li class="list-inline-item"><a href="/TopicIndex.aspx">Home</a></li>
            </ul>
            <p class="copyright">Discussion Forum © 2021</p>
        </footer>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/script.min.js"></script>
</body>
</html>
