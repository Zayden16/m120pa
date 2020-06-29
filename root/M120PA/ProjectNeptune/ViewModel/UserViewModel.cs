using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using ProjectNeptune.Base;
using ProjectNeptune.Model;
using ProjectNeptune.View;

namespace ProjectNeptune.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        public ObservableCollection<User> UsersCollection
        {
            get => _usersCollection??(_usersCollection = new ObservableCollection<User>());
            set
            {
                _usersCollection = value;
                OnPropertyChange();
            }
        }
        private ObservableCollection<User> _usersCollection;


        private readonly User _inputUser = new User();
        public User InputUser => _inputUser;

        public string InputUserUserName
        {
            get => _inputUser.UserName;
            set
            {
                if (_inputUser.UserName == value) return;
                _inputUser.UserName = value;
                OnPropertyChange("InputUser");
                OnPropertyChange("InputUserUserName");
            }
        }
        public string InputUserPassword
        {
            get => _inputUser.Password;
            set
            {
                if (_inputUser.Password == value) return;
                _inputUser.Password = value;
                OnPropertyChange("InputUser");
                OnPropertyChange("InputUserPassword");
            }
        }

        public ICommand DataGridOnInsertCommand => _dataGridOnInsertCommand ?? (_dataGridOnInsertCommand = new RelayCommand(OnDataGridInsert));
        private ICommand _dataGridOnInsertCommand;
        private void OnDataGridInsert(object sender)
        {
            db.WriteUser(InputUser);
            UsersCollection = db.GetUsers();
        }

        public UserViewModel()
        {
            UsersCollection = db.GetUsers();
        }
    }
}
