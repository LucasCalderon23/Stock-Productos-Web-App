<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3_Calderon.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h2>Formulario Articulo</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label id="lblId" runat="server" class="form-label">Id</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtId" />
            </div>
            <div class="mb-3">
                <label id="lblCodigo" runat="server" class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" />
            </div>
            <div class="mb-3">
                <label id="lblNombre" runat="server" class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label id="lblDescripcion" runat="server" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" TextMode="MultiLine" />
            </div>
            <div class="mb-3">
                <label id="lblPrecio" runat="server" class="form-label">Precio</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" />
            </div>
            <div class="mb-3">
                <label for="lblMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="lblCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label id="imagenProducto" runat="server" class="form-label">Imagen Producto</label>
                        <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://imgs.search.brave.com/X_N2Y1fS1TO5CbzKSvt1Wsfs7lyyC_oefR6wrHHdPaU/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy84/Lzg5L1BvcnRyYWl0/X1BsYWNlaG9sZGVy/LnBuZw"
                        runat="server" CssClass="img-fluid mb-3" ID="imgProducto" />
                    </div>
                    <%if (Request.QueryString["id"] != null)
                    { %>
                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />
                    </div>
                    <%if (Confirmacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar eliminacion" ID="ckbConfirmar" runat="server" />
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" class="btn btn-outline-danger" OnClick="btnConfirmar_Click" />
                    </div>
                    <% }%>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row">
                <div class="col-md-4">
                    <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <a href="ListaArticulos.aspx">Regresar</a>
                </div>
            </div>
        </div>
</asp:Content>
