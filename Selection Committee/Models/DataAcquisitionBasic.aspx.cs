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
            if (FileUpload_FacePhoto.HasFile)
            {
                Database db = new Database();

                MySqlCommand sqlCommand = new MySqlCommand("add_or_edit_basic", db.GetConnection());

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("_username", Classes.User.getUsername());
                sqlCommand.Parameters.AddWithValue("_second_name", TextBox_Lastname.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_first_name", TextBox_Firstnane.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_patronymic", TextBox_Patronymic.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_date_of_birth", TextBox_DateOfBirth.Text.Replace('-', '.').Trim());
                sqlCommand.Parameters.AddWithValue("_gender", RadioButtonList_Gender.SelectedValue.Trim());
                sqlCommand.Parameters.AddWithValue("_kind_of_document", TextBox_KindOfDocument.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_citizenship", TextBox_Сitizenship.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_registration_address", TextBox_RegistrationAddress.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_residential_address", TextBox_ResidentialAddress.Text.Trim());
                sqlCommand.Parameters.AddWithValue("_date_of_filling_in", TextBox_DateOfFillingIn.Text.Replace('-', '.').Trim());

                string savePhotoPath = SaveFile(FileUpload_FacePhoto, "~/Data_Of_Enrollee/Face_Photos/");
                sqlCommand.Parameters.AddWithValue("_face_photo_path", savePhotoPath);

                db.OpenConnection();
                sqlCommand.ExecuteNonQuery();
                db.CloseConnection();

                Label_ErrorOrSuccessMessage.Text = "Сохранено успешно!";
            }
            else
            {
                Label_UploadStatus.Text = "Вы не указали файл для загрузки!";
            }
        }

        private string SaveFile(FileUpload fileUpload, string folder_in_the_project)
        {
             string saveFilePath = Server.MapPath(folder_in_the_project) +
                                        fileUpload.FileName;

             FileUpload_FacePhoto.SaveAs(saveFilePath);

             return saveFilePath;
        }

        void Clear()
        {
            Label_ErrorOrSuccessMessage.Text = "";
            Label_UploadStatus.Text = "";
        }
    }
}