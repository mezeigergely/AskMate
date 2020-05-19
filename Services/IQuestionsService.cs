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
        int Create(string title, string message);
    }
}
