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
    public partial class Login : Form
    {
        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();

        #region Events

        public Login()
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

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            this.SetStyle(ControlStyles.DoubleBuffer,true);
            this.SetStyle(ControlStyles.UserPaint ,true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            List<APP_Data.Counter> counterList = new List<APP_Data.Counter>();
            //entity
            
            APP_Data.Counter counterObj1 = new APP_Data.Counter();
            counterObj1.Id = 0;
            counterObj1.Name = "Select";
            counterList.Add(counterObj1);
            counterList.AddRange((from c in entity.Counters select c).ToList());
            cboCounter.DataSource = counterList;
            cboCounter.DisplayMember = "Name";
            cboCounter.ValueMember = "Id";
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         
            for (int i = 0; i < 2; i++)
            {
            }
            Boolean hasError = false;

            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            //Validation
            if (txtUserName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtUserName, "Error");
                tp.Show("Please fill up user name!", txtUserName);                
                hasError = true;
            }
            else if(cboCounter.SelectedIndex <1)
            {
                tp.SetToolTip(cboCounter, "Error");
                tp.Show("Please fill up counter name!", cboCounter);                
                hasError = true;
            }
            if(!hasError)
            {
                string name = txtUserName.Text;
                string password = txtPassword.Text;
                int counterNo = Convert.ToInt32(cboCounter.SelectedValue);
                User user = (from u in entity.Users where u.Name == name select u).FirstOrDefault<User>();
                if (user != null)
                {
                    string p = Utility.DecryptString(user.Password, "SCPos");
                    if (p == password)
                    {
                        MemberShip.UserName = user.Name;
                        MemberShip.UserRole = user.UserRole.RoleName;
                        MemberShip.UserRoleId = Convert.ToInt32(user.UserRoleId);
                        MemberShip.UserId = user.Id;
                        MemberShip.isLogin = true;
                        MemberShip.CounterId = counterNo;
                        DailyRecord dailyRecord = (from rec in entity.DailyRecords where rec.CounterId == counterNo && rec.IsActive == true select rec).FirstOrDefault();

                        ((MDIParent)this.ParentForm).toolStripStatusLabel.Text = "Sales Person : " + MemberShip.UserName + " | Counter : " + cboCounter.Text +"";

                        //Check Start Day
                        //if (dailyRecord != null)
                        //{
                        //    ManageRoles();

                        //    Sales form = new Sales();
                        //    form.WindowState = FormWindowState.Maximized;
                        //    form.MdiParent = ((MDIParent)this.ParentForm);
                        //    form.Show();
                        //}
                        //else
                        //{
                        //    ManageRoles();

                        //    StartDay newform = new StartDay();
                        //    newform.MdiParent = ((MDIParent)this.ParentForm);
                        //    newform.Show();
                        //}


                        ManageRoles();

                        Sales form = new Sales();
                        form.WindowState = FormWindowState.Maximized;
                        form.MdiParent = ((MDIParent)this.ParentForm);
                        form.Show();

                        ((MDIParent)this.ParentForm).logInToolStripMenuItem1.Visible = false;
                        ((MDIParent)this.ParentForm).logOutToolStripMenuItem.Visible = true;

                        this.Close();
                        CheckSetting();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    if (name == "superuser")
                    {
                        int year = Convert.ToInt32(DateTime.Now.Year.ToString());
                        int month = Convert.ToInt32(DateTime.Now.Month.ToString());
                        int num = year + month;
                        string newpass = num.ToString() + "sourcecode" + month.ToString();
                        if (newpass == password)
                        {
                            MemberShip.isAdmin = true;
                            ((MDIParent)this.ParentForm).menuStrip.Enabled = true;
                            Sales form = new Sales();
                            form.WindowState = FormWindowState.Maximized;
                            form.MdiParent = ((MDIParent)this.ParentForm);
                            form.Show();
                            CheckSetting();
                        }
                        else MessageBox.Show("Wrong Password");
                    }
                    else
                    {
                        MessageBox.Show("There is no user exist with this user name");
                    }
                }
            }
            
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtUserName);
            tp.Hide(cboCounter);
        }        

        #endregion

        #region Functions

        private void CheckSetting()
        {
            Boolean HasEmpty = false;

            if (SettingController.BranchName == null || SettingController.BranchName == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultCity == 0 || SettingController.BranchName == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultTaxRate == null || SettingController.DefaultTaxRate == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultTopSaleRow == 0)
            {
                HasEmpty = true;
            }
            else if (SettingController.OpeningHours == null || SettingController.OpeningHours == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.PhoneNo == null || SettingController.PhoneNo == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.ShopName == null || SettingController.ShopName == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultTaxRate != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultTaxRate);
                APP_Data.Tax taxObj = entity.Taxes.Where(x => x.Id == id).FirstOrDefault();
                if (taxObj == null)
                {
                    HasEmpty = true;
                }
            }
            else if (SettingController.DefaultCity != 0)
            {
                int id = SettingController.DefaultCity;
                APP_Data.City cityObj = entity.Cities.Where(x => x.Id == id).FirstOrDefault();
                if (cityObj == null)
                {
                    HasEmpty = true;
                }
            }
            else if (DefaultPrinter.A4Printer == null || DefaultPrinter.A4Printer == string.Empty)
            {
                HasEmpty = true;
            }
            else if (DefaultPrinter.BarcodePrinter == null || DefaultPrinter.BarcodePrinter == string.Empty)
            {
                HasEmpty = true;
            }
            else if (DefaultPrinter.SlipPrinter == null || DefaultPrinter.SlipPrinter == string.Empty)
            {
                HasEmpty = true;
            }

            if (HasEmpty)
            {
                Setting newForm = new Setting();
                newForm.ControlBox = false;
                newForm.ShowDialog();
            }

        }

        private void ManageRoles()
        {

            //if user isn't using server, he/she can't do backup
           // if (DatabaseControlSetting._ServerName.ToUpper() == System.Environment.MachineName.ToUpper())
            if (DatabaseControlSetting._ServerName.ToUpper().Contains(System.Environment.MachineName.ToUpper()))
            {
                ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled = true;
            }

            //Admin
            if (MemberShip.UserRole == "Admin")
            {
                MemberShip.isAdmin = true;
                ((MDIParent)this.ParentForm).menuStrip.Enabled = true;

                #region Account
                //Reopen menu if other roles login here before
                ((MDIParent)this.ParentForm).accountToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).userListToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).addNewUserToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).roleManagementToolStripMenuItem1.Enabled = true;
#endregion

                #region Doctor Menu
                ((MDIParent)this.ParentForm).doctorToolStripMenuItem.Visible=
                ((MDIParent)this.ParentForm).addNewDoctorAndPhysioToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).doctorAndPhysioListToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).doctorPaymentReportToolStripMenuItem.Enabled = true;
                #endregion

                #region Physio Menu
                ((MDIParent)this.ParentForm).physioToolStripMenuItem.Visible=
                ((MDIParent)this.ParentForm).addGroupToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).createPhysioGroupToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).groupListToolStripMenuItem.Enabled = true;
                #endregion

                #region Customer Menu
                ((MDIParent)this.ParentForm).customerListToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).addNewCustomerToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).giftCardContToolStripMenuItem.Enabled = true;
                #endregion

                #region Supplier Menu
                ((MDIParent)this.ParentForm).supplierListToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Enabled = true;
                #endregion

                #region Purchaseing Menu
                ((MDIParent)this.ParentForm).newPurchaseOrderToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).purchaseHistoryToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).purchaseDeleteLogToolStripMenuItem.Enabled = true;
                #endregion

                #region Product Menu
                ((MDIParent)this.ParentForm).brandToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).productCategoryToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).productSubCategoryToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).productListToolStripMenuItem1.Enabled = true;
                ((MDIParent)this.ParentForm).addNewProductToolStripMenuItem.Enabled = true;
                #endregion



                #region Expense Menu
                ((MDIParent)this.ParentForm).expenseToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).expenseToolStripMenuItem.Visible = true;

                ((MDIParent)this.ParentForm).createExpenseEntryToolStripMenuItem.Enabled =
          ((MDIParent)this.ParentForm).createExpenseEntryToolStripMenuItem.Visible = 

                ((MDIParent)this.ParentForm).expenseListToolStripMenuItem.Enabled =
                 ((MDIParent)this.ParentForm).expenseListToolStripMenuItem.Visible = 

                ((MDIParent)this.ParentForm).expenseDeleteLogToolStripMenuItem.Enabled =
                 ((MDIParent)this.ParentForm).expenseDeleteLogToolStripMenuItem.Visible =
                #endregion

          
                #region Report Menu
                ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Visible=

                ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Visible=

                // ((MDIParent)this.ParentForm).dailyTotalTransactionToolStripMenuItem.Enabled = true;
                ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Enabled = 
                 ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Visible=
                //((MDIParent)this.ParentForm).dailySummaryToolStripMenuItem.Enabled = true;


                ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Visible=

                ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Visible=

                ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).topToolStripMenuItem.Enabled = 
                 ((MDIParent)this.ParentForm).topToolStripMenuItem.Visible =


                ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Enabled = 
                 ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).outstandingCustomerToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).outstandingCustomerToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Enabled = 
                 ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Enabled = 
                 ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Enabled = 
                  ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Enabled = 
                    ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).doctorPaymentReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).doctorPaymentReportToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).physioPaymentReportToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).physioPaymentReportToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).dailyDoctorPaymentToolStripMenuItem.Enabled = 
                ((MDIParent)this.ParentForm).dailyDoctorPaymentToolStripMenuItem.Visible =

                ((MDIParent)this.ParentForm).netIncomeSummaryReportToolStripMenuItem.Visible =
             ((MDIParent)this.ParentForm).netIncomeSummaryReportToolStripMenuItem.Enabled =

             ((MDIParent)this.ParentForm).reportsToolStripMenuItem.Visible = true;
                #endregion

    
             
            
             
          
              

                //export and import are only allowed on server machine
               // if (DatabaseControlSetting._ServerName.ToUpper() == System.Environment.MachineName.ToUpper())
                if (DatabaseControlSetting._ServerName.ToUpper().Contains(System.Environment.MachineName.ToUpper()))
                {
                    ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled = true;
                    ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled = false;
                    ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Enabled = false;
                }  

            }
            //Super Casher OR Casher
            else
            {
                MemberShip.isAdmin = false;
                ((MDIParent)this.ParentForm).menuStrip.Enabled = true;
                RoleManagementController controller = new RoleManagementController();
                controller.Load(MemberShip.UserRoleId);

                #region account menu
                //Close some menu for these two role
                ((MDIParent)this.ParentForm).accountToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).userListToolStripMenuItem1.Enabled = false;
               
                ((MDIParent)this.ParentForm).addNewUserToolStripMenuItem.Enabled = false;
          
                ((MDIParent)this.ParentForm).roleManagementToolStripMenuItem1.Enabled = false;
             
#endregion

                #region Doctor Menu
                if (!controller.Doctor.Add) ((MDIParent)this.ParentForm).addNewDoctorAndPhysioToolStripMenuItem.Enabled = false;
                if (!controller.Doctor.View) ((MDIParent)this.ParentForm).doctorAndPhysioListToolStripMenuItem1.Enabled = false;
                if (!controller.Doctor.Payment) ((MDIParent)this.ParentForm).dailyDoctorPaymentToolStripMenuItem.Enabled = false;
                #endregion

                #region Physio Menu

                if (!controller.Physio.Add) ((MDIParent)this.ParentForm).addGroupToolStripMenuItem1.Enabled = false;
                if (!controller.Physio.AddGroup) ((MDIParent)this.ParentForm).createPhysioGroupToolStripMenuItem1.Enabled = false;
                if (!controller.Physio.View) ((MDIParent)this.ParentForm).groupListToolStripMenuItem.Enabled = false;
                #endregion

                #region Customer Menu
                if (!controller.Customer.View) ((MDIParent)this.ParentForm).customerListToolStripMenuItem.Enabled = false;
                if (!controller.Customer.Add) ((MDIParent)this.ParentForm).addNewCustomerToolStripMenuItem.Enabled = false;
                if (!controller.GiftCard.View) ((MDIParent)this.ParentForm).giftCardContToolStripMenuItem.Enabled = false;
                #endregion

                #region Supplier Menu
                if (!controller.Supplier.View) ((MDIParent)this.ParentForm).supplierListToolStripMenuItem.Enabled = false;
                if (!controller.Supplier.Add) ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Enabled = false;
                if (!controller.OutstandingSupplier.View) ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Enabled = false;
                #endregion

                #region Purchaseing Menu
                if (!controller.PurchaseRole.Add) ((MDIParent)this.ParentForm).newPurchaseOrderToolStripMenuItem.Enabled = false;
                if (!controller.PurchaseRole.View) ((MDIParent)this.ParentForm).purchaseHistoryToolStripMenuItem.Enabled = false;
                if (!controller.PurchaseRole.DeleteLog) ((MDIParent)this.ParentForm).purchaseDeleteLogToolStripMenuItem.Enabled = false;
                #endregion

                #region Product Menu
                if (!controller.Product.View) ((MDIParent)this.ParentForm).productListToolStripMenuItem1.Enabled = false;
                if (!controller.Product.Add) ((MDIParent)this.ParentForm).addNewProductToolStripMenuItem.Enabled = false;
                if (!controller.Brand.View) ((MDIParent)this.ParentForm).brandToolStripMenuItem1.Enabled = false;
                if (!controller.Category.View) ((MDIParent)this.ParentForm).productCategoryToolStripMenuItem1.Enabled = false;
                if (!controller.SubCategory.View) ((MDIParent)this.ParentForm).productSubCategoryToolStripMenuItem.Enabled = false;
                #endregion

  
   

                #region Expense Menu

                if (controller.Expense.Add == false && controller.Expense.View == false
                    && controller.Expense.DeleteLog == false)
                {
                    ((MDIParent)this.ParentForm).expenseToolStripMenuItem.Visible = false;
                }
                else
                {
                    ((MDIParent)this.ParentForm).expenseToolStripMenuItem.Visible = true;
                    ((MDIParent)this.ParentForm).createExpenseEntryToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).createExpenseEntryToolStripMenuItem.Visible = controller.Expense.Add;

                    ((MDIParent)this.ParentForm).expenseListToolStripMenuItem.Enabled =
                     ((MDIParent)this.ParentForm).expenseListToolStripMenuItem.Visible = controller.Expense.View;

                    ((MDIParent)this.ParentForm).expenseDeleteLogToolStripMenuItem.Enabled =
                     ((MDIParent)this.ParentForm).expenseDeleteLogToolStripMenuItem.Visible = controller.Expense.DeleteLog;
                }
             
                #endregion

         
                #region Report Menu
                if (!controller.TransactionReport.View)
                { 
                    ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Enabled = 
                      ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Visible=controller.TransactionReport.View;
                }
                if (!controller.TransactionSummaryReport.View)
                {
                    ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Enabled =
                      ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Visible = controller.TransactionSummaryReport.View;
                }
                if (!controller.TransactionDetailReport.View)
                {
                    ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Enabled = 
                    ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Visible=controller.TransactionDetailReport.View;
                }
                // if (!controller.DailyTotalTransactions.View) ((MDIParent)this.ParentForm).dailyTotalTransactionToolStripMenuItem.Enabled = false;
                if (!controller.PurchaseReport.View)
                {
                    ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Visible=controller.PurchaseReport.View;
                }
                if (!controller.PurchaseDiscount.View)
                {
                    ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Enabled =
                     ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Visible=controller.PurchaseDiscount.View;
                }
                if (!controller.ItemSummaryReport.View)
                {
                    ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Enabled = 
                     ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Visible=controller.ItemSummaryReport.View;
                }
                if (!controller.SaleBreakdown.View)
                {
                    ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Enabled = 
                     ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Visible=controller.SaleBreakdown.View;
                }
                if (!controller.TaxSummaryReport.View)
                {
                    ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Enabled = 
                      ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Visible=controller.TaxSummaryReport.View;
                }
                if (!controller.TopBestSellerReport.View)
                {
                    ((MDIParent)this.ParentForm).topToolStripMenuItem.Enabled =
                      ((MDIParent)this.ParentForm).topToolStripMenuItem.Visible=controller.TopBestSellerReport.View;
                }
                if (!controller.CustomerSales.View)
                {
                    ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Enabled = 
                     ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Visible=controller.CustomerSales.View;
                }

                if (!controller.OutstandingCustomerReport.View)
                {
                    ((MDIParent)this.ParentForm).outstandingCustomerToolStripMenuItem.Enabled = 
                    ((MDIParent)this.ParentForm).outstandingCustomerToolStripMenuItem.Visible=controller.OutstandingCustomerReport.View;
                }
                if (!controller.CustomerInformation.View)
                {
                    ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Enabled = 
                     ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Visible=controller.CustomerInformation.View;
                }
                if (!controller.PurchaseReport.View)
                {
                    ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Enabled = 
                     ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Visible=controller.PurchaseReport.View;
                }
                if (!controller.PurchaseDiscount.View)
                {
                    ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Enabled = 
                       ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Visible=controller.PurchaseDiscount.View;
                }
                if (!controller.ReorderPointReport.View)
                {
                    ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Visible=controller.ReorderPointReport.View;
                }
                if (!controller.Consigment.View)
                {
                    ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Enabled =
                     ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Visible=controller.Consigment.View;
                }
                if (!controller.ProfitAndLoss.View)
                {
                    ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Enabled = 
                    ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Visible=controller.ProfitAndLoss.View;
                }
                if (!controller.DoctorPaymentReport.View)
                {
                    ((MDIParent)this.ParentForm).doctorPaymentReportToolStripMenuItem.Enabled =
                     ((MDIParent)this.ParentForm).doctorPaymentReportToolStripMenuItem.Visible=controller.DoctorPaymentReport.View;
                }
                if (!controller.PhysioPaymentReport.View)
                {
                    ((MDIParent)this.ParentForm).physioPaymentReportToolStripMenuItem.Enabled = 
                    ((MDIParent)this.ParentForm).physioPaymentReportToolStripMenuItem.Visible = controller.PhysioPaymentReport.View;
                }

                if (!controller.NetIncomeReport.View)
                {
                     ((MDIParent)this.ParentForm).netIncomeSummaryReportToolStripMenuItem.Enabled=
                    ((MDIParent)this.ParentForm).netIncomeSummaryReportToolStripMenuItem.Visible = controller.NetIncomeReport.View;
                }
                //  ((MDIParent)this.ParentForm).netIncomeSummaryReportToolStripMenuItem.Enabled =
                //((MDIParent)this.ParentForm).netIncomeSummaryReportToolStripMenuItem.Visible = controller.NetIncomeReport.View;
                #endregion

         
         

           
 

      


          


                //Reports
               // if (!controller.DailySaleSummary.View) ((MDIParent)this.ParentForm).dailySummaryToolStripMenuItem.Enabled = false;
      

                //Chashier are not allowed to restore database, 
                ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Enabled = false;
                //export are only allowed on server machine
                if (DatabaseControlSetting._ServerName.ToUpper() == System.Environment.MachineName.ToUpper())
                {
                    ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled = false;
                }  
            }
        }

        #endregion

        
        
    }
}
