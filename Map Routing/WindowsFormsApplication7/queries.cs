using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WindowsFormsApplication7
{
    public class queries
    {

        public int Number_Of_Queries;//number of queries to find its shortest path
        public double[] Start_X_Coordinate;//array contains all the starting X_coordinates of the queries
        public double[] Start_Y_Coordinate;//array contains all the starting Y_coordinates of the queries
        public double[] Destination_X_Coordinate;//array contains all the Ending X_coordinates of the queries
        public double[] Destination_Y_Coordinate;//array contains all the Ending Y_coordinates of the queries
        public double[] R;//array contains all the R????? of the queries
        
        string[] All_file;
        public queries(string queries_file)
        {
            All_file = File.ReadAllLines(queries_file + ".txt");
            ReadQueries();
        }
        private void ReadQueries()//read the number of queries and their data from file
        {
            string[] Query_Data = new string[5];

           
            Number_Of_Queries = Convert.ToInt32(All_file[0]);// read the number of queries
            Start_X_Coordinate = new double[Number_Of_Queries];
            Start_Y_Coordinate = new double[Number_Of_Queries];
            Destination_X_Coordinate = new double[Number_Of_Queries];
            Destination_Y_Coordinate = new double[Number_Of_Queries];
            R = new Double[Number_Of_Queries];

            for (int i = 0; i < Number_Of_Queries; i++)//read all queries data
            {
                Query_Data = All_file[i + 1].Split(' ');

                Start_X_Coordinate[i] = Convert.ToDouble(Query_Data[0]);//read the Start_X_Coordinate of the query
                Start_Y_Coordinate[i] = Convert.ToDouble(Query_Data[1]);//read the Start_Y_Coordinate of the query
                Destination_X_Coordinate[i] = Convert.ToDouble(Query_Data[2]);//read the Ending_X_Coordinate of the query
                Destination_Y_Coordinate[i] = Convert.ToDouble(Query_Data[3]);//read the Ending_Y_Coordinate of the query
                R[i] = Convert.ToDouble(Query_Data[4]);//read the R of the query
            }

        }
        public void print_q()
        {
            for (int i = 0; i < Number_Of_Queries; i++)
            {
                Console.WriteLine(Start_X_Coordinate[i] + " " + Start_Y_Coordinate[i] + " " +
                    Destination_X_Coordinate[i] + "  " + Destination_Y_Coordinate[i] + " R = " + R[i]);
            }
        }
    }
}
