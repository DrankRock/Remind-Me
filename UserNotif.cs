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
    public partial class UserNotif : Form
    {
        public UserNotif()
        {
            InitializeComponent();

            // Set the form's start position to manual
            this.StartPosition = FormStartPosition.Manual;

            // Set the location to the top-left corner of the screen
            this.Location = new Point(0, 0);

            // Set the width to the screen's width and height as desired
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = 100; // Set your desired height

            // Optional: Set other form properties
            this.Text = "Top Full Width Form";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Text = LanguageManager.GetText("ev1", UserDataManager.GetLanguage());
        }
    }
}
