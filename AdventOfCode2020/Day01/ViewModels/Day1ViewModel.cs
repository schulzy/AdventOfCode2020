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

        public Day1ViewModel()
        {
            Message = "View A from your Prism Module";
            Result1 = "Waiting for the result";
            Result2 = "Waiting for the result";
        }
    }
}
