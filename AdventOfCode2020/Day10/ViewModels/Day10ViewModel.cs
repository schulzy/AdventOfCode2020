﻿using Prism.Commands;
using Prism.Mvvm;

namespace Day10.ViewModels
{
    public class Day10ViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public Day10ViewModel()
        {
            Message = "View A from your Prism Module";
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
            _first ?? (_first = new DelegateCommand(FirstDay10));

        private DelegateCommand _second;
        public DelegateCommand Second =>
            _second ?? (_second = new DelegateCommand(SecondDay10));

        private void FirstDay10()
        {
            Result1 = "";
        }

        private void SecondDay10()
        {
            Result2 = "";
        }
    }
}
