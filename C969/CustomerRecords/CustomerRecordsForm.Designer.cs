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
            this.customerRecordsDGV = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customerRecordsLabel
            // 
            this.customerRecordsLabel.AutoSize = true;
            this.customerRecordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerRecordsLabel.Location = new System.Drawing.Point(315, 47);
            this.customerRecordsLabel.Name = "customerRecordsLabel";
            this.customerRecordsLabel.Size = new System.Drawing.Size(190, 25);
            this.customerRecordsLabel.TabIndex = 3;
            this.customerRecordsLabel.Text = "Customer Records";
            // 
            // customerRecordsDGV
            // 
            this.customerRecordsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerRecordsDGV.Location = new System.Drawing.Point(66, 102);
            this.customerRecordsDGV.Name = "customerRecordsDGV";
            this.customerRecordsDGV.RowHeadersWidth = 51;
            this.customerRecordsDGV.RowTemplate.Height = 24;
            this.customerRecordsDGV.Size = new System.Drawing.Size(671, 210);
            this.customerRecordsDGV.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(388, 352);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(86, 28);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(651, 352);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(86, 28);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(520, 352);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(86, 28);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // CustomerRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.customerRecordsLabel);
            this.Controls.Add(this.customerRecordsDGV);
            this.Name = "CustomerRecordsForm";
            this.Text = "CustomerRecords";
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customerRecordsLabel;
        private System.Windows.Forms.DataGridView customerRecordsDGV;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
    }
}