using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace sk.wpf.common.Behavior
{
    public class DataGridDragDropEventArgs : EventArgs
    {
        public object Source { get; internal set; }
        public object Destination { get; internal set; }

        public object DroppedObject { get; internal set; }
        public object TargetObject { get; internal set; }

        public DataGridDragDropDirection Direction { get; internal set; }
        public DragDropEffects Effects { get; internal set; }
    }
}
