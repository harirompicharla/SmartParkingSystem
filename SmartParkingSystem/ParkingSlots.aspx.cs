using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartParkingSystem
{
    public partial class ParkingSlots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> list = GetParkingSlotsDetailsFromAPI();
                TotalParkingSlotsLbl.Text = string.Concat(TotalParkingSlotsLbl.Text, list[0]);
                OccupiedParkingSlotsLbl.Text = string.Concat(OccupiedParkingSlotsLbl.Text, list[1]);
                AvailableParkingSlotsLbl.Text = string.Concat(AvailableParkingSlotsLbl.Text, list[2]);
            }
        }

        protected void TotalParkingSlots_ServerClick(object sender, EventArgs e)
        {
            ParkingDetailsGrid.DataSource = GetParkingDetailsFromAPI();
            ParkingDetailsGrid.DataBind();
        }

        protected void OccupiedParkingSlots_ServerClick(object sender, EventArgs e)
        {
            System.Data.DataView dv = new System.Data.DataView(GetParkingDetailsFromAPI());
            dv.RowFilter = "SlotStatus = 'Parked'";
            ParkingDetailsGrid.DataSource = dv.ToTable();
            ParkingDetailsGrid.DataBind();
        }

        protected void AvailableParkingSlots_ServerClick(object sender, EventArgs e)
        {
            System.Data.DataView dv = new System.Data.DataView(GetParkingDetailsFromAPI());            
            dv.RowFilter = "SlotStatus Is NULL";
            ParkingDetailsGrid.DataSource = dv.ToTable();
            ParkingDetailsGrid.DataBind();
        }

        protected void ParkingDetailsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ParkingDetailsGrid.DataSource = GetParkingDetailsFromAPI();
            ParkingDetailsGrid.PageIndex = e.NewPageIndex;
            ParkingDetailsGrid.DataBind();
        }

        private List<string> GetParkingSlotsDetailsFromAPI()
        {
            List<string> list = new List<string>();
            list.Add("50");
            list.Add("30");
            list.Add("20");
            return list;
        }

        private System.Data.DataTable GetParkingDetailsFromAPI()
        {
            System.Data.DataTable dtParkingDetails = new System.Data.DataTable();
            dtParkingDetails.Columns.Add("SlotNo", typeof(string));
            dtParkingDetails.Columns.Add("CustomerName", typeof(string));
            dtParkingDetails.Columns.Add("VehicleNo", typeof(string));
            dtParkingDetails.Columns.Add("Email", typeof(string));
            dtParkingDetails.Columns.Add("Phone", typeof(string));
            dtParkingDetails.Columns.Add("SlotStatus", typeof(string));

            System.Data.DataRow dr = dtParkingDetails.NewRow();
            dr["SlotNo"] = "L0-1";
            dr["CustomerName"] = "Santosh Kumar";
            dr["VehicleNo"] = "MH-04-1122";
            dr["Email"] = "santosh.kumar@gmail.com";
            dr["Phone"] = "98765412345";
            dr["SlotStatus"] = "Parked";
            dtParkingDetails.Rows.Add(dr);

            dr = dtParkingDetails.NewRow();
            dr["SlotNo"] = "L0-2";           
            dtParkingDetails.Rows.Add(dr);

            dr = dtParkingDetails.NewRow();
            dr["SlotNo"] = "L0-3";
            dr["CustomerName"] = "John";
            dr["VehicleNo"] = "MH-12-3242";
            dr["Email"] = "john.j@gmail.com";
            dr["Phone"] = "91254678911";
            dr["SlotStatus"] = "Parked";
            dtParkingDetails.Rows.Add(dr);

            return dtParkingDetails;

        }
    }
}