using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using System;
using System.Collections.Generic;
using System.Text;
using static TestTask.Core.Services.Enums;

namespace TestTask.Core.ViewModels
{
    public class PriorityViewModel : MvxViewModel
    {
        public string Name { get; set; }
        public Priority Priority { get; set; }


        public PriorityViewModel(Priority priority)
        {
            Priority = priority;
            Name = priority.ToString();
        }


        private bool _isVisible = false;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged(() => IsVisible);
            }
        }
    }
}
