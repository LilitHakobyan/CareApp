using Care.Data.Models;
using System;

namespace Care.Data.DataViewModels
{
    public class Contract : EntityBase
    {
        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public int JobId { get; set; }

        public DateTime StartedDate { get; set; }

        public DateTime FinishedDate { get; set; }

        public double Price { get; set; }

        public bool Completed { get; set; }

        public bool Canceled { get; set; }

    }
}
