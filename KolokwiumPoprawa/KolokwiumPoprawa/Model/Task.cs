using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.Model
{
    public class Task
    {
        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
