using System;

namespace EventPlanning
{
    public class Address
    {
        public string _street { get; private set; }
        public string _city { get; private set; }
        public string _state { get; private set; }
        public string _zipCode { get; private set; }

        public Address(string street, string city, string state, string zipCode)
        {
            _street = street;
            _city = city;
            _state = state;
            _zipCode = zipCode;
        }

        public override string ToString()
        {
            return $"{_street}, {_city}, {_state} {_zipCode}";
        }
    }

    public abstract class Event
    {
        public string _title { get; private set; }
        public string _description { get; private set; }
        public DateTime _date { get; private set; }
        public string _time { get; private set; }
        public Address _eventAddress { get; private set; }

        public Event(string title, string description, DateTime date, string time, Address eventAddress)
        {
            _title = title;
            _description = description;
            _date = date;
            _time = time;
            _eventAddress = eventAddress;
        }

        public virtual string GetStandardDetails()
        {
            return $"Type: {GetType().Name}\n{_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_eventAddress}";
        }

        public abstract string GetFullDetails();

        public virtual string GetShortDescription()
        {
            return $"{GetType().Name} Event: {_title} on {_date.ToShortDateString()}";
        }
    }

    public class Lecture : Event
    {
        public string _speaker { get; private set; }
        public int _capacity { get; private set; }

        public Lecture(string title, string description, DateTime date, string time, Address eventAddress, string speaker, int capacity)
            : base(title, description, date, time, eventAddress)
        {
            _speaker = speaker;
            _capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
        }
    }

    public class Reception : Event
    {
        public string _rsvpEmail { get; private set; }

        public Reception(string title, string description, DateTime date, string time, Address eventAddress, string rsvpEmail)
            : base(title, description, date, time, eventAddress)
        {
            _rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nRSVP Email: {_rsvpEmail}";
        }
    }

    public class OutdoorGathering : Event
    {
        public string _weatherForecast { get; private set; }

        public OutdoorGathering(string title, string description, DateTime date, string time, Address eventAddress, string weatherForecast)
            : base(title, description, date, time, eventAddress)
        {
            _weatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nWeather Forecast: {_weatherForecast}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address lectureAddress = new Address("123 Ice Street", "Niflheim", "NI", "12345");
            Address receptionAddress = new Address("456 Fire Street", "Muspelheim", "MU", "678910");
            Address outdoorAddress = new Address("789 Golden Street", "Asgard", "AS", "111213");

            Lecture lecture = new Lecture("Author Talk", "a talk on the development of Autonomous Books.", new DateTime(2024, 8, 20), "10:00 AM", lectureAddress, "god_Loki", 100);
            Reception reception = new Reception("ASMR Company", "An evening of networking and socialising.", new DateTime(2024, 9, 15), "6:00 PM", receptionAddress, "Surtur.rsvp@company.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Community event on Asian culture", "Join us for a day in the park with events on Asian culture.", new DateTime(2024, 7, 30), "12:00 PM", outdoorAddress, "Sunny with a chance of rain.");

            Event[] events = { lecture, reception, outdoorGathering };

            foreach (Event ev in events)
            {
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine();
                Console.WriteLine(ev.GetShortDescription());
                Console.WriteLine();
            }
        }
    }
}
