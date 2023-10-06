using Emgu.CV;
using Emgu.CV.Structure;

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
    }
}