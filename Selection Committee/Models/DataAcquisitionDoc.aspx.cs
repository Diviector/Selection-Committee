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
    public partial class DataAcquisitionDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Clear();
            }

            if (getDocumenst().Rows.Count > 0) Button_DocSave.Text = "Изменить данные";
        }

        private DataTable getDocumenst()
        {
            Database db = new Database();

            MySqlCommand command = new MySqlCommand("get_doc", db.GetConnection());

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

        protected void Button_DocSave_Click(object sender, EventArgs e)
        {
            try
            {
                addToDocuments();
            }
            catch (Exception ex)
            {
                Label_ErrorOrSuccessMessage.Text = ex.Message;
            }
        }

        private void addToDocuments()
        {
            string appSavePath = "";
            string passSavePath = "";
            string eduSavePath = "";
            string charSavePath = "";
            string medSavePath = "";

            DataTable table = getDocumenst();

            if (Button_DocSave.Text == "Изменить данные")
            {
                if (FileUpload_Application.HasFile)
                {
                    appSavePath = SaveFile(FileUpload_Application, "~/Data_Of_Enrollee/Documents/");
                }
                else
                {
                    appSavePath = table.Rows[0][0].ToString();
                }

                if (FileUpload_Character.HasFile)
                {
                    charSavePath = SaveFile(FileUpload_Character, "~/Data_Of_Enrollee/Documents/");
                }
                else
                {
                    charSavePath = table.Rows[0][3].ToString();
                }

                if (FileUpload_EduDoc.HasFile)
                {
                    eduSavePath = SaveFile(FileUpload_EduDoc, "~/Data_Of_Enrollee/Documents/");
                }
                else
                {
                    eduSavePath = table.Rows[0][2].ToString();
                }

                if (FileUpload_MedStatement.HasFile)
                {
                    medSavePath = SaveFile(FileUpload_MedStatement, "~/Data_Of_Enrollee/Documents/");
                }
                else
                {
                    medSavePath = table.Rows[0][4].ToString();
                }

                if (FileUpload_Passport.HasFile)
                {
                    passSavePath = SaveFile(FileUpload_Passport, "~/Data_Of_Enrollee/Documents/");
                }
                else
                {
                    passSavePath = table.Rows[0][1].ToString();
                }
            }
            else
            {
                if (!(FileUpload_Application.HasFile
                    || FileUpload_Character.HasFile 
                    || FileUpload_EduDoc.HasFile
                    || FileUpload_MedStatement.HasFile
                    || FileUpload_Passport.HasFile))
                {
                    throw new Exception("Должны быть указаны все файлы");
                }
                appSavePath = SaveFile(FileUpload_Application, "~/Data_Of_Enrollee/Documents/");
                charSavePath = SaveFile(FileUpload_Character, "~/Data_Of_Enrollee/Documents/");
                eduSavePath = SaveFile(FileUpload_EduDoc, "~/Data_Of_Enrollee/Documents/");
                medSavePath = SaveFile(FileUpload_MedStatement, "~/Data_Of_Enrollee/Documents/");
                passSavePath = SaveFile(FileUpload_Passport, "~/Data_Of_Enrollee/Documents/");
            }

            Database db = new Database();

            MySqlCommand sqlCommand = new MySqlCommand("add_or_edit_doc", db.GetConnection());

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("_username", Classes.User.getUsername());
            sqlCommand.Parameters.AddWithValue("_application", appSavePath);
            sqlCommand.Parameters.AddWithValue("_passport", passSavePath);
            sqlCommand.Parameters.AddWithValue("_education_document", eduSavePath);
            sqlCommand.Parameters.AddWithValue("_characterization", charSavePath);
            sqlCommand.Parameters.AddWithValue("_medical_statement", medSavePath);

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