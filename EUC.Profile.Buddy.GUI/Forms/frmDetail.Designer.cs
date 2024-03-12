namespace EUC.Profile.Buddy.GUI.Forms
{
    partial class frmDetail
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.RosyBrown;
            button1.Location = new Point(744, 12);
            button1.Name = "button1";
            button1.Size = new Size(44, 23);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDetail";
            Text = "frmDetail";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}