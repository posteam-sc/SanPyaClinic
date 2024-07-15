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
    public partial class frmDailyDuty : Form
    {
        #region Variable
     
        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        public Boolean isEdit { get; set; }
        public int DutyID{ get; set; }
   
        List<APP_Data.GroupByPhysio> GroupPhysio = new List<GroupByPhysio>();
        List<DoctorPhysio> doclist = new List<DoctorPhysio>();
        List<DoctorPhysio> EntryDocList = new List<DoctorPhysio>();
        List<DoctorPhysio> gridList = new List<DoctorPhysio>();
        List<DoctorPhysio> gridListForGroup = new List<DoctorPhysio>();
        List<int>  gList1=new List<int>();
        List<int> gList2 = new List<int>();
        string shift = "";
        int count = 0;
        #endregion

        #region "Initialize"
        public frmDailyDuty()
        {
            InitializeComponent();
        }
        #endregion

        #region "Method"
        public void ReloadGroupList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.Group> GroupList = new List<APP_Data.Group>();
            APP_Data.Group group = new APP_Data.Group();
            group.Id = 0;
            group.GroupName = "None";
            GroupList.Add(group);
            GroupList.AddRange((from p in entity.Groups where p.IsUse == true select p).ToList());
            cboGroupName.DataSource = GroupList;
            cboGroupName.DisplayMember = "GroupName";
            cboGroupName.ValueMember = "Id";
        }

        public void ReloadPartTimeStaffList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.DoctorPhysio> DoctorPhysiorList = new List<APP_Data.DoctorPhysio>();
            APP_Data.DoctorPhysio doctorPhysio = new APP_Data.DoctorPhysio();
            doctorPhysio.Id = 0;
            doctorPhysio.Name = "None";
            DoctorPhysiorList.Add(doctorPhysio);
            DoctorPhysiorList.AddRange((from p in entity.DoctorPhysios where p.IsDoctor == false select p).ToList());
            cboPartTimeStaff.DataSource = DoctorPhysiorList;
            cboPartTimeStaff.DisplayMember = "Name";
            cboPartTimeStaff.ValueMember = "Id";
        }

        public void Get_ShiftAssign()
        {
            entity = new POSEntities();
            //Add Customer List with default option

            APP_Data.Setting setting = new APP_Data.Setting();
            setting = (from p in entity.Settings where p.Key == "amshift_assign" select p).FirstOrDefault();
            lblAMShift.Text = " - " + setting.Value.ToString();

            setting = (from p in entity.Settings where p.Key == "pmshift_assign" select p).FirstOrDefault();
            lblPMShift.Text = " - " + setting.Value.ToString();
        }

        private void CheckShift()
        {
            if (rdoAm.Checked == true)
            {
                shift = "AM";
            }
            else
            {
                shift = "PM";
            }
        }

        private void LoadData(string shift)
        {
            if (Check_AssignStaff())
            {
                var date = System.DateTime.Now.ToShortDateString();
                DateTime dt = Convert.ToDateTime(date);

                entity = new POSEntities();
                List<DailyDutyPhysio> dutyList = new List<DailyDutyPhysio>();


                List<bool> percentList = new List<bool>();
                percentList.Add(true);
                percentList.Add(false);
                CheckShift();
                var list1 = (from f in entity.DailyDutyPhysios where f.DutyDate == dt && f.Shift == shift select f.Id).FirstOrDefault();

                DutyID = list1;
                var groupID = (from a in entity.DailyDutyPhysios
                               where (a.DutyDate == dt && a.Shift == shift)
                               select a.GroupID).FirstOrDefault();
                if (groupID != null)
                {
                    cboGroupName.SelectedValue = groupID;
                }
                #region for GroupStaff

                var physioList = (from a in entity.GroupByPhysios
                                  where (groupID == a.GroupID)
                                  select a.PhysioID).ToList();

                var groupresult1 = (from a in entity.DoctorPhysios
                                    where (physioList.Contains(a.Id) && percentList.Any(x => x))
                                    select a).ToList();
                gridListForGroup = new List<DoctorPhysio>();
                foreach (var w in groupresult1)
                {
                    APP_Data.DoctorPhysio _doctorPhysio = new APP_Data.DoctorPhysio();
                    _doctorPhysio.Id = w.Id;
                    _doctorPhysio.Name = w.Name;
                    if (w.IsPercent == true)
                    {
                        _doctorPhysio.Percent = w.ForPhysioTrain;
                    }
                    else
                    {
                        _doctorPhysio.Amount = w.ForPhysioTrain;
                    }
                    gridListForGroup.Add(_doctorPhysio);
                }

                dgvGroup.DataSource = gridListForGroup;
                #endregion

                #region for PartTimeStaff
                dgvPartTime.AutoGenerateColumns = false;
                String List = "";
         
                List = StaffCollect();
                if (List != "")
                {
                    List<string> _staffIDList = new List<string>(List.Split(','));
                    var _staffID = _staffIDList.Select(int.Parse).ToList();
                    string pList = string.Join(",", physioList);

                    _staffID.RemoveAll(x => physioList.Contains(x));
                    var partTimeResult1 = (from a in entity.DoctorPhysios
                                           where (_staffID.Contains(a.Id) && percentList.Any(x => x))
                                           select a).ToList();
                    doclist = new List<DoctorPhysio>();
                    foreach (var w in partTimeResult1)
                    {
                        APP_Data.DoctorPhysio _doctorPhysio = new APP_Data.DoctorPhysio();
                        _doctorPhysio.Id = w.Id;
                        _doctorPhysio.Name = w.Name;
                        if (w.IsPercent == true)
                        {
                            _doctorPhysio.Percent = w.ForPhysioTrain;
                        }
                        else
                        {
                            _doctorPhysio.Amount = w.ForPhysioTrain;
                        }
                        doclist.Add(_doctorPhysio);
                    }

                    dgvPartTime.DataSource = doclist;
                }
                else
                {
                    dgvPartTime.DataSource = "";
                }
               
                #endregion


            }
            else
            {
                Clear();
                isEdit = false;
            }
        }

        public string StaffCollect()
        {
            var date = System.DateTime.Now.ToShortDateString();
            DateTime dt = Convert.ToDateTime(date);

            string query = (from a in entity.DailyDutyPhysios
                            where (a.DutyDate == dt && a.Shift == shift)
                            select a.StaffID).FirstOrDefault();

            return query;
        }

        public IEnumerable<GroupByPhysio> GetPhysio()
        {
            var physioIdList = from PS in entity.GroupByPhysios
                               where (PS.GroupID == Convert.ToInt32(cboGroupName.SelectedValue))
                               select new { PS.PhysioID };

            return physioIdList.ToList() // now we have in-memory query
                          .Select(c => new GroupByPhysio()
                          {
                              PhysioID = Convert.ToInt32(c.PhysioID)
                          });
        }

        public void Clear()
        {
            cboGroupName.SelectedIndex = 0;
            cboPartTimeStaff.SelectedIndex = 0;
            dgvPartTime.DataSource = "";
            dgvGroup.DataSource = "";
        }

        public bool CheckNameAlready()
        {
            //  DataTable dt = doclist as DataTable;
            String searchAuthor = cboPartTimeStaff.Text;
            var staffId = Convert.ToInt32(cboPartTimeStaff.SelectedValue);
            bool contains = false;

            if (!isEdit)
            {
                var list = (from a in EntryDocList
                            where a.Id == staffId
                            select a).ToList();

                if (list.Count > 0)
                {
                    contains = true;
                }
            }
            else
            {
                var list = (from a in doclist
                            where a.Id == staffId
                            select a).ToList();

                if (list.Count > 0)
                {
                    contains = true;
                }
            }

            return contains;
        }

       

        public bool Check_AssignStaff()
        {
            bool b = false;
            var date = System.DateTime.Now.ToShortDateString();
            DateTime dt = Convert.ToDateTime(date);

           var list= (from f in entity.DailyDutyPhysios where f.DutyDate == dt select f).ToList();

          

            if (list.Count == 2)
            {
                btnSave.Image = POS.Properties.Resources.update_big;
                b = true;
                btnCancel.Enabled = false;
                isEdit = true;

               // btnSave.Enabled = false;
            }
            else if (list.Count == 1)
            {
                CheckShift();
              
               // var tList = (from a in entity.Transactions where idList.Contains(a.GroupID.Value) select a).Count();
           
                var list1 = (from f in list where f.Shift == shift select f.Id).FirstOrDefault();
                if (list1 != 0)
                {
                    DutyID = list1;
                    //MessageBox.Show("Already defined AM Assign Staff duty for today");
                    b = true;
                    btnCancel.Enabled = false;
                    if (shift == "AM")
                    {
                        rdoAm.Checked = true;
                    }
                    else
                    {
                        rdoPm.Checked = true;
                    }

                    btnSave.Image = POS.Properties.Resources.update_big;
                    isEdit = true;
                }
                else
                {
                    btnSave.Image = POS.Properties.Resources.save_big;
                    isEdit = false;
                   
                }

            }
            else
            {
                btnSave.Image = POS.Properties.Resources.save_big;
                isEdit = true;
                btnSave.Enabled = true;
            }
            return b;
        }

        private void Check_Transaction(string shift)
        {
            var date = System.DateTime.Now.ToShortDateString();
            DateTime dt = Convert.ToDateTime(date);
            var list = (from f in entity.DailyDutyPhysios where f.DutyDate == dt select f).ToList();
            var tList = (from a in entity.Transactions
                         where a.DateTime.Value.Year == dt.Year &&
                                          a.DateTime.Value.Month == dt.Month &&
                                          a.DateTime.Value.Day == dt.Day
                         select a.GroupID).ToList();
            var shiftList = (from f in list where tList.Contains(f.Id) select f).ToList();
            if (shiftList.Count == 2)
            {
                btnSave.Enabled = false;
            }
            else if (shiftList.Count == 1)
            {
                var Shift = (from f in shiftList where f.Shift == shift select f.Shift).FirstOrDefault();
                if (Shift == "AM")
                {
                    if (rdoAm.Checked == true)
                    {
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                    }
                }
                else if (Shift == "PM")
                {
                    if (rdoPm.Checked == true)
                    {
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                    }
                }
                else
                {
                    btnSave.Enabled = true;
                }

               
            }
        }

     
        private DailyDutyPhysio Save()
        {
            APP_Data.DailyDutyPhysio ddphysio = new APP_Data.DailyDutyPhysio();
            var GID = Convert.ToInt32(cboGroupName.SelectedValue);
           // gList1 = (from f in entity.GroupByPhysios where f.GroupID == GID select f.PhysioID).ToList();

            //if (!isEdit)
            //{
                gList2 = (from d in EntryDocList
                          select d.Id).ToList();
            //}
            //else
            //{

            //    gList2 = (from d in doclist
            //              select d.Id).ToList();
            //}
           // var resultSum = gList1.Concat(gList2);
                var joinResult = string.Join(",", gList2);


            ddphysio.StaffID = joinResult;

            var date1 = System.DateTime.Now.ToShortDateString();
            ddphysio.DutyDate = Convert.ToDateTime(date1);
            ddphysio.GroupID = Convert.ToInt32(cboGroupName.SelectedValue);
            if (rdoAm.Checked == true)
            {
                ddphysio.Shift = "AM";
            }
            else
            {
                ddphysio.Shift = "PM";
            }
            return ddphysio;
        }

        public bool CheckSave()
        {
            bool _bo = false;
            if (isEdit)
            {
                var pList = (from a in doclist select a.Id).ToList();

                var nList = (from b in gridListForGroup where pList.Contains(b.Id) select b.Name).ToList();

                if (nList.Count > 0)
                {
                    MessageBox.Show("Part Time Staff is already exist in group List. Please delete it!");
                    _bo = false;
                }
                else
                {
                    _bo = true;
                }
            }
            else
            {
                {
                    var pList = (from a in EntryDocList select a.Id).ToList();

                    var nList = (from b in gridListForGroup where pList.Contains(b.Id) select b.Name).ToList();

                    if (nList.Count > 0)
                    {
                        MessageBox.Show("Part Time Staff is already exist in group List. Please delete it!");
                        _bo = false;
                    }
                    else
                    {
                        _bo = true;
                    }
                }
            }
            return _bo;
        }

        public void GroupList()
        {
            dgvGroup.AutoGenerateColumns = false;
            int gId = 0;
            if (cboGroupName.SelectedIndex != 0)
            {
                gId = Convert.ToInt32(cboGroupName.SelectedValue);
                var idList = (from f in entity.GroupByPhysios where f.GroupID == gId select f.PhysioID).ToList();

                var list = (from p in entity.DoctorPhysios where idList.Contains(p.Id) select p).ToList();
                gridListForGroup = new List<DoctorPhysio>();
                foreach (var p in list)
                {
                    APP_Data.DoctorPhysio dop = new APP_Data.DoctorPhysio();
                    if (p.IsPercent == true || p.IsPercent == null)
                    {
                        dop.Percent = p.ForPhysioTrain;
                    }
                    else
                    {
                        dop.Amount = p.ForPhysioTrain;
                    }
                    dop.Name = p.Name;
                    dop.Id = p.Id;
                    gridListForGroup.Add(dop);
                }
                dgvGroup.DataSource = gridListForGroup;
            }
        }

        private void PartTimeGridList()
        {
              if (!isEdit)
            {
                
                dgvPartTime.DataSource = EntryDocList;
            }
            else
            {
                dgvPartTime.DataSource = doclist;
            }
        }

        #endregion

        #region "Event"
        private void frmDailyDuty_Load(object sender, EventArgs e)
        {
            Get_ShiftAssign();
            ReloadGroupList();
            ReloadPartTimeStaffList();
            CheckShift();
            LoadData(shift);
            //CheckShift();
            Check_Transaction(shift);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;
            List<APP_Data.GroupByPhysio> groupByPhysio = new List<APP_Data.GroupByPhysio>();
            var staffId = Convert.ToInt32(cboPartTimeStaff.SelectedValue);

            var GID = Convert.ToInt32(cboGroupName.SelectedValue);

            //select part time staff id already in group list or not
            List<GroupByPhysio> PhysioIDList1 = new List<GroupByPhysio>();
            PhysioIDList1.AddRange((from a in entity.GroupByPhysios
                                    where a.GroupID == GID && a.PhysioID == staffId
                                    select a).ToList());

            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
          
            dgvPartTime.AutoGenerateColumns = false;
            dgvPartTime.DataSource = "";
            //   APP_Data.GroupByPhysio payObj = new APP_Data.GroupByPhysio();
            DoctorPhysio dop = new DoctorPhysio();
            if (cboPartTimeStaff.SelectedIndex == 0)
            {
                tp.SetToolTip(cboPartTimeStaff, "Error");
                tp.Show("Please select part time staff!", cboPartTimeStaff);
                hasError = true;
            }
            else if (PhysioIDList1.Count > 0)
            {
                PartTimeGridList();
               
                MessageBox.Show("Part Time Staff is already exist in Group List. Please choose another staff.");

            }
            else if (CheckNameAlready())
            {
                PartTimeGridList();
                MessageBox.Show("Part Time Staff is already added in List. Please choose another staff.");

            }
            else
            {

                APP_Data.DoctorPhysio _doctorPhysio = new APP_Data.DoctorPhysio();
                int physioId = Convert.ToInt32(cboPartTimeStaff.SelectedValue);
                _doctorPhysio = (from p in entity.DoctorPhysios where p.Id == physioId select p).FirstOrDefault();

                if (_doctorPhysio.IsPercent == true || _doctorPhysio.IsPercent == null)
                {
                    dop.Percent = _doctorPhysio.ForPhysioTrain;
                }
                else
                {
                    dop.Amount = _doctorPhysio.ForPhysioTrain;
                }
                dop.Name = cboPartTimeStaff.Text;
                dop.Id = Convert.ToInt32(cboPartTimeStaff.SelectedValue.ToString());
                if (!isEdit)
                {

                    if (count == 0)
                    {
                        EntryDocList = new List<DoctorPhysio>();
                    }
                    EntryDocList.Add(dop);
                    dgvPartTime.DataSource = EntryDocList;
                    count = dgvPartTime.Rows.Count;
                }
                else
                {
                    doclist.Add(dop);
                    dgvPartTime.DataSource = doclist;
                }
                cboPartTimeStaff.SelectedIndex = 0;
            }
            cboPartTimeStaff.Focus();
        }

        private void dgvPartTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        dgvPartTime.DataSource = "";
                     
                        if (isEdit)
                        {
                            doclist.RemoveAt(e.RowIndex);
                            dgvPartTime.DataSource = doclist;
                        }
                        else
                        {
                            EntryDocList.RemoveAt(e.RowIndex);
                            dgvPartTime.DataSource = EntryDocList;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            APP_Data.DailyDutyPhysio ddphysio = new APP_Data.DailyDutyPhysio();
            if (CheckSave())
            {
                if (isEdit)
                {
                    ddphysio = (from c in entity.DailyDutyPhysios where c.Id == DutyID select c).FirstOrDefault<DailyDutyPhysio>();
                    var GID = Convert.ToInt32(cboGroupName.SelectedValue);
                   // gList1 = (from f in entity.GroupByPhysios where f.GroupID == GID select f.PhysioID).ToList();

                    //if (!isEdit)
                    //{
                    //    gList2 = (from d in EntryDocList
                    //              select d.Id).ToList();
                    //}
                    //else
                    //{

                        gList2 = (from d in doclist
                                  select d.Id).ToList();
                    //}
                   // var resultSum = gList1.Concat(gList2);
                        var joinResult = string.Join(",", gList2);


                    ddphysio.StaffID = joinResult;

                    var date1 = System.DateTime.Now.ToShortDateString();
                    ddphysio.DutyDate = Convert.ToDateTime(date1);
                    ddphysio.GroupID = Convert.ToInt32(cboGroupName.SelectedValue);
                    if (rdoAm.Checked == true)
                    {
                        ddphysio.Shift = "AM";
                    }
                    else
                    {
                        ddphysio.Shift = "PM";
                    }
                    //  ddphysio = Save();
                    entity.Entry(ddphysio).State = EntityState.Modified;

                }
                else
                {
                    ddphysio = Save();
                    entity.DailyDutyPhysios.Add(ddphysio);

                }
                entity.SaveChanges();
                MessageBox.Show("Successfully Save!", "Save");
                LoadData(shift);
            }
            //Edit product


        }

        private void cboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupList();
        }

        private void rdoAm_CheckedChanged(object sender, EventArgs e)
        {
            count = 0;
            CheckShift();
            New_List();
            LoadData(shift);
            Check_Transaction(shift);
        }

        private void rdoPm_CheckedChanged(object sender, EventArgs e)
        {
            count = 0;
            CheckShift();
            New_List();
            LoadData(shift);
            Check_Transaction(shift);
        }

        private void New_List()
        {
            if (!isEdit)
            {
                EntryDocList = new List<DoctorPhysio>();
            }
        }

        #endregion

    }
}
