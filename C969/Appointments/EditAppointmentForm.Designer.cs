namespace C969.Appointments
{
    partial class EditAppointmentForm
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
            this.editAppointmentHeader = new System.Windows.Forms.Label();
            this.endTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.startTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.dateDTP = new System.Windows.Forms.DateTimePicker();
            this.appointmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.appointmentTypeLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editAppointmentHeader
            // 
            this.editAppointmentHeader.AutoSize = true;
            this.editAppointmentHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAppointmentHeader.Location = new System.Drawing.Point(308, 48);
            this.editAppointmentHeader.Name = "editAppointmentHeader";
            this.editAppointmentHeader.Size = new System.Drawing.Size(176, 25);
            this.editAppointmentHeader.TabIndex = 31;
            this.editAppointmentHeader.Text = "Edit Appointment";
            // 
            // endTimeDTP
            // 
            this.endTimeDTP.Location = new System.Drawing.Point(315, 275);
            this.endTimeDTP.Name = "endTimeDTP";
            this.endTimeDTP.Size = new System.Drawing.Size(191, 22);
            this.endTimeDTP.TabIndex = 54;
            // 
            // startTimeDTP
            // 
            this.startTimeDTP.Location = new System.Drawing.Point(315, 230);
            this.startTimeDTP.Name = "startTimeDTP";
            this.startTimeDTP.Size = new System.Drawing.Size(191, 22);
            this.startTimeDTP.TabIndex = 53;
            // 
            // dateDTP
            // 
            this.dateDTP.Location = new System.Drawing.Point(315, 191);
            this.dateDTP.Name = "dateDTP";
            this.dateDTP.Size = new System.Drawing.Size(191, 22);
            this.dateDTP.TabIndex = 52;
            // 
            // appointmentTypeComboBox
            // 
            this.appointmentTypeComboBox.FormattingEnabled = true;
            this.appointmentTypeComboBox.Location = new System.Drawing.Point(313, 148);
            this.appointmentTypeComboBox.Name = "appointmentTypeComboBox";
            this.appointmentTypeComboBox.Size = new System.Drawing.Size(193, 24);
            this.appointmentTypeComboBox.TabIndex = 51;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(184, 196);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(36, 16);
            this.dateLabel.TabIndex = 50;
            this.dateLabel.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 49;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(184, 235);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(68, 16);
            this.startTimeLabel.TabIndex = 46;
            this.startTimeLabel.Text = "Start Time";
            // 
            // appointmentTypeLabel
            // 
            this.appointmentTypeLabel.AutoSize = true;
            this.appointmentTypeLabel.Location = new System.Drawing.Point(184, 153);
            this.appointmentTypeLabel.Name = "appointmentTypeLabel";
            this.appointmentTypeLabel.Size = new System.Drawing.Size(73, 16);
            this.appointmentTypeLabel.TabIndex = 45;
            this.appointmentTypeLabel.Text = "Appt. Type";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(433, 385);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 41;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(315, 385);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 42;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 44;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(184, 281);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(65, 16);
            this.endTimeLabel.TabIndex = 43;
            this.endTimeLabel.Text = "End Time";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(184, 107);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(104, 16);
            this.customerLabel.TabIndex = 39;
            this.customerLabel.Text = "Customer Name";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(315, 101);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(193, 22);
            this.customerNameTextBox.TabIndex = 55;
            // 
            // EditAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customerNameTextBox);
            this.Controls.Add(this.endTimeDTP);
            this.Controls.Add(this.startTimeDTP);
            this.Controls.Add(this.dateDTP);
            this.Controls.Add(this.appointmentTypeComboBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.appointmentTypeLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.editAppointmentHeader);
            this.Name = "EditAppointmentForm";
            this.Text = "EditAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label editAppointmentHeader;
        private System.Windows.Forms.DateTimePicker endTimeDTP;
        private System.Windows.Forms.DateTimePicker startTimeDTP;
        private System.Windows.Forms.DateTimePicker dateDTP;
        private System.Windows.Forms.ComboBox appointmentTypeComboBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label appointmentTypeLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.TextBox customerNameTextBox;
    }
}