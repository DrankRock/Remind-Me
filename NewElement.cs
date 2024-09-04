using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMeApp
{
    public partial class NewElement : Form
    {
        public DateTime _chosen;
        DateTimePicker datePicker;
        DateTimePicker timePicker;

        public bool Continue = false;
        string Language = UserDataManager.GetLanguage();

        public NewElement()
        {
            InitializeComponent();
            tbHour.Text = "08";
            tbMinute.Text = "00";

            lblName.Text = LanguageManager.GetText("name2", Language);
            btnCancel.Text = LanguageManager.GetText("cancel", Language);
            btnContinue.Text = LanguageManager.GetText("continue", Language);
        }

        public void SetData(string name, DateTime dateTime)
        {
            tbName.Text = name;
            tbHour.Text = dateTime.Hour.ToString();
            tbMinute.Text = dateTime.Minute.ToString();
            monthCalendar1.SelectionStart = dateTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTimePicker datePicker = new DateTimePicker();
            datePicker.Show();
            Debug.WriteLine("time : \n" + datePicker.Value.ToString());
            _chosen = datePicker.Value;
        }

        public Tuple<string, DateTime> GetData()
        {
            // public DateTime(int year, int month, int day, int hour, int minute, int second);
            DateTime selectedDT = this.monthCalendar1.SelectionStart;
            DateTime dateTime = new DateTime(
                selectedDT.Year, 
                selectedDT.Month, 
                selectedDT.Day, 
                int.Parse(tbHour.Text), 
                int.Parse(tbMinute.Text), 
                0
            );

            return new Tuple<string, DateTime>(tbName.Text, dateTime);
        }

        // Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Continue
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tbName.Text.Length <= 0)
            {
                MessageBox.Show(LanguageManager.GetText("noEmpty", Language));
                return;
            }
            Continue = true;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbHour.Text = FormatNumber(tbHour.Text, 23);
        }

        public static string FormatNumber(string input, int max)
        {
            string numericString = Regex.Replace(input, @"[^\d]", "");
            int number = string.IsNullOrEmpty(numericString) ? 0 : int.Parse(numericString);
            number = Math.Clamp(number, 0, max);
            return number.ToString("D2");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tbMinute.Text = FormatNumber(tbMinute.Text, 59);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbHour.Text = (int.Parse(tbHour.Text) + 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbHour.Text = (int.Parse(tbHour.Text) - 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbMinute.Text = (int.Parse(tbMinute.Text) + 1).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbMinute.Text = (int.Parse(tbMinute.Text) - 1).ToString();

        }
    }
}
