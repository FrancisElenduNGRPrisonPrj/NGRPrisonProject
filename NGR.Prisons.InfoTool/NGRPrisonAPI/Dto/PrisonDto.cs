using NGRPrisonAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Dto
{
    public class PrisonDto
    {
        public int Id { get; set; }
        public string PrisonName { get; set; }
        public string StateName { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime EstablishedDate { get; set; }
        //public StateDto State { get; set; }
        public ICollection<InmateDto> Inmates { get; set; }
    }
}
