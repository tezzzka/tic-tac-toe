using System;
using System.Threading;
using System.IO;

namespace ttt_dev
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; 
        static int choice; 
        static int flag = 0;
        static int times = 0;
        static int limit = 3;
        static int[] wins = {0,0,0}; 

        static void Main(string[] args)
        {

            while (times < limit) {
                for (int i=0;i<10;i++){
                    arr[i]=(char)(i+48);
                }

                do
                {
                    Console.Clear();
                    Console.WriteLine("Player1:X and Player2:O");
                    Console.WriteLine("Game {0}/{1}\n",times+1,limit);
                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Player 2 Chance");
                    }
                    else
                    {
                        Console.WriteLine("Player 1 Chance");
                    }
                    Console.WriteLine("\n");
                    Board();
                    choice = int.Parse(Console.ReadLine());
            
                    if (arr[choice] != 'X' && arr[choice] != 'O')
                    {
                        if (player % 2 == 0) 
                        {
                            arr[choice] = 'O';
                            player++;
                        }
                        else
                        {
                            arr[choice] = 'X';
                            player++;
                        }
                    }
                    else
   
                    {
                        Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                        Console.WriteLine("\n");
                        Thread.Sleep(2000);
                    }
                    flag = CheckWin();
                }
                while (flag != 1 && flag != -1);
                Console.Clear();
                Board();
                if (flag == 1)
           
                {
                    Console.WriteLine("Player {0} has won", (player % 2) + 1);
                    wins[(player % 2) + 1]=wins[(player % 2) + 1]+1;
                }
                else
                {
                    Console.WriteLine("Draw");
                    wins[2]=wins[2]+1;
                }
                Console.ReadLine();
                times++;
                
            }
            Console.WriteLine("***********{0},{1},{2}",wins[0],wins[1],wins[2]);
            Console.ReadLine();

            StreamWriter f = new StreamWriter("game.txt");
            f.WriteLine(wins[0]);
            f.WriteLine(wins[1]);
            f.WriteLine(wins[2]);
            f.Close();
            
        }
       
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
       
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
           
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
         
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
   
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
   
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
         
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
          
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}
