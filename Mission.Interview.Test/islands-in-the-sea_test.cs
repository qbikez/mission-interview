using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Interview.Test
{
    [TestClass]
    public class islands_in_the_sea_test
    {
        protected virtual IIslands CreateIslands() => new islands_in_the_sea();

        [TestMethod]
        public void sample_1()
        {
            var i = CreateIslands();

            // Example 1:
            var ocean = new[] {
                new[] { 1, 1, 1, 1, 0 },
                new[] { 1, 1, 0, 1, 0 },
                new[] { 1, 1, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0 }
            };
            //Answer: 1

            int expected = 1;

            int c = i.GetIslandsCount(ocean);

            Assert.AreEqual(expected, c);

        }

        [TestMethod]
        public void sample_2()
        {
            var i = CreateIslands();

            // Example 1:
            var ocean = new[] {

              new[] {1, 1, 0, 0, 0},
              new[] {1, 1, 0, 0, 0},
              new[] {0, 0, 1, 0, 0},
              new[] {0, 0, 0, 1, 1}
            };
            //Answer: 1

            int expected = 3;

            int c = i.GetIslandsCount(ocean);

            Assert.AreEqual(expected, c);
        }


        [TestMethod]
        public void gotcha_1()
        {
            var i = CreateIslands();

            // Example 1:
            var ocean = new[] {

              new[] {1, 1, 0, 0, 0},
              new[] {1, 1, 0, 0, 0},
              new[] {0, 0, 1, 0, 1},
              new[] {0, 0, 1, 1, 1}
            };
            //Answer: 1

            int expected = 2;

            int c = i.GetIslandsCount(ocean);

            Assert.AreEqual(expected, c);
        }
    }

    [TestClass]
    public class islands_in_the_sea_rob_test : islands_in_the_sea_test
    {
        protected override IIslands CreateIslands() => new islands_in_the_sea_rob();
    }
    }
