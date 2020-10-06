using System.Drawing;
using System.Windows.Forms;

namespace CustomUIClassLibrary
{
    public partial class SettingSpec_Text_Value : UserControl
    {
        public SettingSpec_Text_Value()
        {
            InitializeComponent();
            SetLineColor(LineColorCustom);
        }

        Color LineColorCustom = Color.White;

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
        public string HeaderLabel
        {
            get { return lblHeader.Text; }
            set { lblHeader.Text = value; }
        }


        private void SetLineColor(Color colorLayout)
        {
            this.lblHeader.ForeColor = colorLayout;
            this.panel1.BackColor = colorLayout;
            this.panel2.BackColor = colorLayout;
            this.panel3.BackColor = colorLayout;
            this.panel4.BackColor = colorLayout;
        }



    }
}
