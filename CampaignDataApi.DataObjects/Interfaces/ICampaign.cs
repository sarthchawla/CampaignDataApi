using System;

namespace CampaignDataApi.DataObjects.Interfaces
{
    public interface ICampaign
    {
        string Code { get; set; }
        string Title { get; set; }
        bool Featured { get; set; }
        int Priority { get; set; }
        object ShortDesc { get; set; }
        string ImageSrc { get; set; }
        DateTime Created { get; set; }
        DateTime EndDate { get; set; }
        double TotalAmount { get; set; }
        double ProcuredAmount { get; set; }
        double TotalProcured { get; set; }
        double BackersCount { get; set; }
        int CategoryId { get; set; }
        string Location { get; set; }
        string NgoCode { get; set; }
        string NgoName { get; set; }
        int DaysLeft { get; set; }
        double Percentage { get; set; }
    }
}
