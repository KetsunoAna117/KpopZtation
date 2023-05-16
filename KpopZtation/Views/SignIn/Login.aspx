<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZtation.Views.SignIn.Login" UnobtrusiveValidationMode="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .login_page{
            width:100vw;
            height:50vh;

            display:flex;
            align-items:center;
            justify-content:center;
        }

        .login_inputField_container{
            display:flex;
            align-items:center;
            justify-content:center;
            flex-direction:column;

            width: 90%;

        }

        .loginBtn{
            margin-top: 2rem;
        }

        .input_field{
            display:flex;
            flex-direction:column;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="login_page" runat="server" CssClass="login_page">
        <asp:Panel ID="login_container" runat="server" CssClass="login_inputField_container ">
            <h2>Login</h2>

            <asp:Panel ID="login_inputField_container" runat="server" CssClass="login_inputField_container">
                <asp:Panel ID="login_EmailInput" runat="server" CssClass="input_field">
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
                    <asp:Label ID="EmailError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="login_PasswordInput" runat="server" CssClass="input_field">
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="PasswordError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="login_RememberMe" runat="server" CssClass="input_field">
                    <div>
                        <asp:CheckBox ID="CheckBoxRememberMe" runat="server" />
                        <asp:Label ID="Label10" runat="server" Text="Remember me"></asp:Label>
                    </div>
                </asp:Panel>
            </asp:Panel>

            <asp:Label ID="ErrorLogin" runat="server" ForeColor="Red"></asp:Label>
            <asp:Button CssClass="btn btn-primary loginBtn" ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click"/>

        </asp:Panel>
    </asp:Panel>

</asp:Content>
