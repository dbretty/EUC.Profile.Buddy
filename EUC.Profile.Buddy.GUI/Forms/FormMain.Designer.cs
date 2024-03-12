namespace EUC.Profile.Buddy.GUI
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            NotifyMain = new NotifyIcon(components);
            ContextMain = new ContextMenuStrip(components);
            showDetailToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            btnMinimize = new Button();
            btnExit = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblProfileSize = new Label();
            lblUserName = new Label();
            lblProfileDirectory = new Label();
            dgUserProfileFolders = new DataGridView();
            Folder = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            ContextFolders = new ContextMenuStrip(components);
            drilldownToolStripMenuItem = new ToolStripMenuItem();
            backToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblCurrentDirectory = new Label();
            btnBack = new Button();
            btnHome = new Button();
            button3 = new Button();
            lblProfileType = new Label();
            label9 = new Label();
            ContextMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgUserProfileFolders).BeginInit();
            ContextFolders.SuspendLayout();
            SuspendLayout();
            // 
            // NotifyMain
            // 
            NotifyMain.BalloonTipIcon = ToolTipIcon.Info;
            NotifyMain.BalloonTipText = "Text";
            NotifyMain.BalloonTipTitle = "Baloon Title";
            NotifyMain.ContextMenuStrip = ContextMain;
            NotifyMain.Icon = (Icon)resources.GetObject("NotifyMain.Icon");
            NotifyMain.Text = "EUC Profile Thing";
            NotifyMain.MouseDoubleClick += NotifyMain_MouseDoubleClick;
            // 
            // ContextMain
            // 
            ContextMain.Items.AddRange(new ToolStripItem[] { showDetailToolStripMenuItem, exitToolStripMenuItem });
            ContextMain.Name = "ContextMain";
            ContextMain.Size = new Size(207, 48);
            // 
            // showDetailToolStripMenuItem
            // 
            showDetailToolStripMenuItem.Name = "showDetailToolStripMenuItem";
            showDetailToolStripMenuItem.Size = new Size(206, 22);
            showDetailToolStripMenuItem.Text = "Show Profile Information";
            showDetailToolStripMenuItem.Click += showDetailToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(206, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(224, 224, 224);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.FromArgb(64, 64, 64);
            btnMinimize.Location = new Point(426, 6);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 24);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "__";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(255, 128, 128);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.FromArgb(64, 64, 64);
            btnExit.Location = new Point(472, 6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(40, 24);
            btnExit.TabIndex = 2;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.profile;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(102, 41);
            label1.Name = "label1";
            label1.Size = new Size(207, 32);
            label1.TabIndex = 4;
            label1.Text = "EUC Profile Buddy";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(47, 124);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 5;
            label2.Text = "User Name: ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(48, 186);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 6;
            label3.Text = "Profile Size: ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(12, 155);
            label4.Name = "label4";
            label4.Size = new Size(130, 21);
            label4.TabIndex = 7;
            label4.Text = "Profile Directory: ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblProfileSize
            // 
            lblProfileSize.AutoSize = true;
            lblProfileSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileSize.ForeColor = Color.FromArgb(64, 64, 64);
            lblProfileSize.Location = new Point(148, 186);
            lblProfileSize.Name = "lblProfileSize";
            lblProfileSize.Size = new Size(100, 21);
            lblProfileSize.TabIndex = 8;
            lblProfileSize.Text = "lblProfileSize";
            lblProfileSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.FromArgb(64, 64, 64);
            lblUserName.Location = new Point(148, 124);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(101, 21);
            lblUserName.TabIndex = 9;
            lblUserName.Text = "lblUserName";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProfileDirectory
            // 
            lblProfileDirectory.AutoSize = true;
            lblProfileDirectory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileDirectory.ForeColor = Color.FromArgb(64, 64, 64);
            lblProfileDirectory.Location = new Point(148, 155);
            lblProfileDirectory.Name = "lblProfileDirectory";
            lblProfileDirectory.Size = new Size(136, 21);
            lblProfileDirectory.TabIndex = 10;
            lblProfileDirectory.Text = "lblProfileDirectory";
            lblProfileDirectory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgUserProfileFolders
            // 
            dgUserProfileFolders.AllowUserToAddRows = false;
            dgUserProfileFolders.AllowUserToDeleteRows = false;
            dgUserProfileFolders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUserProfileFolders.ColumnHeadersVisible = false;
            dgUserProfileFolders.Columns.AddRange(new DataGridViewColumn[] { Folder, Size });
            dgUserProfileFolders.ContextMenuStrip = ContextFolders;
            dgUserProfileFolders.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgUserProfileFolders.Location = new Point(12, 313);
            dgUserProfileFolders.MultiSelect = false;
            dgUserProfileFolders.Name = "dgUserProfileFolders";
            dgUserProfileFolders.ReadOnly = true;
            dgUserProfileFolders.RowHeadersVisible = false;
            dgUserProfileFolders.ScrollBars = ScrollBars.Vertical;
            dgUserProfileFolders.ShowEditingIcon = false;
            dgUserProfileFolders.Size = new Size(495, 332);
            dgUserProfileFolders.TabIndex = 11;
            // 
            // Folder
            // 
            Folder.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Folder.HeaderText = "Folder";
            Folder.Name = "Folder";
            Folder.ReadOnly = true;
            Folder.SortMode = DataGridViewColumnSortMode.NotSortable;
            Folder.Width = 410;
            // 
            // Size
            // 
            Size.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Size.HeaderText = "Size";
            Size.Name = "Size";
            Size.ReadOnly = true;
            Size.Width = 80;
            // 
            // ContextFolders
            // 
            ContextFolders.Items.AddRange(new ToolStripItem[] { drilldownToolStripMenuItem, backToolStripMenuItem });
            ContextFolders.Name = "ContextFolders";
            ContextFolders.Size = new Size(126, 48);
            // 
            // drilldownToolStripMenuItem
            // 
            drilldownToolStripMenuItem.Name = "drilldownToolStripMenuItem";
            drilldownToolStripMenuItem.Size = new Size(125, 22);
            drilldownToolStripMenuItem.Text = "Drilldown";
            drilldownToolStripMenuItem.Click += drilldownToolStripMenuItem_Click;
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(125, 22);
            backToolStripMenuItem.Text = "Back";
            backToolStripMenuItem.Click += backToolStripMenuItem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(9, 320);
            label5.Name = "label5";
            label5.Size = new Size(0, 21);
            label5.TabIndex = 12;
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(420, 274);
            label6.Name = "label6";
            label6.Size = new Size(0, 21);
            label6.TabIndex = 13;
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(4, 247);
            label7.Name = "label7";
            label7.Size = new Size(138, 21);
            label7.TabIndex = 14;
            label7.Text = "Current Directory: ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentDirectory
            // 
            lblCurrentDirectory.AutoSize = true;
            lblCurrentDirectory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentDirectory.ForeColor = Color.FromArgb(64, 64, 64);
            lblCurrentDirectory.Location = new Point(149, 247);
            lblCurrentDirectory.Name = "lblCurrentDirectory";
            lblCurrentDirectory.Size = new Size(144, 21);
            lblCurrentDirectory.TabIndex = 15;
            lblCurrentDirectory.Text = "lblCurrentDirectory";
            lblCurrentDirectory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.FlatAppearance.BorderColor = Color.SteelBlue;
            btnBack.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.FromArgb(64, 64, 64);
            btnBack.Location = new Point(12, 283);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(34, 24);
            btnBack.TabIndex = 16;
            btnBack.Text = "<<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.White;
            btnHome.FlatAppearance.BorderColor = Color.SteelBlue;
            btnHome.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = Color.FromArgb(64, 64, 64);
            btnHome.Location = new Point(52, 283);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(57, 24);
            btnHome.TabIndex = 17;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderColor = Color.SteelBlue;
            button3.FlatAppearance.MouseOverBackColor = Color.Silver;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(64, 64, 64);
            button3.Location = new Point(115, 283);
            button3.Name = "button3";
            button3.Size = new Size(57, 24);
            button3.TabIndex = 18;
            button3.Text = "Info";
            button3.UseVisualStyleBackColor = false;
            // 
            // lblProfileType
            // 
            lblProfileType.AutoSize = true;
            lblProfileType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileType.ForeColor = Color.FromArgb(64, 64, 64);
            lblProfileType.Location = new Point(149, 216);
            lblProfileType.Name = "lblProfileType";
            lblProfileType.Size = new Size(104, 21);
            lblProfileType.TabIndex = 20;
            lblProfileType.Text = "lblProfileType";
            lblProfileType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(64, 64, 64);
            label9.Location = new Point(44, 216);
            label9.Name = "label9";
            label9.Size = new Size(98, 21);
            label9.TabIndex = 19;
            label9.Text = "Profile Type: ";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(519, 689);
            ControlBox = false;
            Controls.Add(lblProfileType);
            Controls.Add(label9);
            Controls.Add(button3);
            Controls.Add(btnHome);
            Controls.Add(btnBack);
            Controls.Add(lblCurrentDirectory);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dgUserProfileFolders);
            Controls.Add(lblProfileDirectory);
            Controls.Add(lblUserName);
            Controls.Add(lblProfileSize);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnExit);
            Controls.Add(btnMinimize);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "EUC Profile Buddy";
            Load += FormMain_Load;
            ContextMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgUserProfileFolders).EndInit();
            ContextFolders.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NotifyIcon NotifyMain;
        private Button btnMinimize;
        private Button btnExit;
        private ContextMenuStrip ContextMain;
        private ToolStripMenuItem showDetailToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblProfileSize;
        private Label lblUserName;
        private Label lblProfileDirectory;
        private DataGridView dgUserProfileFolders;
        private DataGridViewTextBoxColumn Folder;
        private DataGridViewTextBoxColumn Size;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblCurrentDirectory;
        private Button btnBack;
        private Button btnHome;
        private Button button3;
        private ContextMenuStrip ContextFolders;
        private ToolStripMenuItem drilldownToolStripMenuItem;
        private ToolStripMenuItem backToolStripMenuItem;
        private Label lblProfileType;
        private Label label9;
    }
}
