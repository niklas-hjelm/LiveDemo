using MongoDB.Driver;
using TriviaApi.DataAccess.Models;

namespace TriviaApi.DataAccess;

public class QuestionRepository : IQuestionRepository
{
    private readonly IMongoCollection<QuestionModel> _questionCollection;

    public QuestionRepository()
    {
        var host = "localhost";
        var databaseName = "QuizDb";
        var connectionString = $"mongodb://{host}:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _questionCollection = database.GetCollection<QuestionModel>(
            "Questions",
            new MongoCollectionSettings() { AssignIdOnInsert = true }
            );
    }

    public async Task AddQuestion(QuestionModel question)
    {
        await _questionCollection.InsertOneAsync(question);
    }

    public async Task<IEnumerable<QuestionModel>> GetAllQuestions()
    {
        var allQuestions = 
            await _questionCollection.FindAsync(_ => true);
        return allQuestions.ToEnumerable();
    }
}