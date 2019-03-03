namespace TicTakLib
{
    public class Cell
    {
        private TypeOfFigure? typeOfFigure;
        public Cell()
        {
            typeOfFigure = null;
        }

        public bool SetFigure(TypeOfFigure typeOfFigure)
        {
            bool result = false;
            if (this.typeOfFigure == null)
            {
                this.typeOfFigure = typeOfFigure;
                result = true;
            }

            return result;
        }
        
        public TypeOfFigure? GetFigure()
        {
            return typeOfFigure;
        }
    }
}
