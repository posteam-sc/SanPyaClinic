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
    public partial class frmGroupList : Form
    {
        #region Variables

        private POSEntities entity;

        #endregion
        public frmGroupList()
        {
            InitializeComponent();
        }

        private void frmGroupList_Load(object sender, EventArgs e)
        {
            dgvGroupList.AutoGenerateColumns = false;
            LoadData();
        }
        public void LoadData()
        {
            entity = new POSEntities();
            List<Group> groupList = new List<Group>();
            groupList = entity.Groups.ToList();
            dgvGroupList.DataSource = groupList;
        }

        private void dgvGroupList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                //Edit this User
                if (e.ColumnIndex == 2)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Physio.EditOrDelete || MemberShip.isAdmin)
                    {
                        frmCreateGroup form = new frmCreateGroup();
                        form.isEdit = true;
                        form.Text = "Edit Physio Group";
                        form.GroupID = Convert.ToInt32(dgvGroupList.Rows[e.RowIndex].Cells[0].Value);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit physio group", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Delete this User
                else if (e.ColumnIndex == 3)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Physio.EditOrDelete || MemberShip.isAdmin)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvGroupList.Rows[e.RowIndex];
                            Group cust = (Group)row.DataBoundItem;
                            cust = (from c in entity.Groups where c.Id == cust.Id select c).FirstOrDefault<Group>();

                            int groupId=Convert.ToInt32(dgvGroupList.Rows[e.RowIndex].Cells[0].Value);
                            var isUse = (from t in entity.Groups where t.Id == groupId && t.IsUse == true select t).Count();

                            //Need to recheck
                            //if (cust.Transactions.Count > 0)
                            //{
                            //    MessageBox.Show("This group already made transactions!", "Unable to Delete");
                            //    return;
                            //}
                            if (isUse > 0)
                            {
                                MessageBox.Show("This group already made transactions!", "Unable to Delete");
                                  return;
                            }
                            else
                            {
                                List<GroupByPhysio> gp = (from gg in entity.GroupByPhysios where gg.GroupID == cust.Id select gg).ToList();
                                foreach (var item in gp)
                                {
                                    entity.GroupByPhysios.Remove(item);
                                    entity.SaveChanges();
                                }
                                entity.Groups.Remove(cust);
                                entity.SaveChanges();
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete physio group", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Physio.ViewDetail || MemberShip.isAdmin)
                    {
                        frmGroupDetail newForm = new frmGroupDetail();
                        newForm.GroupID = Convert.ToInt32(dgvGroupList.Rows[e.RowIndex].Cells[0].Value); ;
                        newForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to view detail physio group", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                
                   
                }
                if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                {
                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                    newForm.Clear();
                }
            }
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Physio.AddGroup || MemberShip.isAdmin)
            {
                frmCreateGroup form = new frmCreateGroup();
                form.isEdit = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to create physio group", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }       
          
        }
    }  
}
