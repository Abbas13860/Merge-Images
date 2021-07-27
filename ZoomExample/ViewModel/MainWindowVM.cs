using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZoomExample.Common;


namespace ZoomExample
{
    public class MainWindowVM : NotifyPropertyChanged
    {
        #region variable
        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;

        public bool drag = false;
        public double newX, newY;

        public double rectanglewidthtemp;
        public double rectangleheighttemp;

        public Point Point1;
        public Point Point2;

        public ScrollViewer Copyscrollviewer;

        public double ScrollViewerNewExtentWidth;
        public double ScrollViewerNewExtentHeight;

        public double scrollviewerViewportWidth;
        public double scrollviewerViewportHeight;

        bool MainWindowSizeChanged = false;

        public double CanvasRatio;
        public double nextCanvasRatio;

        public bool image1drag = false;
        public bool image2drag = false;
        public bool image3drag = false;
        #endregion
        public MainWindowVM()
        {
            #region Binde
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(@"E:\ZoomExample\ZoomExample\Images\Captions-about-nature-10.jpg", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();

            _image = src;
            #endregion
        }
        #region Methods
        private double _RectangleWidth ;
        public double RectangleWidth
        {
            get { return _RectangleWidth; }
            set
            {
                _RectangleWidth = value;
                OnPropertyChanged();

            }
        }
        private double _RectangleHeight;
        public double RectangleHeight
        {
            get { return _RectangleHeight; }
            set
            {
                _RectangleHeight = value;
                OnPropertyChanged();

            }
        }
        private double _SmallCanvasWidth ;
        public double SmallCanvasWidth
        {
            get { return _SmallCanvasWidth; }
            set
            {
                _SmallCanvasWidth = value;
                OnPropertyChanged();

            }
        }
        private double _SmallCanvasHeight ;
        public double SmallCanvasHeight
        {
            get { return _SmallCanvasHeight; }
            set
            {
                _SmallCanvasHeight = value;
                OnPropertyChanged();

            }
        }
        private double _RectangleLeft;
        public double RectangleLeft
        {
            get { return _RectangleLeft; }
            set
            {
                _RectangleLeft = value;
                OnPropertyChanged();

            }
        }
        private double _RectangleTop;
        public double RectangleTop
        {
            get { return _RectangleTop; }
            set
            {
                _RectangleTop = value;
                OnPropertyChanged();

            }
        }
        private double _BigCanvasWidth;
        public double BigCanvasWidth
        {
            get { return _BigCanvasWidth; }
            set
            {
                _BigCanvasWidth = value;
                OnPropertyChanged();

            }
        }
        private double _BigCanvasHeight;
        public double BigCanvasHeight
        {
            get { return _BigCanvasHeight; }
            set
            {
                _BigCanvasHeight = value;
                OnPropertyChanged();

            }
        }
        private double _ScrollViewerScale;
        public double ScrollViewerScale
        {
            get { return _ScrollViewerScale; }
            set
            {
                _ScrollViewerScale = value;
                OnPropertyChanged();

            }
        }
        private double _ScaleValue = 1;
        public double ScaleValue
        {
            get { return _ScaleValue; }
            set
            {
                _ScaleValue = value;
                OnPropertyChanged();

            }
        }
        private ImageSource _image;

        public ImageSource
            image
        {
            get
            {
                return _image;
            }

        }
        private Point _centerOfViewport;
        public Point centerOfViewport
        {
            get { return _centerOfViewport; }
            set
            {
                _centerOfViewport = value;
                OnPropertyChanged();

            }
        }
        private double _RectangleScale;
        public double RectangleScale
        {
            get { return _RectangleScale; }
            set
            {
                _RectangleScale = value;
                OnPropertyChanged();

            }
        }
        private double _ImageWidth1;
        public double ImageWidth1
        {
            get { return _ImageWidth1; }
            set
            {
                _ImageWidth1 = value;
                OnPropertyChanged();

            }
        }
        private double _ImageHeight1;
        public double ImageHeight1
        {
            get { return _ImageHeight1; }
            set
            {
                _ImageHeight1 = value;
                OnPropertyChanged();

            }
        }
        private double _ImageWidth2;
        public double ImageWidth2
        {
            get { return _ImageWidth2; }
            set
            {
                _ImageWidth2 = value;
                OnPropertyChanged();

            }
        }
        private double _ImageHeight2;
        public double ImageHeight2
        {
            get { return _ImageHeight2; }
            set
            {
                _ImageHeight2 = value;
                OnPropertyChanged();

            }
        }
        private double _ImageWidth3;
        public double ImageWidth3
        {
            get { return _ImageWidth3; }
            set
            {
                _ImageWidth3 = value;
                OnPropertyChanged();

            }
        }
        private double _ImageHeight3;
        public double ImageHeight3
        {
            get { return _ImageHeight3; }
            set
            {
                _ImageHeight3 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasTopSmallImage1;
        public double CanvasTopSmallImage1
        {
            get { return _CanvasTopSmallImage1; }
            set
            {
                _CanvasTopSmallImage1 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasLeftSmallImage1;
        public double CanvasLeftSmallImage1
        {
            get { return _CanvasLeftSmallImage1; }
            set
            {
                _CanvasLeftSmallImage1 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasTopSmallImage2;
        public double CanvasTopSmallImage2
        {
            get { return _CanvasTopSmallImage2; }
            set
            {
                _CanvasTopSmallImage2 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasLeftSmallImage2;
        public double CanvasLeftSmallImage2
        {
            get { return _CanvasLeftSmallImage2; }
            set
            {
                _CanvasLeftSmallImage2 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasTopSmallImage3;
        public double CanvasTopSmallImage3
        {
            get { return _CanvasTopSmallImage3; }
            set
            {
                _CanvasTopSmallImage3 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasLeftSmallImage3;
        public double CanvasLeftSmallImage3
        {
            get { return _CanvasLeftSmallImage3; }
            set
            {
                _CanvasLeftSmallImage3 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasLeftBigImage1;
        public double CanvasLeftBigImage1
        {
            get { return _CanvasLeftBigImage1; }
            set
            {
                _CanvasLeftBigImage1 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasTopBigImage1;
        public double CanvasTopBigImage1
        {
            get { return _CanvasTopBigImage1; }
            set
            {
                _CanvasTopBigImage1 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasLeftBigImage2;
        public double CanvasLeftBigImage2
        {
            get { return _CanvasLeftBigImage2; }
            set
            {
                _CanvasLeftBigImage2 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasTopBigImage2;
        public double CanvasTopBigImage2
        {
            get { return _CanvasTopBigImage2; }
            set
            {
                _CanvasTopBigImage2 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasLeftBigImage3;
        public double CanvasLeftBigImage3
        {
            get { return _CanvasLeftBigImage3; }
            set
            {
                _CanvasLeftBigImage3 = value;
                OnPropertyChanged();

            }
        }
        private double _CanvasTopBigImage3;
        public double CanvasTopBigImage3
        {
            get { return _CanvasTopBigImage3; }
            set
            {
                _CanvasTopBigImage3 = value;
                OnPropertyChanged();

            }
        }
        #endregion
        #region Events

        #region MovableShape_MouseDown
        public void MovableShape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            var Rectangle = sender as IInputElement;

            

            var PR = e.GetPosition(Rectangle);

            Mouse.OverrideCursor = Cursors.Hand;
            Mouse.Capture(Rectangle);
            drag = true;

            Point1 = PR;
      
        }
        #endregion
        #region CanvasImplant_MouseMove
        public void CanvasImplant_MouseMove(object sender, MouseEventArgs e)
        {
           
            var CanvasImplant = sender as Canvas;
            var Rectangle = CanvasImplant.Children[3] as UIElement;
            double a = CanvasImplant.ActualHeight;
            if (drag)
            {

                var PR = e.GetPosition(Rectangle);

                Point2 = PR;
                double TMPLeft= RectangleLeft + Point2.X - Point1.X; 
                double TMPTop = RectangleTop + Point2.Y - Point1.Y;

                if (TMPLeft > 0 && TMPTop > 0 && TMPLeft <= SmallCanvasWidth - RectangleWidth && TMPTop <= SmallCanvasHeight - RectangleHeight)
                {
                    RectangleLeft = TMPLeft;
                    RectangleTop = TMPTop;
                }

                if (RectangleLeft > 0 || RectangleTop > 0)
                {
                    Copyscrollviewer.ScrollToHorizontalOffset((RectangleLeft * Copyscrollviewer.ScrollableWidth) / (SmallCanvasWidth - RectangleWidth));
                    Copyscrollviewer.ScrollToVerticalOffset((RectangleTop * Copyscrollviewer.ScrollableHeight) / (SmallCanvasHeight - RectangleHeight));
                }
            }

        }





        #endregion
        #region CanvasImplant_MouseUp
        public void CanvasImplant_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var CanvasImplant = sender as Canvas;

            drag = false;
            Mouse.OverrideCursor= Cursors.Arrow;
            Mouse.Capture(null);
            
        }

        #endregion
        #region OnMouseLeftButtonUp
        public void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            Mouse.OverrideCursor = Cursors.Arrow;
            scrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }
        #endregion
        #region OnPreviewMouseWheel
        public void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

            var scrollViewer = sender as ScrollViewer;
            var grid = scrollViewer.Content as Canvas;

            lastMousePositionOnTarget = Mouse.GetPosition(grid);
            if (e.Delta > 0)
            {

               
                if (ScaleValue < 5)
                {


                    ScaleValue += 1;
                    ScrollViewerScale *= 2;

                    ScrollViewerNewExtentWidth = BigCanvasWidth * ScrollViewerScale;
                    ScrollViewerNewExtentHeight = BigCanvasHeight * ScrollViewerScale;

                    RectangleScale = ScrollViewerNewExtentWidth / SmallCanvasWidth;
                    if (SmallCanvasHeight * RectangleScale > ScrollViewerNewExtentHeight)
                    {
                        RectangleScale = ScrollViewerNewExtentHeight / SmallCanvasHeight;
                    }

                    

                    rectanglewidthtemp = scrollViewer.ViewportWidth / RectangleScale;
                    rectangleheighttemp = scrollViewer.ViewportHeight / RectangleScale;
                    RectangleWidth = rectanglewidthtemp;
                    RectangleHeight = rectangleheighttemp;


                }

            }
            if (e.Delta < 0)
            {

                if (scrollViewer.ScrollableWidth!=0||scrollViewer.ScrollableHeight!=0)
                {
                    ScrollViewerScale /= 2;

                    ScrollViewerNewExtentWidth = BigCanvasWidth * ScrollViewerScale;
                    ScrollViewerNewExtentHeight = BigCanvasHeight * ScrollViewerScale;

                    RectangleScale = ScrollViewerNewExtentWidth / SmallCanvasWidth;
                    if (SmallCanvasHeight * RectangleScale > ScrollViewerNewExtentHeight)
                    {
                        RectangleScale = ScrollViewerNewExtentHeight / SmallCanvasHeight;
                    }

                    rectanglewidthtemp = scrollViewer.ViewportWidth / RectangleScale;
                    rectangleheighttemp = scrollViewer.ViewportHeight / RectangleScale;
                    ScaleValue -= 1;
                    RectangleWidth = rectanglewidthtemp;
                    RectangleHeight = rectangleheighttemp;
                }

                

            }

            e.Handled = true;


        }
        #endregion
        #region OnMouseLeftButtonDown
        public void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            var mousePos = e.GetPosition(scrollViewer);
            if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y < scrollViewer.ViewportHeight)
            {
                Mouse.OverrideCursor = Cursors.Cross;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer);

            }
        }
        #endregion
        #region OnMouseMove
        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);


                double rwidth = scrollViewer.HorizontalOffset;
                double rheight = scrollViewer.VerticalOffset;
                if (rwidth < 0)
                    rwidth = 0;
                else if (rwidth + RectangleWidth > SmallCanvasWidth)
                    rwidth = SmallCanvasWidth - RectangleWidth;

                if (rheight < 0)
                    rheight = 0;
                else if (rheight + RectangleHeight > SmallCanvasHeight)
                {
                    rheight = SmallCanvasHeight - RectangleHeight;
                }





            }
        }
        #endregion
        #region OnScrollViewerScrollChanged
        public void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            var grid = scrollViewer.Content as Canvas;
            double rwidth = scrollViewer.HorizontalOffset;
            double rheight = scrollViewer.VerticalOffset;

            RectangleTop = ((SmallCanvasHeight - RectangleHeight) * scrollViewer.VerticalOffset) / scrollViewer.ScrollableHeight;
            RectangleLeft = ((SmallCanvasWidth - RectangleWidth) * scrollViewer.HorizontalOffset) / scrollViewer.ScrollableWidth;


            var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer.TranslatePoint(centerOfViewport, grid);
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer.TranslatePoint(centerOfViewport, grid);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(grid);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / grid.ActualWidth;
                    double multiplicatorY = e.ExtentHeight / grid.ActualHeight;

                    double newOffsetX = scrollViewer.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer.ScrollToVerticalOffset(newOffsetY);
                    scrollViewer.ScrollToHorizontalOffset(newOffsetX);



                }
               
            }

            scrollviewerViewportWidth = scrollViewer.ViewportWidth;
            scrollviewerViewportHeight = scrollViewer.ViewportHeight;

            if (MainWindowSizeChanged == true)
            {
                ScrollViewerNewExtentWidth = image.Width * ScrollViewerScale;
                ScrollViewerNewExtentHeight = image.Height * ScrollViewerScale;

               

                rectanglewidthtemp = scrollviewerViewportWidth / RectangleScale;
                rectangleheighttemp = scrollviewerViewportHeight / RectangleScale;
                RectangleWidth = rectanglewidthtemp;
                RectangleHeight = rectangleheighttemp;

                BigCanvasWidth = scrollViewer.ViewportWidth;
                BigCanvasHeight = scrollViewer.ViewportHeight;

               CanvasRatio = BigCanvasHeight / SmallCanvasHeight;

                SmallCanvasWidth = BigCanvasWidth / nextCanvasRatio;
                SmallCanvasHeight = BigCanvasHeight / nextCanvasRatio;
            }

            RectangleTop = ((SmallCanvasHeight - RectangleHeight) * scrollViewer.VerticalOffset) / scrollViewer.ScrollableHeight;
            RectangleLeft = ((SmallCanvasWidth - RectangleWidth) * scrollViewer.HorizontalOffset) / scrollViewer.ScrollableWidth;

            BigCanvasWidth = scrollViewer.ViewportWidth;
            BigCanvasHeight = scrollViewer.ViewportHeight;

            
        }
        #endregion
        #region OrginalCanvas_MouseMove
        public void OrginalCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var OrginalCanvas = sender as Canvas;
            var image1 = OrginalCanvas.Children[0] as Image;
            var image2 = OrginalCanvas.Children[1] as Image;
            var image3 = OrginalCanvas.Children[2] as Image;
            if (image1drag)
            {

                var PR = e.GetPosition(image1);

                Point2 = PR;
                double TMPLeft = CanvasLeftBigImage1 + Point2.X - Point1.X;
                double TMPTop = CanvasTopBigImage1 + Point2.Y - Point1.Y;

                CanvasLeftBigImage1 = TMPLeft;
                CanvasTopBigImage1 = TMPTop;
            }
            if (image2drag)
            {

                var PR = e.GetPosition(image2);

                Point2 = PR;
                double TMPLeft = CanvasLeftBigImage2 + Point2.X - Point1.X;
                double TMPTop = CanvasTopBigImage2 + Point2.Y - Point1.Y;

                CanvasLeftBigImage2 = TMPLeft;
                CanvasTopBigImage2 = TMPTop;
            }
            if (image3drag)
            {

                var PR = e.GetPosition(image3);

                Point2 = PR;
                double TMPLeft = CanvasLeftBigImage3 + Point2.X - Point1.X;
                double TMPTop = CanvasTopBigImage3 + Point2.Y - Point1.Y;

                CanvasLeftBigImage3 = TMPLeft;
                CanvasTopBigImage3 = TMPTop;
            }


            CanvasTopSmallImage1 = Canvas.GetTop(image1) / CanvasRatio;
            CanvasLeftSmallImage1 = Canvas.GetLeft(image1) / CanvasRatio;
            CanvasTopSmallImage2 = Canvas.GetTop(image2) / CanvasRatio;
            CanvasLeftSmallImage2 = Canvas.GetLeft(image2) / CanvasRatio;
            CanvasTopSmallImage3 = Canvas.GetTop(image3) / CanvasRatio;
            CanvasLeftSmallImage3 = Canvas.GetLeft(image3) / CanvasRatio;


        }
        #endregion
        #region OrginalCanvas_MouseUp
        public void OrginalCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            image1drag = false;
            image2drag = false;
            image3drag = false;
            Mouse.OverrideCursor = Cursors.Arrow;
            Mouse.Capture(null);
        }
        #endregion
        #region image1_MouseDown
        public void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image1 = sender as UIElement;

            var PR = e.GetPosition(image1);

            Mouse.OverrideCursor = Cursors.Hand;
            image1drag = true;

            Point1 = PR;
        }
        #endregion
        #region image2_MouseDown
        public void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image2 = sender as UIElement;

            var PR = e.GetPosition(image2);

            Mouse.OverrideCursor = Cursors.Hand;
            image2drag = true;

            Point1 = PR;
        }
        #endregion
        #region image3_MouseDown
        public void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image2 = sender as UIElement;

            var PR = e.GetPosition(image2);

            Mouse.OverrideCursor = Cursors.Hand;
            image3drag = true;

            Point1 = PR;
        }
        #endregion
        #region WindowsLoaded
        public void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            var window = sender as MainWindow;
            var maingrid = window.Content as Grid;
            var grid1 = maingrid.Children[0] as Grid;
            var smallcanvas = grid1.Children[0] as Canvas;
            var scrollViewer = maingrid.Children[1] as ScrollViewer;
            var bigcanvas = scrollViewer.Content as Canvas;
            var image1 = bigcanvas.Children[0] as Image;
            var image2 = bigcanvas.Children[1] as Image;
            var image3 = bigcanvas.Children[2] as Image;



            Copyscrollviewer = scrollViewer;

            BigCanvasWidth = scrollViewer.ViewportWidth;
            BigCanvasHeight = scrollViewer.ViewportHeight;


            SmallCanvasWidth =300;
            SmallCanvasHeight = 200;
            RectangleWidth = SmallCanvasWidth;
            RectangleHeight = SmallCanvasHeight;

            ScrollViewerScale = 1;

            CanvasRatio = BigCanvasHeight / SmallCanvasHeight;
            nextCanvasRatio = CanvasRatio;

            rectanglewidthtemp = SmallCanvasWidth;
            rectangleheighttemp = SmallCanvasHeight;



            ImageWidth1 = image1.ActualWidth / CanvasRatio;
            ImageHeight1 = image1.ActualHeight / CanvasRatio;
            ImageWidth2 = image2.ActualWidth / CanvasRatio;
            ImageHeight2 = image2.ActualHeight / CanvasRatio;
            ImageWidth3 = image3.ActualWidth / CanvasRatio;
            ImageHeight3 = image3.ActualHeight / CanvasRatio;

           
        }
        #endregion
        #region SizeChanged
        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowSizeChanged = true;

            



        }
        #endregion
        #endregion
    }
}
