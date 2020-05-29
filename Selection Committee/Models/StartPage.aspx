<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="Selection_Committee.Models.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Image ID="StartImage" runat="server" Height="200px" ImageUrl="~/App_Images/StartImage.png" />
            <asp:Label ID="Label_SelComm" runat="server" Text="Приемная коммиссия"></asp:Label>
            <br />
            <asp:LinkButton ID="LinkButton_Agreement" runat="server" OnClick="LinkButton_Agreement_Click">Соглашение</asp:LinkButton>
            <br />
            <asp:CheckBox ID="CheckBox_Consent" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_Consent_CheckedChanged" Text="Согласие на обработку данных" />
            <asp:Button ID="Button_Further" runat="server" Enabled="False" OnClick="Button_Further_Click" Text="Продолжить" />

        </div>
    </form>
</body>
</html>
