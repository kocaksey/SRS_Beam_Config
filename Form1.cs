using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRS_Beam_Config
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public double force, force2, force3, b, a, b2, a2,b3,a3, length, length2,length3, elasticity, inertia, beam_mass, beam_mass2,beam_mass3, deflection,deflection2,deflection3, mma, mmlength, mmgpa, mminertia, frequency,total_def;

        private void txtL2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtL2.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtL2.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtL.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtL.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtB3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtB3.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtB3.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtB2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtB2.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtB2.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public double parameter;
        public int flagChange1 = -1;

        private void btnChange_Click(object sender, EventArgs e)
        {
            flag = -1;
            flag2 = -1;
            btnSecondBeam.Enabled = false;
            btnThirdBeam.Enabled = false;
            grpBeamConfig2.Visible = false;
            grpBeamConfig3.Visible = false;
            foreach(TextBox txt in tlpbeamConfig.Controls.OfType<TextBox>())
            {
                txt.Clear();
                cmbB.Text = "";
                comboBoxBeamL.Text = "";
            }
            foreach (TextBox txt in tlpbeamConfig2.Controls.OfType<TextBox>())
            {
                txt.Clear();
                cmbB2.Text = "";
            }
            foreach (TextBox txt in tlpbeamConfig3.Controls.OfType<TextBox>())
            {
                txt.Clear();
                comboBoxBeamL3.Text = "";
            }

            foreach (TextBox txt in tlpResult.Controls.OfType<TextBox>())
            {
                txt.Clear();

            }
            foreach (TextBox txt in tlpSystem.Controls.OfType<TextBox>())
            {
                txt.Clear();
                btnChange.Enabled=false;
                btnContinue.Enabled = true;
                grpBeamConfig.Enabled = false;
                btnCalculate.Enabled = false;
                txt.Enabled = true;
            }  
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
          

            foreach (TextBox txt in tlpSystem.Controls.OfType<TextBox>())
            {
                if (txt.Text.Trim() == "" || !double.TryParse(txt.Text, out parameter))
                {
                    MessageBox.Show("The parameters must be number.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (Convert.ToDouble(txtLoad.Text) > 3000.0)
            {
                grpBeamConfig.Enabled = false;
                btnContinue.Enabled = true;
                btnCalculate.Enabled = false;
                btnChange.Enabled = false;

                foreach (TextBox txt in tlpSystem.Controls.OfType<TextBox>())
                {
                    txt.Enabled = true;
                }

                MessageBox.Show("Mass limit is 3000 kg.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                btnCalculate.Enabled = true;
                btnContinue.Enabled = false;
                btnChange.Enabled = true;
                grpBeamConfig.Enabled = true;

                foreach(TextBox txt in tlpSystem.Controls.OfType<TextBox>())
                {
                    txt.Enabled = false;
                }
            }  
            
            if(Convert.ToDouble(txtXdir.Text) > 2000.0)
            {
                foreach (TextBox txt in tlpSystem.Controls.OfType<TextBox>())
                {
                    txt.Enabled = true;
                }
                btnCalculate.Enabled = false;
                grpBeamConfig.Enabled = false;
                btnContinue.Enabled = true;
                btnChange.Enabled = false;
                MessageBox.Show("Over limit on X direction.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                btnCalculate.Enabled = true;
                btnContinue.Enabled = false;
                btnChange.Enabled = true;
                grpBeamConfig.Enabled = true;
                foreach (TextBox txt in tlpSystem.Controls.OfType<TextBox>())
                {
                    txt.Enabled = false;
                }
            }

            if (Convert.ToDouble(txtYdir.Text) > 2000.0)
            {
                foreach (TextBox txt in tlpSystem.Controls.OfType<TextBox>())
                {
                    txt.Enabled = true;
                }
                btnCalculate.Enabled = false;
                grpBeamConfig.Enabled = false;
                btnContinue.Enabled = true;
                btnChange.Enabled = false;
                MessageBox.Show("Over limit on Y direction.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                btnChange.Enabled = true;
                btnContinue.Enabled = false;
                grpBeamConfig.Enabled = true; 
                btnCalculate.Enabled = true;
                foreach(TextBox txt in tlpSystem.Controls.OfType<TextBox>())
                {
                    txt.Enabled = false;
                }
            }
            if (flag == -1 && flag2 == -1 && btnContinue.Enabled == false)
                txtL.Text = "1300";
                txtL.Enabled = false;
                btnSecondBeam.Enabled = true;
        }   
        int flagPictureBox = -1;     

        private void btnHelp_Click(object sender, EventArgs e)
        {
            flagPictureBox *= -1;

            if (flagPictureBox == 1)
            {
                pictureBox1.Visible = true;

            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        int flag = -1;
        int flag2 = -1;

        private void btnSecondBeam_Click_1(object sender, EventArgs e)
        {
            if (btnContinue.Enabled == false)
            {
                txtB2.ReadOnly = false;
                txtL2.ReadOnly = false;
                cmbB2.Enabled = true;
                txtA.Text = "";

                flag *= -1;
                if (flag == 1)
                    grpBeamConfig2.Visible = true;
                else if (flag2 == 1)
                    grpBeamConfig2.Visible = true;
                else
                    grpBeamConfig2.Visible = false;
                if (flag == 1)
                    grpBeamConfig.Text = "Top Layer Beam";
                else if (flag == -1 && flag2 != 1)
                    grpBeamConfig.Text = "Single Layer Beam";

                if (flag == -1)
                    txtL2.Text = "1300";
                    txtL2.Enabled = false;
                    txtL.Text = "";
                    txtL.Enabled = true;
                    foreach (TextBox txt in tlpbeamConfig2.Controls.OfType<TextBox>())
                    {
                        txt.Clear();
                        cmbB2.Text = "";
                    }
                if (flag == -1)
                    txtL.Text = "1300";
                    txtL.Enabled = false;
                if (flag == 1)
                    txtL.Enabled = true;
                txtL2.Text = "1300";
                txtL2.Enabled = false;
                btnThirdBeam.Enabled = true;
                if(grpBeamConfig2.Visible==false)
                {
                    btnThirdBeam.Enabled = false;
                }

                foreach (TextBox txt in tlpResult.Controls.OfType<TextBox>())
                {
                    txt.Clear();

                }
                if (flag == -1)
                {
                    foreach (TextBox txt in tlpbeamConfig2.Controls.OfType<TextBox>())
                    {
                        txt.Clear();
                        cmbB2.Text = "";

                    }
                    txtB2.Text = "";
                    txtA2.Text = "";
                    txtL2.Text = "";
                    cmbB2.Text = "";

                }
                if(btnThirdBeam.Enabled==false)
                {
                    foreach (TextBox txt in tlpbeamConfig.Controls.OfType<TextBox>())
                    {
                        txt.Clear();
                        cmbB.Text = "";
                        comboBoxBeamL.Text = "";
                        txtL.Text = "1300";
                    }
                }
            }             
        }
        private void btnThirdBeam_Click(object sender, EventArgs e)
        {
            txtB3.ReadOnly = false;
            txtL3.ReadOnly = false;
            comboBoxBeamL3.Enabled = true;
            grpBeamConfig3.Visible = true;
            txtA2.Text = "";
            flag2 *= -1;
            if (flag2 == 1 && flag == 1)
                grpBeamConfig3.Visible = true;
            else
                grpBeamConfig3.Visible = false;
            if (flag2 == 1)
            {
                grpBeamConfig2.Text = "Middle Layer Beam";
                txtL3.Text = "1300";
                txtL3.Enabled = false;
                txtL2.Text = "";
                txtL2.Enabled = true;
                btnSecondBeam.Enabled = false;
            }
            else
            {
                grpBeamConfig2.Text = "Bottom Layer Beam";
            }
            if (grpBeamConfig3.Visible == false)
            {
                txtL2.Text = "1300";
                txtL2.Enabled = false;
                btnSecondBeam.Enabled = true;
            }
            foreach (TextBox txt in tlpResult.Controls.OfType<TextBox>())
            {
                txt.Clear();

            }
            if(flag2 ==-1)
            {
                foreach (TextBox txt in tlpbeamConfig3.Controls.OfType<TextBox>())
                {
                    txt.Clear();
                    comboBoxBeamL3.Text = "";
                }
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {


            if (txtL.Text.Trim() == "" || !double.TryParse(txtL.Text, out parameter))
            {
                MessageBox.Show("Please enter a value.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtL2.Text.Trim() == "" && btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == false)
            {
                MessageBox.Show("Please enter a value.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtB2.Text.Trim() == "" && btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == false)
            {
                MessageBox.Show("Please enter a value.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtB2.Text.Trim() == "" && btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == true)
            {
                MessageBox.Show("Please enter a value.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cmbB2.Text.Trim()=="" && btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == true)
            {
                MessageBox.Show("Please choose length of the beam.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtB3.Text.Trim() == "" && btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == false)
            {
                MessageBox.Show("Please enter a value.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxBeamL3.Text.Trim() == "" && btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == false)
            {
                MessageBox.Show("Please choose length of the beam.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbB.Text.Trim() == "")
            {
                MessageBox.Show("Please choose distance of 'b'.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxBeamL.Text.Trim() == "")
            {
                MessageBox.Show("Please choose length of the beam.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            elasticity = 200;
            inertia = 204.25;
            if (cmbB.SelectedItem.ToString() == "X")
            {
                b = Convert.ToDouble(txtXdir.Text);
            }
            else if (cmbB.SelectedItem.ToString() == "Y")
            {
                b = Convert.ToDouble(txtYdir.Text);
            }
            length = Convert.ToDouble(txtL.Text);

                        switch (comboBoxBeamL.Text)
                        {
                            case "1600":
                                beam_mass = 73;
                                break;

                            case "2000":
                                beam_mass = 95;
                                break;
                            case "":
                            beam_mass = 0;
                                break;
                        }
                        switch (cmbB2.Text)
                        {
                            case "1600":
                                beam_mass2 = 73;
                                break;

                            case "2000":
                                beam_mass2 = 95;
                                break;
                            case "":
                                beam_mass2 = 0;
                                break;

                        }
                        switch (comboBoxBeamL3.Text)
                        {
                            case "1600":
                                beam_mass3 = 73;
                                break;

                            case "2000":
                                beam_mass3 = 95;
                                break;
                            case "":
                                beam_mass = 0;
                                break;
                        }
                        if (txtB2.Text != "")
                        {
                            b2 = Convert.ToDouble(txtB2.Text);
                            length2 = Convert.ToDouble(txtL2.Text);
                            a2 = (length2 - b2) / 2;
                            txtA2.Text = Convert.ToString(a2);
                        }
                        else if (txtB2.Text == "")
                        {
                            foreach (TextBox txt in tlpbeamConfig2.Controls.OfType<TextBox>())
                            {
                                txt.Clear();
                                cmbB2.Text = "";
                            }
                        }

                        if (txtB3.Text != "")
                        {
                            b3 = Convert.ToDouble(txtB3.Text);
                            length3 = Convert.ToDouble(txtL3.Text);
                            a3 = (length3 - b3) / 2;
                            txtA3.Text = Convert.ToString(a3);
                        }
                        force = (((Convert.ToDouble(txtLoad.Text))) * 9.81) / 8;
                        force2 = force + (beam_mass * 9.81 / 8);
                        force3 = force2 + (beam_mass2 * 9.81 / 8);

                        a = (length - b) / 2;
                        txtA.Text = Convert.ToString(a);

                        mma = a * 1;
                        mmlength = length * 1;
                        mmgpa = elasticity * 1000;
                        mminertia = inertia * 10000;

                        deflection = force * (Math.Pow(mma, 2)) * (3 * mmlength - 4 * mma) / (6 * mmgpa * mminertia);
                        deflection2 = force2 * (Math.Pow(a2, 2)) * (3 * length2 - 4 * a2) / (6 * mmgpa * mminertia);
                        deflection3 = force3 * (Math.Pow(a3, 2)) * (3 * length3 - 4 * a3) / (6 * mmgpa * mminertia);

                        if (btnThirdBeam.Enabled == false)
                        {
                            total_def = deflection;
                        }
                        if (btnThirdBeam.Enabled == true && btnSecondBeam.Enabled == true)
                        { 
                            total_def = deflection + deflection2;
                        }
                        if(btnSecondBeam.Enabled==false)
                        {
                            total_def = deflection + deflection2 + deflection3;
                        }
                        frequency = (1 / (2 * Math.PI)) * (Math.Pow((9810 / (total_def)), 0.5));
                        txtFrequency.Text = Convert.ToString(frequency);
                        txtTotalDef.Text = Convert.ToString(total_def);
        }
    }
}
