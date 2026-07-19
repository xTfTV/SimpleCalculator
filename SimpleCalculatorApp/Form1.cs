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
            //btnEquals.Click += NumberButton_Click;
            btnModulus.Click += NumberButton_Click;
            btnDivision.Click += NumberButton_Click;
            btnMultiplication.Click += NumberButton_Click;
            btnSubtraction.Click += NumberButton_Click;
            btnPlus.Click += NumberButton_Click;
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
    }
}