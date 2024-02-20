using System.Collections;
using System.Data;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace WorkplaceApp.backend
{
    public class Workplace
    {
        public static List<Worker> Workers = [
            new Worker(1, "Jan Kowalski", new DateTime(2002, 3, 4), "pracownik fizyczny", 18.5m, 0m),
            new Worker(2, "Agnieszka Kowalska", new DateTime(1973, 12, 15), "urzędnik", 0m, 2800m),
            new Worker(3, "Robert Lewandowski", new DateTime(1980, 5, 23), "pracownik fizyczny", 29m, 0m),
            new Worker(4, "Zofia Plucińska", new DateTime(1998, 11, 2), "urzędnik", 0m, 4750m),
            new Worker(5, "Grzegorz Braunowiec", new DateTime(1960, 1, 29), "pracownik fizyczny", 48m, 0m)
        ];


        public static List<decimal> CalculateSalary(Worker Worker, int WorkedDays, decimal Bonus)
        {
            decimal BruttoPayment;
            if (Worker.Position == "pracownik fizyczny")
            {
                BruttoPayment = Worker.HourlyPay * WorkedDays * 8 + Bonus;
            }
            else
            {
                BruttoPayment = Worker.MonthlyPay + Bonus;
                if (WorkedDays != 20)
                {
                    BruttoPayment = 0.8m * Worker.MonthlyPay + Bonus;
                }
            }

            int WorkersAge = DateTime.Now.Year - Worker.BirthDate.Year;
            decimal Taxes = 0m;
            if (WorkersAge > 26)
            {
                Taxes = BruttoPayment * 0.18m;
            }
            decimal NettoPayment = BruttoPayment - Taxes;
            return [BruttoPayment, Taxes, NettoPayment];
        }
    }
}
