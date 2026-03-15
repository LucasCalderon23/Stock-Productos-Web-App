<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3_Calderon.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .validaciones {
            color: red;
            font-size: 12px;
        }
    </style>
    <div class="row">
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Email invalido" ControlToValidate="txtEmail" CssClass="validaciones"
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtPass" runat="server" CssClass="validaciones" />
            </div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
