using CampaignDataApi.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.BusinessLogic.Clients.Interfaces
{
    public interface ICampaignApiClient
    {
        Task<List<Campaign>> GetData();
    }
}
