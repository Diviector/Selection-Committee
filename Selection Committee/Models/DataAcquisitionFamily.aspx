<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAcquisitionFamily.aspx.cs" Inherits="Selection_Committee.Models.DataAcquisitionFamily" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem Value="DataAcquisitionFamily.aspx">Семья</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionBasic.aspx">Основное</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionEdu.aspx">Образованние</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionDoc.aspx">Документы</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionAchievements.aspx">Достижения</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label_ErrorOrSuccessMessage" runat="server"></asp:Label>
                <asp:Label ID="Label_UploadStatus" runat="server"></asp:Label>
            </p>
        </div>
        <asp:Label ID="Label_Family" runat="server" Text="Семья"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Полная</asp:ListItem>
            <asp:ListItem>Неполная</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <table>
            <tr>
                <td>

                    <asp:Label ID="Label_LegalRepr" runat="server" Text="Законный представитель"></asp:Label>

                </td>
                <td>

                    <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                        <asp:ListItem>Мать</asp:ListItem>
                        <asp:ListItem>Отец</asp:ListItem>
                        <asp:ListItem>Опекун</asp:ListItem>
                        <asp:ListItem>Социальный педагог</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
                <td>

                    <asp:Label ID="Label_FIOLegalRepr" runat="server" Text="ФИО законного представителя"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="TextBox_FIOLegalRepr" runat="server"></asp:TextBox>

                </td>
            </tr>
        </table>
        <asp:Label ID="Label_Phone" runat="server" Text="Номер телефона"></asp:Label>
        <asp:TextBox ID="TextBox_Phone" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button_FamilySave" runat="server" Text="Сохранить данные" OnClick="Button_FamilySave_Click" />
        <div>
        </div>
    </form>
</body>
</html>
