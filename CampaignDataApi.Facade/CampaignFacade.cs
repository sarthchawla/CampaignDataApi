using CampaignDataApi.BusinessLogic;
using CampaignDataApi.BusinessLogic.Interfaces;
using CampaignDataApi.DataObjects.Interfaces;
using CampaignDataApi.Facade.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.Facade
{
    public class CampaignFacade : ICampaignFacade
    {
        private readonly IDataResolver _dataResolver;
        public CampaignFacade(IConfiguration configuration)
        {
            _dataResolver = new CampaignDataResolver(configuration);
        }
        public async Task<List<ICampaign>> GetAllCampagins()
        {
            return await _dataResolver.GetAllCampaigns();
        }

        public async Task<List<ICampaign>> GetActiveCampagins()
        {
            return await _dataResolver.GetActiveCampaigns();
        }

        public async Task<List<ICampaign>> GetClosedCampagins()
        {
            return await _dataResolver.GetClosedCampaigns();
        }
    }
}
