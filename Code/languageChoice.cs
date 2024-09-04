using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMeApp
{
    public partial class LanguageChoice : Form
    {
        string Language = UserDataManager.GetLanguage();
        public string SelectedLanguage = "";
        public LanguageChoice()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;

            btnCancel.Text = LanguageManager.GetText("cancel", Language);
            btnContinue.Text = LanguageManager.GetText("continue", Language);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            SelectedLanguage = comboBox1.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
