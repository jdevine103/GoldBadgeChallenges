using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Repo
{
    public class Outing
    {
        public Outing(EventType type, int attendance, DateTime date)
        {
            Type = type;
            Attendance = attendance;
            Date = date;
        }
        public EventType Type { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson
        {
            get
            {
                if (Type == EventType.Golf)
                    return 400;
                else if (Type == EventType.Bowling)
                    return 100;
                else if (Type == EventType.AmusementPark)
                    return 500;
                else if (Type == EventType.Concert)
                    return 200;
                else
                    return 0;
            }

        }
        public decimal TotalEventCost
        {
            get
            {
                return CostPerPerson * Attendance;
            }
        }
        public enum EventType
        {
            Golf, Bowling, AmusementPark, Concert
        }
    }
}
