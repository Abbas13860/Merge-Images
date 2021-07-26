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
        public Point startPt = new Point();
        public double newX, newY;

        public double rectanglewidth;
        public double rectangleheight;

        public Point P1;
        public Point P2;

        public ScrollViewer Pscrollviewer;


        public double Wsmallimage ;
        public double Hsmallimage;

        public double NewExtentW;
        public double NewExtentH;

        public double scrollviewerVW;
        public double scrollviewerVH;

        bool changed = false;
        #endregion
        public MainWindowVM()
        {
            #region Binde
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(@"F:\ZoomExample\ZoomExample\q_imgfa_ir__5ff8805d722ea_1 (1).jpg", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();

            _image = src;
            #endregion

           



        }



        #region Methods
        private double _RecWidth ;
        public double Recwidth
        {
            get { return _RecWidth; }
            set
            {
                _RecWidth = value;
                OnPropertyChanged();

            }
        }
        private double _RecHeight;
        public double RecHeight
        {
            get { return _RecHeight; }
            set
            {
                _RecHeight = value;
                OnPropertyChanged();

            }
        }
        private double _CWidth ;
        public double Cwidth
        {
            get { return _CWidth; }
            set
            {
                _CWidth = value;
                OnPropertyChanged();

            }
        }
        private double _CHeight ;
        public double CHeight
        {
            get { return _CHeight; }
            set
            {
                _CHeight = value;
                OnPropertyChanged();

            }
        }
        private double _RecLeft;
        public double RecLeft
        {
            get { return _RecLeft; }
            set
            {
                _RecLeft = value;
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
        #endregion
        #region Events

        #region MovableShape_MouseDown
        public void MovableShape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Rectangle = sender as UIElement;

            var PR = e.GetPosition(Rectangle);

            Mouse.OverrideCursor = Cursors.Hand;
            drag = true;

            P1 = PR;
      
        }
        #endregion
        #region CanvasImplant_MouseMove
        public void CanvasImplant_MouseMove(object sender, MouseEventArgs e)
        {
           
            var CanvasImplant = sender as Canvas;
            var Rectangle = CanvasImplant.Children[0] as UIElement;
            double a = CanvasImplant.ActualHeight;
            if (drag)
            {

                var PR = e.GetPosition(Rectangle);

                P2 = PR;
                double TMPL=RecLeft+ P2.X - P1.X; 
                double TMPU=RecUp+ P2.Y - P1.Y; 

                if (TMPL>0&&TMPU>0&&TMPL<=Cwidth-Recwidth&&TMPU<=CHeight-RecHeight)
                {
                    RecLeft = TMPL;
                    RecUp = TMPU;
                }

                if (RecLeft > 0 || RecUp > 0)
                {
                    Pscrollviewer.ScrollToHorizontalOffset((RecLeft * Pscrollviewer.ScrollableWidth) / (Wsmallimage - Recwidth));
                    Pscrollviewer.ScrollToVerticalOffset((RecUp * Pscrollviewer.ScrollableHeight) / (Hsmallimage - RecHeight));
                }
            }

        }





        #endregion
        #region CanvasImplant_MouseUp
        public void CanvasImplant_MouseUp(object sender, MouseButtonEventArgs e)
        {
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
            var grid = scrollViewer.Content as Grid;


           



            lastMousePositionOnTarget = Mouse.GetPosition(grid);
            if (e.Delta > 0)
            {

               
                if (SValue < 5)
                {


                    SValue += 1;
                    Sscale *= 2;

                    NewExtentW = image.Width * Sscale;
                    NewExtentH = image.Height * Sscale;

                    RecScale = NewExtentW / Wsmallimage;
                    if (Hsmallimage * RecScale > NewExtentH)
                    {
                        RecScale = NewExtentH / Hsmallimage;
                    }

                    rectanglewidth = scrollViewer.ViewportWidth /RecScale;
                    rectangleheight = scrollViewer.ViewportHeight / RecScale;
                    Recwidth = rectanglewidth;
                    RecHeight = rectangleheight;


                }

            }
            if (e.Delta < 0)
            {

                if (scrollViewer.ScrollableWidth!=0||scrollViewer.ScrollableHeight!=0)
                {
                    Sscale /= 2;

                    NewExtentW = image.Width * Sscale;
                    NewExtentH = image.Height * Sscale;

                    RecScale = NewExtentW / Wsmallimage;
                    if (Hsmallimage * RecScale > NewExtentH)
                    {
                        RecScale = NewExtentH / Hsmallimage;
                    }

                    rectanglewidth = scrollViewer.ViewportWidth / RecScale;
                    rectangleheight = scrollViewer.ViewportHeight / RecScale;
                    SValue -= 1;
                    Recwidth = rectanglewidth;
                    RecHeight = rectangleheight;
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
                else if (rwidth + Recwidth > Cwidth)
                    rwidth = Cwidth - Recwidth;

                if (rheight < 0)
                    rheight = 0;
                else if (rheight + RecHeight > CHeight)
                {
                    rheight = CHeight - RecHeight;
                }





            }
        }
        #endregion
        #region OnScrollViewerScrollChanged
        public void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            var grid = scrollViewer.Content as Grid;
            double rwidth = scrollViewer.HorizontalOffset;
            double rheight = scrollViewer.VerticalOffset;

            RecUp = ((Hsmallimage - RecHeight) * scrollViewer.VerticalOffset) / scrollViewer.ScrollableHeight;
            RecLeft = ((Wsmallimage - Recwidth) * scrollViewer.HorizontalOffset) / scrollViewer.ScrollableWidth;


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

            scrollviewerVW = scrollViewer.ViewportWidth;
            scrollviewerVH = scrollViewer.ViewportHeight;

            if (changed == true)
            {
                NewExtentW = image.Width * Sscale;
                NewExtentH = image.Height * Sscale;

                RecScale = NewExtentW / Wsmallimage;
                if (Hsmallimage * RecScale > NewExtentH)
                {
                    RecScale = NewExtentH / Hsmallimage;
                }

                rectanglewidth = scrollviewerVW / RecScale;
                rectangleheight = scrollviewerVH / RecScale;
                Recwidth = rectanglewidth;
                RecHeight = rectangleheight;
            }

            RecUp = ((Hsmallimage - RecHeight) * scrollViewer.VerticalOffset) / scrollViewer.ScrollableHeight;
            RecLeft = ((Wsmallimage - Recwidth) * scrollViewer.HorizontalOffset) / scrollViewer.ScrollableWidth;

        }
        #endregion
        #region WindowsLoaded
        public void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            var window = sender as MainWindow;
            var maingrid = window.Content as Grid;
            var grid1 = maingrid.Children[0] as Grid;
            var smallimage = grid1.Children[0] as Image;
            var scrollViewer = maingrid.Children[1] as ScrollViewer;


            Pscrollviewer = scrollViewer;


            Recwidth = smallimage.ActualWidth;
            RecHeight = smallimage.ActualHeight;
            Cwidth = smallimage.ActualWidth;
            CHeight = smallimage.ActualHeight;
            Wsmallimage = smallimage.ActualWidth;
            Hsmallimage = smallimage.ActualHeight;

            double ScaleFit = scrollViewer.ViewportWidth / image.Width;
            if (image.Height * ScaleFit > scrollViewer.ViewportHeight)
            {
                ScaleFit = scrollViewer.ViewportHeight/ image.Height;
            }
            Sscale = ScaleFit;


            


            rectanglewidth = smallimage.ActualWidth;
            rectangleheight = smallimage.ActualHeight;
        }
        #endregion
        #region SizeChanged
        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            changed = true;

            
            
               
         
        }
        #endregion
        #endregion


    }

}
