using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Core.Services;
using static TestTask.Core.Services.Enums;

namespace TestTask.Core.ViewModels
{
    public class AddTicketViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITicketService _ticketService;

        public AddTicketViewModel(IMvxNavigationService navigationService, ITicketService ticketService)
        {
            _navigationService = Mvx.Resolve<IMvxNavigationService>();
            _ticketService = ticketService;
            var priorities = new List<PriorityViewModel>();
            foreach (Priority priority in Enum.GetValues(typeof(Priority)))
            {
                var priorityViewModel = new PriorityViewModel(priority);
                priorities.Add(priorityViewModel);
            }
            Priorities = priorities;
        }

        private string _problemName = "";
        public string ProblemName
        {
            get { return _problemName; }
            set
            {
                _problemName = value;
                RaisePropertyChanged(() => ProblemName);
            }
        }

        private List<PriorityViewModel> _priorities;
        public List<PriorityViewModel> Priorities
        {
            get { return _priorities; }
            set
            {
                _priorities = value;
                RaisePropertyChanged(() => Priorities);
            }
        }


        private Priority _priority;
        public Priority PriorityVal
        {
            get { return _priority; }
            set
            {
                _priority = value;
                RaisePropertyChanged(() => PriorityVal);
            }
        }

        private MvxCommand<PriorityViewModel> _priorityClickedCommand;
        public ICommand PriorityClickedCommand
        {
            get
            {
                return _priorityClickedCommand = _priorityClickedCommand ??
                    new MvxCommand<PriorityViewModel>(priority => {
                        PriorityVal = priority.Priority;
                        Priorities.ForEach(m => m.IsVisible = false);
                        priority.IsVisible = true;
            }       );
            }
        }


        public IMvxAsyncCommand SaveCommand => new MvxAsyncCommand(DoSave);
        private async Task DoSave()
        {
            if (!Validate())
                return;
            Ticket ticket = new Ticket()
            {
                ProblemName = ProblemName,
                //Color = "#FF0000"
                Priority = PriorityVal
            };
            await _ticketService.Insert(ticket);
            Close(this);
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(ProblemName))
                return false;
            return true;
        }




    }
}
