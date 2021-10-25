using CampaignDataApi.DataObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.Facade.Interfaces
{
    public interface ICampaignFacade
    {
        Task<List<ICampaign>> GetAllCampagins();
        Task<List<ICampaign>> GetActiveCampagins();
        Task<List<ICampaign>> GetClosedCampagins();
    }
}
