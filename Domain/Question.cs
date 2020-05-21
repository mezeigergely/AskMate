using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public DateTime SubmissionTime { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
