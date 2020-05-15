# AskMate

5/15/2020
1. mvc starter app
2. Domain/Question.cs
3. Services/IQuestionsService.cs -> PUBLIC INTERFACE
        - List<Question> GetAll();
4. QuestionController.cs (All function -> listed questions)
5. Services/InMemoryQuestionService.cs
        - inherited from IQuestionsService
        - declared list<question>
        - in constructor: hard coded questions
        - add questions into list
6. Views/Questions/All.cshtml
        - view to questionList
7. IQuestionsService registration into Startup.cs
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton(typeof(IQuestionsService), new InMemoryQuestionsService());
        }
