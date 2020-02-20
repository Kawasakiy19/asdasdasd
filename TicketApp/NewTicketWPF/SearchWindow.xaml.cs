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

namespace NewTicketWPF
{
    /// <summary>
    /// Interaction logic for SearchWindiw.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        List<Profile> pf;
        Profile selectedProfile;
        string selected;
        public SearchWindow(MainWindow main)
        {
            InitializeComponent();
            Main = main;
            pf = pf.LoadAllProfile();
            FillProfileBox();
            selectedProfile = main.CurrentProfile;
            ProfileBox.SelectedIndex = 0;
            ActualPf.IsChecked = true;

        }

        public SearchWindow(TicketValidatorWindow validator, Profile profile)
        {
            InitializeComponent();
            Validator = validator;
            selectedProfile = profile;
            selected = "InValidator";
            SearchClick(null, new RoutedEventArgs());
        }
        public TicketValidatorWindow Validator { get; set; }

        public MainWindow Main
        {
            get;
            set;
        }



        private void TicketId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            Main.IsEnabled = true;
            Close();
        }

        public void FillProfileBox()
        {
            foreach (var p in pf)
            {
                ProfileBox.Items.Add(p);
            }
        }

        private void ProfileBox_DropDownClosed(object sender, EventArgs e)
        {
            selectedProfile = pf[ProfileBox.SelectedIndex];
            ProfileBox.Items.Refresh();

            if (AllPf.IsChecked == true)
            {
                ProfileBox.Visibility = Visibility.Collapsed;
                ProfileText.Visibility = Visibility.Collapsed;
            }
        }

        private void AllPf_Checked(object sender, RoutedEventArgs e)
        {
            if (AllPf.IsChecked == true)
            {
                ProfileBox.Visibility = Visibility.Collapsed;
                ProfileText.Visibility = Visibility.Collapsed;
                Height = 120;
                selected = AllPf.Name.ToString();
            }
            if (ActualPf.IsChecked == true)
            {
                ProfileBox.Visibility = Visibility.Visible;
                ProfileText.Visibility = Visibility.Visible;
                Height = 150;
                selected = ActualPf.Name.ToString();
            }
        }

        protected void SearchClick(object sender, RoutedEventArgs e)
        {
            switch (selected)
            {
                case "ActualPf":
                    SearchSelectedProfile();
                    break;
                case "AllPf":
                    SearchAllProfile();
                    break;
                case "InValidator":
                    SearchSelectedProfile();
                    break;
            }
        }

        protected void CancelClick(object sender, RoutedEventArgs e)
        {
            OnClosed(e);
        }

        private Profile SearchAllProfile()
        {
            try
            {
                Ticket item = null;
                Profile foundProfile = null;
                foreach (Profile p in pf)
                {
                    foundProfile = p;
                    item = p.SetProfile.tickets.Find(t => t.ID == int.Parse(TicketId.Text.ToString()));
                }
                if (item != null)
                {
                    MessageBox.Show("Found a ticket in:\n - Profile: " + foundProfile.ProfileName
                         +"\n - Ticket id: " + item.IDS + "\n - Status:   " + item.GetStatus + "\n                  " + item.GetSoldState ,"Ticket Found", MessageBoxButton.OK, MessageBoxImage.Information);
                    return foundProfile;
                }
                else
                {
                    MessageBox.Show("No matches for " + TicketId.Text.ToString(), "Ticket Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ticket Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private Ticket SearchSelectedProfile()
        {
            try
            {
                Ticket foundTicket = null;
                var ticket = selectedProfile.SetProfile.tickets.Find(t => t.ID == int.Parse(TicketId.Text.ToString()));
                if (ticket != null)
                {
                    MessageBox.Show("Found a ticket: " + "\n - Ticket id: " + ticket.IDS + "\n - Status:   " + ticket.GetStatus + "\n                  " 
                        + ticket.GetSoldState, "Ticket Found", MessageBoxButton.OK, MessageBoxImage.Information);
                    return foundTicket;
                }
                else
                {
                    MessageBox.Show("No matches for " + TicketId.Text.ToString(), "Ticket Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ticket Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
