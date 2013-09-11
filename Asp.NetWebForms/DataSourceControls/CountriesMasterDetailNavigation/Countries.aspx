<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="CountriesMasterDetailNavigation.Countries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Continents</h1>
        <asp:EntityDataSource ID="ContinentsEntitySource" runat="server"
            ConnectionString="name=CountriesEntities1" DefaultContainerName="CountriesEntities1"
            EntitySetName="Continents"
            EnableFlattening="false">
        </asp:EntityDataSource>

        <asp:ListBox ID="ContinentsListBox" runat="server"
            DataSourceID="ContinentsEntitySource"
            DataTextField="Name" DataValueField="Id"
            Rows="5" AutoPostBack="true"></asp:ListBox>

        <h1>Countries</h1>

        <asp:EntityDataSource ID="CountriesDataSource" runat="server"
            EnableInsert="True" EnableUpdate="True" EnableDelete="True"
            ConnectionString="name=CountriesEntities1" DefaultContainerName="CountriesEntities1"
            EntitySetName="Countries" Include="Language, Continent" Where="it.ContinentId=@ContId"
            EnableFlattening="false">
            <WhereParameters>
                <asp:ControlParameter Name="ContId" Type="Int32" ControlID="ContinentsListBox" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView ID="CountriesGrid" runat="server"
            DataSourceID="CountriesDataSource" DataKeyNames="Id" AutoGenerateColumns="False"
            AllowPaging="True" AllowSorting="True" PageSize="5"
             ItemType="CountriesData.Country" ShowFooter="true" OnRowCommand="CountriesGrid_RowCommand">
            <Columns>


               <asp:TemplateField>
                    <HeaderTemplate>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByNameCountry" CommandName="Sort" Text="Country Name" CommandArgument="Name" />

                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByPopulationCountry" CommandName="Sort" Text="Country  Population" CommandArgument="Population" />

                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="LanguigeBtn" CommandName="Sort" Text="Country Language" CommandArgument="Language.Name" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="ContinentName" CommandName="Sort" Text="Country's Continent" CommandArgument="Continent.Name" />
                        </th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="SelectButtonCountry" runat="server" CommandName="Select" Text="Select" />
                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" /></td>
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
                    </ItemTemplate>
                      
                     <%-- <FooterTemplate>                   
                           <td colspan="4"><asp:Button CommandName="AddARowBelow" Text="Add A Row Below" OnClick="Unnamed_Click1" runat="server" /></td>--%>
                             <%-- <td colspan="4"><asp:Button ID="ButtonInsertCountrie" Text="Insert" runat="server" OnClick="ButtonInsertCountrie_Click"/></td>--%>                         
                    <%--</FooterTemplate>--%>
                    <EditItemTemplate>
                        <asp:Button ID="ButtonUpdateCountry" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancelCountry" runat="server" CommandName="Cancel" Text="Cancel" /></td>
                        

                        <td>
                            Country Name:
                            <br />
                            <asp:TextBox ID="CountryNameBind" runat="server" Text="<%#: BindItem.Name %>"></asp:TextBox>
                        </td>
                        <td>
                            Country Population:
                            <br />
                            <asp:TextBox ID="CountryPopulationBind" runat="server" Text="<%#: BindItem.Population %>"></asp:TextBox>
                        </td>
                        <td>
                            Language Id: 
                            <br />
                            <asp:TextBox ID="LanguageId" runat="server" Text="<%#: BindItem.LanguageId %>"></asp:TextBox>
                        </td>
                        <td>
                            Continent Id: 
                            <br />
                            <asp:TextBox ID="CountinentId" runat="server" Text="<%#: BindItem.ContinentId %>"></asp:TextBox>
                        </td>
                    </EditItemTemplate>
                

                   <FooterTemplate>
                            <asp:Button   CommandName="Insert" ID="ButtonAdd" runat="server"
                                Text="Add New Row" OnClick="ButtonAdd_Click" />
                            <td>
                            Country Name:
                            <br />
                            <asp:TextBox ID="CountryNameInsertTb" runat="server" Text="<%#: BindItem.Name %>" 
                                OnPreRender="CountryNameInsertTb_PreRender" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            Country Population:
                            <br />
                            <asp:TextBox ID="CountryPopulationBind" runat="server" Text="<%#: BindItem.Population %>"
                                 OnPreRender="CountryPopulationBind_PreRender" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            Language Id: 
                            <br />
                          
                            <asp:TextBox ID="LanguageId" runat="server" Text="<%#: BindItem.LanguageId %>"
                                 OnPreRender="LanguageId_PreRender" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            Continent Id: 
                            <br />
                            <asp:TextBox ID="CountinentId" runat="server" Text="<%#: BindItem.ContinentId %>"
                                 OnPreRender="CountinentId_PreRender" AutoPostBack="true"></asp:TextBox>
                        </td>
                        </FooterTemplate>
                </asp:TemplateField>

             
                        
                 
                <%--<asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" />--%>

               <%--<asp:CommandField ShowSelectButton="True" ShowDeleteButton="true" ShowEditButton="true" ShowInsertButton="true" />
                <asp:BoundField DataField="Name" HeaderText="Country Name" SortExpression="Name" />
                <asp:BoundField DataField="Population" HeaderText="Country Population" SortExpression="Population" />
                <asp:BoundField ReadOnly="true" DataField="Language.Name" HeaderText="Country Language" SortExpression="Language.Name" />
                <asp:BoundField ReadOnly="true" DataField="Continent.Name" HeaderText="Country's Continent" SortExpression="Continent.Name" />--%>
            </Columns>

        </asp:GridView>

     <%--   <asp:Label></asp:Label>--%>
        <h1>Towns</h1>

        <asp:EntityDataSource ID="TownsDataSource" runat="server"
            EnableInsert="True" EnableUpdate="True" EnableDelete="True"
            ConnectionString="name=CountriesEntities1" DefaultContainerName="CountriesEntities1"
            EntitySetName="Towns" Where="it.CountryId=@CountId" Include="Country" EnableFlattening="false">
            <WhereParameters>
                <asp:ControlParameter Name="CountId" Type="Int32" ControlID="CountriesGrid" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:ListView ID="TownsListView" runat="server"
            DataSourceID="TownsDataSource" DataKeyNames="Id" ItemType="CountriesData.Town"
            InsertItemPosition="None"
            OnItemInserted="TownsListView_ItemInserted">
            <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByNameButton" CommandName="Sort" Text="Town Name" CommandArgument="Name" /></th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByPopulation" CommandName="Sort" Text="Town Population" CommandArgument="Population" /></th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByCountry" CommandName="Sort" Text="Town's Country" CommandArgument="Country.Name" /></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tbody>
                    <tfoot>
                        <td class="pagerLine" colspan="3">
                            <asp:Button ID="ButtonInsertTown" Text="Insert" runat="server"
                                OnClick="ButtonInsertTown_Click" />
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
                    <%#:Item.Country.Name %>
                </td>
                <td>
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" /></td>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <tr></tr>
            </ItemSeparatorTemplate>

            <EditItemTemplate>

                <td>Name: 
                         <asp:TextBox ID="TownNameTb" runat="server" Text='<%# BindItem.Name %>' />
                </td>
                <td>Population: 
                         <asp:TextBox ID="TonwPopulationTb" runat="server" Text='<%# BindItem.Population %>' />
                </td>
                <td>
                    <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" /></td>

            </EditItemTemplate>

            <InsertItemTemplate>
                <td>Name: 
                         <asp:TextBox ID="TownNameTb" runat="server" Text='<%# BindItem.Name %>' />
                </td>
                <td>Population: 
                         <asp:TextBox ID="TonwPopulationTb" runat="server" Text='<%# BindItem.Population %>' />
                </td>
                <td>CountryId: 

                    
                    <%--<asp:Label ID="countryId" runat="server" Text="<%# BindItem.CountryId %>"><%#: this.CountriesGrid.SelectedDataKey!=null?this.CountriesGrid.SelectedDataKey.Value:0 %></asp:Label>--%>
                    <asp:TextBox ID="CountryIdTb" runat="server" Text='<%# BindItem.CountryId %>' />
                </td>
                <td>
                    <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" /></td>
            </InsertItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
