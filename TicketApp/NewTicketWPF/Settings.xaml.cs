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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        #region Field
        Window mainWindow;
        List<Profile> pf;
        Profile selectedProfile;
        PData pData;
        MainWindow main;
        #endregion

        #region Constructors
        public Settings()
        {
            InitializeComponent();
            pData = pData.LoadPData();
            pf = pf.LoadAllProfile();
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
            FillProfileBox();
            if (ProfileBox != null)
            {
                ProfileBox.SelectedIndex = 0;
            }
        }

        public Settings(MainWindow main)
        {
            InitializeComponent();
            pData = pData.LoadPData();
            pf = pf.LoadAllProfile();
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
            FillProfileBox();
            if (ProfileBox != null)
            {
                ProfileBox.SelectedIndex = 0;
            }
            this.main = main;
        }

        #endregion

        #region Properties
        public Window SetCreatingForm
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }
        #endregion

        #region Methods

        protected override void OnClosed(EventArgs e)
        {
            if (mainWindow == null)
            {
                mainWindow = new MainWindow();
            }
            mainWindow.IsEnabled = true;
            base.OnClosed(e);
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
                pf.Add(new Profile(ProfileInput.Text, type, max));
            }
            else
            {
                pf.Add(new Profile(DefaultProfileNamer(), type, max));
            }
            pf.Last().SaveProfile();
        }

        private void ProfileRename(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pf.Count() > 0 && RenameField.Text != "")
                {
                    selectedProfile = pf[ProfileBox.SelectedIndex];
                    selectedProfile.Delete(selectedProfile.ProfileName);
                    selectedProfile.ProfileName = RenameField.Text;
                    selectedProfile.SaveProfile();
                    selectedProfile.SavePData(ProfileBox.SelectedIndex);
                    RenameField.Text = "";
                }
                else if (RenameField.Text == "")
                {
                    MessageBox.Show("Give a name for the selected profile before renaming it!");
                }
                else if (pf.Count() == 0 || ProfileBox.SelectedIndex < 0)
                {
                    MessageBox.Show("There is no profile selected, please select a profile before renaming it.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RenameField_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key is Key.Return)
                {
                    if (RenameField.Text == "")
                    {
                        MessageBox.Show("Give a name for the selected profile before renaming it!");
                    }
                    if (pf.Count() > 0 && RenameField.Text != "")
                    {
                        selectedProfile = pf[ProfileBox.SelectedIndex];
                        selectedProfile.Delete(selectedProfile.ProfileName);
                        selectedProfile.ProfileName = RenameField.Text;
                        selectedProfile.SaveProfile();
                        selectedProfile.SavePData(ProfileBox.SelectedIndex);
                        RenameField.Text = "";
                    }
                    else if (pf.Count() == 0)
                    {
                        MessageBox.Show("There is no profile selected, please select a profile before renaming it.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        public void FillProfileBox()
        {
            foreach (var p in pf)
            {
                ProfileBox.Items.Add(p);
            }
        }

        protected void OK_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow == null)
            {
                mainWindow = new MainWindow();
            }
            selectedProfile = pf[ProfileBox.SelectedIndex];
            selectedProfile.SavePData(ProfileBox.SelectedIndex);
            mainWindow.IsEnabled = true;
            mainWindow.Show();
            Close();
        }

        protected void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow == null)
            {
                mainWindow = new MainWindow();
            }
            mainWindow.IsEnabled = true;
            Close();
        }

        protected void Apply_Click(object sender, RoutedEventArgs e)
        {
            selectedProfile = pf[ProfileBox.SelectedIndex];
            selectedProfile.SavePData(ProfileBox.SelectedIndex);
        }



        #endregion

    }
}
