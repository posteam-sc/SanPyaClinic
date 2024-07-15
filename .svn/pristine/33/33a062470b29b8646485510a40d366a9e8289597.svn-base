using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using POS.APP_Data;

namespace POS
{
    public partial class FrmCustomerInfomation : Form
    {
        public FrmCustomerInfomation()
        {
            InitializeComponent();
        }
        APP_Data.POSEntities entity = new APP_Data.POSEntities();
        List<APP_Data.Customer> cusList = new List<APP_Data.Customer>();

        private void FrmCustomerInfomation_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            cusList.Clear();
            cusList = entity.Customers.ToList();
            ShowReportViewer();
        }

        private void ShowReportViewer()
        {

            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.CustomerInformationDataTable dtCustomerReport = (dsReportTemp.CustomerInformationDataTable)dsReport.Tables["CustomerInformation"];
            foreach (Customer c in cusList)
            {
                dsReportTemp.CustomerInformationRow newRow = dtCustomerReport.NewCustomerInformationRow();
                newRow.Name = c.Name + "," + c.Title;
                newRow.Birthday = (c.Birthday == null) ? "-" : c.Birthday.Value.Date.ToString("dd/MM/yyyy");
                newRow.Gender = (c.Gender == "") ? "-" : c.Gender;
                newRow.NRC = (c.NRC == null || c.NRC == "") ? "-" : c.NRC;
                newRow.PhNo = (c.PhoneNumber == "" || c.PhoneNumber == "") ? "-" : c.PhoneNumber;
                newRow.Email = (c.Email == null || c.Email == "") ? "-" : c.Email;
                newRow.Address = (c.Address == null || c.Address == "") ? "-" : c.Address;
               // newRow.TownShip = (c.Townshipdb.TownshipName == null || c.Townshipdb.TownshipName == "") ? "-" : c.Townshipdb.TownshipName;

                //newRow.TownShip = "";
                string townshopname = (from p in entity.Townshipdbs where p.Id ==c.TownShipId select p.TownshipName).FirstOrDefault();
                newRow.TownShip = (townshopname == null || townshopname == "") ? "-" : townshopname;
                newRow.City = (c.City.CityName == null || c.City.CityName == "") ? "-" : c.City.CityName;

                dtCustomerReport.AddCustomerInformationRow(newRow);
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["CustomerInformation"]);
            string reportPath = string.Empty;
            reportPath = Application.StartupPath + "\\Reports\\AllMemberInformation.rdlc";

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

    }
}
