using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Management; //add dll to reference
using Microsoft.Win32;

namespace Win10_BrightnessSlider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //override form as toolwindow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width +22 ,
                Screen.PrimaryScreen.WorkingArea.Height +22 );


            //colors
            BackColor = Color.FromArgb(31, 31, 31);
            label1.ForeColor = Color.White;

            //form show hide event
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
            //clicked outside of form
            Deactivate += Form1_Deactivate;


            CreateNotifyIConContexMenu();
            UpdateStatesOnGuiControls();
        }

        private void CreateNotifyIConContexMenu()
        {

            var cm = new ContextMenu();
            var mi1 = new MenuItem("Exit", (snd, ev) => {
                Application.Exit();
            });

            var mi2 = new MenuItem("State Of Window", (snd, ev) => {
                var msg =
                "visible:" + this.Visible + "\r\n" +
                "Focused:" + this.Focused + "\r\n" +
                "canFocus:" + this.CanFocus + "\r\n";
                MessageBox.Show(msg);
            });

            var mi3 = new MenuItem("Run At Startup", (snd, ev) => {
                var _mi3 = snd as MenuItem;

                _mi3.Checked = !_mi3.Checked; // toggle

                SetStartup(_mi3.Checked);
            });

            cm.MenuItems.Add(mi1);
            cm.MenuItems.Add(mi3);

            if (System.Diagnostics.Debugger.IsAttached)
            {
                cm.MenuItems.Add(mi2);
            }

            notifyIcon1.ContextMenu = cm;
        }
        private void UpdateStatesOnGuiControls()
        {
            //get current states
            var isRunSttup = isRunAtStartup();
            notifyIcon1.ContextMenu.MenuItems
                .Cast<MenuItem>().Where( x=> x.Text == "Run At Startup").FirstOrDefault()
                .Checked = isRunSttup;

            var initBrig = GetBrightness();
            label1.Text = initBrig + "";
            trackBar1.Value = initBrig;
        }


        bool vis = false;
        public void eSetVis(bool visible)
        {
            Console.WriteLine("eSetVis - vis:" + vis);
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;

            var scrWA = Screen.PrimaryScreen.WorkingArea;
            var p = new Point(scrWA.Width , scrWA.Height );

            if (visible)
            {
                p.Offset(-this.Width, -this.Height);
                this.Location = p;

                this.Activate();
                this.Show();
                this.BringToFront();

                vis = true;
            }
            else
            {
                p.Offset(this.Width, this.Height);
                this.Location = p;

                vis = false;

            }



        }
       
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            eSetVis(false);
        }
        
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.MouseClick -= NotifyIcon1_MouseClick;
            Deactivate -= Form1_Deactivate;

            if ( e.Button == MouseButtons.Left)
            {
                Console.WriteLine("Notify Cliiked - vis:" + vis);

                eSetVis(!vis);
            }
           

            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
            Deactivate += Form1_Deactivate;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            byte g = 0;
            if (byte.TryParse(trackBar1.Value + "", out g))
            {
                SetBrightness(g);
                label1.Text = g + "";
            }


        }

        static void SetBrightness(byte targetBrightness)
        {
            ManagementScope scope = new ManagementScope("root\\WMI");
            SelectQuery query = new SelectQuery("WmiMonitorBrightnessMethods");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    foreach (ManagementObject mObj in objectCollection)
                    {
                        mObj.InvokeMethod("WmiSetBrightness",
                            new Object[] { UInt32.MaxValue, targetBrightness });
                        break;
                    }
                }
            }
        }
        static int GetBrightness()
        {
            ManagementScope scope = new ManagementScope("root\\WMI");
            SelectQuery query = new SelectQuery("WmiMonitorBrightness");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    foreach (ManagementObject mObj in objectCollection)
                    {
                        var br_obj = mObj.Properties["CurrentBrightness"].Value;

                        int br = 0;
                        int.TryParse(br_obj+"", out br);
                        return br;
                        break;
                    }
                }
            }
            return 0;

        }

        private void SetStartup( bool RunAtStartup )
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (RunAtStartup)
                rk.SetValue(  Application.ProductName, Application.ExecutablePath );
            else
                rk.DeleteValue(Application.ProductName , false);

        }
        private bool isRunAtStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            var  val  = rk.GetValue(Application.ProductName );

            if (val+"" == Application.ExecutablePath  )
                return true;
            else
                return false;

        }



    }


    
}





 