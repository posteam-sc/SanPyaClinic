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

namespace POS
{
    public partial class DeleteLogForm : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();

        #endregion

        #region Events

        public DeleteLogForm()
        {
            InitializeComponent();
        }

        private void DeleteLogForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvDeleteLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDeleteLog.Rows)
            {
                DeleteLog current = (DeleteLog)row.DataBoundItem;
                row.Cells[1].Value = current.Counter.Name;
                row.Cells[2].Value = current.User.Name;
            }
        }

        private void dgvDeleteLogPartial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDeleteLogPartial.Rows)
            {
                DeleteLog current = (DeleteLog)row.DataBoundItem;
                row.Cells[1].Value = current.Counter.Name;
                row.Cells[2].Value = current.User.Name;
                row.Cells[4].Value = current.TransactionDetail.Product.Name;
                row.Cells[5].Value = current.TransactionDetail.Qty;
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Function
        
        private void LoadData()
        {
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;

            List<DeleteLog> transList = (from t in entity.DeleteLogs where System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) >= fromDate && System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) <= toDate && t.IsParent == true select t).ToList<DeleteLog>();
            dgvDeleteLog.AutoGenerateColumns = false;
            dgvDeleteLog.DataSource = transList;

            List<DeleteLog> partialTransList = (from t in entity.DeleteLogs where System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) >= fromDate && System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) <= toDate && t.IsParent != true select t).ToList<DeleteLog>();
            dgvDeleteLogPartial.AutoGenerateColumns = false;
            dgvDeleteLogPartial.DataSource = partialTransList;
        }

        #endregion

        private void dgvDeleteLogPartial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    string currentTransactionId = dgvDeleteLogPartial.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TransactionDetailForm newForm = new TransactionDetailForm();
                    newForm.transactionId = currentTransactionId;
                    newForm.ShowDialog();
                }
            }
        }

        private void dgvDeleteLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    string currentTransactionId = dgvDeleteLog.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Transaction tObj = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();
                    if (tObj.Type == TransactionType.Refund || tObj.Type == TransactionType.CreditRefund)
                    {
                        RefundDetail newForm = new RefundDetail();
                        newForm.transactionId = currentTransactionId;
                        newForm.IsRefund = false;
                        newForm.ShowDialog();
                    }
                    else 
                    {
                        TransactionDetailForm newForm = new TransactionDetailForm();
                        newForm.transactionId = currentTransactionId;
                        newForm.ShowDialog();
                    }
                    
                }
            }
        }

       
    }
}