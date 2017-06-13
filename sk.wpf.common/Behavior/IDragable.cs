using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sk.wpf.common.Behavior
{
    interface IDragable
    {
        /// <summary>
        /// Type of the data item
        /// </summary>
        Type DataType { get; }

        /// <summary>
        /// Remove the object from the collection
        /// </summary>
        void Remove(object i);
    }
}
