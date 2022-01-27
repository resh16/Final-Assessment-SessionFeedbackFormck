using SessionFeedbackBL.ViewModelBL;
using SessionFeedbackDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionFeedbackBL.Interface
{
   public interface ISessionFeedbackBL
    {
        public void CreatFeedback(FeedbackVMBL feedbackVMBL, Guid userId);
        Task<IEnumerable<SessionVM>> GetAllSession();

       Task<List<SessionVM>> GetAllSessionList(int pageNo, int pageSize);

        Task<SessionCount> GetSessionCount();
    }

   
}
