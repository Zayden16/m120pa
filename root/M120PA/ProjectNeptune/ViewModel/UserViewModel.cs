using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectNeptune.Model;
using ProjectNeptune.View;

namespace ProjectNeptune.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        public List<User> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChange();
            }
        }
        private List<User> _usersList;

        public UserViewModel()
        {
            _usersList = db.GetUsers();
        }
    }
}
