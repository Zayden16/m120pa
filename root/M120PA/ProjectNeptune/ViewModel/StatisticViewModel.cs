using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNeptune.ViewModel
{
    public class StatisticViewModel : BaseViewModel
    {
        public int NumberOfUsers
        {
            get => _numberOfUsers;
            set
            {
                _numberOfUsers = value;
                OnPropertyChange();
            }
        }
        private int _numberOfUsers;

        public int NumberOfCars
        {
            get => _numberOfCars;
            set
            {
                _numberOfCars = value;
                OnPropertyChange();
            }
        }
        private int _numberOfCars;

        public string MostPopularMake
        {
            get => _mostPopularMake;
            set
            {
                _mostPopularMake = value;
                OnPropertyChange();
            }
        }
        private string _mostPopularMake;

        public string MostPopularModel
        {
            get => _mostPopularModel;
            set
            {
                _mostPopularModel = value;
                OnPropertyChange();
            }
        }
        private string _mostPopularModel;

        public StatisticViewModel()
        {
            NumberOfUsers = db.CountUsers();
            NumberOfCars = db.CountCars();
            MostPopularMake = db.GetMostPopularMake();
            MostPopularModel = db.GetMostPopularModel();
        }
    }
}
