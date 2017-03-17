namespace ArrayShuffler.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class GetRandomIntegerTest
    {
        [TestMethod]
        public void GetRandomIntegerZeroZero()
        {
            var result = Shuffler.GetRandomNumber(0, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetRandomIntegerZeroOne()
        {
            var result = Shuffler.GetRandomNumber(0, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetRandomIntegerOneZero()
        {
            var result = Shuffler.GetRandomNumber(1, 0);
        }
        
        [TestMethod]
        public void GetRandomIntegerMinusTwoMinusOne()
        {
            var result = Shuffler.GetRandomNumber(-2, -1);
            Assert.IsTrue(result >= -2);
            Assert.IsTrue(result < -1);
        }

        [TestMethod]
        public void GetRandomIntegerOneTwo()
        {
            var result = Shuffler.GetRandomNumber(1, 2);
            Assert.IsTrue(result >= 1);
            Assert.IsTrue(result < 2);
        }

        [TestMethod]
        public void GetRandomIntegerFourSix()
        {
            var result = Shuffler.GetRandomNumber(4, 6);
            Assert.IsTrue(result >= 4);
            Assert.IsTrue(result < 6);
        }

        [TestMethod]
        public void GetRandomIntegerMinusSixMinusFour()
        {
            var result = Shuffler.GetRandomNumber(-6, -4);
            Assert.IsTrue(result >= -6);
            Assert.IsTrue(result < 4);
        }

        [TestMethod]
        public void GetRandomIntegerMinMaxIntegers()
        {
            var result = Shuffler.GetRandomNumber(int.MinValue, int.MaxValue);
            Assert.IsTrue(result >= int.MinValue);
            Assert.IsTrue(result < int.MaxValue);
        }
        
        [TestMethod]
        [TestCategory("ProbabilisticTest")]
        public void GetRandomIntegerCallsReturnDifferentValues()
        {
            var value1 = Shuffler.GetRandomNumber(int.MinValue, int.MaxValue);
            var value2 = Shuffler.GetRandomNumber(int.MinValue, int.MaxValue);
            var value3 = Shuffler.GetRandomNumber(int.MinValue, int.MaxValue);

            if (value1 == value2 && value2 == value3 && value3 == value1)
            {
                Assert.Inconclusive("Unprobable result. Rerun the test. All three numbers have the same value : {0}.", value1);
            }            
        }

        [TestMethod]
        [TestCategory("ProbabilisticTest")]
        public void RandomIntegersHaveSimilarProbabilityOfOccurence()
        {
            var frequency = new int[6];

            for (var i = 0; i < 6 * 40000; i++)
            {
                frequency[Shuffler.GetRandomNumber(1, 7) - 1]++;
            }

            double distance = ShufflerTestHelper.ComputeDistance(frequency, 40000);

            if (distance >= 850)
            {
                Assert.Inconclusive("Unprobable result. Rerun the test. The distance is expected to be less than 850. The actual distance is {0}.", distance);
            }
        }
    }
}
