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
    public partial class frmCreateGroup : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        public Boolean isEdit { get; set; }
        public int GroupID { get; set; }
        Group currentgroup;
        List<APP_Data.GroupByPhysio> GroupPhysio = new List<GroupByPhysio>();
        List<DoctorPhysio> doclist = new List<DoctorPhysio>();
      
        #endregion

        public frmCreateGroup()
        {
            InitializeComponent();
        }
        public void ReloadDoctorList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.DoctorPhysio> DoctorPhysiorList = new List<APP_Data.DoctorPhysio>();
            APP_Data.DoctorPhysio doctorPhysio = new APP_Data.DoctorPhysio();
            doctorPhysio.Id = 0;
            doctorPhysio.Name = "None";
            DoctorPhysiorList.Add(doctorPhysio);
            DoctorPhysiorList.AddRange((from p in entity.DoctorPhysios where p.IsDoctor == false select p).ToList());
            cboPhysioName.DataSource = DoctorPhysiorList;
            cboPhysioName.DisplayMember = "Name";
            cboPhysioName.ValueMember = "Id";
        }
        public void ReloadGroupList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.Group> GroupList = new List<APP_Data.Group>();
            APP_Data.Group group = new APP_Data.Group();
            group.Id = 0;
            group.GroupName = "None";
            GroupList.Add(group);
            GroupList.AddRange((from p in entity.Groups where p.IsUse==false select p).ToList());
            cboGroupName.DataSource = GroupList;
            cboGroupName.DisplayMember = "GroupName";
            cboGroupName.ValueMember = "Id";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
             Boolean hasError = false;

            dgvGroup.AutoGenerateColumns = false;
            dgvGroup.DataSource = "";
            APP_Data.GroupByPhysio payObj = new APP_Data.GroupByPhysio();
            DoctorPhysio dop = new DoctorPhysio();
             if (cboGroupName.SelectedIndex==0)
            {
                tp.SetToolTip(cboGroupName, "Error");
                tp.Show("Please select group name!", cboGroupName);
                hasError = true;
            }
            else if (cboPhysioName.SelectedIndex == 0)
            {
                tp.SetToolTip(cboPhysioName, "Error");
                tp.Show("Please select physio name!", cboPhysioName);
                hasError = true;
            }
            else
            {
                    int totalper = 0;

                    foreach (APP_Data.DoctorPhysio p in doclist)
                    {
                        totalper += Convert.ToInt32(p.ForPhysioTrain);
                    }
                    foreach (APP_Data.DoctorPhysio p in doclist)
                    {
                        if (p.Id == Convert.ToInt32(cboPhysioName.SelectedValue.ToString())) hasError = true;
                    }
                    if (!hasError)
                    {
                        

                        totalper += Convert.ToInt32(txtPercent.Text);
                        if (totalper <= 100)
                        {
                            dop.ForPhysioTrain = Convert.ToInt32(txtPercent.Text);
                            dop.Name = cboPhysioName.Text;
                            dop.Id = Convert.ToInt32(cboPhysioName.SelectedValue.ToString());
                            payObj.GroupID = Convert.ToInt32(cboGroupName.SelectedValue.ToString());
                            payObj.PhysioID = Convert.ToInt32(cboPhysioName.SelectedValue.ToString());
                            GroupPhysio.Add(payObj);
                            doclist.Add(dop);
                            dgvGroup.DataSource = doclist;
                            cboPhysioName.SelectedIndex = 0;
                            txtPercent.Text = string.Empty;
                        }
                        else
                        {
                            dgvGroup.DataSource = doclist;
                            MessageBox.Show("Total of all payment term should be equal 100%");
                            txtPercent.Focus();
                            txtPercent.SelectAll();
                        }

                    }
                    else
                    {
                        dgvGroup.DataSource = doclist;
                        MessageBox.Show("This physio is already include!");
                    }
            } 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;

            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";

            if (cboGroupName.SelectedIndex==0)
            {
                tp.SetToolTip(cboGroupName, "Error");
                tp.Show("Please select group name!", cboGroupName);
                hasError = true;
            }
           
            else if (CheckPercentage() == false)
            {
                MessageBox.Show("Total of group should be Less than 100%!");
                hasError = true;
            }
            
            if (!hasError)
            {
                //Edit product
                if (isEdit)
                {


                    var GroupDetail = entity.GroupByPhysios.Where(x => x.GroupID == GroupID).ToList();
                    foreach (GroupByPhysio pd in GroupDetail)
                    {
                        entity.GroupByPhysios.Remove(pd);
                        entity.SaveChanges();
                       
                    }
      
      
                    foreach (GroupByPhysio gp in GroupPhysio)
                    {
                        GroupByPhysio pdetail = new GroupByPhysio();
                        pdetail.GroupID = gp.GroupID;
                        pdetail.PhysioID = gp.PhysioID;
                        entity.GroupByPhysios.Add(pdetail);
                    }
                    entity.SaveChanges();
                    MessageBox.Show("Successfully update!", "Update");

                    if (System.Windows.Forms.Application.OpenForms["PurchaseInput"] != null)
                    {
                        frmGroupList newForm = (frmGroupList)System.Windows.Forms.Application.OpenForms["frmGroupList"];
                        newForm.LoadData();
                    }
                    this.Dispose();
                }
                else
                {
                    foreach (GroupByPhysio payDetail in GroupPhysio)
                    {
                        GroupByPhysio pdetail = new GroupByPhysio();
                        pdetail.GroupID = payDetail.GroupID;
                        pdetail.PhysioID = payDetail.PhysioID;
                        entity.GroupByPhysios.Add(pdetail);
                    }
                    int gID = Convert.ToInt32(cboGroupName.SelectedValue.ToString());
                    Group updateGroup = (from s in entity.Groups where s.Id == gID select s).FirstOrDefault();
                    updateGroup.IsUse = true;
                    entity.Entry(updateGroup).State = EntityState.Modified;
                    entity.SaveChanges();
                    ReloadGroupList();
                    MessageBox.Show("Successfully Save!", "Save");
                    #region active CustomerList
                    if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                    {
                        Form1 newForm = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
                        //newForm.FillCustomer();
                      //  newForm.FillContact();

                    }
                    #endregion

                    Clear();
                    this.Dispose();   
                }
            }
        }

        private void frmCreateGroup_Load(object sender, EventArgs e)
        {
            doclist.Clear();
         
            ReloadDoctorList();
            ReloadGroupList();
            dgvGroup.AutoGenerateColumns = false;
            if (isEdit)
            {
                currentgroup = (from p in entity.Groups where p.Id== GroupID select p).FirstOrDefault();
                GroupPhysio.AddRange(currentgroup.GroupByPhysios.ToList());
                foreach (GroupByPhysio w in GroupPhysio)
                {
                    doclist.Add((from p in entity.DoctorPhysios where p.Id == w.PhysioID select p).FirstOrDefault());

                }
                dgvGroup.DataSource = doclist;
                cboGroupName.SelectedValue = currentgroup.Id;

            }
           
        }
        private void frmCreateGroup_MouseMove(object sender, MouseEventArgs e)
        {
          
            tp.Hide(cboGroupName);
            tp.Hide(cboPhysioName);
           
        }

        private void cboPhysioName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPhysioName.SelectedIndex > 0)
            {
                int PhysioID = Int32.Parse(cboPhysioName.SelectedValue.ToString());
                APP_Data.DoctorPhysio DoctorPhysioObj = new APP_Data.DoctorPhysio();
                DoctorPhysioObj = (from d in entity.DoctorPhysios where d.Id ==PhysioID select d).FirstOrDefault();
                txtPercent.Text = DoctorPhysioObj.ForPhysioTrain.ToString();
              
            }
           
        }

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                            dgvGroup.DataSource = "";
                            doclist.RemoveAt(e.RowIndex);
                            GroupPhysio.RemoveAt(e.RowIndex);
                            dgvGroup.DataSource = doclist;
                    }
                }
            }
        }
        private void Clear()
        {
            cboGroupName.SelectedIndex = 0;
            dgvGroup.DataSource = "";
            GroupPhysio.Clear();
            doclist.Clear();
        }
        private Boolean CheckPercentage()
        {
            int totalper = 0;
            foreach (DoctorPhysio p in doclist)
            {

                totalper += Convert.ToInt32(p.ForPhysioTrain);
            }
            if (totalper <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
