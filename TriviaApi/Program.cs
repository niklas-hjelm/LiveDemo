using TriviaApi.DataAccess;
using TriviaApi.DTOs;
using TriviaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizService<QuestionDTO, QuizResponse>, QuizService>();
builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getQuestions", async (HttpClient client) =>
{
    var response = await client.GetAsync("https://opentdb.com/api.php?amount=10&difficulty=easy");
    return await response.Content.ReadAsStringAsync();
});

app.MapGet("/getQuestionsTyped/{difficulty}", async (HttpClient client,IQuizService<QuestionDTO, QuizResponse> quizService, string difficulty, int number) =>
{
    var response = await client.GetAsync($"https://opentdb.com/api.php?amount={number}&difficulty={difficulty}");
    var quizResponse = await response.Content.ReadFromJsonAsync<QuizResponse>();
    return await quizService.GetQuestions(quizResponse, difficulty, number);
});


app.Run();
