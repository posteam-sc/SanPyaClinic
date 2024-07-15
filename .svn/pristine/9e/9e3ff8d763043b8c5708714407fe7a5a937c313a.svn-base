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
    public partial class frmDoctorList : Form
    {
        #region Variables

        private POSEntities entity ;
        List<DoctorPhysio> doctorList;
        #endregion
        public frmDoctorList()
        {
            InitializeComponent();
        }

        private void frmDoctorList_Load(object sender, EventArgs e)
        {
            dgvDoctorList.AutoGenerateColumns = false;
            LoadData();
            if (rdoDoctor.Checked == true)
            {
                dgvDoctorList.Columns[6].Visible = false;
                dgvDoctorList.Columns[7].Visible = true;
                dgvDoctorList.Columns[9].Visible = true;
            }
            else
            {
                dgvDoctorList.Columns[6].Visible = true;
                dgvDoctorList.Columns[7].Visible = false;
                dgvDoctorList.Columns[9].Visible = false;
            }
        }

        private void dgvDoctorList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoctorList.Rows)
            {
                DoctorPhysio cs = (DoctorPhysio)row.DataBoundItem;
                // row.Cells[5].Value = Loc_CustomerPointSystem.GetPointFromCustomerId(cs.Id).ToString();
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmDoctorOrPhysio form = new frmDoctorOrPhysio();
            form.isEdit = false;
            form.ShowDialog();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadData();
         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #region Function

        public void LoadData()
        {
            entity = new POSEntities();
            doctorList = new List<DoctorPhysio>();
            doctorList = entity.DoctorPhysios.ToList();
            if (rdoDoctor.Checked == true)
            {
                doctorList = doctorList.Where(x => x.IsDoctor == true).ToList();
            }
            else
            {
                doctorList = doctorList.Where(x => x.IsDoctor == false).ToList();
            }
            //User make a search
            if (txtSearch.Text.Trim() != string.Empty)
            {
                //Search BY Customer Name               
                doctorList = doctorList.Where(x => x.Name.Trim().ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList();

            }

            dgvDoctorList.DataSource = doctorList;
            if (doctorList.Count == 0)
            {
                MessageBox.Show("Item not found!", "Cannot find");
            }

        }
        #endregion

        private void rdoPhysio_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPhysio.Checked == true)
            {
                LoadData();
                dgvDoctorList.Columns[7].Visible = false;
                dgvDoctorList.Columns[9].Visible = false;
                dgvDoctorList.Columns[6].Visible = true;
                
            }
           
        }

        private void dgvDoctorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //View detail information
                if (e.ColumnIndex == 9)
                {
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Doctor.EditOrDelete || MemberShip.isAdmin)
                    {
                        if (System.Windows.Forms.Application.OpenForms["frmDoctorDetail"] != null)
                        {
                            frmDoctorDetail newForm = (frmDoctorDetail)System.Windows.Forms.Application.OpenForms["frmDoctorDetail"];
                            newForm.DoctorId = Convert.ToInt32(dgvDoctorList.Rows[e.RowIndex].Cells[0].Value);
                            newForm.ShowDialog();
                        }
                        else
                        {
                            frmDoctorDetail newForm = new frmDoctorDetail();
                            newForm.DoctorId = Convert.ToInt32(dgvDoctorList.Rows[e.RowIndex].Cells[0].Value);
                            newForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to view detail doctor or physio", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                   
                }
                //Edit this User
                else if (e.ColumnIndex == 10)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Doctor.EditOrDelete || MemberShip.isAdmin)
                    {
                        frmDoctorOrPhysio form = new frmDoctorOrPhysio();
                        form.isEdit = true;
                        form.Text = "Edit Doctor Or Physio";
                        form.DoctorId = Convert.ToInt32(dgvDoctorList.Rows[e.RowIndex].Cells[0].Value);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit doctor or physio", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Delete this User
                else if (e.ColumnIndex == 11)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Doctor.EditOrDelete || MemberShip.isAdmin)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvDoctorList.Rows[e.RowIndex];
                            DoctorPhysio cust = (DoctorPhysio)row.DataBoundItem;
                            cust = (from c in entity.DoctorPhysios where c.Id == cust.Id select c).FirstOrDefault<DoctorPhysio>();
                            //Need to recheck
                            if (cust.Transactions.Count > 0)
                            {
                                MessageBox.Show("This doctor or physio already made transactions!", "Unable to Delete");
                                return;
                            }
                            else if (cust.GroupByPhysios.Count > 0)
                            {
                                MessageBox.Show("This physio already made Group!", "Unable to Delete");
                                return;
                            }
                            else
                            {
                                entity.DoctorPhysios.Remove(cust);
                                entity.SaveChanges();
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete doctor or physio", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                {
                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                    newForm.Clear();
                }
            }
        }

        private void rdoDoctor_CheckedChanged(object sender, EventArgs e)
        {


            if (rdoDoctor.Checked == true)
            {
                LoadData();
                dgvDoctorList.Columns[6].Visible = false;
                dgvDoctorList.Columns[7].Visible = true;
                dgvDoctorList.Columns[9].Visible = true;
               
            }
        }
    }
}
