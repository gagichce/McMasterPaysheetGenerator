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
        [HttpPost]
        public bool StartPayPeriod(int EmployeeID)
        {
            using (var db = new Models.DatabaseContext())
            {
                var selectedEmployee = db.Employees.First(e => e.ID == EmployeeID);
                if (selectedEmployee == null)
                    throw new Models.UserException("Employee was not found", 404, Models.BaseException.Cause.NotFound);
                db.PayPeriods.Add(new Models.PayPeriod()
                {
                    Employee = selectedEmployee,
                    TimeStarted = DateTime.UtcNow
                });

                db.SaveChanges();
            }
            return true;
        }

        [HttpPost]
        public bool EndPayPeriod(int EmployeeID, string Desc)
        {
            using (var db = new Models.DatabaseContext())
            {

            }
            return true;
        }
    }
}
