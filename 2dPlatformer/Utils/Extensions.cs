using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPlatformer.Utils
{
    static class Extensions
    {
        public static float Abs(this float val)
        {
            return val < 0 ? -val : val;
        }
    }
}
