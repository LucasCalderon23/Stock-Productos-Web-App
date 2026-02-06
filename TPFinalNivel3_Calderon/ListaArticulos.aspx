<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3_Calderon.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-4">
        <div class="mb-3">
            <label for="lblFiltro" class="form-label">Filtro Rapido:</label>
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" />
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkFiltro" CssClass="form-check-input"
                    AutoPostBack="true" />
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvListaArticulos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvListaArticulos_SelectedIndexChanged" 
        OnPageIndexChanging="dgvListaArticulos_PageIndexChanging" AllowPaging="True" PageSize="10">
        <Columns>
            <%-- genero las columnas a criterio mio --%>
            <asp:boundfield headertext="codigo" datafield="codigo" />
            <asp:boundfield headertext="nombre" datafield="nombre" />
            <asp:boundfield headertext="descripcion" datafield="descripcion" />
            <asp:boundfield headertext="precio" datafield="precio" />
            <asp:boundfield headertext="marca" datafield="marca.descripcion" />
            <asp:boundfield headertext="categoria" datafield="categoria.descripcion" />
            <asp:Commandfield headertext="accion" ShowSelectButton="true" selecttext="✅​" />
        </columns>
    </asp:GridView>
    <a href="FormularioArticulos.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
