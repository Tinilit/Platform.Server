﻿namespace Plarform.Server.Models
{
    public class TestModel
    {
        public string Url { get; set; }

        public string Data { get; set; }

        public int ProviderProfileId { get; set; }
        public ProfileModel ProviderProfile { get; set; }

        public int TestTypeId { get; set; }
        public TestTypeModel TestType { get; set; }
    }
}
