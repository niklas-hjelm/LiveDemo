using TriviaApi.DataAccess.Models;

namespace TriviaApi.DataAccess;

public interface IQuestionRepository
{
    Task AddQuestion(QuestionModel question);
    Task<IEnumerable<QuestionModel>> GetAllQuestions();
    Task<IEnumerable<QuestionModel>> GetQuestions(string difficulty, int number);
    Task<bool> HasQuestion(string statement);
}