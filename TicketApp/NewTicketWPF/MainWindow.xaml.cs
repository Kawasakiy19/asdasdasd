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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewTicketWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicketValidatorWindow objTicketValidatorWindow;
        ProfileWindow objNewProfileWindow;
        Profile currentProfile;
        RenameWindow objRenameWindow;
        RegenerateWindow objRegenerateWindow;
        SelectProfileWindow objSelectProfileWindow;
        DeleteWindow objDeleteWindow;
        SearchWindow objSearchWindow;
        string theme;
        public MainWindow()
        {
            InitializeComponent();
            if (!currentProfile.EmptyCheck())
            {
                currentProfile.MakeRootDirectory();
                currentProfile = currentProfile.LoadProfileWithPData();
                TList.ItemsSource = currentProfile.SetProfile.GetTickets;
            }

            if (currentProfile.EmptyCheck())
            {
                objNewProfileWindow = new ProfileWindow(true, this);
                currentProfile = new Profile();
                TList.ItemsSource = currentProfile.SetProfile.GetTickets;
                IsEnabled = false;
                objNewProfileWindow.Show();
            }

        }

        public Profile CurrentProfile 
        { 
            set 
            { 
                currentProfile = value; 
            }
            get
            {
                return currentProfile;
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            objNewProfileWindow?.Close();
            objRenameWindow?.Close();
            objRegenerateWindow?.Close();
            objSelectProfileWindow?.Close();
            objTicketValidatorWindow?.Close();
            objDeleteWindow?.Close();
            objSearchWindow?.Close();
            Close();
        }

        private void Sell_ListClick(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            if (cmd.DataContext is Ticket)
            {
                Ticket sell = (Ticket)cmd.DataContext;
                if (sell.Sold == false)
                {
                    sell.Sold = true;
                    sell.ButtonState = Visibility.Collapsed;
                    sell.ButtonStateInt = (int)sell.ButtonState;
                    var element = currentProfile.SetProfile.tickets.FindIndex(ch => ch.ID == sell.ID);
                    currentProfile.SetProfile.tickets[element] = sell;
                    TList.Items.Refresh();
                    currentProfile.SaveProfile();
                    Log.Text += DateTime.Now.Hour + ":" + DateTime.Now.Minute + " - The ticket \"" + sell.IDS + "\" is successfully sold!\n";

                }
                else if (sell.Sold == true)
                {
                    Log.Text += DateTime.Now.Hour + ":" + DateTime.Now.Minute + " - The ticket \"" + sell.IDS + "\" is already sold!\n";
                }
            }
        }


        public void NewProfileClick(object sender, RoutedEventArgs e)
        {
            objNewProfileWindow = new ProfileWindow();
            objNewProfileWindow.SetCreatingForm = this;
            IsEnabled = false;
            objNewProfileWindow.Show();
        }

        public void RegenerateTicketClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Regenerate all tickets in the current profile?\nThis will delete all current tickets.", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                objRegenerateWindow = new RegenerateWindow(currentProfile);
                objRegenerateWindow.SetMain = this;
                objRegenerateWindow.Show();
                IsEnabled = false;
            }
        }

        public void NewProfileChangesSet(Profile profile)
        {
            currentProfile = profile;
            TList.ItemsSource = profile.SetProfile.tickets;
            TList.Items.Refresh();
        }
        public void SelectProfileClick(object sender, RoutedEventArgs e)
        {
            objSelectProfileWindow = new SelectProfileWindow();
            objSelectProfileWindow.SetMain = this;
            IsEnabled = false;
            objSelectProfileWindow.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        protected void RenameProfileClick(object sender, RoutedEventArgs e)
        {
            objRenameWindow = new RenameWindow();
            objRenameWindow.SetCreatingForm = this;
            objRenameWindow.Show();
            IsEnabled = false;
        }

        protected void RunValidator(object sender, RoutedEventArgs e)
        {

        }

        protected void DeleteProfileClick(object sender, RoutedEventArgs e)
        {
            objDeleteWindow = new DeleteWindow();
            objDeleteWindow.SetMain = this;
            objDeleteWindow.Show();
            IsEnabled = false;
        }

        protected void ThemeDark(object sender, RoutedEventArgs e)
        {
            Theme(sender, e);
        }

        protected void ThemeWhite(object sender, RoutedEventArgs e)
        {
            Theme(sender, e);
        }

        protected void Theme(object sender, RoutedEventArgs e)
        {
            MenuItem cmd = (MenuItem)sender;
            theme = cmd.Header.ToString();
            switch (theme)
            {
                case "White":
                    this.Background = Brushes.White;
                    menu.Background = Brushes.White;
                    ValidatorBtn.Background = Brushes.WhiteSmoke;
                    TList.BorderBrush = Brushes.WhiteSmoke;
                    TList.Background = Brushes.WhiteSmoke;
                    Log.Background = Brushes.WhiteSmoke;
                    theme = "White";
                    break;
                case "Dark":
                    this.Background = Brushes.DimGray;
                    menu.Background = Brushes.DimGray;
                    ValidatorBtn.Background = Brushes.Gray;
                    TList.Background = Brushes.Gray;
                    TList.BorderBrush = Brushes.Gray;
                    Log.Background = Brushes.Gray;
                    theme = "Dark";
                    break;
                default:
                    theme = "White";
                    break;
            }
        }

        protected void ExitClick(object sender, RoutedEventArgs e)
        {
            OnClosed(e);
        }

        protected void SaveClick(object sender, RoutedEventArgs e)
        {

        }

        protected void TicketValidatorClick(object sender, RoutedEventArgs e)
        {
            objTicketValidatorWindow = new TicketValidatorWindow(this);
            objTicketValidatorWindow.Main = this;
            IsEnabled = false;
            objTicketValidatorWindow.Show();
            
        }

        private void Log_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        public void SaveAsClick(object sender, RoutedEventArgs e)
        {

        }

        protected void SearchTicketClick(object sender, RoutedEventArgs e)
        {
            objSearchWindow = new SearchWindow(this);
            IsEnabled = false;
            objSearchWindow.Show();
        }


    }
}
