using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {

            //////How many player?
            int playerCount;           
            Console.WriteLine("How many players are there?");
            while (!int.TryParse(Console.ReadLine(), out playerCount))
            {
                Console.WriteLine("Please input a correct value.");
            }/////////////////////////////
           
            
            
            //initializing variables for general method operations
            Double[,] playerBattingRecords = new Double[playerCount,2];
            string[] playerDirectory = new string[playerCount];
            //////////////////////////////


            //Modifying the player arrays in method
            for (int i = 0; i < playerCount; i++)
            {
                getPlayerStats(playerBattingRecords,playerDirectory,i);
            }
            ////////////////////////////


            //Display
            Console.WriteLine();
            Console.WriteLine("PLAYER DATA ");
            Console.WriteLine("========================================================================");
            Console.WriteLine();
            for (int i = 0; i < playerDirectory.Length; i++)
            {
                Console.Write(String.Format("Batter {0,-1} : {1,-10} |", i+1,playerDirectory[i]));

                for (int j = 0; j < 2; j++)
                {
                    string metric="";
                    if (j == 0)
                        metric = "average :";
                    else if (j ==1)
                        metric = "slugging percentage :";

                    Console.Write(String.Format(" {0,-5} {1, -5} | ", metric, playerBattingRecords[i, j].ToString("#.00")));                 
                }
                Console.WriteLine();
            }///////////////////////////
            Console.WriteLine();
            Console.WriteLine("========================================================================");
            Console.WriteLine();

        }////MAIN

        private static void getPlayerStats(Double[,] playerBattingRecords, string[] playerDirectory, int index)
        {
           
            ///Initializing player info array and batting metric variables
            //ArrayList playerinfo = new ArrayList();
            int hitCount = 0;
            int hitSum = 0;
            double battingAvg = 0;
            double slugPercent = 0;

            Console.WriteLine(String.Format("What is the name of player {0,0}?",index+1));
            string playerName = Console.ReadLine();
            playerDirectory[index] = playerName;
            ////////////////////////////////////////////
            


            ///At Bats input and validation
            int atBats;
            Console.WriteLine(String.Format("How many at bats did {0,0} have?", playerName));
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out atBats))
                {
                    Console.WriteLine("Please input a correct value.");
                }
                if (atBats >= 0)
                {
                    break;
                }
                else
                    Console.WriteLine("Please enter a non negative number.");
            }/////////////////////////////////////////////////



            ///hits for each at bat input and validation          
            int hit;
            for (int i = 0; i < atBats; i++)
            {
                Console.WriteLine(String.Format("For at bat number {0,0} what happened? (How many bases, if any, were obtained from the hit?) ",i+1));
                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(), out hit))
                    {
                        Console.WriteLine("Please input a correct value.");
                    }
                    if (hit >= 0 && hit <= 4)
                    {
                        if (hit > 0)
                        {
                            hitCount += 1;
                            hitSum += hit;
                        }
                        break;
                    }
                    else
                        Console.WriteLine("Please enter a value from 1 - 4");
                }
            }/////////////////////////////////////////



            //Calculating batting stats and populating the Batting Record Array
            battingAvg =Math.Round((double)hitCount / atBats, 3);
            slugPercent = Math.Round((double)hitSum / atBats, 3);
            playerBattingRecords[index, 0] = battingAvg;
            playerBattingRecords[index, 1] = slugPercent;
                      
        }

    }////PROGRAM
}////CLASS

