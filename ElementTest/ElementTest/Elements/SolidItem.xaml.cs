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
    /// Interaction logic for SolidItem.xaml
    /// </summary>
    public partial class SolidItem : UserControl
    {
        public SolidItem()
        {
            InitializeComponent();
        }

        private void port1_MouseEnter(object sender, MouseEventArgs e)
        {
            UserControl uc = (UserControl) sender;
            uc.Background = new SolidColorBrush(Colors.Red);
        }

        private void port1_MouseLeave(object sender, MouseEventArgs e)
        {
            UserControl uc = sender as UserControl;
            uc.Background = new SolidColorBrush(Colors.Blue);
        }

        private void port1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("mouseup");
        }
    }
}
