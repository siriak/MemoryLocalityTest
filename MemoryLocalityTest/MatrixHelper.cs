using System;

namespace MemoryLocalityTest
{
    internal static class MatrixHelper
    {
        public static void NaiveMultiplication(int[][] left, int[][] right, int[][] result)
        {
            var SIZE = left.Length;
            for (var i = 0; i < SIZE; i++)
            {
                for (var j = 0; j < SIZE; j++)
                {
                    for (var k = 0; k < SIZE; k++)
                    {
                        result[i][j] += left[i][k] * right[k][j];
                    }
                }
            }
        }

        public static void OptimizedMultiplication(int[][] left, int[][] right, int[][] result)
        {
            var SIZE = left.Length;
            for (var i = 0; i < SIZE; i++)
            {
                for (var k = 0; k < SIZE; k++)
                {
                    for (var j = 0; j < SIZE; j++)
                    {
                        result[i][j] += left[i][k] * right[k][j];
                    }
                }
            }
        }

        public static void OptimizedBlockedMultiplication(int[][] left, int[][] right, int[][] result, int blockSize)
        {
            var SIZE = left.Length;
            for (var ii = 0; ii < SIZE; ii += blockSize)
            {
                for (var kk = 0; kk < SIZE; kk += blockSize)
                {
                    for (var jj = 0; jj < SIZE; jj += blockSize)
                    {
                        var imax = Math.Min(ii + blockSize, SIZE);
                        for (var i = ii; i < imax; i++)
                        {
                            var kmax = Math.Min(kk + blockSize, SIZE);
                            for (var k = kk; k < kmax; k++)
                            {
                                var jmax = Math.Min(jj + blockSize, SIZE);
                                for (var j = jj; j < jmax; j++)
                                {
                                    result[i][j] += left[i][k] * right[k][j];
                                }
                            }
                        }
                    }
                }
            }
        }

        public static int[][] GetSquareMatrix(int size)
        {
            var matrix = new int[size][];

            for (var i = 0; i < size; i++)
            {
                matrix[i] = new int[size];
            }

            return matrix;
        }

        public static long GetTimeEstimate(long oldTime, int oldSize, int newSize) => oldSize == 0 ? 0 : (long)(oldTime * Math.Pow(newSize, 3) / Math.Pow(oldSize, 3));
    }
}
