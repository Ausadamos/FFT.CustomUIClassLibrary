using CommonClassLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomUIClassLibrary
{
    public partial class SettingSpec_Need_NoneSpec_MinMax : UserControl
    {
        public SettingSpec_Need_NoneSpec_MinMax()
        {
            InitializeComponent();
            SetLineColor(LineColorCustom);
        }

        Color LineColorCustom = Color.White;
        Color BackColorCustom = Color.FromArgb(56, 58, 64);

        public string HeaderLabel
        {
            get { return lblHeader.Text; }
            set { lblHeader.Text = value; }
        }

        public bool CheckNeed
        {
            get { return rdoNeed.Checked; }
            set { rdoNeed.Checked = value; }
        }
        public bool CheckNoNeed
        {
            get { return rdoNoNeed.Checked; }
            set { rdoNoNeed.Checked = value; }
        }
        public bool CheckNonSpec
        {
            get { return chkNoneSpec.Checked; }
            set { chkNoneSpec.Checked = value; }
        }

        public string SpecMax
        {
            get { return txtMax.Text; }
            set { txtMax.Text = value; }
        }
        public string SpecMin
        {
            get { return txtMin.Text; }
            set { txtMin.Text = value; }
        }




        public Color LineColorLayout
        {
            get
            {
                return LineColorCustom;
            }
            set
            {
                LineColorCustom = value;
                SetLineColor(LineColorCustom);
            }

        }

        //public Color BackColorLayout
        //{
        //    get
        //    {
        //        return BackColorCustom;
        //    }
        //    set
        //    {
        //        BackColorCustom = value;
        //        SetBackColor(BackColorCustom);
        //    }

        //}

        private void SetLineColor(Color colorLayout)
        {
            this.lblHeader.ForeColor = colorLayout;
            this.panel2.BackColor = colorLayout;
            this.panel3.BackColor = colorLayout;
            this.panel4.BackColor = colorLayout;
            this.panel5.BackColor = colorLayout;
            this.panel11.BackColor = colorLayout;
        }
        private void SetBackColor(Color colorLayout)
        {
            this.BackColor = colorLayout;
        }

        private void rdoNeed_CheckedChanged(object sender, EventArgs e)
        {
            setMinMaxDefault();
            chkNoneSpec.Checked = false;
            if (rdoNeed.Checked == true)
            {
                pnlNoneSpec.Visible = true;
                pnlMinMax.Visible = true;
            }

        }

        private void rdoNoNeed_CheckedChanged(object sender, EventArgs e)
        {
            setMinMaxDefault();
            chkNoneSpec.Checked = false;

            if (rdoNoNeed.Checked == true)
            {
                pnlNoneSpec.Visible = false;
                pnlMinMax.Visible = false;
            }

        }

        private void chkNoneSpec_CheckedChanged(object sender, EventArgs e)
        {
            setMinMaxDefault();

            if (chkNoneSpec.Checked == true)
            {
                pnlMinMax.Visible = false;
            }
            else
            {
                pnlMinMax.Visible = true;
            }


        }

        private void setMinMaxDefault()
        {

            txtMin.Text = "";
            txtMax.Text = "";
        }

        public void clearToDefault()
        {

            rdoNeed.Checked = false;
            rdoNoNeed.Checked = false;
            this.pnlNoneSpec.Visible = false;

        }

        public static bool checkData(SettingSpec_Need_NoneSpec_MinMax toolBox)
        {
            bool result = true;

            if (toolBox.CheckNeed == false && toolBox.CheckNoNeed == false)
            {
                MessageBox.Show("กรุณาเลือก " + toolBox.HeaderLabel, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (toolBox.CheckNeed == true && toolBox.CheckNonSpec == false)
            {
                if (!double.TryParse(toolBox.SpecMin, out CommonClassLibraryGlobal.chkDouble))
                {
                    CommonClassLibraryGlobal.showError("กรุณากรอก " + toolBox.HeaderLabel + " Minimum เป็นตัวเลขเท่านั้น");

                    toolBox.txtMin.Text = "";
                    toolBox.txtMin.Focus();
                    return false;
                }

                if (!double.TryParse(toolBox.SpecMax, out CommonClassLibraryGlobal.chkDouble))
                {
                    CommonClassLibraryGlobal.showError("กรุณากรอก  " + toolBox.HeaderLabel + "  Maximum เป็นตัวเลขเท่านั้น");
                    toolBox.txtMax.Text = "";
                    toolBox.txtMax.Focus();
                    return false;
                }

                if (double.Parse(toolBox.SpecMin) > double.Parse(toolBox.SpecMax))
                {
                    CommonClassLibraryGlobal.showError("กรุณากรอก  " + toolBox.HeaderLabel + "  Minimum ให้น้อยกว่าหรือเท่ากับ  " + toolBox.HeaderLabel + "  Maximum");
                    toolBox.txtMin.Text = "";
                    toolBox.txtMax.Text = "";
                    toolBox.txtMin.Focus();
                    return false;
                }
            }

            return result;
        }


    }
}
