using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows;

namespace Framework.ViewModel
{
    class HermitGraphVM:BaseVM
    {
        private string _xPos;
        public string XPos
        {
            get => _xPos;
            set
            {
                _xPos = value;
                NotifyPropertyChanged(nameof(XPos));
            }
        }

        private string _yPos;
        public string YPos
        {
            get => _yPos;
            set
            {
                _yPos = value;
                NotifyPropertyChanged(nameof(YPos));
            }
        }

        public List<Point> points { get; set; }
        public Point firstPoint { get; set; }
        public Point lastPoint { get; set; }
    }
}
