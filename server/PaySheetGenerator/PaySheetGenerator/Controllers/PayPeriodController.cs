using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace PaySheetGenerator.Controllers
{
    public class PayPeriodController : ApiController
    {
        [HttpGet]
        public bool StartPayPeriod(int EmployeeID)
        {
            using (var db = new Models.DatabaseContext())
            {
                var payPeriod = db.PayPeriods.Where(p => p.Employee.ID == EmployeeID && p.TimeEnded == null);
                if (payPeriod.Count() > 0)
                {
                    payPeriod.First().TimeEnded = DateTime.UtcNow;
                }
                else
                {
                    db.PayPeriods.Add(new Models.PayPeriod()
                    {
                        Employee = db.Employees.First(e => e.ID == EmployeeID),
                        TimeStarted = DateTime.UtcNow
                    });

                }
                db.SaveChanges();
            }
            return true;
        }
    }
}
