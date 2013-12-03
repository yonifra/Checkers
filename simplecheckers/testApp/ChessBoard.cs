using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testApp
{
	public partial class ChessBoard : Panel
	{
		#region Members

		public static int size = 8;	// Size of board (for example, if 8 the board will be 8x8 cells)
		private Pen penBlack = new Pen(Color.FromArgb(255, 0, 0, 0));
		private Pen penWhite = new Pen(Color.FromArgb(255, 1, 1, 1));
		private Brush brushBlack = Brushes.Black;
		private Brush brushWhite = Brushes.White;
		private ChessElements[,] cmArray = new ChessElements[8, 8];

		enum ChessElements
		{
			Null,
			Pawn,
			Knight,
			Bishop,
			Rook,
			Queen,
			King,
		};

		#endregion Members

		#region Public Methods

		public ChessBoard()
		{
			InitializeComponent();

			for (int i = 2; i < 8; ++i)
			{
				for (int j = 2; j < 8; ++j)
				{
					cmArray[i, j] = ChessElements.Null;
				}
			}

			// Initialize also the rest of the board (with players)
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);

			this.BorderStyle = BorderStyle.FixedSingle;
			int cellWidth = this.Size.Width / size;

			for (int i = 1; i < size - 1; ++i)
			{
				for (int j = 1; j < size - 1; ++j)
				{
					if (i % 2 == 1)
					{
						pe.Graphics.FillRectangle(brushBlack, new Rectangle(this.Location.X * i, this.Location.Y + cellWidth * j,
							cellWidth, cellWidth));
					}
					else
					{
						pe.Graphics.FillRectangle(brushWhite, new Rectangle(this.Location.X + cellWidth * i, this.Location.Y * j,
							cellWidth, cellWidth));
					}
				}
			}
		}

		#endregion Public Methods
	}
}
