namespace C969
{
    partial class Home
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
            this.navBar = new System.Windows.Forms.MenuStrip();
            this.calendarMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.customerRecordsMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.navBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBar
            // 
            this.navBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.navBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarMenuButton,
            this.appointmentsMenuButton,
            this.customerRecordsMenuButton,
            this.reportsMenuButton});
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(800, 28);
            this.navBar.TabIndex = 0;
            this.navBar.Text = "Calendar";
            // 
            // calendarMenuButton
            // 
            this.calendarMenuButton.Name = "calendarMenuButton";
            this.calendarMenuButton.Size = new System.Drawing.Size(82, 24);
            this.calendarMenuButton.Text = "Calendar";
            // 
            // appointmentsMenuButton
            // 
            this.appointmentsMenuButton.Name = "appointmentsMenuButton";
            this.appointmentsMenuButton.Size = new System.Drawing.Size(117, 24);
            this.appointmentsMenuButton.Text = "Appointments";
            // 
            // customerRecordsMenuButton
            // 
            this.customerRecordsMenuButton.Name = "customerRecordsMenuButton";
            this.customerRecordsMenuButton.Size = new System.Drawing.Size(143, 24);
            this.customerRecordsMenuButton.Text = "Customer Records";
            // 
            // reportsMenuButton
            // 
            this.reportsMenuButton.Name = "reportsMenuButton";
            this.reportsMenuButton.Size = new System.Drawing.Size(74, 24);
            this.reportsMenuButton.Text = "Reports";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 422);
            this.mainPanel.TabIndex = 1;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.navBar);
            this.MainMenuStrip = this.navBar;
            this.Name = "Home";
            this.Text = "Home";
            this.navBar.ResumeLayout(false);
            this.navBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip navBar;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuButton;
        private System.Windows.Forms.ToolStripMenuItem appointmentsMenuButton;
        private System.Windows.Forms.ToolStripMenuItem customerRecordsMenuButton;
        private System.Windows.Forms.ToolStripMenuItem reportsMenuButton;
        private System.Windows.Forms.Panel mainPanel;
    }
}