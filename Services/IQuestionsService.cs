using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Services
{
    public interface IQuestionsService
    {
        List<Question> GetAll();
        Question GetOne(int id);
        int Add(string title, string message, DateTime dateTime);
        void Delete(int id);
    }
}
