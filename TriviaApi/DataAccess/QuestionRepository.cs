using Amazon.Auth.AccessControlPolicy;
using MongoDB.Bson.Serialization;
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

    public async Task<IEnumerable<QuestionModel>> GetQuestions(string difficulty, int number)
    {
        var filter = Builders<QuestionModel>.Filter.Eq("Difficulty", difficulty);
        var count = await _questionCollection.CountDocumentsAsync(filter);

        if (count < number)
        {
            var all = await _questionCollection.FindAsync(filter);

            return all.ToEnumerable();
        }

        var results = new HashSet<QuestionModel>(new QuestionEqualityComparer());
        var rand = new Random();

        while (results.Count < number)
        {
            var index = rand.Next((int) count);
            var question = _questionCollection.Find(filter).Skip(index).FirstOrDefault();

            results.Add(question);
        }

        return results;
    }

    public async Task<bool> HasQuestion(string statement)
    {
        var filter = Builders<QuestionModel>.Filter.Eq("Statement", statement);
        var exists = await _questionCollection.FindAsync(filter);

        return exists is not null && exists.ToList().Count > 0;
    }
}