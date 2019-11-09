using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddWorkshop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RoomNeeds.DataSource = DAL.GetRoomNeeds();
            RoomNeeds.DataTextField = "MyNeed";
            RoomNeeds.DataValueField = "MyNeed";
            RoomNeeds.DataBind();
            RoomNeeds.Items.Add("Other");

            CampersNeeds.DataSource = DAL.GetCampersNeeds();
            CampersNeeds.DataTextField = "MyNeed";
            CampersNeeds.DataValueField = "MyNeed";
            CampersNeeds.DataBind();
            CampersNeeds.Items.Add("Other");
        }
    }

    protected void RoomNeeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RoomNeeds.Items.FindByValue("Other").Selected)
        {
            OtherRoomNeed.Visible = true;
        }
        else
        {
            OtherRoomNeed.Visible = false;
        }
    }

    protected void CampersNeeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CampersNeeds.Items.FindByValue("Other").Selected)
        {
            OtherCampersNeed.Visible = true;
        }
        else
            OtherCampersNeed.Visible = false;
    }

    protected void AddBtn_Click(object sender, EventArgs e)
    {
        string units = "", roomNeeds = "", campersNeeds = "";
        foreach (ListItem item in Units.Items)
        {
            if (item.Selected)
                units += item.Value + ",";
        }
        if (units[units.Length - 1] == ',')
            units = units.Substring(0, units.Length - 1);

        foreach (ListItem item in RoomNeeds.Items)
        {
            if (item.Selected)
                roomNeeds += item.Value + ",";
        }
        if (!string.IsNullOrEmpty(OtherRoomNeed.Text))
        {
            string[] arr = OtherRoomNeed.Text.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                DAL.AddRoomNeeds(arr[i]);
            }
            roomNeeds += OtherRoomNeed.Text;
        }
        else if (roomNeeds[roomNeeds.Length - 1] == ',')
            roomNeeds = roomNeeds.Substring(0, roomNeeds.Length - 1);

        foreach (ListItem item in CampersNeeds.Items)
        {
            if (item.Selected)
                campersNeeds += item.Value + ",";
        }
        if (!string.IsNullOrEmpty(OtherCampersNeed.Text))
        {
            string[] arr = OtherCampersNeed.Text.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                DAL.AddCampersNeeds(arr[i]);
            }
            campersNeeds += OtherCampersNeed.Text;
        }
        else if (campersNeeds[campersNeeds.Length - 1] == ',')
            campersNeeds = campersNeeds.Substring(0, campersNeeds.Length - 1);

        if (MyImage.HasFile)
        {
            MyImage.SaveAs(Server.MapPath("../imgs/" + MyImage.FileName));
            DAL.AddWorkshop(MyName.Text, MyDescription.Text, units, roomNeeds, campersNeeds, MyImage.FileName);
        }
        else
        {
            DAL.AddWorkshop(MyName.Text, MyDescription.Text, units, roomNeeds, campersNeeds, "Workshop.jpg");
        }
    }
}