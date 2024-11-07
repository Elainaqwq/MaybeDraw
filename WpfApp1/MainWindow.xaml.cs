using System.Windows;
using MaybeDraw.ViewModel;

namespace MaybeDraw
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DrawViewModel();
        }

        // 鼠标左键按下，开始绘制
        private void DrawingCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var viewModel = DataContext as DrawViewModel;
            if (viewModel != null)
            {
                viewModel.StartDrawingCommand.Execute(e.GetPosition(DrawingCanvas));
            }
        }

        // 鼠标移动，绘制路径
        private void DrawingCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var viewModel = DataContext as DrawViewModel;
            if (viewModel != null && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                viewModel.MouseMoveCommand.Execute(e.GetPosition(DrawingCanvas));
            }
        }

        // 鼠标左键抬起，结束绘制
        private void DrawingCanvas_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var viewModel = DataContext as DrawViewModel;
            if (viewModel != null)
            {
                viewModel.StartDrawingCommand.Execute(null);
            }
        }
    }
}
