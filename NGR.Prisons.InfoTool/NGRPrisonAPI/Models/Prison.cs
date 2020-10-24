using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Models
{
    public class Prison
    {
        public int Id { get; set; }
        public string PrisonName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime EstablishedDate { get; set; }
        public State State { get; set; }
        public ICollection<Inmate> Inmates { get; set; }
    }
}
