using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MaybeDraw.Model
{
    public class DrawModel
    {
        //线条
        public ObservableCollection<Path> Paths { get; set; } = new ObservableCollection<Path>();
        public List<Point> CurrentPath { get; set; } = new List<Point>();
        public void AddPath(List<Point> points, Brush color)
        {
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure { StartPoint = points[0] };

            for (int i = 1; i < points.Count; i++)
            {
                pathFigure.Segments.Add(new LineSegment(points[i], true));
            }
            pathGeometry.Figures.Add(pathFigure);

            Path path = new Path
            {
                Stroke = color,
                StrokeThickness = 2,
                Data = pathGeometry
            };

            Paths.Add(path);
        }

        public void ClearPaths()
        {
            Paths.Clear();
        }
        public Brush CurrentColor { get; set; } = Brushes.Black; // 保存当前颜色
    }
}
