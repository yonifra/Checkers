namespace MainGame
{
	partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbStats = new System.Windows.Forms.GroupBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbComputer = new System.Windows.Forms.RadioButton();
            this.rbHuman = new System.Windows.Forms.RadioButton();
            this.lblWhosStarting = new System.Windows.Forms.Label();
            this.lblVS = new System.Windows.Forms.Label();
            this.lblPlaying = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.rbxAlphaBeta = new System.Windows.Forms.RadioButton();
            this.rbxMinMax = new System.Windows.Forms.RadioButton();
            this.lblChoose = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.cb = new MainGame.CheckersBoard();
            this.groupBox1.SuspendLayout();
            this.gbStats.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(7, 502);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(162, 32);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset Game";
            this.tooltip.SetToolTip(this.btnReset, "Starts a new game");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbStats);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(565, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 586);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";
            // 
            // gbStats
            // 
            this.gbStats.Controls.Add(this.infoPanel);
            this.gbStats.Controls.Add(this.panel2);
            this.gbStats.Controls.Add(this.lblVS);
            this.gbStats.Controls.Add(this.lblPlaying);
            this.gbStats.Controls.Add(this.lblPlayerName);
            this.gbStats.Controls.Add(this.loginPanel);
            this.gbStats.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.gbStats.Location = new System.Drawing.Point(7, 20);
            this.gbStats.Name = "gbStats";
            this.gbStats.Size = new System.Drawing.Size(163, 476);
            this.gbStats.TabIndex = 2;
            this.gbStats.TabStop = false;
            this.gbStats.Text = "Your Stats";
            // 
            // infoPanel
            // 
            this.infoPanel.BackgroundImage = global::MainGame.Properties.Resources.panel;
            this.infoPanel.Controls.Add(this.lblAlgorithm);
            this.infoPanel.Controls.Add(this.lblDifficulty);
            this.infoPanel.Location = new System.Drawing.Point(3, 401);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(160, 75);
            this.infoPanel.TabIndex = 6;
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.BackColor = System.Drawing.Color.Transparent;
            this.lblAlgorithm.ForeColor = System.Drawing.Color.White;
            this.lblAlgorithm.Location = new System.Drawing.Point(5, 40);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(86, 19);
            this.lblAlgorithm.TabIndex = 6;
            this.lblAlgorithm.Text = "Algorithm: ";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.lblDifficulty.ForeColor = System.Drawing.Color.White;
            this.lblDifficulty.Location = new System.Drawing.Point(5, 12);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(74, 19);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "Difficulty:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbComputer);
            this.panel2.Controls.Add(this.rbHuman);
            this.panel2.Controls.Add(this.lblWhosStarting);
            this.panel2.Location = new System.Drawing.Point(6, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 72);
            this.panel2.TabIndex = 6;
            // 
            // rbComputer
            // 
            this.rbComputer.AutoSize = true;
            this.rbComputer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbComputer.Location = new System.Drawing.Point(12, 46);
            this.rbComputer.Name = "rbComputer";
            this.rbComputer.Size = new System.Drawing.Size(127, 21);
            this.rbComputer.TabIndex = 6;
            this.rbComputer.TabStop = true;
            this.rbComputer.Text = "Computer (Black)";
            this.rbComputer.UseVisualStyleBackColor = true;
            // 
            // rbHuman
            // 
            this.rbHuman.AutoSize = true;
            this.rbHuman.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbHuman.Location = new System.Drawing.Point(12, 22);
            this.rbHuman.Name = "rbHuman";
            this.rbHuman.Size = new System.Drawing.Size(82, 21);
            this.rbHuman.TabIndex = 5;
            this.rbHuman.TabStop = true;
            this.rbHuman.Text = "You (Red)";
            this.rbHuman.UseVisualStyleBackColor = true;
            // 
            // lblWhosStarting
            // 
            this.lblWhosStarting.AutoSize = true;
            this.lblWhosStarting.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhosStarting.Location = new System.Drawing.Point(3, 0);
            this.lblWhosStarting.Name = "lblWhosStarting";
            this.lblWhosStarting.Size = new System.Drawing.Size(99, 18);
            this.lblWhosStarting.TabIndex = 4;
            this.lblWhosStarting.Text = "Who\'s Starting";
            // 
            // lblVS
            // 
            this.lblVS.AutoSize = true;
            this.lblVS.Location = new System.Drawing.Point(46, 49);
            this.lblVS.Name = "lblVS";
            this.lblVS.Size = new System.Drawing.Size(27, 19);
            this.lblVS.TabIndex = 2;
            this.lblVS.Text = "vs.";
            this.lblVS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVS.Visible = false;
            // 
            // lblPlaying
            // 
            this.lblPlaying.AutoSize = true;
            this.lblPlaying.Location = new System.Drawing.Point(5, 78);
            this.lblPlaying.Name = "lblPlaying";
            this.lblPlaying.Size = new System.Drawing.Size(0, 19);
            this.lblPlaying.TabIndex = 1;
            this.lblPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(5, 21);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(0, 19);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.panel3);
            this.loginPanel.Controls.Add(this.panel1);
            this.loginPanel.Controls.Add(this.btnStart);
            this.loginPanel.Controls.Add(this.lblName);
            this.loginPanel.Controls.Add(this.tbxName);
            this.loginPanel.Location = new System.Drawing.Point(6, 21);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(156, 374);
            this.loginPanel.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbHard);
            this.panel3.Controls.Add(this.rbMedium);
            this.panel3.Controls.Add(this.rbEasy);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 103);
            this.panel3.TabIndex = 7;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbHard.Location = new System.Drawing.Point(10, 73);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(55, 21);
            this.rbHard.TabIndex = 7;
            this.rbHard.TabStop = true;
            this.rbHard.Text = "Hard";
            this.tooltip.SetToolTip(this.rbHard, "Depth = 2");
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbMedium.Location = new System.Drawing.Point(10, 46);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(75, 21);
            this.rbMedium.TabIndex = 6;
            this.rbMedium.TabStop = true;
            this.rbMedium.Text = "Medium";
            this.tooltip.SetToolTip(this.rbMedium, "Depth = 1");
            this.rbMedium.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbEasy.Location = new System.Drawing.Point(10, 21);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(53, 21);
            this.rbEasy.TabIndex = 5;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "Easy";
            this.tooltip.SetToolTip(this.rbEasy, "Depth = 0");
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game Difficulty";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbRandom);
            this.panel1.Controls.Add(this.rbxAlphaBeta);
            this.panel1.Controls.Add(this.rbxMinMax);
            this.panel1.Controls.Add(this.lblChoose);
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 99);
            this.panel1.TabIndex = 5;
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbRandom.Location = new System.Drawing.Point(12, 76);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(119, 21);
            this.rbRandom.TabIndex = 7;
            this.rbRandom.TabStop = true;
            this.rbRandom.Text = "Random Moves";
            this.tooltip.SetToolTip(this.rbRandom, "Computer plays random allowed moves");
            this.rbRandom.UseVisualStyleBackColor = true;
            // 
            // rbxAlphaBeta
            // 
            this.rbxAlphaBeta.AutoSize = true;
            this.rbxAlphaBeta.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbxAlphaBeta.Location = new System.Drawing.Point(12, 49);
            this.rbxAlphaBeta.Name = "rbxAlphaBeta";
            this.rbxAlphaBeta.Size = new System.Drawing.Size(91, 21);
            this.rbxAlphaBeta.TabIndex = 6;
            this.rbxAlphaBeta.TabStop = true;
            this.rbxAlphaBeta.Text = "Alpha-Beta";
            this.tooltip.SetToolTip(this.rbxAlphaBeta, "Use Alpha-Beta algorithm");
            this.rbxAlphaBeta.UseVisualStyleBackColor = true;
            // 
            // rbxMinMax
            // 
            this.rbxMinMax.AutoSize = true;
            this.rbxMinMax.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.rbxMinMax.Location = new System.Drawing.Point(12, 22);
            this.rbxMinMax.Name = "rbxMinMax";
            this.rbxMinMax.Size = new System.Drawing.Size(78, 21);
            this.rbxMinMax.TabIndex = 5;
            this.rbxMinMax.TabStop = true;
            this.rbxMinMax.Text = "Min-Max";
            this.tooltip.SetToolTip(this.rbxMinMax, "Use Minimax Algorithm");
            this.rbxMinMax.UseVisualStyleBackColor = true;
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoose.Location = new System.Drawing.Point(3, 0);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(123, 18);
            this.lblChoose.TabIndex = 4;
            this.lblChoose.Text = "Choose Algorithm:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(3, 340);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(144, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Game!";
            this.tooltip.SetToolTip(this.btnStart, "Click to start game using the above settings");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 18);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Your Name:";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(2, 21);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(135, 23);
            this.tbxName.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnExit.Image = global::MainGame.Properties.Resources.cancel;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(7, 538);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(162, 42);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit Game";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tooltip.SetToolTip(this.btnExit, "Exit Checkers");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage});
            this.statusStrip.Location = new System.Drawing.Point(0, 564);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(565, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(39, 17);
            this.statusMessage.Text = "Ready";
            // 
            // cb
            // 
            this.cb.Algorithm = MainGame.AlgorithmType.Minimax;
            this.cb.BackColor = System.Drawing.Color.White;
            this.cb.BackgroundImage = global::MainGame.Properties.Resources.checkers;
            this.cb.BlackCount = 12;
            this.cb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cb.currentCP = null;
            this.cb.Enabled = false;
            this.cb.Location = new System.Drawing.Point(0, 0);
            this.cb.Name = "cb";
            this.cb.NowPlaying = MainGame.CheckersElements.Black;
            this.cb.RedCount = 12;
            this.cb.Size = new System.Drawing.Size(560, 560);
            this.cb.TabIndex = 2;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 586);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Checkers Game - V0.5 - Dec. 12, 2010";
            this.groupBox1.ResumeLayout(false);
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnExit;
		private CheckersBoard cb;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusMessage;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox tbxName;
		private System.Windows.Forms.Panel loginPanel;
		private System.Windows.Forms.GroupBox gbStats;
		private System.Windows.Forms.Label lblPlayerName;
		private System.Windows.Forms.Label lblPlaying;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblChoose;
		private System.Windows.Forms.RadioButton rbxAlphaBeta;
		private System.Windows.Forms.RadioButton rbxMinMax;
        private System.Windows.Forms.Label lblVS;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbComputer;
        private System.Windows.Forms.RadioButton rbHuman;
        private System.Windows.Forms.Label lblWhosStarting;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbRandom;
	}
}

