using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;

namespace POS
{
    public partial class TransactionList : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();

        #endregion

        #region Event

        public TransactionList()
        {
            InitializeComponent();
        }

        private void TransactionList_Load(object sender, EventArgs e)
        {
            dgvTransactionList.AutoGenerateColumns = false;
            ReloadDoctorList();
            LoadData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rdbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDate.Checked)
            {
                gbDate.Enabled = true;
                gbId.Enabled = false;
                gbDoctor.Enabled = false;
            }
            else
            {
                gbDate.Enabled = false;
                gbId.Enabled = true;
                
            }
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
       
        private void dgvTransactionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                string currentTransactionId = dgvTransactionList.Rows[e.RowIndex].Cells[0].Value.ToString();
                //Refund
                if (e.ColumnIndex == 8)
                {
                    Transaction tObj = (Transaction)dgvTransactionList.Rows[e.RowIndex].DataBoundItem;
                    if (tObj.PaymentTypeId == 4)
                    {
                        MessageBox.Show("Non Refundable!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        RefundTransaction newForm = new RefundTransaction();
                        newForm.transactionId = currentTransactionId;
                        newForm.ShowDialog();
                    }
                }
                //to print
                //else if (e.ColumnIndex == 8)
                //{
                //    //to print
                //}
                //View Detail
                else if (e.ColumnIndex == 9)
                {
                    TransactionDetailForm newForm = new TransactionDetailForm();
                    newForm.transactionId = currentTransactionId;
                    newForm.ShowDialog();
                }
                //Delete the record and add delete log
                else if (e.ColumnIndex == 10)
                {
                    Transaction ts = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();

                    APP_Data.Transaction ts2 = entity.Transactions.Where(x => x.ParentId == currentTransactionId && x.IsDeleted == false).FirstOrDefault();
                    if (ts2 != null)
                    {
                        MessageBox.Show("This transaction already made a refund. It cannot be deleted!");
                      
                    }
                    else
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {

                            ts.IsDeleted = true;

                            foreach (TransactionDetail detail in ts.TransactionDetails)
                            {
                                detail.IsDeleted = false;
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

                                //For Purchase 
                                #region Purchase Delete

                                List<APP_Data.PurchaseDetailInTransaction> puInTranDetail = entity.PurchaseDetailInTransactions.Where(x => x.TransactionDetailId == detail.Id && x.ProductId == detail.ProductId).ToList();
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

                                        //entity.PurchaseDetailInTransactions.Remove(p);
                                        //entity.SaveChanges();

                                        p.Qty = 0;
                                        entity.Entry(p).State = EntityState.Modified;
                                        entity.SaveChanges();
                                    }
                                }
                                #endregion
                            }

                            DeleteLog dl = new DeleteLog();
                            dl.DeletedDate = DateTime.Now;
                            dl.CounterId = MemberShip.CounterId;
                            dl.UserId = MemberShip.UserId;
                            dl.IsParent = true;
                            dl.TransactionId = ts.Id;

                            entity.DeleteLogs.Add(dl);

                            entity.SaveChanges();

                            LoadData();
                        }
                    }
                }

                else if(e.ColumnIndex==11)
                {
                    Transaction ts = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();

                    List<Transaction> rlist = new List<Transaction>();

                    if (ts.Transaction1.Count > 0)
                    {
                        rlist = ts.Transaction1.Where(x => x.IsDeleted == false).ToList();
                    }
                    if (rlist.Count > 0)
                    {
                        MessageBox.Show("This transaction already make refund. So it can't be delete!");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                            {
                                Sales openedForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                                openedForm.DeleteCopy(currentTransactionId);
                                this.Dispose();
                            }
                        }
                    }
                }
            }
        }           

        private void dgvTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransactionList.Rows)
            {
                Transaction currentt = (Transaction)row.DataBoundItem;
                row.Cells[0].Value = currentt.Id;
                row.Cells[1].Value = currentt.Customer.Name;
                row.Cells[2].Value = currentt.Type;
                row.Cells[3].Value = currentt.PaymentType.Name;
                row.Cells[4].Value = currentt.DateTime.Value.ToString("dd-MM-yyyy");
                row.Cells[5].Value = currentt.DateTime.Value.ToString("hh:mm");
                row.Cells[6].Value = currentt.User.Name;
                row.Cells[7].Value = currentt.TotalAmount;
            }
        }

        #endregion

        #region Function
        public void LoadData()
        {
            entity = new POSEntities();

            if (rdbDate.Checked)
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;
                List<Transaction> transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Sale && t.IsDeleted==false select t).ToList<Transaction>();
                dgvTransactionList.DataSource = transList.Where(x => x.IsDeleted != true).ToList() ;
            }
            else if(rdbId.Checked)
            {
                string Id = txtId.Text;
                if (Id.Trim() != string.Empty)
                {
                    List<Transaction> transList = (from t in entity.Transactions where t.Id == Id select t).ToList().Where(x => x.IsDeleted != true).ToList();
                    if (transList.Count > 0)
                    {
                        dgvTransactionList.DataSource = transList;
                    }
                    else
                    {
                        dgvTransactionList.DataSource = "";
                        MessageBox.Show("Item not found!", "Cannot find");
                    }
                }
                else
                {
                    dgvTransactionList.DataSource = "";
                }
                
            }
            else if (rdoDoctor.Checked)
            {
                if (cboDoctor.SelectedIndex > 0)
                {
                    int Idd = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                    List<Transaction> transList = (from t in entity.Transactions where t.DoctorID == Idd select t).ToList().Where(x => x.IsDeleted != true).ToList();
                    if (transList.Count > 0)
                    {
                        dgvTransactionList.DataSource = transList;
                    }
                    else
                    {
                        dgvTransactionList.DataSource = "";
                        MessageBox.Show("Item not found!", "Cannot find");
                    }
                }
                else
                {
                    dgvTransactionList.DataSource = "";
                }
            }
        }

        #endregion

        private void dgvTransactionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rdoDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDoctor.Checked == true)
            {
                gbDate.Enabled = false;
                gbDoctor.Enabled = true;
                gbId.Enabled = false;
            }
        }

        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbId.Checked)
            {
                gbDate.Enabled = false;
                gbDoctor.Enabled = false;
                gbId.Enabled = true;
            }
        }

       
        
    }
}
