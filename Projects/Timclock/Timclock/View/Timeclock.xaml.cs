using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Timclock.Control;

namespace Timclock.View
{
    /// <summary>
    /// Interaction logic for Timeclock.xaml
    /// </summary>
    public partial class Timeclock : Window
    {
        //public static int closing_window;
        //private static bool invalidmessageshow;
        MyDbConnClass _myDbConnClass = new MyDbConnClass();
        Operations _operations;
        PunchInPunchOut _punchInPunchOut;
        private ErrorDisplay ErrorDisplay;
        public Timeclock()
        {
            //closing_window++;
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                Height = SystemParameters.PrimaryScreenWidth / 2.5;
                Width = SystemParameters.PrimaryScreenHeight / 1.8;
            }
            //if (invalidmessageshow)
            //{
            //    if (MessageBox.Show("") == MessageBoxResult.OK) invalidmessageshow = false;
            //}
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Cradentials.OpenHiddenWindowCheack(new Operations());
            _operations = null;
            _operations = new Operations();
            _operations.Show();
            //Cradentials.OpenHiddenWindowCheack(new Operations())
            //closing_window--;
            //if (closing_window <= 0)
            //{
            //    if (!Cradentials.OpenHiddenWindowCheack(new Operations()))
            //    {
            //        new Operations().Show();
            //    }
            //}
        }
        

        //private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //MessageBox.Show("Test messegbox2");
        //    TextBox tb=sender as TextBox;
        //    if (tb != null && tb.Text.Length == 8)
        //    {
        //        string RFID = (tb.Text.Trim() as string).ToString();
        //        string SFID;
        //        _myDbConnClass.DBConn();
        //        //Local_Person localPerson = new Local_Person();
        //        //Type type = typeof (Local_Person);
        //        /*   if (_punchInPunchOut == null)
        //       {
        //           _punchInPunchOut = new PunchInPunchOut(tb.Text);
        //           _punchInPunchOut.ShowDialog();
        //       }
        //       else
        //       {
        //           _punchInPunchOut.Show();
        //       }*/
        //        //MessageBox.Show("Test messegbox1");
        //        SFID = _myDbConnClass.SearchQuery("Local_Person", "RFID", RFID);
        //        //MessageBox.Show("Test messegbox2");
        //        if (SFID != "")
        //        {
        //            _punchInPunchOut = new PunchInPunchOut(SFID);
        //            Hide();
        //            _punchInPunchOut.ShowDialog();
        //        }
        //        else
        //        {
        //            ErrorDisplay = new ErrorDisplay();
        //            Hide();
        //            ErrorDisplay.ShowDialog();
        //            //invalidmessageshow = true;
        //            //MessageBox.Show("No Record With this RFID");
        //        }
        //        tb.Text = "";
        //    }
        //}

        

        private void Timeclock_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            e.Handled = !IsTextAllowed(e.Text); 
        }

        private bool IsTextAllowed(string text)
        {
            return Array.TrueForAll<char>(text.ToCharArray(),
            delegate(Char c) { return Char.IsDigit(c) || Char.IsControl(c); });

            //foreach (Char c in text.ToCharArray())
            //{
            //    if (Char.IsDigit(c) || Char.IsControl(c)) continue;
            //    else return false;
            //}
            //return true;
        }

        private void TextBox_OnPasting(object sender, DataObjectPastingEventArgs e)
        {

            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text)) e.CancelCommand();
            }
            else e.CancelCommand();
        }
       
        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			 if(WindowState == WindowState.Normal)
            {
               WindowState=WindowState.Maximized;
            }
        else
            {
                WindowState=WindowState.Normal;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox != null && TextBox.Text.Length == 8)
            {
                string RFID = TextBox.Text.Trim();
                string SFID;
                _myDbConnClass.DBConn();
                //Local_Person localPerson = new Local_Person();
                //Type type = typeof (Local_Person);
                /*   if (_punchInPunchOut == null)
               {
                   _punchInPunchOut = new PunchInPunchOut(tb.Text);
                   _punchInPunchOut.ShowDialog();
               }
               else
               {
                   _punchInPunchOut.Show();
               }*/
                //MessageBox.Show("Test messegbox1");
                SFID = _myDbConnClass.SearchQuery("Local_Person", "RFID", RFID);
                //MessageBox.Show("Test messegbox2");
                if (SFID != "")
                {
                    _punchInPunchOut = new PunchInPunchOut(SFID);
                    Hide();
                    _punchInPunchOut.ShowDialog();
                }
                else
                {
                    ErrorDisplay = new ErrorDisplay();
                    Hide();
                    ErrorDisplay.ShowDialog();
                    //invalidmessageshow = true;
                    //MessageBox.Show("No Record With this RFID");
                }
                TextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Id");
            }
        }
    }
}
