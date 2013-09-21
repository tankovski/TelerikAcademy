<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAlbum.aspx.cs" Inherits="PhotoAlbum.PhotoAlbum" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.0.3.js"></script>

    <style>
        #Controls {
            text-align:center
        }
        #btnNext {
            width:32px;
            height:32px;
            background-image:url('Buttons/Next.png');
            background-color:none;
           border:red;
        }

          #btnNext:hover {
            width:32px;
            height:32px;
            background-image:url('Buttons/NextHover.png');
            background-color:none;
           border:red;
           cursor:pointer;
        }

          #btnPrev {
            width:32px;
            height:32px;
            background-image:url('Buttons/Prev.png');
            background-color:none;
           border:red;
        }

          #btnPrev:hover {
            width:32px;
            height:32px;
            background-image:url('Buttons/PrevHover.png');
            background-color:none;
           border:red;
           cursor:pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

        <asp:Image ID="img1" runat="server" Height="500" class="Image" />


        <ajaxToolkit:SlideShowExtender ID="Image1_SlideShowExtender" runat="server"
            Enabled="True" ImageDescriptionLabelID="txtDesc"
            SlideShowServiceMethod="GetSlides" AutoPlay="false"
            NextButtonID="btnNext" PreviousButtonID="btnPrev"
            TargetControlID="img1">
        </ajaxToolkit:SlideShowExtender>
        <br />

        <div id="Controls">
            <asp:Button ID="btnPrev" runat="server"  />
            <asp:Button ID="btnNext" runat="server" />

        </div>


        <script src="Scripts/zoom.js"></script>
    </form>
</body>
</html>
