using System.Drawing;
using System.Windows.Forms;
using TicTakLib;

//TODO:
//1) Diagonals
//2) Score
//3) PC
//4) Refactoring
//5) Menu
//  a) Who turn fist?
//  b) Choose opponent
//  c) Exit
namespace TicTackToe
{
    public partial class TicTakToeMainForm : Form
    {
        private TypeOfFigure currentFigure;
        private Board board;
        private Player[] players;
        public TicTakToeMainForm()
        {
            InitializeComponent();
            board = new Board(5, 5, 3);
            players = new Player[2];
            players[0] = new UserPlayer(TypeOfFigure.Cross);
            players[1] = new UserPlayer(TypeOfFigure.Circle);
            currentFigure = TypeOfFigure.Cross;
        }

        private void buttonStart_Click(object sender, System.EventArgs e)
        {
            DrawEmptyGrid();
            DrawLines();
           // DrawTurn(TypeOfFigure.Circle, 1, 1);
        }

        private void DrawEmptyGrid()
        {
            Graphics graphics = pictureBoxTicTakToe.CreateGraphics();
            graphics.FillRectangle(Brushes.White, 0, 0, pictureBoxTicTakToe.Width, pictureBoxTicTakToe.Height);
        }

        private void DrawLines()
        {
            Graphics graphics = pictureBoxTicTakToe.CreateGraphics();
            var cellWidth = pictureBoxTicTakToe.Width / (board.Width );
            var cellHeight = pictureBoxTicTakToe.Height / (board.Height);
            for (int i = 0; i < board.Width - 1; i++)
            {
                graphics.DrawLine
                    (Pens.Black, cellWidth * (i + 1), 0, cellWidth * (i + 1), pictureBoxTicTakToe.Height);
            }
            for (int i = 0; i < board.Height - 1; i++)
            {
                graphics.DrawLine
                        (Pens.Black, 0, cellHeight * (i + 1), pictureBoxTicTakToe.Width, cellHeight * (i + 1));
            }
        }

        private bool DrawTurn(TypeOfFigure typeOfFigure, int i, int j)
        {
            bool result = board.MakeTurn(typeOfFigure, j, i);
            if (result)
            {
                var graphics = pictureBoxTicTakToe.CreateGraphics();
                var cellWidth = pictureBoxTicTakToe.Width / (board.Width);
                var cellHeight = pictureBoxTicTakToe.Height / (board.Height);
                switch (typeOfFigure)
                {
                    case TypeOfFigure.Circle:
                        Pen pen = new Pen(Color.Red, 3);
                        graphics.DrawEllipse(pen, cellWidth * i, cellHeight * j, cellWidth, cellHeight);
                        break;
                    case TypeOfFigure.Cross:
                        graphics.DrawLine
                            (Pens.Blue, cellWidth * i, cellHeight * j, cellWidth * (i + 1), cellHeight * (j + 1));
                        graphics.DrawLine
                           (Pens.Blue, cellWidth * (i + 1), cellHeight * j, cellWidth * i, cellHeight * (j + 1));
                        break;
                }
                var winState = board.GetWinState();
                if (winState.Item1)
                {
                    if (winState.Item2 != null)
                    {
                        MessageBox.Show($"{winState.Item2} wins!");
                    }
                    else
                    {
                        MessageBox.Show($"Its a tie!");
                    }
                    board = new Board(5, 5, 3);
                    buttonStart_Click(new object(), new System.EventArgs());
                    currentFigure = TypeOfFigure.Circle;
                }
            }
            return result;
        }

        private void ChangeCurrentFigure()
        {
            if (currentFigure == TypeOfFigure.Cross)
            {
                currentFigure = TypeOfFigure.Circle;
            }
            else
            {
                currentFigure = TypeOfFigure.Cross;
            }
        }

        private void pictureBoxTicTakToe_Click(object sender, System.EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            var cellWidth = pictureBoxTicTakToe.Width / (board.Width);
            var cellHeight = pictureBoxTicTakToe.Height / (board.Height);
            var result = DrawTurn(currentFigure, coordinates.X / cellWidth, coordinates.Y / cellHeight);
            if (result)
            {
                ChangeCurrentFigure();
            }
        }
    }
}
