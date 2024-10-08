namespace C969
{
    partial class ReportsForm
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
            this.reportsDGV = new System.Windows.Forms.DataGridView();
            this.reportsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // reportsDGV
            // 
            this.reportsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsDGV.Location = new System.Drawing.Point(75, 115);
            this.reportsDGV.Name = "reportsDGV";
            this.reportsDGV.RowHeadersWidth = 51;
            this.reportsDGV.RowTemplate.Height = 24;
            this.reportsDGV.Size = new System.Drawing.Size(651, 220);
            this.reportsDGV.TabIndex = 1;
            // 
            // reportsLabel
            // 
            this.reportsLabel.AutoSize = true;
            this.reportsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsLabel.Location = new System.Drawing.Point(327, 352);
            this.reportsLabel.Name = "reportsLabel";
            this.reportsLabel.Size = new System.Drawing.Size(86, 25);
            this.reportsLabel.TabIndex = 2;
            this.reportsLabel.Text = "Reports";
            this.reportsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportsLabel);
            this.Controls.Add(this.reportsDGV);
            this.Name = "ReportsForm";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.reportsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView reportsDGV;
        private System.Windows.Forms.Label reportsLabel;
    }
}