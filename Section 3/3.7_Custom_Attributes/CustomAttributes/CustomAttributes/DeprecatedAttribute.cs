using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class DeprecatedAttribute : Attribute
    {
        public DeprecatedAttribute()
        {
            
        }
    }
}
