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
            src.UriSource = new Uri(@"E:\ZoomExample\ZoomExample\Images\q_imgfa_ir__5ff8805d722ea_1 (1).jpg", UriKind.Relative);
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
        private double _RecUp;
        public double RecUp
        {
            get { return _RecUp; }
            set
            {
                _RecUp = value;
                OnPropertyChanged();

            }
        }
        private double _GWidth;
        public double GWidth
        {
            get { return _GWidth; }
            set
            {
                _GWidth = value;
                OnPropertyChanged();

            }
        }
        private double _GHeight;
        public double GHeight
        {
            get { return _GHeight; }
            set
            {
                _GHeight = value;
                OnPropertyChanged();

            }
        }
        private double _Sscale;
        public double Sscale
        {
            get { return _Sscale; }
            set
            {
                _Sscale = value;
                OnPropertyChanged();

            }
        }
        private double _SValue = 1;
        public double SValue
        {
            get { return _SValue; }
            set
            {
                _SValue = value;
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
        private double _RecScale;
        public double RecScale
        {
            get { return _RecScale; }
            set
            {
                _RecScale = value;
                OnPropertyChanged();

            }
        }
        private double _Iwidth1;
        public double Iwidth1
        {
            get { return _Iwidth1; }
            set
            {
                _Iwidth1 = value;
                OnPropertyChanged();

            }
        }
        private double _Iheight1;
        public double Iheight1
        {
            get { return _Iheight1; }
            set
            {
                _Iheight1 = value;
                OnPropertyChanged();

            }
        }
        private double _Iwidth2;
        public double Iwidth2
        {
            get { return _Iwidth2; }
            set
            {
                _Iwidth2 = value;
                OnPropertyChanged();

            }
        }
        private double _Iheight2;
        public double Iheight2
        {
            get { return _Iheight2; }
            set
            {
                _Iheight2 = value;
                OnPropertyChanged();

            }
        }
        private double _Iwidth3;
        public double Iwidth3
        {
            get { return _Iwidth3; }
            set
            {
                _Iwidth3 = value;
                OnPropertyChanged();

            }
        }
        private double _Iheight3;
        public double Iheight3
        {
            get { return _Iheight3; }
            set
            {
                _Iheight3 = value;
                OnPropertyChanged();

            }
        }
        private double _Ctop1;
        public double Ctop1
        {
            get { return _Ctop1; }
            set
            {
                _Ctop1 = value;
                OnPropertyChanged();

            }
        }
        private double _Cleft1;
        public double Cleft1
        {
            get { return _Cleft1; }
            set
            {
                _Cleft1 = value;
                OnPropertyChanged();

            }
        }
        private double _Ctop2;
        public double Ctop2
        {
            get { return _Ctop2; }
            set
            {
                _Ctop2 = value;
                OnPropertyChanged();

            }
        }
        private double _Cleft2;
        public double Cleft2
        {
            get { return _Cleft2; }
            set
            {
                _Cleft2 = value;
                OnPropertyChanged();

            }
        }
        private double _Ctop3;
        public double Ctop3
        {
            get { return _Ctop3; }
            set
            {
                _Ctop3 = value;
                OnPropertyChanged();

            }
        }
        private double _Cleft3;
        public double Cleft3
        {
            get { return _Cleft3; }
            set
            {
                _Cleft3 = value;
                OnPropertyChanged();

            }
        }
        private double _imageleft1;
        public double imageleft1
        {
            get { return _imageleft1; }
            set
            {
                _imageleft1 = value;
                OnPropertyChanged();

            }
        }
        private double _imagetop1;
        public double imagetop1
        {
            get { return _imagetop1; }
            set
            {
                _imagetop1 = value;
                OnPropertyChanged();

            }
        }
        private double _imageleft2;
        public double imageleft2
        {
            get { return _imageleft2; }
            set
            {
                _imageleft2 = value;
                OnPropertyChanged();

            }
        }
        private double _imagetop2;
        public double imagetop2
        {
            get { return _imagetop2; }
            set
            {
                _imagetop2 = value;
                OnPropertyChanged();

            }
        }
        private double _imageleft3;
        public double imageleft3
        {
            get { return _imageleft3; }
            set
            {
                _imageleft3 = value;
                OnPropertyChanged();

            }
        }
        private double _imagetop3;
        public double imagetop3
        {
            get { return _imagetop3; }
            set
            {
                _imagetop3 = value;
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
                double TMPL= RectangleLeft + Point2.X - Point1.X; 
                double TMPU=RecUp+ Point2.Y - Point1.Y;

                if (TMPL > 0 && TMPU > 0 && TMPL <= SmallCanvasWidth - RectangleWidth && TMPU <= SmallCanvasHeight - RectangleHeight)
                {
                    RectangleLeft = TMPL;
                    RecUp = TMPU;
                }

                if (RectangleLeft > 0 || RecUp > 0)
                {
                    Copyscrollviewer.ScrollToHorizontalOffset((RectangleLeft * Copyscrollviewer.ScrollableWidth) / (SmallCanvasWidth - RectangleWidth));
                    Copyscrollviewer.ScrollToVerticalOffset((RecUp * Copyscrollviewer.ScrollableHeight) / (SmallCanvasHeight - RectangleHeight));
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

               
                if (SValue < 5)
                {


                    SValue += 1;
                    Sscale *= 2;

                    ScrollViewerNewExtentWidth = GWidth * Sscale;
                    ScrollViewerNewExtentHeight = GHeight * Sscale;

                    RecScale = ScrollViewerNewExtentWidth / SmallCanvasWidth;
                    if (SmallCanvasHeight * RecScale > ScrollViewerNewExtentHeight)
                    {
                        RecScale = ScrollViewerNewExtentHeight / SmallCanvasHeight;
                    }

                    

                    rectanglewidthtemp = scrollViewer.ViewportWidth /RecScale;
                    rectangleheighttemp = scrollViewer.ViewportHeight / RecScale;
                    RectangleWidth = rectanglewidthtemp;
                    RectangleHeight = rectangleheighttemp;


                }

            }
            if (e.Delta < 0)
            {

                if (scrollViewer.ScrollableWidth!=0||scrollViewer.ScrollableHeight!=0)
                {
                    Sscale /= 2;

                    ScrollViewerNewExtentWidth = GWidth * Sscale;
                    ScrollViewerNewExtentHeight = GHeight * Sscale;

                    RecScale = ScrollViewerNewExtentWidth / SmallCanvasWidth;
                    if (SmallCanvasHeight * RecScale > ScrollViewerNewExtentHeight)
                    {
                        RecScale = ScrollViewerNewExtentHeight / SmallCanvasHeight;
                    }

                    rectanglewidthtemp = scrollViewer.ViewportWidth / RecScale;
                    rectangleheighttemp = scrollViewer.ViewportHeight / RecScale;
                    SValue -= 1;
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

            RecUp = ((SmallCanvasHeight - RectangleHeight) * scrollViewer.VerticalOffset) / scrollViewer.ScrollableHeight;
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
                ScrollViewerNewExtentWidth = image.Width * Sscale;
                ScrollViewerNewExtentHeight = image.Height * Sscale;

               

                rectanglewidthtemp = scrollviewerViewportWidth / RecScale;
                rectangleheighttemp = scrollviewerViewportHeight / RecScale;
                RectangleWidth = rectanglewidthtemp;
                RectangleHeight = rectangleheighttemp;

               GWidth = scrollViewer.ViewportWidth;
               GHeight = scrollViewer.ViewportHeight;

               CanvasRatio = GHeight / SmallCanvasHeight;

                SmallCanvasWidth = GWidth / nextCanvasRatio;
                SmallCanvasHeight = GHeight / nextCanvasRatio;
            }

            RecUp = ((SmallCanvasHeight - RectangleHeight) * scrollViewer.VerticalOffset) / scrollViewer.ScrollableHeight;
            RectangleLeft = ((SmallCanvasWidth - RectangleWidth) * scrollViewer.HorizontalOffset) / scrollViewer.ScrollableWidth;

            GWidth = scrollViewer.ViewportWidth;
            GHeight = scrollViewer.ViewportHeight;

            
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
                double TMPL = imageleft1 + Point2.X - Point1.X;
                double TMPU = imagetop1 + Point2.Y - Point1.Y;

                imageleft1 = TMPL;
                imagetop1 = TMPU;
            }
            if (image2drag)
            {

                var PR = e.GetPosition(image2);

                Point2 = PR;
                double TMPL = imageleft2 + Point2.X - Point1.X;
                double TMPU = imagetop2 + Point2.Y - Point1.Y;

                imageleft2 = TMPL;
                imagetop2 = TMPU;
            }
            if (image3drag)
            {

                var PR = e.GetPosition(image3);

                Point2 = PR;
                double TMPL = imageleft3 + Point2.X - Point1.X;
                double TMPU = imagetop3 + Point2.Y - Point1.Y;

                imageleft3 = TMPL;
                imagetop3 = TMPU;
            }
           

            Ctop1 = Canvas.GetTop(image1) / CanvasRatio;
            Cleft1 = Canvas.GetLeft(image1) / CanvasRatio;
            Ctop2 = Canvas.GetTop(image2) / CanvasRatio;
            Cleft2 = Canvas.GetLeft(image2) / CanvasRatio;
            Ctop3 = Canvas.GetTop(image3) / CanvasRatio;
            Cleft3 = Canvas.GetLeft(image3) / CanvasRatio;


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

            GWidth = scrollViewer.ViewportWidth;
            GHeight = scrollViewer.ViewportHeight;


            SmallCanvasWidth =300;
            SmallCanvasHeight = 200;
            RectangleWidth = SmallCanvasWidth;
            RectangleHeight = SmallCanvasHeight;

            Sscale = 1;

            CanvasRatio = GHeight / SmallCanvasHeight;
            nextCanvasRatio = CanvasRatio;

            rectanglewidthtemp = SmallCanvasWidth;
            rectangleheighttemp = SmallCanvasHeight;



            Iwidth1 = image1.ActualWidth / CanvasRatio;
            Iheight1 = image1.ActualHeight / CanvasRatio;
            Iwidth2 = image2.ActualWidth / CanvasRatio;
            Iheight2 = image2.ActualHeight / CanvasRatio;
            Iwidth3 = image3.ActualWidth / CanvasRatio;
            Iheight3 = image3.ActualHeight / CanvasRatio;

           
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
