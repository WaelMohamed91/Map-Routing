using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsApplication7
{
    public partial class CheckAllTestcases : Form
    {
        public CheckAllTestcases()
        {
            InitializeComponent();

        }
        Graph graph;
        queries queries;
        CheckCorrectness ch;
        ShortestPathAlgorithm shortest;
        string mapFile;
        bool first = true;
        public CheckAllTestcases(string mapfile)
        {
            InitializeComponent();
            mapFile = mapfile;
            richTextBox1.AppendText("*** " + mapFile + " ***\nClick here to Start\n\n");



        }
        
        void check(string mapfile)
        {
            
            if (mapfile == "OLMap")
            {
                queries = new queries("OLQueries");
                ch = new CheckCorrectness("OLOutput", queries.Number_Of_Queries);
            }
            else if (mapfile == "SFMap")
            {
                queries = new queries("SFQueries");
                ch = new CheckCorrectness("SFOutput", queries.Number_Of_Queries);

            }
            else
            {
                if (mapfile == "map1")
                {
                    queries = new queries("queries1");
                    ch = new CheckCorrectness("output1", queries.Number_Of_Queries);
                }
                else if (mapfile == "map2")
                {
                    queries = new queries("queries2");
                    ch = new CheckCorrectness("output2", queries.Number_Of_Queries);
                }
                else if (mapfile == "map3")
                {
                    queries = new queries("queries3");
                    ch = new CheckCorrectness("output3", queries.Number_Of_Queries);
                }
                else if (mapfile == "map4")
                {
                    queries = new queries("queries4");
                    ch = new CheckCorrectness("output4", queries.Number_Of_Queries);
                }
                else if (mapfile == "map5")
                {
                    queries = new queries("queries5");
                    ch = new CheckCorrectness("output5", queries.Number_Of_Queries);
                }

            }
            graph = new Graph(mapfile);
            shortest = new ShortestPathAlgorithm();
            string m;
            bool accepted = true;
            for (int i = 0; i < queries.Number_Of_Queries; i++)
            {
                Stopwatch s = Stopwatch.StartNew();
                shortest.Calculate_ShortestPath(graph, queries, i);
                s.Stop();
                richTextBox1.AppendText("Total Time = " + shortest.totalTime.ToString() + " mins\n");
                richTextBox1.AppendText("Total Distance = " + shortest.totalDistance.ToString() + " Km\n");
                richTextBox1.AppendText("Total Walking Distance = " + shortest.totalWalkingDistance.ToString() + " Km\n");
                richTextBox1.AppendText("Total Vehcile Distance = " + shortest.totalVehD.ToString() + " Km\n");
                richTextBox1.AppendText("Execution Time = " + (int)s.ElapsedMilliseconds + " ms\n");
                m = ch.checkoutput(shortest.totalTime, shortest.totalDistance, shortest.totalWalkingDistance, shortest.totalVehD, (int)s.ElapsedMilliseconds, i);
                richTextBox1.AppendText(m + "\n");
                richTextBox1.AppendText("\n");
                if (m != "Case # " + (i + 1).ToString() + " Succeeded")
                {
                    accepted = false;
                    break;
                }
                richTextBox1.ScrollToCaret();
                
              
            }
            if (accepted)
                richTextBox1.AppendText("All Cases Succeeded\n");
        }

        private void CheckAllTestcases_Load(object sender, EventArgs e)
        {
            
           
        }

        private void CheckAllTestcases_Enter(object sender, EventArgs e)
        {
           
        }

        private void CheckAllTestcases_Activated(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_ReadOnlyChanged(object sender, EventArgs e)
        {
           

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if(first)
            check(mapFile);
            first = false;

        }
    }
}
