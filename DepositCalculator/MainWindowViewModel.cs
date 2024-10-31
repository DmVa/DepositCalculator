using DepositCalculator.Calculator;
using DepositCalculator.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator
{
    public class MainWindowViewModel : BasePropertyChanged
    {
        private int _term;
        private int _selectedCurrencyIndex;
        private decimal _amount;
        private decimal _rate;
        private string _interestFromattedString = string.Empty;
        private bool _isCapitalization;
        private bool _isMonthly;

        private List<DisplayCalcResult> _calcResults = new List<DisplayCalcResult>();
        private readonly string[] _supportedCurrencies = new string[3] { "de-EU", "en-US", "uk-UA" }; // have to correspond to xaml.

        public int Term
        {
            get { return _term; }
            set
            {
                _term = value;
                NotifyPropertyChanged();
            }
        }

        public int SelectedCurrencyIndex
        {
            get { return _selectedCurrencyIndex; }
            set
            {
                _selectedCurrencyIndex = value;
                NotifyPropertyChanged();
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                NotifyPropertyChanged();
            }
        }
        public decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsCapitalization
        {
            get { return _isCapitalization; }
            set
            {
                _isCapitalization = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsMonthly
        {
            get { return _isMonthly; }
            set
            {
                _isMonthly = value;
                NotifyPropertyChanged();
            }
        }

        public List<DisplayCalcResult> CalcResults
        {
            get { return _calcResults; }
            set
            {
                _calcResults = value;
                NotifyPropertyChanged();
            }
        }
        public string InterestFromattedString
        {
            get { return _interestFromattedString; }
            set
            {
                _interestFromattedString = value;
                NotifyPropertyChanged();
            }
        }

        public BaseCommand CalcInterest { get; }
        public class DisplayCalcResult
        {
            public string? LineNumber { get; set; }
            public string? Deposit { get; set; }
            public string? Interest { get; set; }
        }

        public MainWindowViewModel()
        {
            CalcInterest = new BaseCommand(CalcInterestAction, CalcInterestCanExecute);
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            Amount = 1000;
            Term = 12;
            Rate = 0.05m;
            InterestFromattedString = "";
            SelectedCurrencyIndex = 0;
            IsMonthly = true;
        }

        private bool CalcInterestCanExecute()
        {
            return Amount > 0 && Term > 0;
        }

        private async Task CalcInterestAction()
        {
            InterestPayType payType = GetPayType();
            CalcResults.Clear();
            var calulator = CalculatorFactoty.Instance.CreateCalculator(payType);
            var calcResult = await calulator.Calc(Amount, Term, Rate);
            SetCalcResults(calcResult.Details);

            var culture = GetCulture();
            InterestFromattedString = calcResult.Interest.ToString("C", culture);
        }

        private void SetCalcResults(IEnumerable<Calculator.CalcDetailLine> results)
        {
            CalcResults.Clear();
            List<DisplayCalcResult> newResults = new List<DisplayCalcResult>();
            int lineNumber = 1;
            foreach (var result in results)
            {
                DisplayCalcResult display = new DisplayCalcResult
                {
                    LineNumber = lineNumber.ToString(),
                    Deposit = result.InitialFunded.ToString("0.00"),
                    Interest = (result.ToCapitalization + result.ToChekout).ToString("0.00"),
                };

                lineNumber++;
                newResults.Add(display);
            }

            CalcResults = newResults;
        }

        private IFormatProvider GetCulture()
        {
            var culture = _supportedCurrencies[SelectedCurrencyIndex];
            return CultureInfo.CreateSpecificCulture(culture);
        }

        private InterestPayType GetPayType()
        {
            if ((IsCapitalization && IsMonthly) || !(IsCapitalization || IsMonthly))
                throw new InvalidOperationException();

            return IsMonthly ? InterestPayType.Monthly : InterestPayType.Capitalization;
        }
    }
}
  

