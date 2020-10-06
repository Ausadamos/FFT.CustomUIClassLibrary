using CommonClassLibrary;
using System.Drawing;
using System.Windows.Forms;

namespace CustomUIClassLibrary
{
    public partial class SettingSpec_Text_Value_Without_Panel : UserControl
    {
        public SettingSpec_Text_Value_Without_Panel()
        {
            InitializeComponent();
        }

        Color HeaderLabelColor = Color.White;
        Image PictureBoxOption;
        bool isNumeric = false;

        public string HeaderLabel
        {
            get { return lblHeader.Text; }
            set { lblHeader.Text = value; }
        }

        public string TextBoxValue
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        public bool CheckIsNumeric
        {
            get { return isNumeric; }
            set { isNumeric = value; }
        }

        public Color HeaderColor
        {
            get { return HeaderLabelColor; }
            set
            {
                HeaderLabelColor = value;
                SetHeaderColor(HeaderLabelColor);
            }

        }

        public Image PictureOption
        {
            get
            {
                return PictureBoxOption;
            }
            set
            {
                PictureBoxOption = value;
                SetPictureOption(PictureBoxOption);
            }

        }

        private void SetHeaderColor(Color colorLayout)
        {
            this.lblHeader.ForeColor = colorLayout;
        }

        private void SetPictureOption(Image pic)
        {
            this.picOption.Image = pic;
        }

        public static bool checkData(SettingSpec_Text_Value_Without_Panel toolBox)
        {
            bool result = true;

            if (toolBox.CheckIsNumeric)
            {
                if (!string.IsNullOrWhiteSpace(toolBox.txtValue.Text))
                {
                    if (!double.TryParse(toolBox.txtValue.Text, out CommonClassLibraryGlobal.chkDouble))
                    {
                        CommonClassLibraryGlobal.showError("กรุณากรอก  " + toolBox.HeaderLabel + " เป็นตัวเลขเท่านั้น");
                        toolBox.txtValue.Text = "";
                        toolBox.txtValue.Focus();
                        return false;
                    }
                }
            }

            return result;
        }

        public void clearToDefault()
        {
            txtValue.Text = "";
        }

    }
}
