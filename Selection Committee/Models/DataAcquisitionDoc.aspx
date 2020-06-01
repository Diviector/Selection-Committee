<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAcquisitionDoc.aspx.cs" Inherits="Selection_Committee.Models.DataAcquisitionDocuments" %>

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
                    <asp:ListItem Value="DataAcquisitionDoc.aspx">Документы</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionBasic.aspx">Основное</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionEdu.aspx">Образованние</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionFamily.aspx">Семья</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionAchievements.aspx">Достижения</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label_ErrorOrSuccessMessage" runat="server"></asp:Label>
                <asp:Label ID="Label_UploadStatus" runat="server"></asp:Label>
            </p>
        </div>
        <table>
            <tr>
                <td>

                    <asp:Label ID="Label_Application" runat="server" Text="Заявление на поступление"></asp:Label>

                </td>
                <td>

                    <asp:FileUpload ID="FileUpload_Application" runat="server" />

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label_Passport" runat="server" Text="Копия паспорта"></asp:Label>

                </td>
                <td>

                    <asp:FileUpload ID="FileUpload_Passport" runat="server" />

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label_EduDoc" runat="server" Text="Копия атестата/диплома"></asp:Label>

                </td>
                <td>

                    <asp:FileUpload ID="FileUpload_EduDoc" runat="server" />

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label_Character" runat="server" Text="Характеристика"></asp:Label>

                </td>
                <td>

                    <asp:FileUpload ID="FileUpload_Character" runat="server" />

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label_MedStatement" runat="server" Text="Медицинская справка"></asp:Label>

                </td>
                <td>

                    <asp:FileUpload ID="FileUpload_MedStatement" runat="server" />

                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button_DocSave" runat="server" Text="Сохранить данные" OnClick="Button_DocSave_Click" />
        <div>
        </div>
    </form>
</body>
</html>
