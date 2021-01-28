using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Services
{
    class TicketService : ITicketService
    {
        private readonly SQLiteAsyncConnection _connection;

        public TicketService(ISqliteConnectionService service)
        {
            _connection = service.GetAsyncConnection();
            //_connection.DropTableAsync<Ticket>();
            _connection.CreateTableAsync<Ticket>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK);
        }

        public async Task Delete(Ticket ticket)
        {
            await _connection.DeleteAsync(ticket);
        }

        public async Task<int> Insert(Ticket ticket)
        {
            return await _connection.InsertAsync(ticket);
        }

        public async Task<List<Ticket>> GetTickets()
        {
            return await _connection.Table<Ticket>().ToListAsync();
        }

        public async Task<List<Ticket>> TicketsMatching(string nameFilter)
        {
            return await _connection.Table<Ticket>()
                                    .OrderBy(x => x.Id)
                                    .Where(x => x.ProblemName.ToLower().Contains(nameFilter))
                                    .ToListAsync();
        }

        public async Task Update(Ticket ticket)
        {
            await _connection.UpdateAsync(ticket);
        }
    }
}
