using System.Drawing;
using System.Windows.Forms;
using TicTakLib;

namespace TicTackToe
{
    public partial class TicTakToeMainForm : Form
    {
        private Board board;
        private Player[] players;
        public TicTakToeMainForm()
        {
            InitializeComponent();
            board = new Board(3, 3, 3);
            players = new Player[2];
            players[0] = new UserPlayer(TypeOfFigure.Cross);
            players[1] = new UserPlayer(TypeOfFigure.Circle);
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

        private void DrawTurn(TypeOfFigure typeOfFigure, int i, int j)
        {
            Graphics graphics = pictureBoxTicTakToe.CreateGraphics();
            var cellWidth = pictureBoxTicTakToe.Width / (board.Width);
            var cellHeight = pictureBoxTicTakToe.Height / (board.Height);
            switch (typeOfFigure)
            {
                case TypeOfFigure.Circle:
                    var pen = new Pen(Color.Red, 3);
                    graphics.DrawEllipse(pen, cellWidth * i, cellHeight * j, cellWidth, cellHeight);
                    break;
                case TypeOfFigure.Cross:
                    graphics.DrawLine
                        (Pens.Blue, cellWidth * i, cellHeight * j, cellWidth * (i + 1), cellHeight * (j + 1));
                    graphics.DrawLine
                       (Pens.Blue, cellWidth * (i + 1), cellHeight * j, cellWidth * i, cellHeight * (j + 1));
                    break;
            }
        }

        private void pictureBoxTicTakToe_Click(object sender, System.EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            var cellWidth = pictureBoxTicTakToe.Width / (board.Width);
            var cellHeight = pictureBoxTicTakToe.Height / (board.Height);
            DrawTurn(TypeOfFigure.Cross, coordinates.X / cellWidth, coordinates.Y / cellHeight);
        }
    }
}
