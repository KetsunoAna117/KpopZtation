<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="KpopZtation.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Update Profile</h3>
    <div class="updateProfile_body d-flex mt-3">
        <div class="card me-4" style="width: 18rem;">
              <ul class="list-group list-group-flush">
                <li class="list-group-item">
                    <div class="d-flex justify-content-between">
                        <h5 class="card-title">Name</h5>
                        <asp:Label ID="cardName" runat="server" CssClass="card-title"></asp:Label>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="d-flex justify-content-between align-content-center">
                        <p class="card-text">Email</p>
                        <asp:Label ID="cardEmail" runat="server" CssClass="card-subtitle mb-2 text-body"></asp:Label>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="d-flex justify-content-between align-content-center">
                        <p class="card-text">Gender</p>
                        <asp:Label ID="cardGender" runat="server" CssClass="card-text"></asp:Label>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="d-flex justify-content-between align-content-center">
                        <p class="card-text">Address</p>
                        <asp:Label ID="cardAddress" runat="server" CssClass="card-text"></asp:Label>
                    </div>
                </li>
              </ul>
        </div>
    
        <div>
            <div class="input-group input-group-sm mb-3">
                <span class="input-group-text">Name</span>
                <asp:TextBox ID="NameTxt" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="NameError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="input-group input-group-sm mb-3">
                <span class="input-group-text">Email</span>
                <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="EmailError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label5" runat="server" Text="Gender" ></asp:Label>
                <div class="form-check">
                    <asp:RadioButton ID="GenderMaleBtn" runat="server" GroupName="Gender" />
                    <asp:Label ID="Label7" runat="server" Text="Male" CssClass="form-check-label"></asp:Label>
                </div>
                <div class="form-check">
                    <asp:RadioButton ID="GenderFemaleBtn" runat="server" GroupName="Gender" />
                    <asp:Label ID="Label1" runat="server" Text="Female" CssClass="form-check-label"></asp:Label>
                </div>
                <asp:Label ID="GenderError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="input-group input-group-sm mb-3">
                <span class="input-group-text">Address</span>
                <asp:TextBox ID="AddressTxt" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="AddressError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="input-group input-group-sm mb-3">
                <span class="input-group-text">Password</span>
                <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="PasswordError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <asp:Button ID="UpdateBtn" CssClass="btn btn-success" runat="server" Text="Update Account Data" OnClick="UpdateBtn_Click" />
        </div>
</div>
</asp:Content>
