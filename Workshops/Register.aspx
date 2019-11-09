<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="form-group">
            <asp:Label ID="FNamelbl" runat="server" Text="First name"></asp:Label>
            <div class="row">
                <asp:TextBox CssClass="form-control col" ID="FName" placeholder="First name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameRequired" CssClass="col" runat="server" ErrorMessage="You must provide first name" ControlToValidate="FName" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Last name" runat="server" />
            <div class="row">
                <asp:TextBox ID="LName" CssClass="form-control col" placeholder="Last name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="LastNameRequired" CssClass="col" runat="server" ErrorMessage="You must provide last name" ControlToValidate="LName" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Choose your country" runat="server" />
            <div class="row">
                <asp:DropDownList ID="Country" CssClass="form-control col" runat="server" DataTextField="Country" DataValueField="Country" OnSelectedIndexChanged="Country_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:CompareValidator ID="CountryRequired" runat="server" CssClass="col" ControlToValidate="Country" ErrorMessage="You must select your country" Operator="NotEqual" Display="Dynamic" ValueToCompare="choose"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group" id="chooseState" runat="server">
            <asp:Label Text="Choose your state" runat="server" />
            <div class="row">
                <asp:DropDownList ID="State" CssClass="form-control col" runat="server" DataTextField="MyCode" DataValueField="MyCode"></asp:DropDownList>
                <asp:CompareValidator ID="StateRequired" runat="server" CssClass="col" ControlToValidate="State" ErrorMessage="You must choose your state" Operator="NotEqual" Display="Dynamic" ValueToCompare="choose"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="PhoneChoose" runat="server" Text="Please choose your phone code:" Visible="false"></asp:Label>
            <asp:RadioButtonList ID="PhoneCodesList" runat="server" Visible="False"></asp:RadioButtonList>
            <asp:Label ID="EnterPhone" runat="server" Text="Phone number"></asp:Label>
            <div class="row">
                <asp:TextBox ReadOnly="true" CssClass="form-control-plaintext col-1" Visible="false" ID="PhoneCode" runat="server" Text=""></asp:TextBox><asp:TextBox ID="Phone" CssClass="form-control col" placeholder="Phone number" runat="server" TextMode="Phone"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PhoneNumRequired" runat="server" ControlToValidate="Phone" CssClass="col" Display="Dynamic" ErrorMessage="You must provide phone number"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Email address" runat="server" />
            <div class="row">
                <asp:TextBox ID="Email" CssClass="form-control col" placeholder="Email address" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" CssClass="col" runat="server" ErrorMessage="You must provide email address" ControlToValidate="Email" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Password" runat="server" />
            <div class="row">
                <asp:TextBox ID="Password" CssClass="form-control col" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" CssClass="col" runat="server" ErrorMessage="You must provide password" ControlToValidate="Password" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Password" CssClass="col" Display="Dynamic" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
            </div>
        </div>
        <asp:Button ID="RegisterBtn" CssClass="btn btn-primary btn-block" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
    </div>
</asp:Content>

