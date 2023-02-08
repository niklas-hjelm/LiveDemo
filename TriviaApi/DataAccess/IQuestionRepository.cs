using TriviaApi.DataAccess.Models;

namespace TriviaApi.DataAccess;

public interface IQuestionRepository
{
    Task AddQuestion(QuestionModel question);
    Task<IEnumerable<QuestionModel>> GetAllQuestions();
}