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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElementTest.Elements
{

    /// <summary>
    /// Interaction logic for ToolElement.xaml
    /// </summary>
    public partial class ToolElement : UserControl
    {
        private Window _dragdropWindow = null;

        public ToolElement()
        {
            InitializeComponent();
        }

        private void Element_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewMouseMove += new MouseEventHandler(element_PreviewMouseMove);
        }

        void element_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.StartDragWindow(e);
            }
        }

        private void StartDragWindow(MouseEventArgs e)
        {
            QueryContinueDragEventHandler queryhandler = new QueryContinueDragEventHandler(DragSource_QueryContinueDrag);
            this.QueryContinueDrag += queryhandler;
            this.CreateDragDropWindow(this);
            DataObject data = new DataObject(typeof(String), "aa");
            this._dragdropWindow.Show();
            DragDropEffects de = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            this.DestroyDragDropWindow();

            this.QueryContinueDrag -= queryhandler;
        }

        private void StartDragWindow_bak(MouseEventArgs e)
        {
            QueryContinueDragEventHandler queryhandler = new QueryContinueDragEventHandler(DragSource_QueryContinueDrag);
            this.QueryContinueDrag += queryhandler;
            this.CreateDragDropWindow(this);
            DataObject data = new DataObject(typeof(Rectangle), this);
            this._dragdropWindow.Show();
            DragDropEffects de = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            this.DestroyDragDropWindow();

            this.QueryContinueDrag -= queryhandler;
        }

        void DragSource_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            this.UpdateWindowLocation();
        }

        private void UpdateWindowLocation()
        {
            if (this._dragdropWindow != null)
            {
                Win32.POINT p;
                if (!Win32.GetCursorPos(out p))
                {
                    return;
                }
                this._dragdropWindow.Left = (double)p.X;
                this._dragdropWindow.Top = (double)p.Y;
            }
        }

        /// <summary>
        /// 创建拖拽窗体
        /// </summary>
        /// <param name="dragElement"></param>
        private void CreateDragDropWindow(Visual dragElement)
        {
            this._dragdropWindow = new Window();
            this._dragdropWindow.WindowStyle = WindowStyle.None;
            this._dragdropWindow.Opacity = 0.6;
            this._dragdropWindow.AllowsTransparency = true;
            this._dragdropWindow.AllowDrop = false;
            this._dragdropWindow.Background = null;
            this._dragdropWindow.IsHitTestVisible = false;
            this._dragdropWindow.SizeToContent = SizeToContent.WidthAndHeight;
            this._dragdropWindow.Topmost = true;
            this._dragdropWindow.ShowInTaskbar = false;


            this._dragdropWindow.SourceInitialized += new EventHandler(
            delegate(object sender, EventArgs args)
            {
                PresentationSource windowSource = PresentationSource.FromVisual(this._dragdropWindow);
                IntPtr handle = ((System.Windows.Interop.HwndSource)windowSource).Handle;

                Int32 styles = Win32.GetWindowLong(handle, Win32.GWL_EXSTYLE);
                Win32.SetWindowLong(handle, Win32.GWL_EXSTYLE, styles | Win32.WS_EX_LAYERED | Win32.WS_EX_TRANSPARENT);
            });

            Rectangle r = new Rectangle();
            r.Width = ((FrameworkElement)dragElement).ActualWidth;
            r.Height = ((FrameworkElement)dragElement).ActualHeight;
            r.Fill = new VisualBrush(dragElement);
            this._dragdropWindow.Content = r;

            this.UpdateWindowLocation();
        }

        /// <summary>
        /// 销毁托抓窗体
        /// </summary>
        private void DestroyDragDropWindow()
        {
            if (this._dragdropWindow != null)
            {
                this._dragdropWindow.Close();
                this._dragdropWindow = null;
            }
        }

    }
}
