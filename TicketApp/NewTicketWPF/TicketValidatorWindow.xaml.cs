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
using System.Windows.Threading;

namespace NewTicketWPF
{

    /// <summary>
    /// Interaction logic for TicketValidatorWindow.xaml
    /// </summary>
    public partial class TicketValidatorWindow : Window
    {
        public Profile currentProfile;

        public TicketValidatorWindow(MainWindow main)
        {
            InitializeComponent();
            StartClock();
            Main = main;  
            currentProfile = main.CurrentProfile;
            UList.ItemsSource = currentProfile.SetProfile.tickets;
        }

        public MainWindow Main { get; set; }

        
        protected void TicketInputKeyDown(object sender, EventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            Main.IsEnabled = true;
            base.OnClosed(e);
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += TickEvent;
            timer.Start();
        }

        private void TickEvent(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string form = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString();
            Time.Text = form;
        }
    }
}
