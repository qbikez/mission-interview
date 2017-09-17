using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Interview.Test
{
    public class islands_in_the_sea_rob : IIslands
    {
        public int GetIslandsCount(int[][] ocean)
        {
            var islandCount = 0;
            int[] lastRow = null;

            foreach (var row in ocean)
            {
                int lastCoordinate = -1;

                for (int i = 0; i < row.Length; i++)
                {
                    var thisCoordinate = row[i];
                    var thisIsLand = thisCoordinate == 1;
                    var continuingIsland = false;

                    if (thisIsLand && lastCoordinate == 1)
                    {
                        continuingIsland = true;
                    }
                    else if (lastRow != null && lastRow[i] == 1)
                    {
                        continuingIsland = true;
                    }

                    if (thisIsLand && !continuingIsland)
                    {
                        islandCount++;
                    }

                    lastCoordinate = thisCoordinate;
                }

                lastRow = row;
            }

            return islandCount;
        }


    }
}
