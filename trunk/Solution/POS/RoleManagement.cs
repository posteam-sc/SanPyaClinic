using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class RoleManagement : Form
    {        
        #region Events

        public RoleManagement()
        {
            InitializeComponent();
        }

        private void RoleManagement_Load(object sender, EventArgs e)
        {
            #region Load Data for Super Casher Role

            RoleManagementController controller = new RoleManagementController();
            //Super Casher Id
            controller.Load(2);            

            //Product
            chkViewProductSC.Checked = controller.Product.View;
            chkEditProductSC.Checked =controller.Product.EditOrDelete ;
            chkAddProductSC.Checked = controller.Product.Add ;

            //Brand
            chkViewBrandSC.Checked = controller.Brand.View ;
            chkEditBrandSC.Checked = controller.Brand.EditOrDelete;
            chkAddBrandSC.Checked = controller.Brand.Add ;

            //Giftcard
            chkViewGiftcardSC.Checked = controller.GiftCard.View ;
            chkAddGiftCardSC.Checked = controller.GiftCard.Add ;
            chkDeleteGiftCardSC.Checked = controller.GiftCard.EditOrDelete;

            //Customer
            chkViewCustomerSC.Checked = controller.Customer.View ;
            chkEditCustomerSC.Checked = controller.Customer.EditOrDelete ;
            chkAddCustomerSC.Checked = controller.Customer.Add ;

            //Category
            chkViewCategorySC.Checked = controller.Category.View ;
            chkEditCategorySC.Checked = controller.Category.EditOrDelete ;
            chkAddCategorySC.Checked = controller.Category.Add ;

            //SubCategory
            chkViewSubCategorySC.Checked = controller.SubCategory.View ;
            chkEditSubCategorySC.Checked = controller.SubCategory.EditOrDelete ;
            chkAddSubCategorySC.Checked = controller.SubCategory.Add ;

            //Counter            
            chkEditCounterSC.Checked = controller.Counter.EditOrDelete ;
            chkAddCounterSC.Checked = controller.Counter.Add ;

            //Supplier
            chkEditSupplierSC.Checked = controller.Supplier.EditOrDelete;
            chkAddSupplierSC.Checked = controller.Supplier.Add;
            chkViewSupplierSC.Checked = controller.Supplier.View;
            chk_ViewDetailVoucher_SC.Checked=controller.Supplier.ViewDetail;
            chkOutstandingSupListSC.Checked = controller.OutstandingSupplier.View;
            chkOutstandingSupDetailSC.Checked = controller.OutstandingSupplier.ViewDetail;

            //Purchasing
            chkPurchaseListSC.Checked = controller.PurchaseRole.View;
            chkPurchaseDetelte_SC.Checked = controller.PurchaseRole.EditOrDelete;
            chkPurchaseDetail_SC.Checked = controller.PurchaseRole.ViewDetail;
            chkAddPurchase_SC.Checked = controller.PurchaseRole.Add;    

            //Doctor
            chk_AddNewDoctor_SC.Checked = controller.Doctor.Add;
            chk_doctorListView_SC.Checked = controller.Doctor.View;
            chk_DoctorPaymentList_SC.Checked = controller.Doctor.Payment;
            chk_doctorDetail_SC.Checked = controller.Doctor.ViewDetail;
            chk_DoctorDelete_SC.Checked = controller.Doctor.EditOrDelete;
            chk_PrintPayment_SC.Checked = controller.Doctor.Print;
            
            //Physio
            chk_AddGroup_SC.Checked = controller.Physio.Add;
            chk_GroupList_SC.Checked = controller.Physio.AddGroup;
            chk_createPhsioGroup_SC.Checked = controller.Physio.View;
            chk_GroupDelete_SC.Checked = controller.Physio.EditOrDelete;
            chk_DetailPhysioGroup_SC.Checked = controller.Physio.ViewDetail;

            //Purchasing
            chkPurchaseListSC.Checked = controller.PurchaseRole.View;
            chkPurchaseDetelte_SC.Checked = controller.PurchaseRole.EditOrDelete;
            chkPurchaseDetail_SC.Checked = controller.PurchaseRole.ViewDetail;
            chkAddPurchase_SC.Checked = controller.PurchaseRole.Add;
            chkDeleteLogPurSC.Checked = controller.PurchaseRole.DeleteLog;
            chkApprovedPurSC.Checked = controller.PurchaseRole.Approved;


            //Expense
            chkExpenseListSC.Checked = controller.Expense.View;
            chkExpenseDetelte_SC.Checked = controller.Expense.EditOrDelete;
            chkExpenseDetail_SC.Checked = controller.Expense.ViewDetail;
            chkAddExpense_SC.Checked = controller.Expense.Add;
            chkDeleteLogExpenseSC.Checked = controller.Expense.DeleteLog;
            chkApprovedExpenseSC.Checked = controller.Expense.Approved;

            // Reports
            //chkDailySaleSummary_SC.Checked=controller.DailySaleSummary.View;
            chkTransactionSC.Checked=controller.TransactionReport.View;
            chkTransactionSummarySC.Checked=controller.TransactionSummaryReport.View;
            chkTransactionDetail_SC.Checked=controller.TransactionDetailReport.View;
            chkDailyTotalTransaction_SC.Checked=controller.DailyTotalTransactions.View ;
            chkPurchasingSC.Checked=controller.PurchaseReport.View;
            chkPurchasingDiscount_SC.Checked=controller.PurchaseDiscount.View;
            chkItemSummary_SC.Checked=controller.ItemSummaryReport.View;
            chkTopBestSellerSC.Checked=controller.TopBestSellerReport.View;
            chkCustomerSale_SC.Checked=controller.CustomerSales.View  ;
            chkOutStandingCustomer_SC.Checked=controller.OutstandingCustomerReport.View;
            chkTaxSummary_SC.Checked=controller.TaxSummaryReport.View;
            chkSalebreakdown_SC.Checked=controller.SaleBreakdown.View;
            chkCustomerInformation_SC.Checked=controller.CustomerInformation.View;
            chkProductReport_SC.Checked=controller.ProductReport.View;
            chkReorderReport_SC.Checked=controller.ReorderPointReport.View;
            chkConsigment_SC.Checked=controller.Consigment.View;
            chkGrossProfit_SC.Checked=controller.ProfitAndLoss.View;
            chk_doctorPaymentReport_SC.Checked = controller.DoctorPaymentReport.View;
            chk_PysioPaymentReport_SC.Checked = controller.PhysioPaymentReport.View;
            chk_netIncomeSummary_SC.Checked = controller.NetIncomeReport.View;



            #endregion

            #region Load Data for Casher Role

            RoleManagementController controllerCasher = new RoleManagementController();

            //Super Casher Id
            controllerCasher.Load(3);

            //Product
            chkViewProductC.Checked = controllerCasher.Product.View;
            chkEditProductC.Checked = controllerCasher.Product.EditOrDelete;
            chkAddProductC.Checked = controllerCasher.Product.Add;

            //Brand
            chkViewBrandC.Checked = controllerCasher.Brand.View;
            chkEditBrandC.Checked = controllerCasher.Brand.EditOrDelete;
            chkAddBrandC.Checked = controllerCasher.Brand.Add;

            //Giftcard
            chkViewGiftcardC.Checked = controllerCasher.GiftCard.View;
            chkAddGiftcardC.Checked = controllerCasher.GiftCard.Add;
            chkDeleteGiftCardC.Checked = controllerCasher.GiftCard.EditOrDelete;

            //Customer
            chkViewCustomerC.Checked = controllerCasher.Customer.View;
            chkEditCustomerC.Checked = controllerCasher.Customer.EditOrDelete;
            chkAddCustomerC.Checked = controllerCasher.Customer.Add;

            //Category
            chkViewCategoryC.Checked = controllerCasher.Category.View;
            chkEditCategoryC.Checked = controllerCasher.Category.EditOrDelete;
            chkAddCategoryC.Checked = controllerCasher.Category.Add;

            //SubCategory
            chkViewSubCategoryC.Checked = controllerCasher.SubCategory.View;
            chkEditSubCategoryC.Checked = controllerCasher.SubCategory.EditOrDelete;
            chkAddSubCategoryC.Checked = controllerCasher.SubCategory.Add;

            //Counter            
            chkEditCounterC.Checked = controllerCasher.Counter.EditOrDelete;
            chkAddCounterC.Checked = controllerCasher.Counter.Add;

            //Supplier
            chkEditSupplierC.Checked = controllerCasher.Supplier.EditOrDelete;
            chkAddSupplierC.Checked = controllerCasher.Supplier.Add;
            chkViewSupplierC.Checked = controllerCasher.Supplier.View;
            chk_ViewDetailVoucher_C.Checked = controllerCasher.Supplier.ViewDetail;
            chkOutstandingSupListC.Checked = controllerCasher.OutstandingSupplier.View;
            chkOutstandingSupDetailC.Checked = controllerCasher.OutstandingSupplier.ViewDetail;

            //Purchasing
            chkPurchaseListC.Checked = controllerCasher.PurchaseRole.View;
            chkPurchaseDetelte_C.Checked = controllerCasher.PurchaseRole.EditOrDelete;
            chkPurchaseDetail_C.Checked = controllerCasher.PurchaseRole.ViewDetail;
            chkAddPurchase_C.Checked = controllerCasher.PurchaseRole.Add;
            chkDeleteLogPurC.Checked = controllerCasher.PurchaseRole.DeleteLog;
            chkApprovedPurC.Checked = controllerCasher.PurchaseRole.Approved;


            //Expense
            chkExpenseListC.Checked = controllerCasher.Expense.View;
            chkExpenseDetelte_C.Checked = controllerCasher.Expense.EditOrDelete;
            chkExpenseDetail_C.Checked = controllerCasher.Expense.ViewDetail;
            chkAddExpense_C.Checked = controllerCasher.Expense.Add;
            chkDeleteLogExpenseC.Checked = controllerCasher.Expense.DeleteLog;
            chkApprovedExpenseC.Checked = controllerCasher.Expense.Approved;

            //Doctor
            chk_AddNewDoctor_C.Checked = controllerCasher.Doctor.Add;
            chk_doctorListView_C.Checked = controllerCasher.Doctor.View;
            chk_DoctorPaymentList_C.Checked = controllerCasher.Doctor.Payment;
            chk_DoctorDelete_C.Checked = controllerCasher.Doctor.EditOrDelete;            
            chk_doctorDetail_C.Checked = controllerCasher.Doctor.ViewDetail;
            chk_PrintPayment_C.Checked = controllerCasher.Doctor.Print;

            //Physio
            chk_AddGroup_C.Checked = controllerCasher.Physio.Add;
            chk_GroupList_C.Checked = controllerCasher.Physio.AddGroup;
            chk_createPhsioGroup_C.Checked = controllerCasher.Physio.View;
            chk_GroupDelete_C.Checked = controllerCasher.Physio.EditOrDelete;
            chk_DetailPhysioGroup_C.Checked = controllerCasher.Physio.ViewDetail;

            //Report
            //chkDailySaleSummary_C.Checked = controllerCasher.DailySaleSummary.View;
            chkTransactionC.Checked = controllerCasher.TransactionReport.View;
            chkTransactionSummaryC.Checked = controllerCasher.TransactionSummaryReport.View;
            chkTransactionDetail_C.Checked = controllerCasher.TransactionDetailReport.View;
            chkDailyTotalTransaction_C.Checked = controllerCasher.DailyTotalTransactions.View;
            chkPurchasingC.Checked = controllerCasher.PurchaseReport.View;
            chkPurchasingDiscount_C.Checked = controllerCasher.PurchaseDiscount.View;
            chkItemSummary_C.Checked = controllerCasher.ItemSummaryReport.View;
            chkTopBestSellerC.Checked = controllerCasher.TopBestSellerReport.View;
            chkCustomerSale_C.Checked = controllerCasher.CustomerSales.View;
            chkOutStandingCustomer_C.Checked = controllerCasher.OutstandingCustomerReport.View;
            chkTaxSummary_C.Checked = controllerCasher.TaxSummaryReport.View;
            chkSalebreakdown_C.Checked = controllerCasher.SaleBreakdown.View;
            chkCustomerInformation_C.Checked = controllerCasher.CustomerInformation.View;
            chkProductReport_C.Checked = controllerCasher.ProductReport.View;
            chkReorderReport_C.Checked = controllerCasher.ReorderPointReport.View;
            chkConsigment_C.Checked = controllerCasher.Consigment.View;
            chkGrossProfit_C.Checked = controllerCasher.ProfitAndLoss.View;
            chk_doctorPaymentReport_C.Checked = controllerCasher.DoctorPaymentReport.View;
            chk_PysioPaymentReport_C.Checked = controllerCasher.PhysioPaymentReport.View;
            chk_netIncomeSummary_C.Checked = controllerCasher.NetIncomeReport.View;
          

            #endregion
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Save for Super Casher Role

            RoleManagementController controller = new RoleManagementController();

                      
            //Product
            controller.Product.View = chkViewProductSC.Checked;
            controller.Product.EditOrDelete = chkEditProductSC.Checked;
            controller.Product.Add = chkAddProductSC.Checked;

            //Brand
            controller.Brand.View = chkViewBrandSC.Checked;
            controller.Brand.EditOrDelete = chkEditBrandSC.Checked;
            controller.Brand.Add = chkAddBrandSC.Checked;

            //Giftcard
            controller.GiftCard.View = chkViewGiftcardSC.Checked;
            controller.GiftCard.Add = chkAddGiftCardSC.Checked;
            controller.GiftCard.EditOrDelete = chkDeleteGiftCardSC.Checked;

            //Customer
            controller.Customer.View = chkViewCustomerSC.Checked;
            controller.Customer.EditOrDelete = chkEditCustomerSC.Checked;
            controller.Customer.Add = chkAddCustomerSC.Checked;

            //Category
            controller.Category.View = chkViewCategorySC.Checked;
            controller.Category.EditOrDelete = chkEditCategorySC.Checked;
            controller.Category.Add = chkAddCategorySC.Checked;

            //SubCategory
            controller.SubCategory.View = chkViewSubCategorySC.Checked;
            controller.SubCategory.EditOrDelete = chkEditSubCategorySC.Checked;
            controller.SubCategory.Add = chkAddSubCategorySC.Checked;

            //Counter            
            controller.Counter.EditOrDelete = chkEditCounterSC.Checked;
            controller.Counter.Add = chkAddCounterSC.Checked;

            //Supplier
            controller.Supplier.EditOrDelete = chkEditSupplierSC.Checked;
            controller.Supplier.Add = chkAddSupplierSC.Checked;
            controller.Supplier.View = chkViewSupplierSC.Checked;
            controller.Supplier.ViewDetail = chk_ViewDetailVoucher_SC.Checked;
            controller.OutstandingSupplier.View = chkOutstandingSupListSC.Checked;
            controller.OutstandingSupplier.ViewDetail = chkOutstandingSupDetailSC.Checked;

            //Purchase
            controller.PurchaseRole.View = chkPurchaseListSC.Checked;
            controller.PurchaseRole.EditOrDelete = chkPurchaseDetelte_SC.Checked;
            controller.PurchaseRole.ViewDetail = chkPurchaseDetail_SC.Checked;
            controller.PurchaseRole.Add = chkAddPurchase_SC.Checked;
            controller.PurchaseRole.DeleteLog = chkDeleteLogPurSC.Checked;
            controller.PurchaseRole.Approved = chkApprovedPurSC.Checked;


            //Expense
            controller.Expense.View = chkExpenseListSC.Checked;
            controller.Expense.EditOrDelete = chkExpenseDetelte_SC.Checked;
            controller.Expense.ViewDetail = chkExpenseDetail_SC.Checked;
            controller.Expense.Add = chkAddExpense_SC.Checked;
            controller.Expense.DeleteLog = chkDeleteLogExpenseSC.Checked;
            controller.Expense.Approved = chkApprovedExpenseSC.Checked;

            //Doctor
            controller.Doctor.Add = chk_AddGroup_SC.Checked;
            controller.Doctor.View = chk_doctorListView_SC.Checked;
            controller.Doctor.Payment = chk_DoctorPaymentList_SC.Checked;
            controller.Doctor.EditOrDelete = chk_DoctorDelete_SC.Checked;
            controller.Doctor.Print = chk_PrintPayment_SC.Checked;
            controller.Doctor.ViewDetail = chk_doctorDetail_SC.Checked;


            //Physio
            controller.Physio.Add = chk_AddGroup_SC.Checked;
            controller.Physio.AddGroup = chk_GroupList_SC.Checked;
            controller.Physio.View = chk_createPhsioGroup_SC.Checked;
            controller.Physio.ViewDetail = chk_DetailPhysioGroup_SC.Checked;
            controller.Physio.EditOrDelete = chk_GroupDelete_SC.Checked;


           // Reports
           // controller.DailySaleSummary.View = chkDailySaleSummary_SC.Checked;
            controller.TransactionReport.View = chkTransactionSC.Checked;
            controller.TransactionSummaryReport.View = chkTransactionSummarySC.Checked;
            controller.TransactionDetailReport.View = chkTransactionDetail_SC.Checked;
            controller.DailyTotalTransactions.View = chkDailyTotalTransaction_SC.Checked;
            controller.PurchaseReport.View = chkPurchasingSC.Checked;
            controller.PurchaseDiscount.View = chkPurchasingDiscount_SC.Checked;
            controller.ItemSummaryReport.View  =chkItemSummary_SC.Checked;
            controller.TopBestSellerReport.View = chkTopBestSellerSC.Checked;
            controller.CustomerSales.View = chkCustomerSale_SC.Checked;
            controller.OutstandingCustomerReport.View = chkOutStandingCustomer_SC.Checked;
            controller.TaxSummaryReport.View = chkTaxSummary_SC.Checked;
            controller.SaleBreakdown.View =chkSalebreakdown_SC.Checked;
            controller.CustomerInformation.View = chkCustomerInformation_SC.Checked;
            controller.ProductReport.View = chkProductReport_SC.Checked;
            controller.ReorderPointReport.View =chkReorderReport_SC.Checked;              
            controller.Consigment.View = chkConsigment_SC.Checked;
            controller.ProfitAndLoss.View = chkGrossProfit_SC.Checked;
            controller.DoctorPaymentReport.View = chk_doctorPaymentReport_SC.Checked;
            controller.PhysioPaymentReport.View = chk_PysioPaymentReport_SC.Checked;
            controller.NetIncomeReport.View = chk_netIncomeSummary_SC.Checked;



            //Super Casher Id
            controller.Save(2);

            #endregion

            #region Save for Casher Role

            RoleManagementController controllerCasher = new RoleManagementController();                        

            //Product
            controllerCasher.Product.View = chkViewProductC.Checked;
            controllerCasher.Product.EditOrDelete = chkEditProductC.Checked;
            controllerCasher.Product.Add = chkAddProductC.Checked;

            //Brand
            controllerCasher.Brand.View = chkViewBrandC.Checked;
            controllerCasher.Brand.EditOrDelete = chkEditBrandC.Checked;
            controllerCasher.Brand.Add = chkAddBrandC.Checked;

            //Giftcard
            controllerCasher.GiftCard.View = chkViewGiftcardC.Checked;
            controllerCasher.GiftCard.Add = chkAddGiftcardC.Checked;
            controllerCasher.GiftCard.EditOrDelete = chkDeleteGiftCardC.Checked;

            //Customer
            controllerCasher.Customer.View = chkViewCustomerC.Checked;
            controllerCasher.Customer.EditOrDelete = chkEditCustomerC.Checked;
            controllerCasher.Customer.Add = chkAddCustomerC.Checked;

            //Category
            controllerCasher.Category.View = chkViewCategoryC.Checked;
            controllerCasher.Category.EditOrDelete = chkEditCategoryC.Checked;
            controllerCasher.Category.Add = chkAddCategoryC.Checked;

            //SubCategory
            controllerCasher.SubCategory.View = chkViewSubCategoryC.Checked;
            controllerCasher.SubCategory.EditOrDelete = chkEditSubCategoryC.Checked;
            controllerCasher.SubCategory.Add = chkAddSubCategoryC.Checked;

            //Counter            
            controllerCasher.Counter.EditOrDelete = chkEditCounterC.Checked;
            controllerCasher.Counter.Add = chkAddCounterC.Checked;

            //Supplier
            controllerCasher.Supplier.EditOrDelete = chkEditSupplierC.Checked;
            controllerCasher.Supplier.Add = chkAddSupplierC.Checked;
            controllerCasher.Supplier.View = chkViewSupplierC.Checked;
            controllerCasher.Supplier.ViewDetail = chk_ViewDetailVoucher_C.Checked;
            controllerCasher.OutstandingSupplier.View = chkOutstandingSupListSC.Checked;
            controllerCasher.OutstandingSupplier.ViewDetail = chkOutstandingSupDetailSC.Checked;

            //Purchase
            controllerCasher.PurchaseRole.View = chkPurchaseListC.Checked;
            controllerCasher.PurchaseRole.EditOrDelete = chkPurchaseDetelte_C.Checked;
            controllerCasher.PurchaseRole.ViewDetail = chkPurchaseDetail_C.Checked;
            controllerCasher.PurchaseRole.Add = chkAddPurchase_C.Checked;
            controllerCasher.PurchaseRole.DeleteLog = chkDeleteLogPurC.Checked;
            controllerCasher.PurchaseRole.Approved = chkApprovedPurC.Checked;


            //Expense
            controllerCasher.Expense.View = chkExpenseListC.Checked;
            controllerCasher.Expense.EditOrDelete = chkExpenseDetelte_C.Checked;
            controllerCasher.Expense.ViewDetail = chkExpenseDetail_C.Checked;
            controllerCasher.Expense.Add = chkAddExpense_C.Checked;
            controllerCasher.Expense.DeleteLog = chkDeleteLogExpenseC.Checked;
            controllerCasher.Expense.Approved = chkApprovedExpenseC.Checked;

            //Doctor
            controllerCasher.Doctor.Add = chk_AddGroup_C.Checked;
            controllerCasher.Doctor.View = chk_doctorListView_C.Checked;
            controllerCasher.Doctor.Payment = chk_DoctorPaymentList_C.Checked;
            controllerCasher.Doctor.Print = chk_PrintPayment_C.Checked;
            controllerCasher.Doctor.ViewDetail = chk_doctorDetail_C.Checked;
            controllerCasher.Doctor.EditOrDelete = chk_DoctorDelete_C.Checked;

            //Physio
            controllerCasher.Physio.Add = chk_AddGroup_C.Checked;
            controllerCasher.Physio.AddGroup = chk_GroupList_C.Checked;
            controllerCasher.Physio.View = chk_createPhsioGroup_C.Checked;
            controllerCasher.Physio.ViewDetail = chk_DetailPhysioGroup_C.Checked;
            controllerCasher.Physio.EditOrDelete = chk_GroupDelete_C.Checked;

            //Reports
            //controllerCasher.DailySaleSummary.View = chkDailySaleSummary_C.Checked;
            controllerCasher.TransactionReport.View = chkTransactionC.Checked;
            controllerCasher.TransactionSummaryReport.View = chkTransactionSummaryC.Checked;
            controllerCasher.TransactionDetailReport.View = chkTransactionDetail_C.Checked;
            controllerCasher.DailyTotalTransactions.View = chkDailyTotalTransaction_C.Checked;
            controllerCasher.PurchaseReport.View = chkPurchasingC.Checked;
            controllerCasher.PurchaseDiscount.View = chkPurchasingDiscount_C.Checked;
            controllerCasher.ItemSummaryReport.View = chkItemSummary_C.Checked;
            controllerCasher.TopBestSellerReport.View = chkTopBestSellerC.Checked;
            controllerCasher.CustomerSales.View = chkCustomerSale_C.Checked;
            controllerCasher.OutstandingCustomerReport.View = chkOutStandingCustomer_C.Checked;
            controllerCasher.TaxSummaryReport.View = chkTaxSummary_C.Checked;
            controllerCasher.SaleBreakdown.View = chkSalebreakdown_C.Checked;
            controllerCasher.CustomerInformation.View = chkCustomerInformation_C.Checked;
            controllerCasher.ProductReport.View = chkProductReport_C.Checked;
            controllerCasher.ReorderPointReport.View = chkReorderReport_C.Checked;
            controllerCasher.Consigment.View = chkConsigment_C.Checked;
            controllerCasher.ProfitAndLoss.View = chkGrossProfit_C.Checked;
            controllerCasher.DoctorPaymentReport.View = chk_doctorPaymentReport_C.Checked;
            controllerCasher.PhysioPaymentReport.View = chk_PysioPaymentReport_C.Checked;
            controllerCasher.NetIncomeReport.View = chk_netIncomeSummary_C.Checked;

            //Casher Id
            controllerCasher.Save(3);

            #endregion

            MessageBox.Show("Saving Complete");
            this.Dispose();
        }

        #endregion


    }
}
