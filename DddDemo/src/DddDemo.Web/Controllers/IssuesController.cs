using DddDemo.Issues;
using DddDemo.Issues.Dtos;
using DddDemo.Web.Models.Issues;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DddDemo.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class IssuesController : Controller
    {
        private readonly IIssueAppService _issueAppService;
        private readonly IObjectMapper _objectMapper;

        public IssuesController(IIssueAppService issueAppService, IObjectMapper objectMapper)
        {
            _issueAppService = issueAppService;
            _objectMapper = objectMapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{id}")]
        public IActionResult Detail([FromRoute] string id)
        {
            var output = _issueAppService.GetIssue(new GetIssueInput { Id = id });
            var viewModel = _objectMapper.Map<IssueDetailViewModel>(output);
            return View(viewModel);
        }
    }
}
