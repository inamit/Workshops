<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowWorkshopsAdmin.aspx.cs" Inherits="admin_ShowWorkshopsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="WorkList" runat="server" OnItemCommand="WorkList_ItemCommand">
        <HeaderTemplate>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Workshop name</th>
                        <th>Workshop description</th>
                        <th>Workshop units</th>
                        <th>Room needs</th>
                        <th>Campers needs</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th scope="row"><%# DataBinder.Eval(Container.DataItem, "MyName") %></th>
                <td><%# DataBinder.Eval(Container.DataItem, "MyDescription") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "MyUnits") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "MyRoomNeeds") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "MyCamperNeeds") %></td>
                <td>
                    <asp:HyperLink ID="EditLink" runat="server" NavigateUrl='<%# string.Format("~/admin/EditWorkshop.aspx?wId=" + DataBinder.Eval(Container.DataItem, "ID")) %>' ForeColor="#33CC33">edit</asp:HyperLink>
                    /
                    <asp:LinkButton ID="DeleteLink" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' runat="server" ForeColor="Red">delete</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <%--<asp:DataList ID="WorkList" CssClass="table" runat="server" GridLines="Both" OnDeleteCommand="WorkList_DeleteCommand">
        <HeaderTemplate>
            <th class="col">Workshop name</th>
            <th class="col">Workshop description</th>
            <th class="col">Workshop units</th>
            <th class="col">Room needs</th>
            <th class="col">Campers needs</th>
            <th class="col">Actions</th>
        </HeaderTemplate>
        <ItemTemplate>
            <th scope="row"><%# DataBinder.Eval(Container.DataItem, "MyName") %></th>
            <td><%# DataBinder.Eval(Container.DataItem, "MyDescription") %></td>
            <td><%# DataBinder.Eval(Container.DataItem, "MyUnits") %></td>
            <td><%# DataBinder.Eval(Container.DataItem, "MyRoomNeeds") %></td>
            <td><%# DataBinder.Eval(Container.DataItem, "MyCamperNeeds") %></td>
            <td>
                <asp:HyperLink ID="EditLink" runat="server" NavigateUrl='<%# string.Format("~/admin/EditWorkshop.aspx?wId=" + DataBinder.Eval(Container.DataItem, "ID")) %>' ForeColor="#33CC33">edit</asp:HyperLink>
                /
                <asp:LinkButton ID="DeleteLink" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' runat="server" ForeColor="Red">delete</asp:LinkButton>
            </td>
        </ItemTemplate>
    </asp:DataList>--%>
</asp:Content>

