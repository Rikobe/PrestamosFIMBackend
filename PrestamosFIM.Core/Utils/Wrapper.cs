using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosFIM.Core.Utils
{
    public class Wrapper<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}
