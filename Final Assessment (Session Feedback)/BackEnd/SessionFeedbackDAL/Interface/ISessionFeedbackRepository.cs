using SessionFeedbackDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionFeedbackDAL.Interface
{
    public interface ISessionFeedbackRepository
    {
        public void CreateFeedback(FeedbackVM feedbackVM, Guid userId);
        Task<IEnumerable<SessionVM>> GetAllSession();

        Task<List<SessionVM>> GetSessionList(int pageNo, int pageSize);

         Task<SessionCount> GetSessionCount();
    }
}
