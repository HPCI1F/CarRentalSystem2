using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class RentalHistory
    {
        [Key]
        public int Id { get; private set; }

        public int HistoryId { get; private set; }
        public Car Car { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public RentalHistory() { }

        public RentalHistory(int historyId, Car car, DateTime startDate, DateTime endDate)
        {
            HistoryId = historyId;
            Car = car;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

}
