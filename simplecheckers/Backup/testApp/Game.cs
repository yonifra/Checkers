using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainGame
{
	public partial class Game : Form
	{
		public Game()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
            if (rbHuman.Checked)
            {
                cb.Reset(CheckersElements.Black);
            }
            else
            {
                cb.Reset(CheckersElements.Red);
            }

		    statusMessage.Text = "Game reset successfully";
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(tbxName.Text))
			{
				MessageBox.Show("Please enter a name for your player", "Missing Name", MessageBoxButtons.OK);
				return;
			}

			if (!rbxAlphaBeta.Checked && !rbxMinMax.Checked && !rbRandom.Checked)
			{
				MessageBox.Show("Please choose one of the algorithms", "Missing Algorithm", MessageBoxButtons.OK);
				return;
			}

			lblPlayerName.Text = tbxName.Text;

			if (rbxMinMax.Checked)
			{
				lblPlaying.Text += "Min-Max algorithm";
			    cb.Algorithm = AlgorithmType.Minimax;
                lblAlgorithm.Text += "Minimax";
			}
			else if (rbxAlphaBeta.Checked)
			{
				lblPlaying.Text += "Alpha-Beta algorithm";
                cb.Algorithm = AlgorithmType.AlphaBeta;
                lblAlgorithm.Text += "Alpha-Beta";
			}
			else
			{
			    lblPlaying.Text += "Random Moves";
			    cb.Algorithm = AlgorithmType.Random;
			    lblAlgorithm.Text += "Random";
			}
			
			loginPanel.Visible = false;
			btnReset.Visible = true;
		    panel2.Visible = false;
			cb.Enabled = true;
		    lblVS.Visible = true;
            lblVS.BringToFront();

            if (rbEasy.Checked)
            {
                cb.SetDepth(0);
                lblDifficulty.Text += " Easy";
            }
            else if (rbMedium.Checked)
            {
                cb.SetDepth(1);
                lblDifficulty.Text += " Medium";
            }
            else
            {
                cb.SetDepth(2);
                lblDifficulty.Text += " Hard";
            }

            if (rbHuman.Checked)
            {
                cb.Reset(CheckersElements.Black);
            }
            else
            {
                cb.Reset(CheckersElements.Red);
            }
		}
	}
}
