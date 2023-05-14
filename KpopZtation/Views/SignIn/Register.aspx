<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtation.Views.SignIn.Register" UnobtrusiveValidationMode="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .input_field{
            display:flex;
            flex-direction:column;
        }

        .register_page{
            width:100vw;

            display:flex;
            align-items:center;
            justify-content:center;
        }

        .register_inputField_container{
            display:flex;
            align-items:center;
            justify-content:center;
            flex-direction:column;

            width: 90%;

        }

        .input_field{
            display:flex;
            flex-direction:column;
        }

        .registerBtn{
            margin-top: 1rem;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="register_page" runat="server" CssClass="register_page">
        <asp:Panel ID="register_container" runat="server" CssClass="register_inputField_container">
            <h2>Register</h2>

            <asp:Panel ID="register_inputField_container" runat="server" CssClass="register_inputField_container">
                <asp:Panel ID="register_NameInput" runat="server" CssClass="input_field">
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
                    <asp:Label ID="NameError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="register_EmailInput" runat="server" CssClass="input_field">
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
                    <asp:Label ID="EmailError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="register_GenderInput" runat="server" CssClass="input_field input_field_gender">
                    <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                    <div>
                        <asp:RadioButton ID="GenderMaleBtn" runat="server" GroupName="Gender"/>
                         <asp:Label ID="Label7" runat="server" Text="Male"></asp:Label>
                    </div>
                    <div>
                        <asp:RadioButton ID="GenderFemaleBtn" runat="server" GroupName="Gender"/>
                         <asp:Label ID="Label8" runat="server" Text="Female" ></asp:Label>
                    </div>
                    <asp:Label ID="GenderError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="register_AddressInput" runat="server" CssClass="input_field">
                    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="AddressTxt" runat="server"></asp:TextBox>
                    <asp:Label ID="AddressError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="register_PasswordInput" runat="server" CssClass="input_field">
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="PasswordError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>
            </asp:Panel>

            <asp:Label ID="SuccessLbl" runat="server" ForeColor="Green"></asp:Label>
            <asp:Button ID="RegisterBtn" CssClass="btn btn-primary registerBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click"/>
  

        </asp:Panel>
    </asp:Panel>
</asp:Content>
