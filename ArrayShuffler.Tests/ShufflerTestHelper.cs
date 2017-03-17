namespace ArrayShuffler.Tests
{
    using System;

    public static class ShufflerTestHelper
    {
        public static double ComputeDistance(int[] array, int referencePoint)
        {
            if (array.Length != 6)
            {
                throw new ArgumentException();
            }

            var vector = new long[]
            {
                array[0] - referencePoint,
                array[1] - referencePoint,
                array[2] - referencePoint,
                array[3] - referencePoint,
                array[4] - referencePoint,
                array[5] - referencePoint
            };

            var distanceTo100000 = Math.Sqrt(
                (vector[0] * vector[0]) +
                (vector[1] * vector[1]) +
                (vector[2] * vector[2]) +
                (vector[3] * vector[3]) +
                (vector[4] * vector[4]) +
                (vector[5] * vector[5]));

            return distanceTo100000;
        }
    }
}
