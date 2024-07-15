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
    public partial class frmDoctorOrPhysio : Form
    {
        #region Variables

        public Boolean isEdit { get; set; }

        public int DoctorId { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        #endregion
        public frmDoctorOrPhysio()
        {
            InitializeComponent();
        }

        private void rdoDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDoctor.Checked == true)
            {
                txtPerPatient.Enabled = true;
                txtPhysioCharges.Enabled = true;
                chkIsInhouse.Enabled = true;
                txtForPhysio.Enabled = false;
                optPartTime.Enabled = false;
                optPercent.Enabled = false;
            }
            else
            {
                txtPerPatient.Enabled = false;
                txtPhysioCharges.Enabled = false;
                chkIsInhouse.Enabled = false;
                txtForPhysio.Enabled = true;
                optPartTime.Enabled = true;
                optPercent.Enabled = true;
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPhysio.Checked == true)
            {
                txtPerPatient.Enabled = false;
                txtPhysioCharges.Enabled = false;
                chkIsInhouse.Enabled = false;
                txtForPhysio.Enabled = true;
                optPartTime.Enabled = true;
                optPercent.Enabled = true;
            }
            else
            {
                txtPerPatient.Enabled = true;
                txtPhysioCharges.Enabled = true;
                chkIsInhouse.Enabled = true;
                txtForPhysio.Enabled = false;
                optPartTime.Enabled = false;
                optPercent.Enabled = false;
            }
        }

        private void frmDoctorOrPhysio_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                //Editing here
                DoctorPhysio currentDoctor = (from c in entity.DoctorPhysios where c.Id == DoctorId select c).FirstOrDefault<DoctorPhysio>();
                txtName.Text = currentDoctor.Name;
                txtDegree.Text = currentDoctor.Degree;
                txtSpecialization.Text = currentDoctor.Specialisation;
                txtPhone.Text = currentDoctor.PhoneNumber;
                txtEmail.Text = currentDoctor.Email;
                txtAddress.Text = currentDoctor.Address;

                if (currentDoctor.Gender == "Male")
                {
                    rdbMale.Checked = true;
                }
                else
                {
                    rdbFemale.Checked = true;
                }
               

                bool isDoctor= currentDoctor.IsDoctor.Value;

                if (isDoctor)
                {
                    rdoDoctor.Checked = true;
                    txtPerPatient.Text = currentDoctor.ChargesPerPatient.ToString();
                    txtPhysioCharges.Text = currentDoctor.PhysicoCharges.ToString();
                    chkIsInhouse.Checked = currentDoctor.IsInhouse.Value;
                }
                else
                {
                    rdoPhysio.Checked = true;
                    txtForPhysio.Text = currentDoctor.ForPhysioTrain.ToString();
                    if (currentDoctor.IsPercent == true)
                    {
                        optPercent.Checked = true;
                        lblPercent.Visible = true;
                    }
                    else
                    {
                        optPartTime.Checked = true;
                        lblPercent.Visible = false;
                    }
                }

                btnSubmit.Image = POS.Properties.Resources.update_big;
            }
            else
            {
                rdoDoctor.Checked = true;
                rdbMale.Checked = true;
            }

            if (rdoDoctor.Checked == true)
            {
                txtPerPatient.Enabled = true;
                txtPhysioCharges.Enabled = true;
                chkIsInhouse.Enabled = true;
                txtForPhysio.Enabled = false;
                optPartTime.Enabled = false;
                optPercent.Enabled = false;
            }
            else
            {
                txtPerPatient.Enabled = false;
                txtPhysioCharges.Enabled = false;
                chkIsInhouse.Enabled = false;
                txtForPhysio.Enabled = true;
                optPartTime.Enabled = true;
                optPercent.Enabled = true;
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
            if (rdoDoctor.Checked == true)
            {
                if (txtPerPatient.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtPerPatient, "Error");
                    tp.Show("Please fill up charges per patient!", txtPerPatient);
                    hasError = true;
                }
                else if (txtPhysioCharges.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtPhysioCharges, "Error");
                    tp.Show("Please fill up physio charges!", txtPhysioCharges);
                    hasError = true;
                }
                else if (txtName.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtName, "Error");
                    tp.Show("Please fill up doctory name!", txtName);
                    hasError = true;
                }
                else if (txtDegree.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtDegree, "Error");
                    tp.Show("Please fill up degree!", txtDegree);
                    hasError = true;
                }

            }
            else if (rdoPhysio.Checked == true)
            {
                if (txtForPhysio.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtForPhysio, "Error");
                    tp.Show("Please fill up for physio train!", txtForPhysio);
                    hasError = true;
                }
                else if (txtName.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtName, "Error");
                    tp.Show("Please fill up doctory name!", txtName);
                    hasError = true;
                }
                else if (txtDegree.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtDegree, "Error");
                    tp.Show("Please fill up degree!", txtDegree);
                    hasError = true;
                }
                else
                {
                    if (optPercent.Checked == true)
                    {
                        if (Convert.ToInt32(txtForPhysio.Text) > 100)
                        {
                            tp.SetToolTip(txtForPhysio, "Error");
                            tp.Show("Please fill up correct percentage!", txtForPhysio);
                            hasError = true;
                        }
                    }
                }
            }
            
            DoctorPhysio currentDoctorPhysio = new DoctorPhysio();
            if (!hasError)
            {
                if (isEdit)
                {
                    currentDoctorPhysio = (from c in entity.DoctorPhysios where c.Id == DoctorId select c).FirstOrDefault<DoctorPhysio>();
                    currentDoctorPhysio.Name = txtName.Text;
                    currentDoctorPhysio.Degree = txtDegree.Text;
                    currentDoctorPhysio.Specialisation = txtSpecialization.Text;
                    currentDoctorPhysio.PhoneNumber = txtPhone.Text;
                    currentDoctorPhysio.Email = txtEmail.Text;
                    currentDoctorPhysio.Address = txtAddress.Text;

                    if (rdbMale.Checked == true)
                    {
                        currentDoctorPhysio.Gender = "Male";
                    }
                    else
                    {
                        currentDoctorPhysio.Gender = "Female";
                    }
                   
                    if (rdoDoctor.Checked == true)
                    {
                        currentDoctorPhysio.IsDoctor = true;
                        currentDoctorPhysio.ChargesPerPatient = Convert.ToInt32(txtPerPatient.Text);
                        currentDoctorPhysio.PhysicoCharges = Convert.ToInt32(txtPhysioCharges.Text);
                        currentDoctorPhysio.IsInhouse = chkIsInhouse.Checked;
                    }
                    else
                    {
                        currentDoctorPhysio.ForPhysioTrain = Convert.ToDecimal(txtForPhysio.Text);
                        currentDoctorPhysio.IsDoctor = false;
                    }
                    if (rdoPhysio.Checked == true)
                    {
                        if (optPercent.Checked == true)
                        {
                            currentDoctorPhysio.IsPercent = true;
                        }
                        if (optPartTime.Checked == true)
                        {
                            currentDoctorPhysio.IsPercent = false;
                        }
                    }
                    else
                    {
                        currentDoctorPhysio.IsPercent = false;
                    }
                  

                    entity.Entry(currentDoctorPhysio).State = EntityState.Modified;
                    entity.SaveChanges();

                    MessageBox.Show("Successfully Saved!", "Save");
                    this.Dispose();
                    #region active PaidByCreditWithPrePaidDebt

                    if (System.Windows.Forms.Application.OpenForms["frmDoctorList"] != null)
                    {
                        frmDoctorList newForm = (frmDoctorList)System.Windows.Forms.Application.OpenForms["frmDoctorList"];
                        newForm.LoadData();
                    }
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
                        newForm.ReloadDoctorList();
                        newForm.SetCurrentCustomer(currentDoctorPhysio.Id);

                    }
                }
                else
                {
                    int CustomerName = 0;
                    CustomerName = (from p in entity.Customers where p.Name.Trim() == txtName.Text.Trim() select p).ToList().Count;
                    if (CustomerName == 0)
                    {
                       
                        currentDoctorPhysio.Name = txtName.Text;
                        currentDoctorPhysio.Degree = txtDegree.Text;
                        currentDoctorPhysio.Specialisation = txtSpecialization.Text;
                        currentDoctorPhysio.PhoneNumber = txtPhone.Text;
                        currentDoctorPhysio.Email = txtEmail.Text;
                        currentDoctorPhysio.Address = txtAddress.Text;

                        if (rdbMale.Checked == true)
                        {
                            currentDoctorPhysio.Gender = "Male";
                        }
                        else
                        {
                            currentDoctorPhysio.Gender = "Female";
                        }
                      
                        if (rdoDoctor.Checked == true)
                        {
                            currentDoctorPhysio.ChargesPerPatient = Convert.ToInt32(txtPerPatient.Text);
                            currentDoctorPhysio.PhysicoCharges = Convert.ToInt32(txtPhysioCharges.Text);
                            currentDoctorPhysio.IsInhouse = chkIsInhouse.Checked;
                            currentDoctorPhysio.IsDoctor = true;
                        }
                        else
                        {
                            currentDoctorPhysio.ForPhysioTrain = Convert.ToDecimal(txtForPhysio.Text);
                             currentDoctorPhysio.IsDoctor = false;
                        }
                        if (rdoPhysio.Checked == true)
                        {
                            if (optPercent.Checked == true)
                            {
                                currentDoctorPhysio.IsPercent = true;
                            }
                            if (optPartTime.Checked == true)
                            {
                                currentDoctorPhysio.IsPercent = false;
                            }
                        }
                        else
                        {
                            currentDoctorPhysio.IsPercent = false;
                        }
                  
                        entity.DoctorPhysios.Add(currentDoctorPhysio);
                        entity.SaveChanges();

                        MessageBox.Show("Successfully Saved!", "Save");
                        this.Dispose();
                        #region active PaidByCreditWithPrePaidDebt
                        if (System.Windows.Forms.Application.OpenForms["frmDoctorList"] != null)
                        {
                            frmDoctorList newForm = (frmDoctorList)System.Windows.Forms.Application.OpenForms["frmDoctorList"];
                            newForm.LoadData();
                        }
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
                            newForm.ReloadDoctorList();
                            newForm.SetCurrentCustomer(currentDoctorPhysio.Id);

                        }
                    }
                    else if (CustomerName > 0)
                    {
                        tp.SetToolTip(txtName, "Error");
                        tp.Show("This Doctor Name is already exist!", txtName);
                    }
                }

            }
        }

        private void frmDoctorOrPhysio_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtName);
            tp.Hide(txtDegree);
            tp.Hide(txtPerPatient);
            tp.Hide(txtPhysioCharges);
            tp.Hide(txtForPhysio);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDegree.Text = "";
            txtSpecialization.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPerPatient.Text = "";
            txtPhysioCharges.Text = "";
            txtForPhysio.Text = "";
            rdoDoctor.Checked = true;
            btnSubmit.Image = POS.Properties.Resources.save_big;
        }

        private void txtPerPatient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtPhysioCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void txtForPhysio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void optPercent_CheckedChanged(object sender, EventArgs e)
        {
            lblPercent.Visible = true;
        }

        private void optPartTime_CheckedChanged(object sender, EventArgs e)
        {
            lblPercent.Visible = false;
        }
    }
}
