using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Selection_Committee.Models
{
    public partial class DataAcquisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Clear();
            }

            fillBasic();
        }

        private void fillBasic()
        {
            DataTable table = getBasic();
            if (table.Rows.Count > 0)
            {
                TextBox_Secondname.Text = table.Rows[0][0].ToString();
                TextBox_Firstnane.Text = table.Rows[0][1].ToString();
                TextBox_Patronymic.Text = table.Rows[0][2].ToString();
                TextBox_DateOfBirth.Text = dateToString(table.Rows[0][3]);
                RadioButtonList_Gender.SelectedValue = table.Rows[0][4].ToString();
                TextBox_KindOfDocument.Text = table.Rows[0][5].ToString();
                TextBox_Сitizenship.Text = table.Rows[0][6].ToString();
                TextBox_RegistrationAddress.Text = table.Rows[0][7].ToString();
                TextBox_ResidentialAddress.Text = table.Rows[0][8].ToString();
                TextBox_DateOfFillingIn.Text = dateToString(table.Rows[0][9]);
                Label_Photo.Text = "Изменить фото? Укажите на какое или оставьте без изменений";

                Button_BasicSave.Text = "Изменить данные";
            }
        }

        private string dateToString(object date)
        {
            string dateString = date.ToString();

            string[] words = dateString.Split(' ');
            words = words[0].Split('.');
            dateString = words[2] + '-' + words[1] + '-' + words[0];

            return dateString;
        }

        private DataTable getBasic()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("get_basic", db.GetConnection());

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

        protected void Button_BasicSave_Click(object sender, EventArgs e)
        {
            try
            {
                addToBasic();
            }
            catch (Exception ex)
            {
                Label_ErrorOrSuccessMessage.Text = ex.Message;
            }
        }

        private void addToBasic()
        {
            string savePhotoPath = "";

            if (FileUpload_FacePhoto.HasFile)
            {
                savePhotoPath = SaveFile(FileUpload_FacePhoto, "~/Data_Of_Enrollee/Face_Photos/");
            }
            else
            {
                if (Button_BasicSave.Text == "Изменить данные")
                {
                    savePhotoPath = getBasic().Rows[0][10].ToString();
                }
                else throw new Exception("Фото не загружено. Вы не указали фото.");
            }
                
            Database db = new Database();

            MySqlCommand sqlCommand = new MySqlCommand("add_or_edit_basic", db.GetConnection());

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("_username", Classes.User.getUsername());
                sqlCommand.Parameters.AddWithValue("_second_name", TextBox_Secondname.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_first_name", TextBox_Firstnane.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_patronymic", TextBox_Patronymic.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_date_of_birth", TextBox_DateOfBirth.Text.Replace('-', '.').Trim());
                sqlCommand.Parameters.AddWithValue("_gender", RadioButtonList_Gender.SelectedValue.Trim());
                sqlCommand.Parameters.AddWithValue("_kind_of_document", TextBox_KindOfDocument.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_citizenship", TextBox_Сitizenship.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_registration_address", TextBox_RegistrationAddress.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_residential_address", TextBox_ResidentialAddress.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_date_of_filling_in", TextBox_DateOfFillingIn.Text.Replace('-', '.').Trim());
                sqlCommand.Parameters.AddWithValue("_face_photo_path", savePhotoPath);

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