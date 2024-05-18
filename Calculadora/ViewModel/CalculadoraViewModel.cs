using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace Calculadora.ViewModel
{
    public class CalculadoraViewModel : ViewModelBase
    {
        #region Propieadades
        private double _currentValue = 0;
        private double _previousValue = 0;
        private string _currentOperator = "";
        private bool _isNewValue = false;


        private string _Result;
        public string Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                OnPropertyChanged(nameof(Result));
            }
        }




        #endregion

        #region Commandos

        public RelayCommand ClearCommand { get; }
        public RelayCommand<string> PressNumberCommand { get; }


        #endregion

        public CalculadoraViewModel()
        {
            ClearCommand = new RelayCommand(Clear);
            PressNumberCommand = new RelayCommand<string>((s) => PressNumber(s));

        }

        #region MetodosPrivados
        private void Clear()
        {
            _currentValue = 0;
            _previousValue = 0;
            _currentOperator = "";
            Result = "";           
        }

        private void PressNumber(string number)
        {
            
                if (_isNewValue)
                {
                    Result = "";
                    _isNewValue = false;
                }
            Result += number;

        }


        #endregion
    }
}
