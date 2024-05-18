using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private double _currentValue = 0;
        private double _previousValue = 0;
        private string _currentOperator = "";
        private bool _isNewValue = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_isNewValue)
                {
                    ResultTextBox.Text = "";
                    _isNewValue = false;
                }

                ResultTextBox.Text += button.Content.ToString();
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                _previousValue = double.Parse(ResultTextBox.Text);
                _currentOperator = button.Content.ToString();
                _isNewValue = true;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = double.Parse(ResultTextBox.Text);

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

            ResultTextBox.Text = _currentValue.ToString();
            _isNewValue = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = 0;
            _previousValue = 0;
            _currentOperator = "";
            ResultTextBox.Text = "";
        }

    }
}