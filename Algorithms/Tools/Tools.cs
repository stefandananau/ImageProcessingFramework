using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System;
using OpenTK.Graphics.OpenGL;

namespace Algorithms.Tools
{
    public class Tools
    {
        #region Copy
        public static Image<Gray, byte> Copy(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = inputImage.Clone();
            return result;
        }

        public static Image<Bgr, byte> Copy(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = inputImage.Clone();
            return result;
        }
        #endregion

        #region Invert
        public static Image<Gray, byte> Invert(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = (byte)(255 - inputImage.Data[y, x, 0]);
                }
            }
            return result;
        }

        public static Image<Bgr, byte> Invert(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = (byte)(255 - inputImage.Data[y, x, 0]);
                    result.Data[y, x, 1] = (byte)(255 - inputImage.Data[y, x, 1]);
                    result.Data[y, x, 2] = (byte)(255 - inputImage.Data[y, x, 2]);
                }
            }
            return result;
        }
        #endregion

        #region Convert color image to grayscale image
        public static Image<Gray, byte> Convert(Image<Bgr, byte> inputImage)
        {
            Image<Gray, byte> result = inputImage.Convert<Gray, byte>();
            return result;
        }
        #endregion

        #region Thresholding
        public static Image<Gray, byte> Thresholding(Image<Gray, byte> inputImage, int threshold = 100)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    if (inputImage.Data[y, x, 0] >= threshold)
                    {
                        result.Data[y, x, 0] = 255;
                    }
                    else
                    {
                        result.Data[y, x, 0] = 0;
                    }
                    
                }
            }
            return result;
        }
        #endregion

        #region Mirror
        public static Image<Gray, byte> Mirror(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = inputImage.Data[y, inputImage.Width - x - 1 , 0];
                }
            }
            return result;
        }

        public static Image<Bgr, byte> Mirror(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = inputImage.Data[y, inputImage.Width - x - 1, 0];
                    result.Data[y, x, 1] = inputImage.Data[y, inputImage.Width - x - 1, 1];
                    result.Data[y, x, 2] = inputImage.Data[y, inputImage.Width - x - 1, 2];
                }
            }
            return result;
        }
        #endregion

        #region Clockwise Rotation
        public static Image<Gray, byte> ClockwiseRotation(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(height: inputImage.Width, width: inputImage.Height);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[x, y, 0] = inputImage.Data[inputImage.Height - y - 1, x, 0];
                }
            }
            return result;
        }

        public static Image<Bgr, byte> ClockwiseRotation(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(height:inputImage.Width, width: inputImage.Height);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[x, y, 0] = inputImage.Data[inputImage.Height - y - 1, x, 0];
                    result.Data[x, y, 1] = inputImage.Data[inputImage.Height - y - 1, x, 1];
                    result.Data[x, y, 2] = inputImage.Data[inputImage.Height - y - 1, x, 2];
                }
            }
            return result;
        }
        #endregion

        #region Anti Clockwise Rotation
        public static Image<Gray, byte> AntiClockwiseRotation(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(height: inputImage.Width, width: inputImage.Height);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[x, y, 0] = inputImage.Data[y, inputImage.Width - x - 1, 0];
                }
            }
            return result;
        }

        public static Image<Bgr, byte> AntiClockwiseRotation(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(height: inputImage.Width, width: inputImage.Height);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[x, y, 0] = inputImage.Data[y, inputImage.Width - x - 1, 0];
                    result.Data[x, y, 1] = inputImage.Data[y, inputImage.Width - x - 1, 1];
                    result.Data[x, y, 2] = inputImage.Data[y, inputImage.Width - x - 1, 2];
                }
            }
            return result;
        }
        #endregion

        #region Crop
        public static Image<Gray, byte> Crop(Image<Gray, byte> inputImage, Point leftTop, Point rightBottom)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(height: rightBottom.Y - leftTop.Y, width: rightBottom.X - leftTop.X);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    if (x >= leftTop.X && x < rightBottom.X && y >= leftTop.Y && y < rightBottom.Y)
                        result.Data[y - leftTop.Y, x - leftTop.X, 0] = inputImage.Data[y, x, 0];
                }
            }
            return result;
        }

        public static Image<Bgr, byte> Crop(Image<Bgr, byte> inputImage, Point leftTop, Point rightBottom)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(height: rightBottom.Y - leftTop.Y, width: rightBottom.X - leftTop.X);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    if (x >= leftTop.X && x < rightBottom.X && y >= leftTop.Y && y < rightBottom.Y)
                    {
                        result.Data[y - leftTop.Y, x - leftTop.X, 0] = inputImage.Data[y, x, 0];
                        result.Data[y - leftTop.Y, x - leftTop.X, 1] = inputImage.Data[y, x, 1];
                        result.Data[y - leftTop.Y, x - leftTop.X, 2] = inputImage.Data[y, x, 2];
                    }
                }
            }
            return result;
        }

        #endregion

        #region ColorCheck

        public static byte CalculateGrey(int[] color)
        {
            return (byte)(0.3 * color[0] + 0.6 * color[1] + 0.1 * color[2]);
        }

        public static double CalculateDistance3D(int[] color1, int[] color2)
        {
            return Math.Sqrt(Math.Pow(color1[0] - color2[0], 2)
                   + Math.Pow(color1[1] - color2[1], 2)
                   + Math.Pow(color1[2] - color2[2], 2));
        }

        public static Image<Bgr, byte> ColorCheck(Image<Bgr, byte> inputImage, double distance, int[] color)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    int[] color2 = new int[3];
                    color2[0] = inputImage.Data[y, x, 0];
                    color2[1] = inputImage.Data[y, x, 1];
                    color2[2] = inputImage.Data[y, x, 2];
                    if (distance >= CalculateDistance3D(color, color2))
                    {
                        result.Data[y, x, 0] = inputImage.Data[y, x, 0];
                        result.Data[y, x, 1] = inputImage.Data[y, x, 1];
                        result.Data[y, x, 2] = inputImage.Data[y, x, 2];
                    }
                    else
                    {
                        result.Data[y, x, 0] = CalculateGrey(color2);
                        result.Data[y, x, 1] = CalculateGrey(color2);
                        result.Data[y, x, 2] = CalculateGrey(color2);
                    }

                }
            }
            return result;
        }

        public static Image<Bgr, byte> Bin3D(Image<Bgr, byte> inputImage, double distance, int[] color)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    int[] color2 = new int[3];
                    color2[0] = inputImage.Data[y, x, 0];
                    color2[1] = inputImage.Data[y, x, 1];
                    color2[2] = inputImage.Data[y, x, 2];
                    if (distance >= CalculateDistance3D(color, color2))
                    {
                        result.Data[y, x, 0] = 255;
                        result.Data[y, x, 1] = 255;
                        result.Data[y, x, 2] = 255;
                    }
                    else
                    {
                        result.Data[y, x, 0] = 0;
                        result.Data[y, x, 1] = 0;
                        result.Data[y, x, 2] = 0;
                    }

                }
            }
            return result;
        }
        #endregion

        #region Binarizare 2D

        public static double CalculateDistance2D(int[] color1, int[] color2)
        {
            double div1 = color1[0] + color1[1] + color1[2];
            double div2 = color2[0] + color2[1] + color2[2];
            double r1 = div1 == 0 ? 0 : color1[2] / div1;
            double g1 = div1 == 0 ? 0 : color1[1] / div1;
            double r2 = div2 == 0 ? 0 : color2[2] / div2;
            double g2 = div2 == 0 ? 0 : color2[1] / div2;
            double dis =  Math.Sqrt(Math.Pow(r2 - r1, 2) + Math.Pow(g2 - g1, 2));
            return dis;
        }
        public static Image<Bgr, byte> Bin2D(Image<Bgr, byte> inputImage, double distance, int[] color)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    int[] color2 = new int[3];
                    color2[0] = inputImage.Data[y, x, 0];
                    color2[1] = inputImage.Data[y, x, 1];
                    color2[2] = inputImage.Data[y, x, 2];
                    if (distance >= CalculateDistance2D(color, color2))
                    {
                        result.Data[y, x, 0] = 255;
                        result.Data[y, x, 1] = 255;
                        result.Data[y, x, 2] = 255;
                    }
                    else
                    {
                        result.Data[y, x, 0] = 0;
                        result.Data[y, x, 1] = 0;
                        result.Data[y, x, 2] = 0;
                    }

                }
            }
            return result;
        }
        #endregion
    }
}