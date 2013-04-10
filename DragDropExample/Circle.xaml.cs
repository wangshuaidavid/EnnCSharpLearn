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

namespace DragDropExample
{
    /// <summary>
    /// Interaction logic for Circle.xaml
    /// </summary>
    public partial class Circle : UserControl
    {

        private Brush _previouseFill = null;

        public Circle()
        {
            InitializeComponent();
        }

        public Circle(Circle c)
        {
            InitializeComponent();
            this.circleUI.Width  = c.circleUI.Width;
            this.circleUI.Height = c.circleUI.Height;
            this.circleUI.Fill   = c.circleUI.Fill;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, circleUI.Fill.ToString());
                data.SetData("Double", circleUI.Height);
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            if (e.Effects.HasFlag(DragDropEffects.Copy)) {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            if(e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString)) {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString);
                    circleUI.Fill = newFill;

                    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.None;

            if (e.Data.GetDataPresent(DataFormats.StringFormat)) 
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);
                BrushConverter converter = new BrushConverter();
                if(converter.IsValid(dataString))
                {
                    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            _previouseFill = this.circleUI.Fill;
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);
                BrushConverter converter = new BrushConverter();
                if(converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString.ToString());
                    this.circleUI.Fill = newFill;
                }
            }
            
        }

        protected override void OnDragLeave(DragEventArgs e)
        {
            base.OnDragLeave(e);
            circleUI.Fill = _previouseFill;
        }
    }
}
