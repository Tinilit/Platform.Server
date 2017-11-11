namespace Platform.DataAccess.Entities
{
    public class Test : Entity
    {
        public int TestId { get; set; }

        public string Data { get; set; }

        public int ProviderProfileId { get; set; }
        public Profile ProviderProfile { get; set; }

        public int TestTypeId { get; set; }
        public TestType TestType { get; set; }
    }
}