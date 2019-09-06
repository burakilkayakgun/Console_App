using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class OperationResult
    {
        public bool IsFailed { get; set; }
        public string ErrorMessage { get; set; }
        public string ObjectId { get; set; }
        public void SetException(Exception ex)
        {
            IsFailed = true;
            ErrorMessage = ex.Message + ex.StackTrace;
            if (ex.InnerException != null) ErrorMessage += ex.InnerException.Message + ex.InnerException.StackTrace;
        }
    }
}
