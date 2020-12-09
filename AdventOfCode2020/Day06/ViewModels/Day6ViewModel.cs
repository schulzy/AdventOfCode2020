using Day06.BL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.ViewModels
{
    public class Day6ViewModel : BindableBase
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
            _first ?? (_first = new DelegateCommand(FirstDay6));

        private DelegateCommand _second;
        public DelegateCommand Second =>
            _second ?? (_second = new DelegateCommand(SecondDay6));

        private void SecondDay6()
        {
            var groupManager = new GroupManager();
            groupManager.Init();
            Result2 = groupManager.GetAllCommonYesAnswerSum().ToString();
        }

        private void FirstDay6()
        {
            var groupManager = new GroupManager();
            groupManager.Init();
            Result1 = groupManager.GetAllAnswerSum().ToString();
        }

        public Day6ViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
