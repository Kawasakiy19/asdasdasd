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
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        MainWindow mainWindow;
        List<Profile> pf;
        Profile selectedProfile;
        PData pData;

        public RenameWindow()
        {
            InitializeComponent();
            pf = pf.LoadAllProfile();
            pData = new PData();
            pData = pData.LoadPData();
            FillProfileBox();
            if (ProfileBox != null)
            {
                selectedProfile = selectedProfile.LoadSelectedProfile(pData);
                ProfileBox.SelectedIndex = pf.FindIndex(p => p.ProfileName == selectedProfile.ProfileName);
            }
        }

        public MainWindow SetCreatingForm
        {
            set
            {
                mainWindow = value;
            }
        }

        public MainWindow GetCreatingForm
        {
            get
            {
                return mainWindow;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            mainWindow.IsEnabled = true;
            base.OnClosed(e);
        }

        public void FillProfileBox()
        {
            foreach (var p in pf)
            {
                ProfileBox.Items.Add(p);
            }
        }

        private void ProfileRename(object sender, RoutedEventArgs e)
        {
            char[] format = { ' ', ',', '.',':','/','\\','*','?','\"','|' };
            try
            {
                if (RenameField.Text == "")
                {
                    MessageBox.Show("Give a name for the selected profile before renaming it!", "Incorrect parameter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (pf.Count() == 0 || ProfileBox.SelectedIndex < 0)
                {
                    MessageBox.Show("There is no profile selected, please select a profile before renaming it.", "Incorrect parameter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (!RenameField.Text.Savable())
                {
                    MessageBox.Show("The profile name cannot contain spaces and special characters\nlike: \",\\,:,.", "Incorrect parameter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (RenameField.Text.ProfileExists())
                {
                    MessageBox.Show("The profile name is already in use in another profile\nType in a different name.", "Profile already exists", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (pf.Count() > 0 && RenameField.Text != "" && !RenameField.Text.ProfileExists())
                {
                    selectedProfile = pf[ProfileBox.SelectedIndex];
                    selectedProfile.ReplaceProfile(RenameField.Text);
                    selectedProfile.ProfileName = RenameField.Text;
                    selectedProfile.SavePData(ProfileBox.SelectedIndex);
                    mainWindow.NewProfileChangesSet(selectedProfile);
                    RenameField.Text = "";
                    mainWindow.IsEnabled = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rename error",MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }

        
    }
}
