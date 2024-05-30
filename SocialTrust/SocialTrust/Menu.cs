public class Menu()
{
    private static Cafe cafe = new Cafe();
    public static void PrintMenu()
    {
        Console.WriteLine("----------Menu---------");
        Console.WriteLine("\n 1) Reset Data");
        Console.WriteLine(" 2) Print Contacts");
        Console.WriteLine(" 3) Create CaveMan Network");
        Console.WriteLine(" 4) Create SmallWorld Network");
        Console.WriteLine(" 5) Calculate Implicit Social Trust");
        Console.WriteLine(" 6) Calculate Explicit Social Trust");
        Console.WriteLine(" 7) Add Person to Caffe");

        Console.WriteLine("\n 0) Exit");
    }

    public static void TakeOption(string command)
    {
        switch (command)
        {
            case "1": ResetData(); PressAnyKey(); break;
            case "2": PrintContacts(); PressAnyKey(); break;
            case "3": CreateCaveManNetwork(); PressAnyKey(); break;
            case "4": CreateSmallWorldNetwork(); PressAnyKey(); break;
            case "5": CalculateImplicitSocialTrust(); PressAnyKey(); break;
            case "6": CalculateExplicitSocialTrust(); PressAnyKey(); break;
            case "7": AddPersonToCaffe(); PressAnyKey(); break;
            case "0": break;

            default: Console.WriteLine("\n No such Command"); PressAnyKey(); break;
        }
    }

    public static void AddPersonToCaffe()
    {
        //cafe.AddPerson("Stefania");
        //cafe.AddVisitingTime("Stefania", new TimeSpan(22, 30, 0), new TimeSpan(23, 0, 0));

        //cafe.AddPerson("Apolo");
        ///cafe.AddVisitingTime("Apolo",    new TimeSpan(9, 30, 0),  new TimeSpan(10, 0, 0));

        cafe.EstablishContactsBasedOnVisitingTimes();
    }

    private static void ResetData()
    {
        cafe = new Cafe();
        cafe.AddPerson("Alice");
        cafe.AddPerson("Bob");
        cafe.AddPerson("Carol");
        cafe.AddPerson("David");
        cafe.AddPerson("Eve");
        cafe.AddPerson("Frank");
        cafe.AddPerson("Grace");
        cafe.AddPerson("Henry");
        cafe.AddPerson("Isabel");
        cafe.AddPerson("Jack");
        cafe.AddPerson("Karen");
        cafe.AddPerson("Larry");
        cafe.AddPerson("Megan");
        cafe.AddPerson("Nathan");
        cafe.AddPerson("Olivia");
        cafe.AddPerson("Peter");
        cafe.AddPerson("Quinn");
        cafe.AddPerson("Rachel");
        cafe.AddPerson("Sam");
        cafe.AddPerson("Tina");
        //cafe.AddPerson("Apolo");

        cafe.AddVisitingTime("Alice",  new TimeSpan(9, 0, 0),   new TimeSpan(10, 30, 0));
        cafe.AddVisitingTime("Bob",    new TimeSpan(11, 0, 0),  new TimeSpan(13, 0, 0));
        cafe.AddVisitingTime("Carol",  new TimeSpan(12, 0, 0),  new TimeSpan(13, 30, 0));
        cafe.AddVisitingTime("David",  new TimeSpan(9, 30, 0),  new TimeSpan(10, 0, 0));
        cafe.AddVisitingTime("Eve",    new TimeSpan(9, 30, 0),  new TimeSpan(10, 30, 0));
        cafe.AddVisitingTime("Frank",  new TimeSpan(13, 0, 0),  new TimeSpan(14, 0, 0));
        cafe.AddVisitingTime("Grace",  new TimeSpan(13, 30, 0), new TimeSpan(14, 0, 0));
        cafe.AddVisitingTime("Henry",  new TimeSpan(12, 0, 0),  new TimeSpan(13, 30, 0));
        cafe.AddVisitingTime("Isabel", new TimeSpan(15, 0, 0),  new TimeSpan(17, 30, 0));
        cafe.AddVisitingTime("Jack",   new TimeSpan(14, 0, 0),  new TimeSpan(15, 0, 0));
        cafe.AddVisitingTime("Karen",  new TimeSpan(11, 0, 0),  new TimeSpan(15, 30, 0));
        cafe.AddVisitingTime("Larry",  new TimeSpan(19, 0, 0),  new TimeSpan(21, 0, 0));
        cafe.AddVisitingTime("Megan",  new TimeSpan(18, 0, 0),  new TimeSpan(19, 0, 0));
        cafe.AddVisitingTime("Nathan", new TimeSpan(16, 0, 0),  new TimeSpan(19, 0, 0));
        cafe.AddVisitingTime("Olivia", new TimeSpan(17, 0, 0),  new TimeSpan(18, 30, 0));
        cafe.AddVisitingTime("Peter",  new TimeSpan(13, 0, 0),  new TimeSpan(13, 30, 0));
        cafe.AddVisitingTime("Quinn",  new TimeSpan(12, 0, 0),  new TimeSpan(14, 0, 0));
        cafe.AddVisitingTime("Rachel", new TimeSpan(14, 0, 0),  new TimeSpan(17, 0, 0));
        cafe.AddVisitingTime("Sam",    new TimeSpan(9, 0, 0),   new TimeSpan(11, 0, 0));
        cafe.AddVisitingTime("Tina",   new TimeSpan(10, 30, 0), new TimeSpan(11, 0, 0));
        //cafe.AddVisitingTime("Apolo",   new TimeSpan(9, 30, 0), new TimeSpan(10, 0, 0));

        /*cafe = new Cafe();
        cafe.AddPerson("Alice");
        cafe.AddPerson("Bob");
        cafe.AddPerson("Carol");
        cafe.AddPerson("David");
        cafe.AddPerson("Eve");
        cafe.AddPerson("Frank");
        cafe.AddPerson("Grace");
        cafe.AddPerson("Henry");
        cafe.AddPerson("Isabel");
        cafe.AddPerson("Jack");
        cafe.AddPerson("Karen");
        cafe.AddPerson("Larry");
        cafe.AddPerson("Megan");
        cafe.AddPerson("Nathan");
        cafe.AddPerson("Olivia");
        cafe.AddPerson("Peter");
        cafe.AddPerson("Quinn");
        cafe.AddPerson("Rachel");
        cafe.AddPerson("Sam");
        cafe.AddPerson("Tina");

        // 7 00 - 22 00 
        cafe.AddVisitingTime("Alice", new TimeSpan(7, 30, 0), new TimeSpan(8, 30, 0));
        cafe.AddVisitingTime("Bob", new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0));
        cafe.AddVisitingTime("Carol", new TimeSpan(11, 0, 0), new TimeSpan(12, 30, 0));
        cafe.AddVisitingTime("David", new TimeSpan(8, 0, 0), new TimeSpan(8, 30, 0));
        cafe.AddVisitingTime("Eve", new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0));
        cafe.AddVisitingTime("Frank", new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
        cafe.AddVisitingTime("Grace", new TimeSpan(12, 30, 0), new TimeSpan(13, 0, 0));
        cafe.AddVisitingTime("Henry", new TimeSpan(11, 0, 0), new TimeSpan(12, 30, 0));
        cafe.AddVisitingTime("Isabel", new TimeSpan(17, 0, 0), new TimeSpan(19, 30, 0));
        cafe.AddVisitingTime("Jack", new TimeSpan(14, 0, 0), new TimeSpan(15, 0, 0));
        cafe.AddVisitingTime("Karen", new TimeSpan(10, 0, 0), new TimeSpan(14, 30, 0));
        cafe.AddVisitingTime("Larry", new TimeSpan(20, 0, 0), new TimeSpan(22, 0, 0));
        cafe.AddVisitingTime("Megan", new TimeSpan(21, 0, 0), new TimeSpan(22, 0, 0));
        cafe.AddVisitingTime("Nathan", new TimeSpan(19, 0, 0), new TimeSpan(22, 0, 0));
        cafe.AddVisitingTime("Olivia", new TimeSpan(20, 0, 0), new TimeSpan(21, 30, 0));
        cafe.AddVisitingTime("Peter", new TimeSpan(12, 0, 0), new TimeSpan(12, 30, 0));
        cafe.AddVisitingTime("Quinn", new TimeSpan(11, 0, 0), new TimeSpan(13, 0, 0));
        cafe.AddVisitingTime("Rachel", new TimeSpan(13, 0, 0), new TimeSpan(16, 0, 0));
        cafe.AddVisitingTime("Sam", new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0));
        cafe.AddVisitingTime("Tina", new TimeSpan(9, 30, 0), new TimeSpan(10, 0, 0));*/
        //cafe.AddVisitingTime("Tina", new TimeSpan(22, 30, 0), new TimeSpan(23, 0, 0));

        cafe.EstablishContactsBasedOnVisitingTimes();
    }

    private static void PrintContacts()
    {
        cafe.PrintContacts();
    }

    private static void CreateCaveManNetwork()
    {
        cafe.CreateCavemanNetwork(5);
    }

    private static void CreateSmallWorldNetwork()
    {
        cafe.CreateSmallWorldNetwork(0.66);
    }

    private static void CalculateImplicitSocialTrust()
    {
        cafe.CalculateImplicitSocialTrust();
    }

    private static void CalculateExplicitSocialTrust()
    {
        cafe.CalculateExplicitSocialTrust();
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("\n Press any key to continue -> "); 
        Console.ReadLine();
    }
}


