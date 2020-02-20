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
    /// Interaction logic for SelectProfileWindow.xaml
    /// </summary>
    public partial class SelectProfileWindow : Window
    {
        MainWindow main;
        List<Profile> pf;
        Profile selectedProfile;
        PData pData;
        public SelectProfileWindow()
        {
            InitializeComponent();
            pData = new PData();
            pf = pf.LoadAllProfile();
            FillProfileBox();
            ProfileBox.SelectedIndex = 0;
            pData = pData.LoadPData();
            if (ProfileBox != null)
            {
                selectedProfile = selectedProfile.LoadSelectedProfile(pData);
                ProfileBox.SelectedIndex = pf.FindIndex(p => p.ProfileName == selectedProfile.ProfileName);
            }
        }
        
        public MainWindow SetMain
        {
            set
            {
                main = value;
            }
        }

        protected void OkClick(object sender, RoutedEventArgs e)
        {
            main.NewProfileChangesSet(selectedProfile);
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            main.IsEnabled = true;
            Close();
        }
        protected void CancelClick(object sender, RoutedEventArgs e)
        {
            main.IsEnabled = true;
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
            selectedProfile.SavePData(ProfileBox.SelectedIndex);
        }
    }
}
