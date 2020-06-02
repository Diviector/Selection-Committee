<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Selection_Committee.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="250px" ImageUrl="~/App_Images/LogoImage.png" />
            <br />
            <asp:Label ID="Label" runat="server" Text="Приемная комиссия"></asp:Label>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label_Username" runat="server" Text="Имя пользователя"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Username" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label_ErroLine" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label_Password" runat="server" Text="Пароль"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button_SignIn" runat="server" Text="Войти" OnClick="Button_SignIn_Click" />
            <asp:Button ID="Button_Registration" runat="server" OnClick="Button_Registration_Click" Text="Зарегистрироваться" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
