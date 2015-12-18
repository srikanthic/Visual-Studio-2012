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
using Timclock.Control;
using Timclock.Model;

namespace Timclock.View
{
    /// <summary>
    /// Interaction logic for ViewLocalDb.xaml
    /// </summary>
    public partial class ViewLocalDb : Window
    {
        List<TreeViewItem> treeViewItems = new List<TreeViewItem>();
        MyDbConnClass myDbConnClass = new MyDbConnClass();
        public ViewLocalDb()
        {
            InitializeComponent();
            //List<Dictionary<string, string>> dictionary = myDbConnClass.GetLocalTables();
            Dictionary<string, string> dictionary = myDbConnClass.GetLocalTables();
            TreeViewItem treeViewItem= new TreeViewItem();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                treeViewItem = new TreeViewItem();
                treeViewItem.Header=keyValuePair.Value;
                treeViewItem.Tag = keyValuePair.Key;
                treeViewItem.IsSelected = false;
                //treeViewItem.Items.Add(treeViewItem);
                treeViewItems.Add(treeViewItem);
            }
            TreeViewItem.ItemsSource = treeViewItems;
            #region MyRegion
            

       //     ListView list= new ListView();
       //     list.Margin= new Thickness(5);
            
       //     GridView gridView =new GridView();
       //     List.View =gridView;
//            DataTemplate dataTemplate = new DataTemplate();
   //         gridView.ColumnHeaderTemplate=dataTemplate;
  //         TextBlock textBlock=new TextBlock();
  //         textBlock.Text = "ColumnHeaderTemplate";

            
            //var newTextBlock = new FrameworkElementFactory(typeof(TextBlock));
           //newTextBlock.Name = "txt";
           //newTextBlock.SetBinding(TextBlock.TextProperty, new Binding("ColumnHeaderTemplate"));
           //DataTemplate newDataTemplate = new DataTemplate() { VisualTree = newTextBlock };
           //gridView.ColumnHeaderTemplate = newDataTemplate;
            #endregion
            #region MyRegion

            //TreeView.Items.Add(dictionary);
            //

            //foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            //{
            //    keyValuePair.Key.ToString();
            //}

            //TreeViewItem Tabllist = new TreeViewItem();
            //Tabllist.Header = "sdas";
            //TreeView.Items.Add(Tabllist);
            //TreeView.Items.Add(Tabllist);
            //TreeView.Items.Add(Tabllist);
            //TreeView.Items.Add(Tabllist);
            //my my = new my();
            //my.Name = "asdsd";
            //my my1 = new my();
            //my1.Name = "wwew";
            //List<my> myList= new List<my>();
            //myList.Add(my);
            //myList.Add(my1);
            //TreeView.Items.Add(my);
            //TreeView.Items.Add(my1);

            #endregion
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ApplicationOperations.OpenHiddenWindowCheack(new Operations()))
            {
                new Operations().Show();
            }
        }

        private void TreeViewItem_OnSelected(object sender, RoutedEventArgs e)
        {
            //TreeViewItem treeViewItem1 = (sender as TreeViewItem);
            //int position= treeViewItem1.Items.CurrentPosition;
            //var v = treeViewItem1.Items.IsEmpty;
            //var v1 = treeViewItem1.Name +" "+ treeViewItem1.Tag +" "+treeViewItem1.IsEnabled;
            string treeViewItemTag =string.Empty;

            TreeViewItem treeViewItem=sender as TreeViewItem;
           
                foreach (TreeViewItem treeItem in treeViewItem.Items)
                {
                    string s = treeItem.Header.ToString();
                    if (treeItem.IsSelected)
                    {
                        treeViewItemTag = treeItem.Tag.ToString();
                    }
                }


                //int i = (sender as TreeView).Items.CurrentPosition;
                //TreeViewItem treeViewItem = TreeView.Items[0] as TreeViewItem;
                //string treeViewItemTag = treeViewItem.Tag.ToString();
                //MessageBox.Show(treeViewItem.Tag.ToString());
                if (treeViewItemTag == "Local_Person")
                {
                    ListNone.Visibility = Visibility.Hidden;
                    ListPerson.Visibility = Visibility.Visible;
                    localDailyShift.Visibility = Visibility.Hidden;
                    List<Local_Person> localPersons = myDbConnClass.GetLocalPersons();
                    ListPerson.ItemsSource = localPersons;
                    localDailyShift.ItemsSource = null;
                }
                //else if (treeViewItemTag == "Local_LoginDetail")
                //{
                //    ListNone.Visibility = Visibility.Hidden;
                //    ListPerson.Visibility = Visibility.Hidden;
                //    ListLoginDetail.Visibility = Visibility.Visible;
                //    List<Local_LoginDetail> localLoginDetails = myDbConnClass.GetLocalLoginDetail();
                //    ListLoginDetail.ItemsSource = localLoginDetails;
                //    ListPerson.ItemsSource = null;
                //}
                else if (treeViewItemTag == "Local_DailyShift")
                {
                    ListNone.Visibility = Visibility.Hidden;
                    ListPerson.Visibility = Visibility.Hidden;
                    localDailyShift.Visibility = Visibility.Visible;
                    List<Local_DailyShift> localDailyShifts = myDbConnClass.GetLocalDailyShifts();
                    localDailyShift.ItemsSource = from localShift in localDailyShifts
                                                  where localShift.IsSync == false
                                                  select localShift; ;//localDailyShifts;
                    ListPerson.ItemsSource = null;
                }
                else
                {
                    ListNone.Visibility = Visibility.Visible;
                    ListPerson.Visibility = Visibility.Hidden;
                    localDailyShift.Visibility = Visibility.Hidden;
                    ListPerson.ItemsSource = null;
                    localDailyShift.ItemsSource = null;
                }
        }
    }

    //class my
    //{
    //    public string Name { get; set; }
    //}
}
