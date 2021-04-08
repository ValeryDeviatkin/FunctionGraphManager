using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using ViewModels.Graph;

namespace FunctionGraphManager.Behaviors
{
    internal class CanvasDragNDropBehavior : Behavior<FrameworkElement>
    {
        private bool _isDragDropping;
        private Point _prevPosition;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
            AssociatedObject.Loaded += AssociatedObjectOnLoaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            _isDragDropping = false;

            AssociatedObject.Loaded -= AssociatedObjectOnLoaded;
            AssociatedObject.MouseLeftButtonDown -= AssociatedObjectOnMouseLeftButtonDown;
            Canvas.MouseLeave -= CanvasOnMouseLeave;
            Canvas.MouseLeftButtonUp -= CanvasOnMouseLeftButtonUp;
        }

        private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs e)
        {
            Canvas.MouseLeave += CanvasOnMouseLeave;
            Canvas.MouseLeftButtonUp += CanvasOnMouseLeftButtonUp;
        }

        private void CanvasOnMouseLeave(object sender, MouseEventArgs e)
        {
            _isDragDropping = false;
        }

        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragDropping = true;
            _prevPosition = Mouse.GetPosition(Canvas);
        }

        private void CanvasOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragDropping)
            {
                var position = Mouse.GetPosition(Canvas);

                Point.X += position.X - _prevPosition.X;
                Point.Y += position.Y - _prevPosition.Y;
            }

            _isDragDropping = false;
        }

        #region Point dependency: GraphPointViewModel

        public static readonly DependencyProperty PointProperty =
            DependencyProperty.Register(
                nameof(Point),
                typeof(GraphPointViewModel),
                typeof(CanvasDragNDropBehavior),
                new PropertyMetadata(default(GraphPointViewModel)));

        public GraphPointViewModel Point
        {
            get => (GraphPointViewModel) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }

        #endregion

        #region Canvas dependency: Canvas

        public static readonly DependencyProperty CanvasProperty =
            DependencyProperty.Register(
                nameof(Canvas),
                typeof(Canvas),
                typeof(CanvasDragNDropBehavior),
                new PropertyMetadata(default(Canvas)));

        public Canvas Canvas
        {
            get => (Canvas) GetValue(CanvasProperty);
            set => SetValue(CanvasProperty, value);
        }

        #endregion
    }
}