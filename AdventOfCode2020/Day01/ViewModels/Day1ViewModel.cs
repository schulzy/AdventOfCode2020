using Day01.BL;
using Prism.Commands;
using Prism.Mvvm;

namespace Day01.ViewModels
{
    public class Day1ViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _result1;
        private string _result2;

        public string Result1
        {
            get { return _result1; }
            set { SetProperty(ref _result1, value); }
        }

        public string Result2
        {
            get { return _result2; }
            set { SetProperty(ref _result2, value); }
        }

        private DelegateCommand _first;
        public DelegateCommand First =>
            _first ?? (_first = new DelegateCommand(FirstDay1));

        private DelegateCommand _second;
        public DelegateCommand Second =>
            _second ?? (_second = new DelegateCommand(SecondDay1));

        private void SecondDay1()
        {
            var data = new DataProcessor().GetData();
            var numberProcessor = new NumberProcessor(data);
            Result2 = numberProcessor.GetSecondResult().ToString();
        }

        void FirstDay1()
        {
            var data = new DataProcessor().GetData();
            var numberProcessor = new NumberProcessor(data);
            Result1 = numberProcessor.GetFirstResult().ToString();
        }

        public Day1ViewModel()
        {
            Message = "View A from your Prism Module";
            Result1 = "Waiting for the result";
            Result2 = "Waiting for the result";
        }
    }
}
