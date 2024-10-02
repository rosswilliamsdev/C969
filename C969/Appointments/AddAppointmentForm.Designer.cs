namespace C969.Appointments
{
    partial class AddAppointmentForm
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
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.appointmentTypeLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.addAppointmentsHeader = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appointmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dateDTP = new System.Windows.Forms.DateTimePicker();
            this.startTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.endTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(183, 245);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(68, 16);
            this.startTimeLabel.TabIndex = 29;
            this.startTimeLabel.Text = "Start Time";
            // 
            // appointmentTypeLabel
            // 
            this.appointmentTypeLabel.AutoSize = true;
            this.appointmentTypeLabel.Location = new System.Drawing.Point(183, 163);
            this.appointmentTypeLabel.Name = "appointmentTypeLabel";
            this.appointmentTypeLabel.Size = new System.Drawing.Size(73, 16);
            this.appointmentTypeLabel.TabIndex = 28;
            this.appointmentTypeLabel.Text = "Appt. Type";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(432, 394);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 24;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(314, 394);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 27;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(183, 291);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(65, 16);
            this.endTimeLabel.TabIndex = 26;
            this.endTimeLabel.Text = "End Time";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(183, 116);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(80, 16);
            this.customerLabel.TabIndex = 21;
            this.customerLabel.Text = "Customer ID";
            // 
            // addAppointmentsHeader
            // 
            this.addAppointmentsHeader.AutoSize = true;
            this.addAppointmentsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAppointmentsHeader.Location = new System.Drawing.Point(309, 50);
            this.addAppointmentsHeader.Name = "addAppointmentsHeader";
            this.addAppointmentsHeader.Size = new System.Drawing.Size(178, 25);
            this.addAppointmentsHeader.TabIndex = 16;
            this.addAppointmentsHeader.Text = "Add Appointment";
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(312, 113);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(193, 24);
            this.customerComboBox.TabIndex = 30;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(183, 206);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(36, 16);
            this.dateLabel.TabIndex = 34;
            this.dateLabel.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 33;
            // 
            // appointmentTypeComboBox
            // 
            this.appointmentTypeComboBox.FormattingEnabled = true;
            this.appointmentTypeComboBox.Location = new System.Drawing.Point(312, 158);
            this.appointmentTypeComboBox.Name = "appointmentTypeComboBox";
            this.appointmentTypeComboBox.Size = new System.Drawing.Size(193, 24);
            this.appointmentTypeComboBox.TabIndex = 35;
            // 
            // dateDTP
            // 
            this.dateDTP.Location = new System.Drawing.Point(314, 201);
            this.dateDTP.Name = "dateDTP";
            this.dateDTP.Size = new System.Drawing.Size(191, 22);
            this.dateDTP.TabIndex = 36;
            // 
            // startTimeDTP
            // 
            this.startTimeDTP.Location = new System.Drawing.Point(314, 240);
            this.startTimeDTP.Name = "startTimeDTP";
            this.startTimeDTP.Size = new System.Drawing.Size(191, 22);
            this.startTimeDTP.TabIndex = 37;
            // 
            // endTimeDTP
            // 
            this.endTimeDTP.Location = new System.Drawing.Point(314, 285);
            this.endTimeDTP.Name = "endTimeDTP";
            this.endTimeDTP.Size = new System.Drawing.Size(191, 22);
            this.endTimeDTP.TabIndex = 38;
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.endTimeDTP);
            this.Controls.Add(this.startTimeDTP);
            this.Controls.Add(this.dateDTP);
            this.Controls.Add(this.appointmentTypeComboBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.appointmentTypeLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.addAppointmentsHeader);
            this.Name = "AddAppointmentForm";
            this.Text = "AddAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label appointmentTypeLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label addAppointmentsHeader;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox appointmentTypeComboBox;
        private System.Windows.Forms.DateTimePicker dateDTP;
        private System.Windows.Forms.DateTimePicker startTimeDTP;
        private System.Windows.Forms.DateTimePicker endTimeDTP;
    }
}