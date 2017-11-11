namespace Platform.DataAccess.Entities
{
    public class UserTest : Entity
    {
        public int UserTestId { get; set; }

        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
