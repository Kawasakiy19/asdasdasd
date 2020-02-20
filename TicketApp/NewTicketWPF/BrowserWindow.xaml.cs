using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace NewTicketWPF
{
	public partial class SaveFileDialogSample : Window
	{
		MainWindow main;
		public SaveFileDialogSample()
		{
			InitializeComponent();
		}
		public MainWindow SetMain
		{
			set
			{
				main = value;
			}
			
		}
		public SaveFileDialogSample GetMain
		{
			get
			{
				return this;
			}

		}

		private void btnSaveFile_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == true)
				File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
		}
	}
}