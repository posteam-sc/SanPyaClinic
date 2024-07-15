using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;
using Microsoft.Reporting.WinForms;
using System.Data.Objects;

namespace POS
{
    public partial class ConsignmentProductReport : Form
    {
        public ConsignmentProductReport()
        {
            InitializeComponent();
            CenterToScreen();
        }

        #region variable

        POSEntities entity = new POSEntities();
        List<ConsignmentController> conlist = new List<ConsignmentController>();
        int totalcost, totalqty;
        string counterName;
        string CheckPrice;

        #endregion    

        #region Function
        public void BindCounter()
        {
            List<APP_Data.ConsignmentCounter> consignList = new List<APP_Data.ConsignmentCounter>();
            APP_Data.ConsignmentCounter conObj = new APP_Data.ConsignmentCounter();
            conObj.Id = 0;
            conObj.Name = "Select";
            consignList.Add(conObj);
            consignList.AddRange((from clist in entity.ConsignmentCounters select clist).ToList());
            cboCounter.DataSource = consignList;
            cboCounter.DisplayMember = "Name";
            cboCounter.ValueMember = "Id";
            cboCounter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCounter.AutoCompleteSource = AutoCompleteSource.ListItems;   
        }

        private void ShowReportViwer()
        {
            if (cboCounter.SelectedIndex > 0)
            {
                counterName = cboCounter.Text.ToString();
            }
            else
            {
                counterName = "All Counter"; 
            }

            if (rdoUnitPrice.Checked)
            {
                CheckPrice = "Unit Price";
            }
            else
            {
                CheckPrice = "Sale True Price";
            }

            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.Consignment_ProductDataTable dtConsignment = (dsReportTemp.Consignment_ProductDataTable)dsReport.Tables["Consignment Product"];
            foreach (ConsignmentController cgnCon in conlist)
            {
                dsReportTemp.Consignment_ProductRow newRow = dtConsignment.NewConsignment_ProductRow();
                newRow.Name = cgnCon.Name;
                newRow.Qty = cgnCon.Qty.ToString();
                newRow.Price = cgnCon.Price.ToString();
                newRow.Total = cgnCon.Total.ToString();
                newRow.Counter = cgnCon.counter.ToString();
                dtConsignment.AddConsignment_ProductRow(newRow);
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["Consignment Product"]);
            string reportPath = Application.StartupPath + "\\Reports\\ConsignmentProduct.rdlc";

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter totalQty = new ReportParameter("totalQty", totalqty.ToString());
            reportViewer1.LocalReport.SetParameters(totalQty);

            ReportParameter totalCost = new ReportParameter("totalCost", totalcost.ToString());
            reportViewer1.LocalReport.SetParameters(totalCost);

            ReportParameter Header = new ReportParameter("Header", "Consignment report for " +  counterName + " from " + dtpFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpTo.Value.Date.ToString("dd/MM/yyyy")+ " With " + CheckPrice);
            reportViewer1.LocalReport.SetParameters(Header);
            reportViewer1.RefreshReport();
        }

        private void loadData()
        {
            DateTime fromdate = dtpFrom.Value.Date;
            DateTime todate = dtpTo.Value.Date;
            int conId=0;
            totalqty = 0;
            totalcost = 0;
            counterName = "";
            int Dis = 0;
             int  tax = 0;
            
            conlist.Clear();

            if (cboCounter.SelectedIndex > 0)
            {
                conId = Convert.ToInt32(cboCounter.SelectedValue);
            }

            System.Data.Objects.ObjectResult<GetConsignmentProduct_Result> conResult = entity.GetConsignmentProduct(fromdate, todate,conId);
            foreach (GetConsignmentProduct_Result cr in conResult)
            {
                if (cr.IsDeleted != true)
                {
                    ConsignmentController cgnObj = new ConsignmentController();                   
                    cgnObj.Name = cr.Name;
                    cgnObj.Qty = Convert.ToInt32(cr.Qty);

                    if (rdoSaleTruePrice.Checked)
                    {
                        Dis = Convert.ToInt32(cr.UnitPrice / 100) * Convert.ToInt32(cr.DiscountRate);
                        tax = Convert.ToInt32(cr.UnitPrice / 100) * Convert.ToInt32(cr.TaxRate);
                        cgnObj.Price = Convert.ToInt32((cr.UnitPrice - Dis) + tax);
                        cgnObj.Total = Convert.ToInt32(cgnObj.Price *cgnObj.Qty);
                    }
                    else
                    {
                        cgnObj.Price = Convert.ToInt32(cr.UnitPrice);
                        cgnObj.Total = Convert.ToInt32(cr.UnitPrice * cr.Qty);
                    }  
                    cgnObj.counter = cr.Counter_Name;
                    totalcost += Convert.ToInt32(cr.TotalAmount);

                    totalqty += cgnObj.Qty = Convert.ToInt32(cr.Qty);
                    conlist.Add(cgnObj); 
                }
            }

            ShowReportViwer();
        }
        #endregion

        #region Event

        private void ConsignmentProductReport_Load(object sender, EventArgs e)
        {
            BindCounter();
            loadData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cboCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
        #endregion

        private void rdoUnitPrice_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }



    }
}

 