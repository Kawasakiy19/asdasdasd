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
    /// Interaction logic for RegenerateWindow.xaml
    /// </summary>
    public partial class RegenerateWindow : Window
    {
        Profile pf;
        MainWindow main;
        public RegenerateWindow(Profile profile)
        {
            InitializeComponent();
            TType.Items.Add("Default");
            TType.Items.Add("6 number combination");
            TType.Items.Add("7 number combination");
            TType.Items.Add("8 number combination");
            TMax.Items.Add("Default");
            TMax.Items.Add("50");
            TMax.Items.Add("100");
            TMax.Items.Add("300");
            TMax.Items.Add("500");
            TMax.Items.Add("1000");
            TMax.Items.Add("3000");
            TMax.Items.Add("5000");
            TMax.Items.Add("Custom");
            TType.SelectedIndex = 0;
            TMax.SelectedIndex = 0;
            pf = profile;
        }

        public MainWindow SetMain
        {
            set
            {
                main = value;
            }
        }

        public RegenerateWindow GetMain
        {
            get
            {
                return this;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            main.IsEnabled = true;
            Close();
        }

        private void RegenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            int type = -1;
            int max = -1;
            switch (TType.SelectedIndex)
            {
                case 1:
                    type = 0;
                    break;
                case 2:
                    type = 1;
                    break;
                case 3:
                    type = 2;
                    break;
                default:
                    type = 0;
                    break;
            }
            switch (TMax.SelectedIndex)
            {
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
                        MessageBox.Show("The custom amount field is empty or it's input is not a number","Incorrect Format",MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                default:
                    max = 300;
                    break;
            }
            if (type >= 0 && max >= 0)
            {
                pf.SetProfile.GenerateTickets(type, max);
                pf.SaveProfile();
                MessageBox.Show(pf.SetProfile.tickets.Count().ToString() + " tickets was successfully regenerated.\n(type: " + pf.SetProfile.tickets[0].IDS.Length + " number combination)" , "Ticket regeneration", MessageBoxButton.OK, MessageBoxImage.Information);
                main.NewProfileChangesSet(pf);
                Close();
            }
            
        }

        private void TMax_DropDownClosed(object sender, EventArgs e)
        {
            if (TMax.SelectedIndex == 8)
            {
                customField.Visibility = Visibility.Visible;
                customText.Visibility = Visibility.Visible;
                Height = 128;
            }
            else
            {
                customField.Visibility = Visibility.Collapsed;
                customText.Visibility = Visibility.Collapsed;
                Height = 100;
            }
        }
    }
}
