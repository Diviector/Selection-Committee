using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace Selection_Committee
{
    public partial class SignIn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_SignIn_Click(object sender, EventArgs e)
        {
            Label_ErroLine.Text = "";

            if (checkEmptyLine()) return;

            if (checkThePassword())
            {
                Classes.User.setUsername(TextBox_Username.Text.Trim());

                if (Classes.User.agreement)
                {
                    Response.Redirect("DataAcquisitionBasic.aspx");
                }
                else
                {
                    Response.Redirect("StartPage.aspx");
                }
            }
            else
            {
                Label_ErroLine.Text = "Неверный логин или пароль.";
            }

        }        

        protected void Button_Registration_Click(object sender, EventArgs e)
        {
            Label_ErroLine.Text = "";

            if (checkEmptyLine()) return;

            if (checkTheUsername())
            {
                Label_ErroLine.Text = "Имя пользователя занято.";
            }
            else
            {
                registeredUser();

                Classes.User.setUsername(TextBox_Username.Text.Trim());
                Response.Redirect("StartPage.aspx");
            }
        }

        private bool checkEmptyLine()
        {
            if (TextBox_Username.Text.Trim() == "")
            {
                Label_ErroLine.Text = "Введите имя пользователя";
                return true;
            }

            if (TextBox_Password.Text.Trim() == "")
            {
                Label_ErroLine.Text = "Введите пароль";
                return true;
            }

            return false;
        }

        private bool checkTheUsername()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("check_the_user", db.GetConnection());

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_username", MySqlDbType.VarChar).Value = TextBox_Username.Text.Trim();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            db.OpenConnection();
            adapter.Fill(table);
            db.CloseConnection();

            return table.Rows.Count > 0;
        }

        private bool checkThePassword()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("check_the_password", db.GetConnection());

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_username", MySqlDbType.VarChar).Value = TextBox_Username.Text.Trim();
            command.Parameters.Add("_password", MySqlDbType.VarChar).Value = TextBox_Password.Text.Trim();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            db.OpenConnection();
            adapter.Fill(table);
            db.CloseConnection();

            return table.Rows.Count > 0;
        }

        private void registeredUser()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("add_user", db.GetConnection());

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_username", MySqlDbType.VarChar).Value = TextBox_Username.Text.Trim();
            command.Parameters.Add("_email", MySqlDbType.VarChar).Value = "Нет";
            command.Parameters.Add("_password", MySqlDbType.VarChar).Value = TextBox_Password.Text.Trim();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnection();
        }
    }
}