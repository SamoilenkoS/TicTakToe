using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTakLib;

namespace TicTackTests
{
    [TestClass]
    public class Board_TESTS
    {
        private class Point
        {
            public int X;
            public int Y;
        }
        int width = 5;
        int height = 5;
        int winCondition = 3;

        private List<Point> GetPlayerTurns(string playerTurns)
        {
            var stringPlayerTurns = playerTurns.Split(',');
            List<Point> playerPoints = new List<Point>();
            foreach (var stringPlayerTurn in stringPlayerTurns)
            {
                var xy = stringPlayerTurn.Split('.');
                playerPoints.Add
                (
                    new Point
                    {
                        X = Convert.ToInt32(xy[0]),
                        Y = Convert.ToInt32(xy[1])
                    }
                );
            }
            return playerPoints;
        }

        [TestMethod]
        [DataRow("0.0,0.1,0.2", "1.0,2.1,2.0")]//Y
        [DataRow("1.0,0.0,2.0", "1.1,2.1,2.2")]//X
        [DataRow("0.0,1.1,2.2", "1.0,2.1,2.0")]
        public void Board_WinCondition_Tests(string player1Turns, 
            string player2Turns)
        {
            var player1Points = GetPlayerTurns(player1Turns);
            var player2Points = GetPlayerTurns(player2Turns);
            Board board = new Board(width, height, winCondition);
            for (int i = 0; i < player1Points.Count; i++)
            {
                board.MakeTurn(TypeOfFigure.Cross, player1Points[i].X, player1Points[i].Y);
                board.MakeTurn(TypeOfFigure.Circle, player2Points[i].X, player2Points[i].Y);
            }
            var winState = board.GetWinState();
            Assert.IsTrue(winState.Item1);
            Assert.AreEqual(TypeOfFigure.Cross, winState.Item2);

        }
    }
}
