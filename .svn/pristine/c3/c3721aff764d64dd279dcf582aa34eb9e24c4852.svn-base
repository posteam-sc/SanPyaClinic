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
    public partial class PaidByCash : Form
    {
        #region Variables

        public List<TransactionDetail> DetailList = new List<TransactionDetail>();

        public int Discount { get; set; }

        public int Tax { get; set; }

        public int ExtraDiscount { get; set; }

        public int ExtraTax { get; set; }

        public Boolean isDraft { get; set; }

        public Boolean isDebt { get; set; }

        public string DraftId { get; set; }

        public string DebtId { get; set; }
        public string Type { get; set; }
        public long DebtAmount { get; set; }

        public int CustomerId { get; set; }
        public int DId { get; set; }
        public int Cfees { get; set; }
        public int PId { get; set; }
        public int SC { get; set; }
        public long PrePaidAmount { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        #endregion

        public PaidByCash()
        {
            InitializeComponent();
           
        }

        private void PaidByCash_Load(object sender, EventArgs e)
        {
            if (!isDebt)
            {
                lblTotalCost.Text = (DetailList.Sum(x => x.TotalAmount) + Cfees - ExtraDiscount + ExtraTax).ToString();
            }
            else
            {               
                lblTotalCost.Text = DebtAmount.ToString();
            }
        }

        private void txtReceiveAmount_KeyUp(object sender, KeyEventArgs e)
        {
            int amount = 0;
            Int32.TryParse(txtReceiveAmount.Text, out amount);
            if (!isDebt)
            {
                lblChanges.Text = (amount - (DetailList.Sum(x => x.TotalAmount) - ExtraDiscount + ExtraTax)).ToString();
            }
            else
            {
                lblChanges.Text = (amount - DebtAmount).ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            long receiveAmount = 0;
            long totalCost = (long)DetailList.Sum(x => x.TotalAmount) + Cfees + ExtraTax - ExtraDiscount;
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
            if (isDebt)
            {
                if (receiveAmount < DebtAmount)
                {
                    tp.SetToolTip(txtReceiveAmount, "Error");
                    tp.Show("Receive amount must be greater than debt amount!", txtReceiveAmount);
                    hasError = true;
                }
            }
            if (!hasError)
            {
                string resultId = "-";
                System.Data.Objects.ObjectResult<String> Id;
                if (!isDebt)
                {
                    if (Type == "Doctor")
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, null, DId, SC,null,Cfees);
                        resultId = Id.FirstOrDefault().ToString();

                    }
                    else if (Type == "Physio")
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, null,DId, SC,PId,Cfees);
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
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, null, null, SC,null,Cfees);
                        resultId = Id.FirstOrDefault().ToString();
                    }
                }
                else
                {
                    if (Type == "Doctor")
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, receiveAmount, null, CustomerId, DId, SC,null,Cfees);
                        resultId = Id.FirstOrDefault().ToString();
                    }
                    else if (Type == "Physio")
                    {
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, receiveAmount, null, CustomerId, DId, SC,PId,null);
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
                        Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, receiveAmount, null, CustomerId, null, SC,null,Cfees);
                        resultId = Id.FirstOrDefault().ToString();
                    }
                }
                entity = new POSEntities();
              
                Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();


                foreach (TransactionDetail detail in DetailList)
                {
                    detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                    detail.Product.Qty = detail.Product.Qty - detail.Qty;
                    insertedTransaction.TransactionDetails.Add(detail);
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
                    }
                }
                #region toCheck (important)
                //else if (isDebt)
                //{
                //    Transaction debt = (from trans in entity.Transactions where trans.Id == DebtId select trans).FirstOrDefault<Transaction>();
                //    debt.IsPaid = true;
                //}
                #endregion
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
                    newRow.TotalAmount = (int)transaction.TotalAmount;
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

                APP_Data.Counter c = entity.Counters.FirstOrDefault(x => x.Id == MemberShip.CounterId);

                ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                rv.LocalReport.SetParameters(CounterName);

                ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                rv.LocalReport.SetParameters(PrintDateTime);

                ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                rv.LocalReport.SetParameters(CasherName);

                ReportParameter TotalAmount = new ReportParameter("TotalAmount", insertedTransaction.TotalAmount.ToString());
                rv.LocalReport.SetParameters(TotalAmount);

                Int64 Consultantfee = insertedTransaction.Consultantfees == null ? 0 : Convert.ToInt64(insertedTransaction.Consultantfees);
                ReportParameter Consultant = new ReportParameter("Consultantfees", Consultantfee.ToString());
                rv.LocalReport.SetParameters(Consultant);

                Int64 ServiceCharge = insertedTransaction.ServiceChages == null ? 0 : Convert.ToInt64(insertedTransaction.ServiceChages);
                ReportParameter ServiceCharges = new ReportParameter("ServiceCharges", ServiceCharge.ToString());
                rv.LocalReport.SetParameters(ServiceCharges);

                ReportParameter TaxAmount = new ReportParameter("TaxAmount", insertedTransaction.TaxAmount.ToString());
                rv.LocalReport.SetParameters(TaxAmount);

                ReportParameter PName = new ReportParameter("PatientName", insertedTransaction.Customer.Name.ToString());
                rv.LocalReport.SetParameters(PName);

                ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", insertedTransaction.DiscountAmount.ToString());
                rv.LocalReport.SetParameters(DiscountAmount);

                ReportParameter PaidAmount = new ReportParameter("PaidAmount", txtReceiveAmount.Text);
                rv.LocalReport.SetParameters(PaidAmount);

                ReportParameter Change = new ReportParameter("Change", lblChanges.Text);
                rv.LocalReport.SetParameters(Change);


                PrintDoc.PrintReport(rv, "Slip");
                #endregion


                MessageBox.Show("Payment Completed");
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

        private void PaidByCash_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtReceiveAmount);
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
