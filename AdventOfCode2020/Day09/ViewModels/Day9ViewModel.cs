using Day09.BL;
using Prism.Commands;
using Prism.Mvvm;

namespace Day09.ViewModels
{
    public class Day9ViewModel : BindableBase
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
            _first ?? (_first = new DelegateCommand(FirstDay9));

        private DelegateCommand _second;
        public DelegateCommand Second =>
            _second ?? (_second = new DelegateCommand(SecondDay9));

        private void SecondDay9()
        {
            var encoder = new Encoder();
            encoder.Init(25);
            Result2 = encoder.GetContiguousMinMaxSum().ToString();
        }

        private void FirstDay9()
        {
            var encoder = new Encoder();
            encoder.Init(25);
            Result1 =  encoder.GetInvalidCode().ToString();
        }

        public Day9ViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
