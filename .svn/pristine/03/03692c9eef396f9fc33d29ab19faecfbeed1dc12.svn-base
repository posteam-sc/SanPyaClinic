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
    public partial class frmDoctorPaymentByDaily : Form
    {
        private POSEntities entity = new POSEntities();
       
        public frmDoctorPaymentByDaily()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            

            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Doctor.Print || MemberShip.isAdmin)
            {
                #region [ Print ]
                int docID;
                System.Data.Objects.ObjectResult<GetDailyDoctorFees_Result> DetailList;
                if (cboDoctor.SelectedIndex > 0)
                {
                    docID = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                    DetailList = entity.GetDailyDoctorFees(docID, dtDate.Value.Date);
                    dsReportTemp dsReport = new dsReportTemp();
                    dsReportTemp.DoctorDailyDataTable dtReport = (dsReportTemp.DoctorDailyDataTable)dsReport.Tables["DoctorDaily"];
                    foreach (var item in DetailList)
                    {
                        dsReportTemp.DoctorDailyRow newRow = dtReport.NewDoctorDailyRow();
                        newRow.ConsultantFees = item.Consultantfees.ToString();
                        Int64 Cfees = 0;
                        var items = entity.GetConsultantfeesDoctorFeesByDateRate(docID, dtDate.Value.Date, dtDate.Value.Date);
                        foreach (var i in items)
                        {
                            Cfees += Convert.ToInt32(i.NoofPatient);

                        }
                        newRow.ConsultantFees = item.Consultantfees.ToString();
                        newRow.InjectionFees = item.Injection.ToString();
                        newRow.NoofP = Cfees.ToString();
                        newRow.TotalAmount = (item.Consultantfees + item.Injection).ToString();
                        newRow.DoctorName = cboDoctor.Text;
                        dtReport.AddDoctorDailyRow(newRow);
                    }

                    string reportPath = "";
                    ReportViewer rv = new ReportViewer();
                    ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["DoctorDaily"]);
                    reportPath = Application.StartupPath + "\\Reports\\DoctorDailyPayment.rdlc";
                    rv.Reset();
                    rv.LocalReport.ReportPath = reportPath;
                    rv.LocalReport.DataSources.Add(rds);


                    ReportParameter ShopName = new ReportParameter("ShopName", SettingController.ShopName);
                    rv.LocalReport.SetParameters(ShopName);


                    ReportParameter BranchName = new ReportParameter("BranchName", SettingController.BranchName);
                    rv.LocalReport.SetParameters(BranchName);



                    ReportParameter Phone = new ReportParameter("Phone", SettingController.PhoneNo);
                    rv.LocalReport.SetParameters(Phone);

                    ReportParameter OpeningHours = new ReportParameter("OpeningHours", SettingController.OpeningHours);
                    rv.LocalReport.SetParameters(OpeningHours);

                    ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                    rv.LocalReport.SetParameters(PrintDateTime);

                    ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                    rv.LocalReport.SetParameters(CasherName);

                    //for (int i = 0; i <= 1; i++) //Edit By ZMH
                    //{
                    //    PrintDoc.PrintReport(rv, "Slip");
                    //}
                    PrintDoc.PrintReport(rv, "Slip");
                }



                #endregion
            }
            else
            {
                MessageBox.Show("You are not allowed to print daily doctor payment", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void frmDoctorPaymentByDaily_Load(object sender, EventArgs e)
        {
            ReloadDoctorList();
          
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

        private void cboDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDoctor.SelectedIndex > 0)
            {
                int docid = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                var item = entity.GetDailyDoctorFees(docid, dtDate.Value.Date);
                foreach (var i in item)
                {
                    Int64 Cfees = 0;

                    //DateTime dt = Convert.ToDateTime(dtDate.Value);
                    //DateTime fromDate = Convert.ToDateTime(dtDate.Value);
                    //var dt = dtDate.Value.ToShortDateString();
                    //DateTime dt1=Convert.ToDateTime(dt);

                    var items = entity.GetConsultantfeesDoctorFeesByDateRate(docid, dtDate.Value.Date, dtDate.Value.Date);
                    foreach (var a in items)
                    {
                        Cfees += Convert.ToInt32(a.NoofPatient);
                    
                    }
                    lblNoofPa.Text = Cfees.ToString();
                    lblConsul.Text = i.Consultantfees.ToString();
                    lblinjection.Text = i.Injection.ToString();
                    lblTotal.Text = (i.Consultantfees + i.Injection).ToString();
                }
            }
        }
    }
}
