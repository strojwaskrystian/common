using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sk.wpf.common.ViewModel
{
    public class CardProvider<T> : IItemsProvider<T>
    {

        private readonly int _count;
        private readonly int _fetchDelay;
        private List<T> _list = new List<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoCustomerProvider"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="fetchDelay">The fetch delay.</param>
        public CardProvider(int count, int fetchDelay, List<T> llistcard)
        {
            _count = count;
            _fetchDelay = fetchDelay;
            _list = llistcard;
        }

        /// <summary>
        /// Fetches the total number of items available.
        /// </summary>
        /// <returns></returns>
        public int FetchCount()
        {
            //Trace.WriteLine("FetchCount");
            Thread.Sleep(_fetchDelay);
            return _count;
        }

        /// <summary>
        /// Fetches a range of items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to fetch.</param>
        /// <returns></returns>
        public IList<T> FetchRange(int startIndex, int count)
        {
            //Trace.WriteLine("FetchRange: "+startIndex+","+count);
            Thread.Sleep(_fetchDelay);

            List<T> list = new List<T>();
            for (int i = startIndex; (i < startIndex + count) && (i < _list.Count()); i++)
            {
                list.Add(_list[i]);
            }
            return list;
        }
    }
}
