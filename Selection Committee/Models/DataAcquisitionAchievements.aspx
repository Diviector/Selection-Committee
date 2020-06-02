<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAcquisitionAchievements.aspx.cs" Inherits="Selection_Committee.Models.DataAcquisitionAchivment" %>

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
                    <asp:ListItem Value="DataAcquisitionAchievements.aspx">Достижения</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionBasic.aspx">Основное</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionEdu.aspx">Образованние</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionFamily.aspx">Семья</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionDoc.aspx">Документы</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label_ErrorOrSuccessMessage" runat="server"></asp:Label>
                <asp:Label ID="Label_UploadStatus" runat="server"></asp:Label>
            </p>
        </div>
        <asp:Label ID="Label_Achievement" runat="server" Text="Расскажите о себе (личные достижения, хобби)"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox_Achievements" runat="server" Height="115px" Width="445px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
                        <asp:Label ID="Label_Diplomas" runat="server" Text="Прикрепите сканы грамот"></asp:Label>
                        <br />
                        <asp:FileUpload ID="FileUpload_Diplomas" runat="server" />
                        <br />
                        <br />
                        <asp:Button ID="Button_AchievementSave" runat="server" Text="Сохранить данные" OnClick="Button_AchievementSave_Click" />
        <div>
        </div>
    </form>
</body>
</html>
