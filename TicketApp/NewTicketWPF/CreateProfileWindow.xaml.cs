using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Interaction logic for CreateProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        Profile pf;
        MainWindow mainWindow;
        bool first;

        public ProfileWindow()
        {
            InitializeComponent();
            text.Text = "Create New Profile";
            TTypeCB.Items.Add("Default");
            TTypeCB.Items.Add("6 number combination");
            TTypeCB.Items.Add("7 number combination");
            TTypeCB.Items.Add("8 number combination");
            TTypeCB.SelectedIndex = 0;
            TMaximumAmount.Items.Add("Default");
            TMaximumAmount.Items.Add("50 Tickets");
            TMaximumAmount.Items.Add("100 Tickets");
            TMaximumAmount.Items.Add("300 Tickets");
            TMaximumAmount.Items.Add("500 Tickets");
            TMaximumAmount.Items.Add("1000 Tickets");
            TMaximumAmount.Items.Add("3000 Tickets");
            TMaximumAmount.Items.Add("5000 Tickets");
            TMaximumAmount.Items.Add("Custom");
            TMaximumAmount.SelectedIndex = 0;
            ShowInTaskbar = false;
        }

        public ProfileWindow(bool first, MainWindow main)
        {
            InitializeComponent();
            text.Text = "Create First Profile";
            this.first = first;
            TTypeCB.Items.Add("Default");
            TTypeCB.Items.Add("6 number combination");
            TTypeCB.Items.Add("7 number combination");
            TTypeCB.Items.Add("8 number combination");
            TTypeCB.SelectedIndex = 0;
            TMaximumAmount.Items.Add("Default");
            TMaximumAmount.Items.Add("50 Tickets");
            TMaximumAmount.Items.Add("100 Tickets");
            TMaximumAmount.Items.Add("300 Tickets");
            TMaximumAmount.Items.Add("500 Tickets");
            TMaximumAmount.Items.Add("1000 Tickets");
            TMaximumAmount.Items.Add("3000 Tickets");
            TMaximumAmount.Items.Add("5000 Tickets");
            TMaximumAmount.Items.Add("Custom");
            TMaximumAmount.SelectedIndex = 0;
            SetCreatingForm = main;
            mainWindow.Visibility = Visibility.Collapsed;
            ShowInTaskbar = true;
        }

        public MainWindow SetCreatingForm
        {
            set
            {
                mainWindow = value;
            }
        }
        public ProfileWindow GetCreatingForm
        {
            get
            {
                return this;
            }
        }

        private void CreateNewProfile(object sender, RoutedEventArgs e)
        {
            int type = 0;
            int max = 0;
            switch (TTypeCB.SelectedIndex)
            {
                case 0:
                    type = 0;
                    break;
                case 1:
                    type = 1;
                    break;
                case 2:
                    type = 0;
                    break;
                case 3:
                    type = 2;
                    break;
            }
            switch (TMaximumAmount.SelectedIndex)
            {
                case 0:
                    max = 300;
                    break;
                case 1:
                    max = 50;
                    break;
                case 2:
                    max = 100;
                    break;
                case 3:
                    max = 300;
                    break;
                case 4:
                    max = 500;
                    break;
                case 5:
                    max = 1000;
                    break;
                case 6:
                    max = 3000;
                    break;
                case 7:
                    max = 5000;
                    break;
                case 8:
                    if (int.TryParse(customField.Text, out int amount))
                    {
                        max = amount;
                    }
                    else
                    {
                        MessageBox.Show("The custom amount field is empty or it's input is not a number", "Incorrect Format", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
            }
            if (ProfileInput.Text != "")
            {
                pf = new Profile(ProfileInput.Text, type, max);
            }
            else
            {
                pf = new Profile(DefaultProfileNamer(), type, max);
            }
            mainWindow.NewProfileChangesSet(pf);
            mainWindow.IsEnabled = true;
            pf.SaveProfile();
            if (first)
            {
                pf.SavePData(0);
                first = false;
            }
            if (!first)
            {
                string[] fileCount = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Profiles");
                pf.SavePData(fileCount.Length - 1);
            }
            if (!first.ProfileExists())
            {
                Close();
            }
        }

        public string DefaultProfileNamer()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\Profiles\\Profile";
                string defName = "Profile";
                for (int i = 1; i < 100; i++)
                {
                    path = Directory.GetCurrentDirectory() + "\\Profiles\\Profile" + i.ToString() + ".csv";
                    defName = defName + i.ToString();
                    if (File.Exists(path))
                    {
                        defName = defName.Substring(0,7);
                        continue;
                    }
                    return defName;
                }
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("Maximum profiles reached (\"100 Profiles\").");
                return null;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                if (first)
                {
                    var result = MessageBox.Show("You must create your first profile!\nThe \\Profiles folder is empty", "No tickets", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.OK)
                    {
                        ProfileWindow again = new ProfileWindow(first.ProfileExists(), mainWindow);
                        again.Show();
                    }
                    if ((int)result == 2 || (int)result == 0)
                    {
                        mainWindow.Close();
                    }

                }
                if (!first.ProfileExists())
                {
                    mainWindow.Visibility = Visibility.Visible;
                    mainWindow.IsEnabled = true;
                    base.OnClosed(e);
                }
            }
            catch(Exception)
            {
                Close();
            }
        }

        private void TMaximumAmount_DropDownClosed(object sender, EventArgs e)
        {
            if (TMaximumAmount.SelectedIndex == 8)
            {
                customField.Visibility = Visibility.Visible;
                customText.Visibility = Visibility.Visible;
                Height = 205;
            }
            else
            {
                customField.Visibility = Visibility.Collapsed;
                customText.Visibility = Visibility.Collapsed;
                Height = 170;
            }
        }
    }
}
