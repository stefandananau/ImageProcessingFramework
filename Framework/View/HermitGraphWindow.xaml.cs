using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Framework.Utilities.DrawingHelper;

namespace Framework.View
{
    /// <summary>
    /// Interaction logic for HermitGraphWindow.xaml
    /// </summary>
    public partial class HermitGraphWindow : Window
    {

        private readonly HermitGraphVM _graphVM;
        public HermitGraphWindow()
        {
            InitializeComponent();
            _graphVM = new HermitGraphVM();
            _graphVM.points = new List<Point>();
            _graphVM.firstPoint = new Point(0, 255);
            _graphVM.lastPoint = new Point(255, 0);
            DataContext = _graphVM;
        }
        private void CMouseMove(object sender, MouseEventArgs e)
        {
                var position = e.GetPosition(canvas);
                SetUiValues((int)position.X, (int)position.Y);
        }
        private void SetUiValues(int x, int y)
        {
            _graphVM.XPos = x >= 0 ? "X: " + x.ToString() : "";
            _graphVM.YPos = y >= 0 ? "Y: " + (255-y).ToString() : "";
        }

        private void CanvasMouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(canvas);
            var point = new Point((int)position.X, (int)position.Y);
            if (_graphVM.points.Count == 5 || (_graphVM.points.Count != 0 && _graphVM.points.Last().X >= point.X))
            {
                return;
            }
            _graphVM.points.Add(point);
            DrawEllipse(canvas, point, 5, 5, 2, Brushes.Red, 1);
        }

    }
}
