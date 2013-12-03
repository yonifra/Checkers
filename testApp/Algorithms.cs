using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainGame.Properties;

namespace MainGame
{
    public static class Algorithms
    {
        //private static Move MinMax(bool isAlphaBeta, CheckersBoard board, CheckersElements whosTurn)
        //{
        //    // return GetBestMove(whosTurn, board);
        //    List<Move> validMoves = new List<Move>();
        //    List<int> boardScores = new List<int>();
        //    Move bestCandidate = null;
        //    int depth = 0;

        //    while (depth <= MaxDepth)
        //    {
        //        validMoves = board.PossibleMoves(whosTurn);

        //        foreach (Move move in validMoves)
        //        {
        //            boardScores.Add((((CheckersBoard)board.Clone()).ApplyMove(move)).GetBoardScore(whosTurn));
        //        }

        //        int selectedScore = int.MinValue;
        //        int selectedBoardIndex = 0;
        //        int temp = 0;

        //        foreach (int score in boardScores)
        //        {
        //            if (depth % 2 == 0)  // MAX LEVEL
        //            {
        //                if (score > selectedScore)
        //                {
        //                    selectedScore = score;
        //                    selectedBoardIndex = temp;
        //                }
        //            }
        //            else                // MIN LEVEL
        //            {
        //                if (score < selectedScore)
        //                {
        //                    selectedScore = score;
        //                    selectedBoardIndex = temp;
        //                }
        //            }

        //            if ((validMoves.Count != 0) && (validMoves[selectedBoardIndex] != null))
        //            {
        //                bestCandidate = (Move)validMoves[selectedBoardIndex];
        //            }

        //            temp++;
        //        }

        //        depth++;
        //    }

        //    if (bestCandidate != null)
        //    {
        //        return bestCandidate;
        //    }

        //    return null;
        //}

        private static Move MiniMax(CheckersBoard board, CheckersElements whosTurn)
        {
            return DummyMiniMax(board, whosTurn);
            // return MaxMove(board, whosTurn, isAlphaBeta, 0, int.MinValue, int.MaxValue);
            //return GetBestMove(whosTurn, board);
        }

        private static Move MinMove(CheckersBoard board, CheckersElements whosTurn, bool isAlphaBeta, int currentDepth, int alpha, int beta, int maxDepth)
        {
            currentDepth++;
            var bestMoves = new List<Move>();
            var bestScore = int.MaxValue;
            var possibleMoves = board.PossibleMoves(whosTurn);
            var opponent = WhosMyOpponent(whosTurn);

            foreach (var move in possibleMoves)
            {
                var newBoard = ((CheckersBoard)board.Clone()).ApplyMove(move);

                if (currentDepth <= maxDepth)
                {
                    var maxMove = MaxMove(newBoard, CheckersElements.Black, isAlphaBeta, currentDepth, alpha, beta, maxDepth);

                    if (maxMove != null)
                    {
                        if (newBoard.GetBoardScore(whosTurn) < (newBoard.ApplyMove(maxMove)).GetBoardScore(opponent))
                        {
                            bestMoves.Clear();
                            bestMoves.Add(move);
                        }
                    }
                    else break;
                }
                else
                {
                    if (newBoard.GetBoardScore(whosTurn) < bestScore)
                    {
                        bestMoves.Clear();
                        bestMoves.Add(move);
                        bestScore = newBoard.GetBoardScore(whosTurn);
                    }
                }
            }

            if (bestMoves.Count > 0)
            {
                var rand = new Random();
                return bestMoves[rand.Next(bestMoves.Count)];
            }

            return null;
        }

        private static CheckersElements WhosMyOpponent(CheckersElements whosTurn)
        {
            return whosTurn == CheckersElements.Black ? CheckersElements.Red : CheckersElements.Black;
        }

        private static Move MaxMove(CheckersBoard board, CheckersElements whosTurn, bool isAlphaBeta, int currentDepth, int alpha, int beta, int maxDepth)
        {
            currentDepth++;
            var bestMoves = new List<Move>();
            var bestScore = int.MinValue;
            var possibleMoves = board.PossibleMoves(whosTurn);
            var opponent = WhosMyOpponent(whosTurn);

            foreach (var move in possibleMoves)
            {
                var newBoard = ((CheckersBoard)board.Clone()).ApplyMove(move);

                if (currentDepth <= maxDepth)
                {
                    var minMove = MinMove(newBoard, CheckersElements.Black, isAlphaBeta, currentDepth, alpha, beta, maxDepth);

                    if (minMove != null)
                    {
                        if (newBoard.GetBoardScore(whosTurn) > (newBoard.ApplyMove(minMove)).GetBoardScore(opponent))
                        {
                            bestMoves.Clear();
                            bestMoves.Add(move);
                        }
                    }
                    else break;
                }
                else
                {
                    if (newBoard.GetBoardScore(whosTurn) > bestScore)
                    {
                        bestMoves.Clear();
                        bestMoves.Add(move);
                        bestScore = newBoard.GetBoardScore(whosTurn);
                    }
                }
            }

            if (bestMoves.Count > 0)
            {
                var rand = new Random();
                return bestMoves[rand.Next(bestMoves.Count)];
            }

            return null;
        }

        /// <summary>
        /// A dummy minimax algorithm - Used for testing purposes only!
        /// </summary>
        /// <param name="board"></param>
        /// <param name="whosTurn"></param>
        /// <returns></returns>
        private static Move DummyMiniMax(CheckersBoard board, CheckersElements whosTurn)
        {
            var possibleMoves = board.PossibleMoves(whosTurn);
            var rand = new Random();

            if (possibleMoves.Count == 0)
            {
                MessageBox.Show(Resources.GameTied, Resources.ItsATie, MessageBoxButtons.OK);
                return null;
            }

            return (possibleMoves[rand.Next(possibleMoves.Count)]);
        }

        //public static CheckersBoard MinMax(CheckersBoard currentBoard, int depth, bool myMinFlag, int depthLimit, CheckersElements whosTurn)
        //{
        //    // Check if the game is over, and the depth limit
        //    if (currentBoard.RedCount == 0 || currentBoard.BlackCount == 0 || depth > depthLimit)
        //    {
        //        return currentBoard;
        //    }

        //    CheckersElements opponent = (whosTurn == CheckersElements.Black)
        //                                        ? CheckersElements.Red
        //                                        : CheckersElements.Black;

        //    if (myMinFlag)
        //    {
        //        // Get next moves
        //        List<CheckersBoard> nextMoves = currentBoard.GeneratePossibleBoards(whosTurn);

        //        if (nextMoves.Count == 0)
        //        {
        //            throw new Exception("No more moves possible!");
        //        }

        //        CheckersBoard mvpBoard = null;
        //        int value = int.MaxValue;

        //        // Iterate over possible moves for that player.
        //        foreach (CheckersBoard board in nextMoves)
        //        {
        //            int valueOfCurrentBoard =
        //                EvaluateBoard(MinMax(board, depth + 1, !myMinFlag, depthLimit, opponent), whosTurn);

        //            if (valueOfCurrentBoard < value)
        //            {
        //                value = valueOfCurrentBoard;
        //                mvpBoard = board;
        //            }
        //        }

        //        // Return the minimum value seen.
        //        return mvpBoard;
        //    }
        //    else
        //    { // maximizing
        //        // Get next moves
        //        List<CheckersBoard> nextMoves = currentBoard.GeneratePossibleBoards(whosTurn);

        //        if (nextMoves.Count == 0)
        //        {
        //             throw new Exception("MoveGenerator.GeneratePossibleBoards returned 0 boards");
        //        }

        //        CheckersBoard mvpBoard = null;
        //        int value = int.MinValue;

        //        // Iterate over possible moves for that player.
        //        foreach (CheckersBoard board in nextMoves)
        //        {
        //            int valueOfCurrentBoard =
        //                EvaluateBoard(MinMax(board, depth + 1, !myMinFlag, depthLimit, opponent), whosTurn);

        //            if (valueOfCurrentBoard > value)
        //            {
        //                value = valueOfCurrentBoard;
        //                mvpBoard = board;
        //            }
        //        }

        //        // Return the maximum value seen.
        //        return mvpBoard;
        //    }
        //}

        //private static int EvaluateBoard(CheckersBoard board, CheckersElements element)
        //{
        //    return board.GetBoardScore(element);
        //}

        public static CheckersBoard MiniMax(CheckersBoard board, CheckersElements whosPlaying, int maxDepth, int currentDepth, bool isMax, bool isAlphaBeta)
        {
            // Stopping rule for Minimax
            if (currentDepth > maxDepth || board.RedCount == 0 || board.BlackCount == 0)
            {
                return board;
            }

            // TODO: MAKE SURE WE'RE NOT MODIFYING THE ORIGINAL BOARD!
            var clonedBoard = new CheckersBoard
                {
                    cmArray = board.cmArray,
                    RedCount = board.RedCount,
                    BlackCount = board.BlackCount
                };

            CheckersElements opponent = (whosPlaying == CheckersElements.Black)
                                            ? CheckersElements.Red
                                            : CheckersElements.Black;

            var possibleMoves = clonedBoard.PossibleMoves(whosPlaying);
            var possibleBoards = possibleMoves.Select(clonedBoard.ApplyMove).ToList();

            if (possibleBoards.Count == 0)
            {
                return board;
            }

            var boardToReturn = board;

            if (isMax)
            {
                // MAX stage
                int[] maxValue = { int.MinValue };

                foreach (var tempBoard in possibleBoards.Select(b => MiniMax(b, opponent, maxDepth, currentDepth + 1, false, isAlphaBeta)).Where(tempBoard => tempBoard.GetBoardScore(whosPlaying) > maxValue[0]))
                {
                    maxValue[0] = tempBoard.GetBoardScore(whosPlaying);
                    boardToReturn = tempBoard;
                }
            }
            else
            {
                // MIN stage
                int[] minValue = { int.MaxValue };

                foreach (var tempBoard in possibleBoards.Select(b => MiniMax(b, opponent, maxDepth, currentDepth + 1, true, isAlphaBeta)).Where(tempBoard => tempBoard.GetBoardScore(whosPlaying) < minValue[0]))
                {
                    minValue[0] = tempBoard.GetBoardScore(whosPlaying);
                    boardToReturn = tempBoard;
                }
            }

            return boardToReturn;
        }

        /// <summary>
        /// Runs the Minimax Algorithm
        /// </summary>
        /// <param name="board">The board that the algorithm has to work on</param>
        /// <param name="whosTurn">Currently playing player</param>
        /// <param name="maxDepth">Maximum depth for algorithm to go to</param>
        /// <returns>Returns an array list of the moves it should perform</returns>
        public static Move MinMax(CheckersBoard board, CheckersElements whosTurn, int maxDepth)
        {
            return MiniMax(board, whosTurn);
        }

        public static Move AlphaBeta(CheckersBoard board, CheckersElements whosTurn, int maxDepth)
        {
            return MiniMax(board, whosTurn);
        }
    }

    public static class Heuristics
    {
        /// <summary>
        /// Calculate the piece score according to heuristical rules
        /// </summary>
        /// <param name="p"></param>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static int CalculatePieceScore(CheckersPiece p, CheckersBoard cb)
        {
            var score = 0;

            // Check if the piece is a king or not
            if (p.IsKing)
            {
                score += 10;
            }
            else
            {
                score += 5;
            }

            // Check if the piece can eat at this location
            if (cb.GetEatingMoves(p.BoardLocation).Count > 0)
            {
                score += 10000; // If he can eat, we must eat...
            }

            // Add the piece location to the score of the piece
            if ((p.BoardLocation.X == 0 || p.BoardLocation.X == 7) || (p.BoardLocation.Y == 0 || p.BoardLocation.Y == 7))
            {
                score *= 4;
            }
            else if ((p.BoardLocation.X == 1 || p.BoardLocation.X == 6) || (p.BoardLocation.Y == 1 || p.BoardLocation.Y == 6))
            {
                score *= 3;
            }
            else if ((p.BoardLocation.X == 2 || p.BoardLocation.X == 5) || (p.BoardLocation.Y == 2 || p.BoardLocation.Y == 5))
            {
                score *= 2;
            }

            return score;
        }
    }

    /// <summary>
    /// Specifies the different types of possible algorithms to run
    /// </summary>
    public enum AlgorithmType
    {
        Minimax,
        AlphaBeta,
        Random,
    }
}
