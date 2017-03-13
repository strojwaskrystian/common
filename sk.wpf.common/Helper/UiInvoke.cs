using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace sk.wpf.common.Helper
{
    public class UiInvoke
    {
        public static void Flush(Action a)
        {
            Application.Current.Dispatcher.Invoke(a);
        }

        public static void FlushBackground(Action a)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, a);
        }

        public static void FlushBackground(Delegate a)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, a);
        }

    }
}
