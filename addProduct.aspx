<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="FinalFurnitureShowroom.Admin.addProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ci" runat="server">
    <h3> Add Product Pages</h3>
    <table>
        <tr>
            <td> <asp:Label Text="Product Name" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxProductName" runat="server"> </asp:TextBox></td>
        </tr>
         <tr>
            <td> <asp:Label Text="Product Description" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxDes" runat="server" TextMode="MultiLine"> </asp:TextBox></td>
        </tr>
         <tr>
            <td> <asp:Label Text="Product Price" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxPrice" runat="server" TextMode="MultiLine"> </asp:TextBox></td>
        </tr>
         <tr>
            <td> <asp:Label Text="Product Quantity" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxProductQuantity" runat="server" TextMode="MultiLine"> </asp:TextBox></td>
        </tr>
        <tr>
            <td> 
                <asp:Label Text="Product Id" runat="server"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxProductId" runat="server" > </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" /> 
            </td>
        </tr>        
                </table>

                <asp:Label id="lblerror" runat="server"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False"  Width="646px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="productName" HeaderText="Product Name" SortExpression="productName" />
                        <asp:BoundField DataField="ProductDes" HeaderText="product Description" SortExpression="ProductDes" />
                        <asp:BoundField DataField="productPrice" HeaderText="Product Price" SortExpression="productPrice" />
                        <asp:BoundField DataField="productQuantity" HeaderText="Product Quantity" SortExpression="productQuantity" />
                        <asp:BoundField DataField="productId" HeaderText="Product Id" SortExpression="productId" />

                         <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" text="Delete" Id="btnDelete" CommandArgument='<%# Eval("Id")%>' Oncommand="DeleteInfo"/>
                </ItemTemplate>
            </asp:TemplateField>

                         <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" text="Edit" Id="btnEdit" CommandArgument='<%# Eval("Id")%>' Oncommand="EditInfo"/>
                </ItemTemplate>
            </asp:TemplateField>

                       

                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>

   <%-- <table>
        <tr>
            <td> <asp:Label Text="Product Name" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxProductName" runat="server"> </asp:TextBox></td>
        </tr>
         <tr>
            <td> <asp:Label Text="Product Description" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxDes" runat="server" TextMode="MultiLine"> </asp:TextBox></td>
        </tr>
         <tr>
            <td> <asp:Label Text="Product Price" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxPrice" runat="server" TextMode="MultiLine"> </asp:TextBox></td>
        </tr>
         <tr>
            <td> <asp:Label Text="Product Quantity" runat="server"></asp:Label></td>
            <td> <asp:TextBox ID="tbxProductQuantity" runat="server" TextMode="MultiLine"> </asp:TextBox></td>
        </tr>
        <tr>
            <td> 
                <asp:Label Text="Product Id" runat="server"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxProductId" runat="server" > </asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" /> 
            </td>
        </tr>
           <tr>
            <td> 
                <asp:Label Text="lblError" id="lblerror" runat="server"> </asp:Label>
            </td>
        </tr>
    </table>--%>
</asp:Content>
