using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static TestTask.Core.Services.Enums;

namespace TestTask.Core.Services
{
    public class Ticket
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string ProblemName { get; set; }
        //public string Color { get; set; }
        public Priority Priority { get; set; }
    }
}
