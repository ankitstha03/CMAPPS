using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmapp.Models
{
    public class Schedular
    {
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public string Descritpion { get; set; }

        public bool IsLast { get; set; } = false;
    }
}
