using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace MainGame
{
    public class Move
    {
        #region Private Members

        private Point startingPoint;
        private Point endingPoint;
        private CheckersElements element;
        private int score;
        private bool isEating;
        private CheckersBoard myCB;
        private bool isCrowned;

        #endregion Private Members

        #region Public Methods

        public Move(Point start, Point end, CheckersBoard cb)
        {
            myCB = cb;
            startingPoint = start;
            endingPoint = end;
            element = cb.cmArray[startingPoint.X, startingPoint.Y].Type;
            isEating = (Math.Abs(startingPoint.X - endingPoint.X) == 2 ? true : false);
            isCrowned = (cb.cmArray[startingPoint.X, startingPoint.Y]).IsKing;
            if (isEating)
            {
                score = 2;
            }
            else
            {
                score = 1;
            }
        }

        public bool Any()
        {
            if (myCB.GetValidMoves(startingPoint).Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int Score
        {
            get
            {
                return score;
            }
        }

        public Point Starting
        {
            get
            {
                return startingPoint;
            }
        }

        public Point Ending
        {
            get
            {
                return endingPoint;
            }
        }

        public bool IsEating
        {
            get
            {
                return isEating;
            }
        }

        public bool IsCrowned
        {
            get
            {
                return isCrowned;
            }
        }

        #endregion Public Properties
    }
}
