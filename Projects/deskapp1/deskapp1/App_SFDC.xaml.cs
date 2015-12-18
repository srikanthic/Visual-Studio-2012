using System.Windows;

namespace deskapp1
{
    public partial class App : Application
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string InstanceUrl { get; set; }
    }
}
