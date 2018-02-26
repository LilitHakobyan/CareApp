using Care.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Data
{
    public class Proposal : EntityBase
    {
        public int UserId { get; set; }
        public string Message { get; set; }

    }
}
