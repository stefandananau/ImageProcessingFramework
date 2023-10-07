using Emgu.CV;
using Emgu.CV.Structure;
using System;
using static System.Math;

namespace Algorithms.Utilities
{
    public class Utils
    {
        #region Change pixel color
        public static void SetPixelColor<TColor>(Image<TColor, byte> inputImage, int row, int column, TColor pixel)
            where TColor : struct, IColor
        {
            if (row >= 0 && row < inputImage.Height && column >= 0 && column < inputImage.Width)
            {
                inputImage[row, column] = pixel;
            }
        }
        #endregion

        #region Combine two images
        public static Image<Bgr, byte> Combine(IImage leftImage, IImage rightImage, int borderWidth = 0)
        {
            Image<Bgr, byte> img1 = (leftImage is Image<Gray, byte> grayImg1) ? grayImg1.Convert<Bgr, byte>() : leftImage as Image<Bgr, byte>;
            Image<Bgr, byte> img2 = (rightImage is Image<Gray, byte> grayImg2) ? grayImg2.Convert<Bgr, byte>() : rightImage as Image<Bgr, byte>;

            int maxHeight = Max(img1.Height, img2.Height);
            int maxWidth = Max(img1.Width, img2.Width);

            Image<Bgr, byte> result = new Image<Bgr, byte>(2 * maxWidth + borderWidth, maxHeight);

            int remainingHeight = 0, remainingWidth = 0;

            if (img1.Height != maxHeight || img1.Width != maxWidth)
            {
                remainingHeight = (maxHeight - img1.Height) / 2;
                remainingWidth = (maxWidth - img1.Width) / 2;
            }

            for (int y = remainingHeight; y < img1.Height + remainingHeight; ++y)
            {
                for (int x = remainingWidth; x < img1.Width + remainingWidth; ++x)
                {
                    result[y, x] = img1[y - remainingHeight, x - remainingWidth];
                }
            }

            remainingHeight = remainingWidth = 0;

            if (img2.Height != maxHeight || img2.Width != maxWidth)
            {
                remainingHeight = (maxHeight - img2.Height) / 2;
                remainingWidth = (maxWidth - img2.Width) / 2;
            }

            for (int y = remainingHeight; y < img2.Height + remainingHeight; ++y)
            {
                for (int x = remainingWidth + maxWidth + borderWidth; x < img2.Width + remainingWidth + maxWidth + borderWidth; ++x)
                {
                    result[y, x] = img2[y - remainingHeight, x - remainingWidth - maxWidth - borderWidth];
                }
            }

            return result;
        }
        #endregion

        #region Compute histogram
        public static int[] ComputeHistogram(Image<Gray, byte> inputImage)
        {
            int[] histogram = new int[256];

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    ++histogram[inputImage.Data[y, x, 0]];
                }
            }

            return histogram;
        }

        public static int[] ComputeHistogram(Image<Bgr, byte> inputImage, int channel)
        {
            int[] histogram = new int[256];

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    ++histogram[inputImage.Data[y, x, channel]];
                }
            }

            return histogram;
        }
        #endregion

        #region Swap
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            (rhs, lhs) = (lhs, rhs);
        }
        #endregion

        #region Means
        public static int[] GetVector(Image<Gray, byte> inputImage)
        {
            var vector = new int[inputImage.Width * inputImage.Height];
            int k = 0;
            for(int i = 0; i < inputImage.Height; i++)
            {
                for(int j = 0; j < inputImage.Width; j++)
                {
                    vector[k] = inputImage.Data[i, j, 0];
                    k++;
                }
            }
            return vector;
        }

        public static int[,] GetMatrix(Image<Bgr, byte> inputImage)
        {
            int[,] matrix = new int[3, inputImage.Width * inputImage.Height];
            int k = 0;
            for (int i = 0; i < inputImage.Height; i++)
            {
                for (int j = 0; j < inputImage.Width; j++)
                {
                    matrix[0, k] = inputImage.Data[i, j, 0];
                    matrix[1, k] = inputImage.Data[i, j, 1];
                    matrix[2, k] = inputImage.Data[i, j, 2];
                    k++;
                }
            }
            return matrix;
        }

        public static int[] SquareVector(int[] vector)
        {
            int[] result = new int[vector.Length];
            for(int i = 0; i < vector.Length; i++) 
            {
                result[i] = vector[i] * vector[i];
            }
            return result;
        }

        public static double VectorMean(int[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum = sum + vector[i];
            }
            return sum/vector.Length;
        }
        #endregion
    }
}