using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using RemindMeApp.Properties;

namespace RemindMeApp
{
    public partial class Form1 : Form
    {

        Icon currentIcon = Resources.Rwhite;
        private NotifyIcon notifyIcon;
        DateTime LastWarning;
        private System.Windows.Forms.Timer notificationTimer;
        string Language = UserDataManager.GetLanguage();

        public Form1()
        {
            InitializeComponent();
            LanguageManager.LoadDefaultTexts();
            this.Text = LanguageManager.GetText("name", Language);

            Logger.WriteLog("Launch program");
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Resources.RRed;

            notifyIcon.Text = LanguageManager.GetText("name", Language);
            notifyIcon.Visible = true;

            notificationTimer = new System.Windows.Forms.Timer();
            notificationTimer.Interval = 1800000;
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem(LanguageManager.GetText("exit", Language));
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem(LanguageManager.GetText("open", Language));
            exitMenuItem.Click += ExitMenuItem_Click;
            openMenuItem.Click += NotifyIcon_DoubleClick;
            contextMenu.Items.Add(openMenuItem);
            contextMenu.Items.Add(exitMenuItem);
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            // Handle the SizeChanged event
            flowLayoutPanel1.SizeChanged += (sender, e) =>
            {
                // Adjust the width of all controls to match the FlowLayoutPanel's client width
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    control.Width = flowLayoutPanel1.ClientSize.Width - 6;
                }
            };

            settingsToolStripMenuItem.Text = LanguageManager.GetText("settings", Language);
            languageToolStripMenuItem.Text = LanguageManager.GetText("lang", Language);
            aboutToolStripMenuItem.Text = LanguageManager.GetText("about", Language);

            ResetStatus();

            if (todayHappens.Count == 0)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ExitMenuItem_Click(object? sender, EventArgs e)
        {
            forceClose = true;
            Application.Exit();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            ResetStatus();
        }

        private void ShowNotification(string title, string message, ToolTipIcon icon)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipIcon = icon;
            notifyIcon.ShowBalloonTip(5000);
        }

        private void OpenUserWarning()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(LanguageManager.GetText("fol1", Language));
            foreach (Element element in todayHappens)
            {
                sb.Append(element.GetName());
                sb.Append("\n");
            }
            ShowNotification(LanguageManager.GetText("ev1", Language), sb.ToString(), ToolTipIcon.Info);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewElement newElement = new NewElement();
            newElement.Icon = currentIcon;
            newElement.Location = Location;
            newElement.ShowDialog();
            if (newElement.Continue)
            {
                Element element = new Element();
                Tuple<string, DateTime> tu = newElement.GetData();
                element.SetData(tu.Item1, tu.Item2);
                element.Width = flowLayoutPanel1.ClientSize.Width - 6;

                element.Edit += Element_Edit;
                element.Delete += Element_Delete;

                UserDataManager.WriteData(tu.Item1, tu.Item2);
                ResetStatus();
                Logger.WriteLog($"NewElement: {tu.Item1}, {tu.Item2.ToString()}");
            }



        }

        private void Element_Delete(object? sender, EventArgs e)
        {
            var element = sender as Element;
            UserDataManager.RemoveData(element.GetName(), element.GetDateTime());
            Logger.WriteLog("Deleted element : " + element.GetName());
            ResetStatus();
        }

        private void Element_Edit(object? sender, EventArgs e)
        {
            Element senderr = sender as Element;
            NewElement newElement = new NewElement();
            newElement.SetData(senderr.GetName(), senderr.GetDateTime());
            newElement.Icon = currentIcon;
            newElement.ShowDialog();
            if (newElement.Continue)
            {
                var newData = newElement.GetData();
                UserDataManager.ModifyData(senderr.GetName(), senderr.GetDateTime(), newData.Item1, newData.Item2);
                Logger.WriteLog(
                    "Edited element from " +
                    senderr.GetName() + ", " + senderr.GetDateTime().ToString() + "" +
                    "to" +
                    newData.Item1 + ", " + newData.Item2
                );
                senderr.SetData(newData.Item1, newData.Item2);
                ResetStatus();

            }
        }
        List<Element> todayHappens = new List<Element>();
        // Reset status of the app
        private void ResetStatus()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            // is any date today ?
            todayHappens = new List<Element>();

            var data = UserDataManager.ReadData();
            foreach (string key in data.Keys)
            {
                Element element = new Element();

                DateTime date = data[key];
                bool thisIsToday = date.Date == DateTime.Now.Date;
                if (thisIsToday)
                {
                    todayHappens.Add(element);
                }

                element.SetData(key, data[key], thisIsToday);
                element.Width = flowLayoutPanel1.ClientSize.Width - 6;

                element.Edit += Element_Edit;
                element.Delete += Element_Delete;

                this.flowLayoutPanel1.Controls.Add(element);
            }

            if (ThemeHelper.IsDarkMode())
            {
                currentIcon = Resources.Rwhite;
            }
            else
            {
                currentIcon = Resources.RBlack;
            }


            // if any event happens today, warn the user
            if (todayHappens.Count > 0)
            {
                currentIcon = Resources.RRed;
                Logger.WriteLog("events happen today :");
                foreach (Element element in todayHappens)
                {
                    Logger.WriteLog(element.GetName());
                }
                OpenUserWarning();
            }

            this.Icon = currentIcon;

            flowLayoutPanel1.ResumeLayout();
            Logger.WriteLog("Reset Status");
        }
        bool forceClose = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (forceClose || todayHappens.Count == 0)
            {
                Logger.WriteLog("Exit");
            } else
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        // Event handler for NotifyIcon double-click
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageChoice languageChoice = new LanguageChoice();
            languageChoice.Location = Location;
            languageChoice.ShowDialog();
            if (languageChoice.SelectedLanguage != "")
            {
                UserDataManager.SetLanguage(languageChoice.SelectedLanguage);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGitHubPage();
        }

        // Function to open a URL in the default browser
        public static void OpenGitHubPage()
        {
            string url = "https://github.com/DrankRock/Remind-Me";

            try
            {
                // Start the process to open the URL
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // UseShellExecute must be true to open URLs in .NET Core
                });
            }
            catch (Exception ex)
            {
                Logger.WriteLog("An error occurred while trying to open the URL: " + ex.Message);
            }
        }
    }
}
