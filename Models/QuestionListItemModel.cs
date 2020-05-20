using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Models
{
    public class QuestionListItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public QuestionListItemModel(Question question)
        {
            Id = question.Id;
            Title = question.Title;
            Message = question.Message;
        }
    }
}
