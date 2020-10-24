using NGRPrisonAPI.Helper;
using System.Collections.Generic;

namespace NGRPrisonAPI.Dto
{
    public class StateDto
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<PrisonDto> Prisons { get; set; }
        public ICollection<InmateDto> Inmates { get; set; }
    }
}