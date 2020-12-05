using Day04.BL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04.ViewModels
{
    public class Day4ViewModel : BindableBase
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
            _first ?? (_first = new DelegateCommand(FirstDay4));

        private DelegateCommand _second;
        public DelegateCommand Second =>
            _second ?? (_second = new DelegateCommand(SecondDay4));

        private void SecondDay4()
        {
            DataProcessor dataProcessor = new DataProcessor();
            PassportManager passportManager = new PassportManager();
            foreach (var line in dataProcessor.GetData())
            {
                passportManager.AddLine(line);
            }

            Result2 = passportManager.StrictValid().ToString();
        }

        private void FirstDay4()
        {
            DataProcessor dataProcessor = new DataProcessor();
            PassportManager passportManager = new PassportManager();
            foreach (var line in dataProcessor.GetData())
            {
                passportManager.AddLine(line);
            }

            Result1 = passportManager.ValidCount().ToString();
        }

        public Day4ViewModel()
        {
            Message = "View A from your Prism Module";
            Result1 = "Waiting for the result";
            Result2 = "Waiting for the result";
        }
    }
}
