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
    public partial class PaidByCash2 : Form
    {
        #region Variables

        public List<TransactionDetail> DetailList = new List<TransactionDetail>();

        public int Discount { get; set; }

        public int Tax { get; set; }

        public int ExtraDiscount { get; set; }

        public int ExtraTax { get; set; }

        public int InjectionRate { get; set; }
        public int RTRate { get; set; }
        public int XrayRate { get; set; }

        public Boolean isDraft { get; set; }

        public Boolean isDebt { get; set; }

        public string DraftId { get; set; }

        public string DebtId { get; set; }

        public string Type { get; set; }

        public long DebtAmount { get; set; }

        public int CustomerId { get; set; }
        public int DId { get; set; }
        public int PId { get; set; }
        public int SC { get; set; }
        public int Cfees { get; set; }
        public long PrePaidAmount { get; set; }

        public List<Transaction> CreditTransaction { get; set; }

        public List<Transaction> PrePaidTransaction { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        private long totalAmount = 0, prePaidAmount = 0;

        #endregion

        public PaidByCash2()
        {
            InitializeComponent();
        }

        private void PaidByCash2_Load(object sender, EventArgs e)
        {
            if (!isDebt)
            {
                lblTotalCost.Text = (DetailList.Sum(x => x.TotalAmount) + Convert.ToInt32(SC) + Cfees - ExtraDiscount + ExtraTax).ToString();
            }
            else
            {
                foreach (Transaction tObj in CreditTransaction)
                {
                    if (tObj.Transaction1.Count <= 0)
                    {
                        totalAmount += (long)tObj.TotalAmount - (long)tObj.RecieveAmount;
                    }
                    //Has refund
                    else
                    {
                        totalAmount += (long)tObj.TotalAmount - (long)tObj.RecieveAmount;
                        foreach (Transaction Refund in tObj.Transaction1)
                        {
                            totalAmount -= (long)Refund.RecieveAmount;
                        }
                    }
                    if (tObj.UsePrePaidDebts != null)
                    {
                        long prepaid = (long)tObj.UsePrePaidDebts.Sum(x => x.UseAmount);
                        totalAmount -= prepaid;
                    }
                }
                foreach (Transaction tObj in PrePaidTransaction)
                {
                    prePaidAmount += (long)tObj.TotalAmount;
                    long useAmount = (tObj.UsePrePaidDebts1 == null) ? 0 : (int)tObj.UsePrePaidDebts1.Sum(x => x.UseAmount);
                    prePaidAmount -= useAmount;
                }
                DebtAmount = (totalAmount - prePaidAmount);
                lblTotalCost.Text = DebtAmount.ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
                    
            Boolean hasError = false;
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            long receiveAmount = 0;
            long totalCost = (long)DetailList.Sum(x => x.TotalAmount) +Convert.ToInt32(SC) + Cfees  + ExtraTax - ExtraDiscount;
            //total cost wint unit price
            long unitpriceTotalCost = (long)DetailList.Sum(x => x.UnitPrice * x.Qty) ;
            Int64.TryParse(txtReceiveAmount.Text, out receiveAmount);

            //Validation
            if (receiveAmount == 0)
            {
                tp.SetToolTip(txtReceiveAmount, "Error");
                tp.Show("Please fill up receive amount!", txtReceiveAmount);
                hasError = true;
            }
            else if (receiveAmount < totalCost)
            {
                tp.SetToolTip(txtReceiveAmount, "Error");
                tp.Show("Receive amount must be greater than total cost!", txtReceiveAmount);
                hasError = true;
            }
          
            if (!hasError)
            {
                
                System.Data.Objects.ObjectResult<String> Id;
                string resultId = "-";
                Transaction insertedTransaction = new Transaction();
                List<Transaction> RefundList = new List<Transaction>();
                if (!isDebt)
                {
                    if (Type == "Doctor")
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, CustomerId, DId, SC,PId,Cfees);
                        resultId = Id.FirstOrDefault().ToString();
                    }
                    else if (Type == "Physio")
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, CustomerId, DId, SC, PId, Cfees);
                        resultId=Id.FirstOrDefault().ToString();
                        List<GroupByPhysio> gbp = new List<GroupByPhysio>();
                        gbp = (from g in entity.GroupByPhysios where g.GroupID == DId select g).ToList();
                        foreach (GroupByPhysio Item in gbp)
                        {
                            GroupByTransaction gbt = new GroupByTransaction();
                            gbt.TransactionId = resultId;
                            gbt.GroupMemberID = Item.PhysioID;
                            gbt.PaymentPercent =Convert.ToInt32(Item.DoctorPhysio.ForPhysioTrain);
                            entity.GroupByTransactions.Add(gbt);

                        }
                        entity.SaveChanges();
                    }
                    else
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, CustomerId, null, SC, null, Cfees);
                        resultId = Id.FirstOrDefault().ToString();
                    }
                    entity = new POSEntities();
                   
                    insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                    string TId = insertedTransaction.Id;
                    insertedTransaction.IsDeleted = false;
                    foreach (TransactionDetail detail in DetailList)
                    {
                        detail.IsDeleted = false;//Update IsDelete (Null to 0)
                        var detailID = entity.InsertTransactionDetail(TId, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDecimal(detail.DiscountRate), Convert.ToDecimal(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted,Convert.ToDecimal(detail.InjectionRate),Convert.ToDecimal(detail.PTRate),Convert.ToDecimal(detail.XRayRate)).SingleOrDefault();
                        detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();

                        detail.Product.Qty = detail.Product.Qty - detail.Qty;

                        if (detail.Product.BrandId != null)
                        {
                            if (detail.Product.Brand.Name == "Special Promotion")
                            {
                                List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                                if (wList.Count > 0)
                                {
                                    foreach (WrapperItem w in wList)
                                    {
                                        Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                        wpObj.Qty = wpObj.Qty - detail.Qty;

                                        SPDetail spDetail = new SPDetail();
                                        spDetail.TransactionDetailID = Convert.ToInt32(detailID);
                                        spDetail.DiscountRate = detail.DiscountRate;
                                        spDetail.ParentProductID = w.ParentProductId;
                                        spDetail.ChildProductID = w.ChildProductId;
                                        spDetail.Price = wpObj.Price;
                                        entity.insertSPDetail(spDetail.TransactionDetailID, spDetail.ParentProductID, spDetail.ChildProductID, spDetail.Price, spDetail.DiscountRate, "PC");
                                        //entity.SPDetails.Add(spDetail);
                                    }
                                }
                            }
                        }
                    
                        entity.SaveChanges();
                    }      


                    #region purchase
                    // for Purchase Detail and PurchaseDetailInTransacton.

                    foreach (TransactionDetail detail in insertedTransaction.TransactionDetails)
                    {

                        int Qty =Convert.ToInt32(detail.Qty);
                        int pId =Convert.ToInt32(detail.ProductId);


                        // Get purchase detail with same product Id and order by purchase date ascending
                        List<APP_Data.PurchaseDetail> pulist=(from p in entity.PurchaseDetails where p.ProductId==pId && p.IsDeleted==false && p.CurrentQy>0 orderby p.Date ascending select p).ToList();

                        if (pulist.Count > 0)
                        {
                            int TotalQty = Convert.ToInt32(pulist.Sum(x =>x.CurrentQy));

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
                                            pdObjInTran.Date = detail.Transaction.DateTime;
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
                                            pdObjInTran.Date = detail.Transaction.DateTime;
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

                    //if current transaction is draft transaction, draft transaction is deleted
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
                            entity.SaveChanges();
                        }
                    }

                    //Print Invoice
                    #region [ Print ]
                   
                        dsReportTemp dsReport = new dsReportTemp();
                        dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                        foreach (TransactionDetail transaction in DetailList)
                        {
                            dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                            newRow.ItemId = transaction.Product.ProductCode;
                            newRow.Name = transaction.Product.Name;
                            newRow.Qty = transaction.Qty.ToString();
                            newRow.DiscountPercent = transaction.DiscountRate.ToString();
                            newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty;

                            dtReport.AddItemListRow(newRow);
                        }

                        string reportPath = "";
                        ReportViewer rv = new ReportViewer();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
                        reportPath = Application.StartupPath + "\\Reports\\InvoiceCash.rdlc";
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

                        APP_Data.Counter c = entity.Counters.Where(x => x.Id == MemberShip.CounterId).FirstOrDefault();

                        ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                        rv.LocalReport.SetParameters(CounterName);

                        ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                        rv.LocalReport.SetParameters(PrintDateTime);

                        ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                        rv.LocalReport.SetParameters(CasherName);

                        Int64 totalAmountRep = insertedTransaction.TotalAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TotalAmount);
                        ReportParameter TotalAmount = new ReportParameter("TotalAmount", totalAmountRep.ToString());
                        rv.LocalReport.SetParameters(TotalAmount);



                        Int64 Consultantfee = insertedTransaction.Consultantfees == null ? 0 : Convert.ToInt64(insertedTransaction.Consultantfees);
                        ReportParameter Consultant = new ReportParameter("Consultantfees", Consultantfee.ToString());
                        rv.LocalReport.SetParameters(Consultant);

                        Int64 ServiceCharge = insertedTransaction.ServiceChages == null ? 0 : Convert.ToInt64(insertedTransaction.ServiceChages);
                        ReportParameter ServiceCharges = new ReportParameter("ServiceCharges", ServiceCharge.ToString());
                        rv.LocalReport.SetParameters(ServiceCharges);


                        Int64 taxAmountRep = insertedTransaction.TaxAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TaxAmount);
                        ReportParameter TaxAmount = new ReportParameter("TaxAmount", taxAmountRep.ToString());
                        rv.LocalReport.SetParameters(TaxAmount);

                        ReportParameter PName = new ReportParameter("PatientName", insertedTransaction.Customer.Title.ToString()+" "+insertedTransaction.Customer.Name.ToString());
                        rv.LocalReport.SetParameters(PName);

                        Int64 disAmountRep = insertedTransaction.DiscountAmount == null ? 0 : Convert.ToInt64(insertedTransaction.DiscountAmount);
                        ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", disAmountRep.ToString());
                        rv.LocalReport.SetParameters(DiscountAmount);

                        ReportParameter PaidAmount = new ReportParameter("PaidAmount", txtReceiveAmount.Text);
                        rv.LocalReport.SetParameters(PaidAmount);

                        ReportParameter Change = new ReportParameter("Change", lblChanges.Text);
                        rv.LocalReport.SetParameters(Change);

                         PrintDoc.PrintReport(rv, "Slip");
                        //for (int i = 1; i <= 1; i++) //Edit By ZMH
                        //{
                        //    PrintDoc.PrintReport(rv, "Slip"); 
                        //}

                    
                    #endregion


                    MessageBox.Show("Payment Completed");
                }
                else
                {
                    if (lblChangesText.Text == "Changes")
                    {
                        receiveAmount -= Convert.ToInt64(lblChanges.Text);
                    }
                    long totalAmount = receiveAmount + prePaidAmount;
                    long totalCredit = 0;
                    Int64.TryParse(lblTotalCost.Text, out totalCredit);
                    long DebtAmount = 0;
                    if (totalAmount != 0)
                    {
                        if (CreditTransaction.Count > 0)
                        {
                            int index = CreditTransaction.Count;
                            for (int outer = index - 1; outer >= 1; outer--)
                            {
                                for (int inner = 0; inner < outer; inner++)
                                {
                                    if (CreditTransaction[inner].TotalAmount - CreditTransaction[inner].RecieveAmount < CreditTransaction[inner + 1].TotalAmount - CreditTransaction[inner + 1].RecieveAmount)
                                    {
                                        Transaction t = CreditTransaction[inner];
                                        CreditTransaction[inner] = CreditTransaction[inner + 1];
                                        CreditTransaction[inner + 1] = t;
                                    }
                                }
                            }
                            foreach (Transaction CT in CreditTransaction)
                            {
                                long CreditAmount = 0;
                                CreditAmount = (long)CT.TotalAmount - (long)CT.RecieveAmount;
                                RefundList = (from tr in entity.Transactions where tr.ParentId == CT.Id && tr.Type == TransactionType.CreditRefund select tr).ToList();
                                if (RefundList.Count > 0)
                                {
                                    foreach (Transaction TRefund in RefundList)
                                    {
                                        CreditAmount -= (long)TRefund.RecieveAmount;
                                    }
                                }
                                if (CT.UsePrePaidDebts != null)
                                {
                                    long prePaid = (long)CT.UsePrePaidDebts.Sum(x => x.UseAmount);
                                    CreditAmount -= prePaid;
                                }
                                if (CreditAmount <= totalAmount)
                                {
                                    //CT.IsPaid = true;
                                    //entity.SaveChanges();
                                    Transaction CreditT = (from t in entity.Transactions where t.Id == CT.Id select t).FirstOrDefault<Transaction>();
                                    CreditT.IsPaid = true;
                                    entity.Entry(CreditT).State = EntityState.Modified;
                                    entity.SaveChanges();
                                    totalAmount -= CreditAmount;
                                    if (CreditAmount <= receiveAmount)
                                    {
                                        DebtAmount += CreditAmount;
                                        receiveAmount -= CreditAmount;
                                    }
                                    else
                                    {
                                        CreditAmount -= receiveAmount;
                                        DebtAmount += receiveAmount;
                                        receiveAmount = 0;
                                        foreach (Transaction PrePaidDebtTrans in PrePaidTransaction)
                                        {
                                            long PrePaidamount = 0;
                                            //int useAmount = 0;
                                            int useAmount = (PrePaidDebtTrans.UsePrePaidDebts1 == null) ? 0 : (int)PrePaidDebtTrans.UsePrePaidDebts1.Sum(x => x.UseAmount);
                                            PrePaidamount = (long)PrePaidDebtTrans.TotalAmount - useAmount;
                                            //if (CreditAmount >= PrePaidamount)
                                            //{
                                            //    PrePaidDebtTrans.IsActive = true;
                                            //    //entity.Entry(PrePaidDebtTrans).State = System.Data.EntityState.Modified;
                                            //}

                                            if (CreditAmount >= PrePaidamount)
                                            {
                                                //PrePaidDebtTrans.IsActive = true;
                                                //entity.SaveChanges();
                                                Transaction PD = (from PT in entity.Transactions where PT.Id == PrePaidDebtTrans.Id select PT).FirstOrDefault<Transaction>();
                                                PD.IsActive = true;
                                                entity.Entry(PD).State = EntityState.Modified;
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)PrePaidamount;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = CT.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CreditAmount -= PrePaidamount;
                                            }
                                            else
                                            {
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)CreditAmount;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = CT.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CreditAmount -= PrePaidamount;
                                            }
                                        }

                                        PrePaidTransaction = (from PDT in entity.Transactions where PDT.Type == TransactionType.Prepaid && PDT.IsActive == false select PDT).ToList();
                                    }
                                }
                            }
                            if (DebtAmount > 0)
                            {
                                System.Data.Objects.ObjectResult<string> DebtId;
                                if (Type == "Doctor")
                                {
                                    DebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, DebtAmount, null, CustomerId, DId, SC,null,Cfees);
                                    resultId = DebtId.FirstOrDefault().ToString();

                                }
                                else if (Type == "Physio")
                                {
                                    DebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, DebtAmount, null, CustomerId, DId, SC, PId, Cfees);
                                    resultId = DebtId.FirstOrDefault().ToString();
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
                                    DebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, DebtAmount, null, CustomerId, null, SC, null, Cfees);
                                     resultId = DebtId.FirstOrDefault().ToString();
                                }
                                entity = new POSEntities();
                                
                                insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                            }
                        }
                        else
                        {
                            totalAmount -= prePaidAmount;
                            receiveAmount -= prePaidAmount;
                            //System.Data.Objects.ObjectResult<string> PreDebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.PrepaidDebt, true, false, 1, 0, 0, totalAmount, totalAmount, null, customerId);
                            //entity.SaveChanges();
                        }
                    }
                    if (receiveAmount > 0)
                    {
                        System.Data.Objects.ObjectResult<string> PreDebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Prepaid, true, false, 1, 0, 0, receiveAmount, receiveAmount, null, CustomerId,null,SC,null,Cfees);
                        entity.SaveChanges();
                        if (DebtAmount == 0)
                        {
                            entity = new POSEntities();
                            resultId = PreDebtId.FirstOrDefault().ToString();
                            insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                        }

                    }
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
                            entity.SaveChanges();
                        }
                    }
                                 

                    //Print Invoice
                    #region [ Print ]

                    dsReportTemp dsReport = new dsReportTemp();
                    dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                    foreach (TransactionDetail transaction in DetailList)
                    {
                        dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                        newRow.ItemId = transaction.Product.ProductCode;
                        newRow.Name = transaction.Product.Name;
                        newRow.Qty = transaction.Qty.ToString();
                        newRow.TotalAmount = (int)transaction.TotalAmount;
                        dtReport.AddItemListRow(newRow);
                    }

                    string reportPath = "";
                    ReportViewer rv = new ReportViewer();
                    ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
                    reportPath = Application.StartupPath + "\\Reports\\InvoiceSettlement.rdlc";
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

                    APP_Data.Counter c = entity.Counters.Where(x => x.Id == MemberShip.CounterId).FirstOrDefault();

                    ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                    rv.LocalReport.SetParameters(CounterName);

                    ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                    rv.LocalReport.SetParameters(PrintDateTime);

                    ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                    rv.LocalReport.SetParameters(CasherName);


                    ReportParameter PName = new ReportParameter("PatientName", insertedTransaction.Customer.Name.ToString());
                    rv.LocalReport.SetParameters(PName);

                    Int64 totalAmountRep = insertedTransaction.TotalAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TotalAmount + insertedTransaction.ServiceChages + insertedTransaction.Consultantfees);
                    ReportParameter TotalAmount = new ReportParameter("TotalAmount", totalAmountRep.ToString());
                    rv.LocalReport.SetParameters(TotalAmount);

                    Int64 taxAmountRep = insertedTransaction.TaxAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TaxAmount);
                    ReportParameter TaxAmount = new ReportParameter("TaxAmount", taxAmountRep.ToString());
                    rv.LocalReport.SetParameters(TaxAmount);

                    Int64 disAmountRep = insertedTransaction.DiscountAmount == null ? 0 : Convert.ToInt64(insertedTransaction.DiscountAmount);
                    ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", disAmountRep.ToString());
                    rv.LocalReport.SetParameters(DiscountAmount);

                    ReportParameter PaidAmount = new ReportParameter("PaidAmount", txtReceiveAmount.Text);
                    rv.LocalReport.SetParameters(PaidAmount);

                    ReportParameter Change = new ReportParameter("Change", lblChanges.Text);
                    rv.LocalReport.SetParameters(Change);

                    PrintDoc.PrintReport(rv, "Slip");
                    #endregion

                    MessageBox.Show("Payment Completed");
                }
                //entity = new POSEntities();
                //string resultId = Id.FirstOrDefault().ToString();
                //Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();


                //foreach (TransactionDetail detail in DetailList)
                //{
                //    detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                //    detail.Product.Qty = detail.Product.Qty - detail.Qty;
                //    insertedTransaction.TransactionDetails.Add(detail);
                //}

              
                if (!isDebt)
                {
                    if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                    {
                        Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                        newForm.Clear();
                    }
                }
                else
                {
                    if (System.Windows.Forms.Application.OpenForms["CustomerDetail"] != null)
                    {
                        CustomerDetail newForm = (CustomerDetail)System.Windows.Forms.Application.OpenForms["CustomerDetail"];
                        newForm.Reload();
                    }
                }
                this.Dispose();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PaidByCash_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtReceiveAmount);
        }

        private void txtReceiveAmount_KeyUp(object sender, KeyEventArgs e)
        {
            int amount = 0;
            Int32.TryParse(txtReceiveAmount.Text, out amount);
            int Cost = 0;
            Int32.TryParse(lblTotalCost.Text, out Cost);
            if (!isDebt)
            {
                lblChanges.Text = (amount - (DetailList.Sum(x => x.TotalAmount) +Convert.ToInt32(SC) +Cfees - ExtraDiscount + ExtraTax)).ToString();
            }
            else
            {
                if (amount >= DebtAmount)
                {
                    lblChanges.Text = (amount - DebtAmount).ToString();
                    lblChangesText.Text = "Changes";
                }
                else
                {
                    lblChangesText.Text = "NetParable";
                    lblChanges.Text = (DebtAmount - amount).ToString();
                }
            }
        }

        private void txtReceiveAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
