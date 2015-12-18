using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            if (Application.Current.Properties["InstanceUrl"] != null) { InstanceUrl.Text = Application.Current.Properties["InstanceUrl"].ToString(); }
            if (Application.Current.Properties["AccessToken"] != null) { AccessToken.Text = Application.Current.Properties["AccessToken"].ToString(); }
            if (Application.Current.Properties["SF_ApiVersion"] != null) { ApiVersion.Text = Application.Current.Properties["SF_ApiVersion"].ToString(); }
            if (Application.Current.Properties["SFToken"] != null) { sftoken.Text = Application.Current.Properties["SFToken"].ToString(); }
            if (Application.Current.Properties["SFUsername"] != null) { sfusername.Text = Application.Current.Properties["SFUsername"].ToString(); }
            if (Application.Current.Properties["SFPassword"] != null) { sfpassword.Password = Application.Current.Properties["SFPassword"].ToString(); }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Operations().Show();
            Hide();
        }
    }
}
