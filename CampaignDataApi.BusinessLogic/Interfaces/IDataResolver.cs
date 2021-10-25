using CampaignDataApi.DataObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.BusinessLogic.Interfaces
{
    public interface IDataResolver
    {
        Task<List<ICampaign>> GetAllCampaigns();
        Task<List<ICampaign>> GetActiveCampaigns();
        Task<List<ICampaign>> GetClosedCampaigns();
    }
}
