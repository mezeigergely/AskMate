using AskMate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskMate.Services
{
    public interface IAnswersService
    {
        List<Answer> GetAll(int questionId);
        Answer GetOne(int id);
        int Add(int questionId, string message, DateTime dateTime);
    }
}
