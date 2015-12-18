using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Collections.ObjectModel;
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

namespace WpfTestExamples
{
    /// <summary>
    /// Interaction logic for VirtualizingStackPanel.xaml
    /// </summary>
    public partial class VirtualizingStackPanel : Window
    {
        public VirtualizingStackPanel()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<int> obs = new ObservableCollection<int>();
            //List<int> obs =new List<int>();
            Random rnd = new Random(1000);
            for (int i = 0; i < 100000; i++)
                obs.Add(rnd.Next());
            lstElements.DataContext = obs;
        }
    }
}
