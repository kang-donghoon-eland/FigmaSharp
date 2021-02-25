using FigmaSharp.Views.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FigmaSharp.Views.Wpf.ViewWrappers
{
    public class TabView : View, ITabView
    {
        readonly TabControl tabControl;

        public TabView(TabControl control)
        {
            tabControl = control;
        }

    }
}
