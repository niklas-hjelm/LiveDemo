using TriviaApi.DataAccess;
using TriviaApi.DTOs;
using TriviaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizService<QuestionDTO, QuizResponse>, QuizService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getQuestions", async () =>
{
    var client = new HttpClient();
    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=easy");
    return await response.Content.ReadAsStringAsync();
});

app.MapGet("/getQuestionsTyped", async (IQuizService<QuestionDTO, QuizResponse> quizService) =>
{
    var client = new HttpClient();
    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=easy");
    var quizResponse = await response.Content.ReadFromJsonAsync<QuizResponse>();
    return await quizService.GetQuestions(quizResponse);
});


app.Run();