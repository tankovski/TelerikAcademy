<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentTopic.aspx.cs" Inherits="BlogSystem.LoggedUsers.CurrentTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CurrentTopicPosts">
        <h1 id="TopicName" runat="server"></h1>

        <div id="CurrentTopicContainer">

            <asp:UpdatePanel ID="TopicUpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:ListView ID="CurrentTopicListView" runat="server"
                        DataKeyNames="Id"
                        InsertItemPosition="None"
                        ItemType="BlogSystem.Models.Post"
                        SelectMethod="CurrentTopicListView_GetData1"
                        InsertMethod="CurrentTopicListView_InsertItem"
                        OnItemInserted="CurrentTopicListView_ItemInserted">
                        <LayoutTemplate>
                            <ul id="AnswersUl">
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
                            <li>
                                <h3><%#: Item.PostContent %></h3>
                                <asp:Image ID="PostImg" runat="server" ImageUrl='<%#:Item.Image==null?"": "~/Images/"+Item.Image %>' />
                                <p>by <strong><%#: Item.AspNetUser.UserName %></strong></p>

                            </li>
                        </ItemTemplate>
                    </asp:ListView>


                    <fieldset>
                        <legend>Show your Hate</legend>
                        <div>
                            Hate:
                     <asp:TextBox ID="PostContent" runat="server" Rows="10" Columns="20" Height="50px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidateContent" runat="server" Display="Dynamic"
                                EnableClientScript="false" ControlToValidate="PostContent" ErrorMessage="You must enter Hate content"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                           <%-- <asp:FileUpload ID="PostImgUpload" runat="server" />--%>
                            <br />
                            <asp:Button ID="InsertPostBtn" runat="server" OnClick="InsertPostBtn_Click" Text="AddHate" />

                        </div>
                    </fieldset>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
