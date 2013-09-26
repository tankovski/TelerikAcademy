<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="BlogSystem.LoggedUsers.Topics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="TopicsContainer">
        <asp:UpdatePanel ID="TopicUpdatePanel" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="InsertTopicBtn" />
            </Triggers>
            
            <ContentTemplate>
                <asp:ListView ID="AllTopicsListView" runat="server"
                    DataKeyNames="Id"
                    InsertItemPosition="None"
                    ItemType="BlogSystem.Models.Topic"
                    SelectMethod="AllTopicsListView_GetData">
                    <LayoutTemplate>
                        <asp:LinkButton runat="server" ID="SortByNameButton" CommandName="Sort" Text="Sort by Name" CommandArgument="Name" />
                        <ul id="AllTopicsUl">
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </ul>
                        <div>
                            <asp:DataPager ID="DataPagerTopics" runat="server" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ShowLastPageButton="True"
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="hero-unit">
                            <h3><%#: Item.Name %></h3>
                            <p><%#: Item.Description %></p>
                            by <strong><%#: Item.AspNetUser.UserName %></strong>
                            <asp:Image ID="PostImg" runat="server" ImageUrl='<%#:Item.Image==null?"": "~/Images/"+Item.Image %>'/>
                            <br />
                            <a href='CurrentTopic.aspx?id=<%#: Item.Id %>' class="label-success label">LetsHate</a>

                        </li>
                    </ItemTemplate>
                </asp:ListView>

                <div>
                    <fieldset>
                        <legend>Add new topic</legend>

                        TopicTitle
                     <asp:TextBox ID="TopicTitle" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="ValidateTitle" runat="server" Display="Dynamic"
                            EnableClientScript="false" ControlToValidate="TopicTitle" ErrorMessage="You must enter title!"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CustomValidator ID="ValidateTitleLenght" runat="server" Display="Dynamic"
                            EnableClientScript="false" OnServerValidate="ValidateTitleLenght_ServerValidate"
                            ErrorMessage="The tilte is too long" ForeColor="Red"></asp:CustomValidator>
                        Topic Description
                     <asp:TextBox ID="TopicDescription" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            EnableClientScript="false" ControlToValidate="TopicDescription" ErrorMessage="You must enter description"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:FileUpload ID="TopicImgUpload" runat="server" />
                        <br />
                        <asp:Button ID="InsertTopicBtn" CommandName="AddTopic" runat="server" OnClick="InsertTopicBtn_Click" Text="AddTopic" />
                    </fieldset>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
