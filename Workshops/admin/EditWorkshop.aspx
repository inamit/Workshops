<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditWorkshop.aspx.cs" Inherits="admin_EditWorkshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
function ValidateFileUpload(Source, args)
{
  var fuData = document.getElementById('<%= MyImage.ClientID %>'); 
  var FileUploadPath = fuData.value;
 
  if(FileUploadPath =='') 
  {
    // There is no file selected 
    args.IsValid = false;
  }
  else
  {
    var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

      if (Extension == "jpg" || Extension == "png" || Extension == "jpeg")
    {
      args.IsValid = true; // Valid file type
    }
    else
    {
      args.IsValid = false; // Not valid file type
    }
   }
}
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="MyName" placeholder="Workshop name" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="MyDescription" placeholder="Workshop description" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label">Choose units for the workshop:</asp:Label>
    <asp:CheckBoxList ID="Units" runat="server">
        <asp:ListItem Value="N">Nanobyte</asp:ListItem>
        <asp:ListItem Value="K">Kilobyte</asp:ListItem>
        <asp:ListItem Value="M">Megabyte</asp:ListItem>
        <asp:ListItem Value="G">Gigabyte</asp:ListItem>
    </asp:CheckBoxList>
    <asp:Label ID="Label2" runat="server" Text="Label">Choose your needs from the lab:</asp:Label>
    <asp:CheckBoxList ID="RoomNeeds" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RoomNeeds_SelectedIndexChanged">
    </asp:CheckBoxList>
    <asp:TextBox ID="OtherRoomNeed" placeholder="Other room needs (seperated by commas and no spaces after/before)" runat="server" Visible="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Label">Choose your needs from the campers:</asp:Label>
    <asp:CheckBoxList ID="CampersNeeds" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CampersNeeds_SelectedIndexChanged">
    </asp:CheckBoxList>
    <asp:TextBox ID="OtherCampersNeed" placeholder="Other campers needs (seperated by commas and no spaces after/before)" runat="server" Visible="False"></asp:TextBox>
    <br />
    <asp:FileUpload ID="MyImage" runat="server" /><asp:CustomValidator ID="ImageValidation" runat="server" ErrorMessage="Please select valid .png or .jpg (.jpeg) file" ClientValidationFunction="ValidateFileUpload" ControlToValidate="MyImage"></asp:CustomValidator>
    <br />
    <asp:CheckBox ID="Existing" runat="server" Text="Select from existing image" AutoPostBack="True" OnCheckedChanged="Existing_CheckedChanged" />
    <br />
    <div id="ExistingChose" Visible="false" runat="server">
    <asp:DropDownList ID="MyExistingImages" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MyExistingImages_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="previewLbl" runat="server" Text="Preview:"></asp:Label>
    <br />
    <asp:Image ID="MyImagePreview" runat="server" Height="200px" Width="200px" />
        </div>
    <br />
    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
</asp:Content>

