using WorkplaceApp.frontend;
using WorkplaceApp.backend;
using System.Text.Json.Serialization;

Console.Clear();

int UsersChoice = Display.DisplayMenu();

while (true)
{
    switch (UsersChoice)
    {
        case 1:
            UsersChoice = Display.DisplayWorkers();
            break;
        case 2:
            Display.DisplaySalaryCalculation();
            Environment.Exit(0);
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
}
