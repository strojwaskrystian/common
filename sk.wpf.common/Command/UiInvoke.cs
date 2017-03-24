using System;
using System.Windows;
using System.Windows.Threading;

namespace sk.wpf.common.Command
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
