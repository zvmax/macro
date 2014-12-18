<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/Style1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="div1">
            <span id="clicking">
                <asp:Button ID="btnOk" runat="server" Text="搜索" CssClass="mybutton" OnClick="btnOk_Click" />
            </span>
            <span id="waiting" style="color:#ff0000; display:none;">正在搜索，请稍候……</span>
        </div>
    <div class="div1">
    
        <asp:GridView ID="GridView1" runat="server" Width="100%">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
