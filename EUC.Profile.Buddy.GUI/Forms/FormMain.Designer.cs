﻿// <auto-generated/>
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
            deleteToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblCurrentDirectory = new Label();
            btnBack = new Button();
            btnHome = new Button();
            btnProfileDetail = new Button();
            lblProfileType = new Label();
            label9 = new Label();
            lblAppDataRoaming = new Label();
            label10 = new Label();
            lblAppDataLocal = new Label();
            label12 = new Label();
            ContextActions = new ContextMenuStrip(components);
            temporaryDataToolStripMenuItem = new ToolStripMenuItem();
            clearTToolStripMenuItem = new ToolStripMenuItem();
            browsersToolStripMenuItem = new ToolStripMenuItem();
            resetMicrosoftEdgeToolStripMenuItem = new ToolStripMenuItem();
            resetGoogleChromeToolStripMenuItem = new ToolStripMenuItem();
            cmbActions = new ComboBox();
            btnGo = new Button();
            pbMain = new ProgressBar();
            lblStatus = new Label();
            ContextMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgUserProfileFolders).BeginInit();
            ContextFolders.SuspendLayout();
            ContextActions.SuspendLayout();
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
            pictureBox1.Size = new Size(66, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(86, 25);
            label1.Name = "label1";
            label1.Size = new Size(207, 32);
            label1.TabIndex = 4;
            label1.Text = "EUC Profile Buddy";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(48, 87);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 5;
            label2.Text = "User Name: ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(52, 136);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 6;
            label3.Text = "Profile Size: ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(18, 111);
            label4.Name = "label4";
            label4.Size = new Size(114, 19);
            label4.TabIndex = 7;
            label4.Text = "Profile Directory: ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblProfileSize
            // 
            lblProfileSize.AutoSize = true;
            lblProfileSize.Font = new Font("Segoe UI", 10F);
            lblProfileSize.ForeColor = Color.FromArgb(64, 64, 64);
            lblProfileSize.Location = new Point(138, 136);
            lblProfileSize.Name = "lblProfileSize";
            lblProfileSize.Size = new Size(0, 19);
            lblProfileSize.TabIndex = 8;
            lblProfileSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 10F);
            lblUserName.ForeColor = Color.FromArgb(64, 64, 64);
            lblUserName.Location = new Point(138, 87);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(85, 19);
            lblUserName.TabIndex = 9;
            lblUserName.Text = "Please wait...";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProfileDirectory
            // 
            lblProfileDirectory.AutoSize = true;
            lblProfileDirectory.Font = new Font("Segoe UI", 10F);
            lblProfileDirectory.ForeColor = Color.FromArgb(64, 64, 64);
            lblProfileDirectory.Location = new Point(138, 111);
            lblProfileDirectory.Name = "lblProfileDirectory";
            lblProfileDirectory.Size = new Size(0, 19);
            lblProfileDirectory.TabIndex = 10;
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
            dgUserProfileFolders.Location = new Point(12, 295);
            dgUserProfileFolders.MultiSelect = false;
            dgUserProfileFolders.Name = "dgUserProfileFolders";
            dgUserProfileFolders.ReadOnly = true;
            dgUserProfileFolders.RowHeadersVisible = false;
            dgUserProfileFolders.ScrollBars = ScrollBars.Vertical;
            dgUserProfileFolders.ShowEditingIcon = false;
            dgUserProfileFolders.Size = new Size(495, 314);
            dgUserProfileFolders.TabIndex = 11;
            dgUserProfileFolders.CellDoubleClick += dgFoldersDoubleClick;
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
            ContextFolders.Items.AddRange(new ToolStripItem[] { drilldownToolStripMenuItem, backToolStripMenuItem, deleteToolStripMenuItem });
            ContextFolders.Name = "ContextFolders";
            ContextFolders.Size = new Size(126, 70);
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
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(125, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(9, 332);
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
            label6.Location = new Point(420, 286);
            label6.Name = "label6";
            label6.Size = new Size(0, 21);
            label6.TabIndex = 13;
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(11, 238);
            label7.Name = "label7";
            label7.Size = new Size(123, 19);
            label7.TabIndex = 14;
            label7.Text = "Current Directory: ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentDirectory
            // 
            lblCurrentDirectory.AutoSize = true;
            lblCurrentDirectory.Font = new Font("Segoe UI", 10F);
            lblCurrentDirectory.ForeColor = Color.FromArgb(64, 64, 64);
            lblCurrentDirectory.Location = new Point(139, 238);
            lblCurrentDirectory.Name = "lblCurrentDirectory";
            lblCurrentDirectory.Size = new Size(0, 19);
            lblCurrentDirectory.TabIndex = 15;
            lblCurrentDirectory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.FlatAppearance.BorderColor = Color.SteelBlue;
            btnBack.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.FromArgb(64, 64, 64);
            btnBack.Location = new Point(12, 265);
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
            btnHome.Location = new Point(52, 265);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(57, 24);
            btnHome.TabIndex = 17;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnProfileDetail
            // 
            btnProfileDetail.BackColor = Color.White;
            btnProfileDetail.FlatAppearance.BorderColor = Color.SteelBlue;
            btnProfileDetail.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnProfileDetail.FlatStyle = FlatStyle.Flat;
            btnProfileDetail.ForeColor = Color.FromArgb(64, 64, 64);
            btnProfileDetail.Location = new Point(115, 265);
            btnProfileDetail.Name = "btnProfileDetail";
            btnProfileDetail.Size = new Size(57, 24);
            btnProfileDetail.TabIndex = 18;
            btnProfileDetail.Text = "Info";
            btnProfileDetail.UseVisualStyleBackColor = false;
            btnProfileDetail.Click += btnProfileDetail_Click;
            // 
            // lblProfileType
            // 
            lblProfileType.AutoSize = true;
            lblProfileType.Font = new Font("Segoe UI", 10F);
            lblProfileType.ForeColor = Color.FromArgb(64, 64, 64);
            lblProfileType.Location = new Point(139, 161);
            lblProfileType.Name = "lblProfileType";
            lblProfileType.Size = new Size(0, 19);
            lblProfileType.TabIndex = 20;
            lblProfileType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.FromArgb(64, 64, 64);
            label9.Location = new Point(48, 161);
            label9.Name = "label9";
            label9.Size = new Size(86, 19);
            label9.TabIndex = 19;
            label9.Text = "Profile Type: ";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAppDataRoaming
            // 
            lblAppDataRoaming.AutoSize = true;
            lblAppDataRoaming.Font = new Font("Segoe UI", 10F);
            lblAppDataRoaming.ForeColor = Color.FromArgb(64, 64, 64);
            lblAppDataRoaming.Location = new Point(139, 212);
            lblAppDataRoaming.Name = "lblAppDataRoaming";
            lblAppDataRoaming.Size = new Size(0, 19);
            lblAppDataRoaming.TabIndex = 24;
            lblAppDataRoaming.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = Color.FromArgb(64, 64, 64);
            label10.Location = new Point(6, 212);
            label10.Name = "label10";
            label10.Size = new Size(128, 19);
            label10.TabIndex = 23;
            label10.Text = "AppData Roaming: ";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAppDataLocal
            // 
            lblAppDataLocal.AutoSize = true;
            lblAppDataLocal.Font = new Font("Segoe UI", 10F);
            lblAppDataLocal.ForeColor = Color.FromArgb(64, 64, 64);
            lblAppDataLocal.Location = new Point(139, 186);
            lblAppDataLocal.Name = "lblAppDataLocal";
            lblAppDataLocal.Size = new Size(0, 19);
            lblAppDataLocal.TabIndex = 22;
            lblAppDataLocal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.ForeColor = Color.FromArgb(64, 64, 64);
            label12.Location = new Point(29, 186);
            label12.Name = "label12";
            label12.Size = new Size(105, 19);
            label12.TabIndex = 21;
            label12.Text = "AppData Local: ";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ContextActions
            // 
            ContextActions.Items.AddRange(new ToolStripItem[] { temporaryDataToolStripMenuItem, browsersToolStripMenuItem });
            ContextActions.Name = "ContextActions";
            ContextActions.Size = new Size(158, 48);
            // 
            // temporaryDataToolStripMenuItem
            // 
            temporaryDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearTToolStripMenuItem });
            temporaryDataToolStripMenuItem.Name = "temporaryDataToolStripMenuItem";
            temporaryDataToolStripMenuItem.Size = new Size(157, 22);
            temporaryDataToolStripMenuItem.Text = "Temporary Data";
            // 
            // clearTToolStripMenuItem
            // 
            clearTToolStripMenuItem.Name = "clearTToolStripMenuItem";
            clearTToolStripMenuItem.Size = new Size(160, 22);
            clearTToolStripMenuItem.Text = "Clear TEMP Files";
            // 
            // browsersToolStripMenuItem
            // 
            browsersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetMicrosoftEdgeToolStripMenuItem, resetGoogleChromeToolStripMenuItem });
            browsersToolStripMenuItem.Name = "browsersToolStripMenuItem";
            browsersToolStripMenuItem.Size = new Size(157, 22);
            browsersToolStripMenuItem.Text = "Browsers";
            // 
            // resetMicrosoftEdgeToolStripMenuItem
            // 
            resetMicrosoftEdgeToolStripMenuItem.Name = "resetMicrosoftEdgeToolStripMenuItem";
            resetMicrosoftEdgeToolStripMenuItem.Size = new Size(189, 22);
            resetMicrosoftEdgeToolStripMenuItem.Text = "Reset Microsoft Edge";
            // 
            // resetGoogleChromeToolStripMenuItem
            // 
            resetGoogleChromeToolStripMenuItem.Name = "resetGoogleChromeToolStripMenuItem";
            resetGoogleChromeToolStripMenuItem.Size = new Size(189, 22);
            resetGoogleChromeToolStripMenuItem.Text = "Reset Google Chrome";
            // 
            // cmbActions
            // 
            cmbActions.BackColor = Color.LightGray;
            cmbActions.FlatStyle = FlatStyle.Flat;
            cmbActions.Font = new Font("Segoe UI", 12F);
            cmbActions.Location = new Point(12, 624);
            cmbActions.Name = "cmbActions";
            cmbActions.Size = new Size(453, 29);
            cmbActions.Sorted = true;
            cmbActions.TabIndex = 27;
            cmbActions.Text = "Select Action";
            // 
            // btnGo
            // 
            btnGo.BackColor = Color.White;
            btnGo.FlatAppearance.BorderColor = Color.SteelBlue;
            btnGo.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnGo.FlatStyle = FlatStyle.Flat;
            btnGo.ForeColor = Color.FromArgb(64, 64, 64);
            btnGo.Location = new Point(473, 624);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(34, 30);
            btnGo.TabIndex = 28;
            btnGo.Text = "Go";
            btnGo.UseVisualStyleBackColor = false;
            btnGo.Click += btnGo_Click;
            // 
            // pbMain
            // 
            pbMain.ForeColor = Color.SteelBlue;
            pbMain.Location = new Point(255, 661);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(252, 16);
            pbMain.Style = ProgressBarStyle.Marquee;
            pbMain.TabIndex = 29;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(64, 64, 64);
            lblStatus.Location = new Point(10, 658);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(239, 19);
            lblStatus.TabIndex = 31;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(519, 689);
            ControlBox = false;
            Controls.Add(lblStatus);
            Controls.Add(pbMain);
            Controls.Add(btnGo);
            Controls.Add(cmbActions);
            Controls.Add(lblAppDataRoaming);
            Controls.Add(label10);
            Controls.Add(lblAppDataLocal);
            Controls.Add(label12);
            Controls.Add(lblProfileType);
            Controls.Add(label9);
            Controls.Add(btnProfileDetail);
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
            ContextActions.ResumeLayout(false);
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
        private Button btnProfileDetail;
        private ContextMenuStrip ContextFolders;
        private ToolStripMenuItem drilldownToolStripMenuItem;
        private ToolStripMenuItem backToolStripMenuItem;
        private Label lblProfileType;
        private Label label9;
        private Label lblAppDataRoaming;
        private Label label10;
        private Label lblAppDataLocal;
        private Label label12;
        private ContextMenuStrip ContextActions;
        private ToolStripMenuItem temporaryDataToolStripMenuItem;
        private ToolStripMenuItem clearTToolStripMenuItem;
        private ToolStripMenuItem browsersToolStripMenuItem;
        private ToolStripMenuItem resetMicrosoftEdgeToolStripMenuItem;
        private ToolStripMenuItem resetGoogleChromeToolStripMenuItem;
        private ComboBox cmbActions;
        private Button btnGo;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ProgressBar pbMain;
        private Label lblStatus;
    }
}
