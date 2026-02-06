<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Calderon.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-articulo {
            border: 1px solid #e0e0e0;
            border-radius: 12px;
            transition: transform 0.2s ease, box-shadow 0.2s ease;
            background: #fff;
        }

            .card-articulo:hover {
                transform: translateY(-6px);
                box-shadow: 0 10px 25px rgba(0,0,0,0.15);
            }

            .card-articulo img {
                height: 220px;
                object-fit: contain;
                padding: 10px;
                background: #fff;
            }

            .card-articulo .card-body {
                padding: 0.8rem;
            }

            .card-articulo .card-title {
                font-size: 1rem;
                font-weight: 600;
            }

            .card-articulo .precio {
                font-size: 1.1rem;
                font-weight: bold;
                color: #198754;
            }
    </style>
    <div class="col-4">
        <label for="txtFiltro" class="form-label">Filtro rápido:</label>

        <div class="input-group">
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" />
        </div>
    </div>
    <hr />

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%foreach (Dominio.Articulos articulo in ListaArticulos)
            { %>
        <div class="col">
            <div class="card-articulo h-100">
                <img src="<%:articulo.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:articulo.Nombre %></h5>
                    <p class="card-text"><%:articulo.Descripcion %> canciones</p>
                    <h6 class="card-title"><%:articulo.Precio %></h6>
                </div>
            </div>
        </div>
        <%}%>
    </div>
</asp:Content>
