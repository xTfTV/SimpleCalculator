using System.Runtime.CompilerServices;

namespace SimpleCalculatorApp
{
    public partial class simpleCalculator : Form
    {
        private string _currentInput = "";
        private string _expression = "";

        public simpleCalculator()
        {
            InitializeComponent();

            // Adding the Click Functionality
            btnBackspace.Click += BackspaceButton_Click;
            btnAC.Click += ClearButton_Click;
            btnEquals.Click += EqualsButton_Click;
            btnModulus.Click += NumberButton_Click;
            btnDivision.Click += NumberButton_Click;
            btnMultiplication.Click += NumberButton_Click;
            btnSubtraction.Click += NumberButton_Click;
            btnPlus.Click += OperatorButton_Click;
            btnSeven.Click += NumberButton_Click;
            btnEight.Click += NumberButton_Click;
            btnNine.Click += NumberButton_Click;
            btnFour.Click += NumberButton_Click;
            btnFive.Click += NumberButton_Click;
            btnSix.Click += NumberButton_Click;
            btnOne.Click += NumberButton_Click;
            btnTwo.Click += NumberButton_Click;
            btnThree.Click += NumberButton_Click;
            btnZero.Click += NumberButton_Click;
            btnDecimal.Click += NumberButton_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Method to handle button clicks appearing in the label
        private void NumberButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }
            _currentInput += button.Text;
            lblValInput.Text = _expression + _currentInput;
        }
        // Method for the all clear button
        private void ResetCalculatorState()
        {
            _expression = "";
            _currentInput = "";
        }
        private void ClearButton_Click(object? sender, EventArgs e)
        {
            ResetCalculatorState();
            lblValInput.Text = "0";
        }

        // Method for the backspace button
        private void BackspaceButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentInput))
            {
                return;
            }

            _currentInput = _currentInput[..^1];

            if (string.IsNullOrEmpty(_currentInput))
            {
                lblValInput.Text = "0";
            }
            else
            {
                lblValInput.Text = _expression + _currentInput;
            }
        }

        // Connect +, -, x and ÷ to this event.
        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentInput))
            {
                return;
            }

            // Save the first entered number.
            if (!decimal.TryParse(_currentInput, out _firstNumber))
            {
                lblValInput.Text = "Error: Incorrect Format";
                return;
            }

            // Save the selected operator.
            _operation = button.Text;

            // Build the visible expression.
            _expression = $"{_currentInput} {_operation} ";

            // Clear this so the next number becomes the second number.
            _currentInput = "";

            lblValInput.Text = _expression;
        }

        // Method for the calculation
        private string _operation = "";
        private decimal _firstNumber;
        private decimal _secondNumber;

        private void EqualsButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentInput))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(_operation))
            {
                lblValInput.Text = "Error: Select an operation";
                return;
            }


            if (!decimal.TryParse(_currentInput, out _secondNumber))
            {
                lblValInput.Text = "Error: Incorrect Format";
                return;
            }

            decimal result;

            switch (_operation)
            {
                case "+":
                    result = _firstNumber + _secondNumber;
                    break;

                case "-":
                    result = _firstNumber - _secondNumber;
                    break;

                case "x":
                case "×":
                    result = _firstNumber * _secondNumber;
                    break;

                case "÷":
                    if (_secondNumber == 0)
                    {
                        lblValInput.Text = "Cannot divide by zero";
                        return;
                    }

                    result = _firstNumber / _secondNumber;
                    break;

                default:
                    lblValInput.Text = "Error: Unknown operation";
                    return;
            }

            lblValInput.Text =
                $"{_expression}{_currentInput} = {result}";


            _currentInput = result.ToString();
            _expression = "";
            _operation = "";
            _firstNumber = 0;
            _secondNumber = 0;
        }

    }
}