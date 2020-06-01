using System;
using System.Collections.Generic;
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
            for (int i = DateTime.Today.Year; i > 1900; i--)
            {
                ListBox_YearOfGrad.Items.Add(i.ToString());
            }
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

        }
    }
}