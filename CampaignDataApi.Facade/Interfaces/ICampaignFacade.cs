using CampaignDataApi.DataObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignDataApi.Facade.Interfaces
{
    /// <summary>
    /// Campaign Facade interface
    /// </summary>
    public interface ICampaignFacade
    {
        /// <summary>
        /// Gets all campagins.
        /// </summary>
        /// <returns>List of all campaigns</returns>
        Task<List<ICampaign>> GetAllCampagins();

        /// <summary>
        /// Gets the active campagins.
        /// </summary>
        /// <returns>List of all active campaigns</returns>
        Task<List<ICampaign>> GetActiveCampagins();

        /// <summary>
        /// Gets the closed campagins.
        /// </summary>
        /// <returns>List of all closed campaigns</returns>
        Task<List<ICampaign>> GetClosedCampagins();
    }
}
