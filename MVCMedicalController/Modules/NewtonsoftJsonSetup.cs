using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMedicalController.Modules
{
    public class NewtonsoftJsonSetup : IDisposable
    {
        public static void SetupNewtonsoftJson()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
