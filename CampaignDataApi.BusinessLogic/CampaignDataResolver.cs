using CampaignDataApi.BusinessLogic.Clients;
using CampaignDataApi.BusinessLogic.Clients.Interfaces;
using CampaignDataApi.BusinessLogic.Interfaces;
using CampaignDataApi.DataObjects.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignDataApi.BusinessLogic
{
    /// <summary>
    /// The campaign resolver.
    /// </summary>
    /// <seealso cref="CampaignDataApi.BusinessLogic.Interfaces.IDataResolver" />
    public class CampaignDataResolver : IDataResolver
    {
        private readonly ICampaignApiClient _campaignApiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignDataResolver"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public CampaignDataResolver(IConfiguration configuration)
        {
            _campaignApiClient = new CampaginApiClient(configuration);
        }

        /// <summary>
        /// Gets the active campaigns.
        /// </summary>
        /// <returns>
        /// List of all active campaigns
        /// </returns>
        public async Task<List<ICampaign>> GetActiveCampaigns()
        {
            List<ICampaign> campaigns = (await _campaignApiClient.GetData()).ToList<ICampaign>();

            List<ICampaign> activeCampaigns = campaigns.Where(campaign =>
            campaign.EndDate >= DateTime.Now &&
            campaign.Created >= DateTime.Now.Subtract(TimeSpan.FromDays(30))
            ).ToList();

            return activeCampaigns;
        }

        /// <summary>
        /// Gets all campaigns.
        /// </summary>
        /// <returns>
        /// List of all campaigns
        /// </returns>
        public async Task<List<ICampaign>> GetAllCampaigns()
        {
            List<ICampaign> campaigns = (await _campaignApiClient.GetData()).ToList<ICampaign>();

            List<ICampaign> orderedCampaigns = campaigns.OrderByDescending(campaign => campaign.TotalAmount).ToList();

            return orderedCampaigns;
        }

        /// <summary>
        /// Gets the closed campaigns.
        /// </summary>
        /// <returns>
        /// List of all closed campaigns
        /// </returns>
        public async Task<List<ICampaign>> GetClosedCampaigns()
        {
            List<ICampaign> campaigns = (await _campaignApiClient.GetData()).ToList<ICampaign>();

            List<ICampaign> closedCampaigns = campaigns.Where(campaign =>
            campaign.EndDate < DateTime.Now ||
            campaign.ProcuredAmount >= campaign.TotalAmount
            ).ToList();

            return closedCampaigns;
        }
    }
}
