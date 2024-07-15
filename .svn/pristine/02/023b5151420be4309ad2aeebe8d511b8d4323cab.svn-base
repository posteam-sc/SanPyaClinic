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
using System.Data.Objects;


namespace POS
{
    public partial class ExpenseEntry : Form
    {
        #region variable
        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        private decimal totalAmount;
        List<ExpenseController> expenseList = new List<ExpenseController>();
        public string ExpenseNo = "";
        public int expenseId = 0;
        public bool IsAdd = false;
        List<int> expDetailIdList = new List<int>();

        #endregion

        #region event

        public ExpenseEntry()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void ExpenseEntry_Load(object sender, EventArgs e)
        {
            Utility.BindExpenseCategory(cboExpense);
            if (expenseId == 0)
            {
               
                totalAmount = 0;
            }
            else
            {
                btnCancel.Enabled = false;
                Expense editExp = (from exp in entity.Expenses where exp.Id == expenseId select exp).FirstOrDefault();
                if (editExp != null)
                {
                    txtExpNo.Text = editExp.ExpenseNo.Trim();
                    cboExpense.Text = (editExp.ExpenseCategory == null) ? "-" : editExp.ExpenseCategory.Name;
                    cboExpense.Enabled = false;
                    cboExpense.SelectedValue = editExp.ExpenseCategoryId;

                    txtTotalExpense.Text = Convert.ToInt32(editExp.TotalExpenseAmount).ToString();
                    txtComment.Text = editExp.Comment.ToString();

                    var editDetailExp = (from p in entity.ExpenseDetails where p.ExpenseId == expenseId select p).ToList();

                    expenseList.AddRange(editDetailExp.Select(_exp =>
                        new ExpenseController
                        {
                            ExpenseDetailId = Convert.ToInt32(_exp.Id.ToString()),
                            ExpenseNo = _exp.ExpenseId.ToString(),
                            Description = _exp.Description.ToString(),
                            Qty = Convert.ToDecimal(_exp.Qty.ToString()),
                            Price = Convert.ToDecimal(_exp.Price.ToString()),
                            Amount = Convert.ToDecimal(_exp.Qty.ToString()) * Convert.ToDecimal(_exp.Price.ToString())

                        }
                        )
                        );
                    dgvExpenseList.DataSource = expenseList;
                    btnSave.Image = POS.Properties.Resources.update_big;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            bool hasError = false;
            dgvExpenseList.AutoGenerateColumns = false;
            Expense newexp = new Expense();
            if (cboExpense.SelectedIndex == 0)
            {
                tp.SetToolTip(cboExpense, "Error");
                tp.Show("Please fill up Expense category name!", cboExpense);
                hasError = true;
            }
            else if (txtDescription.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtDescription, "Error");
                tp.Show("Please fill up Description for expense", txtDescription);
                hasError = true;
            }
            else if (txtQty.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtQty, "Error");
                tp.Show("Please fill up Qty", txtQty);
                hasError = true;
            }
            else if (txtPrice.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtPrice, "Error");
                tp.Show("Please fill up Price of expense", txtPrice);
                hasError = true;
            }
       
            else
            {
                dgvExpenseList.DataSource = "";
                if (!hasError)
                {
                    if (IsAdd == false)
                    {


                        int expCategoryID = Convert.ToInt32(cboExpense.SelectedIndex);

                        ExpenseController exp = new ExpenseController();
                        exp.Description = txtDescription.Text.Trim();
                        exp.Qty = Convert.ToDecimal(txtQty.Text); ;
                        exp.Price = Convert.ToDecimal(txtPrice.Text);
                        exp.Amount = exp.Qty * exp.Price;


                        expenseList.Add(exp);

                        IsAdd = true;
                        if (IsAdd)
                        {
                            cboExpense.Enabled = false;
                        }
                    }
                    else
                    {
                        cboExpense.Enabled = false;

                        int expCategoryID = Convert.ToInt32(cboExpense.SelectedIndex);

                        ExpenseController exp = new ExpenseController();
                        exp.Description = txtDescription.Text.Trim();
                        exp.Qty = Convert.ToDecimal(txtQty.Text); ;
                        exp.Price = Convert.ToDecimal(txtPrice.Text);
                        exp.Amount = exp.Qty * exp.Price;


                        expenseList.Add(exp);




                    }
                }
                dgvExpenseList.DataSource = expenseList;
                if (expenseId != 0)
                {
                    totalAmount = Convert.ToDecimal(txtTotalExpense.Text);
                }
                totalAmount += Convert.ToInt32(txtQty.Text.ToString()) * Convert.ToInt32(txtPrice.Text.ToString());
                txtTotalExpense.Text = Convert.ToInt32(totalAmount).ToString();

                txtDescription.Text = "";
                txtQty.Text = "";
                txtPrice.Text = "";

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Expense MainExp = new Expense();
            entity = new POSEntities();
            if (expenseId != 0)
            {
                Expense exp = entity.Expenses.Where(x => x.Id == expenseId).FirstOrDefault();
                exp.Id = expenseId;
                exp.ExpenseDate = dtDate.Value.Date;

                exp.IsApproved = false;
                exp.IsDeleted = false;
                exp.UpdatedDate = DateTime.Now;
                exp.UpdatedUser = MemberShip.UserId;
                exp.TotalExpenseAmount = totalAmount;
                exp.Comment = txtComment.Text;

                entity.SaveChanges();

                foreach (ExpenseController explist in expenseList)
                {
                    if (explist.ExpenseDetailId == 0)
                    {
                        APP_Data.ExpenseDetail expnewadd = new APP_Data.ExpenseDetail();
                        expnewadd.ExpenseId = expenseId;
                        expnewadd.Description = explist.Description;
                        expnewadd.Qty = explist.Qty;
                        expnewadd.Price = explist.Price;
                        entity.ExpenseDetails.Add(expnewadd);
                        entity.SaveChanges();
                    }
                    else
                    {
                        APP_Data.ExpenseDetail expeditdetail = entity.ExpenseDetails.Where(x => x.Id == explist.ExpenseDetailId).FirstOrDefault();
                        entity.Entry(expeditdetail).State = EntityState.Modified;
                        entity.SaveChanges();
                    }
                }

                if (System.Windows.Forms.Application.OpenForms["ExpenseList"] != null)
                {
                    ExpenseList newForm = (ExpenseList)System.Windows.Forms.Application.OpenForms["ExpenseList"];
                    newForm.DataBind();
                }
                MessageBox.Show("Successfully updated!", "update");
                this.Close();
                clearDate();
            }
            else
            {
                //auto generate expense number
                string month = "";
                if (DateTime.Now.Month < 10)
                {
                    month = "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    month = DateTime.Now.Month.ToString();

                }
                string day = "";
                if (DateTime.Now.Day < 10)
                {
                    day = "0" + DateTime.Now.Day.ToString();
                }
                else
                {
                    day = DateTime.Now.Day.ToString();
                }


                DateTime date=dtDate.Value.Date;
                int?  _count;
                _count = (from con in entity.Expenses where (EntityFunctions.TruncateTime(con.CreatedDate) == date) orderby con.Id descending select con.Count ?? 0).FirstOrDefault();
                _count += 1;
                string ExpenseNumber;
                if (_count < 10)
                {
                     ExpenseNumber = "EP" + DateTime.Now.Year.ToString() + month + DateTime.Now.Day.ToString() + ("0" + _count).ToString();
                }
                else
                {
                     ExpenseNumber = "EP" + DateTime.Now.Year.ToString() + month + DateTime.Now.Day.ToString() + ( _count).ToString();
                }
                if (expenseList.Count > 0)
                {
                    Expense expenseObj = new Expense();
                    expenseObj.ExpenseNo = ExpenseNumber;
                    expenseObj.ExpenseDate = dtDate.Value.Date;
                    expenseObj.ExpenseCategoryId = Convert.ToInt32(cboExpense.SelectedValue); ;
                    expenseObj.CreatedDate = DateTime.Now;
                    expenseObj.CreatedUser = MemberShip.UserId;
                    expenseObj.IsApproved = false;
                    expenseObj.IsDeleted = false;
                    expenseObj.TotalExpenseAmount = totalAmount;
                    expenseObj.Comment = txtComment.Text;
                    expenseObj.Count = _count;

                    entity.Expenses.Add(expenseObj);
                    entity.SaveChanges();


                    ExpenseDetail expDetailObj = new ExpenseDetail();
                    foreach (ExpenseController exp in expenseList)
                    {
                        expDetailObj.ExpenseId = (from p in entity.Expenses where p.ExpenseNo == ExpenseNumber select p.Id).FirstOrDefault();
                        expDetailObj.Description = exp.Description;
                        expDetailObj.Qty = exp.Qty;
                        expDetailObj.Price = exp.Price;

                        entity.ExpenseDetails.Add(expDetailObj);
                        entity.SaveChanges();
                    }
                    MessageBox.Show("Successfully saved!", "save");
                    clearDate();
                }
                else
                {
                    MessageBox.Show("Please,first fill expense", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboExpense.Enabled = true;
                }
            }

        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Expense_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtDescription);
            tp.Hide(txtQty);
            tp.Hide(txtPrice);
            tp.Hide(cboExpense);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearDate();
           
        }


        private void dgvExpenseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvExpenseList.Rows)
            {
                ExpenseController exp = (ExpenseController)row.DataBoundItem;
                row.Cells[0].Value = Convert.ToInt32(exp.ExpenseDetailId);
                row.Cells[2].Value = exp.Description.ToString();
                row.Cells[3].Value = Convert.ToInt32(exp.Qty);
                row.Cells[4].Value = Convert.ToInt32(exp.Price);
                row.Cells[5].Value = Convert.ToInt32(exp.Amount);
            }
        }

        private void dgvExpenseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    int index = e.RowIndex;
                    int expDetailId = Convert.ToInt32(dgvExpenseList[0, e.RowIndex].Value);
                 
                    if (expenseId != 0)
                    {
                        ExpenseDetail deldetail = (from p in entity.ExpenseDetails where p.Id == expDetailId select p).FirstOrDefault();
                        if (deldetail != null)
                        {
                            entity.ExpenseDetails.Remove(deldetail);
                            entity.SaveChanges();
                        }
                    }

                    expDetailIdList.Add(expDetailId);
               
                    ExpenseController expobj = expenseList[index];
                    expenseList.RemoveAt(index);
                 
                    dgvExpenseList.DataSource = expenseList.ToList();
          
                    txtTotalExpense.Text = "";
                    totalAmount = 0;
                    totalAmount = Convert.ToDecimal(expenseList.Sum(x => x.Qty * x.Price));

                    txtTotalExpense.Text = totalAmount.ToString();



                }
            }
        }
        #endregion

        #region method
        private void clearDate()
        {
            cboExpense.Enabled = true;
            dgvExpenseList.DataSource = "";
            txtTotalExpense.Text = "";
            txtComment.Text = "";
            expenseList.Clear();
            totalAmount = 0;
            txtExpNo.Text = "";
            cboExpense.SelectedIndex = 0;
            btnCancel.Enabled = true;
            expenseId = 0;
            



        }
        #endregion





    }
}
