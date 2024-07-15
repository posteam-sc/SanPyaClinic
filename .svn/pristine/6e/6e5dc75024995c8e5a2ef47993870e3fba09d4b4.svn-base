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
    public partial class frmDoctorPaymentReport : Form
    {
        POSEntities entity = new POSEntities();
        int counterId;
        List<DoctorPaymentForDate> plist = new List<DoctorPaymentForDate>();

        public frmDoctorPaymentReport()
        {
            InitializeComponent();
        }

        private void frmDoctorPaymentReport_Load(object sender, EventArgs e)
        {
            ReloadDoctorList();
            rdoAll.Checked = true;
            
            loadData();
        }
        public void ReloadDoctorList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.DoctorPhysio> DoctorPhysiorList = new List<APP_Data.DoctorPhysio>();
            APP_Data.DoctorPhysio doctorPhysio = new APP_Data.DoctorPhysio();
            doctorPhysio.Id = 0;
            doctorPhysio.Name = "None";
            DoctorPhysiorList.Add(doctorPhysio);
            DoctorPhysiorList.AddRange((from p in entity.DoctorPhysios where p.IsDoctor == true select p).ToList());
            cboDoctor.DataSource = DoctorPhysiorList;
            cboDoctor.DisplayMember = "Name";
            cboDoctor.ValueMember = "Id";
        }
        public void loadData()
        {
            plist.Clear();
             counterId = 0;

            DateTime fromDate = dtFrom.Value;
            DateTime toDate = dtTo.Value;
           
            if (rdoCounterName.Checked)
            {
                if (cboDoctor.SelectedIndex > 0)
                {
                    counterId = Convert.ToInt32(cboDoctor.SelectedValue);
                }

            }
            if (counterId > 0)
            {
                System.Data.Objects.ObjectResult<GetDoctorFeesByDateRate_Result> prlist = entity.GetDoctorFeesByDateRate(counterId,fromDate, toDate,"");
                foreach (GetDoctorFeesByDateRate_Result pr in prlist)
                {
                    DoctorPaymentForDate pfl = new DoctorPaymentForDate();
                    var items = entity.GetConsultantfeesDoctorFeesByDateRate(pr.DoctorID, fromDate, toDate);
                    int Cfees = 0;
                    foreach (var i in items)
                    {
                        Cfees += Convert.ToInt32(i.Consultantfees);
                        pfl.NoP += Convert.ToInt32(i.NoofPatient);
                    }
                    pfl.Consultantfees = Cfees;

                    //pfl.Consultantfees = pr.Consultantfees;
                    pfl.Injection = Convert.ToInt64(pr.Injection);
                    pfl.XRay = Convert.ToInt64(pr.XRay);
                    pfl.PT = Convert.ToInt64(pr.Physio);
                    pfl.Name =pr.Name;
                    pfl.TotalAmount = Convert.ToInt64(pfl.Consultantfees) + Convert.ToInt64(pr.Injection) + Convert.ToInt64(pr.Physio) + Convert.ToInt64(pr.XRay);
                    plist.Add(pfl);
                }
            }
            else
            {
                System.Data.Objects.ObjectResult<GetDoctorFeesByDateRate_Result> prlist = entity.GetDoctorFeesByDateRate(counterId, fromDate, toDate, "All");

                foreach (GetDoctorFeesByDateRate_Result pr in prlist)
                {
                    DoctorPaymentForDate pfl = new DoctorPaymentForDate();
                    var items = entity.GetConsultantfeesDoctorFeesByDateRate(pr.DoctorID, fromDate, toDate);
                    int Cfees = 0;
                    foreach (var i in items)
                    {
                        Cfees += Convert.ToInt32(i.Consultantfees);
                       pfl.NoP += Convert.ToInt32(i.NoofPatient);
                    }
                    pfl.Consultantfees = Cfees;
                    //pfl.Consultantfees = pr.Consultantfees;
                    pfl.Injection = Convert.ToInt64(pr.Injection);
                    pfl.XRay = Convert.ToInt64(pr.XRay);
                    pfl.PT = Convert.ToInt64(pr.Physio);
                    pfl.Name = pr.Name;
                    pfl.TotalAmount = Convert.ToInt64(pfl.Consultantfees) + Convert.ToInt64(pr.Injection) + Convert.ToInt64(pr.Physio) + Convert.ToInt64(pr.XRay);
                    plist.Add(pfl);
                }
            }

            ShowReportViewer();
        }
        
        private void cboDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
        private void ShowReportViewer()
        {
         

            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.DoctorDateDataTable dtPdReport = (dsReportTemp.DoctorDateDataTable)dsReport.Tables["DoctorDate"];
            foreach (DoctorPaymentForDate pdCon in plist)
            {
                dsReportTemp.DoctorDateRow newRow = dtPdReport.NewDoctorDateRow();
                newRow.DoctorName = pdCon.Name.ToString();
                newRow.ConsultantFees = pdCon.Consultantfees.ToString();
                newRow.InjectionFees = pdCon.Injection.ToString();
                newRow.XRay = pdCon.XRay.ToString();
                newRow.PhysioFees = pdCon.PT.ToString();
                newRow.TotalAmount = pdCon.TotalAmount;
                newRow.NumberofPaitent = pdCon.NoP.ToString();
                dtPdReport.AddDoctorDateRow(newRow);
            }
            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["DoctorDate"]);
            string reportPath = Application.StartupPath + "\\Reports\\rdlcDoctorDate.rdlc";

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter Date = new ReportParameter("Date", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);

            ReportParameter TransactionTitle = new ReportParameter("TransactionTitle", "Doctor Payment Report at " + DateTime.Now.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(TransactionTitle);
            reportViewer1.RefreshReport();
        }

        private void rdoCounterName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCounterName.Checked)
            {
                rdoAll.Checked = false;
             
                rdoCounterName.Checked = true;
                cboDoctor.Enabled = true;
                cboDoctor.SelectedIndex = 0;
               

            }
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked)
            {
              
                cboDoctor.Enabled = false;
                cboDoctor.SelectedIndex = 0;

            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            rdoAll.Checked = true;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            ReloadDoctorList();
        }
    }
}
