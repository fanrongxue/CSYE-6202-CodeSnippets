#region Using Directives

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

#endregion

namespace LogonScreenApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void HandleSupermanMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{			
			var uriSource = new Uri(@"/LogonScreenApp;component/images/SupermanPowerStats.png", UriKind.Relative);
			SuperStatsImage.Source = new BitmapImage(uriSource);
    }

		private void HandleInvisibleWomanMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var uriSource = new Uri(@"/LogonScreenApp;component/images/InvisibleWomanPowerStats.png", UriKind.Relative);
			SuperStatsImage.Source = new BitmapImage(uriSource);
		}

		private void HandleHulkMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var uriSource = new Uri(@"/LogonScreenApp;component/images/HulkPowerStats.png", UriKind.Relative);
			SuperStatsImage.Source = new BitmapImage(uriSource);
		}

		private void HandleIronmanMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var uriSource = new Uri(@"/LogonScreenApp;component/images/IronmanPowerStats.png", UriKind.Relative);
			SuperStatsImage.Source = new BitmapImage(uriSource);
		}
	}
}
