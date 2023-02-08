using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TriviaApi.DataAccess.Models;

public class QuestionModel
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement]
    public string Category { get; set; }

    [BsonElement]
    public string Type { get; set; }

    [BsonElement]
    public string Difficulty { get; set; }

    [BsonElement]
    public string Statement { get; set; }

    [BsonElement]
    public string CorrectAnswer { get; set; }

    [BsonElement]
    public IEnumerable<string> IncorrectAnswers { get; set; }
}