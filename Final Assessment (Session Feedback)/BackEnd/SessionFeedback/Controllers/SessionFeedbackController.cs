using CustomIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SessionFeedbackBL.Interface;
using SessionFeedbackBL.ViewModelBL;
using SessionFeedbackDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionFeedback.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionFeedbackController : ControllerBase
    {

       
            private readonly ISessionFeedbackBL _sessionFeedbackBL;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IConfiguration _configuration;
            private readonly UserManager<AppUser> _userManager;

        private readonly ILogger<SessionFeedbackController> _logger;

        




        public SessionFeedbackController(ILogger<SessionFeedbackController> logger, ISessionFeedbackBL sessionFeedbackBL, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)  //:base(userManager)
            {
                this._sessionFeedbackBL = sessionFeedbackBL;
                this._configuration = configuration;
                _httpContextAccessor = httpContextAccessor;
                this._userManager = userManager;
            _logger = (ILogger<SessionFeedbackController>)logger;


        }

            [HttpPost]
          
           [Authorize]
            public IActionResult CreatFeedback([FromForm]FeedbackVMBL feedbackVMBL)
            {
            try
            {


                 //var userId = User.Claims.First(a => a.Type == "UserId").Value;  //
               // Guid currentUserId =  Guid.Parse("43618AED-AE3C-40F8-F907-08D9D668319B");

                var userId = User.Claims.First(a => a.Type == "UserId").Value;
                Guid currentUserId = Guid.Parse(userId);



                _sessionFeedbackBL.CreatFeedback(feedbackVMBL, currentUserId);



              
                return Ok();
            }
            catch (Exception e)
            {
               // return StatusCode(StatusCodes.Status500InternalServerError, new {  Status = "Error", Message = "Feedback already submitted" });
                // throw ;
                return BadRequest("{Message':" +e.Message+"}");
            }


            }

            [HttpGet]
            public async Task<IActionResult> GetSession()
            {

                _logger.LogInformation("Session feedback Controller Invoked");

            

                try
                {
                    IEnumerable<SessionVM> sessionList = await _sessionFeedbackBL.GetAllSession();

                        return Ok(sessionList);
                }
                catch (Exception e)
                {
                    _logger.LogError("Exception thrown......");
                    throw new Exception(e.InnerException.Message);
                       
                }

            }

        [HttpGet]
        public async Task<IActionResult> GetSessionList(int pageNo, int pageSize)
        {

            



            try
            {
               List<SessionVM> sessionList = await _sessionFeedbackBL.GetAllSessionList(pageNo,pageSize);

                return Ok(sessionList);
            }
            catch (Exception e)
            {
               
                throw new Exception(e.InnerException.Message);

            }

        }


        [HttpGet]
        public async Task<IActionResult> GetSessionCount()
        {


            try
            {
                var sessionCount = await _sessionFeedbackBL.GetSessionCount();

                return Ok(sessionCount);
            }
            catch (Exception e)
            {

                throw new Exception(e.InnerException.Message);

            }

        }




    }
}
