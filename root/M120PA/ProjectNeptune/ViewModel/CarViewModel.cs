using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectNeptune;
using ProjectNeptune.Base;
using ProjectNeptune.Model;

namespace ProjectNeptune.ViewModel
{
    class CarViewModel : BaseViewModel
    {
        public ObservableCollection<Car> CarsCollection
        {
            get => _carsCollection;
            set
            {
                _carsCollection = value;
                OnPropertyChange();
            }
        }
        private ObservableCollection<Car> _carsCollection;

        private readonly Car _inputCar = new Car();
        public Car InputCar => _inputCar;

        public int InputCarCarId
        {
            get => _inputCar.CarId;
            set
            {
                if (_inputCar.CarId == value) return;
                _inputCar.CarId = value;
                OnPropertyChange("InputCarCarId");
                OnPropertyChange("InputCar");
            }
        }

        public string InputCarMarke
        {
            get => _inputCar.Marke;
            set
            {
                if (_inputCar.Marke == value) return;
                _inputCar.Marke = value;
                OnPropertyChange("InputCarMarke");
                OnPropertyChange("InputCar");
            }
        }

        public string InputCarModel
        {
            get => _inputCar.Model;
            set
            {
                if (_inputCar.Model == value) return;
                _inputCar.Model = value;
                OnPropertyChange("InputCarModel");
                OnPropertyChange("InputCar");
            }
        }

        public string InputCarFin
        {
            get => _inputCar.FIN;
            set
            {
                if (_inputCar.FIN == value) return;
                _inputCar.FIN = value;
                OnPropertyChange("InputCarFin");
                OnPropertyChange("InputCar");
            }
        }

        public string InputCarKennzeichen
        {
            get => _inputCar.Kennzeichen;
            set
            {
                if (_inputCar.Kennzeichen == value) return;
                _inputCar.Kennzeichen = value;
                OnPropertyChange("InputCarKennzeichen");
                OnPropertyChange("InputCar");
            }
        }


        public ICommand DataGridOnInsertCommand => _dataGridOnInsertCommand ?? (_dataGridOnInsertCommand= new RelayCommand(OnDataGridInsert));
        private ICommand _dataGridOnInsertCommand;
        private void OnDataGridInsert(object sender)
        {
              db.WriteCar(InputCar);
              CarsCollection = db.GetCars();
        }

        public CarViewModel()
        {
            _carsCollection = db.GetCars();
        }
    }
}
