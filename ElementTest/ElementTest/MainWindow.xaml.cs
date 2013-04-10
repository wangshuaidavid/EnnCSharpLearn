using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ComponentModel;
namespace ElementTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public ElementWindow elementWindow;

        public MainWindow()
        {
            InitializeComponent();
            this.MainCanvas.AllowDrop = true;
            this.MainCanvas.DragOver += new DragEventHandler(canvas_DragOver);
            this.MainCanvas.Drop += new DragEventHandler(canvase_Drop);
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(String)))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void canvase_Drop(object sender, DragEventArgs e)
        {
            IDataObject data = e.Data;
            if (data.GetDataPresent(typeof(String)))
            {
                String s = data.GetData(typeof(String)) as String;
                // MessageBox.Show(msg);
        
                Point pg = e.GetPosition(this.MainCanvas);
                Console.WriteLine(pg.ToString());
                Rectangle r = new Rectangle();
                r.Width = 100;
                r.Height = 100;
                r.Fill = new SolidColorBrush(Colors.Black);
                Canvas.SetLeft(r, pg.X);
                Canvas.SetTop(r, pg.Y);
                Console.WriteLine(pg.ToString());
                this.MainCanvas.Children.Add(r);
            }
        }


        void hideElementWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.doHideElementWindow();      
        }

       private void doHideElementWindow()
        {
            this.elementWindow.Hide();
        }

        private void showItemPanelButton_Click(object sender, RoutedEventArgs e)
        {
            elementWindow.Show();
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            elementWindow = new ElementWindow();
            elementWindow.Owner = this;
            elementWindow.ShowInTaskbar = false;
            elementWindow.Closing += new CancelEventHandler(hideElementWindow);
        }


    }
}
