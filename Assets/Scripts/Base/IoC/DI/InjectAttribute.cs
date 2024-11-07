using System;

namespace Base.IoC.DI
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public string Name { get; set; }
    }
}