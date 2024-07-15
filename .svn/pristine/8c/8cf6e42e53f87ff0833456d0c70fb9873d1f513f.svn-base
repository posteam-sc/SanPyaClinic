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
    public partial class Sales : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();

        private Boolean isDraft = false;

        int myCount = 0;

        private String DraftId = string.Empty;

        public EventArgs e { get; set; }

        //anm
        public string AssignValue = "";

        public int CurrentCustomerId = 0;
        public int CurrentDoctorId = 0;
        public int forPatient;
        bool isload = false;

        #endregion

        #region Events

        public Sales()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
       
        private void Sales_Load(object sender, EventArgs e)
        {
            dgvSearchProductList.AutoGenerateColumns = false;
            cboPaymentMethod.DataSource = entity.PaymentTypes.ToList();
            cboPaymentMethod.DisplayMember = "Name";
            cboPaymentMethod.ValueMember = "Id";

            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "";
            productList.Add(productObj);
            productList.AddRange(entity.Products.ToList());
            cboProductName.DataSource = productList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            ReloadCustomerList();
            if (rdoSale.Checked == true)
            {
                lblDoc.Enabled = false;
                cboDoctor.Enabled = false;
                lblServiceCharges.Text = "0";
                cboAssign.Enabled = false;
                lblAssignStaff.Enabled = false;
            }
            else if (rdoDoctor.Checked == true)
            {
               
                lblDoc.Enabled = true;
                cboDoctor.Enabled = true;
                if (cboPaymentMethod.SelectedValue.ToString() == "4")
                {
                    lblServiceCharges.Text = "0";
                }
                else
                {
                    lblServiceCharges.Text = "1000";
                }
                cboAssign.Enabled = false;
                lblAssignStaff.Enabled = false;
                ReloadGroupList(1);
                ReloadDoctorList();
            }
            else if (rdoPhysio.Checked == true)
            {
                lblServiceCharges.Text = "0";
                lblDoc.Enabled = true;
                cboDoctor.Enabled = true;
                cboAssign.Enabled = true;
                lblAssignStaff.Enabled = true;
                lblServiceCharges.Text ="0";
                ReloadDoctorList();
                ReloadGroupList(1);
            }
            //ReloadDoctorList();
            //ReloadGroupList();
            cboCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboDoctor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDoctor.AutoCompleteSource = AutoCompleteSource.ListItems;
            dgvSalesItem.Focus();
        }

        private void dgvSalesItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }        

        private void dgvSalesItem_CellClick(object sender, DataGridViewCellEventArgs e)
         {
            if (e.RowIndex >= 0)
            {               
                //Delete
                if (e.ColumnIndex == 8)
                {                    
                    object deleteProductCode =  dgvSalesItem[1, e.RowIndex].Value;

                    //If product code is null, this is just new role without product. Do not need to delete the row.
                    if (deleteProductCode != null)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                            UpdateTotalCost();
                            dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                        }
                    }
                }
                else if (e.ColumnIndex == 0 || e.ColumnIndex ==1 || e.ColumnIndex ==2 )
                {
                    dgvSalesItem.CurrentCell = dgvSalesItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvSalesItem.BeginEdit(true);
                }
            }
        }

        private void dgvSalesItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int col = dgvSalesItem.CurrentCell.ColumnIndex;
                int row = dgvSalesItem.CurrentCell.RowIndex;

                if (col == 8)
                {
                    object deleteProductCode = dgvSalesItem[1, row].Value;

                    //If product code is null, this is just new role without product. Do not need to delete the row.
                    if (deleteProductCode != null)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            dgvSalesItem.Rows.RemoveAt(row);
                            UpdateTotalCost();
                            dgvSalesItem.CurrentCell = dgvSalesItem[0, row];

                        }
                    }
                }
                e.Handled = true;
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (CheckAssignForPaid())
            {
                List<TransactionDetail> DetailList = GetTranscationListFromDataGridView();
                if (DetailList.Count() != 0)
                {
                    if (cboCustomer.SelectedIndex > 0)
                    {
                        if (CheckDoc() == false)
                        {
                            //Cash
                            if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 1)
                            {
                                PaidByCash2 form = new PaidByCash2();
                                form.DetailList = DetailList;
                                int extraDiscount = 0;
                                Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                                int tax = 0;
                                Int32.TryParse(txtExtraTax.Text, out tax);
                                form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                                form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                                form.isDraft = isDraft;
                                form.DraftId = DraftId;
                                form.ExtraTax = tax;

                                form.ExtraDiscount = extraDiscount;
                                form.isDebt = false;
                                if (rdoDoctor.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                                    form.SC = Convert.ToInt32(lblServiceCharges.Text.Trim());
                                    form.Cfees = Convert.ToInt32(lblPatient.Text);
                                    form.Type = "Doctor";

                                    if (chkPhysio.Checked == true)
                                    {
                                        int pid = getID(cboAssign.SelectedItem.ToString());
                                        if (pid != 0)
                                        {
                                            form.PId = pid;
                                        }
                                    }
                                }
                                else if (rdoPhysio.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());

                                    int pid = getID(cboAssign.SelectedItem.ToString());
                                    if (pid != 0)
                                    {
                                        form.PId = pid;
                                    }

                                    form.Cfees = 0;
                                    form.Type = "Physio";
                                }
                                else if (rdoSale.Checked == true)
                                {
                                    form.Cfees = 0;
                                    form.Type = "Sale";
                                }
                                if (cboCustomer.SelectedIndex != 0)
                                    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                                form.ShowDialog();
                            }
                            //Credit
                            else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 2)
                            {
                                PaidByCreditWithPrePaidDebt form = new PaidByCreditWithPrePaidDebt();
                                form.DetailList = DetailList;
                                int extraDiscount = 0;
                                Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                                int tax = 0;
                                Int32.TryParse(txtExtraTax.Text, out tax);
                                form.isDraft = isDraft;
                                form.DraftId = DraftId;
                                form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                                form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                                form.ExtraTax = tax;

                                form.ExtraDiscount = extraDiscount;
                                if (rdoDoctor.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DOId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                                    form.SC = Convert.ToInt32(lblServiceCharges.Text.Trim());
                                    form.Cfees = Convert.ToInt32(lblPatient.Text);
                                    form.Type = "Doctor";
                                }
                                else if (rdoPhysio.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DOId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());

                                    int pid = getID(cboAssign.SelectedItem.ToString());
                                    if (pid != 0)
                                    {
                                        form.PId = pid;
                                    }
                                    form.Cfees = 0;
                                    form.Type = "Physio";
                                }
                                else if (rdoSale.Checked == true)
                                {

                                    form.Type = "Sale";
                                    form.Cfees = 0;
                                }
                                if (cboCustomer.SelectedIndex != 0)
                                    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                                form.ShowDialog();
                            }
                            //GiftCard
                            else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 3)
                            {
                                PaidByGiftCard form = new PaidByGiftCard();
                                form.DetailList = DetailList;
                                int extraDiscount = 0;
                                Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                                int tax = 0;
                                Int32.TryParse(txtExtraTax.Text, out tax);
                                form.isDraft = isDraft;
                                form.DraftId = DraftId;

                                form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                                form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                                form.ExtraTax = tax;
                                form.ExtraDiscount = extraDiscount;
                                if (rdoDoctor.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                                    form.SC = Convert.ToInt32(lblServiceCharges.Text.Trim());
                                    form.Cfees = Convert.ToInt32(lblPatient.Text);
                                    form.Type = "Doctor";
                                }
                                else if (rdoPhysio.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());

                                    int pid = getID(cboAssign.SelectedItem.ToString());
                                    if (pid != 0)
                                    {
                                        form.PId = pid;
                                    }
                                    form.Cfees = 0;
                                    form.Type = "Physio";
                                }
                                else if (rdoSale.Checked == true)
                                {

                                    form.Type = "Sale";
                                    form.Cfees = 0;
                                }
                                if (cboCustomer.SelectedIndex != 0)
                                    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                                form.ShowDialog();
                            }
                            else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 4)
                            {
                                PaidByFOC form = new PaidByFOC();
                                form.DetailList = DetailList;
                                int extraDiscount = 0;
                                Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                                int tax = 0;
                                Int32.TryParse(txtExtraTax.Text, out tax);
                                form.isDraft = isDraft;
                                form.DraftId = DraftId;

                                form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                                form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                                form.ExtraTax = tax;
                                form.ExtraDiscount = extraDiscount;
                                if (rdoDoctor.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                                    form.SC = Convert.ToInt32(lblServiceCharges.Text.Trim());
                                    form.Cfees = 0;
                                    form.Type = "Doctor";
                                }
                                else if (rdoPhysio.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());

                                    int pid = getID(cboAssign.SelectedItem.ToString());
                                    if (pid != 0)
                                    {
                                        form.PId = pid;
                                    }
                                    form.Cfees = 0;
                                    form.Type = "Physio";
                                }
                                else if (rdoSale.Checked == true)
                                {

                                    form.Type = "Sale";
                                    form.Cfees = 0;
                                }
                                if (cboCustomer.SelectedIndex != 0)
                                    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                                form.ShowDialog();
                            }
                            else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 5)
                            {
                                PaidByMPU form = new PaidByMPU();
                                form.DetailList = DetailList;
                                int extraDiscount = 0;
                                Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                                int tax = 0;
                                Int32.TryParse(txtExtraTax.Text, out tax);
                                form.isDraft = isDraft;
                                form.DraftId = DraftId;
                                form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                                form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                                form.ExtraTax = tax;

                                form.ExtraDiscount = extraDiscount;
                                if (rdoDoctor.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                                    form.SC = Convert.ToInt32(lblServiceCharges.Text.Trim());
                                    form.Cfees = Convert.ToInt32(lblPatient.Text);
                                    form.Type = "Doctor";
                                }
                                else if (rdoPhysio.Checked == true)
                                {
                                    if (cboDoctor.SelectedIndex != 0)
                                        form.DId = Convert.ToInt32(cboDoctor.SelectedValue.ToString());

                                    int pid = getID(cboAssign.SelectedItem.ToString());
                                    if (pid != 0)
                                    {
                                        form.PId = pid;
                                    }
                                    form.Cfees = 0;
                                    form.Type = "Physio";
                                }
                                else if (rdoSale.Checked == true)
                                {
                                    form.Cfees = 0;
                                    form.Type = "Sale";
                                }
                                if (cboCustomer.SelectedIndex != 0)
                                    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                                form.ShowDialog();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select customer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You haven't select any item to paid");
                }
            }
            else
            {
                MessageBox.Show("Please select Assign!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnLoadDraft_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will erase current sale data. Would you like to continue?", "Load", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {               
                DraftList form = new DraftList();
                form.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private int getID(string assignval)
        {
            int match = 0;
            POSEntities entity = new POSEntities();
            var date = DateTime.Now.ToShortDateString();
            DateTime dtnow=Convert.ToDateTime(date);
            match = entity.DailyDutyPhysios.Where(dt => dt.DutyDate == dtnow && dt.Shift == assignval).Select(dt => dt.Id).SingleOrDefault();
            if (match != 0) return match;
            return 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboAssign.SelectedIndex != 0)
            {
                //will only work if the grid have data row
                //datagrid count header as a row, so we have to check there is more than one row
                if (dgvSalesItem.Rows.Count > 1)
                {
                    List<TransactionDetail> DetailList = GetTranscationListFromDataGridView();

                    int extraDiscount = 0;
                    Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);

                    int tax = 0;
                    Int32.TryParse(txtExtraTax.Text, out tax);
                    int cusId = Convert.ToInt32(cboCustomer.SelectedValue);
                    int dId = Convert.ToInt32(cboDoctor.SelectedValue);

                    //for combo check by anm
                    int pId = 0;
                    int pid = getID(cboAssign.SelectedItem.ToString());
                    if (pid != 0)
                    {
                        pId = pid;
                    }
                    System.Data.Objects.ObjectResult<String> Id = null;
                    if (cusId > 0 && dId > 0)
                    {
                        if (rdoDoctor.Checked == true)
                        {
                            Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, cusId, dId, Convert.ToInt32(lblServiceCharges.Text.Trim()), null, Convert.ToInt32(lblPatient.Text));

                        }
                        else if (rdoPhysio.Checked == true)//recheck//repaired
                        {
                            Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, cusId, dId, Convert.ToInt32(lblServiceCharges.Text.Trim()), pId, 0);

                        }
                        else if (rdoSale.Checked == true)
                        {
                            Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, cusId, null, Convert.ToInt32(lblServiceCharges.Text.Trim()), null, 0);

                        }
                    }
                    else if (cusId > 0 && dId == 0)
                    {
                        Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, cusId, null, Convert.ToInt32(lblServiceCharges.Text.Trim()), null, 0);
                    }
                    else if (cusId == 0 && dId > 0)
                    {
                        if (rdoDoctor.Checked == true)
                        {
                            Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, null, dId, Convert.ToInt32(lblServiceCharges.Text.Trim()), null, Convert.ToInt32(lblPatient.Text));

                        }
                        else if (rdoPhysio.Checked == true)//recheck//repaired
                        {
                            Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, null, dId, Convert.ToInt32(lblServiceCharges.Text.Trim()), pId, 0);

                        }
                        else if (rdoSale.Checked == true)
                        {
                            Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, null, null, Convert.ToInt32(lblServiceCharges.Text.Trim()), null, 0);

                        }
                    }
                    else
                    {
                        Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, null, null, Convert.ToInt32(lblServiceCharges.Text.Trim()), null, 0);
                    }

                    entity = new POSEntities();
                    string resultId = Id.FirstOrDefault().ToString();
                    Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                    insertedTransaction.IsDeleted = false;

                    foreach (TransactionDetail detail in DetailList)
                    {
                        detail.IsDeleted = false;
                        insertedTransaction.TransactionDetails.Add(detail);
                    }

                    entity.SaveChanges();
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Please select Assign!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sales_Activated(object sender, EventArgs e)
        {
            //DailyRecord latestRecord = (from rec in entity.DailyRecords where rec.CounterId == MemberShip.CounterId && rec.IsActive == true select rec).FirstOrDefault();
            //if (latestRecord == null)
            //{
            //    StartDay form = new StartDay();
            //    form.Show();
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = cboProductName.Text.Trim();
            List<Product> pList = entity.Products.Where(x => x.Name.Trim().Contains(productName)).ToList();
            if (pList.Count > 0)
            {
                dgvSearchProductList.DataSource = pList;
                dgvSearchProductList.Focus();
            }
            else
            {
                MessageBox.Show("Item not found!", "Cannot find");
                dgvSearchProductList.DataSource = "";
                return;
            }
        }

        private void dgvSearchProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currentProductId = Convert.ToInt32(dgvSearchProductList.Rows[e.RowIndex].Cells[0].Value);
                int count = dgvSalesItem.Rows.Count;
                if (e.ColumnIndex == 1)
                {
                    Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                    if (pro != null)
                    {
                        //fill the new row with the product information
                        //dgvSalesItem.Rows.Add();
                        //int newRowIndex = dgvSalesItem.NewRowIndex;

                        DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                        row.Cells[0].Value = pro.Barcode;
                        row.Cells[1].Value = pro.ProductCode;
                        row.Cells[2].Value = 1;
                        row.Cells[3].Value = pro.Name;
                        row.Cells[4].Value = pro.Price;
                        row.Cells[5].Value = pro.DiscountRate;
                        row.Cells[6].Value = pro.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(pro);
                        row.Cells[9].Value = currentProductId;
                        dgvSalesItem.Rows.Add(row);
                        cboProductName.SelectedIndex = 0;
                        dgvSearchProductList.DataSource = "";
                        dgvSearchProductList.ClearSelection();
                        dgvSalesItem.Focus();
                        dgvSalesItem.CurrentCell = dgvSalesItem.Rows[count].Cells[0];

                    }
                    else
                    {

                        MessageBox.Show("Item not found!", "Cannot find");
                    }

                    UpdateTotalCost();
                }
            }
        }

        private void dgvSearchProductList_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter && dgvSearchProductList.CurrentCell != null)
            {
                int Row = dgvSearchProductList.CurrentCell.RowIndex;
                int Column = dgvSearchProductList.CurrentCell.ColumnIndex;
                int currentProductId = Convert.ToInt32(dgvSearchProductList.Rows[Row].Cells[0].Value);
                int count = dgvSalesItem.Rows.Count;
                if (Column == 1)
                {
                    Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                    if (pro != null)
                    {
                        //fill the new row with the product information
                        //dgvSalesItem.Rows.Add();
                        //int newRowIndex = dgvSalesItem.NewRowIndex;

                        DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                        row.Cells[0].Value = pro.Barcode;
                        row.Cells[1].Value = pro.ProductCode;
                        row.Cells[2].Value = 1;
                        row.Cells[3].Value = pro.Name;
                        row.Cells[4].Value = pro.Price;
                        row.Cells[5].Value = pro.DiscountRate;
                        row.Cells[6].Value = pro.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(pro);
                        row.Cells[9].Value = currentProductId;
                        dgvSalesItem.Rows.Add(row);
                        cboProductName.SelectedIndex = 0;
                        dgvSearchProductList.DataSource = "";
                        dgvSearchProductList.ClearSelection();
                        dgvSalesItem.Focus();
                        dgvSalesItem.CurrentCell = dgvSalesItem.Rows[count].Cells[0];

                    }
                    else
                    {

                        MessageBox.Show("Item not found!", "Cannot find");
                    }

                    UpdateTotalCost();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
            if (keyData == (Keys.F2))
            {
                cboProductName.Focus();
                return true;
            }
            else if (keyData == (Keys.F1))
            {
                btnPaid_Click(this.btnPaid, e);
                return true;
            }
            else if (keyData == Keys.End)
            {
                txtAdditionalDiscount.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboProductName_KeyDown(object sender, KeyEventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

        private void txtAdditionalDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtExtraTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Function

        private List<TransactionDetail> GetTranscationListFromDataGridView()
        {
            List<TransactionDetail> DetailList = new List<TransactionDetail>();

            foreach (DataGridViewRow row in dgvSalesItem.Rows)
            {
                if (!row.IsNewRow && row.Cells[9].Value != null && row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    TransactionDetail transDetail = new TransactionDetail();
                    
                    int qty = 0, productId = 0;
                    bool alreadyinclude = false;
                    decimal discountRate = 0;
                    Int32.TryParse(row.Cells[9].Value.ToString(), out productId);
                    Int32.TryParse(row.Cells[2].Value.ToString(), out qty);
                    Decimal.TryParse(row.Cells[5].Value.ToString(), out discountRate);
                    //Check if the product is already include in above row
                    foreach (TransactionDetail td in DetailList)
                    {
                        if (td.ProductId == productId && td.DiscountRate == discountRate)
                        {
                            Product tempProd = (from p in entity.Products where p.Id == productId select p).FirstOrDefault<Product>();
                            td.Qty = td.Qty + qty;
                            td.TotalAmount = Convert.ToInt64(getActualCost(tempProd, discountRate)) * td.Qty;
                            alreadyinclude = true;
                        }
                    }

                    if (!alreadyinclude)
                    {
                        //Check productId is valid or not.
                        Product pro = (from p in entity.Products where p.Id == productId select p).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            if (pro.ProductCategory.Name == "Injection")
                            {
                                transDetail.InjectionRate = (pro.ChargesforDoctor * qty) ;
                            }
                            if (pro.ProductCategory.Name == "X-Ray")
                            {
                                transDetail.XRayRate = (pro.ChargesforDoctor) ;
                            }

                            if (pro.ProductCategory.Name == "PT")
                            {
                                transDetail.PTRate = (pro.ChargesforDoctor);
                            }
                            transDetail.ProductId = pro.Id;
                            transDetail.UnitPrice = pro.Price;
                            transDetail.DiscountRate = discountRate;
                            transDetail.TaxRate = Convert.ToDecimal(pro.Tax.TaxPercent);
                            transDetail.Qty = qty;
                            transDetail.TotalAmount = Convert.ToInt64(getActualCost(pro, discountRate)) * qty;
                            DetailList.Add(transDetail);
                        }
                    }
                }
            }

            return DetailList;
        }

        private void UpdateTotalCost()
        {
            int discount = 0, tax = 0, total = 0,totalqty=0;

            foreach (DataGridViewRow dgrow in dgvSalesItem.Rows)
            {
                //check if the current one is new empty row
                if (!dgrow.IsNewRow && dgrow.Cells[1].Value != null)
                {                    
                    string rowProductCode = string.Empty;
                    int qty = 0;
                    rowProductCode = dgrow.Cells[1].Value.ToString().Trim();
                    if (rowProductCode != string.Empty && dgrow.Cells[2].Value != null)
                    {
                        //Get qty
                        Int32.TryParse(dgrow.Cells[2].Value.ToString(), out qty);
                        Product pro = (from p in entity.Products where p.ProductCode == rowProductCode select p).FirstOrDefault<Product>();
                        
                        decimal productDiscount = 0;
                        if (dgrow.Cells[5].Value != null)
                        {
                            Decimal.TryParse(dgrow.Cells[5].Value.ToString(), out productDiscount);
                        }
                        else
                        {
                            productDiscount = pro.DiscountRate;
                        }
                        total += (int)Math.Ceiling(getActualCost(pro,productDiscount) * qty);
                        discount += (int)Math.Ceiling(getDiscountAmount(pro.Price, productDiscount) * qty);
                        tax += (int)Math.Ceiling(getTaxAmount(pro) * qty);
                        totalqty += qty;
                    }
                }
            }




            lblTotal.Text = total.ToString();
            lblDiscountTotal.Text = discount.ToString();
            lblTaxTotal.Text = tax.ToString();
            lblTotalQty.Text = totalqty.ToString();
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

        private decimal getActualCost(Product prod, decimal discountRate)
        {
            decimal? actualCost = 0;
            //decrease discount ammount            
            actualCost = prod.Price - ((prod.Price / 100) * discountRate);
            //add tax ammount            
            actualCost = actualCost + ((prod.Price / 100) * prod.Tax.TaxPercent);
            return (decimal)actualCost;
        }

        //private decimal getDiscountAmount(Product prod)
        //{
        //    return (((decimal)prod.Price / 100) * prod.DiscountRate);
        //}

        private decimal getDiscountAmount(long productPrice, decimal productDiscount)
        {
            return (((decimal)productPrice / 100) * productDiscount);
        }

        private decimal getTaxAmount(Product prod)
        {
            return ((prod.Price / 100) * Convert.ToDecimal(prod.Tax.TaxPercent));
        }

        public void LoadDraft(string TransactionId)
        {
            Clear();
            DraftId = TransactionId;
          
            Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId && ts.IsComplete == false select ts).FirstOrDefault<Transaction>();

            if (draft != null)
            {           
                //pre add the rows
                dgvSalesItem.Rows.Insert(0, draft.TransactionDetails.Count());

                int index = 0;
                foreach (TransactionDetail detail in draft.TransactionDetails)
                {
                    //If product still exist
                    if (detail.Product != null)
                    {
                        isload = true;
                        DataGridViewRow row = dgvSalesItem.Rows[index];
                        //fill the current row with the product information
                        row.Cells[0].Value = detail.Product.Barcode;
                        row.Cells[1].Value = detail.Product.ProductCode;
                        row.Cells[2].Value = detail.Qty;
                        row.Cells[3].Value = detail.Product.Name;
                        row.Cells[4].Value = detail.Product.Price;
                        row.Cells[5].Value = detail.DiscountRate;
                        row.Cells[6].Value = detail.Product.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(detail.Product, detail.DiscountRate) * detail.Qty;
                        row.Cells[9].Value = detail.ProductId;
                        index++;
                    }         
                }

                txtAdditionalDiscount.Text = draft.DiscountAmount.ToString();
                txtExtraTax.Text = draft.TaxAmount.ToString();
                lblServiceCharges.Text = draft.ServiceChages.ToString();
                if (draft.Customer != null)
                {
                    SetCurrentCustomer((int)draft.CustomerId);
                }
                if (draft.DoctorPhysio != null)
                {
                    SetCurrentDoctor((int)draft.DoctorID);
                }
                if (draft.Group != null)
                {
                    int GID=(int)draft.GroupID;
                    DailyDutyPhysio currentGroup = entity.DailyDutyPhysios.Where(x => x.Id == GID).FirstOrDefault();
                    if (currentGroup != null)
                    {

                        cboAssign.Text = currentGroup.Shift;//recheck//ok
                        cboCustomer.SelectedItem = currentGroup;

                    }
                }
                UpdateTotalCost();
            }
            else
            {
                //no associate transaction
                MessageBox.Show("The item doesn't exist anymore!");
            }

            isDraft = true;
        }

        public void Clear()
        {
            CurrentCustomerId = 0;
            CurrentDoctorId = 0;
            entity = new POSEntities();
            dgvSalesItem.Rows.Clear();
            dgvSalesItem.Focus();
            txtAdditionalDiscount.Text = "0";
            if (rdoDoctor.Checked == true)
            {
                lblServiceCharges.Text = "1000";
            }
            else
            {
                lblServiceCharges.Text = "0";
            }
            txtExtraTax.Text = "0";
            lblTotal.Text = "0";
            lblTaxTotal.Text = "0";
            lblDiscountTotal.Text = "0";
            lblTotalQty.Text = "0";
            isDraft = false;
            DraftId = string.Empty;
            dgvSearchProductList.DataSource = "";
            cboProductName.SelectedIndex = 0;
            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "";
            productList.Add(productObj);
            productList.AddRange((from p in entity.Products select p).ToList());
            cboProductName.DataSource = productList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCustomer.SelectedIndex = 0;            
            ReloadCustomerList();
            ReloadDoctorList();
            
        }

        public void SetCurrentCustomer(Int32 CustomerId)
        {
            CurrentCustomerId = CustomerId;
            Customer currentCustomer = entity.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();
            if (currentCustomer != null)
            {
                //lblCustomerName.Text = currentCustomer.Name;
                lblCustomerName.Text = currentCustomer.CustomerCode;
                lblNRIC.Text = currentCustomer.NRC;
                lblPhoneNumber.Text = currentCustomer.PhoneNumber;
                lblEmail.Text = currentCustomer.Email;
                cboCustomer.Text = currentCustomer.Name;
                cboCustomer.SelectedItem = currentCustomer;
                
            }
        }
        public void SetCurrentDoctor(Int32 DID)
        {
            CurrentDoctorId = DID;
            DoctorPhysio currentDoctor= entity.DoctorPhysios.Where(x => x.Id == DID).FirstOrDefault();
            if (currentDoctor != null)
            {
                lblPatient.Text = currentDoctor.ChargesPerPatient.ToString();
                cboDoctor.Text = currentDoctor.Name;
                cboCustomer.SelectedItem = currentDoctor;

            }
        }

        public void ReloadCustomerList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.Customer> customerList = new List<APP_Data.Customer>();
            APP_Data.Customer customer = new APP_Data.Customer();
            customer.Id = 0;
            //customer.CustomerCode = "None";
            customer.Name = "None";
            customerList.Add(customer);
            customerList.AddRange(entity.Customers.ToList());
            cboCustomer.DataSource = customerList;
            //cboCustomer.DisplayMember = "CustomerCode";//chanage ZMH Customer Code to Name:
            cboCustomer.DisplayMember = "Name";//chanage ZMH Customer Code to Name:
            cboCustomer.ValueMember = "Id";
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
            DoctorPhysiorList.AddRange((from p in entity.DoctorPhysios where p.IsDoctor==true select p).ToList());
            cboDoctor.DataSource = DoctorPhysiorList;
            cboDoctor.DisplayMember = "Name";
            cboDoctor.ValueMember = "Id";
        }

        public void ReloadGroupList(int iCount=0)
        {
            entity = new POSEntities();
            //get Date and Time
            DateTime dt_now = DateTime.Now;
            
            //Add Customer List with default option
            //List<APP_Data.DailyDutyPhysio> GroupList = new List<APP_Data.DailyDutyPhysio>();
            //GroupList.AddRange((from p in entity.DailyDutyPhysios select p).ToList());
            //cboAssign.DataSource = GroupList;
            //cboAssign.DisplayMember = "Shift";
            //cboAssign.ValueMember = "Id";

            
            //anm
            int i = 0;
            int j = 0;
            DateTime dt_am1 = DateTime.Now;
            DateTime dt_am2 = DateTime.Now;
            DateTime dt_pm1 = DateTime.Now;
            DateTime dt_pm2 = DateTime.Now;

            string am = SettingController.AMShiftAssign.ToString();
            string[] am_split = am.Split('-');
            foreach (string a in am_split)
            {
                DateTime am_dt = Convert.ToDateTime(a);
                if (i == 0)
                {
                    dt_am1 = am_dt;
                    i++;
                }
                else
                {
                    dt_am2 = am_dt;
                }
            }
            string pm = SettingController.PMShiftAssign.ToString();
            string[] pm_split = pm.Split('-');
            foreach (string p in pm_split)
            {
                DateTime pm_dt = Convert.ToDateTime(p);
                if (j == 0)
                {
                    dt_pm1 = pm_dt;
                    j++;
                }
                else
                {
                    dt_pm2 = pm_dt;
                }
            }

            int res1 = DateTime.Compare(dt_am1, dt_now);
            int res2 = DateTime.Compare(dt_am2, dt_now);
            int res3 = DateTime.Compare(dt_pm1, dt_now);
            int res4 = DateTime.Compare(dt_pm2, dt_now);
            if(res1<=0 && res2>=0)
            {
                cboAssign.SelectedIndex = 1;
                AssignValue = "AM";
            }
            else if (res3 <= 0 && res4 >= 0)
            {
                cboAssign.SelectedIndex = 2;
                AssignValue = "PM";
            }
            else
            {
                cboAssign.SelectedIndex = 0;
                AssignValue = "";
            }
            if (cboAssign.SelectedIndex != 0)
            {
                if (iCount == 0)
                {
                    //check assign
                    int matchCount = 0;
                    var date = DateTime.Now.ToShortDateString();
                    DateTime dtNow = Convert.ToDateTime(date);

                    string assignValue = cboAssign.SelectedItem.ToString();
                    matchCount = entity.DailyDutyPhysios.Where(dt => dt.DutyDate == dtNow && dt.Shift == assignValue).Select(dt => dt.Id).SingleOrDefault();
                    if (matchCount <= 0)
                    {
                        //function call to insert assign
                        MessageBox.Show("You need to insert assign for today!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);//remove after test

                        frmDailyDuty _frm = new frmDailyDuty();
                        _frm.ShowDialog();

                    }

                }
            }
        }

        public void CheckAssign()
        {
            if (cboAssign.SelectedIndex != 0)
            {
                //check assign
                int matchCount = 0;
                var date = DateTime.Now.ToShortDateString();
                DateTime dtNow = Convert.ToDateTime(date);
                string assignValue = cboAssign.SelectedItem.ToString();
                matchCount = entity.DailyDutyPhysios.Where(dt => dt.DutyDate == dtNow && dt.Shift == assignValue).Select(dt => dt.Id).SingleOrDefault();
                if (matchCount <= 0)
                {
                    //function call to insert assign
                    MessageBox.Show("You need to insert assign for today!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);//remove after test

                    frmDailyDuty _frm = new frmDailyDuty();
                    _frm.ShowDialog();

                }  
            }
        }

        private int Check()
        {
             //check assign

                    int matchCount = 0;
                    var date = DateTime.Now.ToShortDateString();
                    DateTime dtNow = Convert.ToDateTime(date);

                    if (rdoSale.Checked == false)
                    {
                        if (cboAssign.SelectedIndex != 0)
                        {
                            string assignValue = cboAssign.SelectedItem.ToString();
                            matchCount = entity.DailyDutyPhysios.Where(dt => dt.DutyDate == dtNow && dt.Shift == assignValue).Select(dt => dt.Id).SingleOrDefault();
                            if (matchCount <= 0)
                            {
                                //function call to insert assign
                                MessageBox.Show("You need to insert assign for today!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);//remove after test

                                frmDailyDuty _frm = new frmDailyDuty();
                                _frm.ShowDialog();
                            }
                        }
                    }
                 
                    return matchCount;
        }

        public bool CheckAssignForPaid()
        {
            bool a = false;
            if (rdoDoctor.Checked == true)
            {
                if (chkPhysio.Checked == true)
                {
                    //check assign
                    if (cboAssign.SelectedIndex != 0)
                    {
                        int matchCount = Check();
                        if (matchCount <= 0)
                        {
                            a = false;
                        }
                        else
                        {
                            a = true;
                        }
                    }
                }
                else
                {
                    a = true;
                }
            }
            else
            {
                if (rdoPhysio.Checked == true)
                {
                    if (cboAssign.SelectedIndex != 0)
                    {
                        int matchCount = Check();
                        if (matchCount <= 0)
                        {
                            a = false;
                        }
                        else
                        {
                            a = true;
                        }
                    }
                }
                else
                {
                    a = true;
                }
            }
         
        
            return a;
        }

        #endregion                                

        private void dgvSalesItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalesItem.Rows[e.RowIndex];
                dgvSalesItem.CommitEdit(new DataGridViewDataErrorContexts());
                if (row.Cells[0].Value != null || row.Cells[1].Value != null)
                {
                    //New item code input
                    if (e.ColumnIndex == 0)
                    {
                        string currentBarcode = row.Cells[0].Value.ToString();

                        //get current product
                        Product pro = (from p in entity.Products where p.Barcode == currentBarcode select p).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            //fill the current row with the product information

                            isload = true;
                            row.Cells[1].Value = pro.ProductCode;
                            row.Cells[2].Value = 1;
                            row.Cells[3].Value = pro.Name;
                            row.Cells[4].Value = pro.Price;
                            row.Cells[5].Value = pro.DiscountRate;
                            row.Cells[6].Value = pro.Tax.TaxPercent;
                            row.Cells[7].Value = getActualCost(pro);
                            row.Cells[9].Value = pro.Id;
                        }
                        else
                        {
                            //remove current row if input have no associate product
                            MessageBox.Show("Wrong item code");
                            try
                            {
                                dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                                dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                            }
                            catch (Exception ex)
                            {

                            }

                        }                       
                    }
                    //Product Code Change
                    else if (e.ColumnIndex == 1)
                    {
                        string currentProductCode = row.Cells[1].Value.ToString();
                        //get current product
                        Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            //fill the current row with the product information

                            isload = true;
                            row.Cells[0].Value = pro.Barcode;
                            row.Cells[2].Value = 1;
                            row.Cells[3].Value = pro.Name;
                            row.Cells[4].Value = pro.Price;
                            row.Cells[5].Value = pro.DiscountRate;
                            row.Cells[6].Value = pro.Tax.TaxPercent;
                            row.Cells[7].Value = getActualCost(pro);
                            row.Cells[9].Value = pro.Id;
                        }
                        else
                        {
                            //remove current row if input have no associate product
                            MessageBox.Show("Wrong item code");
                            try
                            {
                                dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                                dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                            }
                            catch (Exception ex)
                            {


                            }

                        }

                        //check if current row isn't topmost
                        if (e.RowIndex > 0)
                        {
                            //Check if upper row have the same product
                            DataGridViewRow upperRow = dgvSalesItem.Rows[e.RowIndex - 1];
                            if (currentProductCode == upperRow.Cells[1].Value.ToString())
                            {
                                //user make same input as above row.
                                //combine these two row and delete current one.
                                upperRow.Cells[2].Value = Convert.ToInt32(upperRow.Cells[2].Value) + 1;
                                //upperRow.Cells[7].Value = Convert.ToInt32(upperRow.Cells[7].Value) + getActualCost(pro);

                                dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex-1];
                                dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                                
                            }
                        }
                    }
                    //Qty Changes
                    else if (e.ColumnIndex == 2)
                    {

                        if (isload == true)
                        {
                            string currentProductCode = row.Cells[1].Value.ToString();
                            //get current Project by Id
                            Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();


                            int currentQty = 1;
                            try
                            {
                                //get updated qty
                                currentQty = Convert.ToInt32(row.Cells[2].Value);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Input quenity have invalid keywords.");
                                row.Cells[2].Value = "1";
                            }


                            //update the total cost
                            row.Cells[7].Value = currentQty * getActualCost(pro);
                            isload = false;
                        }
                        else
                        {
                            Decimal currentDiscountRate = 0;

                            int discountRate = 0;


                            if (row.Cells[5].Value.ToString() != null && row.Cells[5].Value.ToString() != "0.00")
                            {
                                currentDiscountRate = Convert.ToDecimal(row.Cells[5].Value.ToString());
                                discountRate = Convert.ToInt32(currentDiscountRate);
                            }

                            string currentProductCode = row.Cells[1].Value.ToString();



                            //get current Project by Id
                            Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();


                            int currentQty = 1; 
                            try
                            {
                                //get updated qty
                                currentQty = Convert.ToInt32(row.Cells[2].Value);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Input quenity have invalid keywords.");
                                row.Cells[2].Value = "1";
                            }

                            //update the total cost
                            //      row.Cells[7].Value = currentQty * getActualCost(pro,discountRate);
                            row.Cells[7].Value = currentQty * getActualCost(pro, discountRate);
                        }

                    }

                    //Discount Rate Change
                    else if (e.ColumnIndex == 5)
                    {
                        string currentProductCode = row.Cells[1].Value.ToString();
                        //get current Project by Id
                        Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();
                        int currentQty = 1;
                        try
                        {
                            //get updated qty
                            currentQty = Convert.ToInt32(row.Cells[2].Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Input quenity have invalid keywords.");
                            row.Cells[2].Value = "1";
                        }

                        decimal DiscountRate = 0;
                        Decimal.TryParse(row.Cells[5].Value.ToString(), out DiscountRate);

                        if (DiscountRate > 100)
                        {
                            row.Cells[5].Value = 100;
                            DiscountRate = 100;
                        }

                        //update the total cost
                        row.Cells[7].Value = currentQty * getActualCost(pro, DiscountRate);
                    }
                    UpdateTotalCost();
                }
                else
                {
                    dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                    dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                    MessageBox.Show("You need to input product code or barcode firstly in order to add product quentity!");
                }
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex != 0)
            {
                SetCurrentCustomer(Convert.ToInt32(cboCustomer.SelectedValue.ToString()));
            }
            else
            {
                //Clear customer data
                CurrentCustomerId = 0;
                lblCustomerName.Text = "-";
                lblEmail.Text = "-";
                lblNRIC.Text = "-";
                lblPhoneNumber.Text = "-";
            }
        }

        private void btnAddNewDoctor_Click(object sender, EventArgs e)
        {
            //Role Management
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Customer.Add || MemberShip.isAdmin)
            {

                frmDoctorOrPhysio form = new frmDoctorOrPhysio();
                form.isEdit = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to add new customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            //Role Management
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Customer.Add || MemberShip.isAdmin)
            {

                NewCustomer form = new NewCustomer();
                form.isEdit = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to add new customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lbAdvanceSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //CustomerSearch form = new CustomerSearch();
            //form.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        internal void DeleteCopy(string TransactionId)
        {
            Clear();
            DraftId = TransactionId;
            Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId select ts).FirstOrDefault<Transaction>();
            decimal disTotal = 0, taxTotal = 0;
            //Delete transaction
            draft.IsDeleted = true;

          //  List<TransactionDetail> tempTransactionDetaillist = entity.TransactionDetails.Where(x => x.IsDeleted == false).ToList();

            foreach (TransactionDetail detail in draft.TransactionDetails.Where(x=>x.IsDeleted==false))
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
            }

            DeleteLog dl = new DeleteLog();
            dl.DeletedDate = DateTime.Now;
            dl.CounterId = MemberShip.CounterId;
            dl.UserId = MemberShip.UserId;
            dl.IsParent = true;
            dl.TransactionId = draft.Id;

            entity.DeleteLogs.Add(dl);

            entity.SaveChanges();

            //copy transaction
            if (draft != null)
            {
                //pre add the rows
                dgvSalesItem.Rows.Insert(0, draft.TransactionDetails.Count());
                int index = 0;
                foreach (TransactionDetail detail in draft.TransactionDetails)
                {
                    //If product still exist
                    if (detail.Product != null)
                    {
                        DataGridViewRow row = dgvSalesItem.Rows[index];
                        //fill the current row with the product information
                        row.Cells[0].Value = detail.Product.Barcode;
                        row.Cells[1].Value = detail.Product.ProductCode;
                        row.Cells[2].Value = detail.Qty;
                        row.Cells[3].Value = detail.Product.Name;
                        row.Cells[4].Value = detail.Product.Price;
                        row.Cells[5].Value = detail.DiscountRate;
                        row.Cells[6].Value = detail.Product.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(Convert.ToInt64(detail.Product.Price), detail.Product.DiscountRate, Convert.ToDecimal(detail.Product.Tax.TaxPercent)) * detail.Qty;
                        disTotal += Convert.ToInt64(getDiscountAmount(Convert.ToInt64(detail.Product.Price), detail.Product.DiscountRate) * detail.Qty);
                        taxTotal += Convert.ToInt64(getTaxAmount(Convert.ToInt64(detail.Product.Price), Convert.ToDecimal(detail.Product.Tax.TaxPercent)) * detail.Qty);
                        row.Cells[9].Value = detail.ProductId;
                        index++;
                    }
                }

                txtAdditionalDiscount.Text = (draft.DiscountAmount - disTotal).ToString();
                txtExtraTax.Text = (draft.TaxAmount - taxTotal).ToString();
                if (draft.Customer != null)
                {
                    SetCurrentCustomer((int)draft.CustomerId);
                }
                UpdateTotalCost();

            }
        }

        private decimal getActualCost(long productPrice, decimal productDiscount, decimal tax)
        {
            decimal? actualCost = 0;
            //decrease discount ammount            
            actualCost = productPrice - ((productPrice / 100) * productDiscount);
            //add tax ammount            
            actualCost = actualCost + ((productPrice / 100) * tax);
            return (decimal)actualCost;
        }
        private decimal getTaxAmount(long productPrice, decimal tax)
        {
            return ((productPrice / 100) * Convert.ToDecimal(tax));
        }

        private void rdoDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDoctor.Checked == true)
            {
                if (cboPaymentMethod.SelectedValue.ToString() == "4")
                {
                    lblServiceCharges.Text = "0";
                }
                else
                {
                    lblServiceCharges.Text = "1000";
                }
                lblDoc.Enabled = true;
                cboDoctor.Enabled = true;
                chkPhysio.Visible = true;
                lblAssignStaff.Enabled = false;
                if (chkPhysio.Checked == true)
                {
                    cboAssign.Enabled = true;
                }
                else
                {
                    cboAssign.Enabled = false;
                }
                ReloadGroupList();
                ReloadDoctorList();
            }
           
        }

        private void rdoPhysio_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPhysio.Checked == true)
            {
                lblServiceCharges.Text = "0";
                lblDoc.Enabled = true;
                cboDoctor.Enabled = true;
                chkPhysio.Visible = false;
                lblAssignStaff.Enabled = true;
                cboAssign.Enabled = true;
                ReloadCustomerList();
                ReloadGroupList();
            }
            
        }

        private void rdoSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSale.Checked == true)
            {
                lblServiceCharges.Text = "0";
                chkPhysio.Visible = false;
                lblDoc.Enabled = false;
                cboDoctor.Enabled = false;
                lblAssignStaff.Enabled = false;
                cboAssign.Enabled = false;
            }
        }
        private bool CheckDoc()
        {
            if (rdoDoctor.Checked == true)
            {
                if (cboDoctor.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select doctor!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (rdoPhysio.Checked == true)
            {
                if (cboDoctor.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select doctor!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else if (cboAssign.SelectedItem.ToString() == null)//recheck//ok
                {
                    MessageBox.Show("Please select assign!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void cboDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDoctor.SelectedIndex > 0)
            {
                int DoID = Convert.ToInt32(cboDoctor.SelectedValue.ToString());
                DoctorPhysio dp = (from d in entity.DoctorPhysios where d.Id == DoID select d).FirstOrDefault();
                if (rdoDoctor.Checked == true)
                {
                    lblPatient.Text = dp.ChargesPerPatient.ToString();
                }
                else
                {
                    lblPatient.Text = "0";
                }
            }
            else
            {
                lblPatient.Text = "0";
            }
           
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblServiceCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkPhysio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPhysio.Checked == true)
            {
                cboAssign.Enabled = true;
                lblAssignStaff.Enabled = true;
                ReloadGroupList();
            }
            else
            {
                cboAssign.Enabled = false;
                lblAssignStaff.Enabled = true;
            }
        }


        private void cboAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myCount != 0)
            {
                if (cboAssign.SelectedIndex != 0)
                {
                    int matchCount = 0;
                    var date = DateTime.Now.ToShortDateString();
                    DateTime dtNow = Convert.ToDateTime(date);
                    POSEntities entity = new POSEntities();
                    string assignValue = cboAssign.SelectedItem.ToString();
                    matchCount = entity.DailyDutyPhysios.Where(dt => dt.DutyDate == dtNow && dt.Shift == assignValue).Select(dt => dt.Id).SingleOrDefault();
                    if (cboAssign.SelectedItem.ToString() != AssignValue)
                    {
                        //ReloadGroupList();
                        CheckAssign();
                        MessageBox.Show("You are selecting wrong assign!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (matchCount <= 0)
                    {
                        MessageBox.Show("You need to insert assign for today!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);//remove after test
                        //function call to insert assign
                        frmDailyDuty _frm = new frmDailyDuty();
                        _frm.ShowDialog();

                    }
                }
            }
            myCount++;
        }

        private void lnkAssignStaff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboAssign.SelectedIndex != 0)
            {
                frmDailyDutyList _frmDutyList = new frmDailyDutyList();
                _frmDutyList.shift = cboAssign.SelectedItem.ToString();
                _frmDutyList.ShowDialog();
            }
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDoctor.Checked == true)
            {
                if (cboPaymentMethod.SelectedValue.ToString() == "4")
                {
                    lblServiceCharges.Text = "0";
                }
                else
                {
                    lblServiceCharges.Text = "1000";
                }
            }
        }
    }
}
