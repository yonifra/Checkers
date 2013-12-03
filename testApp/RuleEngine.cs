using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MainGame
{
	sealed class RuleEngine
	{
		/// <summary>
		/// This function returns true / false according to the state of the board and the starting and ending point
		/// of the player's piece.
		/// If the move is possible the function will return "true", otherwise it will return "false".
		/// </summary>
		/// <param name="startingPoint">User's starting point</param>
		/// <param name="endPoint">The cell the user wishes to move to</param>
		/// <returns></returns>
		public bool RunEngine(Point startingPoint, Point endPoint, CheckersPiece[,] cmArray)
		{
			return true;
		}
	}
}
