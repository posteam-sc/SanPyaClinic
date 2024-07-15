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
    public partial class NewCustomer : Form
    {
        #region Variables

        public Boolean isEdit { get; set; }

        public int CustomerId { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        #endregion

        public NewCustomer()
        {
            InitializeComponent();
        }

        private void autoID()
        {
            var ProductCode = entity.GetCustomerCode("P", 6, 2);
            txtCCode.Text = ProductCode.FirstOrDefault().ToString();
        
        }


        private void New_Customer_Load(object sender, EventArgs e)
        {
            cboTitle.Items.Add("U");
            cboTitle.Items.Add("Daw");
            cboTitle.Items.Add("Ko");
            cboTitle.Items.Add("Mg");
            cboTitle.Items.Add("Ma");
            cboTitle.Items.Add("Dr");
            cboTitle.Items.Add("Mr");
            cboTitle.Items.Add("Mrs");
            cboTitle.Items.Add("Miss");
            cboTitle.Items.Add("Ms");
            cboTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTitle.AutoCompleteSource = AutoCompleteSource.ListItems;
                             
            cboTitle.SelectedIndex = 0;

            BindCity();

            BindTownship();
            
            if (isEdit)
            {
                //Editing here
                Customer currentCustomer = (from c in entity.Customers where c.Id == CustomerId select c).FirstOrDefault<Customer>();
                txtName.Text = currentCustomer.Name;
                txtPhoneNumber.Text = currentCustomer.PhoneNumber;
                txtNRC.Text = currentCustomer.NRC;
                txtAddress.Text = currentCustomer.Address;
                txtEmail.Text = currentCustomer.Email;
                cboTitle.Text = currentCustomer.Title;
                cboCity.Text = currentCustomer.City.CityName;
                cboTownship.Text = (from m in entity.Townshipdbs where m.Id == currentCustomer.TownShipId select m.TownshipName).SingleOrDefault();
                txtCCode.Text = currentCustomer.CustomerCode;
                if (currentCustomer.Gender == "Male")
                {
                    rdbMale.Checked = true;
                }
                else
                {
                    rdbFemale.Checked = true;
                }
                
                if (currentCustomer.Birthday == null)
                {
                    dtpBirthday.Value = DateTime.Now.Date;
                }
                else
                {
                    dtpBirthday.Value = currentCustomer.Birthday.Value.Date;
                }
                btnSubmit.Image = POS.Properties.Resources.update_big;
            }
            else
            {
                autoID();
                int cityId = 0;
                cityId = SettingController.DefaultCity;                
                APP_Data.City cus2 = (from c in entity.Cities where c.Id == cityId select c).FirstOrDefault();
                cboCity.Text = cus2.CityName;
                rdbMale.Checked = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;

            tp.RemoveAll();
            tp.IsBalloon = true;                        
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            //Validation
            if (txtName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtName, "Error");
                tp.Show("Please fill up customer name!", txtName);
                hasError = true;
            }
            //else if (txtPhoneNumber.Text.Trim() == string.Empty && txtEmail.Text.Trim() == string.Empty && txtNRC.Text.Trim() == string.Empty)
            //{
            //    tp.SetToolTip(plError, "Error");
            //    tp.Show("Please fill up one information for these three requirement!", plError);
            //    plError.Visible = true;
            //    hasError = true;
            //}
            else if (cboCity.SelectedIndex == 0)
            {
                tp.SetToolTip(cboCity, "Error");
                tp.Show("Please fill up city name!", cboCity);
                hasError = true;
            }
            else if (cboTownship.SelectedIndex == 0)
            {
                tp.SetToolTip(cboTownship, "Error");
                tp.Show("Please fill up township name!", cboTownship);
                hasError = true;
            }
            else if (txtEmail.Text != string.Empty)
            {
                if (IsEmail(txtEmail.Text) == false)
                {
                    tp.SetToolTip(txtEmail, "Error");
                    tp.Show("Please fill Correct Email Format!", txtEmail);
                    hasError = true;
                }
            }
            Customer currentCustomer = new Customer();
            if (!hasError)
            {
                if (isEdit)
                {
                    currentCustomer = (from c in entity.Customers where c.Id == CustomerId select c).FirstOrDefault<Customer>();
                    currentCustomer.Title = cboTitle.Text;
                    currentCustomer.Name = txtName.Text;
                    currentCustomer.PhoneNumber = txtPhoneNumber.Text;
                    currentCustomer.NRC = txtNRC.Text;
                    currentCustomer.Address = txtAddress.Text;
                    currentCustomer.Email = txtEmail.Text;
                    if (rdbMale.Checked == true)
                    {
                        currentCustomer.Gender = "Male";
                    }
                    else
                    {
                        currentCustomer.Gender = "Female";
                    }
                    if (dtpBirthday.Value.Date == DateTime.Now.Date)
                    {
                        currentCustomer.Birthday = null;
                    }
                    else
                    {
                        currentCustomer.Birthday = dtpBirthday.Value.Date;
                    }
                    currentCustomer.CityId = Convert.ToInt32(cboCity.SelectedValue.ToString());
                    currentCustomer.TownShipId = Convert.ToInt32(cboTownship.SelectedValue.ToString());
                    entity.Entry(currentCustomer).State = EntityState.Modified;
                    entity.SaveChanges();

                    MessageBox.Show("Successfully Saved!", "Save");
                    this.Close();
                    #region active PaidByCreditWithPrePaidDebt
                    if (System.Windows.Forms.Application.OpenForms["PaidByCreditWithPrePaidDebt"] != null)
                    {
                        PaidByCreditWithPrePaidDebt newForm = (PaidByCreditWithPrePaidDebt)System.Windows.Forms.Application.OpenForms["PaidByCreditWithPrePaidDebt"];
                        newForm.LoadForm();
                    }
                    #endregion
                    #region active PaidByCredit
                    if (System.Windows.Forms.Application.OpenForms["PaidByCredit"] != null)
                    {
                        PaidByCredit newForm = (PaidByCredit)System.Windows.Forms.Application.OpenForms["PaidByCredit"];
                        newForm.LoadForm();
                    }
                    #endregion

                    //refresh sales form's customer list
                    if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                    {
                        Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                        newForm.ReloadCustomerList();
                        newForm.SetCurrentCustomer(currentCustomer.Id);

                    }
                }
                else
                {
                    int CustomerName=0;
                    CustomerName = (from p in entity.Customers where p.Name.Trim() == txtName.Text.Trim() select p).ToList().Count;
                    if(CustomerName == 0)
                    {
                        currentCustomer.Title = cboTitle.Text;
                        currentCustomer.Name = txtName.Text;
                        currentCustomer.PhoneNumber = txtPhoneNumber.Text;
                        currentCustomer.NRC = txtNRC.Text;
                        currentCustomer.Email = txtEmail.Text;
                        currentCustomer.Address = txtAddress.Text;
                        currentCustomer.CustomerCode = txtCCode.Text;
                        if (rdbMale.Checked == true)
                        {
                            currentCustomer.Gender = "Male";
                        }
                        else
                        {
                            currentCustomer.Gender = "Female";
                        }
                        if (dtpBirthday.Value.Date == DateTime.Now.Date)
                        {
                            currentCustomer.Birthday = null;
                        }
                        else
                        {
                            currentCustomer.Birthday = dtpBirthday.Value.Date;
                        }
                        currentCustomer.CityId = Convert.ToInt32(cboCity.SelectedValue.ToString());
                        currentCustomer.TownShipId = Convert.ToInt32(cboTownship.SelectedValue.ToString());
                        entity.Customers.Add(currentCustomer);
                        entity.SaveChanges();

                        MessageBox.Show("Successfully Saved!", "Save");
                        this.Close();
                        #region active PaidByCreditWithPrePaidDebt
                        if (System.Windows.Forms.Application.OpenForms["PaidByCreditWithPrePaidDebt"] != null)
                        {
                            PaidByCreditWithPrePaidDebt newForm = (PaidByCreditWithPrePaidDebt)System.Windows.Forms.Application.OpenForms["PaidByCreditWithPrePaidDebt"];
                            newForm.LoadForm();
                        }
                        #endregion
                        #region active PaidByCredit
                        if (System.Windows.Forms.Application.OpenForms["PaidByCredit"] != null)
                        {
                            PaidByCredit newForm = (PaidByCredit)System.Windows.Forms.Application.OpenForms["PaidByCredit"];
                            newForm.LoadForm();
                        }
                        #endregion

                        //refresh sales form's customer list
                        if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                        {
                            Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                            newForm.ReloadCustomerList();
                            newForm.SetCurrentCustomer(currentCustomer.Id);

                        }
                    }
                    else if (CustomerName > 0)
                    {
                        tp.SetToolTip(txtName, "Error");
                        tp.Show("This Customer Name is already exist!", txtName);
                    }
                    autoID();
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (result.Equals(DialogResult.OK))
            //{
            //    this.Dispose();
            //}
            cboTitle.Text = "Mr";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtNRC.Text = "";
            txtPhoneNumber.Text = "";
            dtpBirthday.Value = DateTime.Now.Date;
            rdbMale.Checked = true;
            int cityId = 0;
            cityId = SettingController.DefaultCity;
            APP_Data.City cus2 = (from c in entity.Cities where c.Id == cityId select c).FirstOrDefault();
            cboCity.Text = cus2.CityName;
            cboTownship.SelectedIndex = 0;
            autoID();
            btnSubmit.Image = POS.Properties.Resources.save_big;
        }

        private void New_Customer_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtName);
            tp.Hide(txtPhoneNumber);
            tp.Hide(cboTownship);
            tp.Hide(plError);
        }
        public static bool IsEmail(string s)
        {
            Regex EmailExpression = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.Compiled | RegexOptions.Singleline);


            if (!EmailExpression.IsMatch(s))
            {

                return false;

            }

            else
            {

                return true;

            }
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            City newForm = new City();
            newForm.ShowDialog();

        }

        private void btnAddTownship_Click(object sender, EventArgs e)
        {
            Township newForm = new Township();
            newForm.ShowDialog();
        }
        public void reloadCity(string rCity)
        {
            BindCity();
            APP_Data.City cus2 = (from c in entity.Cities where c.CityName == rCity select c).FirstOrDefault();
            cboCity.Text = cus2.CityName;
            //cboCity.Text = rCity;
            
        }
        public void reloadTownship(string rTownship)
        {
            BindTownship();
            APP_Data.Townshipdb cus2 = (from c in entity.Townshipdbs where c.TownshipName == rTownship select c).FirstOrDefault();
            cboTownship.Text = cus2.TownshipName;
            //cboTownship.Text = rTownship;
        }

        private void BindCity()
        {
            List<APP_Data.City> cityList = new List<APP_Data.City>();
            APP_Data.City city1 = new APP_Data.City();
            city1.Id = 0;
            city1.CityName = "Select";
            cityList.Add(city1);
            cityList.AddRange(entity.Cities.ToList());
            cboCity.DataSource = cityList;
            cboCity.DisplayMember = "CityName";
            cboCity.ValueMember = "Id";
            cboCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCity.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void BindTownship()
        {
            List<APP_Data.Townshipdb> TownshipList = new List<APP_Data.Townshipdb>();
            APP_Data.Townshipdb town1 = new APP_Data.Townshipdb();
            town1.Id = 0;
            town1.TownshipName = "Select";
            TownshipList.Add(town1);
            TownshipList.AddRange(entity.Townshipdbs.ToList());
            cboTownship.DataSource = TownshipList;
            cboTownship.DisplayMember = "TownshipName";
            cboTownship.ValueMember = "Id";
            cboTownship.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTownship.AutoCompleteSource = AutoCompleteSource.ListItems;
            plError.Visible = false;
        }
    }
}
