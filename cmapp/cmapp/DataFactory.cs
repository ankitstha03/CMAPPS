using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cmapp.Models;


namespace cmapp
{
    public static class DataFactory
    {
        public static IList<Schedular> Classes { get; private set; }

        private static DateTime TaskAt(int month, int Day, int hour, int minute)
        {
            return new DateTime(DateTime.Now.Year,
                month,
                Day,
                hour, minute, 0);
        }

        static DataFactory()
        {

            Classes = new ObservableCollection<Schedular>
            {
                new Schedular
                {
                    EventName = "Task 1",
                    Descritpion = "Task description",
                    EventDate = TaskAt(3,12,8,00),
                },
                 new Schedular
                {
                    EventName = "Task 2",
                    Descritpion = "Task Description",
                    EventDate = TaskAt(3,13,9,30),
                },
         
                 new Schedular
                {
                    EventName = "Cycle",
                    Descritpion = "Task Description",
                    EventDate = TaskAt(3,14,12,00),
                },
                 new Schedular
                {
                    EventName = "Aerobics",
                    Descritpion = "Task Description",
                    EventDate = TaskAt(3,14,15,30),
                },
                 new Schedular
                {
                    EventName = "Weights",
                    Descritpion = "Task Description",
                    EventDate = TaskAt(3,15,18,00),
                },
            };
        }
    }
}
