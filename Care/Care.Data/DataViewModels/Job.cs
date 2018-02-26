using Care.Data.Enums;
using Care.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Care.Data.DataViewModels
{
    public class Job : EntityBase
    {
        public Job()
        {
            Feedbacks = new ObservableCollection<Feedback>(new BaseRepository<Feedback>().GetAll());
            Proposals = new ObservableCollection<Proposal>(new BaseRepository<Proposal>().GetAll());
        }

        public int UserId { get; set; }

        public CareTypesEnum CareType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double? Price { get; set; }

        public string Description { get; set; }

        public bool? Assigned { get; set; }

        public virtual ICollection<Proposal> Proposals{ get; set; }

        public virtual ICollection<Feedback> Feedbacks{ get; set; }

    }
}