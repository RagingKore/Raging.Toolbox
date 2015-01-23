using System;

namespace Raging.Toolbox.Net
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RouteAttribute : Attribute
    {
        public RouteAttribute(string address)
        {
            Guard.NullOrWhiteSpace(() => address);

            this.Address = address;
        }

        public RouteAttribute(string address, string name)
            : this(address)
        {
            Guard.NullOrWhiteSpace(() => name);

            this.Name = name;
        }

        public RouteAttribute(string address, string name, string queryString)
            : this(address, name)
        {
            this.QueryString = queryString;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public string QueryString { get; private set; }
    }
}