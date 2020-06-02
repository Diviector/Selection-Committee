using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Selection_Committee.Models
{
    public partial class DataAcquisitionFamily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Clear();
            }

            fillFamily();
        }

        private void fillFamily()
        {
            DataTable table = getFamily();
            if (table.Rows.Count > 0)
            {
                RadioButtonList_Full.SelectedValue = table.Rows[0][0].ToString();
                RadioButtonList_Repr.SelectedValue = table.Rows[0][1].ToString();
                TextBox_SecondName.Text = table.Rows[0][2].ToString();
                TextBox_FirstName.Text = table.Rows[0][2].ToString();
                TextBox_Patronymic.Text = table.Rows[0][2].ToString();
                TextBox_Phone.Text = table.Rows[0][2].ToString();

                Button_FamilySave.Text = "Изменить данные";
            }
        }

        private DataTable getFamily()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("get_family", db.GetConnection());

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_username", MySqlDbType.VarChar).Value = Classes.User.getUsername();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            db.OpenConnection();
            adapter.Fill(table);
            db.CloseConnection();

            return table;
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(DropDownList.SelectedValue);
        }

        protected void Button_FamilySave_Click(object sender, EventArgs e)
        {
            try
            {
                addToFamily();
            }
            catch (Exception ex)
            {
                Label_ErrorOrSuccessMessage.Text = ex.Message;
            }
        }
        private void addToFamily()
        {

            Database db = new Database();

            MySqlCommand sqlCommand = new MySqlCommand("add_or_edit_family", db.GetConnection());

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("_username", Classes.User.getUsername());
            sqlCommand.Parameters.AddWithValue("_full", RadioButtonList_Full.SelectedValue);
            sqlCommand.Parameters.AddWithValue("_legal_representative", RadioButtonList_Repr.SelectedValue);
            sqlCommand.Parameters.AddWithValue("_second_name", TextBox_SecondName.Text.Trim());
            sqlCommand.Parameters.AddWithValue("_first_name", TextBox_FirstName.Text.Trim());
            sqlCommand.Parameters.AddWithValue("_patronymic", TextBox_Patronymic.Text.Trim());
            sqlCommand.Parameters.AddWithValue("_phone_number", TextBox_Phone.Text.Trim());

            db.OpenConnection();
            sqlCommand.ExecuteNonQuery();
            db.CloseConnection();

            Label_ErrorOrSuccessMessage.Text = "Сохранено успешно!";
        }

        void Clear()
        {
            Label_ErrorOrSuccessMessage.Text = "";
            Label_UploadStatus.Text = "";
        }
    }
}