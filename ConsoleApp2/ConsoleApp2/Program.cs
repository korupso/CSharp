using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                "Which exercise do you want to start?".Println();
                "0: Sum of 3s and 5s".Println();
                "1: Sum of even fibonaccis".Println();
                "2: Tic Tac Toe".Println();
                "Enter your choice: ".Print();
                string choice = Console.ReadLine();
                redo:
                if (choice == "0") Exercise1();
                else if (choice == "1") Exercise2();
                else if (choice == "2") Exercise3();
                else
                {
                    "Invalid input, try again: ".Print();
                    choice = Console.ReadLine();
                    goto redo;                              // I purposefully used goto here, because I'd otherwise need a boolean and a while loop.
                }
            }
        }

        public static void Exercise1()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    nums.Add(i);
                }
            }

            int res = 0;
            foreach (int n in nums)
            {
                res += n;
            }
            res.Println();
            MyExtensions.Wait();
        }

        public static void Exercise2()
        {
            List<int> nums = new List<int>();
            int a = 1;
            int b = 2;
            while (a <= 4000000 && b <= 4000000)
            {
                nums.Add(a);
                a += b;
                nums.Add(b);
                b += a;
            }

            int res = 0;
            foreach (int n in nums)
            {
                if (n % 2 == 0) res += n;
            }
            res.Println();
            MyExtensions.Wait();
        }

        // From here on only the tic tac toe
        public static void Exercise3()
        {
            List<string> board = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                board.Add(" ");
            }
            while (true)
            {
                Console.Clear();
                BoardToString(board).Println();
                Turn(1, board);
                if (IsFinished(board))
                {
                    "Player 1 Won!\nPlay again? (yes/no) ".Print();
                    string input = Console.ReadLine().ToLower();
                    Console.Clear();
                    if (input == "yes" || input == "y") Exercise3();
                    break;
                }
                Console.Clear();
                BoardToString(board).Println();
                Turn(2, board);
                if (IsFinished(board))
                {
                    "Player 2 Won!\nPlay again? (yes/no) ".Print();
                    string input = Console.ReadLine().ToLower();
                    Console.Clear();
                    if (input == "yes" || input == "y") Exercise3();
                    break;
                }
            }
        }

        private static Boolean IsFinished(List<string> board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2] && board[i * 3] != " ") return true;
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i] != " ") return true;
            }
            if (board[0] == board[4] && board[4] == board[8] && board[0] != " ") return true;
            if (board[2] == board[4] && board[4] == board[6] && board[2] != " ") return true;
            Boolean finished = true;
            foreach (string cell in board)
            {
                if (cell == " ") finished = false;
            }
            return finished;
        }
        
        private static void Turn(int player, List<string> board)
        {
            ("It's player " + player + "s turn: ").Print();
            string input = "";
            input = Console.ReadLine();
            while (input.Length != 2)
            {
                "Invalid input, try again: ".Print();
                input = Console.ReadLine();
            }
            while (board[ConvertInput(input)] != " ")
            {
                "Cell is already filled, try again: ".Print();
                input = Console.ReadLine();
            }
            board[ConvertInput(input)] = player == 1 ? "X" : "O";
        }

        private static int ConvertInput(string input)
        {
            return ((int)input.ElementAt(0) - 97 + ((int)input.ElementAt(1) - 49) * 3);
        }

        private static string BoardToString(List<string> board)
        {
            string res = "   a     b     c\n";
            string empty = "      |     |     \n";
            string horizontal = " _____|_____|_____\n";
            res += empty;
            res += "1  " + board[0] + "  |  " + board[1] + "  |  " + board[2] + "\n";
            res += horizontal;
            res += empty;
            res += "2  " + board[3] + "  |  " + board[4] + "  |  " + board[5] + "\n";
            res += horizontal;
            res += empty;
            res += "3  " + board[6] + "  |  " + board[7] + "  |  " + board[8] + "\n";
            res += empty;
            return res;
        }
    }
}
