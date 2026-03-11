<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3_Calderon.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .img-articulo {
            height: 220px;
            object-fit: contain;
            padding: 10px;
            background-color: white;
        }

        .card-articulo {
            max-width: 300px;
        }
    </style>
    <h1>Favoritos</h1>
    <h2>Mis Favoritos</h2>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%foreach (Dominio.Articulos articulo in ListaArticulos)
            { %>
        <div class="col">
            <div class="card-articulo h-100">
                <img src="<%:articulo.UrlImagen %>" class="card-img-top img-articulo" alt="Imagen del producto">

                <div class="card-body">

                    <div class="row">
                        <div class="col-6">
                            <h5 class="card-title"><%:articulo.Nombre %></h5>
                            <p class="card-text"><%:articulo.Descripcion %></p>
                            <h6 class="card-title">$ <%:articulo.Precio %></h6>
                        </div>
                    </div>

                    <div class="row mt-3">
                        <div class="col-12 d-flex justify-content-between align-items-center">
                            <a href='Favoritos.aspx?id=<%: articulo.Id %>' class="btn btn-outline-danger btn-sm">Quitar Favorito</a>
                            <a href='DetalleArticulo.aspx?id=<%: articulo.Id %>' class="btn btn-primary btn-sm">Ver Detalle</a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
