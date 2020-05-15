﻿using System;
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
            return View(questions);
        }
    }
}