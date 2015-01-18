namespace Raging.Toolbox.Net
{
    public class Route<TDecorated>
    {
        public static string Name 
        {
            get
            {
                return Attributes<TDecorated>.Get<RouteAttribute>().Name;
            }
        }

        public static string Address
        {
            get
            {
                return Attributes<TDecorated>.Get<RouteAttribute>().Address;
            }
        }
    }
}