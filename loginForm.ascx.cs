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
    public partial class home : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ArtworkCon"].ToString();
            Session["Role"] = "";
            if (!Page.IsPostBack)
            {

                if (Request.Cookies["UserInfo"] != null)
                {
                    HttpCookie authCookie = Request.Cookies["UserInfo"];

                    if (authCookie["Username"] == null || authCookie["remember"] == "False")
                    {
                        lblLogin.Text = authCookie["remember"];
                        authCookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(authCookie);
                        FormsAuthentication.SignOut();
                        Response.Redirect("Login.aspx");
                        return;
                    }

                    Session["Username"] = authCookie["Username"];
                    string role = "";
                    con.Open();
                    string sql = "SELECT * FROM Account WHERE Username=@username";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", Session["Username"].ToString());
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            Session["UserId"] = reader1.GetValue(0).ToString();
                            role = reader1.GetValue(3).ToString();
                            Session["Role"] = role;
                        }
                        reader1.Close();
                        con.Close();
                    }
                    security.LoginUser(Session["Username"].ToString(), role, true);
                }
                else
                {
                    FormsAuthentication.SignOut();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = txtLogin.Text;
                string password = security.GetHash(txtPassword.Text);
                string role = "";
                bool rememberMe = chkRememberMe.Checked;
                //lblLogin.Text = rememberMe.ToString();
                con.Open();
                string sql = "SELECT * FROM Account WHERE Username=@username AND Password=@password";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader1 = cmd.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        Session["UserId"] = reader1.GetValue(0).ToString();
                        Session["Username"] = username;
                        role = reader1.GetValue(3).ToString();
                        Session["Role"] = role;
                    }
                    reader1.Close();
                    con.Close();
                    security.LoginUser(username, role, rememberMe);
                }
                else
                {
                    cvNotMatched.IsValid = false;
                }


            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }
    }
}