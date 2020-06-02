using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Selection_Committee.Models
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton_Agreement_Click(object sender, EventArgs e)
        {
            //Пользователь скачивает файл соглашения
            Response.Clear();
            Response.ContentType = "application/msword";
            Response.AddHeader("content-disposition", "attachment; filename=Agreement.doc");
            Response.TransmitFile(Server.MapPath("~/App_Data/Agreement.doc"));
            Response.End();
        }

        protected void CheckBox_Consent_CheckedChanged(object sender, EventArgs e)
        {
            Button_Further.Enabled = !Button_Further.Enabled;
        }

        protected void Button_Further_Click(object sender, EventArgs e)
        {
            Classes.User.setAgreementTrue();
            Response.Redirect("DataAcquisitionBasic.aspx");
        }
    }
}