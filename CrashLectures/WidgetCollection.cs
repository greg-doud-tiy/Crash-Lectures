using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashLectures
{
    //public class WidgetCollection : List<Widget>
    //{
    //  Nothing to add ...
    //}
   public class WidgetCollection : Dictionary<int, Widget>
    {
        public void Add(Widget widget)
        {
            this.Add(widget.Id, widget);
        }
    }
}
