using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssignmentBAIT2113
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control MyControl = (Control)LoadControl("loginForm.ascx");
            PlaceHolder1.Controls.Add(MyControl);
           
        }
    }
}