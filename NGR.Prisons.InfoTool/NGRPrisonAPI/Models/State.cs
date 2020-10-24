using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<Prison> Prisons { get; set; }
        public ICollection<Inmate> Inmates { get; set; }
    }
}
