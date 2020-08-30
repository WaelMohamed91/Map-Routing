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
    public partial class Speed : Form
    {
        public Speed()
        {
            InitializeComponent();
            draw_panal.Width = panel1.Left;
        }
        Graph graph;
        queries queries;
        ShortestPathAlgorithm sssp;
        int TestCaseNo;
        float scl;
        int roadwide;
        int intersectionwide;
        

        void drawSourceDestination(queries Q, int index, Panel c, float scl)
        {
            Graphics g = c.CreateGraphics();
            float xS = (float)Q.Start_X_Coordinate[index] * scl;
            float yS = (float)Q.Start_Y_Coordinate[index] * scl;
            g.DrawRectangle(new Pen(Color.Red), xS, yS, 15, 15);
            Font font = new Font("Courier New", 12f, FontStyle.Bold);

            g.DrawString("Source", font, Brushes.White, xS, yS);

            float xD = (float)Q.Destination_X_Coordinate[index] * scl;
            float yD = (float)Q.Destination_Y_Coordinate[index] * scl;
            g.DrawRectangle(new Pen(Color.Red), xD, yD, 15, 15);
            g.DrawString("Destination", font, Brushes.White, xD, yD);


        }
        public void drawMap (List<List<Tuple<int, double, double>>> Nodes_edges, List<Tuple<double, double>> intersections, Panel p, float scl)
        {

            Graphics g = p.CreateGraphics();

            int counter = 1;

            for (int i = 0; i < intersections.Count; i++)
            {
                foreach (var edge in Nodes_edges[i])
                {
                    float x1 = (float)intersections[i].Item1 * scl;
                    float y1 = (float)intersections[i].Item2 * scl;

                    float x2 = (float)intersections[edge.Item1].Item1 * scl;
                    float y2 = (float)intersections[edge.Item1].Item2 * scl;
                    g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                    g.DrawLine(new Pen(Color.DarkGray, roadwide), x1, y1, x2, y2);
                    Font font = new Font("Courier New", 12f, FontStyle.Bold);

                    //e.Graphics.DrawString(edge.Item2.ToString(), font, Brushes.Black, (x2-x1)/2, (y2 - y1) / 2);
                }

            }
            foreach (var point in intersections)
            {
                float vX = (float)point.Item1 * scl;
                float vY = (float)point.Item2 * scl;
                g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                

                g.DrawEllipse(new Pen(Color.DarkRed, intersectionwide), vX, vY, intersectionwide, intersectionwide);
                Font font = new Font("Courier New", 12f, FontStyle.Bold);

                // g.DrawString(counter.ToString(), font, Brushes.White, vX, vY);
                counter++;
            }

        }
        public void drawShortestPath(List<Tuple<double, double>> intersections, List<int> shortestpath, Panel p, float scl)
        {
            Graphics g = p.CreateGraphics();
            float xfirst = (float)intersections[shortestpath[1]].Item1 * scl;
            float yfirst = (float)intersections[shortestpath[1]].Item2 * scl;
            float ystart = (float)queries.Start_Y_Coordinate[TestCaseNo] * scl;
            float xstart = (float)queries.Start_X_Coordinate[TestCaseNo] * scl;
            g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            g.DrawLine(new Pen(Color.Green, roadwide - 2), xfirst, yfirst, xstart, ystart);

            float xlast = (float)intersections[shortestpath[shortestpath.Count - 2]].Item1 * scl;
            float ylast = (float)intersections[shortestpath[shortestpath.Count - 2]].Item2 * scl;
            float yD = (float)queries.Destination_Y_Coordinate[TestCaseNo] * scl;
            float xD = (float)queries.Destination_X_Coordinate[TestCaseNo] * scl;
            g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            g.DrawLine(new Pen(Color.Green, roadwide - 2), xlast, ylast, xD, yD);
            for (int index = 1; index < shortestpath.Count - 2; index++)
            {

                float x1 = (float)intersections[shortestpath[index]].Item1 * scl;
                float y1 = (float)intersections[shortestpath[index]].Item2 * scl;
                float x2 = (float)intersections[shortestpath[index + 1]].Item1 * scl;
                float y2 = (float)intersections[shortestpath[index + 1]].Item2 * scl;
                g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                g.DrawLine(new Pen(Color.Blue, roadwide), x1, y1, x2, y2);

            }
        }
        private void fixed_speed_Click(object sender, EventArgs e)
        {
            
        }

        private void Map_SelectedIndexChanged(object sender, EventArgs e)
        {


            int sample = 10;
            int midlarge = 1000;
            label3.Visible = true;
            if (Map.SelectedIndex == 0)
            { label3.Text = "1 Query"; queriesNo = 1; }
            else if (Map.SelectedIndex > 4)
            { label3.Text = "From 1 to " + midlarge.ToString(); queriesNo = 1000; }
            else
            {
                label3.Text = "From 1 to " + sample.ToString();
                queriesNo = 10;
            }
           
        }
        int GraphConstructionTime;
        float zoom =1.07F;
        int queriesNo;
        private void Draw_Click(object sender, EventArgs e)
        {

            if (Map.Text == "")
                MessageBox.Show("Select Map First !", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else if (Qery_text.text == "" || Convert.ToInt32(Qery_text.text) > queriesNo) 
                MessageBox.Show("Invalid Query Number !", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                Short_Path.Enabled = true;
                //Graph.Map_file = Map.SelectedItem.ToString();
                Stopwatch ConstructionTime = Stopwatch.StartNew();
                graph = new Graph(Map.SelectedItem.ToString());
                ConstructionTime.Stop();
                GraphConstructionTime = (int)ConstructionTime.ElapsedMilliseconds;
                // G.add_Intersection();
                //G.add_roads();
                scl = 0.079F;
                roadwide = 3;
                intersectionwide = 1;
                if (Map.SelectedIndex == 5)
                    queries = new queries("OLQueries");
                else if (Map.SelectedIndex == 6)
                    queries = new queries("SFQueries");
                else
                {
                    queries = new queries("queries" + (Map.SelectedIndex + 1).ToString());
                    roadwide = 20;
                    intersectionwide = 10;
                    scl = 400;
                    if (Map.SelectedIndex > 1)
                        scl = 20;
                }
                panel2.Visible = false;
                Graphics g = draw_panal.CreateGraphics();

                g.Clear(draw_panal.BackColor);
                g.ScaleTransform(zoom, zoom);
                TestCaseNo = Convert.ToInt32(Qery_text.text) - 1;
                drawMap(graph.Nodes_edgesFordrawing, graph.intersections, draw_panal, scl);
                drawSourceDestination(queries, TestCaseNo, draw_panal, scl);
            }
           
        }

        private void Short_Path_Click(object sender, EventArgs e)
        {
            if (Map.Text == "")
                MessageBox.Show("Select Map First !", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else if (Qery_text.text == "" || Convert.ToInt32(Qery_text.text) > queries.Number_Of_Queries)
                MessageBox.Show("Invalid Query Number !", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                sssp = new ShortestPathAlgorithm();
                Stopwatch AlgoTime = Stopwatch.StartNew();
                sssp.Calculate_ShortestPath(graph, queries, TestCaseNo);
                AlgoTime.Stop();
                int AlgorithmTime = (int)AlgoTime.ElapsedMilliseconds;
                int TotalExecutionTime = GraphConstructionTime + AlgorithmTime;

                panel2.Visible = true;
                totaldisL.Text = sssp.totalDistance.ToString() + " Km";
                totaltimeL.Text = sssp.totalTime.ToString() + " mins";
                walkingdL.Text = sssp.totalWalkingDistance.ToString() + " Km";
                vehdL.Text = sssp.totalVehD.ToString() + " Km";
                executionTimeL.Text = AlgorithmTime.ToString() + " ms";
                drawShortestPath(graph.intersections, sssp.shortest_path_nodes, draw_panal, scl);

            }

        }

       
        private void draw_panal_Paint(object sender, PaintEventArgs e)
        {
            
            
            

        }

        private void draw_panal_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
          
                
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Map.Text == "")
                MessageBox.Show("Select Map First !", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                Cursor = Cursors.WaitCursor;
                CheckAllTestcases c = new CheckAllTestcases(Map.SelectedItem.ToString());
                c.Show();
                Cursor = Cursors.Arrow;
           
                
            }
            
        }
    }
}
