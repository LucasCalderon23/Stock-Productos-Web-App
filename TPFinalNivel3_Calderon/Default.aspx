<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Calderon.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-articulo {
            background: rgba(30, 30, 50, 0.8);
            backdrop-filter: blur(10px);
            border-radius: 15px;
            border: 1px solid rgba(255,255,255,0.1);
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
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" OnClick="btnBuscar_Click" />
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
                    <div class="row">
                        <div class="col-6">
                            <h5 class="card-title"><%:articulo.Nombre %></h5>
                            <p class="card-text"><%:articulo.Descripcion %></p>
                            <h6 class="card-title">$ <%:articulo.Precio %></h6>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12 d-flex justify-content-between align-items-center">
                            <a href='Default.aspx?id=<%: articulo.Id %>' class="btn btn-outline-light btn-sm">❤️</a>
                            <a href='DetalleArticulo.aspx?id=<%: articulo.Id %>' class="btn btn-primary btn-sm">Ver Detalle</a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <%}%>
    </div>
</asp:Content>
