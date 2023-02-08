using System.Text.Json.Serialization;

namespace TriviaApi.DTOs;

public class QuestionDTO
{
    public string Category { get; set; }
    public string Type { get; set; }
    public string Difficulty { get; set; }

    [JsonPropertyName("question")]
    public string Statement { get; set; }

    [JsonPropertyName("correct_answer")]
    public string CorrectAnswer { get; set; }

    [JsonPropertyName("incorrect_answers")]
    public IEnumerable<string> IncorrectAnswers { get; set; }
}