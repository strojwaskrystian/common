using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk.wpf.common.Model
{
    public interface ITreeLocationModel
    {
        int GetLocationLevel { get; }
        string GetName { get; }
        int GetID { get; }
    }
}
