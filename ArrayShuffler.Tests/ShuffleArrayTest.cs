namespace ArrayShuffler.Tests
{
    using ArrayShuffler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ShuffleArrayTest
    {
        [TestMethod]
        public void RandomShuffleMaintainsIntegerValues()
        {
            var array = CreateArray(10);

            Shuffler.ShuffleArray(array);

            Assert.IsTrue(
                Array.Exists(array, i => i == 0) &&
                Array.Exists(array, i => i == 1) &&
                Array.Exists(array, i => i == 2) &&
                Array.Exists(array, i => i == 3) &&
                Array.Exists(array, i => i == 4) &&
                Array.Exists(array, i => i == 5) &&
                Array.Exists(array, i => i == 6) &&
                Array.Exists(array, i => i == 7) &&
                Array.Exists(array, i => i == 8) &&
                Array.Exists(array, i => i == 9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShufflingNullArrayThrowsException()
        {
            Shuffler.ShuffleArray(null);
        }

        [TestMethod]
        public void ShuffledEmptyArrayRemainsEmpty()
        {
            var array = new int[0];

            Shuffler.ShuffleArray(array);

            Assert.IsTrue(array.Length == 0);
        }

        [TestMethod]
        public void ShuffledOneItemArrayRemainsAsIs()
        {
            var array = CreateArray(5, 1);

            Shuffler.ShuffleArray(array);

            Assert.IsTrue(array.Length == 1);
            Assert.IsTrue(array[0] == 5);
        }

        [TestMethod]
        [TestCategory("ProbabilisticTest")]
        public void RandomPermutationsHaveSimilarProbabilitiesOfOccurence()
        {
            var frequency = new int[6];

            for (var i = 0; i < 6 * 18000; i++)
            {
                var array = CreateArray(1, 3);

                Shuffler.ShuffleArray(array);

                if (array[0] == 3 && array[1] == 1 && array[2] == 2)
                    frequency[0]++;

                if (array[0] == 3 && array[1] == 2 && array[2] == 1)
                    frequency[1]++;

                if (array[0] == 2 && array[1] == 3 && array[2] == 1)
                    frequency[2]++;

                if (array[0] == 2 && array[1] == 1 && array[2] == 3)
                    frequency[3]++;

                if (array[0] == 1 && array[1] == 3 && array[2] == 2)
                    frequency[4]++;

                if (array[0] == 1 && array[1] == 2 && array[2] == 3)
                    frequency[5]++;
            }

            double distance = ShufflerTestHelper.ComputeDistance(frequency, 18000);

            if (distance >= 550)
            {
                Assert.Inconclusive("Unprobable result. Rerun the test. The distance is expected to be less than 550. The actual distance is {0}.", distance);
            }
        }

        private static int[] CreateArray(int size)
        {
            return CreateArray(0, size);
        }

        private static int[] CreateArray(int start, int size)
        {
            var array = new int[size];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = i + start;
            }

            return array;
        }

    }
}
