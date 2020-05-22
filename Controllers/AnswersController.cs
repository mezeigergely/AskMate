using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskMate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AskMate.Controllers
{
    public class AnswersController : Controller
    {
        private readonly ILogger<AnswersController> _logger;
        private readonly IAnswersService _answersService;

        public AnswersController(ILogger<AnswersController> logger, IAnswersService answerService)
        {
            _logger = logger;
            _answersService = answerService;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _answersService.Delete(id);
            return Redirect(Request.Headers["Referer"]);
        }
    }
}