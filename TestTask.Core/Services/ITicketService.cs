using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> TicketsMatching(string nameFilter);
        Task<List<Ticket>> GetTickets();
        Task<int> Insert(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
    }
}
