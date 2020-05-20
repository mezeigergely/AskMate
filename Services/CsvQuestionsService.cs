﻿using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Services
{
    public class CsvQuestionsService : BaseCsvService, IQuestionsService
    {
        public CsvQuestionsService(string csvPath) : base(csvPath)
        {
        }

        public int Create(string title, string message)
        {
            int nextId = GetAll().Select(x => x.Id).Max() + 1;
            appendTo(nextId, title, message);
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

        private Question toQuestion(string[] fields)
        {
            return new Question
            {
                Id = int.Parse(fields[0]),
                Title = fields[1],
                Message = fields[2]
            };
        }
    }
}
