namespace C969
{
    partial class CustomerRecordsForm
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
            this.customerRecordsLabel = new System.Windows.Forms.Label();
            this.appointmentsDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customerRecordsLabel
            // 
            this.customerRecordsLabel.AutoSize = true;
            this.customerRecordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerRecordsLabel.Location = new System.Drawing.Point(318, 59);
            this.customerRecordsLabel.Name = "customerRecordsLabel";
            this.customerRecordsLabel.Size = new System.Drawing.Size(190, 25);
            this.customerRecordsLabel.TabIndex = 3;
            this.customerRecordsLabel.Text = "Customer Records";
            // 
            // appointmentsDGV
            // 
            this.appointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDGV.Location = new System.Drawing.Point(205, 96);
            this.appointmentsDGV.Name = "appointmentsDGV";
            this.appointmentsDGV.RowHeadersWidth = 51;
            this.appointmentsDGV.RowTemplate.Height = 24;
            this.appointmentsDGV.Size = new System.Drawing.Size(391, 297);
            this.appointmentsDGV.TabIndex = 2;
            // 
            // CustomerRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customerRecordsLabel);
            this.Controls.Add(this.appointmentsDGV);
            this.Name = "CustomerRecordsForm";
            this.Text = "CustomerRecords";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customerRecordsLabel;
        private System.Windows.Forms.DataGridView appointmentsDGV;
    }
}