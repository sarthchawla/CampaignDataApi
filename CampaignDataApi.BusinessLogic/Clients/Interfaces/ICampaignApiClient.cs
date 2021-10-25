using CampaignDataApi.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.BusinessLogic.Clients.Interfaces
{
    /// <summary>
    /// Interface for campaign api client.
    /// </summary>
    public interface ICampaignApiClient
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>List of campaigns</returns>
        Task<List<Campaign>> GetData();
    }
}
