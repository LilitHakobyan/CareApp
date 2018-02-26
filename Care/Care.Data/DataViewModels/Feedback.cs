using Care.Data.Models;
using System;

namespace Care.Data.DataViewModels
{
    public class Feedback : EntityBase
    {
        public int UserId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
