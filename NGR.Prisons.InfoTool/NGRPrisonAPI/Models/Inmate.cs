using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Models
{
    public class Inmate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime SentencedDate { get; set; } 
        public DateTime RelasedDate { get; set; } 
        public string Gender { get; set; }
        public string Offenses { get; set; }
        public State State { get; set; }
        public Prison Prison { get; set; }
        //public ICollection<Photo> Photos { get; set; }
    }
}
