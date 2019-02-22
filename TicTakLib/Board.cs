//TODO: Implement protection for Incorrect i,j values
//Also: Protection for width, height, winCondition
using System;

namespace TicTakLib
{
    public class Board
    {
        private TypeOfFigure lastTypeOfFigure;
        private int width;
        private int height;
        private int winCondition;
        private Cell[,] cells;

        public Board(int width, int height, int winCondition)
        {
            this.width = width;
            this.height = height;
            this.winCondition = winCondition;
            cells = new Cell[width, height];
            lastTypeOfFigure = TypeOfFigure.Circle;
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public Tuple<bool, TypeOfFigure?> GetWinState()
        {
            var currentCount = 0;
            TypeOfFigure? currentFigure = null;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var cellFigure = cells[i, j].GetFigure();
                    if (cellFigure != currentFigure)
                    {
                        currentCount = 1;
                        currentFigure = cellFigure;
                    }
                    else
                    {
                        ++currentCount;
                        if (currentCount == winCondition && currentFigure != null)
                        {
                            return new Tuple<bool, TypeOfFigure?>(true, currentFigure);
                        }
                    }
                }
                currentCount = 0;
                currentFigure = null;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var cellFigure = cells[i, j].GetFigure();
                    if (cellFigure != currentFigure)
                    {
                        currentCount = 1;
                        currentFigure = cellFigure;
                    }
                    else
                    {
                        ++currentCount;
                        if (currentCount == winCondition && currentFigure != null)
                        {
                            return new Tuple<bool, TypeOfFigure?>(true, currentFigure);
                        }
                    }
                }
                currentCount = 0;
                currentFigure = null;
            }

            for (int k = 0; k <= height - winCondition; k++)
            {
                for (int i = 0; i <= width - winCondition; i++)
                {
                    for (int j = 0; j < width + i && j < height + k; j++)
                    {
                        var cellFigure = cells[k + j, i + j].GetFigure();
                        if (cellFigure != currentFigure)
                        {
                            currentCount = 1;
                            currentFigure = cellFigure;
                        }
                        else
                        {
                            ++currentCount;
                            if (currentCount == winCondition && currentFigure != null)
                            {
                                return new Tuple<bool, TypeOfFigure?>(true, currentFigure);
                            }

                        }
                    }
                    currentCount = 0;
                    currentFigure = null;
                }
            }

            for (int k = height - winCondition; k >= 0; k++)
            {
                for (int i = width - winCondition; i >= 0; i++)
                {
                    for (int j = 0; j < width + i && j < height + k; j++)
                    {
                        var cellFigure = cells[k - j, i - j].GetFigure();
                        if (cellFigure != currentFigure)
                        {
                            currentCount = 1;
                            currentFigure = cellFigure;
                        }
                        else
                        {
                            ++currentCount;
                            if (currentCount == winCondition && currentFigure != null)
                            {
                                return new Tuple<bool, TypeOfFigure?>(true, currentFigure);
                            }

                        }
                    }
                    currentCount = 0;
                    currentFigure = null;
                }
            }

            return new Tuple<bool, TypeOfFigure?>(false, null);
        }

        public bool MakeTurn(TypeOfFigure typeOfFigure, int i, int j)
        {
            if (lastTypeOfFigure != typeOfFigure)
            {
                var result = cells[i, j].SetFigure(typeOfFigure);
                if (result)
                {
                    lastTypeOfFigure = typeOfFigure;
                }

                return result;
            }

            return false;
        }

    }
}