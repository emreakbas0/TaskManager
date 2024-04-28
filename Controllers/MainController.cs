using WEBPROJECT2.Interfaces;
using WEBPROJECT2.Models;
using WEBPROJECT2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WEBPROJECT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        readonly IUserService _userService;

        readonly IReportService _reportService;

        private static int id;

        public MainController(IUserService userService, IReportService reportService)
        {
            _userService = userService;
            _reportService = reportService;
        }

        [HttpPost("Create User")]
        [AllowAnonymous]

        public async Task<ActionResult<string>> createUser([FromQuery] string username, [FromQuery] string password, [FromQuery] string passwordagain)
        {
            var result = await _userService.createUser(username, password, passwordagain);
            return result;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<Tokens>> Login([FromQuery] string username, [FromQuery] string password)
        {
            var result = await _userService.login(username, password);
            id = result.ID;
            return result;
        }

        [HttpPost("CreateReport")]
        [Authorize]
         public async Task<ActionResult<string>> CreateReport([FromQuery] string categories, [FromQuery] string insider)
        {        
            var result = await _reportService.AddReport(id, categories, insider); 
            return result;
        }

        [HttpPost("ShowReport")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Reports>>> ShowReport()
        {
            var result = await _reportService.reports(id);
            return result;
        }

        [HttpPost("ShowReportByCategory")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Reports>>> ShowReportByCategory([FromQuery] string categories)
        {
            var result = await _reportService.reportByCat(id, categories);
            return result;
        }

        [HttpGet("GetReportByCategory")]
        [Authorize]
        public async Task<ActionResult<List<Reports>>> GetReportByCategory([FromQuery, Required] string categories){
            var result = await _reportService.reportByCat(id, categories);
            return result;
        }
    }

}
