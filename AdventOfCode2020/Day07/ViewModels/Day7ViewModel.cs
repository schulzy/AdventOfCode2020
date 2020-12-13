using Day07.BL;
using Prism.Commands;
using Prism.Mvvm;

namespace Day07.ViewModels
{
    public class Day7ViewModel : BindableBase
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
            _first ?? (_first = new DelegateCommand(FirstDay7));

        private DelegateCommand _second;
        public DelegateCommand Second =>
            _second ?? (_second = new DelegateCommand(SecondDay7));

        private void SecondDay7()
        {
            BagManager manager = new BagManager();
            manager.Init();
            Result2 = manager.Calculate("shiny gold").ToString();
        }

        private void FirstDay7()
        {
            BagManager manager = new BagManager();
            manager.Init();
            Result1 = manager.CountOfBags("shiny gold").ToString();
        }

        public Day7ViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
