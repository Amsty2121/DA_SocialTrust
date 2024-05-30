using System.Linq;

public class Cafe
{
    public Dictionary<string, Person> People { get; set; }

    public Cafe()
    {
        People = new Dictionary<string, Person>();
    }

    public void AddPerson(string name)
    {
        People[name] = new Person(name);
    }

    // Find the length of the longest contact name
    private int MaxNameLength => People.Keys.Select(s => s.Length).DefaultIfEmpty(0).Max();

    public void PrintContacts()
    {
        Console.WriteLine("\nPrint Contacts");
        Console.WriteLine("Name\t\t\tVisiting Times\t\t\tContacts");
        Console.WriteLine("-------------------------------------------------------------");

        foreach (var person in People.Values)
        {
            Console.Write($"{person.Name.PadRight(MaxNameLength + 1)}\t\t");
            foreach (var time in person.VisitingTimes)
            {
                Console.Write($"[{time.Item1}-{time.Item2}] ");
            }

            Console.Write("\t\t");

            foreach (var contact in person.Contacts)
            {
                Console.Write($"{contact.PadRight(MaxNameLength + 1)} ");
            }

            Console.WriteLine();
        }
        Console.WriteLine();
    }


    public void AddContact(string person1, string person2)
    {
        if (People.ContainsKey(person1) && People.ContainsKey(person2))
        {
            People[person1].Contacts.Add(person2);
            People[person2].Contacts.Add(person1);
        }
    }

    public void AddVisitingTime(string name, TimeSpan startTime, TimeSpan endTime)
    {
        if (People.ContainsKey(name))
            People[name].AddVisitingTime(startTime, endTime);
    }

    public void EstablishContactsBasedOnVisitingTimes()
    {
        foreach (var person1 in People.Values)
        {
            foreach (var person2 in People.Values)
            {
                if (person1.Name != person2.Name && !person1.Contacts.Contains(person2.Name))
                {
                    if (HasOverlappingVisitingTimes(person1, person2))
                    {
                        AddContact(person1.Name, person2.Name);
                    }
                }
            }
        }
    }

    private bool HasOverlappingVisitingTimes(Person person1, Person person2)
    {
        foreach (var time1 in person1.VisitingTimes)
        {
            foreach (var time2 in person2.VisitingTimes)
            {
                if ((time1.Item1 <= time2.Item1 && time1.Item2 >= time2.Item2) || 
                    (time2.Item1 <= time1.Item1 && time2.Item2 >= time1.Item2) || 
                    (time1.Item1 <= time2.Item2 && time1.Item2 >= time2.Item1) || 
                    (time2.Item1 <= time1.Item2 && time2.Item2 >= time1.Item1))   
                {
                    return true;
                }
            }
        }
        return false;
    }


    //Implicit trust---------------------------------------------------------------------------------------
    public void CalculateImplicitSocialTrust()
    {
        Console.WriteLine("\nCalculate Implicit Social Trust");
        Console.WriteLine("Name\t\tImplicit Trust");
        Console.WriteLine("--------------------------------");

        foreach (var person in People.Values)
        {
            double implicitSocialTrust = CalculateImplicitSocialTrustForPerson(person);
            Console.WriteLine($"{person.Name.PadRight(MaxNameLength + 1)}\t\t{implicitSocialTrust:P2}");
        }

        Console.WriteLine();
    }

    private double CalculateImplicitSocialTrustForPerson(Person person)
    {
        double fs0 = person.Contacts.Count;
        double tij = 0;
        foreach (var contact in person.Contacts)
        {
            double familiarity_term = People[contact].Familiarity / fs0;
            double similarity_term = -1;

            foreach (var otherContact in person.Contacts)
            {
                if(person.Contacts.Contains(otherContact))
                {
                    double fkj = People[otherContact].Familiarity;
                    double fsk = People[otherContact].Contacts.Count;
                    similarity_term += (People[contact].Familiarity / fs0) * (fkj / (fsk - 0.3));
                }
            }

            tij = Math.Abs(familiarity_term + similarity_term); 
        }
        return tij;
    }
    //Implicit trust---------------------------------------------------------------------------------------

    //Explicit trust---------------------------------------------------------------------------------------
    double c = 1;
    public void CalculateExplicitSocialTrust()
    {
        Console.WriteLine("\nCalculate Explicit Social Trust");
        Console.WriteLine("Name\t\tExplicit Trust");
        Console.WriteLine("--------------------------------");

        foreach (var person in People.Values)
        {
            double explicitSocialTrust = CalculateExplicitSocialTrustForPerson(person);
            Console.WriteLine($"{person.Name.PadRight(MaxNameLength + 1)}\t\t{explicitSocialTrust:P2}");
        }

        Console.WriteLine();
    }

    private double CalculateExplicitSocialTrustForPerson(Person person)
    {
        var visited = new HashSet<string>();
        var trustValues = new Dictionary<string, double>();

        // Initiate familiriarity to 1 for friends
        foreach (var friend in person.Contacts)
            trustValues[friend] = 1.0;

        visited.Add(person.Name);

        // Breadth-first search for extendig familiarity (deep search)
        var queue = new Queue<string>(person.Contacts);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            visited.Add(current);

            foreach (var friendOfFriend in People[current].Contacts)
            {
                if (!visited.Contains(friendOfFriend))
                {
                    queue.Enqueue(friendOfFriend);
                    visited.Add(friendOfFriend);

                    double sum = 0;
                    int count = 0;
                    foreach (var mutualFriend in person.Contacts.Intersect(People[friendOfFriend].Contacts))
                    {
                        sum += trustValues[mutualFriend];
                        count++;
                    }

                    trustValues[friendOfFriend] = count > 0 ? sum / count : 0; // trust transition
                }
            }
        }

        return trustValues.Values.Sum() / trustValues.Count;
    }
    //Explicit trust---------------------------------------------------------------------------------------

    public void CreateCavemanNetwork(int groupSize)
    {
        Console.WriteLine("\nCreate Caveman Network");

        var implicitSocialTrust = new Dictionary<string, double>();

        foreach(var person in People)
        {
            implicitSocialTrust.Add(person.Key, CalculateImplicitSocialTrustForPerson(person.Value));
        }

        // Delete old relations
        foreach (var person in People.Values)
        {
            person.Contacts.Clear();
        }

        // Groups Splitting 
        List<List<Person>> groups = new List<List<Person>>();
        List<Person> currentGroup = new List<Person>();
        foreach (var person in People.Values)
        {
            currentGroup.Add(person);
            if (currentGroup.Count == groupSize)
            {
                groups.Add(new List<Person>(currentGroup));
                currentGroup.Clear();
            }
        }
        if (currentGroup.Count > 0)
        {
            groups.Add(currentGroup);
        }

        // Add Relations
        foreach (var group in groups)
        {
            foreach (var person in group)
            {
                foreach (var otherPerson in group)
                {
                    if (person != otherPerson)
                    {
                        person.Contacts.Add(otherPerson.Name);
                    }
                }
            }
        }

        PrintGroups(groups);

        Console.WriteLine("\nCalculate Implicit Social Trust");
        Console.WriteLine("Name\t\tImplicit Trust");
        Console.WriteLine("--------------------------------");

        foreach (var person in People.Values)
        {
            double socialTrust = (implicitSocialTrust[person.Name] + CalculateImplicitSocialTrustForPerson(person)) / 2.0;
            Console.WriteLine($"{person.Name}\t\t{socialTrust:P2}");
        }

        Console.WriteLine();

        CalculateExplicitSocialTrust();
    }

    private void PrintGroups(List<List<Person>> groups)
    {
        Console.WriteLine("\nPrint Groups");
        Console.WriteLine("Nr\t\tGroup members");
        Console.WriteLine("--------------------------------");

        int groupNumber = 1;

        foreach (var group in groups)
        {
            Console.Write($"Group {groupNumber}:\t");
            foreach (var person in group)
            {
                Console.Write($"{person.Name.PadRight(MaxNameLength + 1)}");
            }
            Console.WriteLine();
            groupNumber++;
        }
        Console.WriteLine();
    }

    public void CreateSmallWorldNetwork(double probability)
    {
        Console.WriteLine("\nCreate SmallWorld Network");
        Console.WriteLine("\tNew Contacts");
        Console.WriteLine("--------------------------------");

        List<(string, string)> Contacts = new List<(string, string)>();
        foreach (var person in People.Values)
        {
            if (CalculateImplicitSocialTrustForPerson(person) < probability)
                continue;

            foreach (var otherPerson in People.Values)
            {
                if (person != otherPerson)
                {
                    if (CalculateImplicitSocialTrustForPerson(otherPerson) < probability)
                        continue;

                    if (!Contacts.Any(p => p.Equals((otherPerson.Name, person.Name))))
                    {
                        Contacts.Add((person.Name, otherPerson.Name));
                        Console.WriteLine($"{person.Name}\t\t{otherPerson.Name}");
                    }

                }
            }
        }

        foreach (var contact in Contacts)
        {
            AddContact(contact.Item1, contact.Item2);
        }

        CalculateImplicitSocialTrust();
        CalculateExplicitSocialTrust();
    }
}