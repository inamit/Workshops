using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ShowWorkshopsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WorkList.DataSource = DAL.GetWorkshops();
        WorkList.DataBind();
    }

    protected void WorkList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            bool deleted = DAL.DeleteWorkshop(e.CommandArgument.ToString());
            if (deleted)
            {
                Response.Write("Workshop deleted");
            }
            else
            {
                Response.Write("Workshop couldn't be deleted");
            }
            Response.Redirect("ShowWorkshopsAdmin.aspx");
        }
        
    }
}