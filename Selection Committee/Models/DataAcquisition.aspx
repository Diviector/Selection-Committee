<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAcquisition.aspx.cs" Inherits="Selection_Committee.Models.DataAcquisition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="DataAcquisition" runat="server">
        <div>
            <p>
                <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Label ID="Label_ErrorOrSuccessMessage" runat="server"></asp:Label>
                <asp:Label ID="Label_UploadStatus" runat="server"></asp:Label>
            </p>
                <asp:MultiView ID="MultiView" runat="server">
                    <asp:View ID="Основное" runat="server">
                        <table style="width:50%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label_Family" runat="server" Text="Фамилия"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_Lastname" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label_KindOfDocument" runat="server" Text="Вид документа"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_KindOfDocument" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label_Firstname" runat="server" Text="Имя"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_Firstnane" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label_Сitizenship" runat="server" Text="Гражданство"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_Сitizenship" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label_Patronymic" runat="server" Text="Отчество"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_Patronymic" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label_RegistrationAddress" runat="server" Text="Адрес регистрации"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_RegistrationAddress" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label_DateOfBirth" runat="server" Text="Дата рождения"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_DateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label_ResidentialAddress" runat="server" Text="Адрес проживания"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_ResidentialAddress" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label_Gender" runat="server" Text="Пол"></asp:Label>
                                    <asp:RadioButtonList ID="RadioButtonList_Gender" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Муж</asp:ListItem>
                                        <asp:ListItem>Жен</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                </td>
                                <td>
                                    <asp:Label ID="Label_DateOfFillingIn" runat="server" Text="Дата заполнения"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TextBox_DateOfFillingIn" runat="server" TextMode="Date"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="Label_Photo" runat="server" Text="Прикрепите фотографию"></asp:Label>
                        <br />
                        <asp:FileUpload ID="FileUpload_FacePhoto" runat="server" />
                        <br />
                        <br />
                        <asp:Button ID="Button_BasicSave" runat="server" Text="Сохранить данные" OnClick="Button_BasicSave_Click" />
                        <br />
                    </asp:View>
                    <asp:View ID="Образование" runat="server">
                        <br />
                    </asp:View>
                    <asp:View ID="Семья" runat="server">
                        <br />
                    </asp:View>
                    <asp:View ID="Документы" runat="server">
                        <br />
                    </asp:View>
                    <asp:View ID="Дистижения" runat="server">
                        <br />
                    </asp:View>
                </asp:MultiView>
        </div>
    </form>
</body>
</html>