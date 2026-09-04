using System.ComponentModel.DataAnnotations.Schema;

namespace PJAverageRate.Models
{
    public class PJAverageRateViewModel
    {

        public string Modeall { get; set; }
        public string Unit { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }
        public string CustomerType { get; set; }
        public decimal? Ltv { get; set; }

        public bool IsViewMode { get; set; }

        public bool IsViewconMode { get; set; }

        public bool IsUnitCust { get; set; }

        public bool IsGoCustbtn { get; set; }

        [NotMapped]
        public List<GoldRateModel> GoldRates { get; set; } = new();


    }
}
    