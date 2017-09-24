namespace Plarform.Server.Models
{
    public class TestModel
    {
        public string Url { get; set; }
        public string ProviderId { get; set; }
        public int PaidCount { get; set; }

        public TestTypeModel TestType { get; set; }
    }
}
