using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace Yesbd
{
    public partial class home_default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string Date = DatabaseFunctions.Timezone(DateTime.Now).ToString("dd/MM/yyyy");
                }
                else
                {
                    //ddlEmpNM_SelectedIndexChanged(sender, e);
                }

            }
        }
    }
}
