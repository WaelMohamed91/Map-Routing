using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace WindowsFormsApplication7
{
  
    class CheckCorrectness
    {
        double[] totalTime;
        double[] totalDistance;
        double[] walkingDistance;
        double[] vehcileDistance;
        int[] executionTime;
        int totalExecutionTimeForallQueries;
        StreamReader Read_OutPut;
        int QueriesNo;
        public CheckCorrectness(string outputFile, int QueriesNo)
        {
            Read_OutPut = new StreamReader(outputFile + ".txt");
            this.QueriesNo = QueriesNo;
            totalTime = new double[QueriesNo];
            totalDistance = new double[QueriesNo];
            walkingDistance = new double[QueriesNo];
            vehcileDistance = new double[QueriesNo];
            executionTime = new int[QueriesNo];
            totalExecutionTimeForallQueries = 0;

            ReadOutPutFile();
        }
        void ReadOutPutFile()
        {
            string[] line = new string[2];
            for (int i = 0; i < QueriesNo; i++)
            {
                //first line in one case is the total time
                line = Read_OutPut.ReadLine().Split(' ');
                totalTime[i] = Convert.ToDouble(line[0]);

                //second line in one case is the total distance
                line = Read_OutPut.ReadLine().Split(' ');
                totalDistance[i] = Convert.ToDouble(line[0]);

                //third line in one case is the total walking distance
                line = Read_OutPut.ReadLine().Split(' ');
                walkingDistance[i] = Convert.ToDouble(line[0]);

                //fourth line in one case is the total vehcile distance
                line = Read_OutPut.ReadLine().Split(' ');
                vehcileDistance[i] = Convert.ToDouble(line[0]);

                //fifth line in one case is the execution time
                line = Read_OutPut.ReadLine().Split(' ');
                executionTime[i] = Convert.ToInt32(line[0]);

                // move to the next test case
                Read_OutPut.ReadLine();

            }
            // the last line in the file contains the total execution time
            line = Read_OutPut.ReadLine().Split(' ');
            totalExecutionTimeForallQueries = Convert.ToInt32(line[0]);
            Read_OutPut.Close();
        }
        public void printTestcases()
        {
            for (int i = 0; i < QueriesNo; i++)
            {
                Console.WriteLine("Total Time = " + totalTime[i] + " mins");
                Console.WriteLine("Total Distance = " + totalDistance[i] + " Km");
                Console.WriteLine("Total Walking Distance = " + walkingDistance[i] + " Km");
                Console.WriteLine("Total Vehcile Distance = " + vehcileDistance[i] + " Km");
                Console.WriteLine("Execution Time = " + executionTime[i] + " ms");
                Console.WriteLine();
            }
            Console.WriteLine("Total Execution Time = " + totalExecutionTimeForallQueries + " ms");
        }
        public string checkoutput(double totaltime, double totaldistance, double totalwalkingdistance, double totalvehciledistance, int executiontime, int testcase)
        {
            string message = "Case # " + (testcase + 1).ToString() + " Succeeded";
            if (totalTime[testcase] != totaltime)
                message = "Wrong Answer in Case # " + (testcase + 1).ToString() +
                    " in Total Time\nYour Result = " + totaltime
                    + " -- Actual Result = " + totalTime[testcase];

            else if (totalDistance[testcase] != totaldistance)
                message = "Wrong Answer in Case # " + (testcase + 1).ToString() +
                    " in Total Distance\nYour Result = " + totaldistance
                    + " -- Actual Result = " + totalDistance[testcase];

            else if (walkingDistance[testcase] != totalwalkingdistance)
                message = "Wrong Answer in Case # " + (testcase + 1).ToString() +
                    " in Total Walking Distance\nYour Result = " + totalwalkingdistance
                    + " -- Actual Result = " + walkingDistance[testcase];

            else if (vehcileDistance[testcase] != totalvehciledistance)
                message = "Wrong Answer in Case # " + (testcase + 1).ToString() +
                    " in Total Vehcile Distance\nYour Result = " + totalvehciledistance
                    + " -- Actual Result = " + vehcileDistance[testcase];

            // else if (executionTime[testcase] < executiontime)
            //   message = "Time Exceed in Case # " + (testcase+1).ToString() +
            //     " \nRunning Time Toke " + executiontime;
            return message;

        }

    }
}
