using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomUIClassLibrary
{
    public partial class SettingSpec_Need_NoneSpec : UserControl
    {
        public SettingSpec_Need_NoneSpec()
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

            if (rdoNeed.Checked == true)
            {
                pnlNoneSpec.Visible = true;
            }

        }

        private void rdoNoNeed_CheckedChanged(object sender, EventArgs e)
        {

            if (rdoNoNeed.Checked == true)
            {
                pnlNoneSpec.Visible = false;
            }

        }

        public void clearToDefault()
        {

            rdoNeed.Checked = false;
            rdoNoNeed.Checked = false;
            this.pnlNoneSpec.Visible = false;

        }

        public static bool checkData(SettingSpec_Need_NoneSpec toolBox)
        {
            bool result = true;

            if (toolBox.CheckNeed == false && toolBox.CheckNoNeed == false)
            {
                MessageBox.Show("กรุณาเลือก " + toolBox.HeaderLabel, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return result;
        }

    }
}
