using System.Runtime.InteropServices;
using System.Security.Cryptography;
using WorkplaceApp.backend;

namespace WorkplaceApp.frontend
{
    public static class Display
    {
        public static int DisplayMenu()
        {
            Console.WriteLine(" WYBIERZ OPCJĘ:");
            Console.WriteLine(" 1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine(" 2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine(" 3 => ZAKOŃCZ PROGRAM");
            Console.Write(" WYBIERZ 1, 2 LUB 3: ");

            return int.Parse(Console.ReadLine());
        }

        public static int DisplayWorkers()
        {
            Console.Clear();
            Console.WriteLine(" ID | IMIĘ I NAZWISKO | DATA UR. | STANOWISKO");
            foreach (Worker worker in Workplace.Workers)
            {
                Console.WriteLine($" {worker.Id} | {worker.Name} | {worker.BirthDate.ToShortDateString()} | {worker.Position}");
            }
            Console.WriteLine();
            return DisplayMenu();
        }

        private static void DisplayWorkersInfo(Worker Worker)
        {
            Console.WriteLine(" WYLICZANIE WYNAGRODZENIA PRACOWNIKA");
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine(" DANE PRACOWNIKA:");
            Console.WriteLine($" IMIĘ I NAZWISKO: {Worker.Name}");
            Console.WriteLine($" WIEK: {DateTime.Now.Year - Worker.BirthDate.Year} lat");
            Console.WriteLine($" STANOWISKO: {Worker.Position}");
            switch (Worker.Position)
            {
                case "pracownik fizyczny":
                    Console.WriteLine($" STAWKA GODZINOWA: {Worker.HourlyPay} zł/h");
                    break;
                case "urzędnik":
                    Console.WriteLine($" PENSJA STAŁA: {Worker.MonthlyPay} zł");
                    break;
            }
        }

        private static void DisplayPayment(decimal BruttoPayment, decimal Taxes, decimal NettoPayment)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round(BruttoPayment, 2)} zł");
            switch (Taxes)
            {
                case 0:
                    Console.WriteLine(" BRAK PODATKU");
                    break;
                case not 0:

                    Console.WriteLine($" POTRĄCONY PODATEK (18%): {Math.Round(Taxes, 2)} zł");
                    break;
            }
            Console.WriteLine($" DO WYPŁATY: {Math.Round(NettoPayment, 2)} zł");
            Console.ResetColor();
            Console.Write(" WCIŚNIJ DOWOLNY PRZYCISK BY ZAKOŃCZYĆ ... ");
            Console.ReadLine();
        }

        public static void DisplaySalaryCalculation()
        {
            Console.Clear();
            Console.Write(" PROSZĘ PODAĆ ID PRACOWNIKA DLA KTÓREGO ZOSTANIE WYLICZONE WYNAGRODZENIE: ");
            int ChosenId = int.Parse(Console.ReadLine());
            Worker ChosenWorker = Workplace.Workers.FirstOrDefault(x => x.Id == ChosenId);
            Console.Clear();

            DisplayWorkersInfo(ChosenWorker);
            Console.Write(" PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX. 20): ");
            int WorkedDays = int.Parse(Console.ReadLine());
            while (WorkedDays < 0 || WorkedDays > 20)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" BŁĘDNA WARTOŚĆ. ILOŚĆ PRZEPRACOWANYCH DNI POWINNA BYĆ POMIĘDZY 0 A 20.");
                Console.ResetColor();
                DisplayWorkersInfo(ChosenWorker);
                Console.Write(" PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX. 20): ");
                WorkedDays = int.Parse(Console.ReadLine());
            }
            Console.Clear();

            Console.Write(" PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA: ");
            decimal Bonus = decimal.Parse(Console.ReadLine());
            Console.Clear();

            List<decimal> Salary = Workplace.CalculateSalary(ChosenWorker, WorkedDays, Bonus);
            decimal BruttoPayment = Salary[0];
            decimal Taxes = Salary[1];
            decimal NettoPayment = Salary[2];

            DisplayPayment(BruttoPayment, Taxes, NettoPayment);
        }
    }
}
