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
    public partial class frmDoctorDetail : Form
    {
        #region Variables
        POSEntities entity = new POSEntities();
        public int DoctorId { get; set; }
        #endregion
       
        public frmDoctorDetail()
        {
            InitializeComponent();
        }

        private void frmDoctorDetail_Load(object sender, EventArgs e)
        {
            DoctorPhysio cust = (from c in entity.DoctorPhysios where c.Id == DoctorId select c).FirstOrDefault<DoctorPhysio>();

            lblName.Text =cust.Name;
            lblDegree.Text = cust.Degree;
            lblSpecialisation.Text = cust.Specialisation != "" ? cust.Specialisation : "-";
            lblPhoneNumber.Text = cust.PhoneNumber !="" ? cust.PhoneNumber : "-";
            lblEmail.Text = cust.Email != "" ? cust.Email : "-";
            lblGender.Text = cust.Gender;
            lblAddress.Text = cust.Address !=""? cust.Address : "-";
            lblChargesPerPatient.Text = cust.ChargesPerPatient.ToString();
            lblPhysicoCharges.Text = cust.PhysicoCharges.ToString();
            bool inhou = cust.IsInhouse.Value;
            if (inhou == true)
            {
                lblInhouse.Text = "Yes";
            }
            else
            {
                lblInhouse.Text = "No";
            }
          
      
            dgvNormalTransaction.AutoGenerateColumns = false;
            List<Transaction> transList = cust.Transactions.Where(trans => (trans.IsDeleted == false || trans.IsDeleted == null) && trans.IsComplete == true).ToList();
            dgvNormalTransaction.DataSource = transList;        
        }

        private void dgvNormalTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvNormalTransaction.Rows)
            {
                Transaction ts = (Transaction)row.DataBoundItem;
                row.Cells[0].Value = ts.Id;
                row.Cells[1].Value = ts.DateTime.Value.Date.ToString("dd-MM-yyyy");
                //row.Cells[2].Value = ts.DateTime.Value.TimeOfDay.Hours.ToString() + ts.DateTime.Value.TimeOfDay.Minutes.ToString();
                row.Cells[2].Value = ts.DateTime.Value.TimeOfDay.Hours.ToString() + ":" + ts.DateTime.Value.TimeOfDay.Minutes.ToString() + ":" + ts.DateTime.Value.Second.ToString();
                row.Cells[3].Value = ts.PaymentType.Name;
                row.Cells[4].Value = ts.TotalAmount;
                row.Cells[5].Value = ts.Type;
                row.Cells[6].Value = ts.Customer.Name;
                row.Cells[7].Value = ts.User.Name;
            }
        }
    }
}
