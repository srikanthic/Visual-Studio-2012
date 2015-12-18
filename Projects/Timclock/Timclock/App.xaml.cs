using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using Timclock.Control;
using Timclock.Model;
namespace Timclock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool fetchRec = false;
        private readonly DispatcherTimer _dispatcherTimerSyncSfRecrds = new DispatcherTimer();
        DispatcherTimer DispatcherTimer = new DispatcherTimer();
        protected int i = 20;
        private readonly MyDbConnClass _myDbConnClass=new MyDbConnClass();
        //public static bool isSyncedToSF;
        public static bool TryForLogin;
        public static bool Isanyrecordstoupdate;
        public static bool Inprogress;
        private bool Autorun = Timclock.Properties.Settings.Default.AutoLogin;
        public App()
        {

            if (Autorun)
            {
                LoginAttribute loginattributs = new LoginAttribute();
                Cradentials cradentials = new Cradentials();
                bool sandbox = LoginAttribute.sandbox;
                loginattributs = cradentials.Login();
                if (!string.IsNullOrEmpty(loginattributs._username) && !string.IsNullOrEmpty(loginattributs._password) && Cradentials.Logintrys <= 1)
                {
                    Cradentials.Logintrys = 1;
                    while (Cradentials.Logintrys != 0 && Cradentials.Logintrys < 3)
                    {
                        cradentials.RunSample(loginattributs);
                    }
                }
            }
            DispatcherTimer.Tick += time_tick;
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            DispatcherTimer.Start();
            
        }
        private void time_tick(object sender, EventArgs e)
        {
            if (!Inprogress)
            {
                Inprogress = true;
                if (IsConnectedToInternet())
                {
                    Cradentials.IsConnectedToInternet = true;
                    i++;
                    if (i > 40)
                    {
                        if (_myDbConnClass.CheckCredentials())
                        {
                            i = 0;
                            List<Local_DailyShift> SyncRecrds = _myDbConnClass.SearchQuery("Local_DailyShift", "IsSync",1);
                            if (SyncRecrds != null && SyncRecrds.Count > 0)
                            {
                                Isanyrecordstoupdate = true;
                                Isanyrecordstoupdate = _myDbConnClass.SyncLocalToSF(SyncRecrds);
                                //isSyncedToSF = _myDbConnClass.SyncLocalToSF(SyncRecrds);

                                //MessageBox.Show(Isanyrecordstoupdate.ToString());
                            }
                            else
                            {
                                Isanyrecordstoupdate = false;
                            }
                        }
                    }
                }
                else
                {
                    Cradentials.IsConnectedToInternet = false;
                }
                Inprogress = false;
            }
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
        
    }
}
