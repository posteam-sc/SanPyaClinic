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
    public partial class TransactionDetailForm : Form
    {
        #region Variable

        private POSEntities entity = new POSEntities();
        public string transactionId;
        int ExtraDiscount, ExtraTax;
        long unitpriceTotalCost;
        private int CustomerId = 0;
        private int? groupId = 0;
        #endregion

        #region Event

        public TransactionDetailForm()
        {
            InitializeComponent();
        }

        private void TransactionDetailForm_Load(object sender, EventArgs e)
        {
            List<APP_Data.Customer> customerList = new List<APP_Data.Customer>();
            APP_Data.Customer customer = new APP_Data.Customer();
            customer.Id = 0;
            customer.Name = "None";
            customerList.Add(customer);
            customerList.AddRange(entity.Customers.ToList());
            cboCustomer.DataSource = customerList;
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "Id";
            cboCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            LoadData();            
        }        

        private void dgvTransactionDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransactionDetail.Rows)
            {
                TransactionDetail transactionDetailObj = (TransactionDetail)row.DataBoundItem;
                row.Cells[0].Value = transactionDetailObj.Product.ProductCode;
                row.Cells[1].Value = transactionDetailObj.Product.Name;
                row.Cells[2].Value = transactionDetailObj.Qty;
                row.Cells[3].Value = transactionDetailObj.UnitPrice;
                row.Cells[4].Value = transactionDetailObj.DiscountRate + "%";
                row.Cells[5].Value = transactionDetailObj.TaxRate + "%";
                row.Cells[6].Value = transactionDetailObj.TotalAmount;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            Transaction transactionObj = (from t in entity.Transactions where t.Id == transactionId select t).FirstOrDefault();
            unitpriceTotalCost = 0;
            if (transactionObj.PaymentTypeId == 2)
            {
                #region [ Print ] for Credit

                int outStandingAmount = 0;
                Int32.TryParse(lblOutstandingAmount.Text, out outStandingAmount);
                dsReportTemp dsReport = new dsReportTemp();
                dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                foreach (TransactionDetail transaction in transactionObj.TransactionDetails)
                {
                    dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                    newRow.Name = transaction.Product.Name;
                    newRow.Qty = transaction.Qty.ToString();
                    newRow.DiscountPercent = transaction.DiscountRate.ToString();
                    newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty; //Edit By ZMH
                //    newRow.TotalAmount = (int)transaction.TotalAmount;
                    dtReport.AddItemListRow(newRow);
                    unitpriceTotalCost += (int)transaction.UnitPrice * (int)transaction.Qty;
                }

                string reportPath = "";
                ReportViewer rv = new ReportViewer();
                ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
                reportPath = Application.StartupPath + "\\Reports\\InvoiceCreditRe.rdlc";
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

                ReportParameter TransactionId = new ReportParameter("TransactionId", transactionId.ToString());
                rv.LocalReport.SetParameters(TransactionId);

                APP_Data.Counter counter = entity.Counters.FirstOrDefault(x => x.Id == MemberShip.CounterId);

                ReportParameter CounterName = new ReportParameter("CounterName", counter.Name);
                rv.LocalReport.SetParameters(CounterName);

                ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                rv.LocalReport.SetParameters(PrintDateTime);

                ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                rv.LocalReport.SetParameters(CasherName);

                ReportParameter TotalAmount = new ReportParameter("TotalAmount", transactionObj.TotalAmount.ToString());
                rv.LocalReport.SetParameters(TotalAmount);

                ReportParameter TaxAmount = new ReportParameter("TaxAmount", transactionObj.TaxAmount.ToString());
                rv.LocalReport.SetParameters(TaxAmount);

                ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", transactionObj.DiscountAmount.ToString());
                rv.LocalReport.SetParameters(DiscountAmount);

                Int64 Consultantfee = transactionObj.Consultantfees == null ? 0 : Convert.ToInt64(transactionObj.Consultantfees);
                ReportParameter Consultantfees = new ReportParameter("Consultantfees", Consultantfee.ToString());
                rv.LocalReport.SetParameters(Consultantfees);

                Int64 ServiceCharge = transactionObj.ServiceChages == null ? 0 : Convert.ToInt64(transactionObj.ServiceChages);
                ReportParameter ServiceCharges = new ReportParameter("ServiceCharges", ServiceCharge.ToString());
                rv.LocalReport.SetParameters(ServiceCharges);

                ReportParameter PaidAmount = new ReportParameter("PaidAmount", transactionObj.RecieveAmount.ToString());
                rv.LocalReport.SetParameters(PaidAmount);

                ReportParameter PrePaidDebt = new ReportParameter("PrePaidDebt", lblOutstandingAmount.Text);
                rv.LocalReport.SetParameters(PrePaidDebt);

                ReportParameter NetPayable = new ReportParameter("NetPayable", (transactionObj.TotalAmount - Convert.ToInt32(lblOutstandingAmount.Text)).ToString());
                rv.LocalReport.SetParameters(NetPayable);

                ReportParameter Balance = new ReportParameter("Balance", (transactionObj.TotalAmount - (Convert.ToInt32(lblOutstandingAmount.Text)) - transactionObj.RecieveAmount).ToString());
                rv.LocalReport.SetParameters(Balance);

                ReportParameter CustomerName = new ReportParameter("CustomerName", transactionObj.Customer.Name);
                rv.LocalReport.SetParameters(CustomerName);

                PrintDoc.PrintReport(rv, "Slip");
                #endregion
            }
            else if (transactionObj.PaymentTypeId == 3)
            {
                #region [ Print ] for GiftCard

                dsReportTemp dsReport = new dsReportTemp();
                dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                foreach (TransactionDetail transaction in transactionObj.TransactionDetails)
                {
                    dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                    newRow.Name = transaction.Product.Name;
                    newRow.Qty = transaction.Qty.ToString();
                    //newRow.TotalAmount = (int)transaction.TotalAmount;

                    newRow.DiscountPercent = transaction.DiscountRate.ToString();
                    newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty; //Edit By ZMH
                    dtReport.AddItemListRow(newRow);
                    unitpriceTotalCost += (int)transaction.UnitPrice * (int)transaction.Qty;  

                    //dtReport.AddItemListRow(newRow);
                }

                string reportPath = "";
                ReportViewer rv = new ReportViewer();
                ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
                reportPath = Application.StartupPath + "\\Reports\\InvoiceGiftcard.rdlc";
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

                ReportParameter TransactionId = new ReportParameter("TransactionId", transactionId.ToString());
                rv.LocalReport.SetParameters(TransactionId);

                APP_Data.Counter c = entity.Counters.FirstOrDefault(x => x.Id == MemberShip.CounterId);

                ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                rv.LocalReport.SetParameters(CounterName);

                ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                rv.LocalReport.SetParameters(PrintDateTime);

                ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                rv.LocalReport.SetParameters(CasherName);

                ReportParameter PName = new ReportParameter("PatientName", transactionObj.Customer.Name.ToString());
                rv.LocalReport.SetParameters(PName);

                ReportParameter TotalAmount = new ReportParameter("TotalAmount", transactionObj.TotalAmount.ToString());
                rv.LocalReport.SetParameters(TotalAmount);

                ReportParameter TaxAmount = new ReportParameter("TaxAmount", transactionObj.TaxAmount.ToString());
                rv.LocalReport.SetParameters(TaxAmount);

                ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", transactionObj.DiscountAmount.ToString());
                rv.LocalReport.SetParameters(DiscountAmount);

                Int64 Consultantfee = transactionObj.Consultantfees == null ? 0 : Convert.ToInt64(transactionObj.Consultantfees);
                ReportParameter Consultantfees = new ReportParameter("Consultantfees", Consultantfee.ToString());
                rv.LocalReport.SetParameters(Consultantfees);

                Int64 ServiceCharge = transactionObj.ServiceChages == null ? 0 : Convert.ToInt64(transactionObj.ServiceChages);
                ReportParameter ServiceCharges = new ReportParameter("ServiceCharges", ServiceCharge.ToString());
                rv.LocalReport.SetParameters(ServiceCharges);

                ReportParameter PaidAmount = new ReportParameter("PaidAmount", transactionObj.TotalAmount.ToString());
                rv.LocalReport.SetParameters(PaidAmount);

                ReportParameter Change = new ReportParameter("Change", "0");
                rv.LocalReport.SetParameters(Change);

                ReportParameter GiftCardNo = new ReportParameter("GiftCardNo", transactionObj.GiftCardId.ToString());
                rv.LocalReport.SetParameters(GiftCardNo);


                PrintDoc.PrintReport(rv, "Slip");
                #endregion
            }
            else if (transactionObj.PaymentTypeId == 1)
            {
                #region [ Print ] for Cash

                dsReportTemp dsReport = new dsReportTemp();
                dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                foreach (TransactionDetail transaction in transactionObj.TransactionDetails)
                {
                    dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                    newRow.Name = transaction.Product.Name;
                    newRow.Qty = transaction.Qty.ToString();
                    //newRow.TotalAmount = (int)transaction.TotalAmount; //Edit By ZMH
                    newRow.DiscountPercent = transaction.DiscountRate.ToString();
                    newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty; //Edit By ZMH
                    dtReport.AddItemListRow(newRow);
                    unitpriceTotalCost = (int)transaction.UnitPrice * (int)transaction.Qty;                    
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

                ReportParameter TransactionId = new ReportParameter("TransactionId", transactionId.ToString());
                rv.LocalReport.SetParameters(TransactionId);

                APP_Data.Counter c = entity.Counters.FirstOrDefault(x => x.Id == MemberShip.CounterId);

                ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                rv.LocalReport.SetParameters(CounterName);

                ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                rv.LocalReport.SetParameters(PrintDateTime);

                ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                rv.LocalReport.SetParameters(CasherName);

                Int64 Consultantfee = transactionObj.Consultantfees == null ? 0 : Convert.ToInt64(transactionObj.Consultantfees);
                ReportParameter Consultantfees = new ReportParameter("Consultantfees", Consultantfee.ToString());
                rv.LocalReport.SetParameters(Consultantfees);

                Int64 ServiceCharge = transactionObj.ServiceChages == null ? 0 : Convert.ToInt64(transactionObj.ServiceChages);
                ReportParameter ServiceCharges = new ReportParameter("ServiceCharges", ServiceCharge.ToString());
                rv.LocalReport.SetParameters(ServiceCharges);

                ReportParameter TotalAmount = new ReportParameter("TotalAmount", transactionObj.TotalAmount.ToString());
                rv.LocalReport.SetParameters(TotalAmount);

                ReportParameter TaxAmount = new ReportParameter("TaxAmount", transactionObj.TaxAmount.ToString());
                rv.LocalReport.SetParameters(TaxAmount);

                ReportParameter PName = new ReportParameter("PatientName", transactionObj.Customer.Name.ToString());
                rv.LocalReport.SetParameters(PName);

                ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", transactionObj.DiscountAmount.ToString());
                rv.LocalReport.SetParameters(DiscountAmount);

                ReportParameter PaidAmount = new ReportParameter("PaidAmount", transactionObj.RecieveAmount.ToString());
                rv.LocalReport.SetParameters(PaidAmount);

                ReportParameter Change = new ReportParameter("Change",(transactionObj.RecieveAmount - (transactionObj.TotalAmount - ExtraDiscount + ExtraTax)).ToString());//(amount - (DetailList.Sum(x => x.TotalAmount) - ExtraDiscount + ExtraTax))
                rv.LocalReport.SetParameters(Change);


                PrintDoc.PrintReport(rv, "Slip");
                #endregion
            }
        }

        private void dgvTransactionDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currentTransactionId = Convert.ToInt32(dgvTransactionDetail.Rows[e.RowIndex].Cells[8].Value.ToString());
                bool IsSame = false;
                //Delete the record and add delete log
                if (e.ColumnIndex == 7)
                {
                    APP_Data.TransactionDetail tdOBj = new TransactionDetail();
                    APP_Data.Transaction tObj = new Transaction();

                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        tdOBj = entity.TransactionDetails.Where(x => x.Id == currentTransactionId).FirstOrDefault();

                        if (tdOBj != null)
                        {
                            tObj = entity.Transactions.Where(x => x.ParentId == tdOBj.TransactionId && x.IsDeleted == false).FirstOrDefault();
                        }
                        if (tObj != null)
                        {
                            TransactionDetail td = entity.TransactionDetails.Where(x => x.TransactionId == tObj.Id).FirstOrDefault();
                            if (td != null)
                            {
                                if (td.ProductId == tdOBj.ProductId)
                                {
                                    IsSame = true;
                                }
                            }
                        }
                        if (IsSame)
                        {
                            MessageBox.Show("This transaction detail already make refund. So it can't be delete!");
                            return;
                        }
                        else
                        {
                            if (dgvTransactionDetail.Rows.Count <= 1)
                            {
                                DialogResult result2 = MessageBox.Show("You have only one record!.If you delete this,system will automatically delete Transaction of this record", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (result2.Equals(DialogResult.OK))
                                {
                                    TransactionDetail ts = entity.TransactionDetails.Where(x => x.Id == currentTransactionId).FirstOrDefault();
                                    Transaction t = entity.Transactions.Where(x => x.Id == ts.TransactionId).FirstOrDefault();

                                    t.IsDeleted = true;
                                    foreach (TransactionDetail td in t.TransactionDetails)
                                    {
                                        td.IsDeleted = false;
                                    }

                                    ts.Product.Qty = ts.Product.Qty + ts.Qty;

                                    if (ts.Product.IsWrapper == true)
                                    {
                                        List<WrapperItem> wList = ts.Product.WrapperItems.ToList();
                                        if (wList.Count > 0)
                                        {
                                            foreach (WrapperItem w in wList)
                                            {
                                                Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                                wpObj.Qty = wpObj.Qty + ts.Qty;
                                            }
                                        }
                                    }

                                    //For Purchase 
                                    #region Purchase Delete 


                                    
                                    List<APP_Data.PurchaseDetailInTransaction> puInTranDetail = entity.PurchaseDetailInTransactions.Where(x => x.TransactionDetailId == ts.Id && x.ProductId == ts.ProductId).ToList();
                                    if (puInTranDetail.Count > 0)
                                    {
                                        foreach (PurchaseDetailInTransaction p in puInTranDetail)
                                        {
                                            PurchaseDetail pud = entity.PurchaseDetails.Where(x => x.Id == p.PurchaseDetailId).FirstOrDefault();
                                            if(pud != null)
                                            {
                                                pud.CurrentQy = pud.CurrentQy + p.Qty;    
                                            }
                                            entity.Entry(pud).State = EntityState.Modified;
                                            entity.SaveChanges();

                                            //entity.PurchaseDetailInTransactions.Remove(p);
                                            p.Qty = 0;
                                            entity.Entry(p).State = EntityState.Modified;
                                            entity.SaveChanges();                                          
                                        }
                                    }

                                    #endregion




                                    DeleteLog dl = new DeleteLog();
                                    dl.DeletedDate = DateTime.Now;
                                    dl.CounterId = MemberShip.CounterId;
                                    dl.UserId = MemberShip.UserId;
                                    dl.IsParent = true;
                                    dl.TransactionId = t.Id;
                                    //dl.TransactionDetailId = ts.Id;

                                    #region OldCode
                                    //Transaction ParentTransaction = entity.Transactions.Where(x => x.Id == ts.TransactionId).FirstOrDefault();
                                    //ParentTransaction.TotalAmount = ParentTransaction.TotalAmount - ts.TotalAmount;
                                    //if (ParentTransaction != null)
                                    //{
                                    //    ParentTransaction.IsDeleted = true;
                                    //    foreach (TransactionDetail td in ParentTransaction.TransactionDetails)
                                    //    {
                                    //        td.IsDeleted = true;
                                    //    }
                                    //}
                                    #endregion

                                    List<DeleteLog> delist = entity.DeleteLogs.Where(x => x.TransactionId == t.Id && x.TransactionDetailId != null && x.IsParent == false).ToList();

                                    foreach (DeleteLog d in delist)
                                    {
                                        entity.DeleteLogs.Remove(d);
                                    }
                                    entity.DeleteLogs.Add(dl);
                                    entity.SaveChanges();
                                    LoadData();
                                    this.Close();

                                    if (System.Windows.Forms.Application.OpenForms["TransactionList"] != null)
                                    {
                                        TransactionList newForm = (TransactionList)System.Windows.Forms.Application.OpenForms["TransactionList"];
                                        newForm.LoadData();
                                    }
                                }
                            }
                            else
                            {
                                TransactionDetail ts = entity.TransactionDetails.Where(x => x.Id == currentTransactionId).FirstOrDefault();
                                Transaction t = entity.Transactions.Where(x => x.Id == ts.TransactionId).FirstOrDefault();

                                ts.IsDeleted = true;

                                ts.Product.Qty = ts.Product.Qty + ts.Qty;
                                if (ts.Product.IsWrapper == true)
                                {
                                    List<WrapperItem> wList = ts.Product.WrapperItems.ToList();
                                    if (wList.Count > 0)
                                    {
                                        foreach (WrapperItem w in wList)
                                        {
                                            Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                            wpObj.Qty = wpObj.Qty + ts.Qty;
                                        }
                                    }
                                }
                                DeleteLog dl = new DeleteLog();
                                dl.DeletedDate = DateTime.Now;
                                dl.CounterId = MemberShip.CounterId;
                                dl.UserId = MemberShip.UserId;
                                dl.IsParent = false;
                                dl.TransactionId = ts.TransactionId;
                                dl.TransactionDetailId = ts.Id;

                                Transaction ParentTransaction = entity.Transactions.Where(x => x.Id == ts.TransactionId).FirstOrDefault();
                                ParentTransaction.TotalAmount = ParentTransaction.TotalAmount - ts.TotalAmount;

                                entity.DeleteLogs.Add(dl);
                                entity.SaveChanges();

                                //For Purchase 
                                #region Purchase Delete



                                List<APP_Data.PurchaseDetailInTransaction> puInTranDetail = entity.PurchaseDetailInTransactions.Where(x => x.TransactionDetailId == ts.Id && x.ProductId == ts.ProductId).ToList();
                                if (puInTranDetail.Count > 0)
                                {
                                    foreach (PurchaseDetailInTransaction p in puInTranDetail)
                                    {
                                        PurchaseDetail pud = entity.PurchaseDetails.Where(x => x.Id == p.PurchaseDetailId).FirstOrDefault();
                                        if (pud != null)
                                        {
                                            pud.CurrentQy = pud.CurrentQy + p.Qty;
                                        }
                                        entity.Entry(pud).State = EntityState.Modified;
                                        entity.SaveChanges();

                                        entity.PurchaseDetailInTransactions.Remove(p);
                                        entity.SaveChanges();
                                    }
                                }

                                #endregion






                                LoadData();
                                if (System.Windows.Forms.Application.OpenForms["TransactionList"] != null)
                                {
                                    TransactionList newForm = (TransactionList)System.Windows.Forms.Application.OpenForms["TransactionList"];
                                    newForm.LoadData();
                                }
                            }
                        }
                    }
                }
            }    
        }
      

        #endregion

        #region Function

        private void LoadData()
        {
            dgvTransactionDetail.AutoGenerateColumns = false;
            tlpCredit.Visible = false;
            Transaction transactionObject = (from t in entity.Transactions where t.Id == transactionId select t).FirstOrDefault();
            groupId = transactionObject.GroupID;
            var shift = (from a in entity.DailyDutyPhysios where a.Id == groupId select a.Shift).FirstOrDefault();

            lblShift.Text = shift;

            lblSalePerson.Text = (transactionObject.User == null) ? "-" : transactionObject.User.Name;
            lblDate.Text = transactionObject.DateTime.Value.ToString("dd-MM-yyyy");
            lblTime.Text = transactionObject.DateTime.Value.ToString("hh:mm");
            lblCustomerName.Text = (transactionObject.Customer == null) ? "-" : transactionObject.Customer.Name;
            lblDoctor.Text = (transactionObject.DoctorPhysio == null) ? "-" : transactionObject.DoctorPhysio.Name;
            lblGroup.Text = (transactionObject.Group == null) ? "-" : transactionObject.Group.GroupName;
            lblConsultantFees.Text =transactionObject.Consultantfees.ToString();
            if (transactionObject.Customer.Name == null)
            {
                cboCustomer.SelectedIndex = 0;
            }
            else
            {
                cboCustomer.Text = transactionObject.Customer.Name;
            }

            if (transactionObject.Type == TransactionType.Settlement)
            {
                dgvTransactionDetail.DataSource = "";
                lblRecieveAmunt.Text = transactionObject.RecieveAmount.ToString();
                lblDiscount.Text = "0";
                lblTotal.Text = transactionObject.TotalAmount.ToString();
                lblServiceCharges.Text = transactionObject.ServiceChages.ToString();
                lblPaymentMethod1.Text = (transactionObject.PaymentType == null) ? "-" : transactionObject.PaymentType.Name;
                
                tlpCash.Visible = true;
            }
            else if (transactionObject.Type == TransactionType.Sale || transactionObject.Type == TransactionType.Credit)
            {
                dgvTransactionDetail.DataSource = transactionObject.TransactionDetails.Where(x=>x.IsDeleted != true).ToList();
                lblRecieveAmunt.Text = transactionObject.RecieveAmount.ToString();
                int discount = 0;
                int tax = 0;                
                foreach (TransactionDetail td in transactionObject.TransactionDetails)
                {
                    discount += Convert.ToInt32(((td.UnitPrice) * (td.DiscountRate / 100)) * td.Qty);
                    tax += Convert.ToInt32((td.UnitPrice * (td.TaxRate / 100)) * td.Qty);                   
                }
                lblDiscount.Text = (transactionObject.DiscountAmount - discount).ToString();
                lblTotalTax.Text = (transactionObject.TaxAmount).ToString();
                lblTotal.Text = transactionObject.TotalAmount.ToString();
                lblServiceCharges.Text = transactionObject.ServiceChages.ToString();
                ExtraDiscount = Convert.ToInt32(transactionObject.DiscountAmount - discount);
                ExtraTax = Convert.ToInt32(transactionObject.TaxAmount - tax);

               

                
                lblPaymentMethod1.Text = (transactionObject.PaymentType == null) ? "-" : transactionObject.PaymentType.Name; ;
                if (transactionObject.PaymentTypeId == 2)
                {
                    List<Transaction> OldOutStandingList = entity.Transactions.Where(x => x.CustomerId == transactionObject.CustomerId).Where(x => x.IsPaid == false).Where(x => x.DateTime < transactionObject.DateTime).ToList().Where(x => x.IsDeleted != true).ToList();

                    long OldOutstandingAmount = 0;

                    foreach (Transaction t in OldOutStandingList)
                    {
                        OldOutstandingAmount += (long)t.TotalAmount - (long)t.RecieveAmount;
                    }
                    long PrepaidDebt = 0;
                    List<Transaction> PrePaidList = entity.Transactions.Where(x => x.CustomerId == transactionObject.CustomerId).Where(x => x.IsActive == false).Where(x => x.Type == TransactionType.Prepaid).ToList().Where(x => x.IsDeleted != true).ToList();
                    foreach(Transaction t in PrePaidList)
                    {
                        long useAmount = 0;
                        if (t.UsePrePaidDebts != null)
                        {
                            useAmount = (long)t.UsePrePaidDebts.Sum(x => x.UseAmount);
                        }
                        PrepaidDebt += Convert.ToInt32(t.RecieveAmount - useAmount);
                    }
                    if (transactionObject.UsePrePaidDebts != null)
                    {
                        PrepaidDebt += (long)transactionObject.UsePrePaidDebts.Sum(x => x.UseAmount);
                    }
                    if (OldOutstandingAmount > 0)
                    {
                        OldOutstandingAmount -= PrepaidDebt;
                    }
                    tlpCredit.Visible = true;
                    lblOutstandingAmount.Text = PrepaidDebt.ToString();
                    lblPrevTitle.Text = "Used Prepaid Amount";
                    //lblPayableCredit.Text = ((transactionObject.TotalAmount + OldOutstandingAmount) - transactionObject.RecieveAmount).ToString();
                    //lblOutstandingAmount.Text = OldOutstandingAmount.ToString();
                }
                tlpCash.Visible = true;

            }
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {

                Transaction transactionObject = (from t in entity.Transactions where t.Id == transactionId select t).FirstOrDefault();
                transactionObject.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
               // transactionObject.UpdatedDate = DateTime.Now;
                entity.Entry(transactionObject).State = EntityState.Modified;
                entity.SaveChanges();
                MessageBox.Show("Successfully Updated!", "Update");
            }
        }

        private void lbAdvanceSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //CustomerSearch form = new CustomerSearch();
            //form.ShowDialog();
        }

        private void lnkAssignStaff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDailyDutyList frm = new frmDailyDutyList();
            frm.shift = lblShift.Text;
            frm.ShowDialog();
        }

    }
}
