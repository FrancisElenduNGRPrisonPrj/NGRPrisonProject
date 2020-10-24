using NGRPrisonAPI.Helper;
using System.Collections.Generic;

namespace NGRPrisonAPI.Dto
{
    public class StateDto
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        [NoMap]
        public ICollection<PrisonDto> Prisons { get; set; }
        [NoMap]
        public ICollection<InmateDto> Inmates { get; set; }
    }
}