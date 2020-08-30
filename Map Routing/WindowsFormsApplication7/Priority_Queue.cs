using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication7
{

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
}
