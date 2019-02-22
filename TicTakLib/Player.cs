namespace TicTakLib
{
    public abstract class Player
    {
        private TypeOfFigure typeOfFigure;
        public Player(TypeOfFigure typeOfFigure)
        {
            this.typeOfFigure = typeOfFigure;
        }

        public abstract void MakeTurn(Board board);
    }
}
