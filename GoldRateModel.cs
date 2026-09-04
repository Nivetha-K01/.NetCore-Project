using System.ComponentModel.DataAnnotations;

namespace PJAverageRate.Models
{
    public class GoldRateModel
    {
        public int? Rowno { get; set; }

        public int? CaratType { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal? RateAvg { get; set; }
        //[DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        //public decimal? FinalIBJA { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal? IbjaRate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal? FinalMarketRate { get; set; }

      
    }
}
