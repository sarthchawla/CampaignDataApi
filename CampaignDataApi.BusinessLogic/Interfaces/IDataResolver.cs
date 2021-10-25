using CampaignDataApi.DataObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.BusinessLogic.Interfaces
{
    /// <summary>
    /// The interface of data resolver.
    /// </summary>
    public interface IDataResolver
    {
        /// <summary>
        /// Gets all campaigns.
        /// </summary>
        /// <returns>List of all campaigns</returns>
        Task<List<ICampaign>> GetAllCampaigns();

        /// <summary>
        /// Gets the active campaigns.
        /// </summary>
        /// <returns>List of all active campaigns</returns>
        Task<List<ICampaign>> GetActiveCampaigns();

        /// <summary>
        /// Gets the closed campaigns.
        /// </summary>
        /// <returns>List of all closed campaigns</returns>
        Task<List<ICampaign>> GetClosedCampaigns();
    }
}
