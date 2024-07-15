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

namespace POS
{
    public partial class RefundTransaction : Form
    {
        #region Variables

        public string transactionId { get; set; }

        private POSEntities entity = new POSEntities();

        public int DiscountAount { get; set; }

        Transaction currentTransaction;

        int discount = 0;

        #endregion

        #region Events

        public RefundTransaction()
        {
            InitializeComponent();
        }

        private void RefundTransaction_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            entity = new POSEntities();
            currentTransaction = (from c in entity.Transactions where c.Id == transactionId select c).FirstOrDefault();
            dgvItemLists.AutoGenerateColumns = false;

            foreach (TransactionDetail td in currentTransaction.TransactionDetails)
            {
                if (td.IsDeleted != true)
                {
                    int qty = Convert.ToInt32(td.Qty);
                    for (int count = 0; count < qty; count++)
                    {
                        dgvItemLists.AllowUserToAddRows = true;
                        DataGridViewRow row = (DataGridViewRow)dgvItemLists.Rows[count].Clone();
                        row.Cells[0].Value = false;
                        row.Cells[1].Value = td.Product.ProductCode;
                        row.Cells[2].Value = td.Product.Name;
                        row.Cells[3].Value = 1;
                        row.Cells[4].Value = td.UnitPrice;
                        row.Cells[5].Value = td.DiscountRate;
                        row.Cells[6].Value = td.TaxRate;
                        row.Cells[7].Value = getActualCost(td.Product);
                        row.Cells[8].Value = td.ProductId;
                        row.Cells[9].Value = td.Id.ToString();

                        dgvItemLists.Rows.Add(row);
                    }
                }
            }
            dgvItemLists.AllowUserToAddRows = false;
            DiscountAount = -1;

            // dgvItemLists.DataSource = currentTransaction.TransactionDetails.ToList();


            dgvRedundedList.AutoGenerateColumns = false;
            dgvRedundedList.DataSource = entity.Transactions.Where(x => x.Type == TransactionType.CreditRefund || x.Type == TransactionType.Refund).Where(x => x.ParentId == currentTransaction.Id).ToList().Where(x => x.IsDeleted != true).ToList();

            lblSalePerson.Text = currentTransaction.User.Name;
            lblDate.Text = currentTransaction.DateTime.Value.ToString("dd-MM-yyyy");
            lblTime.Text = currentTransaction.DateTime.Value.ToString("hh:mm");
            lblCash.Text = currentTransaction.RecieveAmount.ToString();
            lblTotal.Text = currentTransaction.TotalAmount.ToString();

            foreach (TransactionDetail td in currentTransaction.TransactionDetails)
            {
                discount += Convert.ToInt32(((td.UnitPrice) * (td.DiscountRate / 100)) * td.Qty);
                //tax += Convert.ToInt32((td.UnitPrice * (td.TaxRate / 100)) * td.Qty);
            }
            lblDiscount.Text = (currentTransaction.DiscountAmount - discount).ToString();
            lblMainTransaction.Text = currentTransaction.Id;
            if (currentTransaction.Type == TransactionType.Credit)
            {
                lblChangeGivenTitle.Text = "Payable Credit";
                lblChangeGiven.Text = (currentTransaction.TotalAmount - currentTransaction.RecieveAmount).ToString();
            }
            else
            {
                lblChangeGiven.Text = (currentTransaction.RecieveAmount - currentTransaction.TotalAmount).ToString();
            }
            
        }

        private decimal getActualCost(Product prod)
        {
            decimal? actualCost = 0;
            //decrease discount ammount            
            actualCost = prod.Price - ((prod.Price / 100) * prod.DiscountRate);
            //add tax ammount            
            actualCost = actualCost + ((prod.Price / 100) * prod.Tax.TaxPercent);
            return (decimal)actualCost;
        }

        private void dgvItemLists_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvItemLists.Rows)
            {
                TransactionDetail transactionDetailObj = (TransactionDetail)row.DataBoundItem;
                row.Cells[1].Value = transactionDetailObj.Product.ProductCode;
                row.Cells[2].Value = transactionDetailObj.Product.Name;
                row.Cells[3].Value = transactionDetailObj.Qty;
                row.Cells[4].Value = transactionDetailObj.UnitPrice;
                row.Cells[5].Value = transactionDetailObj.DiscountRate + "%";
                row.Cells[6].Value = transactionDetailObj.TaxRate + "%";
                row.Cells[7].Value = transactionDetailObj.TotalAmount;
            }
        }

        private void dgvRedundedList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRedundedList.Rows)
            {
                Transaction transObj = (Transaction)row.DataBoundItem;
                row.Cells[0].Value = transObj.Id;
                row.Cells[1].Value = transObj.DateTime.Value.ToString("dd-MM-yyyy");
                row.Cells[2].Value = transObj.DateTime.Value.ToString("hh:mm");
                row.Cells[3].Value = transObj.TotalAmount;
                row.Cells[4].Value = transObj.DiscountAmount;

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to refund these products?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                List<TransactionDetail> refundItems = new List<TransactionDetail>();
                int totalRefundAmount = 0;
                int totalDiscountAllItem = 0;

                #region Old Code
                        //foreach (DataGridViewRow row in dgvItemLists.Rows)
                        //{
                        //    if (Convert.ToBoolean(row.Cells[0].Value))
                        //    {
                        //        TransactionDetail refundDetail = new TransactionDetail();
                        //        TransactionDetail transactionDetailObj = (TransactionDetail)row.DataBoundItem;
                        //        refundDetail.ProductId = transactionDetailObj.Product.Id;
                        //        transactionDetailObj.Product.Qty = transactionDetailObj.Product.Qty + transactionDetailObj.Qty;
                        //        refundDetail.Qty = transactionDetailObj.Qty;
                        //        refundDetail.UnitPrice = transactionDetailObj.UnitPrice;
                        //        refundDetail.DiscountRate = transactionDetailObj.DiscountRate;
                        //        refundDetail.TaxRate = transactionDetailObj.TaxRate;
                        //        refundDetail.TotalAmount = transactionDetailObj.TotalAmount;
                        //        totalRefundAmount += (int)transactionDetailObj.TotalAmount;
                        //        totalDiscountAllItem += Convert.ToInt32(((transactionDetailObj.UnitPrice) * (transactionDetailObj.DiscountRate / 100)) * transactionDetailObj.Qty);
                        //        refundItems.Add(refundDetail);
                        //    }
                        //}

                //User refund more than one items
               
                #endregion

                foreach (DataGridViewRow row in dgvItemLists.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        TransactionDetail refundDetail = new TransactionDetail();
                        refundDetail.ProductId = Convert.ToInt32(row.Cells[8].Value);
                        int currentProductId = Convert.ToInt32(row.Cells[8].Value);
                        Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                        pro.Qty = pro.Qty + Convert.ToInt32(row.Cells[3].Value);
                        refundDetail.Qty = Convert.ToInt32(row.Cells[3].Value);
                        refundDetail.UnitPrice = Convert.ToInt32(row.Cells[4].Value);

                        string DiscountRate = row.Cells[5].Value.ToString();
                        string TaxRate = row.Cells[6].Value.ToString();

                        refundDetail.DiscountRate = Convert.ToDecimal(DiscountRate.Replace("%", ""));
                        refundDetail.TaxRate = Convert.ToDecimal(TaxRate.Replace("%", ""));
                        refundDetail.TotalAmount = Convert.ToInt32(row.Cells[7].Value);
                        totalRefundAmount += Convert.ToInt32(row.Cells[7].Value);
                        totalDiscountAllItem += Convert.ToInt32(((Convert.ToInt32(row.Cells[4].Value)) * (Convert.ToDecimal(DiscountRate.Replace("%", "")) / 100)) * Convert.ToInt32(row.Cells[3].Value));
                        refundDetail.Id = Convert.ToInt32(row.Cells[9].Value.ToString());
                        
                        refundItems.Add(refundDetail);
                    }
                }

                if (refundItems.Count > 0)
                {
                    string resultId = string.Empty;
                    string rId = string.Empty;
                    long CurrentDebt = 0;
                    int cusId;
                    if (currentTransaction.PaymentTypeId == 2 && currentTransaction.IsPaid == false)
                    {
                        #region Credit Refund
                        cusId = (int)currentTransaction.CustomerId;
                        CurrentDebt = Convert.ToInt64(entity.Transactions.Where(x => x.PaymentType.Name == "Credit").Where(x => x.Id == currentTransaction.Id).Where(x => x.IsPaid == false).Sum(x => x.TotalAmount - x.RecieveAmount));
                        if (currentTransaction.UsePrePaidDebts != null)
                        {
                            CurrentDebt -= (long)currentTransaction.UsePrePaidDebts.Sum(x => x.UseAmount);
                        }
                        Transaction DiscountTrans = entity.Transactions.Where(x => x.PaymentType.Name == "Credit").Where(x => x.Id == currentTransaction.Id).Where(x => x.IsPaid == false).FirstOrDefault();
                        //long Discount = (long)DiscountTrans.TransactionDetails.Sum(x => (x.UnitPrice * (x.DiscountRate / 100))).Value;
                        //CurrentDebt -= Convert.ToInt64(currentTransaction.DiscountAmount - discount);
                        List<Transaction> DebtList = entity.Transactions.Where(x => x.CustomerId == currentTransaction.CustomerId).ToList();
                        long DebtTotal = Convert.ToInt64(DebtList.Where(x => x.PaymentType.Name == "Credit").Where(x => x.IsPaid == false).Sum(x => x.TotalAmount - x.RecieveAmount));
                        List<Transaction> prePaidTranList = entity.Transactions.Where(tras => tras.Type == TransactionType.Prepaid).Where(x => x.CustomerId == currentTransaction.CustomerId).Where(trans => trans.IsActive == false).ToList();
                        long PrePaidamount = 0;
                        foreach (Transaction PrePaidDebtTrans in prePaidTranList)
                        {
                            int useAmount = (PrePaidDebtTrans.UsePrePaidDebts1 == null) ? 0 : (int)PrePaidDebtTrans.UsePrePaidDebts1.Sum(x => x.UseAmount);
                            PrePaidamount += (long)PrePaidDebtTrans.TotalAmount - useAmount;
                        }
                        long CreditRefundAmount = Convert.ToInt64(entity.Transactions.Where(x => x.ParentId == currentTransaction.Id).Where(x => x.Type == TransactionType.CreditRefund).Sum(x => x.RecieveAmount));
                        CurrentDebt -= CreditRefundAmount;

                        if (totalRefundAmount <= ((currentTransaction.TotalAmount + currentTransaction.DiscountAmount) - totalDiscountAllItem))
                        {

                            if (currentTransaction.DiscountAmount - discount > 0)
                            {
                                if (DiscountAount < 0)
                                {
                                    RefundDiscount newForm = new RefundDiscount();
                                    newForm.ShowDialog();
                                    return;
                                }
                            }
                            else
                            {
                                DiscountAount = 0;
                            }
                            // refund amount is smaller than current debt
                            if ((totalRefundAmount - DiscountAount) < CurrentDebt)
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, DiscountAount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAount, transactionId, null, cusId);
                                resultId = Id.FirstOrDefault().ToString();
                                CurrentDebt -= (totalRefundAmount - DiscountAount);
                                if (PrePaidamount > 0)
                                {
                                    if (CurrentDebt <= PrePaidamount)
                                    {
                                        Transaction CreditT = (from tr in entity.Transactions where tr.Id == currentTransaction.Id select tr).FirstOrDefault<Transaction>();
                                        CreditT.IsPaid = true;
                                        entity.Entry(CreditT).State = EntityState.Modified;
                                        entity.SaveChanges();
                                        foreach (Transaction PrePaidDebtTrans in prePaidTranList)
                                        {
                                            long CurrentPrePaid = 0;

                                            int useAmount = (PrePaidDebtTrans.UsePrePaidDebts1 == null) ? 0 : (int)PrePaidDebtTrans.UsePrePaidDebts1.Sum(x => x.UseAmount);
                                            CurrentPrePaid = (long)PrePaidDebtTrans.TotalAmount - useAmount;
                                            if (CurrentDebt >= CurrentPrePaid)
                                            {
                                                PrePaidDebtTrans.IsActive = true;
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)CurrentPrePaid;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = currentTransaction.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CurrentDebt -= CurrentPrePaid;
                                            }
                                            else
                                            {
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)CurrentDebt;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = currentTransaction.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CurrentDebt = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            //refundAmount is equal current debet
                            else if ((totalRefundAmount - DiscountAount) == CurrentDebt)
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, DiscountAount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAount, transactionId, null, cusId);
                                resultId = Id.FirstOrDefault().ToString();
                                Transaction CreditT = (from tr in entity.Transactions where tr.Id == currentTransaction.Id select tr).FirstOrDefault<Transaction>();
                                CreditT.IsPaid = true;
                                entity.Entry(CreditT).State = EntityState.Modified;
                                entity.SaveChanges();
                            }
                            //if refund amount is greather than current debt, add refund row and credit refund
                            else
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Refund, true, true, 1, 0, DiscountAount, totalRefundAmount - CurrentDebt, totalRefundAmount - CurrentDebt - DiscountAount, transactionId, null, cusId);
                                resultId = Id.FirstOrDefault().ToString();

                                System.Data.Objects.ObjectResult<String> CreditRefundId = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, 0, CurrentDebt, CurrentDebt, transactionId, null, cusId);
                                rId = CreditRefundId.FirstOrDefault().ToString();
                                //entity = new POSEntities();                           
                                //currentTransaction.IsPaid = true;
                                entity.Paid(true, currentTransaction.Id);
                                //entity.SaveChanges();
                            }
                        }
                        else
                        {
                            CurrentDebt = 0;
                            if (totalRefundAmount < ((currentTransaction.TotalAmount + currentTransaction.DiscountAmount) - totalDiscountAllItem))
                            {

                                if (currentTransaction.DiscountAmount - discount > 0)
                                {
                                    if (DiscountAount < 0)
                                    {
                                        RefundDiscount newForm = new RefundDiscount();
                                        newForm.ShowDialog();
                                        return;
                                    }
                                }
                                else
                                {
                                    DiscountAount = 0;
                                }
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, DiscountAount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAount, transactionId, null, cusId);
                                resultId = Id.FirstOrDefault().ToString();
                            }
                            else if (totalRefundAmount == (currentTransaction.TotalAmount + (currentTransaction.DiscountAmount - totalDiscountAllItem)))
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, (currentTransaction.DiscountAmount - totalDiscountAllItem), refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - (currentTransaction.DiscountAmount - totalDiscountAllItem), transactionId, null, cusId);
                                resultId = Id.FirstOrDefault().ToString();
                            }

                        }
                        #endregion


                        //List<Transaction> DebtList = entity.Transactions.Where(x => x.CustomerId == currentTransaction.CustomerId).ToList();                  

                    }
                    //Sale Refunds
                    else
                    {

                        if (totalRefundAmount < ((currentTransaction.TotalAmount + currentTransaction.DiscountAmount) - totalDiscountAllItem))
                        {

                            if (currentTransaction.DiscountAmount - discount > 0)
                            {
                                if (DiscountAount < 0)
                                {
                                    RefundDiscount newForm = new RefundDiscount();
                                    newForm.ShowDialog();
                                    return;
                                }
                            }
                            else
                            {
                                DiscountAount = 0;
                            }
                            System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Refund, true, true, 1, 0, DiscountAount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAount, transactionId, null, null);
                            resultId = Id.FirstOrDefault().ToString();
                        }
                        else if (totalRefundAmount == (currentTransaction.TotalAmount + (currentTransaction.DiscountAmount - totalDiscountAllItem)))
                        {
                            System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Refund, true, true, 1, 0, (currentTransaction.DiscountAmount - totalDiscountAllItem), refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - (currentTransaction.DiscountAmount - totalDiscountAllItem), transactionId, null, null);
                            resultId = Id.FirstOrDefault().ToString();
                            
                        }

                    }

                    #region Purchase Delete

                    foreach (TransactionDetail detail in refundItems)
                    {
                        List<APP_Data.PurchaseDetailInTransaction> puInTranDetail = (from p in entity.PurchaseDetailInTransactions where p.TransactionDetailId == detail.Id && p.ProductId == detail.ProductId orderby p.Id descending select p).ToList();
                        if (puInTranDetail.Count > 0)
                        {
                            foreach (PurchaseDetailInTransaction p in puInTranDetail)
                            {
                                PurchaseDetail pud = entity.PurchaseDetails.Where(x => x.Id == p.PurchaseDetailId).FirstOrDefault();
                                if (pud != null)
                                {
                                    if (pud.CurrentQy <= pud.Qty && p.Qty > 0)
                                    {
                                        pud.CurrentQy = pud.CurrentQy + detail.Qty;
                                        p.Qty = p.Qty - detail.Qty;
                                        entity.Entry(pud).State = EntityState.Modified;
                                        entity.Entry(p).State = EntityState.Modified;
                                        entity.SaveChanges();
                                        break;
                                    }
                                }
                            }
                        }
                    }                   
                    #endregion      

                    entity = new POSEntities();

                    //Normal Refund's Detail Transactions List
                    Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                    foreach (TransactionDetail detail in refundItems)
                    {
                        detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                        detail.Product.Qty = detail.Product.Qty + detail.Qty;

                        if (detail.Product.IsWrapper == true)
                        {
                            List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                            if (wList.Count > 0)
                            {
                                foreach (WrapperItem w in wList)
                                {
                                    Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                    wpObj.Qty = wpObj.Qty + detail.Qty;
                                }
                            }
                        }
                        
                        insertedTransaction.TransactionDetails.Add(detail);                      
                    }
                    insertedTransaction.IsDeleted = false;
                    entity.SaveChanges();

                    entity = new POSEntities();
                    //Credit refund's Detail Transactions List
                    Transaction ITrans = new Transaction();
                    if (rId != string.Empty)
                    {
                        ITrans = (from trans in entity.Transactions where trans.Id == rId select trans).FirstOrDefault<Transaction>();
                        foreach (TransactionDetail detail in refundItems)
                        {
                            TransactionDetail rftDetail = new TransactionDetail();
                            rftDetail.ProductId = detail.ProductId;
                            rftDetail.Qty = detail.Qty;
                            rftDetail.TaxRate = detail.TaxRate;
                            rftDetail.TotalAmount = detail.TotalAmount;
                            rftDetail.TransactionId = detail.TransactionId;
                            rftDetail.UnitPrice = detail.UnitPrice;
                            rftDetail.DiscountRate = detail.DiscountRate;

                            ITrans.TransactionDetails.Add(rftDetail);
                        }
                    }
                    entity.SaveChanges();
                    MessageBox.Show("Refund process completed!");
                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("Please choose at least one item to refund!");
                }
            }
        }        

        private void dgvRedundedList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                string currentTransactionId = dgvRedundedList.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 5)
                {
                    RefundDetail newForm = new RefundDetail();
                    newForm.transactionId = currentTransactionId;
                    newForm.IsRefund = false;
                    newForm.ShowDialog();
                }
            }
        }

        #endregion

        #region Function

        public void Reload()
        {
            btnSubmit_Click(this, null);
        }    

        #endregion
    }
}
