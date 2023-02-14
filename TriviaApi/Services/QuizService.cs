using TriviaApi.DataAccess;
using TriviaApi.DataAccess.Models;
using TriviaApi.DTOs;

namespace TriviaApi.Services;

public class QuizService : IQuizService<QuestionDTO, QuizResponse>
{
    private readonly IQuestionRepository _repository;

    public QuizService(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<QuestionModel>> GetQuestions(QuizResponse response, string difficulty, int number)
    {
        foreach (var question in response.Results)
        {
            await Add(question);
        }

        return await _repository.GetQuestions(difficulty, number);
    }

    public async Task Add(QuestionDTO item)
    {
        if (await _repository.HasQuestion(item.Statement))
        {
            return;
        }

        await _repository.AddQuestion(ConvertToModel(item));
    }

    private QuestionModel ConvertToModel(QuestionDTO item)
    {
        return new QuestionModel()
        {
            Statement = item.Statement,
            Category = item.Category,
            CorrectAnswer = item.CorrectAnswer,
            Difficulty = item.Difficulty,
            IncorrectAnswers = item.IncorrectAnswers.ToList(),
            Type = item.Type
        };
    }
}