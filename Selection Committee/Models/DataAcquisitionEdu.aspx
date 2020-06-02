<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAcquisitionEdu.aspx.cs" Inherits="Selection_Committee.Models.DataAcquisitionEdu" %>

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
                    <asp:ListItem Value="DataAcquisitionEdu.aspx">Образованние</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionBasic.aspx">Основное</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionFamily.aspx">Семья</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionDoc.aspx">Документы</asp:ListItem>
                    <asp:ListItem Value="DataAcquisitionAchievements.aspx">Достижения</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label_ErrorOrSuccessMessage" runat="server"></asp:Label>
                <asp:Label ID="Label_UploadStatus" runat="server"></asp:Label>
            </p>
        </div>
                        <asp:Label ID="Label_EduLevel" runat="server" Text="Уровень образования"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList_EduLevel" runat="server">
            <asp:ListItem>Основное общее образование (9 классов)</asp:ListItem>
            <asp:ListItem>Общее среднее полное образование (11 классов)</asp:ListItem>
            <asp:ListItem>Начальное профессиональное образование</asp:ListItem>
            <asp:ListItem>Среднее профессиональное образование</asp:ListItem>
            <asp:ListItem>Высшее образование</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label_EduInst" runat="server" Text="Учебное заведение, которое окончили"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList_Inst" runat="server">
            <asp:ListItem>Школа</asp:ListItem>
            <asp:ListItem>Колледж</asp:ListItem>
            <asp:ListItem>Техникум</asp:ListItem>
            <asp:ListItem>Институт</asp:ListItem>
            <asp:ListItem>Университет</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label_NameOfEduInst" runat="server" Text="Наименование учебного заведения"></asp:Label>
        <asp:TextBox ID="TextBox_NameOfEduInst" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label_YearOfGrad" runat="server" Text="Год окончания"></asp:Label>
        <br />
        <asp:ListBox ID="ListBox_YearOfGrad" runat="server"></asp:ListBox>
        <br />
        <br />
        <table>
            <tr>
                <td>

                    <asp:RadioButtonList ID="RadioButtonList_Doc" runat="server">
                        <asp:ListItem>Атетстат</asp:ListItem>
                        <asp:ListItem>Диплом</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
                <td>

                    <asp:Label ID="Label_MiddleMark" runat="server" Text="Средний бал"></asp:Label>

                    <br />

                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Рассчитать за меня" TextAlign="Left" OnCheckedChanged="CheckBox1_CheckedChanged" />

                </td>
                <td>

                    <asp:TextBox ID="TextBox_MiddleMark" runat="server"></asp:TextBox>

                    <br />

                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>

                    <asp:Label ID="Label_5" runat="server" Text="Кол-во 5" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBox_5" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_4" runat="server" Text="Кол-во 4" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBox_4" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_3" runat="server" Text="Кол-во 3" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBox_3" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button_Calc" runat="server" Text="Рассчитать" Visible="False" OnClick="Button_Calc_Click" />

                </td>
            </tr>
        </table>
                        <br />
        <asp:Label ID="Label_GoingTo" runat="server" Text="Поступаете на"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList_Form" runat="server">
            <asp:ListItem Value="Очная">Очную форму обучения</asp:ListItem>
            <asp:ListItem Value="Заочная">Заочную форму обучения</asp:ListItem>
        </asp:RadioButtonList>
        <br />
                        <asp:Button ID="Button_EduSave" runat="server" Text="Сохранить данные" OnClick="Button_EduSave_Click"/>
        <div>
        </div>
    </form>
</body>
</html>
