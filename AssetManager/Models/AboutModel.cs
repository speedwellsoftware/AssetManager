using System.Reflection;
using System.Threading;

namespace AssetManager.Models
{
    public class AboutModel
    {
        public string Name => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        public string Version => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
    }
}