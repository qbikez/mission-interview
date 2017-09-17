using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Interview.Test
{
    /// <summary>
    /// Given a 2d grid map of ‘1’s (land) and '0’s (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
    ///   // Example 1:
    ///       const ocean = [
    ///         [1, 1, 1, 1, 0],
    ///         [1, 1, 0, 1, 0],
    ///         [1, 1, 0, 0, 0],
    ///         [0, 0, 0, 0, 0]
    ///   ];
    ///   //Answer: 1
    ///
    ///   //Example 2:
    ///   const ocean2 = [
    ///     [1, 1, 0, 0, 0],
    ///     [1, 1, 0, 0, 0],
    ///     [0, 0, 1, 0, 0],
    ///     [0, 0, 0, 1, 1]
    ///   ];
    ///   //Answer: 3
    /// </summary>
    public class islands_in_the_sea : IIslands
    {
        class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public int GetIslandsCount(int[][] ocean)
        {
            // islands are 1's connected vertically or horizontally
            // (this seems like a graph)
            // * start at [0,0] and find first land 
            // * do a BFS to find all adjacent land
            // * mark visited land (set value to 2)
            // * when no more land is available, find next unvisited land field and start over
            // * continue until all fields are visited

            // assume array is rectangular (all rows have the same length)

            Point start = new Point(0,0);
            int islands = 0;
            while((start = GetUnvisitedLand(ocean, start)) != null)
            {
                MarkIslandVisited(ocean, start);
                islands++;
            }

            return islands;
        }

        private void MarkIslandVisited(int[][] ocean, Point start)
        {
            Stack<Point> toVisit = new Stack<Point>();

            toVisit.Push(start);

            while(toVisit.Count > 0)
            {
                var cur = toVisit.Pop();
                // check all four directions
                // left
                if (cur.x > 0 && ocean[cur.x - 1][cur.y] == 1) toVisit.Push(new Point(cur.x - 1, cur.y));
                // right
                if (cur.x < ocean.Length - 1 && ocean[cur.x + 1][cur.y] == 1) toVisit.Push(new Point(cur.x + 1, cur.y));
                // up
                if (cur.y > 0 && ocean[cur.x][cur.y - 1] == 1) toVisit.Push(new Point(cur.x, cur.y-1));
                // down
                if (cur.y < ocean[cur.x].Length - 1 && ocean[cur.x][cur.y+1] == 1) toVisit.Push(new Point(cur.x, cur.y+1));

                // use 2 to indicate visited land
                ocean[cur.x][cur.y] = 2;
            }
        }

        private Point GetUnvisitedLand(int[][] ocean, Point lastVisited)
        {
            for(int x = lastVisited.x; x < ocean.Length; x++)
            {
                for (int y = 0; y < ocean[x].Length; y++)
                {
                    if (ocean[x][y] == 1) return new Point(x, y);
                }
            }

            return null;
        }
    }

    /// <summary>
    /// a simple interface to easier testing of multiple solutions
    /// </summary>
    public interface IIslands
    {
        int GetIslandsCount(int[][] ocean);
    }

}
