using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Selection_Committee.Models
{
    public partial class DataAcquisition : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost;Database=data_of_enrollee;Uid=XD0;Pwd=8Q}McX0gIdtP2c{8;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList.DataSource = MultiView.Views;
                DropDownList.DataTextField = "ID";
                DropDownList.DataBind();

                MultiView.ActiveViewIndex = DropDownList.SelectedIndex;

                Clear();
            }
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = DropDownList.SelectedIndex;
        }

        protected void Button_BasicSave_Click(object sender, EventArgs e)
        {
            try
            {
                String savePhotoPath = Server.MapPath("~/Data_Of_Enrollee/Face_Photos/");

                if (FileUpload_FacePhoto.HasFile)
                {
                    String fileName = FileUpload_FacePhoto.FileName;

                    savePhotoPath += fileName;

                    FileUpload_FacePhoto.SaveAs(savePhotoPath);

                    Label_UploadStatus.Text = "Your file was saved as " + fileName;

                    using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        MySqlCommand sqlCommand = new MySqlCommand("basic_data_add_or_edit", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("_basic_data_ID", Convert.ToInt32(HiddenField_ID.Value == "" ? "0" : HiddenField_ID.Value));
                        sqlCommand.Parameters.AddWithValue("_last_name", TextBox_Lastname.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_first_name", TextBox_Firstnane.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_patronymic", TextBox_Patronymic.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_date_of_birth", TextBox_DateOfBirth.Text.Replace('-', '.').Trim());
                        sqlCommand.Parameters.AddWithValue("_gender", RadioButtonList_Gender.SelectedValue.Trim());
                        sqlCommand.Parameters.AddWithValue("_kind_of_document", TextBox_KindOfDocument.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_citizenship", TextBox_Сitizenship.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_registration_address", TextBox_RegistrationAddress.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_residential_address", TextBox_ResidentialAddress.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("_date_of_filing_in", TextBox_DateOfFillingIn.Text.Replace('-', '.').Trim());
                        sqlCommand.Parameters.AddWithValue("_face_photo_path", savePhotoPath);
                        sqlCommand.ExecuteNonQuery();

                        Label_ErrorOrSuccessMessage.Text = "Submitted Saccessfully";
                    }
                }
                else
                {
                    Label_UploadStatus.Text = "You did not specify a file to upload.";
                }
            }
            catch (Exception ex)
            {
                Label_ErrorOrSuccessMessage.Text = ex.Message;
            }
        }

        void Clear()
        {
            HiddenField_ID.Value = "";
            Label_ErrorOrSuccessMessage.Text = "";
            Label_UploadStatus.Text = "";
        }
    }
}