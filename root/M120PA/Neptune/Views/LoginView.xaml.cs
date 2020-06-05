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
		List<User> _users = new List<User>();
		private readonly User InputUser = new User();
		public User LoggedInUser = new User();
		DataAccess db = new DataAccess();
		public LoginView()
		{
			InitializeComponent();
		}
		
		private void OnLoad(object sender, RoutedEventArgs e)
		{
			
			_users = db.GetUsers();
		}

		private void LoginButton_OnClick(object sender, RoutedEventArgs e)
		{
			InputUser.UserName = UserName.Text;
			InputUser.Password = Password.Password;

			var loginSuccess= db.GetUserByNameAndPassword(InputUser.UserName, InputUser.Password);
		}

		private void ExitButton_OnClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
