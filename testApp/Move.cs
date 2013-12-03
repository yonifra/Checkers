using System;
using System.Drawing;

namespace MainGame
{
    public class Move
    {
        #region Private Members

        private Point startingPoint;
        private Point endingPoint;
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
            isEating = Math.Abs(startingPoint.X - endingPoint.X) == 2;
            isCrowned = (cb.cmArray[startingPoint.X, startingPoint.Y]).IsKing;
            score = isEating ? 2 : 1;
        }

        public bool Any()
        {
            return myCB.GetValidMoves(startingPoint).Count != 0;
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
