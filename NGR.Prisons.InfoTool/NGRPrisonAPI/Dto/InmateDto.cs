using NGRPrisonAPI.Helper;
using System;

namespace NGRPrisonAPI.Dto
{
    public class InmateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateOfOrigin { get; set; }
        public string PrisonName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime SentencedDate { get; set; }
        public DateTime RelasedDate { get; set; }
        public string Gender { get; set; }
        public string Offenses { get; set; }
        //public int StateId { get; set; }
        //public StateDto State { get; set; }
        //[NoMap]
        //public PrisonDto Prison { get; set; }
        //public ICollection<Photo> Photos { get; set; }
    }
}