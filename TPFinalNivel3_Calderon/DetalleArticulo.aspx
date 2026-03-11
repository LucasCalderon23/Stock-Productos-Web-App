<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPFinalNivel3_Calderon.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row align-items-center">
            <div class="col-md-5 text-center">
                <asp:Image ID="imgImagenDetalle" runat="server" CssClass="img-fluid rounded shadow" Style="max-height: 400px;" />
            </div>
            <div class="col-md-7">
                <h2 class="mb-3">
                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                </h2>

                <h5 class="text-secondary mb-3">Marca:
                    <asp:Label ID="lblMarca" runat="server"></asp:Label>
                </h5>

                <p class="mb-4">
                    <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                </p>

                <h3 class="text-success mb-4">
                    <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                </h3>

                <asp:Button Text="Volver" runat="server" ID="btnVolver" CssClass="btn btn-outline-light" OnClick="btnVolver_Click" />
                <asp:Button ID="btnFavorito" runat="server" Text="Agregar a Favoritos ❤️" CssClass="btn btn-light me-2" OnClick="btnFavorito_Click"/>

            </div>

        </div>
    </div>
</asp:Content>
