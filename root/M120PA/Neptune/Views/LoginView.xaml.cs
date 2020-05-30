using System;
using System.Collections.Generic;
using System.Linq;
using System.Deployment;
using System.Reflection;
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
using Neptune.Models;

namespace Neptune.Views
{
	/// <summary>
	/// Interaction logic for LoginView.xaml
	/// </summary>
	public partial class LoginView : Window
	{
		List<User> users = new List<User>();
		private User _inputUser;

		public LoginView()
		{
			InitializeComponent();
		}
		
		private void OnLoad(object sender, RoutedEventArgs e)
		{
			DataAccess db = new DataAccess();
			users = db.GetUsers();
		}

		private void LoginButton_OnClick(object sender, RoutedEventArgs e)
		{
			_inputUser.UserName = UserName.Text;
			_inputUser.Password = Password.Password;

			if (users.Contains(_inputUser))
			{

			}
			else
			{
				throw new Exception("User not found");
			}
		}

		private void ExitButton_OnClick(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
	}
}
