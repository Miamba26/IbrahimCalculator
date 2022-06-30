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
            Console.Clear();

            int[] xPosition = new int[50];
            xPosition[0] = 35;

            int[] yPosition = new int[50];
            yPosition[0] = 20;
            
            int applesEaten = 0;
            decimal gameSpeed = 150m;

            bool isGameOn = true;
            Random random = new();

            // Hide cursor
            Console.CursorVisible = false;

            // Place snake on screen
            SetApplePositionOnScreen(random, out int appleXDim, out int appleYDim);
            AppleStyle(appleXDim, appleYDim);

            // Set apple on screen
            SetApplePositionOnScreen(random, out appleXDim, out appleYDim);
            AppleStyle(appleXDim, appleYDim);

            // Create Boundary
            BuildWall();

            // Snake move
            ConsoleKey command = Console.ReadKey().Key;

            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.WriteLine(" ");
                        xPosition[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.WriteLine(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.WriteLine(" ");
                        xPosition[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.WriteLine(" ");
                        yPosition[0]++;
                        break;
                }

                // Paint the snake, Make snake longer
                SnakeStyle(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                bool hasSnakeHitWall = HasSnakeHitWall(xPosition[0], yPosition[0]);

                // Detect when snake hits boundary and show score
                if (hasSnakeHitWall)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(23, 20);
                    Console.WriteLine("Snake hit the wall and died!");
                    Console.WriteLine();
                    Console.SetCursorPosition(28, 21);
                    Console.WriteLine("Your score is: " + applesEaten * 50 + "!");
                }

                // Detect when apple was eaten
                bool isAppleEaten = WasAppleEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

                // Place apple on board (random)
                if (isAppleEaten)
                {
                    SetApplePositionOnScreen(random, out appleXDim, out appleYDim);
                    AppleStyle(appleXDim, appleYDim);
                    // Keep track of how many apples were eaten
                    // Make snake longer
                    applesEaten++;
                    // Make snake faster
                    gameSpeed *= .925m;
                }

                if (Console.KeyAvailable) command = Console.ReadKey().Key;

                // Slow game down
                Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (isGameOn);

            Console.ReadLine();
        }

        private static void BuildWall()
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

        private static void SetApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(0 + 2, 70 - 2);
            appleYDim = random.Next(0 + 2, 40 - 2);
        }

        private static void AppleStyle(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool WasAppleEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && yPosition == appleYDim) return true; return false;
        }

        private static void SnakeStyle(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            // Paint the head
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((char)214);

            // Paint the body
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[1], yPositionIn[1]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("o");
            }

            // Remove last part of snake
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            // Record location of each body part
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            // Return the new array
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;


        }

        private static bool HasSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
        }
    }
}