<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowWorkshops.aspx.cs" Inherits="ShowWorkshops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--Card CSS--%>
    <style>
        .card {
          box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
          transition: 0.3s;
          border-radius: 5px; /* 5px rounded corners */
          width: 250px;
          height: 325px;
        }
        /* On mouse-over, add a deeper shadow */
        .card:hover {
          box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
        }

        /* Add rounded corners to the top left and the top right corner of the image */
        img {
          border-radius: 5px 5px 0 0;
        }
        /* Add some padding inside the card container */
        .container {
          padding: 2px 16px;
        }
        * {
          box-sizing: border-box;
        }

        body {
          font-family: Arial, Helvetica, sans-serif;
        }

        /* Float four columns side by side */
        .column {
          float: left;
          width: 25%;
          padding: 0 10px;
        }

        /* Remove extra left and right margins, due to padding in columns */
        .row {margin: 0 -5px;}

        /* Clear floats after the columns */
        .row:after {
          content: "";
          display: table;
          clear: both;
        }

        /* Responsive columns - one column layout (vertical) on small screens */
        @media screen and (max-width: 600px) {
          .column {
            width: 100%;
            display: block;
            margin-bottom: 20px;
          }
        }

        .cut-text { 
          text-overflow: ellipsis;
          overflow: hidden; 
          width: 220px; 
          height: 1.3em; 
          white-space: nowrap;
        }
    </style>
    <%--Modal css--%>
    <style>
        /* The Modal (background) */
        .modal {
          display: none; /* Hidden by default not server */
          position: fixed; /* Stay in place */
          z-index: 1; /* Sit on top */
          left: 0;
          top: 0;
          width: 100%; /* Full width */
          height: 100%; /* Full height */
          overflow: auto; /* Enable scroll if needed */
          background-color: rgb(0,0,0); /* Fallback color */
          background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content/Box */
        /*.modal-content {
          background-color: #fefefe;
          margin: 15% auto; /* 15% from the top and centered */
          /*padding: 20px;
          border: 1px solid #888;
          width: 80%; /* Could be more or less, depending on screen size 
        }*/

        /* The Close Button */
        .close {
          color: #aaa;
          float: right;
          font-size: 28px;
          font-weight: bold;
        }

        .close:hover,
        .close:focus {
          color: black;
          text-decoration: none;
          cursor: pointer;
        }
        /* Modal Header */
        .modal-header {
          padding: 2px 16px;
          background-color: #5cb85c;
          color: white;
        }

        /* Modal Body */
        .modal-body {padding: 2px 16px;}

        /* Modal Footer */
        .modal-footer {
          padding: 2px 16px;
          background-color: #5cb85c;
          color: white;
        }

        /* Modal Content */
        .modal-content {
          position: relative;
          background-color: #fefefe;
          margin: auto;
          padding: 0;
          border: 1px solid #888;
          width: 80%;
          box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
          animation-name: animatetop;
          animation-duration: 0.4s
        }

        /* Add Animation */
        @keyframes animatetop {
          from {top: -300px; opacity: 0}
          to {top: 0; opacity: 1}
        }

    </style>

    <script>
        var modal = document.getElementById("ContentPlaceHolder1_myModal");
        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function(event) {
            if (event.target == document.getElementById("ContentPlaceHolder1_myModal")) {
                document.getElementById("ContentPlaceHolder1_myModal").style.display = "none";
          }
        }
        function show() {
            modal.style.display = "block";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DataList CellSpacing="10" ID="WList" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="WList_SelectedIndexChanged">
                <ItemTemplate>
                    <div class="card">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# string.Format("imgs/{0}", DataBinder.Eval(Container.DataItem, "MyImage")) %>' Width="100%" Height="200" />
                        <div class="container">
                            <h4 class="cut-text"><b><%# DataBinder.Eval(Container.DataItem, "MyName") %></b></h4> 
                            <p class="cut-text"><%# DataBinder.Eval(Container.DataItem, "MyDescription") %></p>
                            <asp:LinkButton ID="Details" runat="server" CommandName="Select" Text="Click here for more details"></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>

            <div id="myModal" runat="server" class="modal">

              <!-- Modal content -->
              <div class="modal-content">
                <div class="modal-header">
                    <h2 runat="server" id="myDetailName">Error</h2>
                    <span class="close" id="closeBtn" onclick="this.parentElement.parentElement.parentElement.style.display='none';">&times;</span>
                  </div>
                  <div class="modal-body">
                    <p runat="server" id="myDetailDesc">There was a problem</p>
                    <b>For units:</b> <p runat="server" id="myDetailUnits">Couldn't load units.</p>
                      <b>In order to be in this workshop, the camper need to have:</b> <ul runat="server" id="myDetailNeeds"></ul>
                  </div>
                  <div class="modal-footer">
                    <h3></h3>
                  </div>
              </div>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostbackTrigger ControlID="WList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

