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
    public partial class frmCustomerSaleReport : Form
    {
        public frmCustomerSaleReport()
        {
            InitializeComponent();
        }
        #region Varibables
        POSEntities entity = new POSEntities();
        List<CustomerSaleController> cuslist = new List<CustomerSaleController>();
        int cId = 0; int pId = 0;
        #endregion

        private void frmCustomerSaleReport_Load(object sender, EventArgs e)
        {

            List<APP_Data.Product> ProductList = new List<APP_Data.Product>();
           
            APP_Data.Product pdObj2 = new APP_Data.Product();
            pdObj2.Id = 0;
            pdObj2.Name = "All";         
            ProductList.Add(pdObj2);
            ProductList.AddRange((from plist in entity.Products select plist).ToList());
            cboProductName.DataSource = ProductList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;


            List<APP_Data.Customer> CustomerList = new List<APP_Data.Customer>();
            
            APP_Data.Customer cuObj2 = new APP_Data.Customer();
            cuObj2.Id = 0;
            cuObj2.Name = "All";
           
            CustomerList.Add(cuObj2);
            CustomerList.AddRange((from clist in entity.Customers select clist).ToList());
            cboCustomerName.DataSource = CustomerList;
            cboCustomerName.DisplayMember = "Name";
            cboCustomerName.ValueMember = "Id";
            cboCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.reportViewer1.Refresh();
        }
        private void loadData()
        {
            cId = 0; pId = 0;
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;
            cuslist.Clear();

            if (cboCustomerName.SelectedIndex > 0)
            {
                cId = Convert.ToInt32(cboCustomerName.SelectedValue);
            }
            if (cboProductName.SelectedIndex > 0)
            {
                pId = Convert.ToInt32(cboProductName.SelectedValue);
            }

            System.Data.Objects.ObjectResult<GetCustomerSaleById_Result> resultlist;
            resultlist = entity.GetCustomerSaleById(cId, pId, fromDate, toDate);

            foreach (GetCustomerSaleById_Result r in resultlist)
            {
                CustomerSaleController c = new CustomerSaleController();
                c.CustomerName = r.Customer_Name;
                c.ProductName = r.Product_Name;
                c.Price =Convert.ToInt32(r.UnitPrice);
                c.Qty =Convert.ToInt32(r.Qty);
                c.TotalAmount = Convert.ToInt32(r.Total_Amount);
                c.TransactionId = r.TransactionId.ToString();
                c.SaleDate = Convert.ToDateTime(r.SaleDate);
                cuslist.Add(c);
            }

            ShowReportViewer();
        }
        private void ShowReportViewer()
        {
            string ProductName = "", CustomerName = "";

            dsReportTemp dsReport = new dsReportTemp();           
            dsReportTemp.CustomerSaleReportDataTable dtCustomerSaleReport = (dsReportTemp.CustomerSaleReportDataTable)dsReport.Tables["CustomerSaleReport"];

            foreach (CustomerSaleController r in cuslist)
            {
                dsReportTemp.CustomerSaleReportRow newRow = dtCustomerSaleReport.NewCustomerSaleReportRow();
                newRow.CustomerName = r.CustomerName.ToString();
                newRow.ProductName = r.ProductName.ToString();
                newRow.Price = r.Price.ToString();
                newRow.Qty = Convert.ToInt32(r.Qty);
                newRow.TotalAmount = Convert.ToInt32(r.TotalAmount);
                newRow.TransactionId = r.TransactionId.ToString();
                newRow.SaleDate = r.SaleDate.ToString("dd/MM/yyyy");

                dtCustomerSaleReport.AddCustomerSaleReportRow(newRow);
            }

            if (cId > 0)
            {
               
                APP_Data.Customer c=entity.Customers.Where(x=>x.Id==cId).FirstOrDefault();               
                CustomerName =c.Name;
            }
            else
            {
              CustomerName = "All Customer";
            }
            if (pId > 0)
            {
                APP_Data.Product p = entity.Products.Where(x => x.Id == pId).FirstOrDefault();
                ProductName = p.Name;
            }
            else
            {
                ProductName = "All Product";
            }   

            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["CustomerSaleReport"]);
            string reportPath = Application.StartupPath + "\\Reports\\CustomerSale.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter Header = new ReportParameter("Header", ProductName + "  Of  "+CustomerName + " From " +dtFrom.Value.Date.ToString("dd/MM/yyyy")+"  To  "+dtTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Header);
            reportViewer1.RefreshReport();

           
        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboCustomerName.SelectedIndex = 0;
            cboProductName.SelectedIndex = 0;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }

        private void cboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
       
    }
}
