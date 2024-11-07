using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using MaybeDraw.Commands;
using MaybeDraw.Model;
using System.Collections.ObjectModel;

namespace MaybeDraw.ViewModel
{
    public class DrawViewModel : BaseViewModel
    {
        private DrawModel _model;
        private Brush _currentColor;
        private ICommand _clearCommand;
        private ICommand _startDrawingCommand;
        private ICommand _mouseMoveCommand;

        public DrawViewModel()
        {
            _model = new DrawModel();
            _currentColor = Brushes.Black;

            _clearCommand = new RelayCommand(ClearCanvas);
            _startDrawingCommand = new RelayCommand(StartDrawing);
            _mouseMoveCommand = new RelayCommand(MouseMove);
        }

        public ObservableCollection<Path> Paths => _model.Paths;
        public Brush CurrentColor
        {
            get => _currentColor;
            set => SetProperty(ref _currentColor, value);
        }

        public ICommand ClearCommand => _clearCommand;
        public ICommand StartDrawingCommand => _startDrawingCommand;
        public ICommand MouseMoveCommand => _mouseMoveCommand;

        // 开始绘制
        private void StartDrawing(object parameter)
        {
           _model.CurrentPath.Clear();
        }

        // 处理鼠标移动
        private void MouseMove(object parameter)
        {
            if (parameter is Point point)
            {
                _model.CurrentPath.Add(point);
                _model.AddPath(_model.CurrentPath, _currentColor);
                OnPropertyChanged(nameof(Paths));
            }
        }

        // 清除画布
        private void ClearCanvas(object parameter)
        {
            _model.ClearPaths();
            OnPropertyChanged(nameof(Paths));
        }
    }
}
