using CampaignDataApi.DataObjects.Interfaces;
using System;

namespace CampaignDataApi.DataObjects
{
    /// <summary>
    /// Campaign data object
    /// </summary>
    /// <seealso cref="CampaignDataApi.DataObjects.Interfaces.ICampaign" />
    public class Campaign : ICampaign
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public bool Featured { get; set; }
        public int Priority { get; set; }
        public object ShortDesc { get; set; }
        public string ImageSrc { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalAmount { get; set; }
        public double ProcuredAmount { get; set; }
        public double TotalProcured { get; set; }
        public double BackersCount { get; set; }
        public int CategoryId { get; set; }
        public string Location { get; set; }
        public string NgoCode { get; set; }
        public string NgoName { get; set; }
        public int DaysLeft { get; set; }
        public double Percentage { get; set; }
    }
}
