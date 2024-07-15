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
    public partial class frmPhysioPayment : Form
    {
        POSEntities entity = new POSEntities();
        List<PhysioPaymentForDate> plist = new List<PhysioPaymentForDate>();
        int partId;
        public string check = "";
        public frmPhysioPayment()
        {
            InitializeComponent();
        }

        private void frmPhysioPayment_Load(object sender, EventArgs e)
        {
            plist = new List<PhysioPaymentForDate>();
            //ReloadDoctorList();
            ReloadPartTimeStaffList();
        }

        public void ReloadPartTimeStaffList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.DoctorPhysio> DoctorPhysiorList = new List<APP_Data.DoctorPhysio>();
            APP_Data.DoctorPhysio doctorPhysio = new APP_Data.DoctorPhysio();
            doctorPhysio.Id = 0;
            doctorPhysio.Name = "None";
            DoctorPhysiorList.Add(doctorPhysio);
            DoctorPhysiorList.AddRange((from p in entity.DoctorPhysios where p.IsDoctor == false select p).ToList());
            cboPartTime.DataSource = DoctorPhysiorList;
            cboPartTime.DisplayMember = "Name";
            cboPartTime.ValueMember = "Id";
        }
    
        public void loadData()
        {
            plist.Clear();

            var fDate = dtFrom.Value.ToShortDateString();
            DateTime fromDate = Convert.ToDateTime(fDate);
            var tDate = dtTo.Value.ToShortDateString();
            DateTime toDate = Convert.ToDateTime(tDate);


            if (cboPartTime.SelectedIndex > 0)
            {
                partId = Convert.ToInt32(cboPartTime.SelectedValue);
            }
            else
            {
                partId = 0;
            }

            var tList = (from a in entity.Transactions
                         where (a.DateTime.Value.Year >= fromDate.Year && a.DateTime.Value.Month >= fromDate.Month && a.DateTime.Value.Day >= fromDate.Day
                                                                                  && a.DateTime.Value.Year <= toDate.Year && a.DateTime.Value.Month <= toDate.Month && a.DateTime.Value.Day <= toDate.Day
                                                                                  && a.IsDeleted == false && a.IsComplete == true && a.IsActive == true && a.PaymentTypeId != 4)
                         select a).ToList();

            if (tList.Count == 0)
            {
                plist.Clear();
                ShowReportViewer();
                //reportViewer1.RefreshReport();
                return;
            }

            var TDutyIdList = (from a in tList select a.GroupID).ToList();

            var tIdList = (from a in tList select a.Id).ToList();

            var ptAmountList = (from td in entity.TransactionDetails
                                join t in entity.Transactions on td.TransactionId equals t.Id
                                join p in entity.Products on td.ProductId equals p.Id
                                join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                where tIdList.Contains(td.TransactionId) && pc.Name == "PT" && t.DateTime.Value.Year >= fromDate.Year && t.DateTime.Value.Month >= fromDate.Month && t.DateTime.Value.Day >= fromDate.Day
                                                                                  && t.DateTime.Value.Year <= toDate.Year && t.DateTime.Value.Month <= toDate.Month && t.DateTime.Value.Day <= toDate.Day
                                                                                  && t.IsDeleted == false && t.IsComplete == true && t.IsActive == true && t.PaymentTypeId != 4 && t.GroupID != 0 && t.GroupID != null
                                select new { td.TotalAmount, t.Id, t.GroupID,t.DateTime }).ToList();
        
            var Data = ptAmountList.GroupBy(x => new  {Date = x.DateTime.Value.Date,  x.GroupID })

                                    .Select(y => new Transaction()
                                    {

                                        TotalAmount = (y.Sum(x => x.TotalAmount)),
                                        GroupID = y.Key.GroupID,

                                    }).ToList();

       
            var date=System.DateTime.Now.ToShortDateString();
            DateTime dt= Convert.ToDateTime(date);
         
           // string dutyIdList="";
            
            string collectStaffList="";
         
            List<int?> _staffIdList1=new List<int?>();
             List<string> _splitstaffIdList =new List<string>();
             List<int> splitCollectstaffIdList = new List<int>();
             if (Data.Count > 0)
             {
                 
                 List<DailyDutyPhysio> dpList = new List<DailyDutyPhysio>();
                 List<DoctorPhysio> dopList = new List<DoctorPhysio>();
                  List<string> splitStaffList=new List<string>();
                         List<int> splitStaffIDList = new List<int>();
                 for (int i = 0; i < Data.Count ; i++)
                 {
                     string staffIdList1 = "";
                    string staffIdList = "";
                     var groupId=Data[i].GroupID;
                     var dutyList = (from a in entity.DailyDutyPhysios where (a.DutyDate >= fromDate && a.DutyDate <= toDate && groupId==a.Id) select a).FirstOrDefault();
                     //if (dutyList[i].Id == Data[i].GroupID)
                     //{
                         DailyDutyPhysio dp = new DailyDutyPhysio();
                         dp.TotalAmout = Data[i].TotalAmount;
                         dp.Id = dutyList.Id;
                         dp.StaffID = dutyList.StaffID;
                         dp.GroupID = dutyList.GroupID;
                         dp.Shift = dutyList.Shift;

                         //string staffList="";

                         if (dp.StaffID.StartsWith(","))
                         {
                             staffIdList = dp.StaffID.Substring(1);
                         }
                         else
                         {
                             staffIdList = dp.StaffID;
                         }

                         if (dp.StaffID.EndsWith(","))
                         {
                             staffIdList = dp.StaffID.Substring(0, dp.StaffID.Length - 1);
                         }
                         else
                         {
                             staffIdList = dp.StaffID;
                         }
                         if (staffIdList == "")
                         {
                             staffIdList = "0";
                         }
                        // splitStaffList = new List<string>(staffIdList.Split(','));

                         ///   StringSplitOptions.RemoveEmptyEntries);
                         //splitStaffIDList = splitStaffList.Select(int.Parse).ToList();

                         if (dp.GroupID!=0)
                         {
                             _staffIdList1 = (from g in entity.GroupByPhysios where dp.GroupID==g.GroupID select g.PhysioID).ToList();

                             staffIdList1 = string.Join(",", _staffIdList1.Select(n => n.ToString()).ToArray());
                             //  _staffIdList1Count = _staffIdList1.Count;
                         }

                         //List<int> gStaffIdList= (from g in entity.DoctorPhysios where dutyIdList.Contains(g.GroupID) select g).ToList();

                         if (staffIdList != "" && staffIdList1 != "")
                         {
                             collectStaffList = staffIdList + "," + staffIdList1;

                         }
                         else
                         {
                             if (staffIdList != "")
                             {
                                 collectStaffList = staffIdList;
                             }
                             else
                             {
                                 collectStaffList = staffIdList1;
                             }
                         }
                         List<string> _splitCollectSTaffList = new List<string>(collectStaffList.Split(','));

                         splitStaffIDList = _splitCollectSTaffList.Select(int.Parse).ToList();

                         //List<int> distinctCollectStaffList = splitStaffIDList.Distinct().ToList();


                         for (int e= 0; e< splitStaffIDList.Count;e++)
                         {
                             var id=splitStaffIDList[e];
                             DoctorPhysio dop = new DoctorPhysio();
                             var sidCount = (from d in dopList where d.Id == id select d).Count();

                             var isPercent = (from d in entity.DoctorPhysios where d.Id == id select d.IsPercent).FirstOrDefault();
                           //  var splitId = splitStaffIDList[e];
                           //  var staffIsPercent = (from f in entity.DoctorPhysios where f.Id == splitId select f.IsPercent).FirstOrDefault();
                            dop.Id = splitStaffIDList[e];
                            dop.Shift = dp.Shift;
                            dop.DutyId = dp.Id;
                            dop.IsPercent = isPercent;
                          //   dop.IsPercent = staffIsPercent;
                             if (sidCount > 0)
                             {
                                 var index = dopList.FindIndex(a => a.Id == id);
                                 var amt= (from d in dopList where d.Id == id select d.TotalAmount).FirstOrDefault();
                                 dop.TotalAmount =amt + dp.TotalAmout;
                                // dop.IdCount = dopList[index].IdCount +  1;
                                
                                 dopList[index].TotalAmount = dop.TotalAmount;
                                // dopList[index].IdCount = dop.IdCount;
                                 if (isPercent == false)
                                 {
                                     dopList.Add(dop);
                                 }
                             }
                             else
                             {
                                 dop.TotalAmount = dp.TotalAmout;
                                 dopList.Add(dop);
                             }
                         }
                             dpList.Add(dp);

                 }
                     if (dopList.Count > 0)
                     {
                         
                         var splitCollectSTaffList = (from e in dopList select e.Id).ToList();
                         List<int> distinctCollectStaffList = splitCollectSTaffList.Distinct().ToList();
                        
                         List<DoctorPhysio> resultReportList = new List<DoctorPhysio>();
                         if (partId > 0)
                         {

                             var exitPartIdList = (from a in distinctCollectStaffList where a == partId select a).ToList();

                             if (exitPartIdList.Count > 0)
                             {
                                 resultReportList = (from a in entity.DoctorPhysios where a.Id == partId select a).ToList();
                             }
                         }
                         else
                         {
                             resultReportList = (from a in entity.DoctorPhysios where distinctCollectStaffList.Contains(a.Id) select a).ToList();
                         }

                         // decimal? TotalChargesforPhysio = (ForPercentAmt / 100) * SettingController.DefaultPhysioPercent;
                         for (int i = 0; i < resultReportList.Count; i++)
                         {
                             PhysioPaymentForDate pf = new PhysioPaymentForDate();

                             var rId = resultReportList[i].Id;
                             var amount = (from d in dopList where d.Id == rId select d.TotalAmount).FirstOrDefault();
                          
                             pf.Name = resultReportList[i].Name;
                             if (resultReportList[i].IsPercent == true)
                             {
                                 pf.Percent = Convert.ToDecimal(resultReportList[i].ForPhysioTrain);
                                 decimal? TotalChargesforPhysio = (amount / 100) * SettingController.DefaultPhysioPercent;

                                 pf.Amount = Convert.ToInt64((TotalChargesforPhysio / 100) * resultReportList[i].ForPhysioTrain);
                             }
                             else
                             {
                                 var shiftCount = (from s in dopList
                                                 where s.Id==rId
                                                 group  s by  new {s.DutyId,s.Shift} into g
                                                select new DoctorPhysio()
                                {
                                    DutyId = g.Key.DutyId,
                                    Shift=g.Key.Shift,
                                }).Count();
                                     pf.Amount = Convert.ToInt64(resultReportList[i].ForPhysioTrain) * shiftCount;
                             }

                             plist.Add(pf);
                         }
                         ShowReportViewer();
                     }
             }
             else
             {
                 reportViewer1.LocalReport.DataSources.Clear();
             }
        }

        private void cboDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
        private void ShowReportViewer()
        {
            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.PhysioReportDataTable dtPdReport = (dsReportTemp.PhysioReportDataTable)dsReport.Tables["PhysioReport"];
            foreach (PhysioPaymentForDate pdCon in plist)
            {
                dsReportTemp.PhysioReportRow newRow = dtPdReport.NewPhysioReportRow();
                newRow.Name = pdCon.Name.ToString();
                newRow.Percent = pdCon.Percent.ToString();
                newRow.Amount =pdCon.Amount;
                
                dtPdReport.AddPhysioReportRow(newRow);
            }
            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["PhysioReport"]);
            string reportPath = Application.StartupPath + "\\Reports\\rdlcPhysioCharges.rdlc";

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter Date = new ReportParameter("Date", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);

            ReportParameter TransactionTitle = new ReportParameter("TransactionTitle", "Physio Payment Report at " + DateTime.Now.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(TransactionTitle);
            reportViewer1.RefreshReport();
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
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
           // ReloadDoctorList();
            ReloadPartTimeStaffList();
        }

    
        private void cboPartTime_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}

