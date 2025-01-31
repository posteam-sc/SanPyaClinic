﻿using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using POS.APP_Data;

namespace POS
{
    class Utility
    {
        /// <summary>
        /// Decrypting incomming file.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123";

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Decryption failed!", "Error");
            }
        }

        /// <summary>
        /// Encrypting incomming file.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;

                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        /// <summary>
        /// Decrypt the input string ( Eg: EncryptString("ABC", string.Empty); )  
        /// </summary>
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Decrypt the input string ( Eg: DecryptString("LoBCnf0JCg8=", string.Empty); )  
        /// </summary>
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        public static string GetSystemMACID()
        {
            string systemName = System.Windows.Forms.SystemInformation.ComputerName;
            try
            {
                ManagementScope theScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
                System.Management.ObjectQuery theQuery = new System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
                ManagementObjectCollection theCollectionOfResults = theSearcher.Get();

                foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                {
                    if (theCurrentObject["MACAddress"] != null)
                    {
                        string macAdd = theCurrentObject["MACAddress"].ToString();
                        return macAdd.Replace(':', '-');
                    }
                }
            }
            catch (ManagementException e)
            {
            }
            catch (System.UnauthorizedAccessException e)
            {

            }
            return string.Empty;
        }
        public static string GetSystemMotherBoardId()
        {
            try
            {
                ManagementObjectSearcher _mbs = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard");
                ManagementObjectCollection _mbsList = _mbs.Get();
                string _id = string.Empty;
                foreach (ManagementObject _mo in _mbsList)
                {
                    _id = _mo["SerialNumber"].ToString();
                    break;
                }

                return _id;
            }
            catch
            {
                return string.Empty;
            }

        }

        public static Boolean IsRegister()
        {
            POSEntities entity = new POSEntities();
            string MacId = Utility.GetSystemMotherBoardId();//Utility.GetSystemMACID();
            Authorize currentKey = (from a in entity.Authorizes where a.macAddress == MacId select a).FirstOrDefault<Authorize>();
            if (currentKey != null)
            {
                return true;
            }
            return false;
        }

        //public static string FillZero(int id)
        //{
        //    string result = string.Empty;
        //    if (id < 10) result = "00000" + id;
        //    else if (id < 100) result = "0000" + id;
        //    else if (id < 1000) result = "000" + id;
        //    else if (id < 10000) result = "00" + id;
        //    else if (id < 100000) result = "0" + id;
        //    else if (id < 1000000) result = id.ToString();

        //    return result;
        //}

        public static void UpdateProductCode(string s, long p)
        {
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@ProductCode", s);
            paras[1] = new SqlParameter("@interestAmount",p);

        }


        //product
        public static Boolean Product_Combo_Control(ComboBox cboProduct)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _productName = cboProduct.Text;

            if (_productName != "Select" && _productName != string.Empty)
            {
                var pro = (from c in entity.Products where c.Name == _productName select c).ToList();

                if (pro.Count <= 0)
                {
                    MessageBox.Show("Product Name '" + cboProduct.Text + "' haven't registered yet!", "mPOS");
                    cboProduct.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }

        //supplier
        public static Boolean Supplier_Combo_Control(ComboBox cboSupplier)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _supName = cboSupplier.Text;

            if (_supName != string.Empty && _supName.Trim() != "Select")
            {
                var sup = (from c in entity.Suppliers where c.Name == _supName select c).ToList();

                if (sup.Count <= 0)
                {
                    MessageBox.Show("Supplier Name '" + cboSupplier.Text + "' haven't registered yet!", "mPOS");
                    cboSupplier.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }

        #region Combo Bind Event
        //Customer
        public static void BindCustomer(ComboBox cboCustomer)
        {
            POSEntities entity = new POSEntities();
            List<Customer> customerList = new List<Customer>();
            Customer customerObj = new Customer();
            customerObj.Id = 0;
            customerObj.Name = "Select All";
            customerList.Add(customerObj);
            customerList.AddRange(entity.Customers.ToList());
            cboCustomer.DataSource = customerList;
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "Id";
            cboCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Supplier
        public static void BindSupplier(ComboBox cboSupplier)
        {
            POSEntities entity = new POSEntities();
            List<Supplier> supplierList = new List<Supplier>();
            Supplier supplierObj = new Supplier();
            supplierObj.Id = 0;
            supplierObj.Name = "Select All";
            supplierList.Add(supplierObj);
            supplierList.AddRange(entity.Suppliers.ToList());
            cboSupplier.DataSource = supplierList;
            cboSupplier.DisplayMember = "Name";
            cboSupplier.ValueMember = "Id";
            cboSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public static void BindExpenseCategory(ComboBox cboExpense)
        {
            POSEntities entity = new POSEntities();
            List<ExpenseCategory> expenseList = new List<ExpenseCategory>();
            ExpenseCategory expenseObj = new ExpenseCategory();
            expenseObj.Id = 0;
            expenseObj.Name = "All";
            expenseList.Add(expenseObj);
            expenseList.AddRange(entity.ExpenseCategories.ToList());
            cboExpense.DataSource = expenseList;
            cboExpense.DisplayMember = "Name";
            cboExpense.ValueMember = "Id";
            cboExpense.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboExpense.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        #endregion
    }

    public static class MemberShip
    {
        public static string UserName;
        public static string UserRole;
        public static int UserRoleId;
        public static int UserId;
        public static bool isLogin;
        public static bool isAdmin;
        public static int CounterId;
    }

    public static class TransactionType
    {
        public static string Sale
        {
            get{ return "Sale";}
        }
        public static string Refund{
            get { return "Refund"; }
        }
        public static string Settlement
        {
            get { return "Settlement"; }
        }
        public static string Credit
        {
            get { return "Credit"; }
        }
        public static string CreditRefund
        {
            get { return "CreditRefund"; }
        }
        public static string Prepaid
        {
            get { return "Prepaid"; }
        }
    }

    public  class TransactionDetailByItemHolder
    {
    //   public int ItemId;
       public string ProductSku;       
       public string Name;
       public string TransactionId;
       public string TransactionType;
       public int Qty;
       public int TotalAmount;
       public DateTime date;
       public string CounterName;
    }

    public class TopProductHolder
    {
        public string ProductId;
        public string Name;
        public decimal Discount;
        public int Qty;
        public long UnitPrice;
        public long totalAmount;

    }
    public class CustomerInfoHolder
    {
        public int PayableAmount;
        public int Id;
        public string Name;
        public string PhNo;
        public string Address;
        public long OutstandingAmount;
        public long RefundAmount;
    }

    public class ConsignmentController
    {
        public string Name;
        public int Qty;
        public int Price;
        public long Total;
        public string counter;
        
    }
    public class ReportItemSummary
    {
        public string Id;
        public string Name;
        public int Qty;
        public int UnitPrice;
        public long totalAmount;
        public int PaymentId;
        public string Size;
    }
    public class ProductReportController
    {
        public string SKUCode;
        public string ProductName;
        public string BrandName;
        public int TotalQty;
        public string Segment;
        public string SubSegment;
        public string Line;
        public bool IsDiscontinous;
    }

    public class ExpenseController
    {
        public int ExpenseDetailId;
        public string ExpenseNo;
        public string Description;
        public decimal Qty;
        public decimal Price;
        public decimal Amount;
    }


    public class CustomerSaleController
    {
        public string  CustomerName;
        public string  ProductName; 
        public int Price;
        public int Qty;
        public int TotalAmount;
        public string TransactionId;
        public DateTime SaleDate;
    }
    public class SaleBreakDownController
    {
        public int bId;
        public string Name;
        public decimal Sales;
        public decimal BreakDown;
        public int saleQty;
        public decimal Refund;
        public int refundQty;
    }
    public class SpecialPromotionController
    {
        public int bId;
        public string Name;
        public decimal Sales;
        public decimal BreakDown;
        public int saleQty;
        public decimal Refund;
        public int refundQty;
    }

    public class PurchaseReportController
    {   public DateTime Date;
        public string ProductName;
        public string SupplierName;
        public int UnitPrice;
        public int Qty;
        public Int64 TotalAmount;
        public string VourcherNo;

    }

    public class NetIncomeReportController
    {
      public int  DrTTConsultationFee;
       public int     OtherDrConsultationFee;
       public int     DrTTInjectionFee;
       public int     OtherDrInjectionFee;
        public int    ServiceChargesFee;
       public int     BookIncomeFee;
       public int     XRayIncomeFee;
        public int    ApplianceExpFee;
      public int      MedicineIncomeFee;
      public int      CommoditiesExpFee;
     public int       SalaryExpFee;
      public int      DailyPTFee;
      public int      PartTimePTFee;
         public int   BookExpFees;
         public int XRayExpFees;
         public int PTIncome;
    }

    public class TotalDailyReport
    {
        public DateTime Date;
        public int TotalTransaction;
        public int TotalQty;
        public Int64 TotalCashAmount;
        public Int64 TotalCreditAmount;
        public Int64 TotalMPUAmount;
        public Int64 TotalGiftCardAmount;
        public Int64 TotalFOCAmount;
        public Int64 TotalTesterAmount;
        public Int64 TotalRefundAmount;
        public Int64 TotalRefundQty;
        public Int64 RepaidAmount;
    }

    public class ProfitAndLoss
    {
        public DateTime SaleDate;
        public int TotalSaleQty;
        public Int64 TotalPurchaseAmount;
        public Int64 TotalSaleAmount;
        public Int64 TotalDiscountAmount;
        public Int64 TotalTaxAmount;
        public Int64 ProfitAndLossAmount;   
    }
    public class DoctorPaymentForDate
    {
      
        public int DID;
        public Nullable<int> Consultantfees;
        public Int64 Injection;
        public Int64 XRay;
        public Int64 PT;
        public Int64 TotalAmount;
        public string Name;
        public int NoP;
    }
    public class PhysioPaymentForDate
    {

        public int DID;
        public decimal Percent;
        public Int64 Amount;
        public string Name;

        public int StaffID;
    }

    public class PurchaseProductController
    {

        public int PurchaseDetailId;
        public string Barcode;
        public string ProductName;
        public int Qty;
        public Int64 PurchasePrice;
        public Int64 Total;
        public Int64 ProductId;
        public int Id;
    }

    public class PurchaseDiscountController
    {
        public DateTime PurchaseDate;
        public string VoucherNo;
        public string SupplierName;
        public Int64 TotalAmount;
        public int DiscountAmount;  
    }


    public class RoleManagementController
    {
        //public RoleManagementModel OutstandingCustomer { get; set; }
        public RoleManagementModel Product { get; set; }
        public RoleManagementModel Brand { get; set; }
        public RoleManagementModel City { get; set; }
        public RoleManagementModel TaxRate { get; set; }
        public RoleManagementModel GiftCard { get; set; }
        public RoleManagementModel Customer { get; set; }
        public RoleManagementModel Supplier { get; set; }
        public RoleManagementModel Category { get; set; }
        public RoleManagementModel SubCategory { get; set; }
        public RoleManagementModel Counter { get; set; }
        public RoleManagementModel PurchaseRole { get; set; }
        public RoleManagementModel Expense { get; set; }
        public RoleManagementModel Doctor { get; set; }
        public RoleManagementModel Physio { get; set; }
        public RoleManagementModel OutstandingSupplier { get; set; }

        //Reports
        public RoleManagementModel TransactionReport { get; set; }
        public RoleManagementModel ItemSummaryReport { get; set; }
        public RoleManagementModel TaxSummaryReport { get; set; }
        public RoleManagementModel ReorderPointReport { get; set; }
        public RoleManagementModel TransactionDetailReport { get; set; }
        public RoleManagementModel OutstandingCustomerReport { get; set; }
        public RoleManagementModel TopBestSellerReport { get; set; }
        public RoleManagementModel TransactionSummaryReport { get; set; }

        public RoleManagementModel DailySaleSummary { get; set; }
        public RoleManagementModel DailyTotalTransactions { get; set; }
        public RoleManagementModel PurchaseReport { get; set; }
        public RoleManagementModel PurchaseDiscount { get; set; }
        public RoleManagementModel SaleBreakdown { get; set; }
        public RoleManagementModel CustomerSales { get; set; }
        public RoleManagementModel ProductReport { get; set; }
        public RoleManagementModel CustomerInformation { get; set; }
        public RoleManagementModel Consigment { get; set; }
        public RoleManagementModel ProfitAndLoss { get; set; }
        public RoleManagementModel DoctorPaymentReport { get; set; }
        public RoleManagementModel PhysioPaymentReport { get; set; }
       public RoleManagementModel NetIncomeReport { get; set; }

        private int UserRoleId { get; set; }

        public RoleManagementController()
        {
            Product = new RoleManagementModel();
            Brand = new RoleManagementModel();
            GiftCard = new RoleManagementModel();
            Customer = new RoleManagementModel();
            Supplier = new RoleManagementModel();
            Category = new RoleManagementModel();
            SubCategory = new RoleManagementModel();
            Counter = new RoleManagementModel();
            PurchaseRole = new RoleManagementModel();
            Expense = new RoleManagementModel();
            Doctor = new RoleManagementModel();
            Physio = new RoleManagementModel();
            OutstandingSupplier = new RoleManagementModel();

            DailySaleSummary = new RoleManagementModel();
            TransactionReport = new RoleManagementModel();
            TransactionSummaryReport = new RoleManagementModel();
            TransactionDetailReport = new RoleManagementModel();
            DailyTotalTransactions = new RoleManagementModel();
            PurchaseReport = new RoleManagementModel();
            PurchaseDiscount = new RoleManagementModel();
            ItemSummaryReport = new RoleManagementModel();
            SaleBreakdown = new RoleManagementModel();
            TaxSummaryReport = new RoleManagementModel();
            TopBestSellerReport = new RoleManagementModel();
            CustomerSales = new RoleManagementModel();
            OutstandingCustomerReport = new RoleManagementModel();
            CustomerInformation = new RoleManagementModel();
            ProductReport = new RoleManagementModel();
            ReorderPointReport = new RoleManagementModel();
            Consigment = new RoleManagementModel();
            ProfitAndLoss = new RoleManagementModel();
            DoctorPaymentReport = new RoleManagementModel();
            PhysioPaymentReport = new RoleManagementModel();
            NetIncomeReport = new RoleManagementModel(); 
        }




        public void Load(int roleId)
        {
            UserRoleId = roleId;


            POSEntities entity = new POSEntities();
            //Product
            Product.View = LoadRules(entity, "product_view");
            Product.EditOrDelete = LoadRules(entity, "product_edit");
            Product.Add = LoadRules(entity, "product_add");
            //Brand
            Brand.View = LoadRules(entity, "brand_view");
            Brand.EditOrDelete = LoadRules(entity, "brand_edit");
            Brand.Add = LoadRules(entity, "brand_add");
            //GiftCard
            GiftCard.View = LoadRules(entity, "giftcard_view");
            GiftCard.Add = LoadRules(entity, "giftcard_add");
            GiftCard.EditOrDelete = LoadRules(entity, "giftcard_edit");
            //Customer
            Customer.View = LoadRules(entity, "customer_view");
            Customer.EditOrDelete = LoadRules(entity, "customer_edit");
            Customer.Add = LoadRules(entity, "customer_add");
            //Supplier
            Supplier.View = LoadRules(entity, "supplier_view");
            Supplier.EditOrDelete = LoadRules(entity, "supplier_edit");
            Supplier.Add = LoadRules(entity, "supplier_add");
            Supplier.ViewDetail = LoadRules(entity, "supplier_viewDetail");
            OutstandingSupplier.View = LoadRules(entity, "outstandingsupplier_view");
            OutstandingSupplier.ViewDetail = LoadRules(entity, "outstandingsupplier_viewDetail");

            //Category
            Category.View = LoadRules(entity, "category_view");
            Category.EditOrDelete = LoadRules(entity, "category_edit");
            Category.Add = LoadRules(entity, "category_add");
            //Sub Category
            SubCategory.View = LoadRules(entity, "subcategory_view");
            SubCategory.EditOrDelete = LoadRules(entity, "subcategory_edit");
            SubCategory.Add = LoadRules(entity, "subcategory_add");
            //Counter
            Counter.EditOrDelete = LoadRules(entity, "counter_edit");
            Counter.Add = LoadRules(entity, "counter_add");
            //Purchase
            PurchaseRole.EditOrDelete = LoadRules(entity, "purchase_delete");
            PurchaseRole.Add = LoadRules(entity, "purchase_add");
            PurchaseRole.ViewDetail = LoadRules(entity, "purchase_viewDetail");
            PurchaseRole.View = LoadRules(entity, "purchase_view");
            PurchaseRole.DeleteLog = LoadRules(entity, "purchase_deletelog");
            PurchaseRole.Approved = LoadRules(entity, "purchase_approved");

            //Expense
            Expense.EditOrDelete = LoadRules(entity, "expense_delete");
            Expense.Add = LoadRules(entity, "expense_add");
            Expense.ViewDetail = LoadRules(entity, "expense_viewDetail");
            Expense.View = LoadRules(entity, "expense_view");
            Expense.DeleteLog = LoadRules(entity, "expense_deletelog");
            Expense.Approved = LoadRules(entity, "expense_approved");

            //Doctor
            Doctor.EditOrDelete = LoadRules(entity, "doctor_edit");
            Doctor.Add = LoadRules(entity, "doctor_add");
            Doctor.ViewDetail = LoadRules(entity, "doctor_viewDetail");
            Doctor.View = LoadRules(entity, "doctor_view");
            Doctor.Payment = LoadRules(entity, "doctor_payment");
            Doctor.Print = LoadRules(entity, "doctor_print");

            //Physio
            Physio.EditOrDelete = LoadRules(entity, "Physio_edit");
            Physio.Add = LoadRules(entity, "Physio_add");
            Physio.AddGroup = LoadRules(entity, "Physio_addGroup");
            Physio.ViewDetail = LoadRules(entity, "Physio_viewDetail");
            Physio.View = LoadRules(entity, "Physio_view");

            //Reports
           // DailySaleSummary.View = LoadRules(entity, "dailySaleSummary_view");
            TransactionReport.View = LoadRules(entity, "transactionReport_view");
            TransactionSummaryReport.View = LoadRules(entity, "transactionSummary_view");
            TransactionDetailReport.View = LoadRules(entity, "transactionDetailReport_view");
            //DailyTotalTransactions.View = LoadRules(entity, "dailyTotalTransactions_view");
            PurchaseReport.View = LoadRules(entity, "purchaseReport_view");
            PurchaseDiscount.View = LoadRules(entity, "purchaseDiscount_view");
            ItemSummaryReport.View = LoadRules(entity, "itemSummaryReport_view");
            SaleBreakdown.View = LoadRules(entity, "saleBreakdown_view");
            TaxSummaryReport.View = LoadRules(entity, "taxSummaryReport_view");
            TopBestSellerReport.View = LoadRules(entity, "topBestSellerReport_view");
            CustomerSales.View = LoadRules(entity, "customerSales_view");
            OutstandingCustomerReport.View = LoadRules(entity, "outstandingCustomerReport_view");
            CustomerInformation.View = LoadRules(entity, "customerInformation_view");
            ProductReport.View = LoadRules(entity, "productReport_view");
            ReorderPointReport.View = LoadRules(entity, "reorderPointReport_view");
            Consigment.View = LoadRules(entity, "consigment_view");
            ProfitAndLoss.View = LoadRules(entity, "ProfitAndLoss_view");
            DoctorPaymentReport.View = LoadRules(entity, "doctorPaymentReport_view");
            PhysioPaymentReport.View = LoadRules(entity, "physioPaymentReport_view");
            NetIncomeReport.View = LoadRules(entity, "netIncomeReport_view");

        }

        public void Save(int roleId)
        {
            UserRoleId = roleId;
            POSEntities entity = new POSEntities();

            //Delete old entry for this userroldId firstly
            List<APP_Data.RoleManagement> RulesListById = entity.RoleManagements.Where(x => x.UserRoleId == UserRoleId).ToList();
            foreach (APP_Data.RoleManagement rule in RulesListById)
            {
                entity.RoleManagements.Remove(rule);
            }

            //Product
            CreateRules(entity, Product.View, "product_view");
            CreateRules(entity, Product.EditOrDelete, "product_edit");
            CreateRules(entity, Product.Add, "product_add");
            //Brand
            CreateRules(entity, Brand.View, "brand_view");
            CreateRules(entity, Brand.EditOrDelete, "brand_edit");
            CreateRules(entity, Brand.Add, "brand_add");
            //GiftCard
            CreateRules(entity, GiftCard.View, "giftcard_view");
            CreateRules(entity, GiftCard.Add, "giftcard_add");
            CreateRules(entity, GiftCard.EditOrDelete, "giftcard_edit");
            //Customer
            CreateRules(entity, Customer.View, "customer_view");
            CreateRules(entity, Customer.EditOrDelete, "customer_edit");
            CreateRules(entity, Customer.Add, "customer_add");
            //Supplier
            CreateRules(entity, Supplier.View, "supplier_view");
            CreateRules(entity, Supplier.EditOrDelete, "supplier_edit");
            CreateRules(entity, Supplier.Add, "supplier_add");
            CreateRules(entity, Supplier.ViewDetail, "supplier_viewDetail");
            CreateRules(entity, OutstandingSupplier.View, "outstandingsupplier_view");
            CreateRules(entity, OutstandingSupplier.ViewDetail, "outstandingsupplier_viewDetail");
            
            //Category
            CreateRules(entity, Category.View, "category_view");
            CreateRules(entity, Category.EditOrDelete, "category_edit");
            CreateRules(entity, Category.Add, "category_add");
            //Sub Category
            CreateRules(entity, SubCategory.View, "subcategory_view");
            CreateRules(entity, SubCategory.EditOrDelete, "subcategory_edit");
            CreateRules(entity, SubCategory.Add, "subcategory_add");
            //Counter
            CreateRules(entity, Counter.EditOrDelete, "counter_edit");
            CreateRules(entity, Counter.Add, "counter_add");
            //Purchase
            CreateRules(entity, PurchaseRole.EditOrDelete, "purchase_delete");
            CreateRules(entity, PurchaseRole.Add, "purchase_add");
            CreateRules(entity, PurchaseRole.ViewDetail, "purchase_viewDetail");
            CreateRules(entity, PurchaseRole.View, "purchase_view");
            CreateRules(entity, PurchaseRole.DeleteLog, "purchase_deletelog");
            CreateRules(entity, PurchaseRole.Approved, "purchase_approved");

            //Expense
            CreateRules(entity, Expense.EditOrDelete, "expense_delete");
            CreateRules(entity, Expense.Add, "expense_add");
            CreateRules(entity, Expense.ViewDetail, "expense_viewDetail");
            CreateRules(entity, Expense.View, "expense_view");
            CreateRules(entity, Expense.DeleteLog, "expense_deletelog");
            CreateRules(entity, Expense.Approved, "expense_approved");

            //Doctor
            CreateRules(entity, Doctor.EditOrDelete, "doctor_edit");
            CreateRules(entity, Doctor.Add, "doctor_add");
            CreateRules(entity, Doctor.ViewDetail, "doctor_viewDetail");
            CreateRules(entity, Doctor.View, "doctor_view");
            CreateRules(entity, Doctor.Payment, "doctor_payment");
            CreateRules(entity, Doctor.Print, "doctor_print");

            //Physio
            CreateRules(entity, Physio.EditOrDelete, "Physio_edit");
            CreateRules(entity, Physio.Add, "Physio_add");
            CreateRules(entity, Physio.ViewDetail, "Physio_viewDetail");
            CreateRules(entity, Physio.View, "Physio_view");
            CreateRules(entity, Physio.AddGroup, "Physio_addGroup");

            //Reports

            CreateRules(entity, DailySaleSummary.View, "dailySaleSummary_view");
            CreateRules(entity, TransactionReport.View, "transactionReport_view");
            CreateRules(entity, TransactionSummaryReport.View, "transactionSummary_view");
            CreateRules(entity, TransactionDetailReport.View, "transactionDetailReport_view");
            CreateRules(entity, DailyTotalTransactions.View, "dailyTotalTransactions_view");
            CreateRules(entity, PurchaseReport.View, "purchaseReport_view");
            CreateRules(entity, PurchaseDiscount.View, "purchaseDiscount_view");
            CreateRules(entity, ItemSummaryReport.View, "itemSummaryReport_view");
            CreateRules(entity, SaleBreakdown.View, "saleBreakdown_view");
            CreateRules(entity, TaxSummaryReport.View, "taxSummaryReport_view");
            CreateRules(entity, TopBestSellerReport.View, "topBestSellerReport_view");
            CreateRules(entity, CustomerSales.View, "customerSales_view");
            CreateRules(entity, OutstandingCustomerReport.View, "outstandingCustomerReport_view");
            CreateRules(entity, CustomerInformation.View, "customerInformation_view");
            CreateRules(entity, ProductReport.View, "productReport_view");
            CreateRules(entity, ReorderPointReport.View, "reorderPointReport_view");
            CreateRules(entity, Consigment.View, "consigment_view");
            CreateRules(entity, ProfitAndLoss.View, "ProfitAndLoss_view");
            CreateRules(entity, DoctorPaymentReport.View, "doctorPaymentReport_view");
            CreateRules(entity, PhysioPaymentReport.View, "physioPaymentReport_view");
            CreateRules(entity, NetIncomeReport.View, "netIncomeReport_view");

        }

        private void CreateRules(POSEntities entity, Boolean IsAllowed, String Rule)
        {
            APP_Data.RoleManagement obj = new APP_Data.RoleManagement();
            obj.UserRoleId = UserRoleId;
            obj.IsAllowed = IsAllowed;
            obj.RuleFeature = Rule;
            entity.RoleManagements.Add(obj);
            entity.SaveChanges();
        }

        private Boolean LoadRules(POSEntities entity, String Rule)
        {
            APP_Data.RoleManagement obj = entity.RoleManagements.Where(x => x.RuleFeature == Rule && x.UserRoleId == UserRoleId).FirstOrDefault();
            Boolean result = false;
            if (obj != null) result = obj.IsAllowed;

            return result;
        }
    }

    public class RoleManagementModel
    {
        public Boolean View { get; set; }
        public Boolean EditOrDelete { get; set; }
        public Boolean Add { get; set; }
        public Boolean ViewDetail { get; set; }
        public Boolean Payment { get; set; }
        public Boolean AddGroup { get; set; }
        public Boolean Print { get; set; }
        public Boolean DeleteLog { get; set; }
        public Boolean Approved { get; set; }

    }

    public static class SettingController
    {
        public static int getidwithassign
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_top_sale_row");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }

                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_top_sale_row");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_top_sale_row";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
        public static string AMShiftAssign
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "amshift_assign");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "amshift_assign");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "amshift_assign";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
        public static string PMShiftAssign
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "pmshift_assign");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "pmshift_assign");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "pmshift_assign";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
        public static string ShopName
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "shop_name");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "shop_name");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "shop_name";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();                    
                }
                entity.SaveChanges();
            }
        }

        public static string BranchName
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "branch_name");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "branch_name");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "branch_name";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string PhoneNo
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "phone_number");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "phone_number");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "phone_number";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string OpeningHours
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "opening_hours");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "opening_hours");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "opening_hours";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string DefaultTaxRate
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_tax_rate");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_tax_rate");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_tax_rate";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static int DefaultTopSaleRow
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_top_sale_row");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }

                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_top_sale_row");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_top_sale_row";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
        public static int DefaultCity
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_city_id");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }
                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_city_id");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_city_id";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
        
        public static int DefaultServiceCharges
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_service_charges");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }

                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_service_charges");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_service_charges";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static int DefaultPhysioPercent
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_Physio_Percent");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }

                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_Physio_Percent");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_Physio_Percent";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
       

    }

    public static class DatabaseControlSetting
    {
        public static string _ServerName
        {
            get
            {                
                return System.Configuration.ConfigurationManager.AppSettings["_ServerName"];
            }
        }
        /// <summary>
        /// Get or Set the Database's Name
        /// </summary>
        public static string _DBName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_DBName"];
            }
        }
        /// <summary>
        /// Get or Set the Database's Login User
        /// </summary>
        public static string _DBUser
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_DBUser"];
            }
        }
        /// <summary>
        /// Get or Set the Database's Login Password
        /// </summary>
        public static string _DBPassword
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_DBPassword"];
            }
        }

    }


    public class RestoreHelper
    {
        public RestoreHelper()
        {

        }

        public void RestoreDatabase(String databaseName, String backUpFile, String serverName, String userName, String password)
        {
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);
            string dbaddr = string.Empty;
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                dbaddr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            }

            SqlConnection conn = new SqlConnection(dbaddr);
            string s = conn.State.ToString();
            conn.Close();
            SqlConnection.ClearPool(conn);
            Restore rstDatabase = new Restore();
            rstDatabase.Action = RestoreActionType.Database;
            rstDatabase.Database = databaseName;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
            rstDatabase.Devices.Add(bkpDevice);
            rstDatabase.ReplaceDatabase = true;
            rstDatabase.Complete += new ServerMessageEventHandler(sqlRestore_Complete);
            rstDatabase.PercentCompleteNotification = 10;
            rstDatabase.PercentComplete += new PercentCompleteEventHandler(sqlRestore_PercentComplete);
            rstDatabase.SqlRestore(sqlServer);
            sqlServer.Refresh();
        }

        public event EventHandler<PercentCompleteEventArgs> PercentComplete;

        void sqlRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (PercentComplete != null)
                PercentComplete(sender, e);
        }

        public event EventHandler<ServerMessageEventArgs> Complete;

        void sqlRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (Complete != null)
                Complete(sender, e);
        }
    }

    public class BackupHelper
    {
        public BackupHelper()
        {

        }

        public void BackupDatabase(String databaseName, String userName, String password, String serverName, String destinationPath, ref bool isBackUp)
        {
            Backup sqlBackup = new Backup();

            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString();
            sqlBackup.BackupSetName = "Archive";

            sqlBackup.Database = databaseName;

            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);

            Database db = sqlServer.Databases[databaseName];

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);
            sqlBackup.Incremental = false;

            sqlBackup.ExpirationDate = DateTime.Now.AddDays(30);
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;
            try
            {
                sqlBackup.SqlBackup(sqlServer);
                isBackUp = true;
            }
            catch
            {
                MessageBox.Show("Please check the database if it's properly installed.");
            }
        }
    }

    #region PrintFunctions

    public static class PrintDoc
    {
        private static Boolean isStickerSize = false;
        private static Boolean isSlipSize = false;
        private static IList<Stream> m_streams;
        private static int m_currentPageIndex;

        #region Printing Functions

        private static void Print()
        {
            try
            {
                if (m_streams == null || m_streams.Count == 0)
                    return;

                PrintDocument printDoc = new PrintDocument();

                if (isStickerSize)
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.BarcodePrinter;
                else if (isSlipSize)
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.SlipPrinter;
                else
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.A4Printer;

                if (!printDoc.PrinterSettings.IsValid)
                {
                    string msg = String.Format("Can't find printer \"{0}\".", DefaultPrinter.A4Printer);
                    System.Diagnostics.Debug.WriteLine(msg);
                    return;
                }
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                printDoc.Print();

                printDoc.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void PrintReport(ReportViewer rv)
        {
            isStickerSize = false;
            m_currentPageIndex = 0;
            m_streams = null;
            Export(rv.LocalReport);
            Print();
            //  Dispose();
            rv.LocalReport.ReleaseSandboxAppDomain();
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="Type">BarcodeStricker||Slip </param>
        public static void PrintReport(ReportViewer rv, String Type)
        {
            m_currentPageIndex = 0;
            m_streams = null;
            if (Type == "BarcodeSTicker")
            {
                isStickerSize = true;
            }
            else
            {
                isSlipSize = true;
            }

            Export(rv.LocalReport);

            Print();

            //  Dispose();
            rv.LocalReport.ReleaseSandboxAppDomain();
        }

        // Export the given report as an EMF (Enhanced Metafile) file.
        private static void Export(LocalReport report)
        {
            string deviceInfo = string.Empty;
            if (isStickerSize)
            {
                deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3in</PageWidth>                
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
                </DeviceInfo>";
            }
            else if (isSlipSize)
            {
                deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3in</PageWidth>                
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            }
            else
            {
                deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8in</PageWidth>
                <PageHeight>10.5in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            }
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //ev.Graphics.DrawImage(pageImage, 0, 0);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        #endregion
    }

    public static class ExportReport
    {
        public static void Excel(ReportViewer rv, String FileName)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = rv.LocalReport.Render(
               "Excel", null, out mimeType, out encoding,
                out extension,
               out streamids, out warnings);
            try
            {
                FileStream fs = new FileStream(@"D:\Reports\" + FileName + DateTime.Now.ToString("ddMMyyyy") + ".xls", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                MessageBox.Show(@"Report file is saved in D\Reports\" + FileName + DateTime.Now.ToString("ddMMyyyy") + ".xls", "Saving Complete");
            }
            catch (DirectoryNotFoundException message)
            {
                MessageBox.Show(@"The file patch (D:\Reports) isn't exist. Please check and create Reports folder in the Drive D", "Error");
            }
        }
    }

    public static class DefaultPrinter
    {
        public static string BarcodePrinter
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "barcode_printer");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "barcode_printer");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "barcode_printer";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string A4Printer
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "a4_printer";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string SlipPrinter
        {
            get
            {
                POSEntities entity = new POSEntities();
                string key = "slip_printer_counter" + MemberShip.CounterId.ToString();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == key );
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                string key = "slip_printer_counter" + MemberShip.CounterId.ToString();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == key);
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = key;
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }        
    }

    #endregion


}
