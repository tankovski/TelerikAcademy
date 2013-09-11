<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountriesFlags.aspx.cs" Inherits="CountriesFlags.CountriesFlags" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:EntityDataSource ID="CountriesEntitySource" runat="server"
            ConnectionString="name=CountriesEntities1" DefaultContainerName="CountriesEntities1"
            EntitySetName="Countries" Include="Language, Continent"
            EnableFlattening="False" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
        </asp:EntityDataSource>

        
        <asp:ListView ID="CountriesListView" runat="server"
            DataSourceID="CountriesEntitySource" DataKeyNames="Id" ItemType="CountriesData.Country"
            InsertItemPosition="None"
            OnItemInserted="CountriesListView_ItemInserted">
            <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByNameButton" CommandName="Sort" Text="Countrie Name" CommandArgument="Name" /></th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByPopulation" CommandName="Sort" Text="Countrie Population" CommandArgument="Population" /></th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByLanguage" CommandName="Sort" Text="Countrie's Language" CommandArgument="Language.Name" /></th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByContinent" CommandName="Sort" Text="Countrie's Continent" CommandArgument="Continent.Name" /></th>
                            <th>
                                <asp:LinkButton runat="server" ID="Flag" CommandName="Sort" Text="Flag" /></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tbody>
                    <tfoot>
                        <td class="pagerLine" colspan="3">
                            <asp:Button ID="ButtonInsertCountrie" Text="Insert" runat="server"
                                OnClick="ButtonInsertCountrie_Click" />
                            |
                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                        </td>
                    </tfoot>
                </table>
            </LayoutTemplate>

             <EmptyDataTemplate>
                <div>No data was returned.</div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td>
                    <%#:Item.Name %>
                </td>
                <td>
                    <%#:Item.Population %>
                </td>
                <td>
                    <%#:Item.Language.Name %>
                </td>
                <td>
                    <%#:Item.Continent.Name %>
                </td>
                <td>
                    <img src="data:image/png;base64,<%#:Item.Flag !=null?Convert.ToBase64String(Item.Flag):"" %> " />
                </td>
                <td>
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="ChangeFlag" />
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" /></td>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <tr></tr>
            </ItemSeparatorTemplate>

            <InsertItemTemplate>
                <td>Name: 
                         <asp:TextBox ID="TownNameTb" runat="server" Text='<%# BindItem.Name %>' />
                </td>
                <td>Population: 
                         <asp:TextBox ID="TonwPopulationTb" runat="server" Text='<%# BindItem.Population %>' />
                </td>
                <td>LanguageId: 
                    <asp:TextBox ID="CountryIdTb" runat="server" Text='<%# BindItem.LanguageId %>' />
                </td>
                <td>ContinentId: 
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.ContinentId %>' />
                </td>
                <td>Flag: 
                    <asp:FileUpload ID="FileUpload1" filebytes='<%#: BindItem.Flag %>' runat="server" />
                </td>
                <td>
                    <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" /></td>
            </InsertItemTemplate>
            <EditItemTemplate>
                
                <td colspan="5">Flag: 
                    <asp:FileUpload ID="FileUpload1" filebytes='<%#: BindItem.Flag %>' runat="server" />
                </td>
                <td> <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" /></td>
            </EditItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
