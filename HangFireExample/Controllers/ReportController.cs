using Hangfire;
using Hangfire.States;
using Microsoft.AspNetCore.Mvc;

namespace HangFireExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpGet("GetReportWorst")]
        public async Task<IActionResult> GetRGetReportWorsteport()
        {
            await Task.Delay(TimeSpan.FromMinutes(1));
            return Ok();
        }

        [HttpPost("GetReportWithBackgroundJob")]
        public async Task<IActionResult> GetReportWithBackgroundJob()
        {
            IBackgroundJobClient client = new BackgroundJobClient();
            var jobId = client.Enqueue<ReportService>(job => job.GetReportAsync(CancellationToken.None));
            return Ok("BackgroundJob Started. jobId:" + jobId);
        }

        [HttpGet("GetJobDetail")]
        public async Task<IActionResult> GetJobDetail(string jobId)
        {
            var jobDetails = JobStorage.Current.GetMonitoringApi().JobDetails(jobId);
            var state = jobDetails.History.OrderByDescending(h => h.CreatedAt).First().StateName;
            return Ok(state);
        }
    }

    public class ReportService
    {
        public async Task GetReportAsync(CancellationToken cancellationToken)
        {
            //Do excel export things
            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
        }
    }
}
