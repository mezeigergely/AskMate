using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AskMate.Services
{
    public class CsvAnswersService : BaseCsvService, IAnswersService
    {
        public CsvAnswersService(string csvPath) : base(csvPath)
        {
        }

        public List<Answer> GetAll(int questionId)
        {
            return GetAll()
                .Where(x => x.QuestionId == questionId)
                .ToList();
        }

        public Answer GetOne(int id)
        {
            return ToAnswer(readFrom(id));
        }

        public int Add(int questionId, string message, DateTime dateTime)
        {
            var answers = GetAll();
            int nextId = answers.Count == 0 ? 1 : answers.Select(x => x.Id).Max() + 1;
            dateTime = DateTime.Now;
            appendTo(nextId, questionId, message, dateTime);
            return nextId;
        }

        public void Delete(int id)
        {
            deleteAt(id);
        }

        public void DeleteAll(int questionId)
        {
            deleteAt(fields => !fields[1].Equals(questionId.ToString()));
        }

        private List<Answer> GetAll()
        {
            return readAllFrom()
                .Select(ToAnswer)
                .ToList();
        }

        private Answer ToAnswer(string[] fields)
        {
            return new Answer
            {
                Id = int.Parse(fields[0]),
                QuestionId = int.Parse(fields[1]),
                Message = fields[2],
                SubmissionTime = DateTime.Parse(fields[3])
            };
        }
    }
}