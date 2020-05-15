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
    }
}
