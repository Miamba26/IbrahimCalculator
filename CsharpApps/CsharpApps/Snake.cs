using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpApps
{
    internal class Snake
    {
        public void RunApp()
        {
            int xPosition = 35;
            int yPosition = 20;
            int appleXDim = 10;
            int appleYDim = 10;
            int applesEaten = 0;

            decimal gameSpeed = 150m;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;

            Random random = new Random();

            // Place snake on screen
            Console.SetCursorPosition(xPosition, yPosition);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((char)214);

            // Set apple on screen
            setApplePositionOnScreen(random, out appleXDim, out appleYDim);
            paintApple(appleXDim, appleYDim);

            // Create Boundary
            buildWall();

            // Snake move

            ConsoleKey command = Console.ReadKey().Key;

            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.WriteLine(" ");
                        xPosition--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.WriteLine(" ");
                        yPosition--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.WriteLine(" ");
                        xPosition++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.WriteLine(" ");
                        yPosition++;
                        break;
                }

                Console.SetCursorPosition(xPosition, yPosition);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine((char)214);

                isWallHit = DidSnakeHitWall(xPosition, yPosition);

                // Detect when snake hits boundary
                if (isWallHit)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("Snake hit the wall and died!");
                }

                // Detect when apple was eaten
                isAppleEaten = determineIfAppleWasEaten(xPosition, yPosition, appleXDim, appleYDim);

                // Place apple on board (random)
                if (isAppleEaten)
                {
                    setApplePositionOnScreen(random, out appleXDim, out appleYDim);
                    paintApple(appleXDim, appleYDim);
                    applesEaten++;
                    gameSpeed *= .925m;
                }

                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                // Slow game down
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (isGameOn);

        }

        private static void buildWall()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.WriteLine("#");
                Console.SetCursorPosition(70, i);
                Console.WriteLine("#");
            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("#");
                Console.SetCursorPosition(i, 40);
                Console.WriteLine("#");
            }
        }

        private static void setApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(0 + 2, 70 - 2);
            appleYDim = random.Next(0 + 2, 40 - 2);
        }

        private static void paintApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && yPosition == appleYDim) return true; return false;
        }

        // Detect when snake hits boundary
        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
        }
    }
}