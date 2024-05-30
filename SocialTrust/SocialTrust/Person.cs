public class Person
{
    public string Name { get; set; }
    public List<string> Contacts { get; set; }
    public double Familiarity { get; set; }
    public List<Tuple<TimeSpan, TimeSpan>> VisitingTimes { get; set; }

    public Person(string name)
    {
        Name = name;
        Contacts = new List<string>();
        Familiarity = 1.0;
        VisitingTimes = new List<Tuple<TimeSpan, TimeSpan>>();
    }

    public void AddVisitingTime(TimeSpan startTime, TimeSpan endTime)
    {
        VisitingTimes.Add(new Tuple<TimeSpan, TimeSpan>(startTime, endTime));
    }
}
