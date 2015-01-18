using System;

namespace Raging.Toolbox.Net
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RouteAttribute : Attribute
    {
        public RouteAttribute(string address)
        {
            Guard.NullOrWhiteSpace(() => address, address);

            this.Address = address;
        }

        public RouteAttribute(string route, string name)
            : this(route)
        {
            Guard.NullOrWhiteSpace(() => name, name);

            this.Name = name;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }
    }
}