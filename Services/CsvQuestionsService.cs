using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Services
{
    public class CsvQuestionsService : BaseCsvService, IQuestionsService
    {
        public CsvQuestionsService(string csvPath) : base(csvPath)
        {
        }

        public int Add(string title, string message, DateTime dateTime)
        {
            var questions = GetAll();
            int nextId = questions.Count == 0 ? 1 : questions.Select(x => x.Id).Max() + 1;
            dateTime = DateTime.Now;
            appendTo(nextId, title, message, dateTime);
            return nextId;
        }

        public List<Question> GetAll()
        {
            return readAllFrom()
                .Select(toQuestion)
                .ToList();
        }

        public Question GetOne(int id)
        {
            return toQuestion(readFrom(id));
        }

        public void Delete(int id)
        {
            deleteAt(id);
        }

        private Question toQuestion(string[] fields)
        {
            return new Question
            {
                Id = int.Parse(fields[0]),
                SubmissionTime = DateTime.Parse(fields[3]),
                Title = fields[1],
                Message = fields[2]
            };
        }
    }
}