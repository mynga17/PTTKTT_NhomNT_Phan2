using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTravelling
{
    class FindTravelling
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[,] graph = {
            {0, 10, 15, 20, 50},
            {10, 0, 35, 25, 15},
            {15, 35, 0, 30, 20},
            {20, 25, 30, 0, 10},
            {50, 15, 20, 10, 0}
        };
            FindTravel(graph, n);
            Console.ReadKey();
        }

        static void FindTravel(int[,] graph, int n)
        {
            bool[] visited = new bool[n]; // đánh dấu các điểm đã được thăm
            List<int> tour = new List<int>(); // danh sách tour lưu trữ đường đi
            int startNode = 0; // bắt đầu từ đỉnh 0
            int totalCost = 0; // chi phí ban đầu là 0

            visited[startNode] = true;
            tour.Add(startNode);

            while (tour.Count < n)
            {
                int nearestNode = -1;
                int minCost = int.MaxValue;

                // tìm đỉnh kế tiếp gần nhất chưa được thăm (có chi phí di chuyển nhỏ nhất)
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i] && graph[tour[tour.Count - 1], i] < minCost)
                    {
                        nearestNode = i;
                        minCost = graph[tour[tour.Count - 1], i];
                    }
                }

                // cập nhật tổng chi phí và đánh dấu đỉnh vừa chọn là đã thăm và thêm vào tour
                totalCost += minCost;
                visited[nearestNode] = true;
                tour.Add(nearestNode);
            }

            // Trở về điểm bắt đầu
            totalCost += graph[tour[tour.Count - 1], startNode];
            tour.Add(startNode);

            //In ra đường đi và tổng chi phí
            Console.WriteLine("Duong di:");
            foreach (int node in tour)
                Console.Write(node + " ");
            Console.WriteLine("\nTong chi phi: " + totalCost);
        }
    }
}