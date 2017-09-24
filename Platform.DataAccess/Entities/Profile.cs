using System;

namespace Platform.DataAccess.Entities
{
    public class Profile:Entity
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Education { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string FirstLanguage { get; set; }
        public string MedName { get; set; }
        public string InjuryCount { get; set; }
        public string Income { get; set; }
        public string Hand { get; set; }
        public string Ethnisity { get; set; }
        public string BrainActivity { get; set; }
        public string Exercise { get; set; }
        public string SelfEsteem { get; set; }
        public string SelfHealth { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
