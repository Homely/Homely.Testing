using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Homely.Testing
{
    /// <summary>
    /// Common serialization settings for our tests.
    /// </summary>
    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Formatting = Formatting.Indented;
            DateFormatString = "yyyy-MM-ddTHH:mmZ";
            NullValueHandling = NullValueHandling.Ignore;
            Error += (sender,
                      args) =>
            {
                args.ErrorContext.Handled = true;
            };
        }
    }
}
