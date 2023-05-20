using MauiAppCalculator.MVVM.ViewModels;

namespace MauiAppCalculator.MVVM.Views;

public partial class CalculatorView : ContentPage
{
    int currentState = 1;
    string operatorMath;
    double Num, Tot;
    CalculatorViewModel cvm = new CalculatorViewModel();
    public CalculatorView()
	{
		InitializeComponent();
        OnClear(this, null);
    }
    void OnClear(object sender, EventArgs e)
    {
        Tot = 0;
        Num = 0;
        currentState = 1;
        this.result.Text = "0";
        this.operations.Text = "";
    }

    void OnPercent(object sender, EventArgs e)
    {
        if (Tot == 0)
            return;
        Tot = Tot / 100;
        this.result.Text = Tot.ToString();
    }

    void OnDelete(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.result.Text))
        {
            try
            {
                if (this.result.Text.Length == 1)
                {
                    Num = 0;
                    this.result.Text = Num.ToString();
                    this.operations.Text = operations.Text.Remove(operations.Text.Length - 1);
                }
                else
                {
                    this.result.Text = result.Text.Remove(result.Text.Length - 1);
                    this.operations.Text = operations.Text.Remove(operations.Text.Length - 1);
                    Num = double.Parse(this.result.Text);
                }
            }
            catch
            { }
        }
    }
    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = string.Empty;
            if (currentState < 0)
                currentState *= -1;
        }

        this.result.Text += btnPressed;
        this.operations.Text += btnPressed;

        try
        {
            double number = double.Parse(this.result.Text);

            if (currentState == 1)
            {
                Tot = number;
                cvm.Tot = number;
            }
            else
            {
                Num = number;
                cvm.Num = number;
            }
        }
        catch
        { }
    }

    void OnOperator(object sender, EventArgs e)
    {
        OnCalculate(this, null);
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        this.operations.Text += btnPressed;
        operatorMath = btnPressed;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            var result = MVVM.Models.Calculate.DoCalculation(Tot, Num, operatorMath);
            //cvm.CalculateCommand();
            //this.result.Text = cvm.Resul.ToString();

            this.result.Text = result.ToString();
            Tot = result;
            currentState = -1;
        }
    }
}