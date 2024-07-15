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
using System.Text.RegularExpressions;

namespace POS
{
    public partial class NewProduct : Form
    {
        #region Variables

        public Boolean isEdit { get; set; }

        public int ProductId { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        List<Product> productList = new List<Product>();

        List<WrapperItem> wrapperList = new List<WrapperItem>();

        Product currentProduct;

        #endregion

        #region Event

        public NewProduct()
        {
            InitializeComponent();
        }

        private void NewProduct_Load(object sender, EventArgs e)
        {
            //txtName.Focus();
            this.ActiveControl = txtName;
           // txtBarcode.ReadOnly = true;
          //  txtProductCode.ReadOnly = true;
            dgvChildItems.AutoGenerateColumns = false;
           // chkSpecialPromotion.Enabled = false;
         //   txtName.Focused = true;
        
           


            List<APP_Data.Brand> BrandList = new List<APP_Data.Brand>();
            APP_Data.Brand brandObj1 = new APP_Data.Brand();
            brandObj1.Id = 0;
            brandObj1.Name = "Select";
            //APP_Data.Brand brandObj2 = new APP_Data.Brand();
            //brandObj2.Id = 1;
            //brandObj2.Name = "None";
            BrandList.Add(brandObj1);
          //  BrandList.Add(brandObj2);
            //BrandList.Add(brandObj2);
            BrandList.AddRange((from bList in entity.Brands select bList).ToList());
            cboBrand.DataSource = BrandList;
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems; 

            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            pSubCatList.Add(SubCategoryObj1);
            APP_Data.ProductSubCategory SubCategoryObj2 = new APP_Data.ProductSubCategory();
            SubCategoryObj2.Id = 1;
            SubCategoryObj2.Name = "None";
            //pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == Convert.ToInt32(cboMainCategory.SelectedValue) select c).ToList());
            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";

            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";
            //APP_Data.ProductCategory MainCategoryObj2 = new APP_Data.ProductCategory();
            //MainCategoryObj2.Id = 1;
            //MainCategoryObj2.Name = "None";
            pMainCatList.Add(MainCategoryObj1);
            //pMainCatList.Add(MainCategoryObj2);
            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<Product> productList1 = new List<Product>();
            
            Product productObj = new Product();
            productObj.Name = "Select";
            productObj.Id = 0;
            productList1.Add(productObj);
            productList1.AddRange((from pList in entity.Products select pList).ToList());
            cboProductList.DataSource = productList1;
            cboProductList.DisplayMember = "Name";
            cboProductList.ValueMember = "Id";
            cboProductList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductList.AutoCompleteSource = AutoCompleteSource.ListItems;            

            List<Unit> unitList = new List<Unit>();
            Unit unitObj = new Unit();
            unitObj.Id = 0;
            unitObj.UnitName = "Select";
            unitList.Add(unitObj);
            unitList.AddRange((from u in entity.Units select u).ToList());
            cboUnit.DataSource = unitList;
            cboUnit.DisplayMember = "UnitName";
            cboUnit.ValueMember = "Id";
            cboUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUnit.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<ConsignmentCounter> consignmentCounterList = new List<ConsignmentCounter>();
            ConsignmentCounter consignmentObj = new ConsignmentCounter();
            consignmentObj.Id = 0;
            consignmentObj.Name = "Select";
            consignmentCounterList.Add(consignmentObj);
            consignmentCounterList.AddRange((from c in entity.ConsignmentCounters select c).ToList());
            cboConsignmentCounter.DataSource = consignmentCounterList;
            cboConsignmentCounter.DisplayMember = "Name";
            cboConsignmentCounter.ValueMember = "Id";
            cboConsignmentCounter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboConsignmentCounter.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<Tax> taxList = entity.Taxes.ToList();
            List<Tax> result = new List<Tax>();
            foreach (Tax r in taxList)
            {
                Tax t = new Tax();
                t.Id = r.Id;
                t.Name = r.Name + " and " + r.TaxPercent + "%";
                t.TaxPercent = r.TaxPercent;
                result.Add(t);
            }
            cboTaxList.DataSource = result;
            cboTaxList.DisplayMember = "Name";
            cboTaxList.ValueMember = "Id";
            if (SettingController.DefaultTaxRate != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultTaxRate);
                Tax defaultTax = (from t in entity.Taxes where t.Id == id select t).FirstOrDefault();
                cboTaxList.Text = defaultTax.Name + " and " + defaultTax.TaxPercent + "%";
            }

            wrapperList.Clear();
            productList.Clear();
            if (isEdit)
            {
           
                //Editing here
                currentProduct = (from p in entity.Products where p.Id == ProductId select p).FirstOrDefault();

                ChargesForDoctorAndTechnician(currentProduct.ProductCategory.Name);
                txtName.Text = currentProduct.Name;
                
                txtUnitPrice.Text = currentProduct.Price.ToString();
                if (currentProduct.Brand != null)
                {
                    cboBrand.Text = currentProduct.Brand.Name;
                }
                else
                {
                    cboBrand.Text = "None";
                }
                if (currentProduct.ProductCategory != null)
                {
                    cboMainCategory.Text = currentProduct.ProductCategory.Name;
                    if (currentProduct.ProductCategory.Name == "Injection")
                    {
                        txtPaymentforDoctor.Text = currentProduct.ChargesforDoctor.ToString();
                    }
                    else if (currentProduct.ProductCategory.Name == "X-Ray")
                    {
                        txtPaymentforDoctor.Text = currentProduct.ChargesforDoctor.ToString();
                    }
                    else if (currentProduct.ProductCategory.Name == "PT")
                    {
                        txtPaymentforDoctor.Text = currentProduct.ChargesforDoctor.ToString();
                    }
                    if (currentProduct.ProductSubCategory != null)
                    {
                        cboSubCategory.Text = currentProduct.ProductSubCategory.Name;                        
                    }
                    else
                    {
                        cboSubCategory.Text = "None";                        
                    }
                    cboSubCategory.Enabled = true;
                }
                else
                {
                    cboMainCategory.Text = "Select";
                    cboSubCategory.Enabled = false;
                }
                cboTaxList.Text = currentProduct.Tax.Name + " and " + currentProduct.Tax.TaxPercent + "%";
                txtDiscount.Text = currentProduct.DiscountRate.ToString();
                
                cboUnit.Text = currentProduct.Unit.UnitName;
                txtLocation.Text = currentProduct.ProductLocation;
                chkMinStock.Checked = currentProduct.IsNotifyMinStock.Value;
                if (chkMinStock.Checked)
                {
                    txtQty.Text = currentProduct.Qty.ToString();
                    txtMinStockQty.Text = currentProduct.MinStockQty.ToString();
                    txtMinStockQty.Enabled = true;
                }
                else
                {
                    txtQty.Text = currentProduct.Qty.ToString();
                }
                txtPurchasePrice.Text = currentProduct.PurchasePrice.ToString();
                txtSize.Text = currentProduct.Size;
                chkIsWrapper.Checked = currentProduct.IsWrapper.Value;                
                if (chkIsWrapper.Checked)
                {
                    chkIsWrapper.Enabled = false;
                    if (currentProduct.Brand.Name == "Special Promotion")
                    {

                        txtUnitPrice.ReadOnly = true;
                        txtUnitPrice.Text = currentProduct.Price.ToString();
                        chkSpecialPromotion.Checked = true;
                    }



                    wrapperList.AddRange(currentProduct.WrapperItems.ToList());
                    foreach (WrapperItem w in wrapperList)
                    {
                        productList.Add((from p in entity.Products where p.Id == w.ChildProductId  select p).FirstOrDefault());
                    }
                    cboProductList.Enabled = true;
                    btnAddItem.Enabled = true;
                    dgvChildItems.DataSource = productList;

                }
                chkIsConsignment.Checked = currentProduct.IsConsignment.Value;
                if (chkIsConsignment.Checked)
                {
                    cboConsignmentCounter.Text = currentProduct.ConsignmentCounter.Name;
                    txtConsignmentPrice.Text = currentProduct.ConsignmentPrice.ToString();
                    cboConsignmentCounter.Enabled = true;
                    txtConsignmentPrice.Enabled = true;
                }
                else
                {
                    cboConsignmentCounter.Enabled = false;
                    txtConsignmentPrice.Enabled = false;
                }
                btnSubmit.Image = POS.Properties.Resources.update_big;
                cboMainCategory.Enabled = false;
                cboSubCategory.Enabled = false;
                btnNewCategory.Enabled = false;
                btnNewSubCategofry.Enabled = false;

                txtBarcode.Text = currentProduct.Barcode;
                txtProductCode.Text = currentProduct.ProductCode;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           Boolean hasError = false;
           POSEntities newEntity = new POSEntities();//anm
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            //Validation
            if (txtBarcode.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtBarcode, "Error");
                tp.Show("Please fill up barcode!", txtBarcode);
                hasError = true;
            }
            else if (txtProductCode.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtProductCode, "Error");
                tp.Show("Please fill up product code!", txtProductCode);
                hasError = true;
            }
            else if (txtName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtName, "Error");
                tp.Show("Please fill up product name!", txtName);
                hasError = true;
            }
            else if (cboBrand.SelectedIndex == 0)
            {
                tp.SetToolTip(cboBrand, "Error");
                tp.Show("Please select brand name!", cboBrand);
                hasError = true;
            }
            else if (txtUnitPrice.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtUnitPrice, "Error");
                tp.Show("Please fill up product price!", txtUnitPrice);
                hasError = true;
            }
            else if (txtQty.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtQty, "Error");
                tp.Show("Please fill up product quantity!", txtQty);
                hasError = true;
            }
            else if (cboMainCategory.SelectedIndex == 0)
            {
                tp.SetToolTip(cboMainCategory, "Error");
                tp.Show("Please select main category name!", cboMainCategory);
                hasError = true;
            }
            else if (cboMainCategory.SelectedIndex > 0 && cboSubCategory.SelectedIndex == 0)
            {
                tp.SetToolTip(cboSubCategory, "Error");
                tp.Show("Please select sub category name!", cboSubCategory);
                hasError = true;
            }
            else if (txtDiscount.Text.Trim() != string.Empty && Convert.ToDouble(txtDiscount.Text) >100.00 )
            {
                tp.SetToolTip(txtDiscount, "Error");
                tp.Show("Discount percent must not over 100!", txtDiscount);
                hasError = true;
            }
            //else if (txtMinStockQty.Text.Trim() == string.Empty)
            //{
            //    txtMinStockQty.Text = "0";
            //}
            else if (cboUnit.SelectedIndex == 0)
            {
                tp.SetToolTip(cboUnit, "Error");
                tp.Show("Please select unit!", cboUnit);
                hasError = true;
            }
            else if (chkIsWrapper.Checked == true && productList.Count == 0)
            {
                tp.SetToolTip(cboProductList, "Error");
                tp.Show("Please select wrapper product item!", cboProductList);
                hasError = true;
            }
            else if (chkIsConsignment.Checked == true && cboConsignmentCounter.SelectedIndex == 0)
            {
                tp.SetToolTip(cboConsignmentCounter, "Error");
                tp.Show("Please select consignment counter name!", cboConsignmentCounter);
                hasError = true;
            }
            else if (cboMainCategory.Text == "Injection" && txtPaymentforDoctor.Text.Trim() == "")
            {
                tp.SetToolTip(txtPaymentforDoctor, "Error");
                tp.Show("Please fill up paymentfordoctor!", txtPaymentforDoctor);
                hasError = true;
            }
            else if (cboMainCategory.Text == "X Ray" && txtPaymentforDoctor.Text.Trim() == "")
            {
                tp.SetToolTip(txtPaymentforDoctor, "Error");
                tp.Show("Please fill up paymentfordoctor!", txtPaymentforDoctor);
                hasError = true;
            }
            else if (cboMainCategory.Text == "Physio Train" && txtPaymentforDoctor.Text.Trim() == "")
            {
                tp.SetToolTip(txtPaymentforDoctor, "Error");
                tp.Show("Please fill up paymentfordoctor!", txtPaymentforDoctor);
                hasError = true;
            }
            if (!hasError)
            {
                //Edit product
                if (isEdit)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        
                        APP_Data.Product editProductObj = (from p in newEntity.Products where p.Id == ProductId select p).FirstOrDefault();
                        
                        int oldPrice = Convert.ToInt32(editProductObj.Price); int currentPrice = 0; int differentPrice = 0;
                        int ProductCodeCount = 0, BarcodeCount = 0,ProductNameCount=0;
                        //count = (from p in entity.Products where p.Name == txtName.Text select p).ToList().Count;
                        if (txtProductCode.Text.Trim() != editProductObj.ProductCode.Trim())
                        {
                            ProductCodeCount = (from p in newEntity.Products where p.ProductCode.Trim() == txtProductCode.Text.Trim() select p).ToList().Count;
                        }
                        if (txtBarcode.Text.Trim() != editProductObj.Barcode.Trim())
                        {
                            BarcodeCount = (from p in newEntity.Products where p.Barcode.Trim() == txtBarcode.Text.Trim() select p).ToList().Count;
                        }

                        if (txtName.Text.Trim() != editProductObj.Name.Trim())
                        {
                            ProductNameCount = (from p in newEntity.Products where p.Name.Trim() == txtName.Text.Trim() select p).ToList().Count;
                        }

                        if (ProductNameCount > 0)
                        {
                            tp.SetToolTip(txtName, "Error");
                            tp.Show("Product Name is already exist!", txtName);
                            return;
                        }

                        if (ProductCodeCount == 0 && BarcodeCount == 0)
                        {

                            editProductObj.Barcode = txtBarcode.Text.Trim();
                            editProductObj.ProductCode = txtProductCode.Text.Trim();
                            editProductObj.Name = txtName.Text.Trim();
                            //if (cboBrand.SelectedIndex == 1)
                            //{
                            //    editProductObj.BrandId = null;
                            //}
                            //else
                            //{
                            //    editProductObj.BrandId = Convert.ToInt32(cboBrand.SelectedValue.ToString());
                            //}
                            editProductObj.BrandId = Convert.ToInt32(cboBrand.SelectedValue.ToString());
                            if (editProductObj.BrandId == 0)
                            {
                                editProductObj.BrandId = null;
                            }

                            int paymentfordoc = txtPaymentforDoctor.Text.Trim() != "" ? Convert.ToInt32(txtPaymentforDoctor.Text.Trim()) : 0;
                            editProductObj.ChargesforDoctor = paymentfordoc;
                            txtUnitPrice.Text = txtUnitPrice.Text.Trim().Replace(",", "");
                            txtQty.Text = txtQty.Text.Trim().Replace(",", "");
                            txtMinStockQty.Text = txtMinStockQty.Text.Trim().Replace(",", "");

                            editProductObj.Price = Convert.ToInt32(txtUnitPrice.Text);
                            //get price different
                            currentPrice = Convert.ToInt32(txtUnitPrice.Text);
                            differentPrice = currentPrice - oldPrice;
                            editProductObj.Size = txtSize.Text;
                            if (txtPurchasePrice.Text.Trim() != string.Empty)
                            {
                                editProductObj.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                            }
                            
                            //if discount is null, add default value
                            editProductObj.TaxId = Convert.ToInt32(cboTaxList.SelectedValue);
                            if (txtDiscount.Text.Trim() == string.Empty)
                            {
                                editProductObj.DiscountRate = 0;
                            }
                            else
                            {
                                editProductObj.DiscountRate = Convert.ToDecimal(txtDiscount.Text);
                            }
                            editProductObj.IsNotifyMinStock = chkMinStock.Checked;
                            editProductObj.Qty = Convert.ToInt32(txtQty.Text);
                            //if minstock qty is null, add default value
                            if (txtMinStockQty.Text.Trim() == string.Empty)
                            {
                                editProductObj.MinStockQty = 0;
                            }
                            else
                            {
                                editProductObj.MinStockQty = Convert.ToInt32(txtMinStockQty.Text);
                            }
                            editProductObj.UnitId = Convert.ToInt32(cboUnit.SelectedValue);
                            
                            editProductObj.ProductCategoryId = Convert.ToInt32(cboMainCategory.SelectedValue);
                            if (cboSubCategory.SelectedIndex > 1)
                            {
                                editProductObj.ProductSubCategoryId = Convert.ToInt32(cboSubCategory.SelectedValue);
                            }
                            else if(cboSubCategory.SelectedIndex == 1)
                            {
                                editProductObj.ProductSubCategoryId = null;
                            }
                          
                            if (txtLocation.Text.Trim() == string.Empty)
                            {
                                editProductObj.ProductLocation = string.Empty;
                            }
                            else
                            {
                                editProductObj.ProductLocation = txtLocation.Text;
                            }
                            editProductObj.WrapperItems.Clear();
                            //Remove associated row for wrapperItems table       
                            //var wrapper = entity.WrapperItems.Where(d => d.ParentProductId == editProductObj.Id);
                            //foreach (var d in wrapper)
                            //{
                            //    entity.WrapperItems.Remove(d);
                            //}
                            editProductObj.IsWrapper = chkIsWrapper.Checked;
                            if (editProductObj.IsWrapper.Value)
                            {
                                foreach (WrapperItem wrapperObj in wrapperList)
                                {
                                    editProductObj.WrapperItems.Add(wrapperObj);
                                }
                            }
                            editProductObj.IsConsignment = chkIsConsignment.Checked;
                            if (editProductObj.IsConsignment.Value)
                            {
                                editProductObj.ConsignmentCounterId = Convert.ToInt32(cboConsignmentCounter.SelectedValue);
                                editProductObj.ConsignmentPrice = Convert.ToInt32(txtConsignmentPrice.Text);
                            }
                            else
                            {
                                editProductObj.ConsignmentCounterId = null;
                                editProductObj.ConsignmentPrice = null;
                            }
                            if (editProductObj.MinStockQty != null)
                            {
                                if (editProductObj.Qty >= editProductObj.MinStockQty || chkMinStock.Checked != false)
                                {
                                    newEntity.Entry(editProductObj).State = System.Data.EntityState.Modified;
                                    if (differentPrice != 0)
                                    {
                                        ProductPriceChange pc = new ProductPriceChange();
                                        pc.ProductId = editProductObj.Id;
                                        pc.OldPrice = oldPrice;
                                        pc.Price = editProductObj.Price;
                                        pc.UserID = MemberShip.UserId;
                                        pc.UpdateDate = DateTime.Now;
                                        newEntity.ProductPriceChanges.Add(pc);
                                    }
                                    newEntity.SaveChanges();
                                    MessageBox.Show("Successfully Updated!", "Update");

                                    if (System.Windows.Forms.Application.OpenForms["ItemList"] != null)
                                    {
                                        ItemList newForm = (ItemList)System.Windows.Forms.Application.OpenForms["ItemList"];
                                        newForm.DataBind();
                                    }
                                    if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                                    {
                                        Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                                        newForm.Clear();
                                    }

                                    if (System.Windows.Forms.Application.OpenForms["PurchaseInput"] != null)
                                    {
                                        PurchaseInput newForm = (PurchaseInput)System.Windows.Forms.Application.OpenForms["PurchaseInput"];
                                        newForm.Clear();
                                    }
                                    this.Dispose();
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Available quantity must be greater than minimum stock quantity!");
                                    newEntity.Dispose();
                                    return;
                                }
                            }
                        }
                        else if(BarcodeCount < 0)
                        {
                            tp.SetToolTip(txtBarcode, "Error");
                            tp.Show("This barcode is already exist!", txtBarcode);
                        }
                        else if(ProductCodeCount < 0)
                        {
                            tp.SetToolTip(txtProductCode, "Error");
                            tp.Show("This product code is already exist!", txtProductCode);
                        }
                    }
                }
                //add new product
                else
                {
                    int ProductCodeCount = 0, BarcodeCount = 0, ProductNameCount = 0; ;
                    //count = (from p in entity.Products where p.Name == txtName.Text select p).ToList().Count;
                    var proList = (from p in entity.Products select p).ToList();
                    ProductCodeCount=proList.Where(x => x.ProductCode.Trim() == txtProductCode.Text.Trim()).ToList().Count;
                   // ProductCodeCount = (from p in newEntity.Products where p.ProductCode.Trim() == txtProductCode.Text.Trim() select p).ToList().Count;
                    ProductNameCount  = proList.Where(x => x.Name.Trim() == txtName.Text.Trim()).ToList().Count;
                    BarcodeCount = (from p in newEntity.Products where p.Barcode.Trim() == txtBarcode.Text.Trim() select p).ToList().Count;

                    if (ProductNameCount > 0)
                    {

                        tp.SetToolTip(txtName, "Error");
                        tp.Show("Product Name is already exist!", txtName);
                        return;
                    }

                    if (ProductCodeCount == 0 && BarcodeCount == 0)
                    {
                        APP_Data.Product productObj = new APP_Data.Product();

                        productObj.Barcode = txtBarcode.Text.Trim();
                        productObj.ProductCode = txtProductCode.Text.Trim();

                        productObj.Name = txtName.Text.Trim();
                        //if (cboBrand.SelectedIndex == 1)
                        //{
                        //    productObj.BrandId = null;
                        //}
                        //else
                        //{
                        //    productObj.BrandId = Convert.ToInt32(cboBrand.SelectedValue.ToString());
                        //}
                        int paymentfordoc = txtPaymentforDoctor.Text.Trim() != "" ? Convert.ToInt32(txtPaymentforDoctor.Text.Trim()) : 0;
                        productObj.BrandId = Convert.ToInt32(cboBrand.SelectedValue.ToString());

                        if (productObj.BrandId == 0)
                        {
                            productObj.BrandId = null;
                        }
                        productObj.ChargesforDoctor = paymentfordoc;
                        txtUnitPrice.Text = txtUnitPrice.Text.Trim().Replace(",", "");
                        txtQty.Text = txtQty.Text.Trim().Replace(",", "");
                        txtMinStockQty.Text = txtMinStockQty.Text.Trim().Replace(",", "");

                        productObj.Price = Convert.ToInt32(txtUnitPrice.Text);
                       
                        productObj.TaxId = Convert.ToInt32(cboTaxList.SelectedValue);
                        //if discount is null, add default value
                        if (txtDiscount.Text.Trim() == string.Empty)
                        {
                            productObj.DiscountRate = 0;
                        }
                        else
                        {
                            productObj.DiscountRate = Convert.ToDecimal(txtDiscount.Text);
                        }
                        productObj.Size = txtSize.Text;
                        if (txtPurchasePrice.Text.Trim() != string.Empty)
                        {
                            productObj.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                        }
                        
                        productObj.IsNotifyMinStock = chkMinStock.Checked;
                        productObj.Qty = Convert.ToInt32(txtQty.Text);
                        //if minstock qty is null, add default value
                        if (txtMinStockQty.Text.Trim() == string.Empty)
                        {
                            productObj.MinStockQty = 0;
                        }
                        else
                        {
                            productObj.MinStockQty = Convert.ToInt32(txtMinStockQty.Text);
                        }
                        productObj.UnitId = Convert.ToInt32(cboUnit.SelectedValue);

                        if (txtLocation.Text.Trim() == string.Empty)
                        {
                            productObj.ProductLocation = string.Empty;
                        }
                        else
                        {
                            productObj.ProductLocation = txtLocation.Text;
                        }

                        
                        productObj.ProductCategoryId = Convert.ToInt32(cboMainCategory.SelectedValue);
                        if (cboSubCategory.SelectedIndex > 1)
                        {
                            productObj.ProductSubCategoryId = Convert.ToInt32(cboSubCategory.SelectedValue);
                        }
                        else if(cboSubCategory.SelectedIndex == 1)
                        {
                            productObj.ProductSubCategoryId = null;
                        }
                       

                        productObj.IsWrapper = chkIsWrapper.Checked;
                        if (productObj.IsWrapper.Value)
                        {
                            foreach (WrapperItem wrapperObj in wrapperList)
                            {
                                productObj.WrapperItems.Add(wrapperObj);
                            }
                        }

                        productObj.IsConsignment = chkIsConsignment.Checked;
                        if (productObj.IsConsignment.Value)
                        {
                            productObj.ConsignmentCounterId = Convert.ToInt32(cboConsignmentCounter.SelectedValue);
                            productObj.ConsignmentPrice = Convert.ToInt32(txtConsignmentPrice.Text);
                        }
                        else
                        {
                            productObj.ConsignmentCounterId = null;
                            productObj.ConsignmentPrice = null;
                        }
                        if (productObj.MinStockQty != null)
                        {
                            if (productObj.Qty > productObj.MinStockQty || chkMinStock.Checked == false)
                            {
                                entity.Products.Add(productObj);
                                entity.SaveChanges();

                                MessageBox.Show("Successfully Saved!", "Save");
                                
                                if (System.Windows.Forms.Application.OpenForms["ItemList"] != null)
                                {
                                    ItemList newForm = (ItemList)System.Windows.Forms.Application.OpenForms["ItemList"];
                                    newForm.DataBind();
                                }
                                if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                                {
                                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                                    newForm.Clear();
                                }
                                if (System.Windows.Forms.Application.OpenForms["PurchaseInput"] != null)
                                {
                                    PurchaseInput newForm = (PurchaseInput)System.Windows.Forms.Application.OpenForms["PurchaseInput"];
                                    newForm.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Available quantity must be greater than minimum stock quantity!");
                                newEntity.Dispose();
                                return;
                            }
                        }
                    }
                    else if(BarcodeCount > 0)
                    {
                        tp.SetToolTip(txtBarcode, "Error");
                        tp.Show("This barcode is already exist!", txtBarcode);
                    }
                    else if (ProductCodeCount > 0)
                    {
                        tp.SetToolTip(txtProductCode, "Error");
                        tp.Show("This product code is already exist!", txtProductCode);
                    }
                }

                List<Product> productList1 = new List<Product>();

                Product productObj1 = new Product();
                productObj1.Name = "Select";
                productObj1.Id = 0;
                productList1.Add(productObj1);
                productList1.AddRange((from pList in newEntity.Products select pList).ToList());
                cboProductList.DataSource = productList1;
                cboProductList.DisplayMember = "Name";
                cboProductList.ValueMember = "Id";
                cboProductList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboProductList.AutoCompleteSource = AutoCompleteSource.ListItems; 

                //Clear Data
                ClearInputs();
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Product pObj = new Product();
            bool isHave = false;
            int totalAmount = 0;

            int id = Convert.ToInt32(cboProductList.SelectedValue);
            if (id > 0)
            {
                foreach (Product p in productList)
                {
                    if (p.Id == id) isHave = true;//
                }
                if (!isHave)
                {
                    WrapperItem wrapperItemObj = new WrapperItem();
                    wrapperItemObj.ChildProductId = id;
                    wrapperList.Add(wrapperItemObj);
                    dgvChildItems.DataSource = "";
                    //dgvChildItems.DataSource = wrapperList;
                    pObj = (from p in entity.Products where p.Id == id select p).FirstOrDefault();
                    productList.Add(pObj);
                    dgvChildItems.DataSource = productList;
                    totalAmount += Convert.ToInt32(pObj.Price);
                    if (txtUnitPrice.Text == "")
                    {
                        txtUnitPrice.Text = "0";
                    }
                    if (chkSpecialPromotion.Checked == true)
                    {
                        txtUnitPrice.Text = (Convert.ToInt32(txtUnitPrice.Text) + totalAmount).ToString();
                    }
                }
                else
                {
                    //to show meassage for duplicate 
                    MessageBox.Show("This product is already include!");
                }
            }
            else
            {
                //to show message
            }
        }
        private void cboMainCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMainCategory.SelectedIndex > 0)
            {
                ChargesForDoctorAndTechnician(cboMainCategory.Text);

                int productCategoryId = Int32.Parse(cboMainCategory.SelectedValue.ToString());
                List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
                APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
                SubCategoryObj1.Id = 0;
                SubCategoryObj1.Name = "Select";
                APP_Data.ProductSubCategory SubCategoryObj2 = new APP_Data.ProductSubCategory();
                SubCategoryObj2.Id = 1;
                SubCategoryObj2.Name = "None";
                pSubCatList.Add(SubCategoryObj1);
                pSubCatList.Add(SubCategoryObj2);
                pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == productCategoryId select c).ToList());
                cboSubCategory.DataSource = pSubCatList;
                cboSubCategory.DisplayMember = "Name";
                cboSubCategory.ValueMember = "Id";
                cboSubCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboSubCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboSubCategory.Enabled = true;
            }
            else
            {
                cboSubCategory.SelectedIndex = 0;
                cboSubCategory.Enabled = false;
            }
        }
        private void dgvChildItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvChildItems.Rows[e.RowIndex];
                        string pdcode = row.Cells[0].Value.ToString();
                        APP_Data.Product p = entity.Products.Where(x => x.ProductCode == pdcode).FirstOrDefault();
                        if (txtUnitPrice.Text != "")
                        {
                            txtUnitPrice.Text = (Convert.ToInt32(txtUnitPrice.Text) - p.Price).ToString();
                        } 


                        dgvChildItems.DataSource = "";
                        wrapperList.RemoveAt(e.RowIndex);
                        productList.RemoveAt(e.RowIndex);
                        dgvChildItems.DataSource = productList;                      
                    }
                }
            }
        }

        private void chkIsWrapper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsWrapper.Checked)
            {
                cboProductList.Enabled = true;
                btnAddItem.Enabled = true;
                txtUnitPrice.Clear();
                txtUnitPrice.ReadOnly = false;
                chkSpecialPromotion.Enabled = true;
            }
            else
            {
                cboProductList.Enabled = false;
                btnAddItem.Enabled = false;
                productList.Clear();
                wrapperList.Clear();
                dgvChildItems.DataSource = "";
                txtUnitPrice.Clear();               
                chkSpecialPromotion.Enabled = false;
            }
        }

        private void chkIsConsignment_CheckedChanged(object sender, EventArgs e)          
        {
            if (chkIsConsignment.Checked)
            {
                cboConsignmentCounter.Enabled = true;
                txtConsignmentPrice.Enabled = true;
            }
            else
            {
                cboConsignmentCounter.Enabled = false;
                txtConsignmentPrice.Enabled = false;
                cboConsignmentCounter.SelectedIndex = 0;
                txtConsignmentPrice.Text = "";
            }
        }

        private void NewProduct_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtName);
            tp.Hide(txtQty);
            tp.Hide(txtUnitPrice);
            tp.Hide(cboBrand);
            tp.Hide(cboMainCategory);
            tp.Hide(cboProductList);
            tp.Hide(cboSubCategory);
            tp.Hide(cboUnit);
            tp.Hide(cboConsignmentCounter);
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtMinStockQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void chkMinStock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinStock.Checked)
            {
                txtMinStockQty.Enabled = true;
            }
            else
            {
                txtMinStockQty.Enabled = false;
                txtMinStockQty.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtLocation.Text = "";
            txtBarcode.Text = "";
            txtProductCode.Text = "";
            txtConsignmentPrice.Text = "";
            txtConsignmentPrice.Enabled = false;
            txtDiscount.Text = "";
            txtMinStockQty.Text = "";
            txtMinStockQty.Enabled = false;
            txtName.Text = "";
            txtPurchasePrice.Text = "";
            txtQty.Text = "";
            txtSize.Text = "";
            txtUnitPrice.Text = "";
            chkIsConsignment.Checked = false;
            chkIsWrapper.Checked = false;
            chkMinStock.Checked = false;
            cboBrand.SelectedIndex = 0;
            cboConsignmentCounter.SelectedIndex = 0;
            cboConsignmentCounter.Enabled = false;
            cboMainCategory.SelectedIndex = 0;
            cboSubCategory.SelectedIndex = 0;
            cboSubCategory.Enabled = false;
            cboTaxList.SelectedIndex = 0;
            cboUnit.SelectedIndex = 0;
            cboProductList.SelectedIndex = 0;
            cboProductList.Enabled = false;
            btnAddItem.Enabled = false;
            this.ActiveControl = txtName;
        }


        private void btnNewBrand_Click(object sender, EventArgs e)
        {
            Brand newForm = new Brand();
            newForm.ShowDialog();
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            ProductCategory newForm = new ProductCategory();
            newForm.ShowDialog();
        }

        private void btnNewSubCategofry_Click(object sender, EventArgs e)
        {
            ProductSubCategory newFrom = new ProductSubCategory();
            newFrom.ShowDialog();
        }

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            UnitForm newForm = new UnitForm();
            newForm.ShowDialog();

        }
        #endregion      

        #region Function
        public void ReloadConsignor()
        {
            entity = new POSEntities();
            List<ConsignmentCounter> consignmentCounterList = new List<ConsignmentCounter>();
            ConsignmentCounter consignmentObj = new ConsignmentCounter();
            consignmentObj.Id = 0;
            consignmentObj.Name = "Select";
            consignmentCounterList.Add(consignmentObj);
            consignmentCounterList.AddRange((from c in entity.ConsignmentCounters select c).ToList());
            cboConsignmentCounter.DataSource = consignmentCounterList;
            cboConsignmentCounter.DisplayMember = "Name";
            cboConsignmentCounter.ValueMember = "Id";
            cboConsignmentCounter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboConsignmentCounter.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void SetCurrentConsignor(Int32 ConsignorId)
        {

            ConsignmentCounter currentConsignor = entity.ConsignmentCounters.Where(x => x.Id == ConsignorId).FirstOrDefault();
            if (currentConsignor != null)
            {
                cboConsignmentCounter.SelectedValue = currentConsignor.Id;
            }
        }

        private void ClearInputs()
        {
            txtLocation.Text = "";
            txtBarcode.Text = "";
            txtProductCode.Text = "";
            txtConsignmentPrice.Text = "";
            txtConsignmentPrice.Enabled = false;
            txtDiscount.Text = "";
            txtMinStockQty.Text = "";
            txtMinStockQty.Enabled = false;
            txtName.Text = "";
            txtPurchasePrice.Text = "";
            txtQty.Text = "";
            txtSize.Text = "";
            txtUnitPrice.Text = "";
            txtPaymentforDoctor.Text = "";
            chkIsConsignment.Checked = false;
            chkIsWrapper.Checked = false;
            chkMinStock.Checked = false;
            cboBrand.SelectedIndex = 0;
            cboConsignmentCounter.SelectedIndex = 0;
            cboConsignmentCounter.Enabled = false;
            cboMainCategory.SelectedIndex = 0;
            cboSubCategory.SelectedIndex = 0;
            cboSubCategory.Enabled = false;
            cboTaxList.SelectedIndex = 0;
            cboUnit.SelectedIndex = 0;
            cboProductList.SelectedIndex = 0;
            cboProductList.Enabled = false;
            btnAddItem.Enabled = false;
            dgvChildItems.DataSource = "";
            lblPaymentForDT.Text = "Payment for Doctor ";
        }

        public void ReloadBrand()
        {
            entity = new POSEntities();
            List<APP_Data.Brand> BrandList = new List<APP_Data.Brand>();
            APP_Data.Brand brandObj1 = new APP_Data.Brand();
            brandObj1.Id = 0;
            brandObj1.Name = "Select";
            //APP_Data.Brand brandObj2 = new APP_Data.Brand();
            //brandObj2.Id = 1;
            //brandObj2.Name = "None";
            BrandList.Add(brandObj1);
            //BrandList.Add(brandObj2);
            BrandList.AddRange((from bList in entity.Brands select bList).ToList());
            cboBrand.DataSource = BrandList;
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (isEdit)
            {
                if (currentProduct.Brand != null)
                {
                    cboBrand.Text = currentProduct.Brand.Name;
                }
                //else
                //{
                //    cboBrand.Text = "None";
                //}
            }
        }
        public void ReloadCategory()
        {
            entity = new POSEntities();
            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            pSubCatList.Add(SubCategoryObj1);
            APP_Data.ProductSubCategory SubCategoryObj2 = new APP_Data.ProductSubCategory();
            SubCategoryObj2.Id = 1;
            SubCategoryObj2.Name = "None";
            //pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == Convert.ToInt32(cboMainCategory.SelectedValue) select c).ToList());
            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";

            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";
            //APP_Data.ProductCategory MainCategoryObj2 = new APP_Data.ProductCategory();
            //MainCategoryObj2.Id = 1;
            //MainCategoryObj2.Name = "None";
            pMainCatList.Add(MainCategoryObj1);
            //pMainCatList.Add(MainCategoryObj2);
            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (isEdit)
            {
                if (currentProduct.ProductCategory != null)
                {
                    cboMainCategory.Text = currentProduct.ProductCategory.Name;
                    if (currentProduct.ProductSubCategory != null)
                    {
                        cboSubCategory.Text = currentProduct.ProductSubCategory.Name;
                    }
                    else
                    {
                        cboSubCategory.Text = "None";
                    }
                    cboSubCategory.Enabled = true;
                }
                else
                {
                    cboMainCategory.Text = "Select";
                    cboSubCategory.Enabled = false;
                }
            }
        }
        public void ReloadSubCategory()
        {
            entity = new POSEntities();
            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            pSubCatList.Add(SubCategoryObj1);
            APP_Data.ProductSubCategory SubCategoryObj2 = new APP_Data.ProductSubCategory();
            SubCategoryObj2.Id = 1;
            SubCategoryObj2.Name = "None";
            //pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == Convert.ToInt32(cboMainCategory.SelectedValue) select c).ToList());
            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";

            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";
            //APP_Data.ProductCategory MainCategoryObj2 = new APP_Data.ProductCategory();
            //MainCategoryObj2.Id = 1;
            //MainCategoryObj2.Name = "None";
            pMainCatList.Add(MainCategoryObj1);
            //pMainCatList.Add(MainCategoryObj2);
            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (isEdit)
            {
                if (currentProduct.ProductCategory != null)
                {
                    cboMainCategory.Text = currentProduct.ProductCategory.Name;
                    if (currentProduct.ProductSubCategory != null)
                    {
                        cboSubCategory.Text = currentProduct.ProductSubCategory.Name;
                    }
                    else
                    {
                        cboSubCategory.Text = "None";
                    }
                    cboSubCategory.Enabled = true;
                }
                else
                {
                    cboMainCategory.Text = "Select";
                    cboSubCategory.Enabled = false;
                }
            }
        }
       
        public void ReloadUnit()
        {
            
            List<Unit> unitList = new List<Unit>();
            Unit unitObj = new Unit();
            unitObj.Id = 0;
            unitObj.UnitName = "Select";
            unitList.Add(unitObj);
            unitList.AddRange((from u in entity.Units select u).ToList());
            cboUnit.DataSource = unitList;
            cboUnit.DisplayMember = "UnitName";
            cboUnit.ValueMember = "Id";
            cboUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUnit.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (isEdit)
            {                
                
                cboUnit.Text = currentProduct.Unit.UnitName;
            }
        }


        public void SetCurrentBrand(Int32 BrandId)
        {
            APP_Data.Brand currentBrand = entity.Brands.Where(x => x.Id == BrandId).FirstOrDefault();
            if (currentBrand != null)
            {
                cboBrand.SelectedValue = currentBrand.Id;
            }
        }

        public void SetCurrentCategory(Int32 CategoryId)
        {
            APP_Data.ProductCategory currentCategory = entity.ProductCategories.Where(x => x.Id == CategoryId).FirstOrDefault();
            if (currentCategory != null)
            {
                cboMainCategory.SelectedValue = currentCategory.Id;
            }
        }

        public void SetCurrentSubCategory(Int32 SubCategoryId)
        {
            APP_Data.ProductSubCategory currentSubCategory = entity.ProductSubCategories.Where(x => x.Id == SubCategoryId).FirstOrDefault();
            if (currentSubCategory != null)
            {
                cboSubCategory.Text = currentSubCategory.Name;
            }
        }
        #endregion

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkSpecialPromotion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialPromotion.Checked)
            {
                //txtUnitPrice.Clear();
                cboBrand.SelectedValue = 39;
                cboMainCategory.SelectedValue = 1045;
                cboSubCategory.SelectedValue = 72;
                wrapperList.Clear();
                productList.Clear();
            }
            else
            {
                cboBrand.SelectedValue = 0;
                cboMainCategory.SelectedValue = 0;
                cboSubCategory.SelectedValue = 0;
                wrapperList.Clear();
                productList.Clear();
                txtUnitPrice.Clear();
                dgvChildItems.DataSource = null;
            }            
        }

        public void SetCurrentUnit(Int32 UnitId)
        {

            Unit currentUnit = entity.Units.Where(x => x.Id == UnitId).FirstOrDefault();
            if (currentUnit != null)
            {
                cboUnit.SelectedValue = currentUnit.Id;
            }
        }

        private void cboSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubCategory.SelectedIndex > 1)
            {
                if (isEdit == false)
                {
                    int id = Convert.ToInt32(cboSubCategory.SelectedValue);
                    APP_Data.ProductSubCategory pdSub = entity.ProductSubCategories.Where(x => x.Id == id).FirstOrDefault();
                    if (pdSub != null && pdSub.Prefix != null)
                    {
                        if (pdSub.Prefix.Length == 2)
                        {
                            var ProductCode = entity.GetProductCode(pdSub.Prefix, 3, 3);
                            txtProductCode.Text = ProductCode.FirstOrDefault().ToString();
                            txtBarcode.Text = txtProductCode.Text;
                        }
                        else if (pdSub.Prefix.Length == 3)
                        {
                            var ProductCode = entity.GetProductCode(pdSub.Prefix, 3, 4);
                            txtProductCode.Text = ProductCode.FirstOrDefault().ToString();
                            txtBarcode.Text = txtProductCode.Text;
                        }
                        else if (pdSub.Prefix.Length == 4)
                        {
                            var ProductCode = entity.GetProductCode(pdSub.Prefix, 3, 5);
                            txtProductCode.Text = ProductCode.FirstOrDefault().ToString();
                            txtBarcode.Text = txtProductCode.Text;
                        }
                        else
                        {
                            MessageBox.Show("Please check your sub category code", "Wrong Code");
                            return;
                        }

                    }
               
                }
            }
            else
            {
                txtBarcode.Clear();
                txtProductCode.Clear();
            }
        }


        private void ChargesForDoctorAndTechnician(string CagText)
        {
            switch (CagText)
            {
                case   "X-Ray":
                    lblPaymentForDT.Text = "Payment for Doctor and Technician";
                    break;
                default :
                    lblPaymentForDT.Text = "  Payment for Doctor ";
                    break;
            }
        }

        private void txtPaymentforDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }
      
        private static bool ContainsNumber(string input)
        {
            return Regex.IsMatch(input, @"\d+");
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            txtProductCode.Text = txtBarcode.Text.ToString();
        }
      
    }
}
