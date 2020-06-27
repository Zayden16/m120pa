using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectNeptune.Base;
using ProjectNeptune.View;

namespace ProjectNeptune.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private object _viewModel;

        public object ViewModel
        {
            get => _viewModel ?? (_viewModel = new StatisticViewModel());
            set
            {
                _viewModel = value;
                OnPropertyChange();
            }
        }

        public ICommand SatisticControlCommand => _statisticControlCommand ?? (_statisticControlCommand = new RelayCommand(OnStatisticControl));
        private ICommand _statisticControlCommand;
        private void OnStatisticControl(object sender)
        {
            if (ViewModel is StatisticViewModel)
            {
                return;
            }
            ViewModel = new StatisticViewModel();

        }

        public ICommand CarControlCommand => _carControlCommand ?? (_carControlCommand = new RelayCommand(OnCarControl));
        private ICommand _carControlCommand;
        private void OnCarControl(object sender)
        {
            if (ViewModel is CarViewModel)
            {
                return;
            }
            ViewModel = new CarViewModel();
        }
    }
}
