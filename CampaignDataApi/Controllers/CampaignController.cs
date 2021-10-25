using CampaignDataApi.DataObjects.Interfaces;
using CampaignDataApi.Facade.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignDataApi.Controllers
{
    [ApiController]
    [Route("/api/campaign-data")]
    public class CampaignController : ControllerBase
    {
        readonly ICampaignFacade _campaignFacade;

        public CampaignController(ICampaignFacade campaignFacade)
        {
            _campaignFacade = campaignFacade;
        }

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
