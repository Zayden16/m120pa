using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProjectNeptune.Base;
using ProjectNeptune.Model;
using ProjectNeptune.View;

namespace ProjectNeptune.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        #region Properties

        private User _inputUser = new User();
        public User InputUser => _inputUser;

        public string InputUserUsername
        {
            get => _inputUser.UserName;
            set
            {
                if (_inputUser.UserName == value) return;
                _inputUser.UserName = value;
                OnPropertyChange("InputUserUsername");
                OnPropertyChange("InputUser");
            }
        }

        public string InputUserPassword
        {
            get => _inputUser.Password;
            set
            {
                if (_inputUser.Password == value) return;
                _inputUser.Password = value;
                OnPropertyChange("InputUserPassword");
                OnPropertyChange("InputUser");
            }
        }

        public Action CloseAction { get; set; }

        #endregion

        #region Commands

        private ICommand _exitCommand;
        public ICommand ExitCommand => _exitCommand ?? (_exitCommand = new RelayCommand(OnExitCommand));
         
        private void OnExitCommand(object sender)
        {
            CloseAction();
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(OnLoginCommand));

        private void OnLoginCommand(object sender)
        {
            var authdUser = db.GetUserByNameAndPassword(_inputUser.UserName, _inputUser.Password);
            if (authdUser.UserId != 0)
            {
                var view = new MainView();
                view.Show();
                CloseAction();
            }
        }

        #endregion
    }
}
