namespace TicTakLib
{
    public class Board
    {
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
        }


    }
}