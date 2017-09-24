namespace Plarform.Server.Models
{
    public class UserTestModel
    {
        public string Url { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }

        public TestModel Test { get; set; }
    }
}
