using System;

namespace Plarform.Server.Models
{
    public class ProfileModel
    {
        public string Url{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Education { get; set; }
        public string MaritalStatus { get; set; }
        public bool? Gender { get; set; }
        public string FirstLanguage { get; set; }
        public string MedName { get; set; }
        public int? InjuryCount { get; set; }
        public int? Income { get; set; }
        public int? Hand { get; set; }
        public int? Ethnisity { get; set; }
        public string BrainActivity { get; set; }
        public string Exercise { get; set; }
        public string SelfEsteem { get; set; }
        public string SelfHealth { get; set; }
        public string UserId { get; set; }
    }
}
