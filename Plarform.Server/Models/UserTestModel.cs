namespace Plarform.Server.Models
{
    public class UserTestModel
    {
        public string Url { get; set; }
        
        public int UserProfileId { get; set; }
        public ProfileModel UserProfile { get; set; }

        public int TestId { get; set; }
        public TestModel Test { get; set; }
    }
}
