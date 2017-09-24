namespace Platform.DataAccess.Entities
{
    public class UserTest : Entity
    {
        public int UserTestId { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }

        public User User { get; set; }
        public Test Test { get; set; }
    }
}
