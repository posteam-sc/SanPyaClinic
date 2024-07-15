using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;
namespace POS
{
    public partial class Setting : Form
    {
        #region Variable
        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();     
        #endregion
        public Setting()
        {
            InitializeComponent();
        }

       
        private void Setting_Load(object sender, EventArgs e)
        {
            int i = 0;
            int j=0;
            #region Printer

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                cboBarcodePrinter.Items.Add(printerName);
                cboA4Printer.Items.Add(printerName);
                cboSlipPrinter.Items.Add(printerName);
            }

            if (DefaultPrinter.BarcodePrinter != null)
            {
                cboBarcodePrinter.Text = DefaultPrinter.BarcodePrinter;
            }
            if (DefaultPrinter.A4Printer != null)
            {
                cboA4Printer.Text = DefaultPrinter.A4Printer;
            }
            if (DefaultPrinter.SlipPrinter != null)
            {
                cboSlipPrinter.Text = DefaultPrinter.SlipPrinter;
            }

            #endregion

            #region taxPercent
            List<Tax> taxList = entity.Taxes.ToList();
            List<Tax> result = new List<Tax>();
            foreach (Tax r in taxList)
            {
                Tax t = new Tax();
                t.Id = r.Id;
                t.Name = r.Name + " and " + r.TaxPercent;
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
                cboTaxList.Text = defaultTax.Name + " and " + defaultTax.TaxPercent;
            }
            #endregion

            #region city
            List<APP_Data.City> cityList = entity.Cities.ToList();
            cboCity.DataSource = cityList;
            cboCity.DisplayMember = "CityName";
            cboCity.ValueMember = "Id";
            if (SettingController.DefaultCity != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultCity);
                APP_Data.City city = entity.Cities.Where(x => x.Id == id).FirstOrDefault();
                cboCity.Text = city.CityName;
            }
            #endregion
            txtShopName.Text = SettingController.ShopName;
            txtBranchName.Text = SettingController.BranchName;
            txtPhoneNo.Text = SettingController.PhoneNo;
            txtOpeningHours.Text = SettingController.OpeningHours;
            txtDefaultSalesRow.Text = SettingController.DefaultTopSaleRow.ToString();
            txtServiceCharges.Text = SettingController.DefaultServiceCharges.ToString();
            txtPhysio.Text = SettingController.DefaultPhysioPercent.ToString();
            string am = SettingController.AMShiftAssign.ToString();
            string[] am_split = am.Split('-');
            foreach (string a in am_split)
            {
                DateTime am_dt = Convert.ToDateTime(a);
                if (i == 0)
                {
                    am1.Value = am_dt;
                    i++;
                }
                else
                {
                    am2.Value = am_dt;
                }
            }
            string pm = SettingController.PMShiftAssign.ToString();
            string[] pm_split = pm.Split('-');
            foreach (string p in pm_split)
            {
                DateTime pm_dt = Convert.ToDateTime(p);
                if (j == 0)
                {
                    pm1.Value = pm_dt;
                    j++;
                }
                else
                {
                    pm2.Value = pm_dt;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;

            DateTime dt_am1 = Convert.ToDateTime(am1.Value.ToShortTimeString());
            DateTime dt_am2 = Convert.ToDateTime(am2.Value.ToShortTimeString());
            DateTime dt_pm1 = Convert.ToDateTime(pm1.Value.ToShortTimeString());
            DateTime dt_pm2 = Convert.ToDateTime(pm2.Value.ToShortTimeString());

            int res1=DateTime.Compare(dt_am1,dt_am2);
            int res2=DateTime.Compare(dt_am2,dt_pm1);
            int res3=DateTime.Compare(dt_pm1,dt_pm2);
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            //Validation
            if (txtShopName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtShopName, "Error");
                tp.Show("Please fill up shop name!", txtShopName);
                hasError = true;
            }
            else if (txtBranchName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtBranchName, "Error");
                tp.Show("Please fill up branch name or address!", txtBranchName);
                hasError = true;
            }
            else if (txtPhoneNo.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtPhoneNo, "Error");
                tp.Show("Please fill up pnone number!", txtPhoneNo);
                hasError = true;
            }
            else if (txtOpeningHours.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtOpeningHours, "Error");
                tp.Show("Please fill up opening hour!", txtOpeningHours);
                hasError = true;
            }
            else if (txtServiceCharges.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtServiceCharges, "Error");
                tp.Show("Please fill up service charges!", txtServiceCharges);
                hasError = true;
            }
            else if (txtPhysio.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtPhysio, "Error");
                tp.Show("Please fill up physio percent!", txtPhysio);
                hasError = true;
            }
            else if (res1>0||res1==0)
            {
                tp.SetToolTip(am2, "Error");
                tp.Show("Please fill up correct time!", am2);
                hasError = true;
            }
            else if (res2 > 0)
            {
                tp.SetToolTip(pm1, "Error");
                tp.Show("Please fill up correct time!", pm1);
                hasError = true;
            }
            else if (res3 > 0 || res3 == 0)
            {
                tp.SetToolTip(pm2, "Error");
                tp.Show("Please fill up correct time!", pm2);
                hasError = true;
            }
            if(hasError==false)
            {
                DefaultPrinter.BarcodePrinter = cboBarcodePrinter.Text;
                DefaultPrinter.A4Printer = cboA4Printer.Text;
                DefaultPrinter.SlipPrinter = cboSlipPrinter.Text;

                SettingController.ShopName = txtShopName.Text;
                SettingController.BranchName = txtBranchName.Text;
                SettingController.PhoneNo = txtPhoneNo.Text;
                SettingController.OpeningHours = txtOpeningHours.Text;
                SettingController.DefaultTaxRate = cboTaxList.SelectedValue.ToString();
                SettingController.DefaultServiceCharges = Convert.ToInt32(txtServiceCharges.Text);
                SettingController.DefaultPhysioPercent = Convert.ToInt32(txtPhysio.Text);
                string am = am1.Value.ToShortTimeString() + "-" + am2.Value.ToShortTimeString();
                string pm = pm1.Value.ToShortTimeString() + "-" + pm2.Value.ToShortTimeString();
                SettingController.AMShiftAssign = am;
                SettingController.PMShiftAssign = pm;

                int topcity = 0;
                Int32.TryParse(cboCity.SelectedValue.ToString(), out topcity);
                SettingController.DefaultCity = topcity;
                int topSalesRow = 0;
                Int32.TryParse(txtDefaultSalesRow.Text, out topSalesRow);
                SettingController.DefaultTopSaleRow = topSalesRow;
                MessageBox.Show("Successfully Saved!");
                this.Dispose();
            }
            
        }

        private void btnNewTax_Click(object sender, EventArgs e)
        {
            Taxes newForm = new Taxes();
            newForm.ShowDialog();
        }

        private void btnNewCity_Click(object sender, EventArgs e)
        {
            City newForm = new City();
            newForm.ShowDialog();
        }

        #region Function
        public void ReLoadData()
        {
            #region taxPercent
            List<Tax> taxList = entity.Taxes.ToList();
            List<Tax> result = new List<Tax>();
            foreach (Tax r in taxList)
            {
                Tax t = new Tax();
                t.Id = r.Id;
                t.Name = r.Name + " and " + r.TaxPercent;
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
                cboTaxList.Text = defaultTax.Name + " and " + defaultTax.TaxPercent;
            }
            #endregion

            #region city
            List<APP_Data.City> cityList = entity.Cities.ToList();
            cboCity.DataSource = cityList;
            cboCity.DisplayMember = "CityName";
            cboCity.ValueMember = "Id";
            if (SettingController.DefaultCity != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultCity);
                APP_Data.City city = entity.Cities.Where(x => x.Id == id).FirstOrDefault();
                cboCity.Text = city.CityName;
            }
            #endregion


        }

        public void ReloadTax()
        {
            entity = new POSEntities();
            #region taxPercent
            List<Tax> taxList = entity.Taxes.ToList();
            List<Tax> result = new List<Tax>();
            foreach (Tax r in taxList)
            {
                Tax t = new Tax();
                t.Id = r.Id;
                t.Name = r.Name + " and " + r.TaxPercent;
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
                cboTaxList.Text = defaultTax.Name + " and " + defaultTax.TaxPercent;
            }
            #endregion
        }


        public void SetCurrentTax(Int32 TaxId)
        {
            APP_Data.Tax currentTax = entity.Taxes.Where(x => x.Id == TaxId).FirstOrDefault();
            if (currentTax != null)
            {
                cboTaxList.SelectedValue = currentTax.Id;
            }
        }

        public void ReLoadCity()
        {
            #region city
            List<APP_Data.City> cityList = entity.Cities.ToList();
            cboCity.DataSource = cityList;
            cboCity.DisplayMember = "CityName";
            cboCity.ValueMember = "Id";
            if (SettingController.DefaultCity != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultCity);
                APP_Data.City city = entity.Cities.Where(x => x.Id == id).FirstOrDefault();
                cboCity.Text = city.CityName;
            }
            #endregion
        }

        public void SetCurrentCity(Int32 CityId)
        {
            APP_Data.City currentCity = entity.Cities.Where(x => x.Id == CityId).FirstOrDefault();
            if (currentCity != null)
            {
                cboCity.SelectedValue = currentCity.Id;
            }
        }
        #endregion

        private void txtServiceCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtBookFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtPhysio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }
    }
}
