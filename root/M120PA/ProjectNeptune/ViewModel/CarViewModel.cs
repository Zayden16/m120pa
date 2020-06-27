using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectNeptune;
using ProjectNeptune.Model;

namespace ProjectNeptune.ViewModel
{
    class CarViewModel : BaseViewModel
    {
        public List<Car> CarsList
        {
            get => _carsList;
            set
            {
                _carsList = value;
                OnPropertyChange();
            }
        }
        private List<Car> _carsList;

        public CarViewModel()
        {
            _carsList = db.GetCars();
        }
    }
}
