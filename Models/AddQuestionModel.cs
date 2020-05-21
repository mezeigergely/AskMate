using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Models
{
    public class AddQuestionModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}
