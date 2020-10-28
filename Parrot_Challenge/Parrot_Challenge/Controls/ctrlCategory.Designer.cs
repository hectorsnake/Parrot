namespace Parrot_Challenge.Controls
{
	partial class ctrlCategory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlCategory));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.picDown = new System.Windows.Forms.PictureBox();
			this.picUp = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 44);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(618, 10);
			this.flowLayoutPanel1.TabIndex = 5;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(17, 14);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(35, 13);
			this.lblTitle.TabIndex = 6;
			this.lblTitle.Text = "label1";
			// 
			// picDown
			// 
			this.picDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picDown.BackgroundImage")));
			this.picDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.picDown.Location = new System.Drawing.Point(579, 5);
			this.picDown.Name = "picDown";
			this.picDown.Size = new System.Drawing.Size(50, 34);
			this.picDown.TabIndex = 7;
			this.picDown.TabStop = false;
			this.picDown.Click += new System.EventHandler(this.picDown_Click);
			// 
			// picUp
			// 
			this.picUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picUp.BackgroundImage")));
			this.picUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.picUp.Location = new System.Drawing.Point(579, 5);
			this.picUp.Name = "picUp";
			this.picUp.Size = new System.Drawing.Size(50, 34);
			this.picUp.TabIndex = 8;
			this.picUp.TabStop = false;
			this.picUp.Click += new System.EventHandler(this.picUp_Click);
			// 
			// ctrlCategory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.picUp);
			this.Controls.Add(this.picDown);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "ctrlCategory";
			this.Size = new System.Drawing.Size(641, 57);
			this.Load += new System.EventHandler(this.ctrlCategory_Load);
			((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.PictureBox picDown;
		private System.Windows.Forms.PictureBox picUp;
	}
}
