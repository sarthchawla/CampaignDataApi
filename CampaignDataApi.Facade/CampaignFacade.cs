using CampaignDataApi.BusinessLogic;
using CampaignDataApi.BusinessLogic.Interfaces;
using CampaignDataApi.DataObjects.Interfaces;
using CampaignDataApi.Facade.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.Facade
{
    /// <summary>
    /// The Campaign Facade
    /// </summary>
    /// <seealso cref="CampaignDataApi.Facade.Interfaces.ICampaignFacade" />
    public class CampaignFacade : ICampaignFacade
    {
        private readonly IDataResolver _dataResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignFacade"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public CampaignFacade(IConfiguration configuration)
        {
            _dataResolver = new CampaignDataResolver(configuration);
        }

        /// <summary>
        /// Gets all campagins.
        /// </summary>
        /// <returns>
        /// List of all campaigns
        /// </returns>
        public async Task<List<ICampaign>> GetAllCampagins()
        {
            return await _dataResolver.GetAllCampaigns();
        }

        /// <summary>
        /// Gets the active campagins.
        /// </summary>
        /// <returns>
        /// List of all active campaigns
        /// </returns>
        public async Task<List<ICampaign>> GetActiveCampagins()
        {
            return await _dataResolver.GetActiveCampaigns();
        }

        /// <summary>
        /// Gets the closed campagins.
        /// </summary>
        /// <returns>
        /// List of all closed campaigns
        /// </returns>
        public async Task<List<ICampaign>> GetClosedCampagins()
        {
            return await _dataResolver.GetClosedCampaigns();
        }
    }
}
