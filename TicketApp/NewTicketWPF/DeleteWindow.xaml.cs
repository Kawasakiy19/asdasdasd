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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        MainWindow main;
        List<Profile> pf;
        Profile selectedProfile;
        bool empty;
        public DeleteWindow()
        {
            InitializeComponent();
            empty = false;
            pf = pf.LoadAllProfile();
            FillProfileBox();
            ProfileBox.SelectedIndex = 0;
        }

        public MainWindow SetMain
        {
            set
            {
                main = value;
            }
        }
        public void FillProfileBox()
        {
            foreach (var p in pf)
            {
                ProfileBox.Items.Add(p);
            }
        }

        protected void CancelClick(object sender, RoutedEventArgs e)
        {
            main.IsEnabled = true;
            Close();
        }

        protected void DeleteClick(object sender, RoutedEventArgs e)
        {
            bool deleted = false;
            selectedProfile = pf[ProfileBox.SelectedIndex];
            pf = pf.LoadAllProfile();
            if (pf.Count() > 1)
            {
                pf.Remove(pf[ProfileBox.SelectedIndex]);
                selectedProfile.Delete(selectedProfile.ProfileName);
                ProfileBox.Items.Clear();
                FillProfileBox();
                ProfileBox.Items.Refresh();
                ProfileBox.SelectedIndex = 0;
                pf[0].SavePData(0);
                deleted = true;
            }
            if (pf.Count() == 1 && deleted == false)
            {
                pf.Remove(pf[ProfileBox.SelectedIndex]);
                selectedProfile.Delete(selectedProfile.ProfileName);
                ProfileWindow again = new ProfileWindow(true, main);
                MessageBox.Show("Profiles are empty, you must create a profile to continue.", "no profiles found", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                again.Show();
                empty = true;
                Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (empty)
            {
                main.IsEnabled = false;
            }
            if (!empty)
            {
                main.IsEnabled = true;
                base.OnClosed(e);
            }
        }

        private void ProfileBox_DropDownClosed(object sender, EventArgs e)
        {
            selectedProfile = pf[ProfileBox.SelectedIndex];
            ProfileBox.Items.Refresh();
        }
    }
}
