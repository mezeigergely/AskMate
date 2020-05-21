using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Models
{
    public class QuestionDetailModel
    {
        public int Id { get; set; }
        public DateTime SubmissionTime { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public List<Answer> Answers { get; set; }

        public QuestionDetailModel(Question question, List<Answer> answers)
        {
            Id = question.Id;
            SubmissionTime = question.SubmissionTime;
            Title = question.Title;
            Message = question.Message;
            Answers = answers;
        }
    }
}
