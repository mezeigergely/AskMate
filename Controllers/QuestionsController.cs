using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AskMate.Models;
using AskMate.Services;

namespace AskMate.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionsService _questionsService;
        private readonly IAnswersService _answersService;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionsService questionsService, IAnswersService answerService)
        {
            _logger = logger;
            _questionsService = questionsService;
            _answersService = answerService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var questions = _questionsService.GetAll();
            return View(questions.Select(x => new QuestionListItemModel(x)).ToList());
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var question = _questionsService.GetOne(id);
            var answers = _answersService.GetAll(id);
            return View(new QuestionDetailModel(question, answers));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddQuestionModel newQuestion)
        {
            int id = _questionsService.Create(newQuestion.Title, newQuestion.Message, DateTime.Now);
            return RedirectToAction("GetOne", new { id });
        }

        [HttpGet]
        [Route("[controller]/Add/[action]/{id}", Name = "add-answer")]
        public IActionResult Answer(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/Add/[action]/{id}", Name = "add-answer")]
        public IActionResult Answer(int id, AddAnswerModel newAnswer)
        {
            _answersService.Add(id, newAnswer.Message, DateTime.Now);
            return RedirectToAction("GetOne", new { id });
        }
    }
}