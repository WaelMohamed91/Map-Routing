using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace WindowsFormsApplication7
{
    public class ShortestPathAlgorithm
    {
        List<int> shortest_path_nodes1;
        List<int> shortest_path_nodes2;
        public List<int> shortest_path_nodes;
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
         public void Calculate_ShortestPath_AllQueries(Graph G, queries Q)//calc and construct the shortest path of each query
         {
             for (int i = 0; i < Q.Number_Of_Queries; ++i)
             {
                Stopwatch Sw = Stopwatch.StartNew();

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
                //    dijkstra(G, Q.Start_X_Coordinate[i], Q.Start_Y_Coordinate[i], Q.Destination_X_Coordinate[i], Q.Destination_Y_Coordinate[i], Q.R[i]);
                int end_point = dijkstra_Two_Way(G, Q, i);
                construct_two_way_dijkstra_path(G, end_point);
                totalTime =(double)Math.Round((decimal)((time[end_point] + time_End[end_point])*60),2);
                totalDistance =(double)Math.Round((decimal)( distance[end_point] + distance_End[end_point]),2);
                totalWalkingDistance =(double)Math.Round((decimal)(distance[shortest_path_nodes[1]] + distance_End[shortest_path_nodes[shortest_path_nodes.Count - 2]]),2);
                totalVehD =(double)Math.Round((decimal)(totalDistance - totalWalkingDistance),2);
                Sw.Stop();

                
                Console.WriteLine("Time = " + (totalTime));
               // totalDistance = Math.Round(totalDistance, 2);
                Console.WriteLine("Distance = " + totalDistance);
                Console.WriteLine("Walking Distance = " + totalWalkingDistance + " km");
                Console.WriteLine("Vehicle Distance = " + totalVehD + " km");

                // Console.WriteLine("Shortest path Contains Intersection ");
                /*for (int w = 1; w <shortest_path_nodes.Count-1; w++)
                {
                    Console.Write(shortest_path_nodes[w] + "  " );
                }
                Console.WriteLine();*/

                Console.WriteLine("Excution Time = " + Sw.ElapsedMilliseconds);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
         }

        public void Calculate_ShortestPath(Graph G, queries Q, int i)//calc and construct the shortest path of each query
        {

            Stopwatch Sw = Stopwatch.StartNew();

        

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
            //    dijkstra(G, Q.Start_X_Coordinate[i], Q.Start_Y_Coordinate[i], Q.Destination_X_Coordinate[i], Q.Destination_Y_Coordinate[i], Q.R[i]);
            int end_point = dijkstra_Two_Way(G, Q, i);
            construct_two_way_dijkstra_path(G, end_point);
            totalTime = (time[end_point] + time_End[end_point]) * 60;
            totalDistance = distance[end_point] + distance_End[end_point];
            totalWalkingDistance = distance[shortest_path_nodes[1]] + distance_End[shortest_path_nodes[shortest_path_nodes.Count - 2]];
            totalVehD = totalDistance - totalWalkingDistance;
            Sw.Stop();

            totalTime = (double)Math.Round((decimal)(totalTime), 2);
            Console.WriteLine("Time = " + totalTime);
            //  Console.WriteLine("Time = " + Math.Round(totalTime * 60,2));

            totalDistance = (double)Math.Round((decimal)totalDistance, 2);
            Console.WriteLine("Distance = " + totalDistance);
            totalWalkingDistance = (double)Math.Round((decimal)totalWalkingDistance, 2);
            Console.WriteLine("Walking Distance = " + totalWalkingDistance + " km");
            totalVehD = (double)Math.Round((decimal)totalVehD, 2);
            Console.WriteLine("Vehicle Distance = " + totalVehD + " km");

            // Console.WriteLine("Shortest path Contains Intersection ");
            /*for (int w = 1; w <shortest_path_nodes.Count-1; w++)
            {
                Console.Write(shortest_path_nodes[w] + "  " );
            }
            Console.WriteLine();*/

            Console.WriteLine("Excution Time = " + Sw.ElapsedMilliseconds);





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
            for (int i = count1 - 1; i >= 0; i--)
                shortest_path_nodes.Add(shortest_path_nodes1[i]);
            shortest_path_nodes.Add(real_end_index);
            int count2 = shortest_path_nodes2.Count;
            for (int i = 0; i < count2; i++)
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
}
