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
    public partial class frmGroup : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();

        #endregion
        public frmGroup()
        {
            InitializeComponent();
        }

        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvGroupList.AutoGenerateColumns = false;
            dgvGroupList.DataSource = entity.Groups.ToList();
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
                tp.Show("Please fill up group name!", txtName);
                HaveError = true;
            }
            if (!HaveError)
            {
                string GroupName = txtName.Text.Trim();
                APP_Data.Group GroupObj = new APP_Data.Group();
                APP_Data.Group alredyGroupObj = entity.Groups.Where(x => x.GroupName.Trim() == GroupName).FirstOrDefault();
                if (alredyGroupObj == null)
                {
                    dgvGroupList.DataSource = "";
                    GroupObj.GroupName = txtName.Text;
                    GroupObj.IsUse = false;
                    entity.Groups.Add(GroupObj);
                    entity.SaveChanges();
                    dgvGroupList.DataSource = entity.Groups.ToList();
                    txtName.Text = "";
                    MessageBox.Show("Successfully Saved!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tp.SetToolTip(txtName, "Error");
                    tp.Show("This group name is already exist!", txtName);
                }
            }
            if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
            {
                Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                newForm.ReloadGroupList();
            }
        }

        private void dgvGroupList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                if (e.ColumnIndex == 2)
                {
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

                            //Need to recheck
                            if (cust.Transactions.Count > 0)
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
                                dgvGroupList.DataSource = entity.Groups.ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete physio group", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
               
            }
        }
    }
}
