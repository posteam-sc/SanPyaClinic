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
    public partial class frmDailyDutyList : Form
    {
        #region Variables

        private POSEntities entity;
      public  string shift {get;set;}
        List<DoctorPhysio> gridList = new List<DoctorPhysio>();
        #endregion
        public frmDailyDutyList()
        {
            InitializeComponent();
        }

        private void frmDailyDutyList_Load(object sender, EventArgs e)
        {
            dgvDutyList.AutoGenerateColumns = false;
            LoadData(shift);
            
        }

        private void LoadData(string shift)
        {
            var date = System.DateTime.Now.ToShortDateString();
            DateTime dt = Convert.ToDateTime(date);

            entity = new POSEntities();
            List<DailyDutyPhysio> dutyList = new List<DailyDutyPhysio>();

            String List = "";

            int DId = (from a in entity.DailyDutyPhysios
                    where (a.DutyDate == dt && a.Shift == shift)
                    select a.Id).FirstOrDefault();

            if (DId != 0)
            {
                List = (from a in entity.DailyDutyPhysios
                        where (a.DutyDate == dt && a.Shift == shift)
                        select a.StaffID).FirstOrDefault();
                int? groupId = (from a in entity.DailyDutyPhysios
                                where (a.DutyDate == dt && a.Shift == shift)
                                select a.GroupID).FirstOrDefault();

                var pList = (from a in entity.GroupByPhysios
                             where (a.GroupID == groupId)
                             select a.PhysioID).ToList();

                string staffList = string.Join(",", pList);

                string _StaffList=staffList + "," + List;
                string staffIdList = "";
                if (_StaffList.StartsWith(","))
                {
                    _StaffList = _StaffList.Substring(1);
                }

                if (_StaffList.EndsWith(","))
                {
                    _StaffList = _StaffList.Substring(0, _StaffList.Length - 1);
                }
                List<string> _staffIDList = new List<string>(_StaffList.Split(','));

               
                    var _staffID = _staffIDList.Select(int.Parse).ToList();
                    //List<DoctorPhysio> result1 = new List<DoctorPhysio>();
                    var result1 = (from a in entity.DoctorPhysios
                                   where (_staffID.Contains(a.Id) && a.IsPercent == false)
                                   select a).ToList();
                    //  List<DoctorPhysio> result2 = new List<DoctorPhysio>();
                    var result2 = (from a in entity.DoctorPhysios
                                   where (_staffID.Contains(a.Id) && a.IsPercent == true)
                                   select a).ToList();

                    var wholeGridList = result1.Concat(result2);
                    gridList = new List<DoctorPhysio>();
                    foreach (var w in wholeGridList)
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
                        gridList.Add(_doctorPhysio);
                    }

                    dgvDutyList.DataSource = gridList;
                
            }
        }

    }
}

