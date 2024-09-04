using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RemindMeApp
{
    public partial class Element : UserControl
    {
        private string _Name;
        private DateTime _DateTime;
        string Language = UserDataManager.GetLanguage();
        public Element()
        {
            InitializeComponent();
            _Name = "Example";
            _DateTime = DateTime.Now;

            lblName.Text = _Name;
            lblDate.Text = _DateTime.Date.ToString();
            lblTime.Text = _DateTime.Hour.ToString() + ":" + _DateTime.Minute.ToString();
        }

        public void SetData(string name, DateTime dateTime, bool isRed= false)
        {
            TimeSpan ts = dateTime - DateTime.Now;

            lblName.Text = name;
            lblDate.Text = dateTime.Year+"/"+dateTime.Month+"/"+dateTime.Day+"\n"+ LanguageManager.GetText("in", Language) + ts.Days+ LanguageManager.GetText("days", Language);
            lblTime.Text = dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
            _Name = name;
            _DateTime = dateTime;

            if (isRed)
            {
               tableLayoutPanel1.BackColor = Color.Red;
            }
        }

        public string GetName()
        {
            return _Name;
        }

        public DateTime GetDateTime()
        {
            return _DateTime;
        }

        public event EventHandler Edit;
        private void button1_Click(object sender, EventArgs e)
        {
            Edit?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler Delete;
        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show(LanguageManager.GetText("del1", Language), LanguageManager.GetText("conf1", Language), MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes) { 
                Delete?.Invoke(this, EventArgs.Empty); 
            }

        }
    }
}
