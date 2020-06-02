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
    public partial class DataAcquisitionAchivment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Clear();
            }

            fillAchievement();
        }

        private void fillAchievement()
        {
            DataTable table = getAchievement();
            if (table.Rows.Count > 0)
            {
                TextBox_Achievements.Text = table.Rows[0][0].ToString();

                Button_AchievementSave.Text = "Изменить данные";
            }
        }

        private DataTable getAchievement()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("get_achievement", db.GetConnection());

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

        protected void Button_AchievementSave_Click(object sender, EventArgs e)
        {
            try
            {
                addToAchievement();
            }
            catch (Exception ex)
            {
                Label_ErrorOrSuccessMessage.Text = ex.Message;
            }
        }

        private void addToAchievement()
        {
            string saveDiplomaPath = "";

            if (FileUpload_Diplomas.HasFile)
            {
                saveDiplomaPath = SaveFile(FileUpload_Diplomas, "~/Data_Of_Enrollee/Diplomas/");
            }
            else
            {
                if (Button_AchievementSave.Text == "Изменить данные")
                {
                    saveDiplomaPath = getAchievement().Rows[0][1].ToString();
                }
            }

            Database db = new Database();

            MySqlCommand sqlCommand = new MySqlCommand("add_or_edit_achieve", db.GetConnection());

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("_username", Classes.User.getUsername());
            sqlCommand.Parameters.AddWithValue("_story", TextBox_Achievements.Text);
            sqlCommand.Parameters.AddWithValue("_diploma", saveDiplomaPath);

            db.OpenConnection();
            sqlCommand.ExecuteNonQuery();
            db.CloseConnection();

            Label_ErrorOrSuccessMessage.Text = "Сохранено успешно!";
        }

        private string SaveFile(FileUpload fileUpload, string folder_in_the_project)
        {
            string saveFilePath = Server.MapPath(folder_in_the_project) +
                                       fileUpload.FileName;

            fileUpload.SaveAs(saveFilePath);

            return saveFilePath;
        }

        void Clear()
        {
            Label_ErrorOrSuccessMessage.Text = "";
            Label_UploadStatus.Text = "";
        }
    }
}