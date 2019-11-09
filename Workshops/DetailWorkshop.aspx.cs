using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class DetailWorkshop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbDataReader dr = DAL.GetWorkshopBy(Request.QueryString["w"]);
    }
}