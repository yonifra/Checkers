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
	public partial class StartingForm : Form
	{
		public StartingForm()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
