using System;
using System.Drawing;
using System.Windows.Forms;

namespace MainGame
{
    public class CheckersPiece : Panel
    {
        #region Private Members

        private bool isKing;
        private CheckersElements type;
        private bool isAlive;
        private System.ComponentModel.IContainer components;
        private ImageList imageList1;
        private Point location;
        private int boardCellSize;
        private bool isDown;
        private CheckersBoard myCB;
        private Point startingPosition;
        private int index;
        private bool caneat;

        #endregion Private Members

        #region Public Properties

        public CheckersElements Type
        {
            get
            {
                return type;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
        }

        public bool IsDown
        {
            get
            {
                return isDown;
            }
        }

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
            }
        }

        public bool CanEat
        {
            get
            {
                return caneat;
            }
            set
            {
                caneat = value;
            }
        }

        public bool IsKing
        {
            get
            {
                return isKing;
            }
            set
            {
                isKing = value;
            }
        }

        public Image PieceImage
        {
            get
            {
                return BackgroundImage;
            }
            set
            {
                BackgroundImage = value;
            }
        }

        public Point BoardLocation
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        // Constructor
        public CheckersPiece(CheckersElements el, Point pieceLocation, CheckersBoard callingBoard)
        {
            InitializeComponent();

            boardCellSize = callingBoard.Size.Width / CheckersBoard.size;
            Size = new Size(boardCellSize, boardCellSize);
            Location = new Point(pieceLocation.X * boardCellSize, pieceLocation.Y * boardCellSize);
            BackgroundImageLayout = ImageLayout.Center;
            BoardLocation = pieceLocation;
            myCB = callingBoard;
            Enabled = true;

            if (el == CheckersElements.Null)
            {
                isAlive = false;
                Visible = false;
            }
            else
            {
                if (imageList1 != null)
                {
                    PieceImage = el == CheckersElements.Black ? imageList1.Images[0] : imageList1.Images[1];
                }

                isAlive = true;
            }

            isKing = false;
            caneat = false;
            myCB.currentCP = null;
            type = el;
            callingBoard.Controls.Add(this);
        }

        public void MakeKing()
        {
            BackgroundImage = Type == CheckersElements.Black ? imageList1.Images[2] : imageList1.Images[3];


            isKing = true;
        }

        #endregion Public Methods

        #region Private Methods

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckersPiece));
            this.imageList1 = new ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = Color.White;
            this.imageList1.Images.SetKeyName(0, "blackPiece.png");
            this.imageList1.Images.SetKeyName(1, "redpiece.png");
            this.imageList1.Images.SetKeyName(2, "blackPieceking.png");
            this.imageList1.Images.SetKeyName(3, "redpieceking.png");
            // 
            // CheckersPiece
            // 
            this.BackColor = Color.Transparent;
            this.MouseMove += this.CheckersPiece_MouseMove;
            this.MouseDown += this.CheckersPiece_MouseDown;
            this.MouseUp += this.CheckersPiece_MouseUp;
            this.MouseEnter += new EventHandler(CheckersPiece_MouseEnter);

            this.ResumeLayout(false);

        }


        void CheckersPiece_MouseEnter(object sender, EventArgs e)
        {
            Cursor = myCB.allowedCPieces.Contains(this) ? Cursors.Hand : Cursors.Default;
        }

        private void CheckersPiece_MouseDown(object sender, MouseEventArgs e)
        {
            if (myCB.currentCP != null && myCB.currentCP != this)
            {
                MessageBox.Show("Can't Move this piece! You already moved the piece positioned :" + myCB.currentCP.location.X.ToString() + "," + myCB.currentCP.location.Y.ToString());
                isDown = false;
                return;
            }

            new Point(e.X / boardCellSize, e.Y / boardCellSize);
            startingPosition = Location;

            if (type != CheckersElements.Null && (type == myCB.NowPlaying) && myCB.allowedCPieces.Contains(this))
            {
                isDown = true;
            }
        }

        private void CheckersPiece_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                Location = new Point(e.X + Location.X - (boardCellSize / 2), e.Y + Location.Y - (boardCellSize / 2));
            }
        }

        private void CheckersPiece_MouseUp(object sender, MouseEventArgs e)
        {
            var loc = myCB.PointToClient(MousePosition);
            var starting = myCB.GetArrayCoordinates(startingPosition);
            var ending = myCB.GetArrayCoordinates(loc);

            // Check if move is possible, and if it is, align the piece to the board
            if (myCB.MovePossible(starting, ending, caneat) && isDown)
            {
                // Move is possible, so change the location of the piece and pass the turn to the other player
                Location = myCB.AlignToCells(loc);
                var eating = false;
                isDown = false;

                // If we're eating an opponent
                if ((Math.Abs(starting.X - ending.X) == 2) && (Math.Abs(starting.Y - ending.Y) == 2))
                {
                    eating = true;

                    myCB.cmArray[(starting.X + ending.X) / 2, (starting.Y + ending.Y) / 2].Visible = false;
                    myCB.cmArray[(starting.X + ending.X) / 2, (starting.Y + ending.Y) / 2].IsAlive = false;
                    var nullCP = new CheckersPiece(CheckersElements.Null, new Point(ending.X, ending.Y), myCB);

                    // Make the eaten cell null (so others can step into it)
                    myCB.cmArray[(starting.X + ending.X) / 2, (starting.Y + ending.Y) / 2] = nullCP;
                }


                // Updating the board elements array with the movement
                myCB.UpdateMovement(myCB.GetArrayCoordinates(startingPosition), myCB.GetArrayCoordinates(loc));

                // Change the playing player to the other one
                if (myCB.EatPossible(ending) && eating)
                {
                    caneat = true;
                    myCB.currentCP = this;
                    myCB.allowedCPieces.Clear();
                    myCB.allowedCPieces.Add(this);
                }
                else
                {
                    foreach (var piece in myCB.allowedCPieces)
                    {
                        piece.caneat = false;
                    }

                    myCB.currentCP = null;
                    myCB.ChangePlayer(type);
                }
            }
            else
            {
                // Move is not possible, return piece to the previous location
                Location = startingPosition;
                isDown = false;
            }
        }

        /// <summary>
        /// Resets the piece image to the initial image
        /// </summary>
        internal void ResetImage()
        {
            switch (type)
            {
                case CheckersElements.Black:
                    BackgroundImage = imageList1.Images[0];
                    break;
                case CheckersElements.Red:
                    BackgroundImage = imageList1.Images[1];
                    break;
                default:
                    BackgroundImage = null;
                    break;
            }
        }

        #endregion Private Methods
    }

    #region Enums

    public enum CheckersElements
    {
        Black,
        Red,
        Null,
    };

    #endregion Enums
}
