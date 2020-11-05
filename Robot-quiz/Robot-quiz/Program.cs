/*
 * There is a robot which can move around on a grid. 
 * The robot is placed at point (0,0). From (x, y) the robot can move to (x+1, y), (x-1, y), (x, y+1), and (x, y-1). 
 * Some points are dangerous and contain EMP Mines. 
 * To know which points are safe, 
 * we check whether the sum digits of abs(x) plus the sum of the digits of abs(y) are less than or equal to 23. 
 * For example, the point (59, 75) is not safe because 5 + 9 + 7 + 5 = 26, which is greater than 23. 
 * The point (-51, -7) is safe because 5 + 1 + 7 = 13, which is less than 23.
 * 
 * How large is the area that the robot can access?*/

namespace Robot_quiz
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const int square = 1000;    // size 
        private static List<Position> moves = new List<Position>() {
                new Position (-1, 0),    // Down
                new Position (1, 0),     // Up
                new Position (0, -1),    // Left
                new Position (0, 1)      // Right
        };
        private static bool[,] grid = new bool[square * 2, square * 2];    //gives us a list of positions that were already visited
        private static int safePosition = 0;                                //Counts the safe positions
        private static Queue<Position> positions = new Queue<Position>();   // will contain the last safe position



        static void Main(string[] args)
        {
            positions.Enqueue(new Position(0, 0));  // add to the queue the position (0,0)
            grid[0 + square, 0 + square] = true;    //position of the origin point in our grid
            safePosition = 1;   // counting the first safe area is (0,0) 

            getSizeOfSafeArea();
        }


        static void getSizeOfSafeArea()
        {
            //this loop checks if there are any safe positions
            while (positions.Count != 0)
            {
                // remove the last position and assign the value to the variable lastPosition
                Position lastPosition = positions.Dequeue();

                // loop around the moves that our robot can do
                // the following block of code will check if the available moves are safe or not for the robot 
                foreach (var move in moves)
                {
                    int coordinateX = lastPosition.getAbsyX() + move.getAbsyX();    //get new x position
                    int coordinateY = lastPosition.getAbsyY() + move.getAbsyY();    //get new y position

                    int sumX = digitsSum(coordinateX);  //sums every digit of x value
                    int sumY = digitsSum(coordinateY);  //sums every digit of y value

                    //checks if it is safe and checks if the robot has been already in this position 
                    if (sumX + sumY < 24 && !grid[coordinateX + square, coordinateY + square])
                    {
                        grid[coordinateX + square, coordinateY + square] = true;    //mark this new position as visited
                        positions.Enqueue(new Position(coordinateX, coordinateY));  //adds this position to the queue
                        safePosition++; //increment safePosition. 
                    }

                }
            }
            Console.WriteLine("The size of the area that the robot can access is " + safePosition);
        }

        // this method sums all the digits of a number.
        // Example: 59
        // 5 + 9 = 14
        static int digitsSum(int n)
        {
            int sum = 0;

            n = Math.Abs(n);

            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }
    }
}
