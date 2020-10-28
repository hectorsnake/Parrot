namespace Parrot_Challenge.Controls
{
	partial class ctrlProduct
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
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.imgMain = new System.Windows.Forms.PictureBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblPrice = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.chkStatus = new System.Windows.Forms.CheckBox();
			this.lblCategory = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
			this.SuspendLayout();
			// 
			// imgMain
			// 
			this.imgMain.Location = new System.Drawing.Point(19, 3);
			this.imgMain.Name = "imgMain";
			this.imgMain.Size = new System.Drawing.Size(155, 158);
			this.imgMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgMain.TabIndex = 0;
			this.imgMain.TabStop = false;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(194, 23);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name";
			// 
			// lblPrice
			// 
			this.lblPrice.AutoSize = true;
			this.lblPrice.Location = new System.Drawing.Point(194, 53);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(31, 13);
			this.lblPrice.TabIndex = 2;
			this.lblPrice.Text = "Price";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(194, 84);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(37, 13);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "Status";
			// 
			// chkStatus
			// 
			this.chkStatus.AutoSize = true;
			this.chkStatus.Location = new System.Drawing.Point(255, 84);
			this.chkStatus.Name = "chkStatus";
			this.chkStatus.Size = new System.Drawing.Size(56, 17);
			this.chkStatus.TabIndex = 4;
			this.chkStatus.Text = "Status";
			this.chkStatus.UseVisualStyleBackColor = true;
			this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Location = new System.Drawing.Point(194, 3);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(49, 13);
			this.lblCategory.TabIndex = 5;
			this.lblCategory.Text = "Category";
			// 
			// ctrlProduct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblCategory);
			this.Controls.Add(this.chkStatus);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblPrice);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.imgMain);
			this.Name = "ctrlProduct";
			this.Size = new System.Drawing.Size(425, 166);
			((System.ComponentModel.ISupportInitialize)(this.imgMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imgMain;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.CheckBox chkStatus;
		private System.Windows.Forms.Label lblCategory;
	}
}
