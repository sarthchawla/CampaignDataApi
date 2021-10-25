using CampaignDataApi.DataObjects.Interfaces;
using CampaignDataApi.Facade.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignDataApi.Controllers
{
    /// <summary>
    /// CampaignController: Controller for all campaign related endpoints.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("/api/campaign-data")]
    public class CampaignController : ControllerBase
    {
        /// <summary>
        /// The campaign facade
        /// </summary>
        readonly ICampaignFacade _campaignFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignController"/> class.
        /// </summary>
        /// <param name="campaignFacade">The campaign facade.</param>
        public CampaignController(ICampaignFacade campaignFacade)
        {
            _campaignFacade = campaignFacade;
        }

        /// <summary>
        /// Lists all.
        /// </summary>
        /// <returns>List of all campaigns sorted by total amount.</returns>
        [HttpGet]
        [Route("list-all")]
        public async Task<ActionResult> ListAll()
        {
            Task<List<ICampaign>> campaignTask = Task.Run(() => _campaignFacade.GetAllCampagins());
            // thread is free to do other useful stuff right now

            // after a while result is needed, so await for campaignTask:
            List<ICampaign> campaigns = await campaignTask;


            return new JsonResult(campaigns.Select(campaign => new
            {
                campaign.Title,
                campaign.TotalAmount,
                campaign.BackersCount,
                campaign.EndDate
            }));
        }

        /// <summary>
        /// Lists the active.
        /// </summary>
        /// <returns>List of all active campaigns</returns>
        [HttpGet]
        [Route("list-active")]
        public async Task<List<ICampaign>> ListActive()
        {
            Task<List<ICampaign>> campaignTask = Task.Run(() => _campaignFacade.GetActiveCampagins());
            // thread is free to do other useful stuff right now

            // after a while result is needed, so await for campaignTask:
            List<ICampaign> campaigns = await campaignTask;

            return campaigns;
        }

        /// <summary>
        /// Lists the closed.
        /// </summary>
        /// <returns>list of all closed campaigns.</returns>
        [HttpGet]
        [Route("list-closed")]
        public async Task<List<ICampaign>> ListClosed()
        {
            Task<List<ICampaign>> campaignTask = Task.Run(() => _campaignFacade.GetClosedCampagins());
            // thread is free to do other useful stuff right now

            // after a while result is needed, so await for campaignTask:
            List<ICampaign> campaigns = await campaignTask;

            return campaigns;
        }
    }
}
