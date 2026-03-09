<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3_Calderon.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .form-check-input {
            width: 45px;
            height: 22px;
            cursor: pointer;
            background-color: #444;
            border-color: #666;
            appearance: none;
        }

            .form-check-input:checked {
                background: linear-gradient(45deg, #00c6ff, #0072ff);
                border-color: #00c6ff;
            }

        .form-check-label {
            font-weight: 500;
            font-size: 15px;
            cursor: pointer;
        }

        
    </style>
    <%--NOTA IMPORTANTE. 
        el check del filtro avanzado le meti mano para que se vea el texto con el fondo oscuro pero debajo
        se agrego un dibujito gris que no puedo sacar. Hay solucion pero me lleva a cambiar algunas cosas.
        Por ahora lo dejo asi y sigo con la App... :)--%> 
    <div class="col-4">
        <label for="txtFiltro" class="form-label">Filtro rápido:</label>
        <div class="input-group">
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" OnClick="btnBuscar_Click" />
        </div>
        <div class="mt-3">
            <div class="form-check form-switch text-light">
                <asp:CheckBox ID="ckdFiltro" runat="server" CssClass="form-check-input" AutoPostBack="true"
                    OnCheckedChanged="chkFiltro_CheckedChanged" />
                <label class="form-check-label ms-2" for="<%= ckdFiltro.ClientID %>">Filtro Avanzado</label>
            </div>
        </div>

    </div>
    <%if (FiltroAvanzado)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo" />
                <asp:DropDownList ID="ddlCampo" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblCriterio" runat="server" Text="Criterio" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" AutoPostBack="true" />
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscarAvanzado" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarAvanzado_Click" />
                <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar" CssClass="btn btn-success" OnClick="btnLimpiarFiltro_Click" />
            </div>
        </div>
    </div>

    <%} %>
    <asp:GridView ID="dgvListaArticulos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvListaArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvListaArticulos_PageIndexChanging" AllowPaging="True" PageSize="10">
        <Columns>
            <%-- genero las columnas a criterio mio --%>
            <asp:BoundField HeaderText="codigo" DataField="codigo" />
            <asp:BoundField HeaderText="nombre" DataField="nombre" />
            <asp:BoundField HeaderText="descripcion" DataField="descripcion" />
            <asp:BoundField HeaderText="precio" DataField="precio" />
            <asp:BoundField HeaderText="marca" DataField="marca.descripcion" />
            <asp:BoundField HeaderText="categoria" DataField="categoria.descripcion" />
            <asp:CommandField HeaderText="accion" ShowSelectButton="true" SelectText="✅​" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulos.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
