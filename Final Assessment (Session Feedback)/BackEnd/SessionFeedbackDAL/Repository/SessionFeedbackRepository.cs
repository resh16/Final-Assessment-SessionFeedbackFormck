using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SessionFeedbackDAL.Data;
using SessionFeedbackDAL.Entities;
using SessionFeedbackDAL.Interface;
using SessionFeedbackDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionFeedbackDAL.Repository
{
   public class SessionFeedbackRepository:ISessionFeedbackRepository
    {

        private readonly IConfiguration _configuration;
        private readonly SessionFeedbackContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public SessionFeedbackRepository(IConfiguration configuration, SessionFeedbackContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._configuration = configuration;
            this._context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public void CreateFeedback(FeedbackVM feedbackVM, Guid userId)
        {
            Feedback feedback = new Feedback();

            if (_context.Feedbacks.ToList().Any(o => o.UserId == userId && o.SessionId == feedbackVM.SessionId))//if true,the record already exists
            {

                throw new Exception("Feedback already submitted");




            }

           

            FileInfo fi = new(feedbackVM.Image.FileName);

            var Filename = $"{DateTime.UtcNow.ToString("yyyyMMddTHHmmssfffffffK")}{fi.Extension}";

            //Store to filePath
            string filePath = Path.Combine(_configuration.GetSection("AppSettings:ImagePath").Value.ToString(), Filename);

            //if(fi.Length > 0 && fi.Length < 5e+6 &&  fi.Extension.ToLower() == ".jpeg" || fi.Extension.ToLower() == ".jpg")
            //{
            //    if (feedbackVM.Image != null)
            //    {



            //        using (var fs = File.Create(filePath))
            //        {
            //            feedbackVM.Image.CopyTo(fs);
            //        }

            //    }
            //}
            //else
            //{
            //    throw new Exception("Invalid filetype or filesize");
            //}


            if (feedbackVM.Image != null)
            {



                using (var fs = File.Create(filePath))
                {
                    feedbackVM.Image.CopyTo(fs);
                }

            }




            feedback.UserId = userId;
            feedback.Name = feedbackVM.Name; // title
            feedback.SessionId = feedbackVM.SessionId;
            feedback.GoodFeedback = feedbackVM.GoodFeedback;
            feedback.BadFeedback = feedbackVM.BadFeedback;
            feedback.Rating = feedbackVM.Rating;
            feedback.Image = feedbackVM.Image.FileName;
            feedback.UniqueImageName = Filename;
            feedback.CreatedAt = DateTime.UtcNow;
            feedback.CreatedBy = userId;

           
           
               
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
            

          
            


        }


        public async Task<IEnumerable<SessionVM>> GetAllSession()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "usp_GetAllSessions";

            var listOfSession = await Task.FromResult(dbConnection.Query<SessionVM>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfSession;
        }



        public async Task<List<SessionVM>> GetSessionList(int pageNo, int pageSize)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "usp_GetAllSessions2";

            DynamicParameters parameters = new();

            parameters.Add("PageNo", pageNo);
            parameters.Add("PageSize", pageSize);
           

            var sessions = await Task.FromResult(dbConnection.Query<SessionVM>(sp,parameters, commandType: CommandType.StoredProcedure).ToList());

            return sessions;
        }


        public async Task<SessionCount> GetSessionCount()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[Usp_getAllSessionCount]";

            var count = await Task.FromResult(dbConnection.Query<SessionCount>(sp, commandType: CommandType.StoredProcedure).First());

            return count;
        }

    }
}
