using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void FirstDay9()
        {
        }

        public Day9ViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
