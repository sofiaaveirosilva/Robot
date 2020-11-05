namespace Robot_quiz
{
    public class Position
    {
        private int x, y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getAbsyX()
        {
            return this.x;
        }

        public int getAbsyY()
        {
            return this.y;
        }
    }
}
