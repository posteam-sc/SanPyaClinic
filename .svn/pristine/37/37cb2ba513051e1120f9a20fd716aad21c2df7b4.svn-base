using POS.APP_Data;
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
    public partial class Township : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        
        private bool isEdit = false;
        private int TownshipId = 0;
        #endregion
        public Township()
        {
            InitializeComponent();
        }

        private void Township_Load(object sender, EventArgs e)
        {
            dgvTownshipList.AutoGenerateColumns = false;
            dgvTownshipList.DataSource = entity.Townshipdbs.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            bool HaveError = false;
            if (txtName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtName, "Error");
                tp.Show("Please fill up township name!", txtName);
                HaveError = true;
            }
            if (!HaveError)
            {
                string CityName = txtName.Text.Trim();
                APP_Data.Townshipdb CityObj = new APP_Data.Townshipdb();
                APP_Data.Townshipdb alredyCityObj = entity.Townshipdbs.Where(x => x.TownshipName.Trim() == CityName).FirstOrDefault();
                if (alredyCityObj == null)
                {
                    if (!isEdit)
                    {
                        dgvTownshipList.DataSource = "";
                        CityObj.TownshipName = txtName.Text;
                        entity.Townshipdbs.Add(CityObj);
                        entity.SaveChanges();
                        dgvTownshipList.DataSource = entity.Townshipdbs.ToList();
                        //  txtName.Text = "";
                        MessageBox.Show("Successfully Saved!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        APP_Data.Townshipdb EditTownship = entity.Townshipdbs.Where(x => x.Id == TownshipId).FirstOrDefault();
                        EditTownship.TownshipName = txtName.Text.Trim();
                        entity.SaveChanges();

                        dgvTownshipList.DataSource = (from b in entity.Townshipdbs orderby b.Id descending select b).ToList();

                     
                       
                    }
                    txtName.Text = "";

                    #region active setting
                    if (System.Windows.Forms.Application.OpenForms["Setting"] != null)
                    {
                        Setting newForm = (Setting)System.Windows.Forms.Application.OpenForms["Setting"];
                        this.Close();
                        newForm.ReLoadData();
                  
                    }
                    if (System.Windows.Forms.Application.OpenForms["NewCustomer"] != null)
                    {
                        NewCustomer newForm1 = (NewCustomer)System.Windows.Forms.Application.OpenForms["NewCustomer"];
                        this.Close();
                        newForm1.reloadTownship(txtName.Text);
                       
                    }
                    #endregion
                }
                else
                {
                    tp.SetToolTip(txtName, "Error");
                    tp.Show("This city name is already exist!", txtName);
                }
            }
        }

        private void dgvCityList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentId;
            if (e.RowIndex >= 0)
            {
                //Edit
                if (e.ColumnIndex == 2)
                {

                    //Role Management

                    DataGridViewRow row = dgvTownshipList.Rows[e.RowIndex];
                    currentId = Convert.ToInt32(row.Cells[0].Value);

                    APP_Data.Townshipdb Township = (from b in entity.Townshipdbs where b.Id == currentId select b).FirstOrDefault();
                    txtName.Text = Township.TownshipName;
                    isEdit = true;
                    this.Text = "Edit Township";
                    TownshipId = Township.Id;
                    btnAdd.Image = Properties.Resources.save_small;


                }
                //Delete
                if (e.ColumnIndex == 3)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvTownshipList.Rows[e.RowIndex];
                        currentId = Convert.ToInt32(row.Cells[0].Value);
                        int count = (from Cus in entity.Customers where Cus.TownShipId == currentId select Cus).ToList().Count;
                        if (count < 1)
                        {
                            dgvTownshipList.DataSource = "";
                            APP_Data.Townshipdb city = (from c in entity.Townshipdbs where c.Id == currentId select c).FirstOrDefault();
                            entity.Townshipdbs.Remove(city);
                            entity.SaveChanges();
                            dgvTownshipList.DataSource = entity.Townshipdbs.ToList();
                            MessageBox.Show("Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //To show message box 
                            MessageBox.Show("This township name is currently in use!", "Enable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }
    }
}
