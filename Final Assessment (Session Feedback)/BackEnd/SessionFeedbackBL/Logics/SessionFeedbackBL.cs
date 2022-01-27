using SessionFeedbackBL.Interface;
using SessionFeedbackBL.ViewModelBL;
using SessionFeedbackDAL.Interface;
using SessionFeedbackDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionFeedbackBL.Logics
{
   public class SessionFeedbackBl: ISessionFeedbackBL
    {
        private readonly ISessionFeedbackRepository _sessionFeedbackDAL;

        public SessionFeedbackBl(ISessionFeedbackRepository sessionFeedbackRepository)
        {
            this._sessionFeedbackDAL = sessionFeedbackRepository;
        }


        public void CreatFeedback(FeedbackVMBL feedbackVMBL, Guid userId)
        {
            FeedbackVM feedbackVM = new FeedbackVM();


           
            feedbackVM.Name = feedbackVMBL.Name;
            feedbackVM.SessionId = feedbackVMBL.SessionId;
            feedbackVM.Image = feedbackVMBL.Image;
            feedbackVM.GoodFeedback = feedbackVMBL.GoodFeedback;
            feedbackVM.BadFeedback = feedbackVMBL.BadFeedback;
            feedbackVM.Rating = feedbackVMBL.Rating;
           


            _sessionFeedbackDAL.CreateFeedback(feedbackVM,userId);

        }

        
        public async Task<IEnumerable<SessionVM>> GetAllSession()
        {
            return await _sessionFeedbackDAL.GetAllSession();
        }

        public async Task<List<SessionVM>> GetAllSessionList(int pageNo, int pageSize)
        {
            return await _sessionFeedbackDAL.GetSessionList(pageNo,pageSize);
        }

        public async Task<SessionCount> GetSessionCount()
        {
            return await _sessionFeedbackDAL.GetSessionCount();
        }


    }
}
