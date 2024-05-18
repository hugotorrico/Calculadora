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
        private double _currentValue = 0;
        private double _previousValue = 0;
        private string _currentOperator = "";
        private bool _isNewValue = false;

        #region Propieadades


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
        public RelayCommand PressEqualsCommand { get; }
        public RelayCommand<string> PressNumberCommand { get; }

        public RelayCommand<string> PressOperatorCommand { get; }

        #endregion

        public CalculadoraViewModel()
        {

            //=> Expresiones Lambda, Funciones Flecha
            PressEqualsCommand = new RelayCommand(PressEquals);
            ClearCommand = new RelayCommand(Clear);
            PressNumberCommand = new RelayCommand<string>((s) => PressNumber(s));
            PressOperatorCommand= new RelayCommand<string>((s)=> PressOperator(s));
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

        private void PressOperator(string operator1)
        {
            
                _previousValue = double.Parse(Result);
                _currentOperator = operator1;
                _isNewValue = true;
           
        }

        private void PressEquals()
        {
            _currentValue = double.Parse(Result);

            switch (_currentOperator)
            {
                case "+":
                    _currentValue = _previousValue + _currentValue;
                    break;
                case "-":
                    _currentValue = _previousValue - _currentValue;
                    break;
                case "*":
                    _currentValue = _previousValue * _currentValue;
                    break;
                case "/":
                    if (_currentValue != 0)
                    {
                        _currentValue = _previousValue / _currentValue;
                    }
                    else
                    {
                        MessageBox.Show("Division by zero is not allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        _currentValue = 0;
                    }
                    break;
            }

            Result = _currentValue.ToString();
            _isNewValue = true;
        }



        #endregion
    }
}
