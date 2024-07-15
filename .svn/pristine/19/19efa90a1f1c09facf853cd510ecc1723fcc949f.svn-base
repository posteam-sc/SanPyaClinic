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

namespace POS
{
    public partial class frmGroupDetail : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        public int GroupID { get; set; }
        Group currentgroup;
        List<APP_Data.GroupByPhysio> GroupPhysio = new List<GroupByPhysio>();
        List<DoctorPhysio> doclist = new List<DoctorPhysio>();

        #endregion

        public frmGroupDetail()
        {
            InitializeComponent();
        }

        private void frmGroupDetail_Load(object sender, EventArgs e)
        {
            dgvGroup.AutoGenerateColumns = false;
            currentgroup = (from p in entity.Groups where p.Id == GroupID select p).FirstOrDefault();
            lblGroupname.Text = currentgroup.GroupName;
            GroupPhysio.AddRange(currentgroup.GroupByPhysios.ToList());
            foreach (GroupByPhysio w in GroupPhysio)
            {
                doclist.Add((from p in entity.DoctorPhysios where p.Id == w.PhysioID select p).FirstOrDefault());

            }
            dgvGroup.DataSource = doclist;
        }
    }
}
