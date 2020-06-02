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
    public partial class DataAcquisitionEdu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Clear();
            }
            for (int i = DateTime.Today.Year; i > 1900; i--)
            {
                ListBox_YearOfGrad.Items.Add(i.ToString());
            }
            fillEdu();
        }

        private void fillEdu()
        {
            DataTable table = getEdu();
            if (table.Rows.Count > 0)
            {
                RadioButtonList_EduLevel.SelectedValue = table.Rows[0][0].ToString();
                RadioButtonList_Inst.SelectedValue = table.Rows[0][1].ToString();
                TextBox_NameOfEduInst.Text = table.Rows[0][2].ToString();
                ListBox_YearOfGrad.SelectedValue = table.Rows[0][3].ToString();
                RadioButtonList_Doc.SelectedValue = table.Rows[0][4].ToString();
                TextBox_MiddleMark.Text = table.Rows[0][5].ToString();
                RadioButtonList_Form.SelectedValue = table.Rows[0][6].ToString();

                Button_EduSave.Text = "Изменить данные";
            }
        }

        private DataTable getEdu()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("get_edu", db.GetConnection());

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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Label_3.Visible = !Label_3.Visible;
            Label_4.Visible = !Label_4.Visible;
            Label_5.Visible = !Label_5.Visible;

            TextBox_3.Visible = !TextBox_3.Visible;
            TextBox_4.Visible = !TextBox_4.Visible;
            TextBox_5.Visible = !TextBox_5.Visible;

            Button_Calc.Visible = !Button_Calc.Visible;
        }

        protected void Button_EduSave_Click(object sender, EventArgs e)
        {
            try
            {
                addToEdu();
            }
            catch (Exception ex)
            {
                Label_ErrorOrSuccessMessage.Text = ex.Message;
            }
        }

        private void addToEdu()
        {
            Database db = new Database();

            MySqlCommand sqlCommand = new MySqlCommand("add_or_edit_edu", db.GetConnection());

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("_username", Classes.User.getUsername());
            sqlCommand.Parameters.AddWithValue("_level_of_education", RadioButtonList_EduLevel.SelectedValue);
            sqlCommand.Parameters.AddWithValue("_educational_institution", RadioButtonList_Inst.SelectedValue);
            sqlCommand.Parameters.AddWithValue("_name_of_educational_institution", TextBox_NameOfEduInst.Text.Trim());
            sqlCommand.Parameters.AddWithValue("_year_of_graduation", ListBox_YearOfGrad.SelectedValue);
            sqlCommand.Parameters.AddWithValue("_kind_of_document", RadioButtonList_Doc.SelectedValue);
            sqlCommand.Parameters.AddWithValue("_middle_mark", TextBox_MiddleMark.Text.Trim());
            sqlCommand.Parameters.AddWithValue("_form_of_education", RadioButtonList_Form.SelectedValue);

            db.OpenConnection();
            sqlCommand.ExecuteNonQuery();
            db.CloseConnection();

            Label_ErrorOrSuccessMessage.Text = "Сохранено успешно!";
        }

        private void Clear()
        {
            Label_ErrorOrSuccessMessage.Text = "";
            Label_UploadStatus.Text = "";
        }

        protected void Button_Calc_Click(object sender, EventArgs e)
        {
            int five = Convert.ToInt32(TextBox_5.Text.Trim());
            int four = Convert.ToInt32(TextBox_4.Text.Trim());
            int three = Convert.ToInt32(TextBox_3.Text.Trim());

            double middle_mark = (((five * 5.0) + (four * 4.0) + (three * 3.0)) / (five + four + three));
            TextBox_MiddleMark.Text = middle_mark.ToString();
        }
    }
}