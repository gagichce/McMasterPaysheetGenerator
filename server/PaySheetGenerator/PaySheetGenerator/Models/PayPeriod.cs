using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace PaySheetGenerator.Models
{
    public class PayPeriod
    {
        public int ID { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }
        public DateTime? TimeClaimed { get; set; }
        public DateTime? TimePaid { get; set; }
        public string Accomplished { get; set; }
        public string Notes { get; set; }
        public virtual Employee Employee { get; set; }
        public PayPeriod()
        {
            this.TimeStarted = DateTime.UtcNow;
        }
    }
}