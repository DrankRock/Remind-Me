namespace RemindMeApp
{
    partial class NewElement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewElement));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblName = new Label();
            tbName = new TextBox();
            btnContinue = new Button();
            btnCancel = new Button();
            monthCalendar1 = new MonthCalendar();
            tableLayoutPanel3 = new TableLayoutPanel();
            tbMinute = new TextBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            tbHour = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(btnContinue, 1, 2);
            tableLayoutPanel1.Controls.Add(btnCancel, 0, 2);
            tableLayoutPanel1.Controls.Add(monthCalendar1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(465, 256);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(lblName, 0, 0);
            tableLayoutPanel2.Controls.Add(tbName, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(465, 56);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(459, 21);
            lblName.TabIndex = 0;
            lblName.Text = "[name2]";
            // 
            // tbName
            // 
            tbName.Dock = DockStyle.Top;
            tbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbName.Location = new Point(3, 24);
            tbName.Name = "tbName";
            tbName.Size = new Size(459, 29);
            tbName.TabIndex = 1;
            // 
            // btnContinue
            // 
            btnContinue.Dock = DockStyle.Fill;
            btnContinue.Location = new Point(235, 230);
            btnContinue.Margin = new Padding(3, 7, 3, 3);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(227, 23);
            btnContinue.TabIndex = 9;
            btnContinue.Text = "[continue]";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += button1_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(3, 230);
            btnCancel.Margin = new Padding(3, 7, 3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(226, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "[cancel]";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button2_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Dock = DockStyle.Fill;
            monthCalendar1.Location = new Point(3, 59);
            monthCalendar1.Margin = new Padding(3);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tbMinute, 1, 1);
            tableLayoutPanel3.Controls.Add(button6, 1, 2);
            tableLayoutPanel3.Controls.Add(button5, 0, 2);
            tableLayoutPanel3.Controls.Add(button4, 1, 0);
            tableLayoutPanel3.Controls.Add(button3, 0, 0);
            tableLayoutPanel3.Controls.Add(tbHour, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(235, 59);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(227, 161);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // tbMinute
            // 
            tbMinute.Dock = DockStyle.Fill;
            tbMinute.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMinute.Location = new Point(116, 45);
            tbMinute.Name = "tbMinute";
            tbMinute.Size = new Size(108, 71);
            tbMinute.TabIndex = 5;
            tbMinute.Text = "24";
            tbMinute.TextAlign = HorizontalAlignment.Center;
            tbMinute.TextChanged += textBox2_TextChanged;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button6.Location = new Point(113, 119);
            button6.Margin = new Padding(0);
            button6.Name = "button6";
            button6.Size = new Size(114, 42);
            button6.TabIndex = 3;
            button6.Text = "V";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button5.Location = new Point(0, 119);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Size = new Size(113, 42);
            button5.TabIndex = 2;
            button5.Text = "V";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            button4.Location = new Point(113, 0);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Size = new Size(114, 42);
            button4.TabIndex = 1;
            button4.Text = "^";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            button3.Location = new Point(0, 0);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(113, 42);
            button3.TabIndex = 0;
            button3.Text = "^";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tbHour
            // 
            tbHour.Dock = DockStyle.Fill;
            tbHour.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbHour.Location = new Point(3, 45);
            tbHour.Name = "tbHour";
            tbHour.Size = new Size(107, 71);
            tbHour.TabIndex = 4;
            tbHour.Text = "24";
            tbHour.TextAlign = HorizontalAlignment.Center;
            tbHour.TextChanged += textBox1_TextChanged;
            // 
            // NewElement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 256);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(481, 295);
            MinimumSize = new Size(481, 295);
            Name = "NewElement";
            Text = "NewElement";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblName;
        private TextBox tbName;
        private Button btnContinue;
        private Button btnCancel;
        private MonthCalendar monthCalendar1;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private TextBox tbMinute;
        private TextBox tbHour;
    }
}