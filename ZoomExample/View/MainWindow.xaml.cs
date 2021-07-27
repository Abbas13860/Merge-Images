using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ZoomExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Point? lastCenterPositionOnTarget;
        //Point? lastMousePositionOnTarget;
        //Point? lastDragPoint;


        //public bool drag = true;
        //public Point StartPt = new Point();
        //public double newX, newY;

        //public double rectanglewidth;
        //public double rectangleheight;
        
        public MainWindow()
        {
            

            InitializeComponent();
            //scrollViewer.MouseLeftButtonUp += OnMouseLeftButtonUp;
            //scrollViewer.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
            //scrollViewer.PreviewMouseWheel += OnPreviewMouseWheel;

            //scrollViewer.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            //scrollViewer.MouseMove += OnMouseMove;

            //slider.ValueChanged += OnSliderValueChanged;
           


        }

       



        //void OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (lastDragPoint.HasValue)
        //    {
        //        Point posNow = e.GetPosition(scrollViewer);

        //        double dX = posNow.X - lastDragPoint.Value.X;
        //        double dY = posNow.Y - lastDragPoint.Value.Y;

        //        lastDragPoint = posNow;

        //        scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
        //        scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);


        //        double rwidth = scrollViewer.HorizontalOffset;
        //        double rheight = scrollViewer.VerticalOffset;
        //        if (rwidth < 0)
        //            rwidth = 0;
        //        else if (rwidth + MovableShape.ActualWidth > CanvasImplant.ActualWidth)
        //            rwidth = CanvasImplant.ActualWidth - MovableShape.ActualWidth;

        //        if (rheight < 0)
        //            rheight = 0;
        //        else if (rheight + MovableShape.ActualHeight > CanvasImplant.ActualHeight)

        //            Canvas.SetLeft(MovableShape, rwidth);
        //            Canvas.SetTop(MovableShape, rheight);



        //    }
        //}

        //void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    var mousePos = e.GetPosition(scrollViewer);
        //    if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y < scrollViewer.ViewportHeight)
        //    {
        //        scrollViewer.Cursor = Cursors.SizeAll;
        //        lastDragPoint = mousePos;
        //        Mouse.Capture(scrollViewer);

        //    }
        //}
        //void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    scaleTransform.ScaleX = e.NewValue;
        //    scaleTransform.ScaleY = e.NewValue;

        //    var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
        //    lastCenterPositionOnTarget = scrollViewer.TranslatePoint(centerOfViewport, grid);




        //}

        //void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    double rectanglewidth = 263.3;
        //    double rectangleheight = 165;
        //    lastMousePositionOnTarget = Mouse.GetPosition(grid);
        //    System.Console.WriteLine(e.Delta);
        //    if (e.Delta > 0)
        //    {
        //        slider.Value +=1;

        //        rectanglewidth /= scaleTransform.ScaleX;
        //        rectangleheight /=scaleTransform.ScaleY;
        //    }
        //    if (e.Delta < 0)
        //    {
        //        if (MovableShape.Width < 225 && MovableShape.Height < 225)
        //        {
        //            rectanglewidth /= scaleTransform.ScaleX;
        //            rectangleheight /= scaleTransform.ScaleY;
        //        }
        //        slider.Value -= 1;

        //    }

        //    e.Handled = true;

        //    MovableShape.Width = rectanglewidth;
        //    MovableShape.Height= rectangleheight;

        //}

        //void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    scrollViewer.Cursor = Cursors.Arrow;
        //    scrollViewer.ReleaseMouseCapture();
        //    lastDragPoint = null;
        //}





        //private void CanvasImplant_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    drag = false;
        //    Cursor = Cursors.Arrow;
        //    Mouse.Capture(null);
        //}

        //private void CanvasImplant_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (drag)
        //    {
        //        var mp = e.GetPosition(CanvasImplant);
        //        double deltaX = mp.X - StartPt.X;
        //        double deltaY = mp.Y - StartPt.Y;

        //        var newX = deltaX + Canvas.GetLeft(MovableShape);
        //        var newY = deltaY + Canvas.GetTop(MovableShape);

        //        if (newX < 0)
        //            newX = 0;
        //        else if (newX + MovableShape.ActualWidth > CanvasImplant.ActualWidth)
        //            newX = CanvasImplant.ActualWidth - MovableShape.ActualWidth;

        //        if (newY < 0)
        //            newY = 0;
        //        else if (newY + MovableShape.ActualHeight > CanvasImplant.ActualHeight)
        //            newY = CanvasImplant.ActualHeight - MovableShape.ActualHeight;

        //        Canvas.SetLeft(MovableShape, newX);
        //        Canvas.SetTop(MovableShape, newY);

        //        StartPt = mp;


        //    }
        //}
        //private void MovableShape_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    drag = true;
        //    Cursor = Cursors.Hand;
        //    StartPt = e.GetPosition(CanvasImplant);
        //    Mouse.Capture(CanvasImplant);


        //}


    }
}