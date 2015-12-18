using System.Windows;

namespace Timclock
{
    public partial class App : Application
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string InstanceUrl { get; set; }
    }
}
