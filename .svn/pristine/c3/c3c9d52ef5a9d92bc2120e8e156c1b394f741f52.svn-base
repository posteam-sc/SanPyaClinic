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
    public partial class PaidByMPU : Form
    {
        #region Variables

        public List<TransactionDetail> DetailList = new List<TransactionDetail>();

        public int Discount { get; set; }

        public int Tax { get; set; }

        public int ExtraDiscount { get; set; }

        public int ExtraTax { get; set; }
        public int SC { get; set; }
        public Boolean isDraft { get; set; }
        public int PId { get; set; }
        public string DraftId { get; set; }
        public string Type { get; set; }
        public int DId { get; set; }
        public int Cfees { get; set; }
        public int CustomerId { get; set; }

        private POSEntities entity = new POSEntities();

        #endregion
        public PaidByMPU()
        {
            InitializeComponent();
        }

        private void PaidByMPU_Load(object sender, EventArgs e)
        {
            long totalCost = (long)DetailList.Sum(x => x.TotalAmount) + SC + Cfees + ExtraTax - ExtraDiscount;
            long unitpriceTotalCost = (long)DetailList.Sum(x => x.UnitPrice * x.Qty);//Edit ZMH
             System.Data.Objects.ObjectResult<String> Id;
             string resultId = "";
             if (Type == "Doctor")
             {
                 Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 5, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, totalCost, null, CustomerId, DId, SC,null,Cfees);
                 resultId = Id.FirstOrDefault().ToString();
             }
             else if (Type == "Physio")
             {
                 Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 5, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, totalCost, null, CustomerId, DId, SC, PId, Cfees);
                  resultId = Id.FirstOrDefault().ToString();
                 List<GroupByPhysio> gbp = new List<GroupByPhysio>();
                 gbp = (from g in entity.GroupByPhysios where g.GroupID == DId select g).ToList();
                 foreach (GroupByPhysio Item in gbp)
                 {
                     GroupByTransaction gbt = new GroupByTransaction();
                     gbt.TransactionId = resultId;
                     gbt.GroupMemberID = Item.PhysioID;
                     gbt.PaymentPercent = Convert.ToInt32(Item.DoctorPhysio.ForPhysioTrain);
                     entity.GroupByTransactions.Add(gbt);

                 }
                 entity.SaveChanges();
             }
             else
             {
                 Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 5, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, totalCost, null, CustomerId, null, SC, null, Cfees);
                 resultId = Id.FirstOrDefault().ToString();
             }
            entity = new POSEntities();
           
            Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
            foreach (TransactionDetail detail in DetailList)
            {
                detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                detail.Product.Qty = detail.Product.Qty - detail.Qty;
                if (detail.Product.IsWrapper == true)
                {
                    List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                    if (wList.Count > 0)
                    {
                        foreach (WrapperItem w in wList)
                        {
                            Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                            wpObj.Qty = wpObj.Qty - detail.Qty;
                        }
                    }
                }
                detail.IsDeleted = false;
                insertedTransaction.TransactionDetails.Add(detail);
            }
            insertedTransaction.IsDeleted = false;
            entity.SaveChanges();
            #region purchase
            // for Purchase Detail and PurchaseDetailInTransacton.

            foreach (TransactionDetail detail in insertedTransaction.TransactionDetails)
            {

                int Qty = Convert.ToInt32(detail.Qty);
                int pId = Convert.ToInt32(detail.ProductId);
                // Get purchase detail with same product Id and order by purchase date ascending
                List<APP_Data.PurchaseDetail> pulist = (from p in entity.PurchaseDetails where p.ProductId == pId && p.IsDeleted == false && p.CurrentQy > 0 orderby p.Date ascending select p).ToList();
                if (pulist.Count > 0)
                {
                    int TotalQty = Convert.ToInt32(pulist.Sum(x => x.CurrentQy));

                    if (TotalQty >= Qty)
                    {
                        foreach (PurchaseDetail p in pulist)
                        {
                            if (Qty > 0)
                            {
                                if (p.CurrentQy >= Qty)
                                {
                                    PurchaseDetailInTransaction pdObjInTran = new PurchaseDetailInTransaction();
                                    pdObjInTran.ProductId = pId;
                                    pdObjInTran.TransactionDetailId = detail.Id;
                                    pdObjInTran.PurchaseDetailId = p.Id;
                                    pdObjInTran.Date = p.Date;
                                    pdObjInTran.Qty = Qty;
                                    p.CurrentQy = p.CurrentQy - Qty;
                                    Qty = 0;

                                    entity.PurchaseDetailInTransactions.Add(pdObjInTran);
                                    entity.Entry(p).State = EntityState.Modified;
                                    entity.SaveChanges();
                                    break;
                                }
                                else if (p.CurrentQy <= Qty)
                                {
                                    PurchaseDetailInTransaction pdObjInTran = new PurchaseDetailInTransaction();
                                    pdObjInTran.ProductId = pId;
                                    pdObjInTran.TransactionDetailId = detail.Id;
                                    pdObjInTran.PurchaseDetailId = p.Id;
                                    pdObjInTran.Date = p.Date;
                                    pdObjInTran.Qty = p.CurrentQy;

                                    Qty = Convert.ToInt32(Qty - p.CurrentQy);
                                    p.CurrentQy = 0;
                                    entity.PurchaseDetailInTransactions.Add(pdObjInTran);
                                    entity.Entry(p).State = EntityState.Modified;
                                    entity.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            if (isDraft)
            {
                Transaction draft = (from trans in entity.Transactions where trans.Id == DraftId select trans).FirstOrDefault<Transaction>();
                if (draft != null)
                {
                    draft.TransactionDetails.Clear();
                    var Detail = entity.TransactionDetails.Where(d => d.TransactionId == draft.Id);
                    foreach (var d in Detail)
                    {
                        entity.TransactionDetails.Remove(d);
                    }
                    entity.Transactions.Remove(draft);
                }
            }
            entity.SaveChanges();
            //Print Invoice
            #region [ Print ]

            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
            foreach (TransactionDetail transaction in DetailList)
            {
                dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                newRow.Name = transaction.Product.Name;
                newRow.Qty = transaction.Qty.ToString();
                newRow.DiscountPercent = transaction.DiscountRate.ToString();
                newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty; //Edit By ZMH
                //newRow.TotalAmount = (int)transaction.TotalAmount;
                dtReport.AddItemListRow(newRow);
            }

            string reportPath = "";
            ReportViewer rv = new ReportViewer();
            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
            reportPath = Application.StartupPath + "\\Reports\\InvoiceMPU.rdlc";
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

            ReportParameter TransactionId = new ReportParameter("TransactionId", resultId.ToString());
            rv.LocalReport.SetParameters(TransactionId);

            APP_Data.Counter c = entity.Counters.FirstOrDefault(x => x.Id == MemberShip.CounterId);

            ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
            rv.LocalReport.SetParameters(CounterName);

            ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
            rv.LocalReport.SetParameters(PrintDateTime);

            ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
            rv.LocalReport.SetParameters(CasherName);

            ReportParameter PName = new ReportParameter("PatientName", insertedTransaction.Customer.Title.ToString() + " " + insertedTransaction.Customer.Name.ToString());
            rv.LocalReport.SetParameters(PName);

            Int64 totalAmountRep = insertedTransaction.TotalAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TotalAmount); //Edit By ZMH
            ReportParameter TotalAmount = new ReportParameter("TotalAmount", totalAmountRep.ToString());
            rv.LocalReport.SetParameters(TotalAmount);

            ReportParameter TaxAmount = new ReportParameter("TaxAmount", insertedTransaction.TaxAmount.ToString());
            rv.LocalReport.SetParameters(TaxAmount);

            Int64 Consultantfee = insertedTransaction.Consultantfees == null ? 0 : Convert.ToInt64(insertedTransaction.Consultantfees);
            ReportParameter Consultantfees = new ReportParameter("Consultantfees", Consultantfee.ToString());
            rv.LocalReport.SetParameters(Consultantfees);

            Int64 ServiceCharge = insertedTransaction.ServiceChages == null ? 0 : Convert.ToInt64(insertedTransaction.ServiceChages);
            ReportParameter ServiceCharges = new ReportParameter("ServiceCharges", ServiceCharge.ToString());
            rv.LocalReport.SetParameters(ServiceCharges);
            

            ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", insertedTransaction.DiscountAmount.ToString());
            rv.LocalReport.SetParameters(DiscountAmount);

            ReportParameter PaidAmount = new ReportParameter("PaidAmount", totalCost.ToString());
            rv.LocalReport.SetParameters(PaidAmount);

            ReportParameter Change = new ReportParameter("Change", "0");
            rv.LocalReport.SetParameters(Change);

            //for (int i = 0; i <= 1; i++) //Edit By ZMH
            //{
            //    PrintDoc.PrintReport(rv, "Slip");
            //}

            PrintDoc.PrintReport(rv, "Slip");
            #endregion


            //MessageBox.Show("Payment Completed");

            if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
            {
                Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                newForm.Clear();
            }

            this.Dispose();
        }
    }
}
