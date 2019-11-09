using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowWorkshops : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = DAL.GetWorkshops();
        if (!IsPostBack)
        {
            WList.DataSource = ds;
            WList.DataBind();
            
        }
    }

    protected void WList_SelectedIndexChanged(object sender, EventArgs e)
    {
        myDetailName.InnerText = ds.Tables[0].Rows[WList.SelectedIndex]["MyName"].ToString();
        myDetailDesc.InnerText = ds.Tables[0].Rows[WList.SelectedIndex]["MyDescription"].ToString();
        string units = "";
        string[] divided = ds.Tables[0].Rows[WList.SelectedIndex]["MyUnits"].ToString().Split(',');
        for (int i = 0; i < divided.Length - 1; i++)
        {
            switch (divided[i])
            {
                case "N":
                    units += "Nanobyte, ";
                    break;
                case "K":
                    units += "Kilobyte, ";
                    break;
                case "M":
                    units += "Megabyte, ";
                    break;
                case "G":
                    units += "Gigabyte, ";
                    break;
                default:
                    break;
            }
        }

        switch (divided[divided.Length - 1])
        {
            case "N":
                units += "Nanobyte";
                break;
            case "K":
                units += "Kilobyte";
                break;
            case "M":
                units += "Megabyte";
                break;
            case "G":
                units += "Gigabyte";
                break;
            default:
                break;
        }

        myDetailUnits.InnerText = units;

        string needs = "";
        string[] dividedNeeds = ds.Tables[0].Rows[WList.SelectedIndex]["MyCamperNeeds"].ToString().Split(',');
        for (int i = 0; i < dividedNeeds.Length; i++)
        {
            needs += "<li>" + dividedNeeds[i] + "</li>";
        }
        myDetailNeeds.InnerHtml = needs;
        myModal.Style.Add("display", "block");
    }
}