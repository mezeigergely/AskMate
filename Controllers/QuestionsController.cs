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

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionsService questionsService)
        {
            _logger = logger;
            _questionsService = questionsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var questions = _questionsService.GetAll();
            return View(questions.Select(x => new QuestionModel(x)).ToList());
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var question = _questionsService.GetOne(id);
            return View(new QuestionModel(question));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddQuestionModel newQuestion)
        {
            int id = _questionsService.Create(newQuestion.Title, newQuestion.Message);
            return RedirectToAction("GetOne", new { id });
        }
    }
}