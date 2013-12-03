using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace MainGame
{
    public partial class CheckersBoard : Panel, ICloneable
    {
        #region Members

        public static int size = 8;	// Size of board (for example, if 8 the board will be 8x8 cells

        private Pen penBlack = new Pen(Color.FromArgb(255, 0, 0, 0));
        private Pen penWhite = new Pen(Color.FromArgb(255, 1, 1, 1));
        private Brush brushBlack = Brushes.SaddleBrown;
        public CheckersPiece[,] cmArray = new CheckersPiece[8, 8];
        private int cellSize;
        private CheckersElements nowPlaying;
        private CheckersElements human = CheckersElements.Red;
        private CheckersElements ai = CheckersElements.Black;
        private int redCount = 12;
        private int blackCount = 12;
        private AlgorithmType algorithm;
        private int maxDepth;

        #endregion Members

        #region Public Properties

        public CheckersPiece currentCP { get; set; }
        public List<CheckersPiece> allowedCPieces;
        public CheckersElements NowPlaying
        {
            get
            {
                return nowPlaying;
            }
            set
            {
                nowPlaying = value;
            }
        }

        public int RedCount
        {
            get
            {
                return redCount;
            }
            set
            {
                redCount = value;
                CheckCounts();
            }
        }

        public int BlackCount
        {
            get
            {
                return blackCount;
            }
            set
            {
                blackCount = value;
                CheckCounts();
            }
        }

        public AlgorithmType Algorithm
        {
            get { return algorithm; }
            set { algorithm = value; }
        }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Initializes the array that represents the array of chess elements
        /// on the board.
        /// </summary>
        private void InitializeElementsArray()
        {
            // Populating checkers board
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if ((i + j) % 2 == 1)
                    {
                        if (j < 3)
                        {
                            // If we're looking at the upper side of the board
                            cmArray[i, j] = new CheckersPiece(CheckersElements.Black, new Point(i, j), this);
                            cmArray[i, j].IsKing = false;
                            cmArray[i, j].IsAlive = true;
                        }
                        else if (j > 4)
                        {
                            // If we're looking at the bottom side of the board
                            cmArray[i, j] = new CheckersPiece(CheckersElements.Red, new Point(i, j), this);
                            cmArray[i, j].IsKing = false;
                            cmArray[i, j].IsAlive = true;
                        }
                        else
                        {
                            cmArray[i, j] = new CheckersPiece(CheckersElements.Null, new Point(i, j), this);
                            cmArray[i, j].IsKing = false;
                            cmArray[i, j].IsAlive = false;
                            cmArray[i, j].Visible = false;
                        }
                    }
                    else
                    {
                        cmArray[i, j] = null; // White cell, will never be used
                    }
                }
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (cmArray[i, j] != null && cmArray[i, j].Type == nowPlaying)
                    {
                        Point curpoint = GetArrayCoordinates(cmArray[i, j].Location);

                        if (CanMove(curpoint))
                        {
                            allowedCPieces.Add(cmArray[i, j]);
                        }
                    }
                }
            }

            cellSize = this.Width / size;
            redCount = 12;
            blackCount = 12;

            WriteBoardToFile();
        }

        #endregion Private Methods

        #region Public Methods

        public CheckersBoard()
        {
            InitializeComponent();
            allowedCPieces = new List<CheckersPiece>();
        }

        /// <summary>
        /// Resets the board for a new game
        /// </summary>
        public void Reset(CheckersElements SecondPlayer)
        {
            InitializeElementsArray();    // Initializes the checkers array
            DrawPiecesOnBoard(true);      // Draws the cmArray array on the board
            ChangePlayer(SecondPlayer);   // This is to ensure that the human will start first
        }

        /// <summary>
        /// Updates the array with a movement of a checkers piece
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void UpdateMovement(Point from, Point to)
        {
            ApplyMove(new Move(from, to, this));
        }

        /// <summary>
        /// Writes the current state of the board to a text file.
        /// Used when we need to notify the other algorithm about the status of the board.
        /// </summary>
        public void WriteBoardToFile()
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter(@"C:\Board.txt");

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (cmArray[j, i] == null || cmArray[j, i].Type == CheckersElements.Null)
                    {
                        tw.Write("N");
                    }
                    else
                    {
                        if (cmArray[j, i].IsKing)
                        {
                            tw.Write(cmArray[j, i].Type.ToString().ToUpper()[0]);
                        }
                        else
                        {
                            tw.Write(cmArray[j, i].Type.ToString().ToLower()[0]);
                        }
                    }
                }

                // Go down a line
                tw.WriteLine();
            }

            // close the stream
            tw.Close();
        }

        /// <summary>
        /// Reads a board status from a text file and updates the checkers board accordingly.
        /// </summary>
        public void ReadBoardFromFile()
        {
            // create a writer and open the file
            TextReader tr = new StreamReader(@"C:\Board.txt");
            cmArray = new CheckersPiece[size, size];
            string readString;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    readString = tr.ReadLine();

                    if ((i + j) % 2 == 1)
                    {
                        switch (readString[j])
                        {
                            case 'N':
                            case 'n':
                                cmArray[i, j] = new CheckersPiece(CheckersElements.Null, new Point(i, j), this);
                                cmArray[i, j].IsKing = false;
                                cmArray[i, j].IsAlive = false;
                                break;
                            case 'B':
                                cmArray[i, j] = new CheckersPiece(CheckersElements.Black, new Point(i, j), this);
                                cmArray[i, j].IsKing = true;
                                cmArray[i, j].IsAlive = true;
                                break;
                            case 'b':
                                cmArray[i, j] = new CheckersPiece(CheckersElements.Black, new Point(i, j), this);
                                cmArray[i, j].IsKing = false;
                                cmArray[i, j].IsAlive = true;
                                break;
                            case 'R':
                                cmArray[i, j] = new CheckersPiece(CheckersElements.Red, new Point(i, j), this);
                                cmArray[i, j].IsKing = true;
                                cmArray[i, j].IsAlive = true;
                                break;
                            case 'r':
                                cmArray[i, j] = new CheckersPiece(CheckersElements.Red, new Point(i, j), this);
                                cmArray[i, j].IsKing = false;
                                cmArray[i, j].IsAlive = true;
                                break;
                        }
                    }
                    else
                    {
                        cmArray[i, j] = null;
                    }
                }
            }

            // close the stream
            tr.Close();
        }

        /// <summary>
        /// This function is called upon gaining control from the other application
        /// </summary>
        public void GainControl()
        {
            ReadBoardFromFile();
        }

        /// <summary>
        /// Changes the active player to the other one
        /// </summary>
        /// <param name="changeFrom"></param>
        public void ChangePlayer(CheckersElements changeFrom)
        {
            nowPlaying = (changeFrom == CheckersElements.Black ? CheckersElements.Red : CheckersElements.Black);

            allowedCPieces.Clear();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cmArray[i, j] != null)
                    {
                        Point curpoint = GetArrayCoordinates(cmArray[i, j].Location);
                        if (cmArray[i, j].Type == nowPlaying && EatPossible(curpoint))
                        {
                            allowedCPieces.Add(cmArray[i, j]);
                            cmArray[i, j].CanEat = true;
                        }
                        else
                        {
                            cmArray[i, j].CanEat = false;
                        }
                    }
                }
            }

            if (allowedCPieces.Count == 0)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (cmArray[i, j] != null)
                        {
                            Point curpoint = GetArrayCoordinates(cmArray[i, j].Location);
                            if (cmArray[i, j].Type == nowPlaying && CanMove(curpoint))
                            {
                                allowedCPieces.Add(cmArray[i, j]);
                            }

                            cmArray[i, j].CanEat = false;
                        }
                    }
                }
            }

            WriteBoardToFile();

            // If the currently playing player is black, it means it's the computer's turn
            if (nowPlaying == CheckersElements.Black)
            {
                ComputerPlay(nowPlaying);
            }
        }

        public Point GetBoardCoordinates(int x, int y)
        {
            return new Point(x * (this.Width / size), y * (this.Width / size));
        }

        public Point GetBoardCoordinates(Point p)
        {
            return GetBoardCoordinates(p.X, p.Y);
        }

        public Point GetArrayCoordinates(int x, int y)
        {
            return new Point(x / (this.Width / size), y / (this.Width / size));
        }

        public Point GetArrayCoordinates(Point p)
        {
            return GetArrayCoordinates(p.X, p.Y);
        }

        /// <summary>
        /// Checks to see if a move is possible.
        /// </summary>
        /// <param name="start">Starting point (in board coordinates)</param>
        /// <param name="end">Ending point (in board coordinates)</param>
        /// <returns>Boolean</returns>
        public bool MovePossible(Point start, Point end, bool caneat)
        {
            // If the movement will get us out of bounds - return false
            if ((end.X > 7 || end.Y > 7 || end.X < 0 || end.Y < 0)
                || (start.X > 7 || start.Y > 7 || start.X < 0 || start.Y < 0))
            {
                return false;
            }

            // If we're trying to move the piece to a white (null) cell - return false
            if (cmArray[end.X, end.Y] == null || cmArray[start.X, start.Y] == null)
            {
                return false;
            }

            // If the player we're trying to move is not the playing player - return false
            if (cmArray[start.X, start.Y].Type != nowPlaying)
            {
                return false;
            }

            // If we didnt move at all or didn't move diagonally - return false
            if ((start.X == end.X) || (start.Y == end.Y))
            {
                return false;
            }

            if (EatPossible(start))
            {
                cmArray[start.X, start.Y].CanEat = true;
            }

            if (cmArray[start.X, start.Y].IsKing && (Math.Abs(start.X - end.X) == 1) && (Math.Abs(start.Y - end.Y) == 1) && (!caneat))
            {
                return true;
            }

            if ((!caneat) && (cmArray[end.X, end.Y].Type == CheckersElements.Null)
                   && (Math.Abs(start.X - end.X) == 1) &&
                   (((start.Y - end.Y == -1) && (nowPlaying == CheckersElements.Black))
                   || ((start.Y - end.Y == 1) && (nowPlaying == CheckersElements.Red))))
            {
                return true;
            }

            // Check if we can eat a piece
            if ((cmArray[end.X, end.Y].Type == CheckersElements.Null) && (Math.Abs(start.X - end.X) == 2) &&
                ((cmArray[start.X, start.Y].IsKing && (Math.Abs(start.Y - end.Y) == 2)) ||
                ((start.Y - end.Y == -2) && (nowPlaying == CheckersElements.Black)) ||
                ((start.Y - end.Y == 2) && (nowPlaying == CheckersElements.Red))) &&
                (cmArray[(start.X + end.X) / 2, (start.Y + end.Y) / 2] != null) &&
                (cmArray[(start.X + end.X) / 2, (start.Y + end.Y) / 2].Type != CheckersElements.Null) &&
                (cmArray[(start.X + end.X) / 2, (start.Y + end.Y) / 2].Type != cmArray[start.X, start.Y].Type))
            {
                return true;
            }

            CheckersElements opponent = (cmArray[start.X, start.Y].Type == CheckersElements.Black)
                                            ? CheckersElements.Red
                                            : CheckersElements.Black;

            if ((Math.Abs(start.X - start.Y) == 2) && (Math.Abs(end.X - end.Y) == 2))
            {
                if (cmArray[end.X, end.Y].Type == CheckersElements.Null)
                {
                    if (cmArray[(start.X + end.X) / 2, (start.Y + end.Y) / 2].Type == opponent)
                    {
                        if (!cmArray[start.X, start.Y].IsKing)
                        {
                            if (cmArray[start.X, start.Y].Type == CheckersElements.Black)
                            {
                                if (start.Y - end.Y == -2)
                                {
                                    return true;
                                }
                            }
                            else if (cmArray[start.X, start.Y].Type == CheckersElements.Red)
                            {
                                if (start.Y - end.Y == 2)
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (Math.Abs(start.Y - end.Y) == 2)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            // If move is not possible
            return false;
        }

        public bool CanMove(Point cp)
        {
            if (cmArray[cp.X, cp.Y] == null)
            {
                return false;
            }

            if (cmArray[cp.X, cp.Y].IsKing && ((cp.X < 7 && cp.Y < 7 && cmArray[cp.X + 1, cp.Y + 1].Type == CheckersElements.Null)
                || (cp.X < 7 && cp.Y > 0 && cmArray[cp.X + 1, cp.Y - 1].Type == CheckersElements.Null)
                || (cp.X > 0 && cp.Y < 7 && cmArray[cp.X - 1, cp.Y + 1].Type == CheckersElements.Null)
                || (cp.X > 0 && cp.Y > 0 && cmArray[cp.X - 1, cp.Y - 1].Type == CheckersElements.Null)))
            {
                return true;
            }

            if (nowPlaying == CheckersElements.Black && (cp.X < 7 && cp.Y < 7 && cmArray[cp.X + 1, cp.Y + 1].Type == CheckersElements.Null
                || cp.X > 0 && cp.Y < 7 && cmArray[cp.X - 1, cp.Y + 1].Type == CheckersElements.Null))
            {
                return true;
            }

            if (nowPlaying == CheckersElements.Red && (cp.X < 7 && cp.Y > 0 && cmArray[cp.X + 1, cp.Y - 1].Type == CheckersElements.Null
                || cp.X > 0 && cp.Y > 0 && cmArray[cp.X - 1, cp.Y - 1].Type == CheckersElements.Null))
            {
                return true;
            }
            return false;
        }

        public bool EatPossible(Point po)
        {
            if ((nowPlaying == CheckersElements.Black)
                && (po.X <= 5 && po.Y <= 5 && (cmArray[po.X + 2, po.Y + 2].Type == CheckersElements.Null && cmArray[po.X + 1, po.Y + 1].Type == CheckersElements.Red)
                || (po.X >= 2 && po.Y <= 5 && cmArray[po.X - 2, po.Y + 2].Type == CheckersElements.Null && cmArray[po.X - 1, po.Y + 1].Type == CheckersElements.Red)))
            {
                return true;
            }

            if ((nowPlaying == CheckersElements.Red)
                && (po.X >= 2 && po.Y >= 2 && (cmArray[po.X - 2, po.Y - 2].Type == CheckersElements.Null && cmArray[po.X - 1, po.Y - 1].Type == CheckersElements.Black)
                || (po.X <= 5 && po.Y >= 2 && cmArray[po.X + 2, po.Y - 2].Type == CheckersElements.Null && cmArray[po.X + 1, po.Y - 1].Type == CheckersElements.Black)))
            {
                return true;
            }

            if (cmArray[po.X, po.Y].IsKing &&
                po.X <= 5 && (po.Y <= 5 && (cmArray[po.X + 2, po.Y + 2].Type == CheckersElements.Null && cmArray[po.X + 1, po.Y + 1].Type != nowPlaying && cmArray[po.X + 1, po.Y + 1].Type != CheckersElements.Null)
                || (po.Y >= 2 && cmArray[po.X + 2, po.Y - 2].Type == CheckersElements.Null && cmArray[po.X + 1, po.Y - 1].Type != nowPlaying && cmArray[po.X + 1, po.Y - 1].Type != CheckersElements.Null)))
            {
                return true;
            }

            if (cmArray[po.X, po.Y].IsKing &&
                po.X >= 2 && (po.Y <= 5 && (cmArray[po.X - 2, po.Y + 2].Type == CheckersElements.Null && cmArray[po.X - 1, po.Y + 1].Type != nowPlaying && cmArray[po.X - 1, po.Y + 1].Type != CheckersElements.Null)
                || (po.Y >= 2 && cmArray[po.X - 2, po.Y - 2].Type == CheckersElements.Null && cmArray[po.X - 1, po.Y - 1].Type != nowPlaying && cmArray[po.X - 1, po.Y - 1].Type != CheckersElements.Null)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Aligns the piece (panel) to the right cell location on the board
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point AlignToCells(Point p)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < size; i++)
            {
                if (p.X > x && (p.X - x > cellSize))
                {
                    x += cellSize;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < size; i++)
            {
                if (p.Y > y && (p.Y - y > cellSize))
                {
                    y += cellSize;
                }
                else
                {
                    break;
                }
            }

            return new Point(x, y);
        }

        /// <summary>
        /// Returns an ArrayList of valid moves for a specific cell in the board
        /// </summary>
        /// <param name="p">Cell to check</param>
        /// <returns>ArrayList of possible moves</returns>
        public List<Move> GetValidMoves(Point p)
        {
            List<Move> moveArray = new List<Move>();

            if (MovePossible(p, new Point(p.X - 1, p.Y - 1), cmArray[p.X, p.Y].CanEat))
            {
                moveArray.Add(new Move(p, new Point(p.X - 1, p.Y - 1), this));
            }
            if (MovePossible(p, new Point(p.X - 1, p.Y + 1), cmArray[p.X, p.Y].CanEat))
            {
                moveArray.Add(new Move(p, new Point(p.X - 1, p.Y + 1), this));
            }
            if (MovePossible(p, new Point(p.X + 1, p.Y - 1), cmArray[p.X, p.Y].CanEat))
            {
                moveArray.Add(new Move(p, new Point(p.X + 1, p.Y - 1), this));
            }
            if (MovePossible(p, new Point(p.X + 1, p.Y + 1), cmArray[p.X, p.Y].CanEat))
            {
                moveArray.Add(new Move(p, new Point(p.X + 1, p.Y + 1), this));
            }

            //moveArray.AddRange(GetEatingMoves(p));

            return moveArray;
        }

        /// <summary>
        /// Returns an ArrayList of valid moves for a specific cell in the board
        /// </summary>
        /// <param name="p">Cell to check</param>
        /// <returns>ArrayList of possible moves</returns>
        public List<Move> GetEatingMoves(Point p)
        {
            List<Move> eatingMoves = new List<Move>();

            if (MovePossible(p, new Point(p.X - 2, p.Y - 2), cmArray[p.X, p.Y].CanEat))
            {
                eatingMoves.Add(new Move(p, new Point(p.X - 2, p.Y - 2), this));
            }
            if (MovePossible(p, new Point(p.X - 2, p.Y + 2), cmArray[p.X, p.Y].CanEat))
            {
                eatingMoves.Add(new Move(p, new Point(p.X - 2, p.Y + 2), this));
            }
            if (MovePossible(p, new Point(p.X + 2, p.Y - 2), cmArray[p.X, p.Y].CanEat))
            {
                eatingMoves.Add(new Move(p, new Point(p.X + 2, p.Y - 2), this));
            }
            if (MovePossible(p, new Point(p.X + 2, p.Y + 2), cmArray[p.X, p.Y].CanEat))
            {
                eatingMoves.Add(new Move(p, new Point(p.X + 2, p.Y + 2), this));
            }

            return eatingMoves;
        }

        /// <summary>
        /// Gets a valid move and applies it onto the board.
        /// </summary>
        /// <param name="m">The move to apply</param>
        public CheckersBoard ApplyMove(Move m)
        {
            CheckersPiece temp = cmArray[m.Ending.X, m.Ending.Y];

            cmArray[m.Ending.X, m.Ending.Y] = cmArray[m.Starting.X, m.Starting.Y];
            cmArray[m.Starting.X, m.Starting.Y] = temp;
            cmArray[m.Starting.X, m.Starting.Y].Location = GetBoardCoordinates(m.Starting.X, m.Starting.Y);
            cmArray[m.Starting.X, m.Starting.Y].BoardLocation = m.Starting;
            cmArray[m.Ending.X, m.Ending.Y].Location = GetBoardCoordinates(m.Ending.X, m.Ending.Y);
            cmArray[m.Ending.X, m.Ending.Y].BoardLocation = m.Ending;

            if (Math.Abs(m.Starting.X - m.Ending.X) == 2 && (Math.Abs(m.Starting.Y - m.Ending.Y) == 2))
            {
                cmArray[(m.Starting.X + m.Ending.X) / 2, (m.Starting.Y + m.Ending.Y) / 2].Visible = false;
                cmArray[(m.Starting.X + m.Ending.X) / 2, (m.Starting.Y + m.Ending.Y) / 2].IsAlive = false;
                CheckersPiece nullCP = new CheckersPiece(CheckersElements.Null, new Point(m.Ending.X, m.Ending.Y), this);

                // Handle black / red piece count (for knowing when the game ends)
                //if (cmArray[(m.Starting.X + m.Ending.X) / 2, (m.Starting.Y + m.Ending.Y) / 2].Type == CheckersElements.Black)
                if (nowPlaying == CheckersElements.Red)
                {
                    BlackCount--;
                }
                else
                {
                    RedCount--;
                }

                // Make the eaten cell null (so others can step into it)
                cmArray[(m.Starting.X + m.Ending.X) / 2, (m.Starting.Y + m.Ending.Y) / 2] = nullCP;
            }

             // If we're being knighted
                if (((m.Ending.Y == 7) || (m.Ending.Y == 0)) && (!cmArray[m.Ending.X, m.Ending.Y].IsKing))
                {
                    cmArray[m.Ending.X, m.Ending.Y].MakeKing();
                }

            // Write the board to a text file for another program to read
            WriteBoardToFile();

            return this;
        }

        /// <summary>
        /// Calculates a board's score using predefined heuristics
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int GetBoardScore(CheckersElements element)
        {
            int boardScore = 0;

            //// If we don't have any possible moves, return the lowest value possible
            //if (PossibleMoves(element).Count == 0)
            //{
            //    return int.MinValue;
            //}

            foreach (CheckersPiece piece in cmArray)
            {
                if (piece != null && piece.Type == element)
                {
                    boardScore += Heuristics.CalculatePieceScore(piece, this);
                }
            }

            return boardScore;
        }

        /// <summary>
        /// Returns a List of all the possible moves for the specified CheckersElement
        /// </summary>
        /// <param name="element">The element to get possible moves to</param>
        /// <returns>A List of all possible moves</returns>
        public List<Move> PossibleMoves(CheckersElements element)
        {
            List<Move> movesArray = new List<Move>();

            foreach (CheckersPiece piece in cmArray)
            {
                if (piece != null && piece.Type == element)
                {
                    movesArray.AddRange(GetValidMoves(piece.BoardLocation));
                }
            }

            List<Move> eatmovesArray = new List<Move>();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cmArray[i, j] != null && cmArray[i, j].Type == element)
                    {
                        eatmovesArray.AddRange(GetEatingMoves(cmArray[i, j].BoardLocation));
                    }
                }
            }


          /*  foreach (CheckersPiece piece in cmArray)
            {
                if (piece != null && piece.Type == element)
                {
                    eatmovesArray.AddRange(GetEatingMoves(piece.BoardLocation));
                }
            }*/
            if (eatmovesArray.Count != 0)
            {
                return eatmovesArray;
            }
            else
                return movesArray;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Checks to see if one of the counts reached 
        /// </summary>
        private void CheckCounts()
        {
            DialogResult dr = new DialogResult();

            if (blackCount == 0)
            {
                dr = MessageBox.Show("Red (Human) player wins!", "RED WINS!", MessageBoxButtons.RetryCancel);
            }
            else if (redCount == 0)
            {
                dr = MessageBox.Show("Black (Computer) player wins!", "BLACK WINS!", MessageBoxButtons.RetryCancel);
            }

            if (dr == DialogResult.Retry)
            {
                Reset(CheckersElements.Black);
            }
        }

        /// <summary>
        /// Draws the checkers pieces on the board (Updates its location and sets alive status to true)
        /// </summary>
        private void DrawPiecesOnBoard(bool isReset)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    CheckersPiece p = cmArray[i, j];

                    if (p != null)
                    {
                        p.Location = GetBoardCoordinates(p.BoardLocation);

                        if (p.Type != CheckersElements.Null)
                        {
                            p.BringToFront();

                            if (isReset)
                            {
                                p.IsAlive = true;
                                p.IsKing = false;
                                p.Visible = true;
                                p.ResetImage();
                            }
                        }
                        else
                        {
                            p.Visible = false;
                            p.IsAlive = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A function that tells the PC to perform a move according to the selected algorithm
        /// </summary>
        private void ComputerPlay(CheckersElements computerColor)
        {
            Thread.Sleep(300);

            switch (algorithm)
            {
                case AlgorithmType.Random:
                    Move move;

                    if (algorithm == AlgorithmType.Minimax)
                    {
                        move = Algorithms.MinMax(this, computerColor, maxDepth);
                    }
                    else
                    {
                        move = Algorithms.AlphaBeta(this, computerColor, maxDepth);
                    }

                    if (move != null)
                    {
                        ApplyMove(move);
                    }
                    else
                    {
                        MessageBox.Show("Game is tied - No more moves possible", "TIED GAME!", MessageBoxButtons.OK);
                        Application.Exit();
                    }
                    break;

                case AlgorithmType.AlphaBeta:
                    CheckersBoard board = Algorithms.MiniMax(this, nowPlaying, maxDepth, 0, true, true);
                    cmArray = board.cmArray;
                    redCount = board.redCount;
                    blackCount = board.blackCount;
                    break;

                default:
                   // CheckersBoard board = Algorithms.MinMax(this, 0, false, maxDepth, CheckersElements.Black);
                    board = Algorithms.MiniMax(this, nowPlaying, maxDepth, 0, true, false);
                    cmArray = board.cmArray;
                    redCount = board.redCount;
                    blackCount = board.blackCount;
                    break;

            }



            ChangePlayer(nowPlaying);
        }

        #endregion Private Methods

        #region ICloneable Members

        public object Clone()
        {
            CheckersBoard cloned = new CheckersBoard();

            cloned = this;

            return cloned;
        }

        #endregion ICloneable Members

        internal void SetDepth(int p)
        {
            maxDepth = p;
        }

        internal List<CheckersBoard> GeneratePossibleBoards(CheckersElements whosTurn)
        {
            List<Move> possibleMoves = PossibleMoves(whosTurn);
            List<CheckersBoard> possibleBoards = new List<CheckersBoard>();

            foreach (Move m in possibleMoves)
            {
                possibleBoards.Add(((CheckersBoard) Clone()).ApplyMove(m));
            }

            return possibleBoards;
        }
    }
}