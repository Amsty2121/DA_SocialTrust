
/*cafe.PrintContacts();

cafe.CalculateFamiliarity();
//cafe.PrintFamiliarity();

cafe.CalculateExplicitSocialTrust();
cafe.PrintFamiliarity();


/*cafe.CalculateFamiliarity();
cafe.PrintFamiliarity();*/
//cafe.CalculateImplicitSocialTrust();

//cafe.CreateCavemanNetwork(3);
//cafe.CreateSmallWorldNetwork(0.66);

string command;
do
{
    //Console.Clear();
    Menu.PrintMenu();
    Console.Write("\n Choose a command -> ");
    command = Console.ReadLine();
    Menu.TakeOption(command);

} while (command != "0");

