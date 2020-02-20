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
    public partial class CreateProfileWindow : Window
    {
        Profile pf;
        MainWindow mainWindow;

        public CreateProfileWindow()
        {
            InitializeComponent();
            pf = new Profile();
            Window v = new Window();
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
        }

        public MainWindow SetCreatingForm
        {
            set
            {
                mainWindow = value;
            }
        }
        public CreateProfileWindow GetCreatingForm
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
                    type = 3;
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
            Close();
        }

        public string DefaultProfileNamer()
        {
            try
            {
                string init = "Profiles\\Profile";
                for (int i = 1; i < 100; i++)
                {
                    init += i.ToString() + ".csv";
                    if (File.Exists(init))
                    {
                        init = "Profiles\\Profile";
                        continue;
                    }
                    return init;
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
            mainWindow.NewProfileChangesSet(pf);
            mainWindow.IsEnabled = true;
            base.OnClosed(e);
        }
    }
}
