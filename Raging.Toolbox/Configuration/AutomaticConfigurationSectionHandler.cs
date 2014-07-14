using System;
using System.Configuration;
using System.Xml;

namespace Raging.Toolbox.Configuration
{
    public class AutomaticConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            throw new NotImplementedException();

            //using(var rdr = new XmlNodeReader(section))
            //{
            //    var root = XElement.Load(rdr);
            //}
        }
    }
}