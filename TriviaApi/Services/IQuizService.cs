using TriviaApi.DataAccess.Models;

namespace TriviaApi.Services;

public interface IQuizService<T, TU>    where T : class
                                        where TU : class
{
    Task<IEnumerable<QuestionModel>> GetQuestions(TU response, string difficulty, int number);

    Task Add(T item);
}