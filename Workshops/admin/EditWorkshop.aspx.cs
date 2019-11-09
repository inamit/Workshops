using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class admin_EditWorkshop : System.Web.UI.Page
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

            OleDbDataReader dr = DAL.GetWorkshopBy(Request.QueryString["wId"]);
            dr.Read();
            MyName.Text = dr["MyName"].ToString();
            MyDescription.Text = dr["MyDescription"].ToString();
            string[] unitsArr = dr["MyUnits"].ToString().Split(',');
            for (int i = 0; i < unitsArr.Length; i++)
            {
                Units.Items.FindByValue(unitsArr[i]).Selected = true;
            }

            string[] roomArr = dr["MyRoomNeeds"].ToString().Split(',');
            for (int i = 0; i < roomArr.Length; i++)
            {
                RoomNeeds.Items.FindByValue(roomArr[i]).Selected = true;
            }
            string[] campersArr = dr["MyCamperNeeds"].ToString().Split(',');
            for (int i = 0; i < campersArr.Length; i++)
            {
                CampersNeeds.Items.FindByValue(campersArr[i]).Selected = true;
            }

            DAL.CloseConnection();
            string[] files = System.IO.Directory.GetFiles(Server.MapPath("../imgs"));
            string[] pics = new string[files.Length];
            int index = 0;
            foreach (string file in files)
            {
                System.IO.FileInfo info = new System.IO.FileInfo(file);
                string fileName = System.IO.Path.GetFileName(info.FullName);
                pics[index] = fileName;
                index++;
            }
            MyExistingImages.DataSource = pics;
            MyExistingImages.DataBind();
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

    protected void UpdateBtn_Click(object sender, EventArgs e)
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

        if (Existing.Checked)
        {
            DAL.EditWorkshop(MyName.Text, MyDescription.Text, units, roomNeeds, campersNeeds, MyExistingImages.SelectedValue, Request.QueryString["wId"].ToString());
        }
        else
        {
            if (MyImage.HasFile)
            {
                MyImage.SaveAs(Server.MapPath("../imgs/" + MyImage.FileName));
                DAL.EditWorkshop(MyName.Text, MyDescription.Text, units, roomNeeds, campersNeeds, MyImage.FileName, Request.QueryString["wId"].ToString());
            }
            else
            {
                DAL.EditWorkshop(MyName.Text, MyDescription.Text, units, roomNeeds, campersNeeds, Request.QueryString["wId"].ToString());
            }
        }
        
    }

    protected void MyExistingImages_SelectedIndexChanged(object sender, EventArgs e)
    {
        MyImagePreview.ImageUrl = "../imgs/" + MyExistingImages.SelectedValue;
    }

    protected void Existing_CheckedChanged(object sender, EventArgs e)
    {
            ExistingChose.Visible = Existing.Checked;

            MyImage.Visible = !Existing.Checked;
            ImageValidation.Visible = !Existing.Checked;
    }
}