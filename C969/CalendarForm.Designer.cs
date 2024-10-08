namespace C969
{
    partial class CalendarForm
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.appointmentsDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(44, 98);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // appointmentsDGV
            // 
            this.appointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDGV.Location = new System.Drawing.Point(406, 98);
            this.appointmentsDGV.Name = "appointmentsDGV";
            this.appointmentsDGV.RowHeadersWidth = 51;
            this.appointmentsDGV.RowTemplate.Height = 24;
            this.appointmentsDGV.Size = new System.Drawing.Size(363, 207);
            this.appointmentsDGV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(498, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "View Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Date";
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appointmentsDGV);
            this.Controls.Add(this.calendar);
            this.Name = "CalendarForm";
            this.Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DataGridView appointmentsDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}