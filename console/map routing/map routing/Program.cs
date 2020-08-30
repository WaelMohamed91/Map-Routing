using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics; 

namespace map_routing
{
    
    class queries
    {

        public int Number_Of_Queries;//number of queries to find its shortest path
        public double[] Start_X_Coordinate ;//array contains all the starting X_coordinates of the queries
        public double[] Start_Y_Coordinate;//array contains all the starting Y_coordinates of the queries
        public double[] Destination_X_Coordinate;//array contains all the Ending X_coordinates of the queries
        public double[] Destination_Y_Coordinate;//array contains all the Ending Y_coordinates of the queries
        public double[] R;//array contains all the R????? of the queries

        
        public void ReadQueries()//read the number of queries and their data from file
        {
            string[] Query_Data = new string[5]; 
        

            string[] All_file = File.ReadAllLines("OLQueries.txt");

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
        
    }
    class Graph
    {
        public int Number_Of_Intersection; //number of intersection in the map
        public int Number_Of_Roads;// number of roads in the map

        //list that contains the x_coordinates and y_coordinates of all intersection in the map 
        public List<Tuple<double, double>> intersections = new List<Tuple<double, double>>(); // using in design 

        //list contains the data of all the roads in the map(first intersection, second intersection,length and speed of the road)
      
    public List<List<Tuple<int, double, double>>> Nodes_edges = new List<List<Tuple<int, double, double>>>();
       
        string[] All_File = File.ReadAllLines("OLMap.txt");
        
        public void add_Intersection() //storing intersections in the list(intersections)
        {
            
            string[] Intersection_data = new string[3];
            Number_Of_Intersection=Convert.ToInt32(All_File[0]); //read the number of intersection in the map
            double x, y;
            for(int i=0;i<Number_Of_Intersection;i++) //read all the intersections_data
            {
                Intersection_data = All_File[i+1].Split(' ');
                x = Convert.ToDouble(Intersection_data[1]); //read the x_coordinate of the intersection
                y = Convert.ToDouble(Intersection_data[2]); //read the y_coordinate of the intersection
                intersections.Add(Tuple.Create(x, y)); //Adding the intersection to the list(intersections)
            Nodes_edges.Add(new List<Tuple<int, double , double>>());//initializing a list of edges to this intersection
            }
        }

        public void add_roads()//stores all the roads in the list(intersections_edges)
        {

            Number_Of_Roads = Convert.ToInt32(All_File[Number_Of_Intersection + 1]); //reading the number of roads in them  map
            string[] road_data = new string[4];
            int intersection1, intersection2;
            double road_Length, Speed;
            for (int i = Number_Of_Intersection + 1; i <= Number_Of_Roads + Number_Of_Intersection; i++)// read all the roads_data
            {
                road_data = All_File[i + 1].Split(' ');
                intersection1 = Convert.ToInt32(road_data[0]);//read the first intersection of the road
                intersection2 = Convert.ToInt32(road_data[1]);//read the second intersection of the road
                road_Length = Convert.ToDouble(road_data[2]);//read the road length
                Speed = Convert.ToDouble(road_data[3]);//read the road speed
                                                       //adding the road to the list(intersections_edges)
                Nodes_edges[intersection1].Add(Tuple.Create(intersection2, road_Length, Speed));
                Nodes_edges[intersection2].Add(Tuple.Create(intersection1, road_Length, Speed));
            }
        }
    }
    class shortest_path
    {
        List<int> shortest_path_nodes1;
        List<int> shortest_path_nodes2;
      public  List<int> shortest_path_nodes;
        List<int> Available_Starting_Intersections;//List contain all the Available_Starting_Intersections of a certain query
        List<int> Available_Ending_Intersections;//List contain all the Available_Starting_Intersections of a certain query
        double[] time;// array for storing the shortest time to reach each intersection for a cretain query  
        double[] time_End;
        double[] distance;// array for storing distance to reach each intersection for a cretain query
        double[] distance_End;
        int[] parent;// array for storing the parent(best intersection to come from) of each intersection for a cretain query
        int[] parent_End;
        public double totalTime;
        public double totalDistance;
        public double totalWalkingDistance;
        public double totalVehD;

        public double ExcuationTime_withOut_InOut = 0; 
        public void Calculate_ShortestPath(Graph G, queries Q,int i)//calc and construct the shortest path of each query
        {
           

            Stopwatch timer_without = Stopwatch.StartNew(); 
                //initializing the time  , distance , and parent arrays for this query
                int number_of_intersection_plus_2 = G.Number_Of_Intersection + 2; // for speed 
                time = new double[number_of_intersection_plus_2];
                time_End = new double[number_of_intersection_plus_2];
                distance = new double[number_of_intersection_plus_2];
                distance_End = new double[number_of_intersection_plus_2];
                parent = new int[number_of_intersection_plus_2];
                parent_End = new int[number_of_intersection_plus_2];
                shortest_path_nodes1 = new List<int>();
                shortest_path_nodes2 = new List<int>();
                shortest_path_nodes = new List<int>();
                //initializing the Available_Starting_Intersections and vailable_Ending_Intersections  lists for this query
                Available_Starting_Intersections = new List<int>();
                Available_Ending_Intersections = new List<int>();
                // initial times 
                for (int j = 0; j < number_of_intersection_plus_2; ++j)
                { time[j] = 1e15; time_End[j] = 1e15; }

                int number_of_intersection = G.Number_Of_Intersection; // for speed ; 
                for (int j = 0; j < number_of_intersection; ++j)
                {
                //Console.WriteLine(Q.Number_Of_Queries);

                double distance_toSource = Math.Sqrt(Math.Pow(Q.Start_X_Coordinate[i] - G.intersections[j].Item1, 2) + Math.Pow(Q.Start_Y_Coordinate[i] - G.intersections[j].Item2, 2));

                //checking for every intersection on the map if it can be included in (Available_Starting_Intersections or Available_Ending_Intersections) of this query
                if (distance_toSource * 1000 <= Q.R[i])
                {
                    Available_Starting_Intersections.Add(j);
                    if (time[j] > distance_toSource / 5)
                    {

                        // time to arrive from (X,Y) cordinates to source node 
                        time[j] = distance_toSource / 5;

                        //distance from (X,Y) cordinates to source
                        distance[j] = distance_toSource;
                        // parent of source equal to (X,Y) cordinates 
                        parent[j] = G.Number_Of_Intersection;
                    }
                    //find the shortest path for this starting node and changing the values of time array,distance array and parent array;
                    //dijkstra(G,j,Q.Start_X_Coordinate[i],Q.Start_Y_Coordinate[i],Q.Destination_X_Coordinate[i],Q.Destination_Y_Coordinate[i] , Q.R[i]);

                }

                double distance_from_distination_To_j = (Math.Sqrt(Math.Pow(G.intersections[j].Item1 - Q.Destination_X_Coordinate[i], 2) + Math.Pow(G.intersections[j].Item2 - Q.Destination_Y_Coordinate[i], 2)));
                //Console.WriteLine(u+" "+distance_from_u_to_distination);
                if (distance_from_distination_To_j * 1000 <= Q.R[i])
                {
                    Available_Ending_Intersections.Add(j);
                    // checke if time of distination more than new time by using new u node >> update
                    if (time_End[j] > (distance_from_distination_To_j / 5))
                    {
                        //Console.WriteLine(1);
                        // time to arrive from (X,Y) cordinates to source node 
                        time_End[j] = (distance_from_distination_To_j / 5);
                        //distance from (X,Y) cordinates to source
                        distance_End[j] = distance_from_distination_To_j;
                        // parent of source equal to (X,Y) cordinates 
                        parent_End[j] = G.Number_Of_Intersection + 1;

                    }

                }

            }

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                int end_point = dijkstra_Two_Way(G, Q, i);
                construct_two_way_dijkstra_path(G, end_point);

                totalTime = (time[end_point] + time_End[end_point])*60;
                totalDistance = distance[end_point] + distance_End[end_point];
                totalWalkingDistance = distance[shortest_path_nodes[0]] + distance_End[shortest_path_nodes[shortest_path_nodes.Count -1 ]];
                totalVehD = totalDistance - totalWalkingDistance;
              

                totalTime = (double)Math.Round((decimal)(totalTime), 2);
            totalDistance = (double)Math.Round((decimal)totalDistance, 2);

              totalWalkingDistance = (double)Math.Round((decimal)totalWalkingDistance, 2);
           

            //    totalWalkingDistance = Math.Round(totalWalkingDistance, 2);

            //    totalVehD = (double)Math.Round((decimal)totalVehD, 2);
            totalVehD = Math.Round(totalVehD, 2);
            timer_without.Stop();

            ExcuationTime_withOut_InOut += timer_without.ElapsedMilliseconds;

            // output Same of file output 
            for (int w = 1; w < shortest_path_nodes.Count - 1; w++)
            {
                Console.Write(shortest_path_nodes[w] + " ");
            }
            Console.WriteLine();
            // write Total time 
            Console.WriteLine( totalTime + "mins");
             
                Console.WriteLine( totalDistance +" km");
            // write walkingDistance 
                Console.WriteLine( totalWalkingDistance + " km");
               
                Console.WriteLine(totalVehD + " km");
            Console.WriteLine();
          

          //  Console.WriteLine("Excution Time = " + Sw.ElapsedMilliseconds); Note delete stopwatch
                
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            
        }
        public void construct_two_way_dijkstra_path(Graph G, int real_end_index)
        {
            //construct the first half of the path (path from source to real_end_index)
            //nodes added in reversed order
            int temp = real_end_index;
            while (temp != G.Number_Of_Intersection)
            {
                shortest_path_nodes1.Add(parent[temp]);
                temp = parent[temp];
            }
            //construct the second half of the path (path from real_end_index to destination)
            //nodes added in their right order
            temp = real_end_index;
            while (temp != G.Number_Of_Intersection + 1)
            {
                shortest_path_nodes2.Add(parent_End[temp]);
                temp = parent_End[temp];
            }

            //combine the first half and the second half of the path
            int count1 = shortest_path_nodes1.Count;
            for (int i = count1 - 2  ; i >= 0; i--)
                shortest_path_nodes.Add(shortest_path_nodes1[i]);
            shortest_path_nodes.Add(real_end_index);
            int count2 = shortest_path_nodes2.Count;
            for (int i = 0; i < count2-1 ; i++)
                shortest_path_nodes.Add(shortest_path_nodes2[i]);


        }
        public int dijkstra_Two_Way(Graph G, queries Q, int index)
        {
            double res = 1e17;
            int real_end_index = -1;
            bool[] visted = new bool[G.Number_Of_Intersection + 2];
            for (int i = 0; i < G.Number_Of_Intersection + 2; i++) visted[i] = false;
            Priority_Queue PQ = new Priority_Queue(time);
            Priority_Queue PQ_End = new Priority_Queue(time_End);
            PQ.buildHeap();
            PQ_End.buildHeap();
            while (true)
            {

                int u = PQ.extractMin();
                int num_of_neighbours_of_u = G.Nodes_edges[u].Count;  // for speed 
                for (int j = 0; j < num_of_neighbours_of_u; j++)
                {
                    // retrive index of adjecent (المجاورة) vertex of minimum node (u) 
                    int Current_index = G.Nodes_edges[u][j].Item1;
                    // time from u to one of the  neighbours 
                    double time_to_neighbour = G.Nodes_edges[u][j].Item2 / G.Nodes_edges[u][j].Item3;

                    if (time[u] + time_to_neighbour < time[Current_index])
                    {

                        time[Current_index] = time[u] + time_to_neighbour;

                        PQ.heap_update_key(Current_index, time[u] + time_to_neighbour);

                        distance[Current_index] = distance[u] + G.Nodes_edges[u][j].Item2;
                        parent[Current_index] = u;

                    }


                }

                //checking if this node u may be on the shortest path between source and destination 
                if (time[u] + time_End[u] < res)
                {
                    res = time[u] + time_End[u];
                    real_end_index = u;
                }

                if (visted[u] == true) { break; }
                visted[u] = true;

                int u_End = PQ_End.extractMin();

                int num_of_neighbours_of_u_End = G.Nodes_edges[u_End].Count;  // for speed 
                for (int j = 0; j < num_of_neighbours_of_u_End; j++)
                {
                    // retrive index of adjecent (المجاورة) vertex of minimum node (u) 
                    int Current_index = G.Nodes_edges[u_End][j].Item1;
                    // time from u to one of the  neighbours 
                    double time_to_neighbour = G.Nodes_edges[u_End][j].Item2 / G.Nodes_edges[u_End][j].Item3;

                    if (time_End[u_End] + time_to_neighbour < time_End[Current_index])
                    {

                        time_End[Current_index] = time_End[u_End] + time_to_neighbour;

                        PQ_End.heap_update_key(Current_index, time_End[u_End] + time_to_neighbour);

                        distance_End[Current_index] = distance_End[u_End] + G.Nodes_edges[u_End][j].Item2;
                        parent_End[Current_index] = u_End;

                    }


                }
                //checking if this node u_End may be on the shortest path between source and destination
                if (time[u_End] + time_End[u_End] < res)
                {
                    res = time[u_End] + time_End[u_End];
                    real_end_index = u_End;
                }
                if (visted[u_End] == true) { break; }
                visted[u_End] = true;


            }
            return real_end_index;
        }


    }
    class Priority_Queue
    {
        int size_PQ;
        List<Tuple<int, double>> time_PQ;

        int[] index_in_heap;
        public Priority_Queue(double[] time)
        {
            size_PQ = time.Length - 2;
            time_PQ = new List<Tuple<int, double>>();
            index_in_heap = new int[size_PQ];
            for (int i = 0; i < size_PQ; i++)
            {
                time_PQ.Add(Tuple.Create(i, -time[i]));
                index_in_heap[i] = i;
            }

        }


        public void exchange(int i, int j)
        {
            int temp_index = time_PQ[i].Item1;
            double temp_time = time_PQ[i].Item2;

            index_in_heap[time_PQ[j].Item1] = i;
            index_in_heap[time_PQ[i].Item1] = j;

            time_PQ[i] = Tuple.Create(time_PQ[j].Item1, time_PQ[j].Item2);
            time_PQ[j] = Tuple.Create(temp_index, temp_time);

        }

        public void heapify(int i)
        {
            int l = 2 * i;
            int r = 2 * i + 1;
            int largest = -1;

            if (l < size_PQ && time_PQ[l].Item2 > time_PQ[i].Item2)
                largest = l;
            else
                largest = i;
            if (r < size_PQ && time_PQ[r].Item2 > time_PQ[largest].Item2)
                largest = r;
            if (largest != i)
            {
                exchange(i, largest);
                heapify(largest);
            }
        }
        public void buildHeap()
        { 
            for (int i = size_PQ / 2; i >= 0; i--)
                heapify(i);
        }

        public int extractMin()
        {

            int max_id = time_PQ[0].Item1;
            size_PQ--;
            exchange(0, size_PQ);
            heapify(0);
            return max_id;
        }

        public void heap_update_key(int id, double new_time)
        {
            int index_heap = index_in_heap[id];

            time_PQ[index_heap] = Tuple.Create(id, -new_time);

            int parent = index_heap / 2;

            while (index_heap > 0 && time_PQ[parent].Item2 < time_PQ[index_heap].Item2)
            {
                exchange(parent, index_heap);
                index_heap = parent;
                parent = index_heap / 2;
            }
        }

        public bool empty()
        {
            if (size_PQ <= 0)
                return true;
            return false;
        }

    }
    class CheckCorrectness
    {
        double[] totalTime;
        double[] totalDistance;
        double[] walkingDistance;
        double[] vehcileDistance;
        int   [] executionTime;
        int totalExecutionTimeForallQueries;
        List<List<int>> path_nodes ; 
        StreamReader Read_OutPut;
        int QueriesNo;
       public CheckCorrectness(string outputFile,int QueriesNo)
        {
           

            Read_OutPut = new StreamReader(outputFile + ".txt");
            this.QueriesNo = QueriesNo;

            totalTime = new double[QueriesNo];

            totalDistance = new double[QueriesNo];

            walkingDistance = new double[QueriesNo];
            vehcileDistance = new double[QueriesNo];
            executionTime = new int[QueriesNo];
            totalExecutionTimeForallQueries = 0;
            path_nodes = new List<List<int>>(QueriesNo);

            ReadOutPutFile();
        }
        void ReadOutPutFile()
        {
            string[] line = new string[2];
            string[] Nodes;
            string first_line = ""; 
            for (int i = 0; i < QueriesNo; i++) 
            {
                first_line = Read_OutPut.ReadLine();
                Nodes = first_line.Split(' ');
                path_nodes.Add(new List<int>()); 
                for (int j = 0; j <Nodes.Length; j++)
                {
                    path_nodes[i].Add(int.Parse(Nodes[j])); 

                }
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
                // move to the next test case
                Read_OutPut.ReadLine();

            }

          /*  // the last line in the file contains the total execution time
            line = Read_OutPut.ReadLine().Split(' ');
            totalExecutionTimeForallQueries = Convert.ToInt32(line[0]); //*/

            Read_OutPut.Close();
        }
       public void printTestcases()
        {
            for (int i = 0;i<QueriesNo;i++)
            {
                for (int j = 0; j <path_nodes[i].Count;j++)
                {
                    Console.Write(path_nodes[i][j] + " "); 
                }
                Console.WriteLine(); 
                Console.WriteLine("Total Time = " + totalTime[i] + " mins");
                Console.WriteLine("Total Distance = " + totalDistance[i] + " Km");
                Console.WriteLine("Total Walking Distance = " + walkingDistance[i] + " Km");
                Console.WriteLine("Total Vehcile Distance = " + vehcileDistance[i] + " Km");
              
                Console.WriteLine();
            }
         
        }
        public string checkoutput(double totaltime, double totaldistance, double totalwalkingdistance , double totalvehciledistance ,int executiontime, int testcase , List<int> nodes)
        {
            string message = "Case # "+(testcase+1).ToString()+" Succeeded";
            for (int i = 0; i < path_nodes[testcase].Count ; i++)
            {
                if (nodes[i] !=  path_nodes[testcase][i] )
                {
                    message = "Wrong Answer in Case # " + (testcase + 1).ToString() + "At Shortest path Nodes "; 
                }
            }


           if (totalTime[testcase] != totaltime)
                message = "Wrong Answer in Case # " + (testcase+1).ToString() +
                    " in Total Time\nYour Result = " + totaltime
                    + " -- Actual Result = " + totalTime[testcase];

             if (totalDistance[testcase] != totaldistance)
                message = "Wrong Answer in Case # " + (testcase+1).ToString() +
                    " in Total Distance\nYour Result = " + totaldistance
                    + " -- Actual Result = " + totalDistance[testcase];

            else if (walkingDistance[testcase] != totalwalkingdistance)
                message = "Wrong Answer in Case # " + (testcase+1).ToString() +
                    " in Total Walking Distance\nYour Result = " + totalwalkingdistance
                    + " -- Actual Result = " + walkingDistance[testcase];

            else if (vehcileDistance[testcase] != totalvehciledistance)
                message = "Wrong Answer in Case # " + (testcase+1).ToString() +
                    " in Total Vehcile Distance\nYour Result = " + totalvehciledistance
                    + " -- Actual Result = " + vehcileDistance[testcase];

           // else if (executionTime[testcase] < executiontime)
             //   message = "Time Exceed in Case # " + (testcase+1).ToString() +
               //     " \nRunning Time Toke " + executiontime;
            return message;

        }
       
    }
    class Program
    {

        
        static void Main(string[] args)
        {
           queries Q = new queries();
            Stopwatch input_time = Stopwatch.StartNew();
            Q.ReadQueries();
            input_time.Stop();


            Graph G=new Graph();
            
             G.add_Intersection();
             G.add_roads();
          

            shortest_path P = new shortest_path(); 
            Stopwatch with_Out = Stopwatch.StartNew();
            for (int i = 0; i < Q.Number_Of_Queries; i++)
            {
              
                P.Calculate_ShortestPath(G, Q, i);
            }
            with_Out.Stop();
            Console.WriteLine();

            Console.WriteLine(P.ExcuationTime_withOut_InOut + " ms"   ) ;

            Console.WriteLine();

            Console.WriteLine((input_time.ElapsedMilliseconds + with_Out.ElapsedMilliseconds).ToString() + " ms" ); 



            // Remove /*  to start by auto Correction 
            /*
            List<int> wrong = new List<int>();
           CheckCorrectness che = new CheckCorrectness("OLOutput", Q.Number_Of_Queries);
          
            bool aCCEPTED = true ;
            int counter = 0;
            Stopwatch total = Stopwatch.StartNew();
            for (int i = 0;i<Q.Number_Of_Queries;i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                
                shortest_path P = new shortest_path();
                P.Calculate_ShortestPath(G, Q, i);

                sw.Stop();
                //Console.WriteLine("Case " + (i + 1).ToString() + "  " + (sw.ElapsedMilliseconds).ToString() + " ms");

                string m = che.checkoutput(P.totalTime, P.totalDistance, P.totalWalkingDistance, P.totalVehD,  (int)sw.ElapsedMilliseconds, i , P.shortest_path_nodes );
            
               Console.WriteLine(m);
                if (m != "Case # " + (i + 1).ToString() + " Succeeded")
                {
                    aCCEPTED = false;
                    //break;
                    counter++;
                    wrong.Add(i + 1);
                   
                }
                

            }
            total.Stop();
            Console.WriteLine("Total Execution Time = " + total.ElapsedMilliseconds);
            if (aCCEPTED)
                Console.WriteLine(" Yes AAAACCCCCEPPPTEEDDDD ");
            else
                Console.WriteLine(counter + " Cases are wrong");
            for (int i = 0; i < wrong.Count; ++i)
                Console.WriteLine(wrong[i]); // */


        }
    }
}
