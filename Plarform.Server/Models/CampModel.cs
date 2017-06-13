using System;
using System.ComponentModel.DataAnnotations;

namespace Plarform.Server.Models
{
    public class CampModel
    {
        public string Url { get; set; }
        [Required]
        public string Moniker { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; }
        [Required]
        public string Description { get; set; }

        //location
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationCityTown { get; set; }
        public string LocationStateProvince { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationCountry { get; set; }
    }
}
