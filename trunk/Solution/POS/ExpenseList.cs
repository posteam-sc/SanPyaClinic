﻿using System;
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
    public partial class ExpenseList : Form
    {
        #region Variable

        public int expenseId;
        public string supplierName;
        POSEntities entity = new POSEntities();
        public static PurchaseListBySupplier plist;
        bool Approved = false;
        DateTime _fromDate = new DateTime();
        DateTime _toDate = new DateTime();
        bool _startProcess = false;

        int Qty = 0;

        #endregion

        #region Event

        public ExpenseList()
        {
            InitializeComponent();
            CenterToScreen();
            // plist = this;
        }

        private void ExpenseListBySupplier_Load(object sender, EventArgs e)
        {
            dtFrom.Format = DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "dd-MM-yyyy";

            dtTo.Format = DateTimePickerFormat.Custom;
            dtTo.CustomFormat = "dd-MM-yyyy";


            Default_Date();
            Radio_Status();
            Utility.BindExpenseCategory(cboExpenseCag);

            dgvExpenseList.AutoGenerateColumns = false;

            _startProcess = true;
            DataBind();
        }


        private void dgvExpenseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currentExpenseId = Convert.ToInt32(dgvExpenseList.Rows[e.RowIndex].Cells[0].Value);
                string vouncherNo = dgvExpenseList.Rows[e.RowIndex].Cells[2].Value.ToString();

                Expense _expense = (from p in entity.Expenses where p.Id == currentExpenseId select p).FirstOrDefault();
                //Edit
                if (e.ColumnIndex == 7)
                {
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Expense.EditOrDelete || MemberShip.isAdmin)
                    {
                    if (_expense.IsApproved == true)
                    {
                        MessageBox.Show("You have already approved Expense No. " + vouncherNo + " You cannot edit it anymore.");
                        return;
                    }
                    else
                    {
             
                        int _expenseId = Convert.ToInt32(dgvExpenseList.Rows[e.RowIndex].Cells[0].Value);

                        ExpenseEntry newform = new ExpenseEntry();
                        newform.expenseId = _expenseId;
                        newform.ShowDialog();
                    }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit expense.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                //View Detail
                if (e.ColumnIndex == 8)
                {
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Expense.ViewDetail || MemberShip.isAdmin)
                    {
                    string _expenseNo = dgvExpenseList.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DateTime _expenseDate = Convert.ToDateTime(dgvExpenseList.Rows[e.RowIndex].Cells[1].Value.ToString());
                    ExpenseDetailList newform = new ExpenseDetailList();
                    newform.expenseId = currentExpenseId;
                    newform.ExpenseCag = dgvExpenseList.Rows[e.RowIndex].Cells[5].Value.ToString();
                    newform.ExpenseNo = _expenseNo;
                    newform.ExpenseDate = _expenseDate.ToString("dd-MMM-yyyy");
                    newform.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to view expense detail", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Approved
                else if (e.ColumnIndex == 9)
                {
                    if (_expense.IsApproved == true)
                    {
                        MessageBox.Show("This Expense No. " + vouncherNo + " is already Approved!", "Information");
                        return;
                    }
                    else
                    {
                        RoleManagementController controller = new RoleManagementController();
                        controller.Load(MemberShip.UserRoleId);
                        if (controller.Expense.Approved || MemberShip.isAdmin)
                        {
                        DialogResult result1 = MessageBox.Show("Please note that you cannot edit  expense  anymore after you clicked Approved. ", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.OK))
                        {
                            _expense.IsApproved = true;
                            _expense.UpdatedDate = DateTime.Now;
                            _expense.UpdatedUser = MemberShip.UserId;

                            entity.Entry(_expense).State = EntityState.Modified;
                            entity.SaveChanges();

                            MessageBox.Show("Successfully Approved Expense no. " + vouncherNo);
                        }

                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to approve expense.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                //Delete
                else if (e.ColumnIndex == 10)
                {
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Expense.EditOrDelete || MemberShip.isAdmin)
                    {
                    if (_expense.IsApproved == false)
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.OK))
                        {


                            APP_Data.Expense expense = entity.Expenses.Where(x => x.Id == currentExpenseId).FirstOrDefault();

                            //Expense Delete
                            string voucherNo = expense.ExpenseNo.ToString();
                            expense.IsDeleted = true;

                            entity.Entry(expense).State = EntityState.Modified;
                            entity.SaveChanges();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have already approved Expense No. " + vouncherNo + " You cannot delete it anymore.");
                        return;
                    }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete expense", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                DataBind();
            }

        }

        private void cboExpCag_SelectedValueChanged(object sender, EventArgs e)
        {
            Radio_Status();
            Date_Assign();
            DataBind();
        }

        private void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Status();
            Date_Assign();
            DataBind();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            Date_Assign();
            DataBind();
        }

        #endregion

        #region Function

        private void Default_Date()
        {
            dtTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Date_Assign();
        }

        private void Date_Assign()
        {
            _fromDate = dtFrom.Value;
            _toDate = dtTo.Value;
        }

        private void Radio_Status()
        {
            if (rdoPending.Checked == true)
            {
                Approved = false;
            }
            else
            {
                Approved = true;
            }
        }

        public void DataBind()
        {
            if (_startProcess == true)
            {
                dgvExpenseList.Columns[1].DefaultCellStyle.Format = "dd-MMM-yyyy";

                if (Approved == true)
                {
                    dgvExpenseList.Columns[7].Visible = false;
                    dgvExpenseList.Columns[9].Visible = false;
                    dgvExpenseList.Columns[10].Visible = false;
                }
                else
                {
                    dgvExpenseList.Columns[7].Visible = true;
                    dgvExpenseList.Columns[9].Visible = true;
                    dgvExpenseList.Columns[10].Visible = true;
                }

                    int expenseCagId = Convert.ToInt32(cboExpenseCag.SelectedValue);
                    dgvExpenseList.AutoGenerateColumns = false;

                    var girdList = (from mp in entity.Expenses
                                    where mp.IsDeleted == false
                                    && mp.IsApproved == Approved
                                   && (EntityFunctions.TruncateTime(mp.ExpenseDate.Value) >= _fromDate)
                                 && (EntityFunctions.TruncateTime(mp.ExpenseDate.Value) <= _toDate)
                                 && ((expenseCagId == 0 && 1 == 1) || (expenseCagId != 0 && mp.ExpenseCategoryId == expenseCagId))
                                    orderby mp.ExpenseDate descending
                                    select new
                                    {
                                        Id = mp.Id,
                                        ExpenseDate = mp.ExpenseDate,
                                        ExpenseNo = mp.ExpenseNo,
                                        TotalExpenseAmount = mp.TotalExpenseAmount,
                                        CreatedUser = mp.User.Name,
                                        ExpenseCag=mp.ExpenseCategory.Name,
                                        Comment = mp.Comment

                                    }).ToList();

                    dgvExpenseList.DataSource = girdList;
                    Calculating_TotalExpenseAmount();
               
            }
        }

        private void Calculating_TotalExpenseAmount()
        {
            Int64 TotalExpenseAmt = dgvExpenseList.Rows.Cast<DataGridViewRow>()
             .Sum(t => Convert.ToInt32(t.Cells["colTotalExpenseAmount"].Value));

            txtTotalExpenseAmt.Text = TotalExpenseAmt.ToString();
        }

        #endregion
    }
}
