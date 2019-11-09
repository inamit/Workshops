using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Country.DataSource = DAL.GetCountries();
            Country.DataTextField = "Country";
            Country.DataBind();

            ListItem chooseCt = new ListItem("Choose country", "choose");
            chooseCt.Attributes.Add("disabled", "disabled");
            Country.Items.Insert(0, chooseCt);

            chooseState.Visible = false;
        } else
        {
            Country.Items[0].Attributes.Add("disabled", "disabled");
        }
    }

    protected void Country_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Country.SelectedIndex != 0)
        {
            string phoneCode = DAL.GetPhoneCode(Country.SelectedValue);
            if (phoneCode[0] != '+')
            {
                phoneCode = '+' + phoneCode;
            }
            if (phoneCode.Contains('/'))
            {
                PhoneCode.Visible = false;
                PhoneCodesList.Visible = true;
                PhoneChoose.Visible = true;
                PhoneCodesList.Items.Clear();
                string[] arr = phoneCode.Split('/');
                for (int i = 0; i < arr.Length; i++)
                {
                    PhoneCodesList.Items.Add(arr[i]);
                }
            }
            else
            {
                PhoneCode.Visible = true;
                PhoneCodesList.Visible = false;
                PhoneChoose.Visible = false;
                PhoneCode.Text = phoneCode;
            }

            if (Country.SelectedValue == "United States")
            {
                State.DataSource = DAL.GetStates();
                State.DataTextField = "MyCode";
                State.DataBind();
                ListItem chooseSt = new ListItem("Choose state", "choose");
                chooseSt.Attributes.Add("disabled", "disabled");
                State.Items.Insert(0, chooseSt);
                chooseState.Visible = true;
                //chooseState.Style["display"] = "block";
            }
            else
            {
                chooseState.Visible = false;
                //chooseState.Style["display"] = "none";
            }
        }
    }

    protected void RegisterBtn_Click(object sender, EventArgs e)
    {
        if (PhoneCodesList.Visible)
        {
            DAL.Register(Email.Text, FName.Text, LName.Text, Password.Text, PhoneCodesList.SelectedValue + Phone.Text, Country.SelectedValue, State.SelectedValue);
        }
        else
        {
            DAL.Register(Email.Text, FName.Text, LName.Text, Password.Text, PhoneCode.Text + Phone.Text, Country.SelectedValue, State.SelectedValue);
        }
    }
}