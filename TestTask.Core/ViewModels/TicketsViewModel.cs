using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Services;

namespace TestTask.Core.ViewModels
{
    public class TicketsViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITicketService _ticketService;

        private List<Ticket> _tickets;
        public string Color { get; set; }
        public TicketsViewModel(ITicketService ticketService)
        {
            _navigationService = Mvx.Resolve<IMvxNavigationService>();
            _ticketService = ticketService;
            //Color = Color.FromArgb(255, 0, 0);
            Color = "#ff0000";
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await UpdateTickets();
        }

        public async Task UpdateTickets()
        {
            Tickets = await _ticketService.GetTickets();
        }

        public List<Ticket> Tickets
        {
            get { return _tickets; }
            set
            {
                _tickets = value;
                RaisePropertyChanged(() => Tickets);
            }
        }

        private string _searchQuery = "";
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                Action filter = async () =>
                {
                    if (_searchQuery.Length >= 3)
                        await FilterTickets(_searchQuery);
                    else
                        await UpdateTickets();
                };

                _searchQuery = value;
                filter();
                RaisePropertyChanged(() => Tickets);
                RaisePropertyChanged(() => SearchQuery);
            }
        }

        private async Task FilterTickets(string filterStr)
        {
            Tickets = await _ticketService.TicketsMatching(filterStr);
        }




        public IMvxAsyncCommand NavigateToAddTicketCommand => new MvxAsyncCommand(NavigateToAddTicket);
        private async Task NavigateToAddTicket()
        {
            await _navigationService.Navigate<AddTicketViewModel>();
        }

        //private string _text = "Hello MvvmCross";
        //public string Text
        //{
        //    get { return _text; }
        //    set { SetProperty(ref _text, value); }
        //}
    }
}
