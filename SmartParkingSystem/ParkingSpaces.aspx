<%@ Page Title="Parking Spaces" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParkingSpaces.aspx.cs" Inherits="SmartParkingSystem.ParkingSpaces" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div>
        <h1>Parking Spaces</h1>
    </div>

    <div class="row">
        <a href="ParkingSpaces.aspx" class="col-md-2 jumbotron" style="border-radius: 25px;">            
                <h4>Total Parking Spaces
                </h4>            
        </a>

        <a href="ParkingSlots.aspx" class="col-md-2 jumbotron" style="border-radius: 25px;">
            <h4>Occupied Parking Spaces
                </h4>            
        </a>
        <a href="#" class="col-md-2 jumbotron" style="border-radius: 25px;">            
                <h4>Available Parking Spaces
                </h4>            
        </a>
    </div>
</asp:Content>