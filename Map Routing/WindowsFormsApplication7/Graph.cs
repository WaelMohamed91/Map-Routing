using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication7
{
    public class Graph
    {

        public int Number_Of_Intersection; //number of intersection in the map
        public int Number_Of_Roads;// number of roads in the map

        //list that contains the x_coordinates and y_coordinates of all intersection in the map 
        public List<Tuple<double, double>> intersections = new List<Tuple<double, double>>(); // using in design 


        //list contains the data of all the roads in the map(first intersection, second intersection,length and speed of the road)

        public List<List<Tuple<int, double, double>>> Nodes_edges = new List<List<Tuple<int, double, double>>>();
        public List<List<Tuple<int, double, double>>> Nodes_edgesFordrawing = new List<List<Tuple<int, double, double>>>();
       
        string[] All_File;
        public Graph(string Map_file)
        {

            All_File = File.ReadAllLines(Map_file + ".txt");
            add_Intersection();
            add_roads();
        }

        

        public void add_Intersection() //storing intersections in the list(intersections)
        {

            string[] Intersection_data = new string[3];
            Number_Of_Intersection = Convert.ToInt32(All_File[0]); //read the number of intersection in the map
            double x, y;
            for (int i = 0; i < Number_Of_Intersection; i++) //read all the intersections_data
            {
                Intersection_data = All_File[i + 1].Split(' ');
                x = Convert.ToDouble(Intersection_data[1]); //read the x_coordinate of the intersection
                y = Convert.ToDouble(Intersection_data[2]); //read the y_coordinate of the intersection
                intersections.Add(Tuple.Create(x, y)); //Adding the intersection to the list(intersections)
                Nodes_edges.Add(new List<Tuple<int, double, double>>());//initializing a list of edges to this intersection
                Nodes_edgesFordrawing.Add(new List<Tuple<int, double, double>>());//initializing a list of edges to this intersection

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
                Nodes_edgesFordrawing[intersection1].Add(Tuple.Create(intersection2, road_Length, Speed));
            }
        }

        public void print()
        {
            for (int i = 0; i < Number_Of_Intersection; i++)
            {

                Console.WriteLine(intersections[i].Item1 + "   " + intersections[i].Item2);
            }
            for (int i = 0; i < Number_Of_Intersection; i++)
            {
                foreach (var edge in Nodes_edges[i])
                {
                    Console.WriteLine(i + " Connected with " + edge.Item1 + " " + edge.Item2 + "  " + edge.Item3);
                }

            }

        }
    }
}
