<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="TreeView.TreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="soruce" 
         ExpandImageUrl="~/imgs/1378668376_46285.ico" 
            CollapseImageUrl="~/imgs/1378668525_12525.ico" NoExpandImageUrl="~/imgs/1378668673_132656.ico"
             OnTreeNodeCollapsed="TreeView1_TreeNodeCollapsed" SelectedNodeStyle-ForeColor="Green" 
             OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
           <DataBindings>
          
          <asp:TreeNodeBinding TargetField="#InnerText"  TextField="#Name"/>
               <asp:TreeNodeBinding DataMember="genre" TextField="name" />
               <asp:TreeNodeBinding DataMember="book" TextField="ISBN" />
               <asp:TreeNodeBinding DataMember="userComment" TargetField="#InnerText" TextField="rating" />
               <asp:TreeNodeBinding DataMember="comments" TextField="#Name" />
     </DataBindings>

<SelectedNodeStyle ForeColor="Green"></SelectedNodeStyle>
        </asp:TreeView>
        <asp:XmlDataSource ID="soruce" runat="server" DataFile="~/review-queries.xml"></asp:XmlDataSource>
        <asp:Label ID="innerXml" runat="server"></asp:Label>
    </form>
</body>
</html>
