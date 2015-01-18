using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Raging.Toolbox.Net.Adapters
{
    public interface IHttpContentAdapter
    {
        Task<T> ReadAsAsync<T>(IEnumerable<MediaTypeFormatter> formatters);

        Task<string> ReadAsStringAsync();
    }
}