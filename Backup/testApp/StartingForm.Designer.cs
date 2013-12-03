namespace MainGame
{
	partial class StartingForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbEasy = new System.Windows.Forms.RadioButton();
			this.rbMedium = new System.Windows.Forms.RadioButton();
			this.rbHard = new System.Windows.Forms.RadioButton();
			this.lblName = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblColor = new System.Windows.Forms.Label();
			this.rbWhite = new System.Windows.Forms.RadioButton();
			this.rbBlack = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.lblName);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(384, 124);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Player Information";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(13, 229);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(249, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(268, 229);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Exit";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(7, 20);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(61, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Your name:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(77, 20);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(301, 20);
			this.textBox1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rbBlack);
			this.panel1.Controls.Add(this.rbWhite);
			this.panel1.Controls.Add(this.lblColor);
			this.panel1.Location = new System.Drawing.Point(6, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(371, 47);
			this.panel1.TabIndex = 2;
			// 
			// lblColor
			// 
			this.lblColor.AutoSize = true;
			this.lblColor.Location = new System.Drawing.Point(4, 4);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(79, 13);
			this.lblColor.TabIndex = 0;
			this.lblColor.Text = "Preferred color:";
			// 
			// rbWhite
			// 
			this.rbWhite.AutoSize = true;
			this.rbWhite.Location = new System.Drawing.Point(90, 4);
			this.rbWhite.Name = "rbWhite";
			this.rbWhite.Size = new System.Drawing.Size(53, 17);
			this.rbWhite.TabIndex = 1;
			this.rbWhite.TabStop = true;
			this.rbWhite.Text = "White";
			this.rbWhite.UseVisualStyleBackColor = true;
			// 
			// rbBlack
			// 
			this.rbBlack.AutoSize = true;
			this.rbBlack.Location = new System.Drawing.Point(90, 27);
			this.rbBlack.Name = "rbBlack";
			this.rbBlack.Size = new System.Drawing.Size(52, 17);
			this.rbBlack.TabIndex = 2;
			this.rbBlack.TabStop = true;
			this.rbBlack.Text = "Black";
			this.rbBlack.UseVisualStyleBackColor = true;
			// 
			// StartingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 256);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Name = "StartingForm";
			this.Text = "Welcome Screen";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbHard;
		private System.Windows.Forms.RadioButton rbMedium;
		private System.Windows.Forms.RadioButton rbEasy;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbBlack;
		private System.Windows.Forms.RadioButton rbWhite;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.TextBox textBox1;
	}
}