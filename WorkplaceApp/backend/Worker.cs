using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace WorkplaceApp.backend
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Position { get; set; } = "";
        public decimal HourlyPay { get; set; }
        public decimal MonthlyPay { get; set; }

        public Worker(
            int id,
            string name,
            DateTime birthdate,
            string position,
            decimal hourlyPay,
            decimal monthlyPay
        )
        {
            Id = id;
            Name = name;
            BirthDate = birthdate;
            Position = position;
            HourlyPay = hourlyPay;
            MonthlyPay = monthlyPay;
        }
    }
}
