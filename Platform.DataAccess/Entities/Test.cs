namespace Platform.DataAccess.Entities
{
    public class Test : Entity
    {
        public int TestId { get; set; }
        public string ProviderId { get; set; }
        public int PaidCount { get; set; }

        public int TestTypeId { get; set; }
        public TestType TestType { get; set; }
    }
}