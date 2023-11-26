using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System;
using System.Collections.Generic;
using Algorithms.Utilities;

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

        #region AverageFilter
        private static byte ComputeAverage(Image<Gray, byte> image, int y, int x, int maskdim)
        {
            int sum = 0;
            for(int i = y; i < y + maskdim; i++)
            {
                for(int j = x; j < x + maskdim; j++)
                {
                    sum = sum + image.Data[i, j, 0];
                }
            }
            return (byte)(sum / (maskdim * maskdim));
        }
        private static byte[] ComputeAverage(Image<Bgr, byte> image, int y, int x, int maskdim)
        {
            int b = 0;
            int g = 0;
            int r = 0;
            byte[] result = new byte[3]; 
            for (int i = y; i < y + maskdim; i++)
            {
                for (int j = x; j < x + maskdim; j++)
                {
                    b = b + image.Data[i, j, 0];
                    g = g + image.Data[i, j, 1];
                    r = r + image.Data[i, j, 2];
                }
            }
            result[0] = (byte)(b / (maskdim * maskdim));
            result[1] = (byte)(g / (maskdim * maskdim));
            result[2] = (byte)(r / (maskdim * maskdim));
            return result;
        }

        public static Image<Gray, byte> AverageFilter(Image<Gray, byte> inputImage, int maskdim)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            Image<Gray, byte> helper = new Image<Gray, byte>(height:inputImage.Height + maskdim - 1, width:inputImage.Width + maskdim - 1);
            int border = (maskdim - 1) / 2;
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    helper.Data[y + border, x + border, 0] = inputImage.Data[y, x, 0];
                }
            }
            //schimbam culoarea noilor pixeli in culoarea celui mai apropiat pixel
            for (int i = 0; i < border; i++)
            {
                for(int j = 0; j < inputImage.Height; j++)
                {
                    helper.Data[j + border, i, 0] = inputImage.Data[j, 0, 0];
                    helper.Data[j + border, inputImage.Width + border + i, 0] = inputImage.Data[j, inputImage.Width - 1, 0];
                }
                for (int j = 0; j < inputImage.Width; j++)
                {
                    helper.Data[i, j + border, 0] = inputImage.Data[0, j, 0];
                    helper.Data[inputImage.Height + border + i, j + border , 0] = inputImage.Data[inputImage.Height - 1, j, 0];
                }
                for (int j = 0; j < border; j++)
                {
                    helper.Data[i, j, 0] = inputImage.Data[0, 0, 0];
                    helper.Data[inputImage.Height + border + i, j, 0] = inputImage.Data[inputImage.Height - 1, 0, 0];
                    helper.Data[i, inputImage.Width + border + j, 0] = inputImage.Data[0, inputImage.Width - 1, 0];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 0] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 0];
                }
            }

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = ComputeAverage(helper, y, x, maskdim);
                }
            }
            return result;
        }
        public static Image<Bgr, byte> AverageFilter(Image<Bgr, byte> inputImage, int maskdim)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            Image<Bgr, byte> helper = new Image<Bgr, byte>(height: inputImage.Height + maskdim - 1, width: inputImage.Width + maskdim - 1);
            int border = (maskdim - 1) / 2;
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    helper.Data[y + border, x + border, 0] = inputImage.Data[y, x, 0];
                    helper.Data[y + border, x + border, 1] = inputImage.Data[y, x, 1];
                    helper.Data[y + border, x + border, 2] = inputImage.Data[y, x, 2];
                }
            }
            for (int i = 0; i < border; i++)
            {
                for (int j = 0; j < inputImage.Height; j++)
                {
                    helper.Data[j + border, i, 0] = inputImage.Data[j, 0, 0];
                    helper.Data[j + border, i, 1] = inputImage.Data[j, 0, 1];
                    helper.Data[j + border, i, 2] = inputImage.Data[j, 0, 2];
                    helper.Data[j + border, inputImage.Width + border + i, 0] = inputImage.Data[j, inputImage.Width - 1, 0];
                    helper.Data[j + border, inputImage.Width + border + i, 1] = inputImage.Data[j, inputImage.Width - 1, 1];
                    helper.Data[j + border, inputImage.Width + border + i, 2] = inputImage.Data[j, inputImage.Width - 1, 2];
                }
                for (int j = 0; j < inputImage.Width; j++)
                {
                    helper.Data[i, j + border, 0] = inputImage.Data[0, j, 0];
                    helper.Data[i, j + border, 1] = inputImage.Data[0, j, 1];
                    helper.Data[i, j + border, 2] = inputImage.Data[0, j, 2];
                    helper.Data[inputImage.Height + border + i, j + border, 0] = inputImage.Data[inputImage.Height - 1, j, 0];
                    helper.Data[inputImage.Height + border + i, j + border, 1] = inputImage.Data[inputImage.Height - 1, j, 1];
                    helper.Data[inputImage.Height + border + i, j + border, 2] = inputImage.Data[inputImage.Height - 1, j, 2];
                }
                for (int j = 0; j < border; j++)
                {
                    helper.Data[i, j, 0] = inputImage.Data[0, 0, 0];
                    helper.Data[i, j, 1] = inputImage.Data[0, 0, 1];
                    helper.Data[i, j, 2] = inputImage.Data[0, 0, 2];
                    helper.Data[inputImage.Height + border + i, j, 0] = inputImage.Data[inputImage.Height - 1, 0, 0];
                    helper.Data[inputImage.Height + border + i, j, 1] = inputImage.Data[inputImage.Height - 1, 0, 1];
                    helper.Data[inputImage.Height + border + i, j, 2] = inputImage.Data[inputImage.Height - 1, 0, 2];
                    helper.Data[i, inputImage.Width + border + j, 0] = inputImage.Data[0, inputImage.Width - 1, 0];
                    helper.Data[i, inputImage.Width + border + j, 1] = inputImage.Data[0, inputImage.Width - 1, 1];
                    helper.Data[i, inputImage.Width + border + j, 2] = inputImage.Data[0, inputImage.Width - 1, 2];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 0] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 0];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 1] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 1];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 2] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 2];
                }
            }
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    var res = ComputeAverage(helper, y, x, maskdim);
                    result.Data[y, x, 0] = res[0];
                    result.Data[y, x, 1] = res[1];
                    result.Data[y, x, 2] = res[2];
                }
            }
            return result;
        }
        #endregion

        #region emboss

        private static byte ComputeEmboss(Image<Gray, byte> image, int y, int x, int borderdim)
        {
            byte result;
            int sum = 0;
            int maskdim = borderdim * 2 + 1;
            byte[,] mask = new byte[maskdim, maskdim];
            x = x - borderdim;
            y = y - borderdim;
            for(int i = 0; i < maskdim; i++)
            {
                for(int j = 0; j < maskdim; j++)
                {
                    mask[i, j] = image.Data[y + i, x + j, 0];
                }
            }

            for (int i = 0; i < maskdim; i++)
            {
                for (int j = 0; j < maskdim; j++)
                {
                    if(i + j < borderdim * 2)
                    {
                        sum = sum - mask[i, j];
                    }
                    if(i + j > borderdim * 2)
                    {
                        sum = sum + mask[i, j];
                    }
                }
            }

            result = (byte)(sum / maskdim* maskdim);
            result = (byte)(result + 128);
            return result;
        }
        private static byte[] ComputeEmboss(Image<Bgr, byte> image, int y, int x, int borderdim)
        {
            byte[] result = new byte[3];
            int sumb = 0;
            int sumg = 0;
            int sumr = 0;
            int maskdim = borderdim * 2 + 1;
            byte[,,] mask = new byte[maskdim, maskdim,3];
            x = x - borderdim;
            y = y - borderdim;
            for (int i = 0; i < maskdim; i++)
            {
                for (int j = 0; j < maskdim; j++)
                {
                    mask[i, j, 0] = image.Data[y + i, x + j, 0];
                    mask[i, j, 1] = image.Data[y + i, x + j, 1];
                    mask[i, j, 2] = image.Data[y + i, x + j, 2];
                }
            }

            for (int i = 0; i < maskdim; i++)
            {
                for (int j = 0; j < maskdim; j++)
                {
                    if (i + j < borderdim * 2)
                    {
                        sumb = sumb - mask[i, j, 0];
                        sumg = sumg - mask[i, j, 1];
                        sumr = sumr - mask[i, j, 2];
                    }
                    if (i + j > borderdim * 2)
                    {
                        sumb = sumb + mask[i, j, 0];
                        sumg = sumg + mask[i, j, 1];
                        sumr = sumr + mask[i, j, 2];
                    }
                }
            }

            result[0] = (byte)(sumb / maskdim * maskdim);
            result[0] = (byte)(result[0] + 128);
            result[1] = (byte)(sumg / maskdim * maskdim);
            result[1] = (byte)(result[1] + 128);
            result[2] = (byte)(sumr / maskdim * maskdim);
            result[2] = (byte)(result[2] + 128);
            return result;
        }
        public static Image<Gray, byte> Emboss(Image<Gray, byte> inputImage, bool is3)
        {
            int border;
            if (is3 == true)
            {
                border = 1;
            }
            else
            {
                border = 2;
            }

            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            Image<Gray, byte> helper = new Image<Gray, byte>(height: inputImage.Height + 2 * border, width: inputImage.Width + 2 * border);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    helper.Data[y + border, x + border, 0] = inputImage.Data[y, x, 0];
                }
            }
            for (int i = 0; i < border; i++)
            {
                for (int j = 0; j < inputImage.Height; j++)
                {
                    helper.Data[j + border, i, 0] = inputImage.Data[j, 0, 0];
                    helper.Data[j + border, inputImage.Width + border + i, 0] = inputImage.Data[j, inputImage.Width - 1, 0];
                }
                for (int j = 0; j < inputImage.Width; j++)
                {
                    helper.Data[i, j + border, 0] = inputImage.Data[0, j, 0];
                    helper.Data[inputImage.Height + border + i, j + border, 0] = inputImage.Data[inputImage.Height - 1, j, 0];
                }
                for (int j = 0; j < border; j++)
                {
                    helper.Data[i, j, 0] = inputImage.Data[0, 0, 0];
                    helper.Data[inputImage.Height + border + i, j, 0] = inputImage.Data[inputImage.Height - 1, 0, 0];
                    helper.Data[i, inputImage.Width + border + j, 0] = inputImage.Data[0, inputImage.Width - 1, 0];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 0] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 0];
                }
            }
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = ComputeEmboss(helper, y + border, x + border, border);
                }
            }
            return result;
        }
        public static Image<Bgr, byte> Emboss(Image<Bgr, byte> inputImage, bool is3)
        {
            int border;
            if (is3 == true)
            {
                border = 1;
            }
            else
            {
                border = 2;
            }

            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            Image<Bgr, byte> helper = new Image<Bgr, byte>(height: inputImage.Height + 2 * border, width: inputImage.Width + 2 * border);

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    helper.Data[y + border, x + border, 0] = inputImage.Data[y, x, 0];
                    helper.Data[y + border, x + border, 1] = inputImage.Data[y, x, 1];
                    helper.Data[y + border, x + border, 2] = inputImage.Data[y, x, 2];
                }
            }
            for (int i = 0; i < border; i++)
            {
                for (int j = 0; j < inputImage.Height; j++)
                {
                    helper.Data[j + border, i, 0] = inputImage.Data[j, 0, 0];
                    helper.Data[j + border, i, 1] = inputImage.Data[j, 0, 1];
                    helper.Data[j + border, i, 2] = inputImage.Data[j, 0, 2];
                    helper.Data[j + border, inputImage.Width + border + i, 0] = inputImage.Data[j, inputImage.Width - 1, 0];
                    helper.Data[j + border, inputImage.Width + border + i, 1] = inputImage.Data[j, inputImage.Width - 1, 1];
                    helper.Data[j + border, inputImage.Width + border + i, 2] = inputImage.Data[j, inputImage.Width - 1, 2];
                }
                for (int j = 0; j < inputImage.Width; j++)
                {
                    helper.Data[i, j + border, 0] = inputImage.Data[0, j, 0];
                    helper.Data[i, j + border, 1] = inputImage.Data[0, j, 1];
                    helper.Data[i, j + border, 2] = inputImage.Data[0, j, 2];
                    helper.Data[inputImage.Height + border + i, j + border, 0] = inputImage.Data[inputImage.Height - 1, j, 0];
                    helper.Data[inputImage.Height + border + i, j + border, 1] = inputImage.Data[inputImage.Height - 1, j, 1];
                    helper.Data[inputImage.Height + border + i, j + border, 2] = inputImage.Data[inputImage.Height - 1, j, 2];
                }
                for (int j = 0; j < border; j++)
                {
                    helper.Data[i, j, 0] = inputImage.Data[0, 0, 0];
                    helper.Data[i, j, 1] = inputImage.Data[0, 0, 1];
                    helper.Data[i, j, 2] = inputImage.Data[0, 0, 2];
                    helper.Data[inputImage.Height + border + i, j, 0] = inputImage.Data[inputImage.Height - 1, 0, 0];
                    helper.Data[inputImage.Height + border + i, j, 1] = inputImage.Data[inputImage.Height - 1, 0, 1];
                    helper.Data[inputImage.Height + border + i, j, 2] = inputImage.Data[inputImage.Height - 1, 0, 2];
                    helper.Data[i, inputImage.Width + border + j, 0] = inputImage.Data[0, inputImage.Width - 1, 0];
                    helper.Data[i, inputImage.Width + border + j, 1] = inputImage.Data[0, inputImage.Width - 1, 1];
                    helper.Data[i, inputImage.Width + border + j, 2] = inputImage.Data[0, inputImage.Width - 1, 2];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 0] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 0];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 1] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 1];
                    helper.Data[inputImage.Height + border + i, inputImage.Width + border + j, 2] = inputImage.Data[inputImage.Height - 1, inputImage.Width - 1, 2];
                }
            }
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    var res = ComputeEmboss(helper, y+ border, x + border, border);
                    result.Data[y, x, 0] = res[0];
                    result.Data[y, x, 1] = res[1];
                    result.Data[y, x, 2] = res[2];
                }
            }
            return result;
        }
        #endregion

        #region conex
        public static Image<Bgr, byte> Conex(Image<Gray, byte> inputImage)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            var components = new List<Component>();
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = 255;
                    result.Data[y, x, 1] = 255;
                    result.Data[y, x, 2] = 255;
                    if (inputImage.Data[y, x, 0] == 0)
                    {
                        var start_point = new Point(x, y);
                        if(!Utils.isPartOfAComponent(start_point, components))
                        {
                            Random rnd = new Random();
                            var component = new Component((byte)rnd.Next(), (byte)rnd.Next(), (byte)rnd.Next());
                            var queue = new Queue<Point>();
                            queue.Enqueue(start_point);
                            while(queue.Count != 0)
                            {
                                var current = queue.Dequeue();
                                var neighbors = Utils.GetNeighbors(current, inputImage.Width - 1, inputImage.Height - 1);
                                foreach(var neighbor in neighbors)
                                {
                                    if (inputImage.Data[neighbor.Y, neighbor.X, 0] == 0 && !component.Contains(neighbor))
                                    {
                                        component.AddPoint(neighbor);
                                        queue.Enqueue(neighbor);
                                    }
                                }
                            }
                            components.Add(component);
                        }
                    }
                }
            }
            
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    var found_point = new Point(x, y);
                    if (inputImage.Data[y, x, 0] == 0)
                    {
                        foreach(var component in components)
                        {
                            if (component.Contains(found_point))
                            {
                                result.Data[y, x, 0] = component.Color[0];
                                result.Data[y, x, 1] = component.Color[1];
                                result.Data[y, x, 2] = component.Color[2];
                            }
                        }
                    }
                }
            }

            var largestComponent = new Component(0, 0, 0);
            var max = 0;

            foreach (var component in components)
            {
               if(component.Size() > max)
                {
                    max = component.Size();
                    largestComponent = component;
                }
            }

            var lu = largestComponent.LeftUp();
            var rd = largestComponent.RightDown();
            for(int i = lu.X; i <= rd.X; i++)
            {
                result.Data[lu.Y, i, 0] = 0;
                result.Data[lu.Y, i, 1] = 0;
                result.Data[lu.Y, i, 2] = 0;
                result.Data[rd.Y, i, 0] = 0;
                result.Data[rd.Y, i, 1] = 0;
                result.Data[rd.Y, i, 2] = 0;
            }

            for(int i = lu.Y; i <= rd.Y; i++)
            {
                result.Data[i, lu.X, 0] = 0;
                result.Data[i, lu.X, 1] = 0;
                result.Data[i, lu.X, 2] = 0;
                result.Data[i, rd.X, 0] = 0;
                result.Data[i, rd.X, 1] = 0;
                result.Data[i, rd.X, 2] = 0;
            }

            return result;
        }
        #endregion
    }
}